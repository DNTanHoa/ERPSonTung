import { support } from 'jquery';
import React, { Component } from 'react';
import { SideBar } from './sidebar';
import { Link } from 'react-router-dom';

export default class SideBarNavigation extends React.Component {
    constructor(props) {
        super(props)
    }

    icon = this.props.iconName ? <i className={this.props.iconName}></i> : null

    menuLinkClassName = this.props.isActive ? "nav-link active" : "nav-link";

    render = () =>  {
        if(this.props.hasChild) {
            return(
                <li className="nav-item has-treeview">
                    <Link to={this.props.href} className={this.menuLinkClassName}>
                        {this.icon}
                        <p>{this.props.displayName}</p>
                    </Link>
                    <ul className="nav nav-treeview">
                        
                    </ul>
                </li>
            )
        }
        return(
            <li className="nav-item">
                <Link to={this.props.href} className={this.menuLinkClassName}>
                    {this.icon}
                    <p>{this.props.displayName}</p>
                </Link>
            </li>
        )
    }
}