import React, { Component } from 'react';
import axios from "axios";

export class Login extends Component {
    constructor(props) {
        super(props);

        this.state = {
            username: "",
            password: "",
            rememberPassword: false,
            loginErrors: ""
        };

        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChange = this.handleChange.bind(this);
    }

    handleSubmit(event) {
        const {
            username, 
            password, 
            rememberPassword
        } = this.state;

        axios
            .post(
                "url",
                {
                    username: username,
                    password: password,
                    rememberPassword: rememberPassword
                }
            )
            .then(res => {
                if(res.data.status === "success"){
                    console.log(res.data);
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
        return (
            <div>
                <form onSubmit={this.handleSubmit}>
                <input
                    type="email"
                    name="username"
                    placeholder="Email"
                    value={this.state.email}
                    onChange={this.handleChange}
                    required
                />

                <input
                    type="password"
                    name="password"
                    placeholder="Password"
                    value={this.state.password}
                    onChange={this.handleChange}
                    required
                />

                <button type="submit">Login</button>
                </form>
            </div>
        );
    }
}