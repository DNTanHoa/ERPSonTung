import React, { Component } from 'react';
import { SidebarInfor } from '../user/sidebar-info'
import SideBarNavigation from './sidebar-navigation';
import { getItems } from '../../apis/role/role-service';
import { loadTree } from '../../utils/sidebar-helper';


let roles = [];

export class SideBar extends Component {
    constructor(props) {
        super(props);
        
        this.state = {
            roles: []
        }
    }

    componentDidMount = async () => {
        roles = await getItems();
        this.setState({roles:roles});
        loadTree();
    }


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
                            {this.state.roles.map((role) => {
                                if(role.childrens.length > 0) {
                                    return(
                                        <SideBarNavigation displayName={role.item.navigation.displayName} 
                                            href={role.item.navigation.componentPath != null ? role.item.navigation.componentPath : null}
                                            hasChild={true}
                                            key={role.item.navigation.code}
                                            code={role.item.navigation.code}
                                            childs={role.childrens}
                                            iconName={role.item.navigation.icon}></SideBarNavigation>
                                    )
                                }
                                return(
                                    <SideBarNavigation displayName={role.item.navigation.displayName}
                                        key={role.item.navigation.code}
                                        code={role.item.navigation.code}
                                        href={role.item.navigation.componentPath != null ? role.item.navigation.componentPath : null}
                                        iconName={role.item.navigation.icon}></SideBarNavigation>
                                )
                            })}
                        </ul>
                    </nav>
                </div>
            </aside>
        );
    }
}
