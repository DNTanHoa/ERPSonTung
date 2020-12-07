import * as React from 'react';
import { Grid, GridColumn as Column, GridToolbar } from '@progress/kendo-react-grid';
import config from '../../appsettings.json';
import { EmployeeCommandCell } from "./employee-command.jsx";
import EmployeeService from "../../apis/employee/employee-service";
import EmployeeImportModal from './employee-import-modal'
import EmployeeInfoModal from './employee-info-modal';
import { Redirect } from "react-router-dom";
import { Loading } from '../loading';
import { DropDownList } from '@progress/kendo-react-dropdowns';
import { Modal } from 'react-bootstrap';
import { getCategoriesByEntity } from "../../apis/category/category-service";

export class Employee extends React.Component {

    editField = "inEdit";

    constructor(props) {
        super(props);
        this.state = {
            employees: [],
            departments:[],
            groups: [],
            editID: null,
            skip: 0,
            take: 100,
            loading: false,
            showInforModal:false,
            showImportModal:false,
            group: {},
            department: {},
            redirectToDetail: false,
            paramId:Number
        }

    }

    componentDidMount = async() => {

        this.setState({loading:true});
        
        let employees = await (await EmployeeService.getEmployeesHasFillter()).map((item) => {
            return {...item, startDate: new Date(item.startDate), dateOfBirth: new Date(item.dateOfBirth)}
        });

        let groups = await (await getCategoriesByEntity(config.entities.group))
        .map((group) =>  {return {...group, textname: group.code +' - '+ group.name}})
        
        let departments = await (await getCategoriesByEntity(config.entities.department))
        .map((department) => {return {...department, textname: department.code +' - '+ department.name}});

        
        this.setState({employees, departments, groups, loading: false});
    }

    CommandCell = props => (
        <EmployeeCommandCell
            {...props}
            openDetail={this.openDetail}
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

    handleRefresh = async () => {
        this.setState({loading:true});
        let employees = await (await EmployeeService.getEmployeesHasFillter()).map((item) => {
            return {...item, startDate: new Date(item.startDate), dateOfBirth: new Date(item.dateOfBirth)}
        });
        this.setState({employees, loading: false})
    }

    handleSelectChange = (e) => {
        this.setState({
            [e.target.name]: e.value
        });
    }

    handleFilterChange = (e) => {

    }

    openDetail = (dataItem) => {
        this.setState({paramId:dataItem.id});
        this.setState({redirectToDetail:true});
    }

    
    render() {
        if(this.state.redirectToDetail) {
            return(
                <Redirect push to={{
                    pathname:'/hrm/employee/detail',
                    state: { id: this.state.paramId }
            }}/>)
        }
        return(
            <div className="container-fluid px-1 h-100">
                <section className="content-header py-1">
                    <div className="container-fluid">
                        <div className="row mb-2">
                            <div className="col-sm-6">
                                <h1 className="float-sm-left">Danh sách nhân viên</h1>
                            </div>
                            <div className="col-sm-6">
                                <ol className="breadcrumb float-sm-right">
                                    <li className="breadcrumb-item"><a href="#">Quản lý nhân viên</a></li>
                                    <li className="breadcrumb-item active">Danh sách</li>
                                </ol>
                            </div>
                        </div>
                    </div>
                </section>
                <section className="content h-100">
                    <div className="container-fluid">
                        <div className="row h-100">
                            <div className="card h-100" style={{overflowX:"auto", minHeight:'800px'}}>
                                <div className="card-header p-1">
                                    <div className="row w-100 m-0">
                                        <div className="col-md-4 col-lg-3 p-1">
                                            <DropDownList data={this.state.departments}
                                                textField="textname"
                                                dataItemKey="code"
                                                name="department"
                                                delay={1000}
                                                filterable={true}
                                                onFilterChange={this.handleFilterChange}
                                                value={this.state.department}
                                                onChange={this.handleSelectChange}
                                                style={{width: '100%'}}/>
                                        </div>
                                        <div className="col-md-4 col-lg-3 mt-1 mt-md-0 p-1">
                                            <DropDownList data={this.state.groups} 
                                                textField="textname"
                                                dataItemKey="code"
                                                name="group"
                                                delay={1000}
                                                filterable={true}
                                                value={this.state.group}
                                                onFilterChange={this.handleFilterChange}
                                                onChange={this.handleSelectChange}
                                                style={{width: '100%'}}/>
                                        </div>
                                        <div className="col-md-3 col-lg-3 mt-1 mt-md-0 p-1">
                                            <input className="form-control" placeholder="Tìm...."></input>
                                        </div>
                                        <div className="col-md-1 col-12 mt-1 mt-md-0 p-1">
                                            <button className="btn btn-success w-100" title="Tìm kết quả">
                                                <i className="fas fa-search"></i>
                                            </button>
                                        </div>
                                    </div>
                                </div>
                                <div className="card-body p-1">
                                <Grid data={this.state.employees.slice(this.state.skip, this.state.take + this.state.skip)}
                                        onItemChange={this.itemChange}
                                        pageable={{buttonCount: 5, info: true, pageSizes:true}}
                                        resizable={true}
                                        style={{ height: '100%' }}
                                        selectedField="selected"
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
                                                    onClick={this.handleRefresh}
                                                    title="Tải lại">
                                                    <i className="fas fa-sync"></i>
                                                </button>
                                                <button className="btn btn-warning ml-1 text-white"
                                                    onClick={() => {this.setState({showImportModal: true})}}
                                                    title="Import Excel">
                                                    <i className="fas fa-file-import"></i>
                                                </button>
                                                <button className="btn btn-success ml-1 text-white"
                                                    onClick={() => {this.setState({showImportModal: true})}}
                                                    title="Xuất excel dữ liệu nhân sự">
                                                    <i className="fas fa-file-excel"></i>
                                                </button>
                                            </div>
                                        </GridToolbar>
                                        <Column cell={this.CommandCell} width="120px"/>
                                        <Column field="code" title="Mã quản lý" width="120px" editable={false}/>
                                        <Column field="fullName" title="Nhân viên" width="250px"/>
                                        <Column field="startDate" title="Vào làm" width="150px" format="{0:dd-MM-yyyy}"/>
                                        <Column field="department" title="Bộ phận" width="250px"/>
                                        <Column field="group" title="Tổ làm" width="250px"/>
                                        <Column field="job" title="Công việc" width="250px"/>
                                        <Column field="position" title="Chức vụ" width="250px"/>
                                        <Column field="status" title="Trạng thái" width="150px"/>
                                        <Column field="dateOfBirth" title="Ngày sinh" width="150px" format="{0:dd-MM-yyyy}"/>
                                        <Column field="phone" title="Thường trú" width="250px"/>
                                        <Column field="originAddress" title="Thường trú" width="250px"/>
                                        <Column field="temporaryAddress" title="Tạm trú" width="250px"/>
                                        <Column field="companyEmail" title="Email công ty" width="250px"/>
                                        <Column field="personalEmail" title="Email riêng" width="250px"/>
                                        <Column field="identityNumber" title="Chứng minh" width="250px"/>
                                        <Column field="identityLicenseDate" title="Ngày cấp" width="150px" format="{0:dd-MM-yyyy}"/>
                                        <Column field="identityLicensePlace" title="Nơi cấp" width="250px"/>
                                        <Column field="age" title="Tuổi" width="80px"/>
                                        <Column field="note" title="Ghi chú"/>
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