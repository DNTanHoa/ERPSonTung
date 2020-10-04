import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Login } from './components/login/Login';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { library } from '@fortawesome/fontawesome-svg-core';
import { faEnvelope, faKey, faUser } from '@fortawesome/free-solid-svg-icons';
import './custom.css';

library.add(faEnvelope, faKey, faUser);

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Login></Login>
    );
  }
}
