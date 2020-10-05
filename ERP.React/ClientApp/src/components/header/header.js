import React, { Component } from 'react';

export class Header extends Component {

    render() {
        return (
            <nav className="main-header navbar navbar-expand navbar-white navbar-light">
                <ul className="navbar-nav">
                    <li className="nav-item">
                    <a className="nav-link" data-widget="pushmenu" href="#" role="button"><i className="fas fa-bars" /></a>
                    </li>
                    <li className="nav-item dropdown">
                    <a className="nav-link dropdown-toggle" style={{fontSize: 16}} href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        Hướng dẫn
                    </a>
                    <div className="dropdown-menu" aria-labelledby="navbarDropdown">
                        <a className="dropdown-item" href="#">Thông tin nhân viên</a>
                        <a className="dropdown-item" href="#">Chấm công</a>
                        <a className="dropdown-item" href="#">Tuyển dụng</a>
                        <a className="dropdown-item" href="#">Thông tin chung</a>
                    </div>
                    </li>
                </ul>
                <ul className="navbar-nav ml-auto">
                    <li className="nav-item dropdown user-menu" id="HeaderInfor"></li>
                </ul>
            </nav>
        );
    }
}
