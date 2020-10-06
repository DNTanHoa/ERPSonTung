import React, { Component } from 'react';

export class SideBar extends Component {

    render() {
        return (
           <aside className="main-sidebar sidebar-dark-primary elevation-4" style={{backgroundColor: 'black'}}>
                <a asp-action="Index" asp-controller="Dashboard" className="brand-link text-center" style={{fontSize: 25}}>
                    <span className="brand-text font-weight-light text-center text-white">QUẢN LÝ NHÂN SỰ</span>
                </a>
                <div className="sidebar">
                    <div className="user-panel mt-3 pb-3 mb-3 d-flex" id="SidebarInfor">
                    </div>
                    <nav className="mt-2">
                        <ul className="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false">
                            <li className="nav-item has-treeview menu-open">
                            <a className="nav-link active">
                                <i className="nav-icon fas fa-tachometer-alt" />
                                <p>
                                    Dashboard
                                <i className="right fas fa-angle-left" />
                                </p>
                            </a>
                            <ul className="nav nav-treeview">
                                <li className="nav-item">
                                <a className="nav-link active">
                                    <i className="far fa-circle nav-icon" />
                                    <p>Dashboard v1</p>
                                </a>
                                </li>
                                <li className="nav-item">
                                <a className="nav-link">
                                    <i className="far fa-circle nav-icon" />
                                    <p>Dashboard v2</p>
                                </a>
                                </li>
                                <li className="nav-item">
                                <a className="nav-link">
                                    <i className="far fa-circle nav-icon" />
                                    <p>Dashboard v3</p>
                                </a>
                                </li>
                            </ul>
                            </li>
                        </ul>
                    </nav>
                </div>
            </aside>
        );
    }
}
