import React, { Component } from 'react';
import * as ReactDOM from 'react-dom';
import { Grid, GridColumn as Column, GridToolbar } from '@progress/kendo-react-grid';
import { CommandCell } from '../command/common-command';
import { process } from '@progress/kendo-data-query';
import { UserProvider, UserConxtext } from '../../providers/context/user-context'
import { getUsers, insertUser } from '../../apis/user/user-service';
import { Loading } from '../loading';


export class User extends Component {
    constructor(props) {
        super(props);

        this.state = {
            data: [],
            editUserName : null,
            skip: 0,
            take: 20,
            loading: false
        }
    }

    componentDidMount = async () => {
        this.setState({loading: true})
        let users = await getUsers();
        this.setState({data: users, loading: false});
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

    pageChange = (event) => {
        this.setState({
            skip: event.page.skip,
            take: event.page.take
        });
    }

    add = (dataItem) => {
        dataItem.inEdit = true;
        const data = insertUser(dataItem);
        this.setState({
            data: this.state.data.concat(data)
        });
    };

    enterEdit = dataItem => {
        this.setState({
            data: this.state.data.map(item =>
                item.username === dataItem.username ? { ...item, inEdit: true } : item
            )
        });
    };

    itemChange = event => {
        const data = this.state.data.map(item =>
            item.username === event.dataItem.username
                ? { ...item, [event.field]: event.value }
                : item
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
                                <Grid style={{ height: '600px' }}
                                    data={this.state.data.slice(this.state.skip, this.state.take + this.state.skip)}
                                    onItemChange={this.itemChange}
                                    pageable={{
                                        buttonCount: 5,
                                        info: true,
                                        type: 'numeric',
                                        pageSizes: true,
                                        previousNext: true
                                    }}
                                    total={this.state.data.length}
                                    skip={this.state.skip}
                                    resizable={true}
                                    take={this.state.take}
                                    onPageChange={this.pageChange}
                                    editField="inEdit">
                                    <GridToolbar>
                                        <button title="Thêm người dùng"
                                                className="btn btn-success"
                                                onClick={this.add}>
                                            <i className="fas fa-plus-circle"></i>
                                        </button>
                                    </GridToolbar>
                                    <Column field="username" title="Tài khoản" width="250" editor="text" />
                                    <Column field="password" title="Mật khẩu" width="300" editor="text"/>
                                    <Column field="guidCode" title="Khóa" width="350" editor="text" editable={false}/>
                                    <Column field="employeeCode" title="Nhân viên" width="300"/>
                                    <Column field="note" title="Ghi chú"/>
                                    <Column cell={this.CommandCell} />
                                </Grid>
                                {this.state.loading === true ? <Loading></Loading> : null} 
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        )
    }   
}
