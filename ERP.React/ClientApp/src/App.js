import React, { Component } from 'react';
import { library } from '@fortawesome/fontawesome-svg-core';
import { faEnvelope, faKey, faUser } from '@fortawesome/free-solid-svg-icons';
import '@progress/kendo-theme-bootstrap/dist/all.css';
import './custom.css';
import { Login } from './containers/authenticate/login-page';
import { Layout } from './containers/admin/admin-page';
import { BrowserRouter as Router, Route, Redirect, useHistory, useLocation, Switch } from "react-router-dom";

library.add(faEnvelope, faKey, faUser);

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Router>
        <Switch>
          <Route exact path='/' component={Login}></Route>
          <Route path='/hrm' component={Layout}></Route>
        </Switch>
      </Router>
    );
  }
}
