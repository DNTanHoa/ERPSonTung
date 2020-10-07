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
        
        fetch(this.baseUrl, this.init)
            .then(response =>
                response.json()
            )
            .then(json => {
                console.log(json);
                this.lastSuccess = this.pending;
                this.pending = '';
                if (toODataString(this.props.dataState) === this.lastSuccess) {
                    this.props.onDataRecieved.call(undefined, {
                        data: json.data,
                        total: json['@odata.count']
                    });
                } else {
                    this.requestDataIfNeeded();
                }
            });
    }

    render() {
        this.requestDataIfNeeded();
        return this.pending && <Loading />;
    }
}