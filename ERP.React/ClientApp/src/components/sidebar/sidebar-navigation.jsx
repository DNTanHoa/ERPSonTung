import React from 'react';
import { Link } from 'react-router-dom';

export default class SideBarNavigation extends React.Component {

    constructor(props) {
        
        this.addActiveClass= this.addActiveClass.bind(this);
        super(props)

    }

    state = {
        parentMenuActive: '',
        childMenuActive: ''
    }

    icon = this.props.iconName ? <i className={this.props.iconName}></i> : null
    href = this.props.href ? this.props.href : null;

    handleParentClick(code){
        this.setState({
            parentMenuActive: code
        });
    }

    handleChildClick = (code) => {
        this.setState({
            childMenuActive: code
        });
    }

    render = () => {

        const { childMenuActive } = this.state;
        const { parentMenuActive } = this.state;

        if (this.props.hasChild) {
            return (
                <li className="nav-item has-treeview">
                    <a className={parentMenuActive == this.props.code ? 'nav-link active' : 'nav-link'} key={this.props.code} onClick={this.handleParentClick.bind(this, this.props.code)}>
                        {this.icon}
                        <p className="px-1">{this.props.displayName}</p>
                        <i className="right fas fa-angle-left" />
                    </a>
                    <ul className="nav nav-treeview">
                        {this.props.childs.map((child) => {
                            return (
                                <li className="nav-item" key={child.item.navigation.code}>
                                    <Link to={child.item.navigation.componentPath} className={childMenuActive == child.item.navigation.code ? 'nav-link active' : 'nav-link'} onClick={() => this.handleChildClick(child.item.navigation.code)}>
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
        return (
            <li className="nav-item" key={this.props.code}>
                <Link to={this.props.href} className={this.menuLinkClassName}>
                    {this.icon}
                    <p className="px-1">{this.props.displayName}</p>
                </Link>
            </li>
        )
    }
}