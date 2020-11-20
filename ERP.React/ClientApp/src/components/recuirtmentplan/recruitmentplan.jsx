import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { Grid, GridColumn as Column, GridToolbar } from '@progress/kendo-react-grid';
import { DropDownList } from '@progress/kendo-react-dropdowns';
import config from '../../appsettings.json';
import { Loading } from '../loading';
import { ToastContainer, toast } from 'react-toastify';
import RecruitmentPlanModal from './recruimentplan-modal';
import { getCategoriesByEntity } from "../../apis/category/category-service";
import { Modal } from 'react-bootstrap';

export class RecruitmentPlan extends React.Component {
    constructor(props){
        super(props)

        this.state = {
            showModal: false,
            departments:[],
            department: {},
        }

        this.handleModalHide = this.handleModalHide.bind(this);
    }

    componentDidMount = async () => {
        let departments = await (await getCategoriesByEntity(config.entities.department))
        .map((department) => {return {...department, textname: department.code +' - '+ department.name}});
        this.setState({departments})
    }

    handleModalHide = () => {
        this.setState({showModal:false})
    }

    handleSelectChange = (e) => {
        this.setState({
            [e.target.name]: e.value
        });
    }

    handleSearch = (e) => {

    }

    render = () => {
        return(
        <div className="container-fluid">
            <section className="content-header">
                <div className="container-fluid">
                    <div className="row mb-2">
                        <div className="col-sm-6">
                            <h1 className="float-sm-left">Tuyển dụng</h1>
                        </div>
                        <div className="col-sm-6">
                            <ol className="breadcrumb float-sm-right">
                                <li className="breadcrumb-item"><a href="#">Tuyển dụng</a></li>
                                <li className="breadcrumb-item active">Kế hoạch</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </section>
            <section className="content">
                <div className="container-fluid">
                    <div className="row">
                        <div className="card p-1">
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
                                    <div className="col-md-3 col-lg-3 mt-1 mt-md-0 p-1">
                                            <input className="form-control" placeholder="Tìm...."></input>
                                        </div>
                                    <div className="col-md-1 col-12 mt-1 mt-md-0 p-1">
                                        <button className="btn btn-success w-100" title="Tìm kết quả" onClick={this.handleSearch}>
                                            <i className="fas fa-search"></i>
                                        </button>
                                    </div>
                                </div>
                            </div>
                            <div className="card-body p-1">
                                <Grid style={{ height: "550px" }}>
                                    <GridToolbar>
                                        <div className="d-flex">
                                            <button className="btn btn-success"
                                                onClick={() => {this.setState({showModal: true});}}
                                                title="Thêm kế hoạch">
                                                <i className="fas fa-plus-circle"></i>
                                            </button>
                                            <button className="btn btn-success ml-1"
                                                title="Tải lại">
                                                <i className="fas fa-sync"></i>
                                            </button>
                                        </div>
                                    </GridToolbar>
                                    <Column field="code" title="Mã số" width="200px" editable={false} />
                                    <Column field="title" title="Tiêu đề" width="250px" />
                                    <Column field="quantity" title="Số lượng" width="150px"/>
                                    <Column field="job" title="Vị trí" width="150px" />
                                    <Column field="department" title="Bộ phận" width="150px" />
                                    <Column field="startDate" title="Từ ngày" width="150px" format="dd-MM-yyyy"/>
                                    <Column field="endDate" title="Đến ngày" width="150px" format="dd-MM-yyyy"/>
                                    <Column field="note" title="Ghi chú"/>
                                </Grid>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <Modal centered={true} 
                size="xl"
                onHide={this.handleModalHide}
                enforceFocus={false}
                show={this.state.showModal}>
                <RecruitmentPlanModal onHide={this.handleModalHide}/>
            </Modal>
        </div>
        )
    }
}