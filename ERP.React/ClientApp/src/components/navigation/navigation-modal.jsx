import React from 'react';
import { Modal } from 'react-bootstrap';
import { AutoComplete, ComboBox, DropDownList, MultiSelect } from '@progress/kendo-react-dropdowns';
import { insertNavigation, updateNavigation } from "../../apis/navigation/navigation-service";
import { getCategoriesByEntity } from "../../apis/category/category-service";
import { getNavigations } from '../../apis/navigation/navigation-service';
import config from '../../appsettings.json';
import { ToastContainer, toast } from 'react-toastify';    
import { filterBy } from '@progress/kendo-data-query';

let navigationTypes = [];
let navigations = [];
let container;

const delay = 300;


export default class NavigationModal extends React.Component {
    constructor(props) {
        super(props)

        this.state = {
            id: this.props.model.id,
            type: this.props.model.type,
            code: this.props.model.code,
            icon: this.props.model.icon,
            displayName: this.props.model.displayName,
            componentPath: this.props.model.componentPath,
            controller: this.props.model.controller,
            action: this.props.model.action,
            note: this.props.model.note,
            parentCode: this.props.model.parentCode,
            navigationTypes: [],
            defaultNavigationType: {},
            navigations: [],
            selectedNavigationType: {},
            selectedNavigationGroup: {}
        }
    }

    componentDidMount = async () => {
        navigationTypes = await (await getCategoriesByEntity(config.entities.navigationType))
        .map((navigationType) => {return {...navigationType, textname: navigationType.code +' - '+ navigationType.name}});

        navigations = await (await getNavigations())
        .map((navigation) => {return {...navigation, textname: navigation.code +' - '+ navigation.displayName}});
        
        let selectedNavigationType = navigationTypes.find(item => item.code === this.state.type);

        let selectedNavigationGroup = navigations.find(item => item.code === this.state.parentCode);

        this.setState({ navigationTypes, navigations, selectedNavigationType, selectedNavigationGroup});
    }

    handleSaveChange = async () => {
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
            parentCode: this.state.parentCode
        }

        let respone = {}

        if(this.state.id > 0) {
            respone = await updateNavigation(dataItem);
        } 
        else {
            respone = await insertNavigation(dataItem);
            this.setState(respone.data);
        }

        if(respone.result.resultType === 0) {
            toast.success(`Cập nhật điều hướng ${respone.data.code} thành công`, 2000);
        }
        else {
            toast.error(`Thao tác thất bại`);
        }
        console.log(respone);
    }

    handleChange = (event) => {
        this.setState({
            [event.target.name]: event.target.value
        });
    }

    filterNavigationTypeChange = (e) => {
        clearTimeout(this.timeout);
        this.timeout = setTimeout(() => {
            this.setState({navigationTypes: this.filterNavigationTypes(e.filter)});
        }, delay);
    }

    filterNavigationChange = (e) => {
        clearTimeout(this.timeout);
        this.timeout = setTimeout(() => {
            this.setState({navigations: this.filterNavigations(e.filter)});
        }, delay);
    }

    filterNavigationTypes(filter) {
        return filterBy(navigationTypes, filter);
    }

    filterNavigations(filter) {
        return filterBy(navigations, filter);
    }

    handleSelectChange = (event) => {
        this.setState({
            [event.target.name]: event.value.code
        })
    }

    render = () => {
        return(
            <>
                <ToastContainer ref={ref => container = ref}
                    className="toast-top-right">
                </ToastContainer>
                <Modal.Header closeButton>
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
                                    name="type"
                                    defaultValue={this.state.defaultNavigationType}
                                    delay={1000}
                                    filterable={true}
                                    value={this.state.selectedNavigationType}
                                    onChange={this.handleSelectChange}
                                    onFilterChange={this.filterNavigationTypeChange}
                                    style={{width: '100%'}}/>
                            </div>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-12">
                            <div className="form-group m-0">
                                <label className="m-0">Nhóm</label>
                                <DropDownList data={this.state.navigations} 
                                    textField="textname"
                                    dataItemKey="code"
                                    name="parentCode"
                                    delay={1000}
                                    filterable={true}
                                    value={this.state.selectedNavigationGroup}
                                    onChange={this.handleSelectChange}
                                    onFilterChange={this.filterNavigationChange}
                                    style={{width: '100%'}}/>
                            </div>
                        </div>
                    </div>
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
                                <label className="m-0">Tên hiển thị</label>
                                <input name="displayName" 
                                    className="form-control"
                                    placeholder="Tên hiển thị"
                                    value={this.state.displayName}
                                    onChange={this.handleChange}></input>
                            </div>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-12">
                            <div className="form-group m-0">
                                <label className="m-0">Component</label>
                                <input name="componentPath" 
                                    className="form-control"
                                    placeholder="Đường dẫn"
                                    value={this.state.componentPath}
                                    onChange={this.handleChange}></input>
                            </div>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-12">
                            <div className="form-group m-0">
                                <label className="m-0">Controller</label>
                                <input name="controller" 
                                    className="form-control"
                                    placeholder="Controller"
                                    value={this.state.controller}
                                    onChange={this.handleChange}></input>
                            </div>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-12">
                            <div className="form-group m-0">
                                <label className="m-0">Action</label>
                                <input name="action" 
                                    className="form-control"
                                    placeholder="Action"
                                    value={this.state.action}
                                    onChange={this.handleChange}></input>
                            </div>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-12">
                            <div className="form-group m-0">
                                <label className="m-0">Icon</label>
                                <input name="icon" 
                                    className="form-control" 
                                    placeholder="Icon"
                                    value={this.state.icon}
                                    onChange={this.handleChange}></input>
                            </div>
                        </div>
                    </div>
                    <div className="row mb-1">
                        <div className="col-md-12">
                            <div className="form-group m-0">
                                <label className="m-0">Note</label>
                                <input name="note" 
                                    className="form-control" 
                                    placeholder="Ghi chú"
                                    value={this.state.note}
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
            </>
        )
    }
}