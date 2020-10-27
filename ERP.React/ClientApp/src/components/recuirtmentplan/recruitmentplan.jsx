import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { Grid, GridColumn as Column, GridToolbar } from '@progress/kendo-react-grid';
import { AutoComplete, ComboBox, DropDownList, MultiSelect } from '@progress/kendo-react-dropdowns';
import config from '../../appsettings.json';
import { Loading } from '../loading';
import { ToastContainer, toast } from 'react-toastify';
import RecruitmentPlanModal from './recruimentplan-modal';
import { Modal } from 'react-bootstrap';

export class RecruitmentPlan extends React.Component {
    constructor(props){
        super(props)

        this.state = {
            showModal: false
        }

        this.handleModalHide = this.handleModalHide.bind(this);
    }

    handleModalHide = () => {
        this.setState({showModal:false})
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
                                <li className="breadcrumb-item active">Kế hoạch tuyển dụng</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </section>
            <section className="content">
                <div className="container-fluid">
                    <div className="row">
                        <div className="card">
                            <div className="card-header">
                                <h3 className="card-title">
                                    Kế hoạch tuyển dụng
                                </h3>
                            </div>
                            <div className="card-body">
                                <Grid style={{ height: "550px" }}>
                                    <GridToolbar>
                                        <div className="d-flex">
                                            <button className="btn btn-success"
                                                onClick={() => {this.setState({showModal: true}); console.log(this.state);}}
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
                show={this.state.showModal}><RecruitmentPlanModal onHide={this.handleModalHide}/></Modal>
        </div>
        )
    }
}