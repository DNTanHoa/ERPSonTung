import React, {Component} from 'react'
import {Modal, Button} from 'react-bootstrap'
import { DatePicker } from '@progress/kendo-react-dateinputs';
import './recruitmentplan.css'

export default class RecruitmentPlanModal extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            showModal: this.props.isShown
        }
    }

    render = () => {
        return (
            <>
                <Modal.Header>
                    <h5 className="modal-title">Kế hoạch tuyển dụng</h5>
                </Modal.Header>
                <Modal.Body>
                    <div className="row mb-1">
                        <div className="col-md-2 col-lg-1">
                            <label className="text-nowrap m-0 mr-2 mt-md-1">Tiêu đề</label>
                        </div>
                        <div className="col-md-10 col-lg-11">
                            <input type="text" className="form-control" placeholder="Kế hoạch tuyển dụng"/>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-2 col-lg-1">
                            <label className="text-nowrap m-0 mr-2 mt-md-1">Vị trí</label>
                        </div>
                        <div className="col-md-4 col-lg-5">
                            <input type="text" className="form-control" placeholder="Vị trí công việc"/>
                        </div>
                        <div className="col-md-2 col-lg-1">
                            <label className="text-nowrap m-0 mr-2 mt-md-1">Bộ phận</label>
                        </div>
                        <div className="col-md-4 col-lg-5">
                            <input type="text" className="form-control" placeholder="Bộ phận"/>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-2 col-lg-1">
                            <label className="text-nowrap m-0 mr-2 mt-md-1">Từ ngày</label>
                        </div>
                        <div className="col-md-4 col-lg-5">
                            <DatePicker format="dd-MM-yyyy"
                                className="w-100"
                                defaultValue={new Date()}/>
                        </div>
                        <div className="col-md-2 col-lg-1">
                            <label className="text-nowrap m-0 mr-2 mt-md-1">Đến ngày</label>
                        </div>
                        <div className="col-md-4 col-lg-5">
                            <DatePicker format="dd-MM-yyyy"
                                className="w-100"
                                defaultValue={new Date()}/>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-2 col-lg-1">
                            <label className="text-nowrap m-0 mr-2 mt-md-1">Số lượng</label>
                        </div>
                        <div className="col-md-4 col-lg-5">
                            <input type="text" className="form-control" placeholder="Số lượng"/>
                        </div>
                        <div className="col-md-2 col-lg-1">
                            <label className="text-nowrap m-0 mr-2 mt-md-1">Trạng thái</label>
                        </div>
                        <div className="col-md-4 col-lg-5">
                            <input type="text" className="form-control" placeholder="Trạng thái"/> 
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-2 col-lg-1">
                            <label className="text-nowrap m-0 mr-2 mt-md-1">Yêu cầu</label>
                        </div>
                        <div className="col-md-10 col-lg-11">
                            <textarea className="form-control" rows="5" id="comment"></textarea>
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