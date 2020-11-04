import React, { Component } from 'react';
import { Header } from '../../components/header/header';
import { SideBar } from '../../components/sidebar/sidebar';
import { Footer } from '../../components/footer/footer';
import { Employee } from '../../components/employee/employee-list';
import { Category } from '../../components/category/category';
import { Route, Redirect, Switch } from "react-router-dom";
import DailyMonitor from '../../components/dashboard/daily-monitor';
import { User } from '../../components/user/user-list';
import { Navigation } from '../../components/navigation/navigation-list';
import { CategoryDistinct } from '../../components/category/category-distinct';
import TimeKeeping from '../../components/report/time-keeping';
import EmployeeDetail from '../../components/employee/employee-detail';
import { CheckInOutDevice } from '../../components/check-in-out-device/check-int-out-device';
import { DailyTimeKeeping } from '../../components/dashboard/daily-timekeeping';
import { RecruitmentPlan } from '../../components/recuirtmentplan/recruitmentplan';
import AppContext from '../../providers/context/app-context';

export class Layout extends Component {

  constructor(props) {
    super(props)
  }

  render = () => {
    return (
      <div className="wrapper">
            <AppContext.Consumer>
              {({ hasLogin }) => hasLogin === true ? null : <Redirect to="/"></Redirect>}
            </AppContext.Consumer>
        <Header></Header>
        <SideBar></SideBar>
        <div className="content-wrapper">
            <Switch>
              <Route exact path='/hrm/employee' component={Employee}></Route>
              <Route path='/hrm/category' component={Category}></Route>
              <Route path='/hrm/user' component={User}></Route>
              <Route path='/hrm/dashboard' component={DailyMonitor}></Route>
              <Route path='/hrm/navigation' component={Navigation}></Route>
              <Route exact path='/hrm' component={DailyMonitor}></Route>
              <Route path='/hrm/department' render={(props) => <CategoryDistinct {...props} categoryName='bộ phận' entity='Department'/>}></Route>
              <Route path='/hrm/group' render={(props) => <CategoryDistinct {...props} categoryName='tổ nhóm' entity='Group'/>}></Route>
              <Route path='/hrm/laborgroup' render={(props) => <CategoryDistinct {...props} categoryName='nhóm lao động' entity='LaborGroup'/>}></Route>
              <Route path='/hrm/job' render={(props) => <CategoryDistinct {...props} categoryName='vị trí công việc' entity='Job'/>}></Route>
              <Route path='/hrm/bank' render={(props) => <CategoryDistinct {...props} categoryName='ngân hàng' entity='Bank'/>}></Route>
              <Route path='/hrm/school' render={(props) => <CategoryDistinct {...props} categoryName='trường học' entity='School'/>}></Route>
              <Route path='/hrm/province' render={(props) => <CategoryDistinct {...props} categoryName='Tỉnh' entity='Province'/>}></Route>
              <Route path='/hrm/district' render={(props) => <CategoryDistinct {...props} categoryName='Huyện' entity='District'/>}></Route>
              <Route path='/hrm/ward' render={(props) => <CategoryDistinct {...props} categoryName='Xã' entity='Ward'/>}></Route>
              <Route path='/hrm/timekeeping' component={TimeKeeping}></Route>
              <Route path='/hrm/dailytimekeeping' component={DailyTimeKeeping}></Route>
              <Route path='/hrm/checkinoutdevice' component={CheckInOutDevice}></Route>
              <Route exact path='/hrm/employee/detail' component={EmployeeDetail}></Route>
              <Route path='/hrm/recruitmentplan' component={RecruitmentPlan}></Route>
            </Switch>
        </div>
        <Footer></Footer>
      </div>
    );
  }
}
