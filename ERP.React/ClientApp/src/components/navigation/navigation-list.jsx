import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { Grid, GridColumn as Column, GridToolbar } from '@progress/kendo-react-grid';
import { AutoComplete, ComboBox, DropDownList, MultiSelect } from '@progress/kendo-react-dropdowns';
import config from '../../appsettings.json';
import { getEntities } from "../../apis/entitycenter/entitycenter-service"
import { Loading } from '../loading';
import { ToastContainer, toast } from 'react-toastify';
import { insertCategory, getCategories, updateItem, deleteItem, getCategoriesByEntity } from "../../apis/category/category-service";
import { filterBy } from '@progress/kendo-data-query';
import {NavigationCommandCell} from './navigation-command'
import { getNavigations } from '../../apis/navigation/navigation-service';

export class Navigation extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            navigationTypes:[],
            navigations: []
        }
    }

    componentDidMount = async () => {
        let navigationTypes = await getCategoriesByEntity('NavigationType');
        let navigations = await getNavigations();
        this.setState({ navigationTypes, navigations });
    }

    CommandCell = props => (
        <NavigationCommandCell {...props}
            edit={this.enterEdit}
            remove={this.delete}
            add={this.add}
            detail={this.detail}
            discard={this.discard}
            update={this.update}
            cancel={this.cancel}
            editField={this.editField}></NavigationCommandCell>
    )

    render = () => {
        return(
            <div className="container-fluid">
                <section className="content-header">
                    <div className="container-fluid">
                        <div className="row mb-2">
                            <div className="col-sm-6">
                                <h1 className="float-sm-left">Quản lý điều hướng</h1>
                            </div>
                            <div className="col-sm-6">
                                <ol className="breadcrumb float-sm-right">
                                    <li className="breadcrumb-item"><a href="#">Quản lý hệ thống</a></li>
                                    <li className="breadcrumb-item active">Điều hướng hệ thống</li>
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
                                        <div class="col-md-4">
                                            <DropDownList data={this.state.navigationTypes} 
                                                textField="name"
                                                dataItemKey="code"
                                                delay={1000}
                                                defaultItem={{name :"-- Tất cả --", code : ""}}
                                                filterable={true}
                                                value={this.state.value}
                                                onChange={this.selectedEntityChange}
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
                                        data={this.state.navigations}
                                        onItemChange={this.itemChange}
                                        pageable={true}
                                        resizable={true}
                                        editField={this.editField}>
                                        <GridToolbar>
                                            <button title="Thêm mới"
                                                    className="btn btn-success"
                                                    onClick={this.addNew}>
                                                <i className="fas fa-plus-circle"></i>
                                            </button>
                                            <button title="Tải lại"
                                                    className="btn btn-success"
                                                    onClick={this.addNew}>
                                                <i class="fas fa-sync"></i>
                                            </button>
                                        </GridToolbar>
                                        <Column field="id" title="ID" width="80px" editable={false} />
                                        <Column field="type" title="Phân loại" width="200px" />
                                        <Column field="displayName" title="Tên hiển thị" width="200px" />
                                        <Column field="code" title="Mã" width="200px" />
                                        <Column field="componentPath" title="ComponentPath" width="200px" />
                                        <Column field="sortOrder" title="Sắp xếp" width="200px" />
                                        <Column field="note" title="Ghi chú" />
                                        <Column cell={this.CommandCell} width="200px" />
                                </Grid>
                                {this.state.loading === true ? <Loading></Loading> : null} 
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        )
    }
}