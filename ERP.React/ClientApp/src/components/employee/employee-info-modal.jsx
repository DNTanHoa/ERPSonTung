import React from 'react';
import { Modal } from 'react-bootstrap';
import { DatePicker } from '@progress/kendo-react-dateinputs';
import { DropDownList } from '@progress/kendo-react-dropdowns';
import { getCategoriesByEntity } from "../../apis/category/category-service";
import { getModelTemplates } from "../../apis/employee/employee-service";
import config from '../../appsettings.json'

export default class EmployeeInfoModal extends React.Component {
    constructor(props){
        super(props)

        this.state = {
            departments:[],
            defaultDepartment: {},
            employeeStatuses: [],
            department: {},
            employeeStatus: {},
            groups:[],
            group: {},
            laborGroups: [],
            jobs:[],
            job: {},
            positions: [],
            position: {},
            laborGroups: [],
            laborGroup: {},
            supervisors:[],
            supervisor:{}
        }

        this.handleSelectChange = this.handleSelectChange.bind(this)
    }

    componentDidMount = async () => {
        let departments = await (await getCategoriesByEntity(config.entities.department))
        .map((department) => {return {...department, textname: department.code +' - '+ department.name}});

        let employeeStatuses = await (await getCategoriesByEntity(config.entities.employeeStatus))
        .map((employeeStatus) => {return {...employeeStatus, textname: employeeStatus.code +' - '+ employeeStatus.name}});

        let jobs = await (await getCategoriesByEntity(config.entities.job))
        .map((job) =>  {return {...job, textname: job.code +' - '+ job.name}})

        let groups = await (await getCategoriesByEntity(config.entities.group))
        .map((group) =>  {return {...group, textname: group.code +' - '+ group.name}})

        let positions = await (await getCategoriesByEntity(config.entities.position))
        .map((position) =>  {return {...position, textname: position.code +' - '+ position.name}})

        let laborGroups = await (await getCategoriesByEntity(config.entities.laborGroup))
        .map((laborGroup) =>  {return {...laborGroup, textname: laborGroup.code +' - '+ laborGroup.name}})

        let supervisors = await getModelTemplates()

        this.setState({departments, employeeStatuses, jobs, groups, positions, laborGroups, supervisors});
    }

    handleSelectChange = (event) => {
        this.setState({
            [event.target.name]: event.value
        });
    }

    render = () => {
        return (
            <>
                <Modal.Header>
                    <h5 className="modal-title">Thông tin nhân viên</h5>
                </Modal.Header>
                <Modal.Body>
                    <div className="row mb-1">
                        <div className="col-md-4">
                            <div className="form-group m-0">
                                <label className="m-0">Mã quản lý</label>
                                <input className="form-control" placeholder="Mã quản lý"></input>
                            </div>
                        </div>
                        <div className="col-md-4">
                            <div className="form-group m-0">
                                <label className="m-0">Họ và đệm</label>
                                <input className="form-control" placeholder="Họ và tên đệm"></input>
                            </div>
                        </div>
                        <div className="col-md-4">
                            <div className="form-group m-0">
                                <label className="m-0">Tên</label>
                                <input className="form-control" placeholder="Tên"></input>
                            </div>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-4">
                            <div className="form-group m-0">
                                <label className="m-0">Mã chấm công</label>
                                <input className="form-control" placeholder="Mã chấm công"></input>
                            </div>
                        </div>
                        <div className="col-md-4">
                            <div className="form-group m-0">
                                <label className="m-0">Ngày vào</label>
                                <DatePicker format="dd-MM-yyyy"
                                    className="w-100"
                                    defaultValue={new Date()}/>
                            </div>
                        </div>
                        <div className="col-md-4">
                            <div className="form-group m-0">
                                <label className="m-0">Trạng thái</label>
                                <DropDownList data={this.state.employeeStatuses} 
                                    textField="textname"
                                    dataItemKey="code"
                                    name="employeeStatus"
                                    delay={1000}
                                    filterable={true}
                                    value={this.state.employeeStatus}
                                    onChange={this.handleSelectChange}
                                    style={{width: '100%'}}/>
                            </div>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-4">
                            <div className="form-group m-0">
                                <label className="m-0">Bộ phận</label>
                                <DropDownList data={this.state.departments} 
                                    textField="textname"
                                    dataItemKey="code"
                                    name="department"
                                    delay={1000}
                                    filterable={true}
                                    value={this.state.department}
                                    onChange={this.handleSelectChange}
                                    style={{width: '100%'}}/>
                            </div>
                        </div>
                        <div className="col-md-4">
                            <div className="form-group m-0">
                                <label className="m-0">Tổ nhóm</label>
                                <DropDownList data={this.state.groups} 
                                    textField="textname"
                                    dataItemKey="code"
                                    name="group"
                                    delay={1000}
                                    filterable={true}
                                    value={this.state.group}
                                    onChange={this.handleSelectChange}
                                    style={{width: '100%'}}/>
                            </div>
                        </div>
                        <div className="col-md-4">
                            <div className="form-group m-0">
                                <label className="m-0">Công việc</label>
                                <DropDownList data={this.state.jobs} 
                                    textField="textname"
                                    dataItemKey="code"
                                    name="job"
                                    delay={1000}
                                    filterable={true}
                                    value={this.state.job}
                                    onChange={this.handleSelectChange}
                                    style={{width: '100%'}}/>
                            </div>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-4">
                            <div className="form-group m-0">
                                <label className="m-0">Chức vụ</label>
                                <DropDownList data={this.state.positions} 
                                    textField="textname"
                                    dataItemKey="code"
                                    name="position"
                                    delay={1000}
                                    filterable={true}
                                    value={this.state.position}
                                    onChange={this.handleSelectChange}
                                    style={{width: '100%'}}/>
                            </div>
                        </div>
                        <div className="col-md-4">
                            <div className="form-group m-0">
                                <label className="m-0">Nhóm lao động</label>
                                <DropDownList data={this.state.laborGroups} 
                                    textField="textname"
                                    dataItemKey="code"
                                    name="laborGroup"
                                    delay={1000}
                                    filterable={true}
                                    value={this.state.laborGroup}
                                    onChange={this.handleSelectChange}
                                    style={{width: '100%'}}/>
                            </div>
                        </div>
                        <div className="col-md-4">
                            <div className="form-group m-0">
                                <label className="m-0">Người quản lý</label>
                                <DropDownList data={this.state.supervisors} 
                                    textField="display"
                                    dataItemKey="code"
                                    name="supervisor"
                                    delay={1000}
                                    filterable={true}
                                    value={this.state.supervisor}
                                    onChange={this.handleSelectChange}
                                    style={{width: '100%'}}/>
                            </div>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-sm-12">
                            <div className="form-group m-0">
                                <label className="m-0">Ghi chú</label>
                                <input className="form-control" placeholder="Ghi chú"></input>
                            </div>
                        </div>
                    </div>
                </Modal.Body>
                <Modal.Footer>
                    <div className="row w-100">
                        <div className="col-5 col-md-6 p-0">
                            <button className="btn btn-success float-sm-left">
                                <i className="far fa-question-circle"></i> Trợ giúp
                            </button>
                        </div>
                        <div className="col-7 col-md-6 p-0">
                            <div className="float-right d-flex">
                                <button className="btn btn-primary">
                                    <i className="far fa-save"></i> Lưu
                                </button>
                                <button className="btn btn-danger ml-1" onClick={this.props.onHide}>
                                    <i className="far fa-times-circle"></i> Thoát
                                </button>
                            </div>
                        </div>
                    </div>
                </Modal.Footer>
            </>
        )
    }
}