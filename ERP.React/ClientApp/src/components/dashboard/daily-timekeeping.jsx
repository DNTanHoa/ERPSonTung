import React, { Component, PureComponent } from 'react';
import { Link } from 'react-router-dom';
import { InforCard } from '../card/infor-card';
import { getDashboardOverview } from '../../apis/Statistic/statistic-api'
import { Chart, ChartLegend, ChartSeries, ChartSeriesItem, ChartCategoryAxis, ChartCategoryAxisItem } from '@progress/kendo-react-charts';

export class DailyTimeKeeping extends React.Component {
    constructor(props){
        super(props);
        
        this.state = {
            employeeOnTime: 0,
            employeeGoLate: 0,
            employeeFoods: 0,
            employeeOutSide: 0,
            departmentStatistic: [],
            monitorDate: new Date(),
            categories: [
                {name: 'Tổ sản xuất', percent: 0.25, employeeCount: 250, employeeLeave: 10},
                {name: 'Chuyền', percent: 0.15, employeeCount: 150, employeeLeave: 10},
                {name: 'Wash', percent: 0.3, employeeCount: 300, employeeLeave: 10},
                {name: 'Hành chính - nhân sự', percent: 0.2, employeeCount: 200, employeeLeave: 10},
                {name: 'IT', percent: 0.1, employeeCount: 100, employeeLeave: 10},
            ]
        }
    }

    render = () => {
        return(
            <div className="container-fluid pb-2 pb-md-0" style={{paddingLeft: '0px', paddingRight: '0px'}}>
                <section className="content-header">
                    <div className="container-fluid">
                        <div className="row mb-2">
                            <div className="col-sm-6">
                                <ol className="breadcrumb float-sm-left">
                                    <li className="breadcrumb-item"><a href="#">Theo dõi tổng quan</a></li>
                                    <li className="breadcrumb-item active">Chấm công ngày</li>
                                </ol>
                            </div>
                            <div className="col-sm-6">
                                <h1 className="float-sm-right">Chấm công ngày {this.state.monitorDate.getDate()} - {this.state.monitorDate.getMonth() + 1} - {this.state.monitorDate.getFullYear()}</h1>
                            </div>
                        </div>
                    </div>
                </section>
                <section className="content">
                    <div className="container-fluid">
                        <div className="row">
                            <InforCard boxType='small-box bg bg-success'
                                displayName='Đúng giờ'
                                boxValue={ this.state.employeeOnTime}
                                icon='fas fa-users'
                                href=''
                                displayText='Xem chi tiết'></InforCard>
                            <InforCard boxType='small-box bg bg-danger'
                                displayName='Đi trễ'
                                boxValue={this.state.employeeGoLate}
                                icon='fas fa-users'
                                href=''
                                displayText='Xem chi tiết'></InforCard>
                            <InforCard boxType='small-box bg bg-primary'
                                displayName='Xuất cơm dự kiến'
                                boxValue={this.state.employeeFoods}
                                icon='fas fa-users'
                                href=''
                                displayText='Xem chi tiết'></InforCard>
                            <InforCard boxType='small-box bg bg-info'
                                displayName='Công tác'
                                boxValue={this.state.employeeOutSide}
                                icon='fas fa-chart-pie'
                                href=''
                                displayText='Xem chi tiết'></InforCard>
                        </div>
                        <div className="row">
                            <div className="col-md-6">
                                <div className="card h-100 " >
                                    <div className="card-header">
                                        <h3 className="card-title">
                                            Nhân sự - Bộ phận
                                        </h3>
                                    </div>
                                    <div className="card-body w-100" style={{overflowX:'auto'}}>
                                        <table className="table table-bordered">
                                            <thead>
                                                <tr>
                                                    <th>Bộ phận</th>
                                                    <th>Đi trễ</th>
                                                    <th>Công tác</th>
                                                    <th></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                {this.state.departmentStatistic.map((item, index) => {
                                                    return(
                                                        <tr>
                                                            <td>{item.name}</td>
                                                            <td>{item.employeeCount}</td>
                                                            <td>{item.employeeLeave}</td>
                                                            <td>
                                                                <button className="btn btn-success">
                                                                    <i className="fas fa-external-link-square-alt"></i>
                                                                </button>
                                                            </td>
                                                        </tr>
                                                    )
                                                })}
                                                <tr>
                                                    <td style={{fontWeight:'bold'}}>Tổng cộng</td>
                                                    <td>{this.state.departmentStatistic.reduce((a,b) => a + (b.employeeCount || 0),0)}</td>
                                                    <td>{this.state.departmentStatistic.reduce((a,b) => a + (b.employeeLeave || 0),0)}</td>
                                                    <td></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div className="col-md-6 mt-2 mt-md-0">
                                <div className="card w-100 h-100">
                                    <div className="card-header">
                                        <h3 className="card-title">Biểu đồ tỷ lệ nhân sự</h3>
                                    </div>
                                    <div className="card-body">
                                    <Chart style={{ height: 350 }}>
                                        <ChartLegend position="top" orientation="horizontal" />
                                        <ChartCategoryAxis>
                                            <ChartCategoryAxisItem categories={this.state.categories.map((item) => item.name)} startAngle={45} />
                                        </ChartCategoryAxis>
                                        <ChartSeries>
                                            {this.state.categories.map((item, idx) => (
                                                <ChartSeriesItem
                                                    key={idx}
                                                    type="column"
                                                    tooltip={{ visible: true }}
                                                    data={item.employeeCount}
                                                    name={item.name}
                                                />
                                            ))}
                                        </ChartSeries>
                                    </Chart>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        )
    }
}