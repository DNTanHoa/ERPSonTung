import React from 'react';
import { Modal } from 'react-bootstrap';
import { DatePicker } from '@progress/kendo-react-dateinputs';
import { AutoComplete, ComboBox, DropDownList, MultiSelect } from '@progress/kendo-react-dropdowns';
import { getCategoriesByEntity } from "../../apis/category/category-service";
import { getModelTemplates } from "../../apis/employee/employee-service";
import config from '../../appsettings.json'

export default class NavigationModal extends React.Component {
    constructor(props) {
        super(props)
    }

    render = () => {
        return(
            <>
                <Modal.Header>
                    <h5 className="modal-title">Chi tiết điều hướng</h5>
                </Modal.Header>
                <Modal.Body>
                    <div className="row mb-1">
                        <div className="col-md-12">
                            <div className="form-group m-0">
                                <label className="m-0">Loại điều hướng</label>
                                <input className="form-control" placeholder="Phân loại"></input>
                            </div>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-12">
                            <div className="form-group m-0">
                                <label className="m-0">Mã quản lý</label>
                                <input className="form-control" placeholder="Mã quản lý"></input>
                            </div>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-12">
                            <div className="form-group m-0">
                                <label className="m-0">Tên hiển thị</label>
                                <input className="form-control" placeholder="Tên hiển thị"></input>
                            </div>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-12">
                            <div className="form-group m-0">
                                <label className="m-0">Component</label>
                                <input className="form-control" placeholder="Đường dẫn"></input>
                            </div>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-12">
                            <div className="form-group m-0">
                                <label className="m-0">Icon</label>
                                <input className="form-control" placeholder="Icon"></input>
                            </div>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-12">
                            <div className="form-group m-0">
                                <label className="m-0">Note</label>
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