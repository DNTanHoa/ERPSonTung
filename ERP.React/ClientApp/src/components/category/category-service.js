import config from '../../appsettings.json';
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { Loading} from '../loading'

let data = [];

const generateId = data =>
    data.reduce((acc, current) => Math.max(acc, current.ProductID), 0) + 1;

const props = {};

export const insertItem = item => {
    item.ProductID = generateId(data);
    item.inEdit = false;
    data.unshift(item);
    return data;
};

export const getItems = () => {
    let url = config.appSettings.ServerUrl + 'category/getall'

    let init = { 
        method: 'GET',
        headers: new Headers({
            Accept: 'application/json, text/plain',
            'Content-Type': 'application/json;charset=UTF-8',
            Authorization: 'Bearer ' + localStorage.getItem('token'),
        })
    };

    var respone =  fetch(url, init)
        .then(response =>
            response.json()
        )
        .then(json => {
            data = json.data;
            return data;
        });
    return data;
};

export const updateItem = item => {
    let index = data.findIndex(record => record.id === item.id);
    data[index] = item;
    return data;
};

export const deleteItem = item => {
    let index = data.findIndex(record => record.id === item.id);
    data.splice(index, 1);
    return data;
};
