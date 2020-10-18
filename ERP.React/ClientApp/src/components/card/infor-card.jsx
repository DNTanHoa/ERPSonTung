import React, { Component, PureComponent } from 'react';
import { Link } from 'react-router-dom';

export class InforCard extends React.Component {

    constructor(props) {
        super(props);
    }

    render() {
        return(
            <div className="col-6 col-lg-3">
                <div className={this.props.boxType}>
                    <div className="inner">
                        <h3>{this.props.boxValue}</h3>
                        <p>{this.props.displayName}</p>
                    </div>
                    <div className="icon">
                        <i className={this.props.icon} />
                    </div>
                    <Link to={this.props.href} className="small-box-footer">{this.props.displayText} <i className="fas fa-arrow-circle-right" /></Link>
                </div>
            </div>
        )
    }
}