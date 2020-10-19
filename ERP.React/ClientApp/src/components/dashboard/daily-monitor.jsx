import React, { Component, PureComponent } from 'react';
import { Link } from 'react-router-dom';
import { InforCard } from '../card/infor-card';

export default class DailyMonitor extends React.Component {
    constructor(props){
        super(props);

        this.state =  {
            emloyeeCount: 0,
            employeeLeaveWithPermission: 0,
            employeeLeaveNoPermission: 0,
            percentLeave: 0,
            monitorDate: new Date(),
        }
    }

    render() {
        return(
            <div className="container-fluid">
                <section className="content-header">
                    <div className="container-fluid">
                        <div className="row mb-2">
                            <div className="col-sm-6">
                                <ol className="breadcrumb float-sm-left">
                                    <li className="breadcrumb-item"><Link href="#">Theo dõi tổng quan</Link></li>
                                    <li className="breadcrumb-item active">Tình hình nhân sự</li>
                                </ol>
                            </div>
                            <div className="col-sm-6">
                                <h1 className="float-sm-right">Bảng giám sát ngày {this.state.monitorDate.getDate()} - {this.state.monitorDate.getMonth() + 1} - {this.state.monitorDate.getFullYear()}</h1>
                            </div>
                        </div>
                    </div>
                </section>
                <section className="content">
                    <div className="container-fluid">
                        <div className="row">
                            <InforCard boxType='small-box bg bg-success'
                                displayName='Nhân viên'
                                boxValue={this.state.emloyeeCount}
                                icon='fas fa-users'
                                href=''
                                displayText='Xem chi tiết'></InforCard>
                            <InforCard boxType='small-box bg bg-warning'
                                displayName='Vắng có phép'
                                boxValue={this.state.employeeLeaveWithPermission}
                                icon='fas fa-users'
                                href=''
                                displayText='Xem chi tiết'></InforCard>
                            <InforCard boxType='small-box bg bg-danger'
                                displayName='Vắng không phép'
                                boxValue={this.state.employeeLeaveWithPermission}
                                icon='fas fa-users'
                                href=''
                                displayText='Xem chi tiết'></InforCard>
                            <InforCard boxType='small-box bg bg-info'
                                displayName='Tỷ lệ vắng'
                                boxValue={this.state.percentLeave}
                                icon='fas fa-chart-pie'
                                href=''
                                displayText='Xem chi tiết'></InforCard>
                        </div>
                    </div>
                </section>
            </div>
        )
    }
}