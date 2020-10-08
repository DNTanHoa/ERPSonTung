import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { Loading} from '../loading'
import { toODataString } from '@progress/kendo-data-query';
import config from '../../appsettings.json';
import axios from 'axios';


export class UsersLoader extends React.Component {

    baseUrl = config.appSettings.ServerUrl + 'user/get';
    
    token = 'Bearer ' + localStorage.getItem('token');
    
    init = { 
        method: 'GET',
        credentials: 'include',
        mode: 'cors',
        headers: new Headers({
            Authorization: this.token,
            Origin: 'http://api.toilamkythuat.com'
        })
    };
    lastSuccess = '';
    pending = '';

    requestDataIfNeeded = () => {
        if (this.pending || toODataString(this.props.dataState) === this.lastSuccess) {
            return;
        }
        this.pending = toODataString(this.props.dataState);
        
        axios.get(this.baseUrl, {
            baseUrl: config.appSettings.ServerUrl,
            headers: {
                'Authorization': this.token,
            }
        })
        .then(res => {
            console.log(res);
        })
        .catch(err => {
            console.log("Login has error", err);
        });
    }

    render() {
        this.requestDataIfNeeded();
        return this.pending && <Loading />;
    }
}