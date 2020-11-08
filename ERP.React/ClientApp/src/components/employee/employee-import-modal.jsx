import React from 'react';
import { Modal, ModalBody } from 'react-bootstrap';
import { DatePicker } from '@progress/kendo-react-dateinputs';
import { AutoComplete, ComboBox, DropDownList, MultiSelect } from '@progress/kendo-react-dropdowns';
import { getCategoriesByEntity } from "../../apis/category/category-service";
import { getModelTemplates } from "../../apis/employee/employee-service";
import config from '../../appsettings.json'
import { IntlProvider, LocalizationProvider, loadMessages } from '@progress/kendo-react-intl';
import { Upload } from '@progress/kendo-react-upload';
import './employee-detail.css';
import uploadMessages from '../../constants/upload.json';
import { employeeCheckFileImport } from '../../apis/file/file-service';
import { Grid, GridColumn as Column } from '@progress/kendo-react-grid';

loadMessages(uploadMessages, 'vi-VN');

export default class EmployeeImportModal extends React.Component {
    constructor(props){
        super(props);

        this.state = {
            selectedFile: {},
            importEmployees: [],
            skip: 0,
            take: 50,
        }
    }

    handleSelectChange = (event) => {
        this.setState({
            [event.target.name]: event.value
        });
    }

    handleFileSelect = (event) => {
        this.setState({
            selectedFile: event.target.files[0],
        });
    }

    handleUpload =  async () => {
        let importEmployees = await (await employeeCheckFileImport(this.state.selectedFile)).map((employee,index) => {
            return {...employee, 
                startDate: new Date(employee.startDate), 
                dateOfBirth: new Date(employee.dateOfBirth), 
                stt: index,
                identityLicenseDate: new Date(employee.identityLicenseDate)
            }
        });
        this.setState({
            importEmployees
        });
        console.log(this.state);
    }

    pageChange = (event) => {
        this.setState({
            skip: event.page.skip,
            take: event.page.take
        });
    }

    rowRender = (row, props) => {
        const error = { backgroundColor: "#dc3545", color: "white", border: "solid 1px white" };
        const isError = props.dataItem.isError;
        const rowProps = {style: isError ? error : null}
        return React.cloneElement(row, {...rowProps}, row.props.children);
    }


    render = () => {
        return (
            <>
                <Modal.Header closeButton>
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
                                    {/* <Upload batch={false}
                                        multiple={false}
                                        defaultFiles={[]}
                                        onAdd={this.handleFileSelect}
                                        restrictions={{
                                            allowedExtensions: [ '.xlsx', '.xls' ]
                                        }}
                                        withCredentials={false}
                                        autoUpload={false}/> */}
                                        <input type="file" 
                                          className="form-control-file"
                                          placeholder="Chọn file"
                                          onChange={this.handleFileSelect}></input>
                                        <span className="">
                                            <button className="btn btn-primary mt-2"
                                               onClick={this.handleUpload}>Upload</button>
                                        </span>
                                </IntlProvider>
                            </LocalizationProvider>
                        </div>
                    </div>
                    <div className="row mb-1" style={{overflowX:"auto"}}>
                        <Grid style={{overflowX:"auto"}}
                            pageable={{buttonCount: 5, info: true, pageSizes:true}}
                            resizable={true}
                            pageSize={this.state.take}
                            onPageChange={this.pageChange}
                            reorderable={true}
                            skip={this.state.skip}
                            take={this.state.take}
                            rowRender={this.rowRender}
                            total={this.state.importEmployees.length}
                            data={this.state.importEmployees.slice(this.state.skip, this.state.take + this.state.skip)}>
                            <Column field="stt" title="STT" width="60px" editable={false} />
                            <Column field="code" title="Mã quản lý" width="120px" editable={false} />
                            <Column field="fullName" title="Nhân viên" width="250px" />
                            <Column field="startDate" title="Vào làm" width="150px" format="{0:dd-MM-yyyy}" />
                            <Column field="originAddress" title="Thường trú" width="350px" />
                            <Column field="temporaryAddress" title="Tạm trú" width="400px" />
                            <Column field="identityNumber" title="CMND" width="150px" />
                            <Column field="identityLicensePlace" title="Nơi cấp CMMD" width="200px" />
                            <Column field="identityLicenseDate" title="Ngày cấp" width="150px" format="{0:dd-MM-yyyy}"/>
                            <Column field="department" title="Bộ phận" width="250px" />
                            <Column field="group" title="Tổ làm" width="250px" />
                            <Column field="job" title="Công việc" width="250px" />
                            <Column field="position" title="Chức vụ" width="250px" />
                            <Column field="laborGroup" title="Nhóm lao động" width="250px" />
                            <Column field="status" title="Trạng thái" width="150px" />
                            <Column field="dateOfBirth" title="Ngày sinh" width="150px" format="{0:dd-MM-yyyy}"/>
                            <Column field="age" title="Tuổi" width="80px"/>
                            <Column field="note" title="Ghi chú"/>
                        </Grid>
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