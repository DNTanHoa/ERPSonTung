import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { Grid, GridColumn as Column, GridToolbar } from '@progress/kendo-react-grid';
import config from '../../appsettings.json';
import { CategoryCommandCell } from "./category-command.jsx";
import { insertItem, getItems, updateItem, deleteItem } from "./category-service.js";


export class Category extends React.Component {
    editField = "inEdit";

    state = {
        data: [],
        editID: null,
        skip: 0,
        take: 10
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

    componentDidMount() {
        fetch(this.url, this.init)
        .then(response =>
            response.json()
        )
        .then(json => {
            this.setState({
                data: json.data
            });
        });
        // this.setState({
        //     data: getItems()
        // });
    }

    dataRecieved = (data) => {
        this.setState({
            data: data
        });
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
                                    <li className="breadcrumb-item active">Danh sácch đối tượng</li>
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
                                    <h3 className="card-title">Danh sách đối tượng</h3>
                                </div>
                                <div className="card-body">
                                <Grid style={{ height: "550px" }}
                                        data={this.state.data.slice(this.state.skip, this.state.take + this.state.skip)}
                                        onItemChange={this.itemChange}
                                        pageable={true}
                                        total={this.state.data.length}
                                        skip={this.state.skip}
                                        take={this.state.take}
                                        onPageChange={this.pageChange}
                                        editField={this.editField}>
                                        <GridToolbar>
                                            <button title="Add new"
                                                    className="btn btn-success"
                                                    title="Thêm thành viên"
                                                    onClick={this.addNew}>
                                                <i className="fas fa-plus-circle"></i>
                                            </button>
                                        </GridToolbar>
                                        <Column field="id" title="ID" width="80px" editable={false} />
                                        <Column field="code" title="Mã quản lý" width="200px" />
                                        <Column field="entity" title="Đối tượng" width="200px" />
                                        <Column field="subCode" title="Mã phụ" width="200px" />
                                        <Column field="name" title="Tên hiển thị" width="200px" />
                                        <Column field="note" title="Ghi chú" />
                                        <Column cell={this.CommandCell} width="200px" />
                                </Grid>
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

        const data = insertItem(dataItem);
        this.setState({
            data: data
        });
    };

    update = dataItem => {
        dataItem.inEdit = false;
        const data = updateItem(dataItem);
        this.setState({ data });
    };

    // Local state operations
    discard = dataItem => {
        const data = [...this.state.data];
        data.splice(0, 1)
        this.setState({ data });
    };

    cancel = dataItem => {
        const originalItem = getItems().find(
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
