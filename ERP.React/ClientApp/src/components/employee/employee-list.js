import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { Grid, GridColumn as Column, GridToolbar } from '@progress/kendo-react-grid';
import config from '../../appsettings.json';
import { EmployeeCommandCell } from "./employee-command.jsx";
import { getEmployeesHasFillter } from "../../apis/employee/employee-service"
import EmployeeImportModal from '../employee/employee-import-modal'
import { CustomDatePicker } from '../editortemplates/date-picker';
import EmployeeInfoModal from './employee-info-modal';
import { Modal } from 'react-bootstrap';

export class Employee extends React.Component {

    editField = "inEdit";

    constructor(props) {
        super(props);
        this.state = {
            employees: [],
            editID: null,
            skip: 0,
            take: 100,
            showInforModal:false,
            showImportModal:false,
        }
    }

    componentDidMount = async() => {
        let employees = await getEmployeesHasFillter();
        this.setState({employees})
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

    handleModalHide = () => {
        this.setState({showInforModal: false, showImportModal: false})
    }

    pageChange = (event) => {
        this.setState({
            skip: event.page.skip,
            take: event.page.take
        });
    }

    gridRowDoubleClick = () => {
        this.setState({showInforModal: true})
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
                                        data={this.state.employees.slice(this.state.skip, this.state.take + this.state.skip)}
                                        onItemChange={this.itemChange}
                                        pageable={{buttonCount: 5, info: true, pageSizes:true}}
                                        resizable={true}
                                        reorderable={true}
                                        onPageChange={this.pageChange}
                                        total={this.state.employees.length}
                                        skip={this.state.skip}
                                        resizable={true}
                                        onRowDoubleClick={this.gridRowDoubleClick}
                                        take={this.state.take}
                                        editField={this.editField}>
                                        <GridToolbar>
                                            <div className="d-flex" style={{overflowX: "auto"}}>
                                                <button className="btn btn-success"
                                                    onClick={() => {this.setState({showInforModal: true})}}
                                                    title="Thêm nhân viên">
                                                    <i className="fas fa-plus-circle"></i>
                                                </button>
                                                <button className="btn btn-success ml-1"
                                                    title="Tải lại">
                                                    <i className="fas fa-sync"></i>
                                                </button>
                                                <button className="btn btn-warning ml-1 text-white"
                                                    onClick={() => {this.setState({showImportModal: true})}}
                                                    title="Import Excel">
                                                    <i className="fas fa-file-import"></i>
                                                </button>
                                            </div>
                                        </GridToolbar>
                                        <Column field="code" title="Mã quản lý" width="120px" editable={false} />
                                        <Column field="fullName" title="Nhân viên" width="250px" />
                                        <Column field="startDate" title="Vào làm" width="150px" format="dd-MM-yyyy" cell={CustomDatePicker}/>
                                        <Column field="department" title="Bộ phận" width="250px" />
                                        <Column field="group" title="Tổ làm" width="250px" />
                                        <Column field="job" title="Công việc" width="250px" />
                                        <Column field="position" title="Chức vụ" width="250px" />
                                        <Column field="laborGroup" title="Nhóm lao động" width="250px" />
                                        <Column field="status" title="Trạng thái" width="150px" />
                                        <Column field="dateOfBirth" title="Ngày sinh" width="150px" format="dd-MM-yyyy" cell={CustomDatePicker}/>
                                        <Column field="age" title="Tuổi" width="80px"/>
                                        <Column field="note" title="Ghi chú"/>
                                        <Column cell={this.CommandCell} width="200px" />
                                </Grid>
                                <Modal centered={false} 
                                    size="xl"
                                    onHide={this.handleModalHide}
                                    enforceFocus={false}
                                    show={this.state.showInforModal}>
                                    <EmployeeInfoModal onHide={this.handleModalHide}></EmployeeInfoModal>
                                </Modal>
                                <Modal centered={false} 
                                    size="xl"
                                    onHide={this.handleModalHide}
                                    enforceFocus={false}
                                    show={this.state.showImportModal}>
                                    <EmployeeImportModal onHide={this.handleModalHide}></EmployeeImportModal>
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