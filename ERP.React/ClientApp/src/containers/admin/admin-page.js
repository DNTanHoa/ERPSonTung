import React, { Component, Fragment } from 'react';
import { Header } from '../../components/header/header';
import { SideBar } from '../../components/sidebar/sidebar';
import { Footer } from '../../components/footer/footer';
import { Employee } from '../../components/employee/employee-list';
import { Category } from '../../components/category/category';
import { BrowserRouter as Router, Route, Redirect, useHistory, useLocation, Switch } from "react-router-dom";
import DailyMonitor from '../../components/dashboard/daily-monitor';
import { User } from '../../components/user/user-list';
import { Navigation } from '../../components/navigation/navigation-list';
import { CategoryDistinct } from '../../components/category/category-distinct';
import TimeKeeping from '../../components/report/time-keeping';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div className="wrapper">
          <Header></Header>
          <SideBar></SideBar>
          <div className="content-wrapper">
              <Switch>
                  <Route path='/hrm/employee' component={Employee}></Route>
                  <Route path='/hrm/category' component={Category}></Route>
                  <Route path='/hrm/user' component={User}></Route>
                  <Route path='/hrm/dashboard' component={DailyMonitor}></Route>
                  <Route path='/hrm/navigation' component={Navigation}></Route>
                  <Route exact path='/hrm' component={DailyMonitor}></Route>
                  <Route exact path='/hrm/department' render={(props) => <CategoryDistinct {...props} categoryName='bộ phận' entity='Department'/>}></Route>
                  <Route exact path='/hrm/group' render={(props) => <CategoryDistinct {...props} categoryName='tổ nhóm' entity='Group'/>}></Route>
                  <Route exact path='/hrm/laborgroup' render={(props) => <CategoryDistinct {...props} categoryName='nhóm lao động' entity='LaborGroup'/>}></Route>
                  <Route exact path='/hrm/job' render={(props) => <CategoryDistinct {...props} categoryName='vị trí công việc' entity='Job'/>}></Route>
                  <Route exact path='/hrm/bank' render={(props) => <CategoryDistinct {...props} categoryName='ngân hàng' entity='Bank'/>}></Route>
                  <Route exact path='/hrm/school' render={(props) => <CategoryDistinct {...props} categoryName='trường học' entity='School'/>}></Route>
                  <Route exact path='/hrm/province' render={(props) => <CategoryDistinct {...props} categoryName='Tỉnh' entity='Province'/>}></Route>
                  <Route exact path='/hrm/district' render={(props) => <CategoryDistinct {...props} categoryName='Huyện' entity='District'/>}></Route>
                  <Route exact path='/hrm/ward' render={(props) => <CategoryDistinct {...props} categoryName='Xã' entity='Ward'/>}></Route>
                  <Route exact path='/hrm/timekeeping' component={TimeKeeping}></Route>
              </Switch>
          </div>
          <Footer></Footer>
      </div>
    );
  }
}
