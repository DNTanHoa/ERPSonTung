import config from '../../appsettings.json';
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { getInit } from '../api-caller.js';

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