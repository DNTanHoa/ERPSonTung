import React from 'react';
import { Modal } from 'react-bootstrap';
import { AutoComplete, ComboBox, DropDownList, MultiSelect } from '@progress/kendo-react-dropdowns';
import { insertNavigation, updateNavigation } from "../../apis/navigation/navigation-service";
import { getCategoriesByEntity } from "../../apis/category/category-service";
import { getNavigations } from '../../apis/navigation/navigation-service';
import config from '../../appsettings.json';
import { ToastContainer, toast } from 'react-toastify';    
import { filterBy } from '@progress/kendo-data-query';
import { extend } from 'hammerjs';

let container;

export default class CategoryModal extends React.Component {
    constructor(props) {
        super(props)

        this.state = {

        }
    }

    handleSaveChange = (e) => {

    }

    handleSaveChange = (e) => {

    }

    render = () => {
        return <React.Fragment>
            <ToastContainer ref={ref => container = ref}
                className="toast-top-right">
            </ToastContainer>
            <Modal.Header closeButton>
                <h5 className="modal-title">Chi tiết danh mục</h5>
            </Modal.Header>
            <Modal.Body>
                <div className="row mb-1">
                    <div className="col-md-12">
                        <div className="form-group m-0">
                            <label className="m-0">Mã quản lý</label>
                            <input name="code" 
                                className="form-control" readOnly 
                                placeholder="Mã quản lý"
                                value={this.state.code}
                                onChange={this.handleChange}></input>
                        </div>
                    </div>
                </div>
                <div className="row mb-1">
                    <div className="col-md-12">
                        <div className="form-group m-0">
                            <label className="m-0">Mã phụ</label>
                            <input name="code" 
                                className="form-control" readOnly 
                                placeholder="Mã quản lý"
                                value={this.state.code}
                                onChange={this.handleChange}></input>
                        </div>
                    </div>
                </div>
                <div className="row mb-1">
                    <div className="col-md-12">
                        <div className="form-group m-0">
                            <label className="m-0">Nhóm</label>
                            <input name="code" 
                                className="form-control" readOnly 
                                placeholder="Mã quản lý"
                                value={this.state.code}
                                onChange={this.handleChange}></input>
                        </div>
                    </div>
                </div>
                <div className="row mb-1">
                    <div className="col-md-12">
                        <div className="form-group m-0">
                            <label className="m-0">Tên</label>
                            <input name="code" 
                                className="form-control" readOnly 
                                placeholder="Mã quản lý"
                                value={this.state.code}
                                onChange={this.handleChange}></input>
                        </div>
                    </div>
                </div>
                <div className="row mb-1">
                    <div className="col-md-12">
                        <div className="form-group m-0">
                            <label className="m-0">Ghi chú</label>
                            <input name="code" 
                                className="form-control" readOnly 
                                placeholder="Mã quản lý"
                                value={this.state.code}
                                onChange={this.handleChange}></input>
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
                                <button className="btn btn-primary" onClick={this.handleSaveChange}>
                                    <i className="far fa-save"></i> Lưu
                                </button>
                                <button className="btn btn-danger ml-1" onClick={this.props.onHide}>
                                    <i className="far fa-times-circle"></i> Thoát
                                </button>
                            </div>
                        </div>
                    </div>
                </Modal.Footer>
        </React.Fragment>
    }
}