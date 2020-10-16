import React, { Component } from 'react';
import { SidebarInfor } from '../user/sidebar-info'
import SideBarNavigation from './sidebar-navigation';

export class SideBar extends Component {

    render() {
        return (
           <aside className="main-sidebar sidebar-dark-primary elevation-4" style={{backgroundColor: 'black'}}>
                <a asp-action="Index" asp-controller="Dashboard" className="brand-link text-center" style={{fontSize: 25}}>
                    <span className="brand-text font-weight-light text-center text-white">QUẢN LÝ NHÂN SỰ</span>
                </a>
                <div className="sidebar">
                    <SidebarInfor></SidebarInfor>
                    <nav className="mt-2">
                        <ul className="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false">
                            <li className="nav-item has-treeview menu-open">
                                <a className="nav-link active">
                                    <i className="nav-icon fas fa-tachometer-alt" />
                                    <p>
                                        Bảng giám sát
                                        <i className="right fas fa-angle-left" />
                                    </p>
                                </a>
                                <ul className="nav nav-treeview">
                                    <SideBarNavigation displayName="Điểm danh ngày" 
                                        href = "employee"
                                        iconName="far fa-circle nav-icon"></SideBarNavigation>
                                    <SideBarNavigation displayName="Chấm công ngày"
                                        href = "user"
                                        isActive = "active"
                                        iconName="far fa-circle nav-icon"></SideBarNavigation>
                                    <SideBarNavigation displayName="Tăng ca ngày"
                                        href = "category"
                                        iconName="far fa-circle nav-icon"></SideBarNavigation>
                                </ul>
                            </li>
                        </ul>
                    </nav>
                </div>
            </aside>
        );
    }
}
