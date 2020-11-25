import axios from 'axios';
import config from '../../appsettings.json';
import {
    getInit
} from '../api-caller.js';

export const getEmployeesHasFillter = async (filter) => {
    let url = config.appSettings.ServerUrl + 'employee/getdatatransferhasfilter'

    let init = getInit('GET');

    let data = [];

    await fetch(url, init)
        .then(response =>
            response.json()
        )
        .then(json => {
            data = json.data;
            return data;
        });
    return data;
}

export const getModelTemplates = async () => {
    let url = config.appSettings.ServerUrl + 'employee/GetModelTemplates'

    let init = getInit('GET');

    let data = [];

    await fetch(url, init)
        .then(response =>
            response.json()
        )
        .then(json => {
            data = json.data;
            return data;
        });
    return data;
}

export const getById = async (id) => {
    let url = config.appSettings.ServerUrl + 'employee/Detail?Id=' + id

    let init = getInit('GET');

    let data = {};

    await fetch(url, init)
        .then(response =>
            response.json()
        )
        .then(json => {
            data = json.data;
            return data;
        });
    return data;
}

export const saveEmployeeDetail = async (formData) => {
    let token = localStorage.getItem('token');
    let url = config.appSettings.ServerUrl + 'employee/SaveChange';

    await axios({
            method: 'post',
            url: url,
            data: formData,
            headers: {
                'Content-Type': 'multipart/form-data',
                'Authorization': 'Bearer ' + token
            }
        })
        .then(function (response) {
            console.log(response);
        })
        .catch(function (error) {
            console.log(error);
        });
}