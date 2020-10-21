import config from '../../appsettings.json';
import axios from "axios";
import {getInit} from '../api-caller';
import React from 'react';
import { Loading} from '../../components/loading';
import { JsxEmit } from 'typescript';

let data = [];

const generateId = data =>
    data.reduce((acc, current) => Math.max(acc, current.ProductID), 0) + 1;

const props = {};

export const insertCategory = item => {
    item.inEdit = false;
    data.unshift(item);
    return data;
};

export const getCategories = async () => {
    let url = config.appSettings.ServerUrl + 'category/getall'

    let init = getInit('GET');

    await fetch(url, init)
        .then(response =>
            response.json()
        )
        .then(json => {
            data = json.data;
            return data;
        });
    return data;
};

export const updateItem = (item) => {
    let index = data.findIndex(record => record.id === item.id);
    data[index] = item;
    return data;
};

export const deleteItem = item => {
    let index = data.findIndex(record => record.id === item.id);
    data.splice(index, 1);
    return data;
};


export const getCategoriesByEntity = async (entity)  => {
    let url = config.appSettings.ServerUrl + 'category/getbyentity';

    let init = getInit('POST');

    let body = { entity };

    init.body = JSON.stringify(body);

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
