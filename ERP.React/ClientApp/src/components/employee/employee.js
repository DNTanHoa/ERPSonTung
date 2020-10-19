import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { Grid, GridColumn as Column, GridToolbar } from '@progress/kendo-react-grid';
import config from '../../appsettings.json';
import { EmployeeCommandCell } from "./employee-command.jsx";
import { EmployeeService, insertItem, deleteItem, getItems, updateItem } from './employee-service';

export class Employee extends React.Component {

    editField = "inEdit";

    constructor(props) {
        super(props);
        this.state = {
            data: [],
            editID: null,
            skip: 0,
            take: 10
        }
    }

    CommandCell = props => (
        <EmployeeCommandCell
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

    dataRecieved = (employees) => {
        this.setState({
            data: employees
        })
    }
    
    render() {
        return(
            <div className="container-fluid">
                <section className="content-header">
                    <div className="container-fluid">
                        <div className="row mb-2">
                            <div className="col-sm-6">
                                <h1 className="float-sm-left">Danh sách nhân viên</h1>
                            </div>
                            <div className="col-sm-6">
                                <ol className="breadcrumb float-sm-right">
                                    <li className="breadcrumb-item"><a href="#">Quản lý nhân viên</a></li>
                                    <li className="breadcrumb-item active">Tổng quan nhân sự</li>
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
                                    <h3 className="card-title">Danh sách nhân viên</h3>
                                </div>
                                <div className="card-body">
                                <Grid style={{ height: "550px" }}
                                        data={this.state.data.slice(this.state.skip, this.state.take + this.state.skip)}
                                        onItemChange={this.itemChange}
                                        pageable={true}
                                        total={this.state.data.length}
                                        skip={this.state.skip}
                                        resizable={true}
                                        take={this.state.take}
                                        onPageChange={this.pageChange}
                                        editField={this.editField}>
                                        <GridToolbar>
                                            <button className="btn btn-success"
                                                    title="Thêm thành viên"
                                                    onClick={this.addNew}>
                                                <i className="fas fa-plus-circle"></i>
                                            </button>
                                        </GridToolbar>
                                        <Column field="code" title="Mã quản lý" width="200px" editable={false} />
                                        <Column field="fullName" title="Nhân viên" width="250px" />
                                        <Column field="startDate" title="Vào làm" width="150px" format="{0: yyyy-MM-dd HH:mm:ss}"/>
                                        <Column field="status" title="Trạng thái" width="150px" />
                                        <Column field="dateOfBirth" title="Ngày sinh" width="150px" format="{0: yyyy-MM-dd HH:mm:ss}"/>
                                        <Column field="age" title="Tuổi" width="80px"/>
                                        <Column field="note" title="Ghi chú"/>
                                        <Column cell={this.CommandCell} width="200px" />
                                </Grid>
                                <EmployeeService onDataRecieved={this.dataRecieved}></EmployeeService>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        )
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