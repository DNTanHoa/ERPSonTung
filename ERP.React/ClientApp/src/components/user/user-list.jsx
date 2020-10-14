import React, { Component } from 'react';
import * as ReactDOM from 'react-dom';
import { Grid, GridColumn as Column, GridToolbar } from '@progress/kendo-react-grid';
import { UsersLoader } from './user-loader';
import { CommandCell } from '../command/common-command';
import { process } from '@progress/kendo-data-query';


export class User extends Component {
    constructor(props) {
        super(props);

        this.state = {
            data: [],
            editUserName : null,
        }
    }

    CommandCell = props => (
        <CommandCell
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

    remove = dataItem => {

    };

    add = dataItem => {
        dataItem.inEdit = true;
    };

    update = dataItem => {
        dataItem.inEdit = false;
    };

    dataStateChange = (e) => {
        this.setState({
            ...this.state,
            dataState: e.data
        });
    }

    dataRecieved = (data) => {
        this.setState({
            data: data,
        });
    }

    addNew = () => {
        const { users } = this.state.data;
        const newItem = { };
        this.setState({
            data: [newItem, ...users],
            editUserName : '',
        });
    };

    closeEdit = (event) => {
        if (event.target === event.currentTarget) {
            this.setState({ editID: null });
        }
    };

    rowClick = (event) => {
        this.setState({
            editID: event.dataItem.ProductID
        });
    };

    itemChange = (event) => {
        const inEditID = event.dataItem.userName;
        const data = this.state.data.map(item =>
            item.ProductID === inEditID ? {...item, [event.field]: event.value} : item
        );
        this.setState({ data });
    };

    render () {
        return (
            <div className="container-fluid">
                <section className="content-header">
                    <div className="container-fluid">
                        <div className="row mb-2">
                            <div className="col-sm-6">
                                <h1 className="float-sm-left">Quản lý thành viên</h1>
                            </div>
                            <div className="col-sm-6">
                                <ol className="breadcrumb float-sm-right">
                                    <li className="breadcrumb-item"><a href="#">Quản lý hệ thống</a></li>
                                    <li className="breadcrumb-item active">Danh sách thành viên</li>
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
                                    <h3 className="card-title">Danh sách thành viên</h3>
                                </div>
                                <div className="card-body">
                                    <Grid style={{ height: '550px' }}
                                          sortable={true}
                                          data={this.state.data}
                                          onRowClick={this.rowClick}
                                          editField="inEdit"
                                          onItemChange={this.itemChange}
                                          onDataStateChange={this.dataStateChange}>
                                              <GridToolbar>
                                                    <button title="Add new"
                                                            className="btn btn-success"
                                                            title="Thêm thành viên"
                                                            onClick={this.addNew}>
                                                        <i className="fas fa-plus-circle"></i>
                                                    </button>
                                                </GridToolbar>
                                        <Column field="username" title="Tài khoản" width="150" editor="text" />
                                        <Column field="password" title="Mật khẩu" width="150" editor="text" editable={false}/>
                                        <Column field="guidCode" title="Khóa" width="450" editor="text" editable={false}/>
                                        <Column field="employeeCode" title="Nhân viên" width="300"/>
                                        <Column field="note" title="Ghi chú"/>
                                        <Column cell={this.CommandCell} />
                                    </Grid>
                                    <UsersLoader
                                        dataState={this.state.dataState}
                                        onDataRecieved={this.dataRecieved}></UsersLoader>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        )
    }   
}
