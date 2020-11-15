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
import CategoryModal from './category-modal';
import { Modal } from 'react-bootstrap';

let categories = [];

export class CategoryDistinct extends React.Component {
    constructor(props) {
        super(props)
        
        this.state = {
            data: [],
            editID: null,
            skip: 0,
            take: 1000,
            selectedEntity:"",
            loading: false,
            entities:[],
            showModal: false
        }
    }

    componentDidMount = async () =>  {
        this.setState({loading: true})
        categories = await getCategoriesByEntity(this.props.entity);
        this.setState({data: categories,loading: false});
    }

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

    addNew = () => {
        this.setState({showModal: true});
    }

    render = () => {
        return(
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
                                    <h3 className="card-title">Danh mục {this.props.categoryName}</h3>
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
                                        <Column field="id" title="ID" width="80px" editable={false} />
                                        <Column field="code" title="Mã quản lý" width="200px" />
                                        <Column field="subCode" title="Mã phụ" width="200px" />
                                        <Column field="name" title="Tên" />
                                        <Column field="note" title="Ghi chú" />
                                        <Column cell={this.CommandCell} width="200px" />
                                </Grid>
                                {this.state.loading === true ? <Loading></Loading> : null}
                                <Modal centered={false} 
                                    size="md"
                                    onHide={this.handleModalHide}
                                    enforceFocus={false}
                                    show={this.state.showModal}>
                                    <CategoryModal onHide={this.handleModalHide}
                                        model={this.state.selectedNavigation}></CategoryModal>
                                </Modal>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        )
    }
}