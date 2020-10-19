import React, { Component } from 'react';
import * as ReactDOM from 'react-dom';
import { Grid, GridColumn as Column, GridToolbar } from '@progress/kendo-react-grid';
import { CommandCell } from '../command/common-command';
import { process } from '@progress/kendo-data-query';
import { UserProvider, UserConxtext } from '../../providers/context/user-context'
import { getUsers, insertUser, updateUser } from '../../apis/user/user-service';
import { Loading } from '../loading';
import { ToastContainer, toast } from 'react-toastify';    
import 'react-toastify/dist/ReactToastify.css'; 
import { UserCommandCell } from './user-command';

let container;

export class User extends Component {
    constructor(props) {
        super(props);

        this.state = {
            data: [],
            editUserName : null,
            skip: 0,
            take: 20,
            loading: false,
            isAddingNew: false,
        }
    }

    editField = 'inEdit';

    componentDidMount = async () => {
        this.setState({loading: true})
        let users = await getUsers();
        this.setState({data: users, loading: false});
    }

    CommandCell = props => (
        <UserCommandCell
            {...props}
            edit={this.enterEdit}
            remove={this.remove}
            add={this.add}
            detail={this.detail}
            discard={this.discard}
            update={this.update}
            cancel={this.cancel}
            editField={this.editField}/>
    );

    pageChange = (event) => {
        this.setState({
            skip: event.page.skip,
            take: event.page.take
        });
    }

    add = async (dataItem) => {
        this.setState({loading : true});

        let response = await insertUser(dataItem);
        
        if(response.result.resultType == 0) {
            dataItem = response.data;
            let newData = this.state.data.slice(1);
            newData.push(dataItem);
            this.setState({
                isAddingNew: false,
                data: newData
            });
            toast.success(`Thêm thành viên ${dataItem.username} thành công`, 2000);
        } else {
            dataItem.inEdit = true;
            dataItem.editField = 'inEdit';
            toast.error(response.result.message, 2000);
        }

        this.setState({loading : false});
    };

    update = async (dataItem) => {
        this.setState({loading : true});

        let response = await updateUser(dataItem);

        if(response.result.resultType == 0) {
            dataItem = response.data;
            
            toast.success(`Cập nhật thành viên ${dataItem.username} thành công`, 2000);
        } else {
            dataItem.inEdit = true;
            dataItem.editField = 'inEdit';
            toast.error(response.result.message, 2000);
        }
        const data = this.state.data.map(item =>
            item.id === dataItem.id ? dataItem : item
        );
        this.setState({ data, loading: false });
    }

    addNewLine = (dataItem) => {
        if(this.state.isAddingNew){
            return;
        }
        else {
            dataItem.inEdit = true;
            dataItem.editField = 'inEdit';
            dataItem.id = 0;
            let data = this.state.data;
            data.unshift(dataItem);
            this.setState({
                isAddingNew: true,
                data: data
            });
        }
    }

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

    detail = (user) => {

    }

    discard = dataItem => {
        const data = [...this.state.data];
        data.splice(0, 1)
        this.setState({ data, isAddingNew: false });
    };

    cancel = dataItem => {
        const originalItem = this.state.data.find(
            p => p.id === dataItem.id
        );
        originalItem.inEdit = false;
        const data = this.state.data.map(item =>
            item.id === originalItem.id ? originalItem : item
        );
        this.setState({ data });
    }

    render () {
        return (
            <div className="container-fluid">
                <ToastContainer ref={ref => container = ref}
                    className="toast-top-right">
                </ToastContainer>
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
                                                    onClick={this.addNewLine}>
                                                <i className="fas fa-plus-circle"></i>
                                            </button>
                                        </GridToolbar>
                                        <Column field="id" title="ID" width="100" editor="text" editable={false} />
                                        <Column field="username" title="Tài khoản" width="150" editor="text" />
                                        <Column field="password" title="Mật khẩu" width="300" editor="text"/>
                                        <Column field="guidCode" title="Khóa" width="350" editor="text" editable={false}/>
                                        <Column field="employeeCode" title="Nhân viên" width="150"/>
                                        <Column field="isActive" title="Kích hoạt" width="100" editor="boolean"/>
                                        <Column field="note" title="Ghi chú"/>
                                        <Column cell={this.CommandCell} width="200px"/>
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
