import React, { Component, PureComponent } from 'react';
import { Link } from 'react-router-dom';
import { InforCard } from '../card/infor-card';
import { DatePicker } from '@progress/kendo-react-dateinputs';
import { Grid, GridColumn as Column, GridToolbar } from '@progress/kendo-react-grid';
import { Loading } from '../loading';
import { getDashboardOverview } from '../../apis/Statistic/statistic-api'
import { Chart, ChartLegend, ChartSeries, ChartSeriesItem } from '@progress/kendo-react-charts';

export default class TimeKeeping extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            fromDate: new Date().setDate(1),
            toDate: new Date(),
            dateFields: [
                {name:'01102020', title: '01/10', isHoliday: false, isWeeken: false},
                {name:'02102020', title: '02/10', isHoliday: false, isWeeken: false},
                {name:'03102020', title: '03/10', isHoliday: false, isWeeken: false},
                {name:'04102020', title: '04/10', isHoliday: false, isWeeken: false},
                {name:'05102020', title: '05/10', isHoliday: false, isWeeken: false},
                {name:'06102020', title: '06/10', isHoliday: false, isWeeken: false},
            ]
        }
    }

    render = () => {
        return(
            <div className="container-fluid">
                <section className="content-header">
                    <div className="container-fluid">
                        <div className="row mb-2">
                            <div className="col-sm-6">
                                <h1 className="float-sm-left">Báo cáo giờ công</h1>
                            </div>
                            <div className="col-sm-6">
                                <ol className="breadcrumb float-sm-right">
                                    <li className="breadcrumb-item"><a href="#">Báo cáo nhân sự</a></li>
                                    <li className="breadcrumb-item active">Báo cáo giờ công</li>
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
                                    <div className="row">
                                        <div className="col-md-3">
                                            <div className="form-group m-0">
                                                <label className="m-0">Từ ngày</label>
                                                <DatePicker format="dd-MM-yyyy"
                                                    style={{width:'100%'}}
                                                    className="w-100"
                                                    defaultValue={new Date()}/>
                                            </div>
                                        </div>
                                        <div className="col-md-3">
                                            <div className="form-group m-0">
                                                <label className="m-0">Đến</label>
                                                <DatePicker format="dd-MM-yyyy"
                                                        className="w-100"
                                                        defaultValue={new Date()}/>
                                            </div>
                                        </div>
                                        <div className="col-sm-1">
                                            <button type="button" className="btn btn-success w-100 mt-1 mt-md-4">
                                                <span className="fa fa-search" />
                                            </button>
                                        </div>
                                    </div>
                                </div>
                                <div className="card-body">
                                    <Grid style={{ height: "550px" }}>
                                        <Column field="code" title="Mã" width="100px" locked={true}/>
                                        <Column field="employeeName" title="Nhân viên" width="250px" locked={true}/>
                                        {this.state.dateFields.map((field) => {
                                            return(
                                                <Column field={field.name} title={field.title} width="250px" />
                                            )
                                        })}
                                    </Grid>
                                    {this.state.loading === true ? <Loading></Loading> : null} 
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        )
    }
}