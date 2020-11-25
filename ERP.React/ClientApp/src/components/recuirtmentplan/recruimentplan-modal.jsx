import React, {Component} from 'react'
import {Modal, Button} from 'react-bootstrap'
import { DatePicker } from '@progress/kendo-react-dateinputs';
import { getCategoriesByEntity } from "../../apis/category/category-service";
import config from '../../appsettings.json';
import { DropDownList } from '@progress/kendo-react-dropdowns';
import { ToastContainer, toast } from 'react-toastify';
import {insertRecruitmentPlan, updateRecruitmentPlan, getRecruitmentPlanById} from '../../apis/recruitmentplan/recruitmentplan-service'
import './recruitmentplan.css';

let container;

export default class RecruitmentPlanModal extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            showModal: this.props.isShown,
            departments:[],
            statuses:[],
            jobs:[],
            loading: false,
            skip: 0,
            take: 100,
            title: '',
            code:'',
            quantity: 0,
            departmentCode:'',
            jobCode: '',
            startDate: null,
            endDate: null,
            id: 0,
            status: {},
            description: '',
            department: {},
            job:{},
            status: {},
        }
        
        this.handleInputChange = this.handleInputChange.bind(this);
    }

    componentDidMount = async () => {
        let departments = await (await getCategoriesByEntity(config.entities.department))
        .map((department) => {return {...department, textname: department.code +' - '+ department.name}});

        let jobs = await (await getCategoriesByEntity(config.entities.job))
        .map((job) =>  {return {...job, textname: job.code +' - '+ job.name}})

        let statuses = await (await getCategoriesByEntity(config.entities.recruitmentPlanStatus))
        .map((status) =>  {return {...status, textname: status.code +' - '+ status.name}})

        this.setState({departments, jobs, statuses});

        if(this.props.dataItem.id > 0) {
            let respone = await getRecruitmentPlanById(this.props.dataItem.id);
            if(respone.result.resultType === 0) {
                let data = respone.data;
                let job = this.state.jobs.find(item => item.code === data.jobCode);
                let department =  this.state.departments.find(item => item.code === data.departmentCode);
                let status = this.state.statuses.find(item => item.code === data.status);
                this.setState({
                    title: data.title, 
                    startDate: new Date(data.startDate), 
                    endDate: new Date(data.endDate),
                    code: data.code,
                    job,
                    department,
                    description: data.description,
                    status,
                    id: data.id
                });
            }
        } else {
            this.setState({startDate: new Date(), endDate: new Date()});
        }
        console.log(this.state);
    }

    handleSaveChange = async () => {
        const dataItem = {
            title: this.state.title,
            code: this.state.code,
            quantity: this.state.quantity,
            departmentCode: this.state.department.code,
            startDate: this.state.startDate,
            endDate: this.state.endDate,
            id: this.state.id,
            status: this.state.status.code,
            description: this.state.description,
            jobCode: this.state.job.code
        }

        let respone = {}

        if(this.state.id > 0) {
            respone = await updateRecruitmentPlan(dataItem);
        } else {
            respone = await insertRecruitmentPlan(dataItem);
        }

        if(respone.result.resultType === 0) {
            toast.success(`Cập nhật kế hoạch thành công`, 2000);
        } else {
            toast.error(`Cập nhật kế hoạch thất bại. Lỗi: ${respone.result.message}`, 2000);
        }
    }

    handleSelectChange = (e) => {
        console.log(e)
        this.setState({
            [e.target.name]: e.value
        });
    }

    handleInputChange = (e) => {
        e.persist();
        this.setState({
            [e.target.name]: e.target.value
        })
    }

    render = () => {
        return (
            <React.Fragment>
                <ToastContainer ref={ref => container = ref}
                    className="toast-top-right">
                </ToastContainer>
                <Modal.Header closeButton>
                    <h5 className="modal-title">Kế hoạch tuyển dụng</h5>
                </Modal.Header>
                <Modal.Body>
                    <form id="dataForm">
                        <div className="row mb-1">
                            <div className="col-md-2 col-lg-1">
                                <label className="text-nowrap m-0 mr-2 mt-md-1">Tiêu đề</label>
                            </div>
                            <div className="col-md-10 col-lg-11">
                                <input type="text"
                                    name="title"
                                    value={this.state.title}
                                    className="form-control"
                                    onChange={this.handleInputChange}
                                    placeholder="Kế hoạch tuyển dụng"/>
                            </div>
                        </div>
                        <div className="row mb-1">
                            <div className="col-md-2 col-lg-1">
                                <label className="text-nowrap m-0 mr-2 mt-md-1">Công việc</label>
                            </div>
                            <div className="col-md-4 col-lg-5">
                                <DropDownList data={this.state.jobs} 
                                    textField="textname"
                                    dataItemKey="code"
                                    name="job"
                                    filterable={true}
                                    value={this.state.job}
                                    onChange={this.handleSelectChange}
                                    style={{width: '100%'}}/>
                            </div>
                        <div className="col-md-2 col-lg-1">
                            <label className="text-nowrap m-0 mr-2 mt-md-1">Bộ phận</label>
                        </div>
                            <div className="col-md-4 col-lg-5">
                            <DropDownList data={this.state.departments} 
                                    textField="textname"
                                    dataItemKey="code"
                                    name="department"
                                    filterable={true}
                                    value={this.state.department}
                                    onChange={this.handleSelectChange}
                                    style={{width: '100%'}}/>
                            </div>
                        </div>
                        <div className="row mb-1">
                            <div className="col-md-2 col-lg-1">
                                <label className="text-nowrap m-0 mr-2 mt-md-1">Từ ngày</label>
                            </div>
                            <div className="col-md-4 col-lg-5">
                                <DatePicker format="dd-MM-yyyy"
                                    className="w-100"
                                    name="startDate"
                                    onChange={this.handleInputChange}
                                    defaultValue={new Date()}/>
                            </div>
                            <div className="col-md-2 col-lg-1">
                                <label className="text-nowrap m-0 mr-2 mt-md-1">Đến ngày</label>
                            </div>
                            <div className="col-md-4 col-lg-5">
                                <DatePicker format="dd-MM-yyyy"
                                    className="w-100"
                                    name="endDate"
                                    onChange={this.handleInputChange}
                                    defaultValue={new Date()}/>
                            </div>
                        </div>
                        <div className="row mb-1">
                            <div className="col-md-2 col-lg-1">
                                <label className="text-nowrap m-0 mr-2 mt-md-1">Số lượng</label>
                            </div>
                            <div className="col-md-4 col-lg-5">
                                <input type="number"
                                    onChange={this.handleInputChange}
                                    name="quantity"
                                    className="form-control" 
                                    placeholder="Số lượng"/>
                            </div>
                            <div className="col-md-2 col-lg-1">
                                <label className="text-nowrap m-0 mr-2 mt-md-1">Trạng thái</label>
                            </div>
                            <div className="col-md-4 col-lg-5">
                                <DropDownList data={this.state.statuses} 
                                    textField="textname"
                                    dataItemKey="code"
                                    name="status"
                                    delay={1000}
                                    value={this.state.status}
                                    filterable={true}
                                    onChange={this.handleSelectChange}
                                    style={{width: '100%'}}/>
                            </div>
                        </div>
                        <div className="row mb-1">
                            <div className="col-md-2 col-lg-1">
                                <label className="text-nowrap m-0 mr-2 mt-md-1">Yêu cầu</label>
                            </div>
                            <div className="col-md-10 col-lg-11">
                                <textarea className="form-control" rows="5"  name="description" onChange={this.handleInputChange}></textarea>
                            </div>
                        </div>
                    </form>
                </Modal.Body>
                <Modal.Footer>
                    <div className="row w-100">
                        <div className="col-5 col-md-6 p-0">
                            <button className="btn btn-success float-sm-left" title="Tài liệu hướng dẫn">
                                <i className="far fa-question-circle"></i> Trợ giúp
                            </button>
                        </div>
                        <div className="col-7 col-md-6 p-0">
                            <div className="float-right d-flex">
                                <button className="btn btn-primary" title="Lưu thay đổi" onClick={this.handleSaveChange}>
                                    <i className="far fa-save"></i> Lưu
                                </button>
                                <button className="btn btn-danger ml-1" onClick={this.props.onHide} title="Thoát">
                                    <i className="far fa-times-circle"></i> Thoát
                                </button>
                            </div>
                        </div>
                    </div>
                </Modal.Footer>
            </React.Fragment>
        )
    }
}