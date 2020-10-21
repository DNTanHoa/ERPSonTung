import { support } from 'jquery';
import React, { Component } from 'react';
import { SideBar } from './sidebar';
import { Link } from 'react-router-dom';

export default class SideBarNavigation extends React.Component {
    constructor(props) {
        super(props)
    }

    icon = this.props.iconName ? <i className={this.props.iconName}></i> : null
    href = this.props.href ? this.props.href : null;
    menuLinkClassName = this.props.isActive ? "nav-link active" : "nav-link"

    render = () =>  {
        if(this.props.hasChild) {
            return(
                <li className="nav-item has-treeview">
                    <a className={this.menuLinkClassName} key={this.props.code}>
                        {this.icon}
                        <p className="px-1">{this.props.displayName}</p>
                        <i className="right fas fa-angle-left" />
                    </a>
                    <ul className="nav nav-treeview">
                        {this.props.childs.map((child) => {
                            return(
                                <li className="nav-item" key={child.item.navigation.code}>
                                    <Link to={child.item.navigation.componentPath} className={this.menuLinkClassName}>
                                        <i className={child.item.navigation.icon}></i>
                                        <p className="px-1">{child.item.navigation.displayName}</p>
                                    </Link>
                                </li>
                            )
                        })}
                    </ul>
                </li>
            )
        }
        return(
            <li className="nav-item" key={this.props.code}>
                <Link to={this.props.href} className={this.menuLinkClassName}>
                    {this.icon}
                    <p className="px-1">{this.props.displayName}</p>
                </Link>
            </li>
        )
    }
}