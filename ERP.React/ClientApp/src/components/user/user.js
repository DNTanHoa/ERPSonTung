import React, { Component } from 'react';
import * as ReactDOM from 'react-dom';
import { Grid, GridColumn as Column } from '@progress/kendo-react-grid';
import { UsersLoader } from './user-loader'
import { process } from '@progress/kendo-data-query';


export class User extends Component {
    constructor(props) {
        super(props);
        this.state = {
            products: { data: [], total: 0 },
            dataState: { take: 10, skip: 0 }
        };
    }

    dataStateChange = (e) => {
        this.setState({
            ...this.state,
            dataState: e.data
        });
    }

    dataRecieved = (products) => {
        this.setState({
            ...this.state,
            products: products
        });
    }

    render () {
        return (
            <div className="container-fluid">
                <section className="content-header">
                    <div className="container-fluid">
                        <div className="row mb-2">
                            <div className="col-sm-6">
                                <ol className="breadcrumb float-sm-left">
                                    <li className="breadcrumb-item"><a href="#">Quản lý hệ thống</a></li>
                                    <li className="breadcrumb-item active">Danh sách thành viên</li>
                                </ol>
                            </div>
                            <div className="col-sm-6">
                                <h1 className="float-sm-right">Danh sách thành viên</h1>
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
                                          pageable={true}
                                          {...this.state.dataState}
                                          {...this.state.products}
                                          onDataStateChange={this.dataStateChange}>
                                        <Column field="Username" title="Tài khoản" width="150" />
                                        <Column field="Password" title="Mật khẩu" width="150" />
                                        <Column field="GuidCode" title="Khóa" width="250"/>
                                        <Column field="Employee" title="Nhân viên" width="300"/>
                                        <Column field="Note" title="Ghi chú" />
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
