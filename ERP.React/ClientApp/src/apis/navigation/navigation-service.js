import config from '../../appsettings.json';
import axios from "axios";
import { getInit } from '../api-caller';
import React from 'react';
import { Loading} from '../../components/loading';

export const getNavigations = async (entity)  => {
    let url = config.appSettings.ServerUrl + 'navigation/get';

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

export const insertNavigation = async (navigation) => {
    let url = config.appSettings.ServerUrl + 'navigation/create';

    let init = getInit('POST');

    init.body = JSON.stringify(navigation);

    navigation.inEdit = false;

    let result = {};

    await fetch(url, init)
        .then(response =>
            response.json()
        )
        .then(json => {
            result = json;
            return result;
        });
    return result;
}

export const updateNavigation = async (navigation) => {
    let url = config.appSettings.ServerUrl + 'navigation/update';

    let init = getInit('PUT');

    init.body = JSON.stringify(navigation);

    navigation.inEdit = false;

    let result = {};

    await fetch(url, init)
        .then(response =>
            response.json()
        )
        .then(json => {
            result = json;
            return result;
        });
    return result;
}