import React, { Component, PureComponent } from 'react';
import { Link } from 'react-router-dom';
import { InforCard } from '../card/infor-card';
import { getDashboardOverview } from '../../apis/Statistic/statistic-api'
import { Chart, ChartLegend, ChartSeries, ChartSeriesItem } from '@progress/kendo-react-charts';
import AppContext from '../../providers/context/app-context';
import { AppProvider } from '../../providers/context/app-provider';


export default class DailyMonitor extends React.Component {
    constructor(props){
        super(props);

        this.state =  {
            employeeCount: 0,
            employeeLeaveWithPermission: 0,
            employeeLeaveNoPermission: 0,
            percentLeave: 0,
            monitorDate: new Date(),
            departmentStatistic: [
                {name: 'Tổ sản xuất', percent: 0.25, employeeCount: 250, employeeLeave: 10},
                {name: 'Chuyền', percent: 0.15, employeeCount: 150, employeeLeave: 10},
                {name: 'Wash', percent: 0.3, employeeCount: 300, employeeLeave: 10},
                {name: 'Hành chính - nhân sự', percent: 0.2, employeeCount: 200, employeeLeave: 10},
                {name: 'IT', percent: 0.1, employeeCount: 100, employeeLeave: 10},
            ]
        }
    }

    chartLabelContent = (props) => {
        let formatedNumber = Number(props.dataItem.percent).toLocaleString(undefined, { style: 'percent', minimumFractionDigits: 2 });
        return `${props.dataItem.name}: ${formatedNumber}`;
    }

    componentDidMount = async () => {
        let data = await getDashboardOverview(new Date().setHours(0,0,0,0), new Date().setHours(23,59,59,0));
        let result = data[0];
        this.setState({
            employeeCount: result.employeeCount,
            employeeLeaveNoPermission: result.employeeLeaveNoPermission,
            employeeLeaveWithPermission: result.employeeLeaveWithPermission,
            percentLeave: result.percentLeave
        });
    }

    render() {
        return(
            <div className="container-fluid pb-2 pb-md-0" style={{paddingLeft: '0px', paddingRight: '0px'}}>
                <section className="content-header">
                    <div className="container-fluid">
                        <div className="row mb-2">
                            <div className="col-sm-6">
                                <ol className="breadcrumb float-sm-left">
                                    <li className="breadcrumb-item"><a href="#">Theo dõi tổng quan</a></li>
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
                                boxValue={ this.state.employeeCount}
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
                                boxValue={this.state.employeeLeaveNoPermission}
                                icon='fas fa-users'
                                href=''
                                displayText='Xem chi tiết'></InforCard>
                            <InforCard boxType='small-box bg bg-info'
                                displayName='Tỷ lệ vắng'
                                boxValue={this.state.percentLeave.toLocaleString(undefined, { FractionDigits: 1 }) + '%'}
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
                                                    <th>Số lượng</th>
                                                    <th>Vắng</th>
                                                    <th></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                {this.state.departmentStatistic.map((item, index) => {
                                                    return(
                                                        <tr key={index}>
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
                                        <Chart title="Tỷ lệ nhân sự theo bộ phận">
                                            <ChartLegend position="bottom" />
                                            <ChartSeries>
                                                <ChartSeriesItem type="pie" data={this.state.departmentStatistic} field="percent" categoryField="name" labels={{ visible: true, content: this.chartLabelContent }} />
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