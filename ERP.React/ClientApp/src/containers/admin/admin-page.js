import React, { Component, Fragment } from 'react';
import { Header } from '../../components/header/header';
import { SideBar } from '../../components/sidebar/sidebar';
import { Footer } from '../../components/footer/footer';
import { Employee } from '../../components/employee/employee';
import { Category } from '../../components/category/category';
import { BrowserRouter as Router, Route, Redirect, useHistory, useLocation, Switch } from "react-router-dom";
import DailyMonitor from '../../components/dashboard/daily-monitor';
import { User } from '../../components/user/user-list';

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
                    </Switch>
                </div>
                <Footer></Footer>
            </div>
    );
  }
}
