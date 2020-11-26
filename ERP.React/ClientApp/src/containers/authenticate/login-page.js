import React, { Component } from 'react';
import axios from "axios";
import style from './login-page.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Checkbox} from 'react-icheck';
import 'icheck/skins/all.css';
import config from '../../appsettings.json';
import {Redirect} from "react-router-dom";
import AppContext from '../../providers/context/app-context';


export class Login extends Component {
    static contextType = AppContext

    constructor(props) {
        super(props);

        this.state = {
            username: "",
            password: "",
            rememberPassword: true,
            errorMessage: "",
            redirect: false,
            token: '',
        };

        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChange = this.handleChange.bind(this);
    }
    
    handleSubmit(event) {
        const {
            username, 
            password
        } = this.state;
        axios
            .post(
                config.appSettings.ServerUrl + "user/login",
                {
                    username: username,
                    password: password,
                }
            )
            .then(res => {
                var result = res.data.result;
                if(result.resultType === 0) {
                    var token = res.data.data.token;
                    let userName = res.data.data.user.username;
                    let employeeName = res.data.data.user.name;
                    this.renderContext.logIn(token,userName,employeeName);
                    this.setState({redirect: true});
                } else {
                   this.setState({errorMessage : result.message});
                }
            })
            .catch(err => {
                console.log("Login has error", err);
            });
        event.preventDefault();
    }

    handleChange(event) {
        this.setState({
            [event.target.name]: event.target.value
        });
    }
    
    render() {
        if(this.state.redirect === true) {
            return(
                <Redirect push to='/hrm'/>
            )
        }
        return (
            <div className="hold-transition login-page loginPage">
                    <AppContext.Consumer>
                    {value => {this.renderContext = value;}}
                    </AppContext.Consumer>
                <div className="d-flex justify-content-center align-items-center login-page" style= {{minHeight: "100%"}} id="loginContent">
                <div className = "titleStyle">
                    <p className="text-white h4 text-center h4"><b>THÔNG TIN NHÂN SỰ</b></p>
                </div>
                    <div className="login-box">
                        <div className="card">
                            <div className="card-body login-card-body">
                                <div className="d-flex justify-content-center flex-row align-items-center">
                                    <img src="../images/sontung.png" style={{width:'20%'}} alt="son tung"/>
                                </div>
                                <div className="mt-2">
                                    <div className="text-danger text-center" id="loginResult">{this.state.errorMessage}</div>
                                    <form id="loginForm" onSubmit={this.handleSubmit}>
                                        <div className="input-group mb-2">
                                            <div className="input-group-append w-100">
                                                <input type="text"
                                                    name="username"
                                                    className="form-control"
                                                    placeholder="Tài khoản"
                                                    value={this.state.username}
                                                    onChange={this.handleChange}/>
                                                <div className="input-group-text">
                                                    <FontAwesomeIcon icon="user" size="xs" />
                                                </div>
                                            </div>
                                        </div>
                                        <div className="input-group mb-2">
                                            <div className="input-group-append w-100">
                                                <input name="password"
                                                    className="form-control"
                                                    placeholder="Mật khẩu"
                                                    type="password"
                                                    value={this.state.password}
                                                    onChange={this.handleChange}/>
                                                <div className="input-group-text">
                                                    <FontAwesomeIcon icon="key" size="xs" />
                                                </div>
                                            </div>
                                        </div>
                                        <div className="row">
                                            <div className="col-8">
                                            <Checkbox checkboxClass="icheckbox_square-blue"
                                                name = "rememberPassword"
                                                label = " Lưu mật khẩu"
                                                value = {this.state.rememberPassword}
                                                onChange = {this.handleChange}/>
                                            </div>
                                            <div className="col-4">
                                                <button className="btn btn-primary btn-block text-white" type="submit"><i className="fas fa-sign-in-alt"></i></button>
                                            </div>
                                        </div>
                                        <div className="social-auth-links text-center mb-3">
                                            <button id="loginEmailButton" className="btn btn-block btn-danger text-white">
                                                <i className="fab fa-google-plus mr-2"></i> Sử dụng email
                                            </button>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}


