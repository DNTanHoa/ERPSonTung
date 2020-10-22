import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { Grid, GridColumn as Column, GridToolbar } from '@progress/kendo-react-grid';
import { AutoComplete, ComboBox, DropDownList, MultiSelect } from '@progress/kendo-react-dropdowns';
import config from '../../appsettings.json';
import { CategoryCommandCell } from "./category-command.jsx";
import { getEntities } from "../../apis/entitycenter/entitycenter-service"
import { Loading } from '../loading';
import { ToastContainer, toast } from 'react-toastify';
import { insertCategory, getCategories, updateItem, deleteItem, getCategoriesByEntity } from "../../apis/category/category-service";
import { filterBy } from '@progress/kendo-data-query';


let entities = [];

let categories = [];

const delay = 300;

export class Category extends React.Component {

    constructor(props) {
        super(props);

        this.search = this.search.bind(this);
    }

    editField = "inEdit";

    state = {
        data: [],
        editID: null,
        skip: 0,
        take: 1000,
        selectedEntity:"",
        loading: false,
        entities:[]
    }

    url = config.appSettings.ServerUrl + 'category/getall'

    init = { 
        method: 'GET',
        headers: new Headers({
            Accept: 'application/json, text/plain',
            'Content-Type': 'application/json;charset=UTF-8',
            Authorization: 'Bearer ' + localStorage.getItem('token'),
        })
    };

    CommandCell = props => (
        <CategoryCommandCell
            {...props}
            edit={this.enterEdit}
            remove={this.remove}
            add={this.add}
            discard={this.discard}
            update={this.update}
            cancel={this.cancel}
            editField={this.editField}
        />
    );

    componentDidMount = async () =>  {
        this.setState({loading: true})
        categories = await getCategories();
        entities = await getEntities();
        this.setState({data: categories, entities: entities ,loading: false});
    }

    search = async (e) => {
        this.setState({loading: true});
        let result = categories.filter(item => item.entity.includes(this.state.selectedEntity))
        this.setState({data: result, loading: false});
    }

    filterEntitiesChange = (e) => {
        clearTimeout(this.timeout);
        this.timeout = setTimeout(() => {
            this.setState({entities: this.filterEntities(e.filter)});
        }, delay);
    }

    filterEntities(filter) {
        return filterBy(entities, filter);
    }

    selectedEntityChange = (e) => {
        this.setState({selectedEntity: e.value.entity});
    }

    render() {
        return (
            <div className="container-fluid">
                <section className="content-header">
                    <div className="container-fluid">
                        <div className="row mb-2">
                            <div className="col-sm-6">
                                <h1 className="float-sm-left">Quản lý danh mục</h1>
                            </div>
                            <div className="col-sm-6">
                                <ol className="breadcrumb float-sm-right">
                                    <li className="breadcrumb-item"><a href="#">Quản lý danh mục</a></li>
                                    <li className="breadcrumb-item active">Danh sách đối tượng</li>
                                </ol>
                            </div>
                        </div>
                    </div>
                </section>
                <section className="content">
                    <div className="container-fluid">
                        <div className="row">
                            <div className="card w-100" style={{overflowX:"auto"}}>
                                <div className="card-header">
                                    <div className="row">
                                        <div className="col-md-1 mt-md-1">
                                            <b>Danh mục</b>
                                        </div>
                                        <div className="col-md-4">
                                            <DropDownList data={this.state.entities} 
                                                textField="note"
                                                dataItemKey="entity"
                                                delay={1000}
                                                defaultItem={{note :"-- Tất cả --", entity : ""}}
                                                filterable={true}
                                                value={this.state.value}
                                                onChange={this.selectedEntityChange}
                                                onFilterChange={this.filterEntitiesChange}
                                                style={{width: '100%'}}/>
                                        </div>
                                        <div class="col-md-1 mt-1 mt-md-0">
                                            <button type="button" class="btn btn-success w-100" onClick={this.search}>
                                                <span class="fa fa-search"></span>
                                            </button>
                                        </div>
                                    </div>
                                </div>
                                <div className="card-body">
                                <Grid style={{ height: "550px" }}
                                        data={this.state.data.slice(this.state.skip, this.state.take + this.state.skip)}
                                        onItemChange={this.itemChange}
                                        pageable={true}
                                        resizable={true}
                                        total={this.state.data.length}
                                        skip={this.state.skip}
                                        take={this.state.take}
                                        onPageChange={this.pageChange}
                                        editField={this.editField}>
                                        <GridToolbar>
                                            <button title="Thêm mới"
                                                    className="btn btn-success"
                                                    onClick={this.addNew}>
                                                <i className="fas fa-plus-circle"></i>
                                            </button>
                                        </GridToolbar>
                                        <Column field="id" title="ID" width="80px" editable={false}/>
                                        <Column field="code" title="Mã quản lý" width="200px" />
                                        <Column field="entity" title="Đối tượng" width="200px" />
                                        <Column field="subCode" title="Mã phụ" width="200px" />
                                        <Column field="name" title="Tên hiển thị" width="200px" />
                                        <Column field="note" title="Ghi chú"/>
                                        <Column cell={this.CommandCell} width="200px" locked={true}/>
                                </Grid>
                                {this.state.loading === true ? <Loading></Loading> : null} 
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        );
    }
    pageChange = (event) => {
        this.setState({
            skip: event.page.skip,
            take: event.page.take
        });
    }

    remove = dataItem => {
        const data = deleteItem(dataItem);
        this.setState({ data });
    };

    add = dataItem => {
        dataItem.inEdit = true;

        const data = insertCategory(dataItem);
        this.setState({
            data: data
        });
    };

    update = dataItem => {
        dataItem.inEdit = false;
        const data = updateItem(dataItem);
        this.setState({ data });
    };

    discard = dataItem => {
        const data = [...this.state.data];
        data.splice(0, 1)
        this.setState({ data });
    };

    cancel = dataItem => {
        const originalItem = getCategories().find(
            p => p.id === dataItem.id
        );
        const data = this.state.data.map(item =>
            item.id === originalItem.id ? originalItem : item
        );

        this.setState({ data });
    };

    enterEdit = dataItem => {
        this.setState({
            data: this.state.data.map(item =>
                item.id === dataItem.id ? { ...item, inEdit: true } : item
            )
        });
    };

    itemChange = event => {
        const data = this.state.data.map(item =>
            item.id === event.dataItem.id
                ? { ...item, [event.field]: event.value }
                : item
        );

        this.setState({ data });
    };

    addNew = () => {
        const newDataItem = { inEdit: true, Discontinued: false };

        this.setState({
            data: [newDataItem, ...this.state.data]
        });
    };

}
