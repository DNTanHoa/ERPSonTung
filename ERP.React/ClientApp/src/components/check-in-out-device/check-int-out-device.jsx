import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { Grid, GridColumn as Column, GridToolbar } from '@progress/kendo-react-grid';
import { AutoComplete, ComboBox, DropDownList, MultiSelect } from '@progress/kendo-react-dropdowns';
import config from '../../appsettings.json';
import { Loading } from '../loading';
import { ToastContainer, toast } from 'react-toastify';

export class CheckInOutDevice extends React.Component {
    constructor(props) {
        super(props)
    }

    render = () => {
        return(
            <div className="container-fluid">
                <section className="content-header">
                    <div className="container-fluid">
                        <div className="row mb-2">
                            <div className="col-sm-6">
                                <h1 className="float-sm-left">Quản lý hệ thống</h1>
                            </div>
                            <div className="col-sm-6">
                                <ol className="breadcrumb float-sm-right">
                                    <li className="breadcrumb-item"><a href="#">Quản lý hệ thống</a></li>
                                    <li className="breadcrumb-item active">Thiết bị chấm công</li>
                                </ol>
                            </div>
                        </div>
                    </div>
                </section>
                <section className="content">
                    <div className="container-fluid">
                        <div className="row">
                            <div className="card w-100" style={{overflowX:"auto"}}>
                                <div className="card-header">
                                    <h3 className="card-title">
                                        Thiết bị chấm công
                                    </h3>
                                </div>
                                <div className="card-body">
                                    <Grid style={{ height: "550px" }}>
                                        <GridToolbar>
                                            <div className="d-flex">
                                                <button className="btn btn-success"
                                                        title="Thêm thiết bị">
                                                    <i className="fas fa-plus-circle"></i>
                                                </button>
                                                <button className="btn btn-success ml-1"
                                                        title="Tải lại">
                                                    <i className="fas fa-sync"></i>
                                                </button>
                                            </div>
                                        </GridToolbar>
                                        <Column field="code" title="Mã số" width="200px" editable={false} />
                                        <Column field="textName" title="Tên máy" width="250px" />
                                        <Column field="connectionType" title="Loại kết nối" width="150px"/>
                                        <Column field="ipAddress" title="Đại chỉ IP" width="150px" />
                                        <Column field="port" title="Port" width="150px" format="dd-MM-yyyy"/>
                                        <Column field="com" title="Cổng com" width="150px" format="dd-MM-yyyy"/>
                                        <Column field="transferSpeed" title="Tốc độ truyền" width="150px" format="dd-MM-yyyy"/>
                                        <Column field="website" title="Website" width="150px" format="dd-MM-yyyy"/>
                                        <Column field="status" title="Trạng thái"/>
                                        <Column field="note" title="Ghi chú"/>
                                    </Grid>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        )
    }
}