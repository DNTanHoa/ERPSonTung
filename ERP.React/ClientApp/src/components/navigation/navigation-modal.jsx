import React from 'react';
import { Modal } from 'react-bootstrap';
import { AutoComplete, ComboBox, DropDownList, MultiSelect } from '@progress/kendo-react-dropdowns';
import { insertNavigation } from "../../apis/navigation/navigation-service";
import { getCategoriesByEntity } from "../../apis/category/category-service";
import config from '../../appsettings.json'
import { isConstructorDeclaration } from 'typescript';

export default class NavigationModal extends React.Component {
    constructor(props) {
        super(props)

        this.state = {
            id: 0,
            type: 'NT001',
            code: '',
            icon: '',
            displayName: '',
            componentPath: '',
            controller: '',
            action: '',
            note:'',
            navigationTypes: [],
            defaultNavigationType: {},
        }
    }

    componentDidMount = async () => {
        let navigationTypes = await (await getCategoriesByEntity(config.entities.navigationType))
        .map((navigationType) => {return {...navigationType, textname: navigationType.code +' - '+ navigationType.name}});
        let defaultNavigationType = navigationTypes[0];
        this.setState({ navigationTypes, defaultNavigationType });
        console.log(this.state);
    }

    handleSaveChange = () => {
        const dataItem = {
            id: this.state.id,
            type: this.state.type,
            code: this.state.code,
            icon: this.state.icon,
            displayName: this.state.displayName,
            componentPath: this.state.componentPath,
            controller: this.state.componentPath,
            action: this.state.action,
            note: this.state.note,
        }

        console.log(dataItem);

        let result = insertNavigation(dataItem);

        console.log(result);
    }

    handleChange = (event) => {
        this.setState({
            [event.target.name]: event.target.value
        });
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
                                <DropDownList data={this.state.navigationTypes} 
                                    textField="textname"
                                    dataItemKey="code"
                                    name="employeeStatus"
                                    defaultValue={this.state.defaultNavigationType}
                                    delay={1000}
                                    filterable={true}
                                    value={this.state.employeeStatus}
                                    onChange={this.handleSelectChange}
                                    style={{width: '100%'}}/>
                            </div>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-12">
                            <div className="form-group m-0">
                                <label className="m-0">Nhóm</label>
                                <input name="parentCode" className="form-control" placeholder="Nhóm" onChange={this.handleChange}></input>
                            </div>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-12">
                            <div className="form-group m-0">
                                <label className="m-0">Mã quản lý</label>
                                <input name="code" className="form-control" readOnly placeholder="Mã quản lý" onChange={this.handleChange}></input>
                            </div>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-12">
                            <div className="form-group m-0">
                                <label className="m-0">Tên hiển thị</label>
                                <input name="displayName" className="form-control" placeholder="Tên hiển thị" onChange={this.handleChange}></input>
                            </div>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-12">
                            <div className="form-group m-0">
                                <label className="m-0">Component</label>
                                <input name="component" className="form-control" placeholder="Đường dẫn" onChange={this.handleChange}></input>
                            </div>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-12">
                            <div className="form-group m-0">
                                <label className="m-0">Controller</label>
                                <input name="controller" className="form-control" placeholder="Controller" onChange={this.handleChange}></input>
                            </div>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-12">
                            <div className="form-group m-0">
                                <label className="m-0">Action</label>
                                <input name="action" className="form-control" placeholder="Action" onChange={this.handleChange}></input>
                            </div>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-12">
                            <div className="form-group m-0">
                                <label className="m-0">Icon</label>
                                <input name="icon" className="form-control" placeholder="Icon" onChange={this.handleChange}></input>
                            </div>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-12">
                            <div className="form-group m-0">
                                <label className="m-0">Note</label>
                                <input name="note" className="form-control" placeholder="Ghi chú" onChange={this.handleChange}></input>
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
            </>
        )
    }
}