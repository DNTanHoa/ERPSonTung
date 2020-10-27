import React from 'react';
import { Modal, ModalBody } from 'react-bootstrap';
import { DatePicker } from '@progress/kendo-react-dateinputs';
import { AutoComplete, ComboBox, DropDownList, MultiSelect } from '@progress/kendo-react-dropdowns';
import { getCategoriesByEntity } from "../../apis/category/category-service";
import { getModelTemplates } from "../../apis/employee/employee-service";
import config from '../../appsettings.json'
import { IntlProvider, LocalizationProvider, loadMessages } from '@progress/kendo-react-intl';
import { Upload } from '@progress/kendo-react-upload';
import uploadMessages from '../../constants/upload.json';

loadMessages(uploadMessages, 'vi-VN');

export default class EmployeeImportModal extends React.Component {
    constructor(props){
        super(props)

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
                    <h5 className="modal-title">Import thông tin nhân viên</h5>
                </Modal.Header>
                <Modal.Body>
                    <div className="row mb-1">
                        <div className="col-md-6">
                           <h6 className="">Bước 1: Tải file mẫu để nhập: <a className="text-primary" href="">Tải về</a></h6> 
                        </div>
                        <div className="col-md-6">
                            <h6 className="">Bước 2: Chọn file import:</h6>
                            <LocalizationProvider language="vi-VN">
                                <IntlProvider locale="vi">
                                    <Upload batch={false}
                                        multiple={true}
                                        ariaLabelledBy="Chọn"
                                        autoUpload={false}
                                        saveUrl={'https://demos.telerik.com/kendo-ui/service-v4/upload/save'}
                                        removeUrl={'https://demos.telerik.com/kendo-ui/service-v4/upload/remove'}
                                    />
                                </IntlProvider>
                            </LocalizationProvider>
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