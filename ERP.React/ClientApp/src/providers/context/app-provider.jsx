import React from 'react'
import { login } from '../../apis/user/user-service'
import AppContext from '../context/app-context'

export class AppProvider extends React.Component {
    constructor(props){
        super(props)

        let hasLogin = false;

        let token = localStorage.getItem('token');
        if(token != undefined && token != '') {
            hasLogin = true;
        }

        this.state = {
            hasLogin: hasLogin,
            username: "",
            employeeName: ""
        }

        
        this.logIn = this.logIn.bind(this);
        this.logOut = this.logOut.bind(this);
    }

    user = {
        userName: localStorage.getItem('userName'),
        employeeName: localStorage.getItem('employeeName'),
    }

    logIn = (token, userName, employeeName) => {
        if(token != undefined && token != '') {
            localStorage.setItem('token', token);
            localStorage.setItem('userName',userName);
            localStorage.setItem('employeeName', employeeName);
            this.setState({hasLogin: true, userName, employeeName});
        }
    }

    logOut = () => {
        localStorage.clear();
        this.setState({hasLogin: false});
    }

    render = () => {
        return(
            <AppContext.Provider value={{ 
                hasLogin: this.state.hasLogin,
                user: this.user,
                logIn: this.logIn,
                logOut: this.logOut
            }}>
                {this.props.children}
            </AppContext.Provider>
        )
    }
}