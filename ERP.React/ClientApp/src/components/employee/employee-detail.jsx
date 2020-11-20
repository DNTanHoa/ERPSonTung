import React, { Component, PureComponent } from 'react';
import { DatePicker } from '@progress/kendo-react-dateinputs';
import { TabStrip, TabStripTab } from '@progress/kendo-react-layout';
import './employee-detail.css';
import { Grid, GridColumn as Column, GridToolbar } from '@progress/kendo-react-grid';

export default class EmployeeDetail extends React.Component {
    constructor(props) {
        super(props)

        this.state = {
            selected: 0
        }
    }

    handleTabSelect = (e) => {
        this.setState({ selected: e.selected });
    }

    render = () => {
       return(
        <div className="container-fluid">
            <section className="content-header">
                <div className="container-fluid px-1">
                    <div className="row mb-2">
                        <div className="card w-100">
                            <div className="card-header">
                                <div className="row">
                                    <h3 className="card-title col-sm-6 px-0">Thông tin nhân viên</h3>
                                    <div className="col-sm-4"></div>
                                    <div className="col-6 col-md-1 px-1 py-1 py-md-0">
                                        <button className="btn btn-primary w-100" title="Lưu thông tin nhân viên">
                                            <i className="far fa-save"></i>
                                        </button>
                                    </div>
                                    <div className="col-6 col-md-1 px-1 py-1 py-md-0">
                                        <button className="btn btn-dark w-100" title="Thoát">
                                            <i className="fas fa-arrow-left"></i>
                                        </button>
                                    </div>
                                </div>
                            </div>
                            <div className="card-body">
                               <div className="row">
                                    <div className="col-md-4 col-lg-2 text-center p-1">
                                        <img src="/images/avatar.png" style={{height: '160px', width: '160px'}}></img>
                                        <div className="input-group mt-md-5 mt-1">
                                            <input type="text" class="form-control" placeholder="Upload hình ảnh"/>
                                            <div className="input-group-append">
                                                <button className="btn btn-success">
                                                    <i class="fas fa-cloud-upload-alt"></i>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                    <div className="col-md-3 col-lg-5 p-1">
                                        <div className="row">
                                            <div className="col-6">
                                                <div class="form-group m-0">
                                                    <label class="m-0" for="Code">Họ và đệm</label>
                                                    <input type="text" class="form-control" placeholder="Họ tên đệm"></input>
                                                </div>
                                            </div>
                                            <div className="col-6">
                                                <div class="form-group m-0">
                                                    <label class="m-0" for="Code">Tên</label>
                                                    <input type="text" class="form-control" placeholder="Tên"></input>
                                                </div>
                                            </div>
                                        </div>
                                        <div className="row">
                                            <div className="col-6">
                                                <div class="form-group m-0">
                                                    <label class="m-0" for="Code">Mã</label>
                                                    <input type="text" class="form-control" placeholder="Mã"></input>
                                                </div>
                                            </div>
                                            <div className="col-6">
                                                <div class="form-group m-0">
                                                    <label class="m-0" for="Code">Chấn công</label>
                                                    <input type="text" class="form-control" placeholder="Chấm công"></input>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div className="col-6">
                                                <label class="m-0" for="Code">Vào làm</label>
                                                <DatePicker format="dd-MM-yyyy"
                                                    className="w-100"
                                                    defaultValue={new Date()}/>
                                            </div>
                                            <div className="col-6">
                                                <label class="m-0" for="Code">Ngày sinh</label>
                                                <DatePicker format="dd-MM-yyyy"
                                                    className="form-control"
                                                    defaultValue={new Date()}/>
                                            </div>
                                            
                                        </div>
                                        <div class="form-group m-0">
                                            <label class="m-0" for="Code">Trạng thái</label>
                                            <input type="text" class="form-control" placeholder="Trạng thái"></input>
                                        </div>
                                    </div>
                                    <div className="col-md-5 p-1">
                                        <div className="row">
                                            <div className="col-6">
                                                <div class="form-group m-0">
                                                    <label class="m-0" for="Code">Bộ phận</label>
                                                    <input type="text" class="form-control" placeholder="Mã"></input>
                                                </div>
                                            </div>
                                            <div className="col-6">
                                                <div class="form-group m-0">
                                                    <label class="m-0" for="Code">Tổ</label>
                                                    <input type="text" class="form-control" placeholder="Chấm công"></input>
                                                </div>
                                            </div>
                                        </div>
                                        <div className="row">
                                            <div className="col-6">
                                                <div class="form-group m-0">
                                                    <label class="m-0" for="Code">Chức vụ</label>
                                                    <input type="text" class="form-control" placeholder="Mã"></input>
                                                </div>
                                            </div>
                                            <div className="col-6">
                                                <div class="form-group m-0">
                                                    <label class="m-0" for="Code">Công việc</label>
                                                    <input type="text" class="form-control" placeholder="Chấm công"></input>
                                                </div>
                                            </div>
                                        </div>
                                        <div className="row">
                                            <div className="col-6">
                                                <div class="form-group m-0">
                                                    <label class="m-0" for="Code">Nhóm</label>
                                                    <input type="text" class="form-control" placeholder="Mã"></input>
                                                </div>
                                            </div>
                                            <div className="col-6">
                                                <div class="form-group m-0">
                                                    <label class="m-0" for="Code">Quản lý</label>
                                                    <input type="text" class="form-control" placeholder="Chấm công"></input>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group m-0">
                                            <label class="m-0" for="Code">Ghi chú</label>
                                            <input type="text" class="form-control" placeholder="Ghi chú"></input>
                                        </div>
                                    </div>
                               </div>
                            </div>
                        </div>
                    </div>
                    <div className="row mb-md-1 mb-1">
                        <div className="card w-100" style={{overflowX:'auto'}}>
                            <div className="card-header">
                                <h3 className="card-title">Thông tin liên quan</h3>
                            </div>
                            <div className="card-body w-100">
                                <TabStrip selected={this.state.selected} onSelect={this.handleTabSelect} className="w-100">
                                    <TabStripTab title="1.Liên hệ" className="w-100">
                                        <div className="container-fluid w-100">
                                            <div className="row">
                                                <div className="col-md-2 col-lg-1">
                                                    <label className="text-nowrap m-0 mr-2 mt-md-1">Thường trú</label>
                                                </div>
                                                <div className="col-md-10 col-lg-11">
                                                    <div className="input-group mb-2">
                                                        <input type="text" class="form-control" placeholder="Địa chỉ thường trú"/>
                                                        <div className="input-group-append">
                                                            <button className="btn btn-success">
                                                                <i className="fas fa-map-marker-alt"></i>
                                                            </button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div className="row">
                                                <div className="col-md-2 col-lg-1">
                                                    <label className="text-nowrap m-0 mr-2 mt-md-1">Trạm trú</label>
                                                </div>
                                                <div className="col-md-10 col-lg-11">
                                                    <div className="input-group mb-2">
                                                        <input type="text" class="form-control" placeholder="Địa chỉ tạm trú"/>
                                                        <div className="input-group-append">
                                                            <button className="btn btn-success">
                                                                <i className="fas fa-map-marker-alt"></i>
                                                            </button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div className="row mb-md-2 mb-0">
                                                <div className="col-md-2 col-lg-1">
                                                    <label className="text-nowrap m-0 mr-2 mt-md-1">Điện thoại</label>
                                                </div>
                                                <div className="col-md-2 col-lg-3">
                                                    <input type="text" class="form-control w-100" placeholder="Điện thoại"/>
                                                </div>
                                                <div className="col-md-2 col-lg-1">
                                                    <label className="text-nowrap m-0 mr-2 mt-md-1">Email</label>
                                                </div>
                                                <div className="col-md-2 col-lg-3">
                                                    <input type="text" class="form-control w-100" placeholder="Email công ty"/>
                                                </div>
                                                <div className="col-md-2 col-lg-1">
                                                    <label className="text-nowrap m-0 mr-2 mt-md-1">Email (phụ)</label>
                                                </div>
                                                <div className="col-md-2 col-lg-3">
                                                    <input type="text" class="form-control w-100" placeholder="Email cá nhân"/>
                                                </div>
                                            </div>
                                            <div className="row mb-md-2 mb-0">
                                                <div className="col-md-2 col-lg-1">
                                                    <label className="text-nowrap m-0 mr-2 mt-md-1">CMND</label>
                                                </div>
                                                <div className="col-md-2 col-lg-3">
                                                    <input type="text" class="form-control w-100" placeholder="Chứng minh, căn cước, hộ chiếu"/>
                                                </div>
                                                <div className="col-md-2 col-lg-1">
                                                    <label className="text-nowrap m-0 mr-2 mt-md-1">Ngày Cấp</label>
                                                </div>
                                                <div className="col-md-2 col-lg-3">
                                                    <input type="text" class="form-control w-100" placeholder="Ngày cấp"/>
                                                </div>
                                                <div className="col-md-2 col-lg-1">
                                                    <label className="text-nowrap m-0 mr-2 mt-md-1">Nơi cấp</label>
                                                </div>
                                                <div className="col-md-2 col-lg-3">
                                                    <input type="text" class="form-control w-100" placeholder="Nơi cấp"/>
                                                </div>
                                            </div>
                                            <div className="row mb-md-2 mb-0">
                                                <div className="col-md-2 col-lg-1">
                                                    <label className="text-nowrap m-0 mr-2 mt-md-1">Giới tính</label>
                                                </div>
                                                <div className="col-md-2 col-lg-3">
                                                    <input type="text" class="form-control w-100" placeholder="Giới tính"/>
                                                </div>
                                                <div className="col-md-2 col-lg-1">
                                                    <label className="text-nowrap m-0 mr-2 mt-md-1">Dân tộc</label>
                                                </div>
                                                <div className="col-md-2 col-lg-3">
                                                    <input type="text" class="form-control w-100" placeholder="Ngày cấp"/>
                                                </div>
                                                <div className="col-md-2 col-lg-1">
                                                    <label className="text-nowrap m-0 mr-2 mt-md-1">Tôn giáo</label>
                                                </div>
                                                <div className="col-md-2 col-lg-3">
                                                    <input type="text" class="form-control w-100" placeholder="Tôn giáo"/>
                                                </div>
                                            </div>
                                            <div className="row mb-md-2 mb-0">
                                                <div className="col-md-2 col-lg-1">
                                                    <label className="text-nowrap m-0 mr-2 mt-md-1">Tài khoản</label>
                                                </div>
                                                <div className="col-md-2 col-lg-3">
                                                    <input type="text" class="form-control w-100" placeholder="Giới tính"/>
                                                </div>
                                                <div className="col-md-2 col-lg-1">
                                                    <label className="text-nowrap m-0 mr-2 mt-md-1">Ngân hàng</label>
                                                </div>
                                                <div className="col-md-6 col-lg-7">
                                                    <input type="text" class="form-control w-100" placeholder="Tên ngân hàng"/>
                                                </div>
                                            </div>
                                        </div>
                                    </TabStripTab>
                                    <TabStripTab title="2.Hợp đồng">
                                        <Grid style={{ height: "350px" }}>
                                            <GridToolbar>
                                                <button className="btn btn-success"
                                                        title="Thêm thành viên"
                                                        onClick={this.addNew}>
                                                    <i className="fas fa-plus-circle"></i>
                                                </button>
                                            </GridToolbar>
                                            <Column field="code" title="Mã số" width="200px" editable={false} />
                                            <Column field="fullName" title="Đại diên" width="250px" />
                                            <Column field="startDate" title="Loại hợp đồng" width="150px"/>
                                            <Column field="status" title="Trạng thái" width="150px" />
                                            <Column field="dateOfBirth" title="Ngày ký" width="150px" format="dd-MM-yyyy"/>
                                            <Column field="dateOfBirth" title="Ngày hiệu lực" width="150px" format="dd-MM-yyyy"/>
                                            <Column field="dateOfBirth" title="Ngày hết hạn" width="150px" format="dd-MM-yyyy"/>
                                            <Column field="note" title="Ghi chú"/>
                                        </Grid>
                                    </TabStripTab>
                                    <TabStripTab title="3.Bảo hiểm">
                                        <Grid style={{ height: "350px" }}>
                                            <GridToolbar>
                                                <button className="btn btn-success"
                                                        title="Thêm thành viên"
                                                        onClick={this.addNew}>
                                                    <i className="fas fa-plus-circle"></i>
                                                </button>
                                            </GridToolbar>
                                            <Column field="code" title="Mã số" width="200px" editable={false} />
                                            <Column field="fullName" title="Số sổ" width="250px" />
                                            <Column field="fullName" title="Ngày đóng" width="250px" />
                                            <Column field="fullName" title="Nởi đăng ký KCB" width="250px" />
                                            <Column field="note" title="Số thẻ BHYT"/>
                                        </Grid>
                                    </TabStripTab>
                                    <TabStripTab title="4.Nghỉ phép">
                                        <Grid style={{ height: "350px" }}>
                                            <GridToolbar>
                                                <button className="btn btn-success"
                                                        title="Thêm thành viên"
                                                        onClick={this.addNew}>
                                                    <i className="fas fa-plus-circle"></i>
                                                </button>
                                            </GridToolbar>
                                            <Column field="code" title="STT" width="100px" editable={false} />
                                            <Column field="fullName" title="Ngày nghỉ" width="150px" />
                                            <Column field="fullName" title="Bắt đầu" width="150px" />
                                            <Column field="fullName" title="Két thúc" width="150px" />
                                            <Column field="fullName" title="Lý do" width="250px" />
                                            <Column field="note" title="Phê duyệt" width="100px"/>
                                            <Column field="note" title="Người phê duyệt"/>
                                            <Column field="note" title="Ghi chú"/>
                                        </Grid>
                                    </TabStripTab>
                                    <TabStripTab title="5.Lịch sử">

                                    </TabStripTab>
                                    <TabStripTab title="6.Hồ sơ">

                                    </TabStripTab>
                                    <TabStripTab title="7.Người thân">
                                        
                                    </TabStripTab>
                                    <TabStripTab title="8.Khen thưởng - kỷ luật">
                                        
                                    </TabStripTab>
                                </TabStrip>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
       )
    }
}