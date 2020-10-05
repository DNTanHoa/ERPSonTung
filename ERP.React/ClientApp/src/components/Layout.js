import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { Route } from 'react-router';
import { NavMenu } from './NavMenu';
import { Header } from './header/header';
import { SideBar } from './sidebar/sidebar';
import { Footer } from './footer/footer';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div className="wrapper">
        <Header></Header>
        <SideBar></SideBar>
        <div className="content-wrapper">
          <div className="container-fluid" id="AppContent">
          </div>
        </div>
        <Footer></Footer>
      </div>
    );
  }
}
