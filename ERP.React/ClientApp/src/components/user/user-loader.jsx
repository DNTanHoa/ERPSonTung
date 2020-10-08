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
        fetch(this.baseUrl, this.init)
            .then(response =>
                response.json()
            )
            .then(json => {
                this.props.onDataRecieved.call(undefined, {
                    data: json.data,
                });
            });
    }

    render() {
        this.requestDataIfNeeded();
        return this.pending && <Loading />;
    }
}