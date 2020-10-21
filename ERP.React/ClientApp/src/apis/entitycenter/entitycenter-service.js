import config from '../../appsettings.json';
import axios from "axios";
import {getInit} from '../api-caller';
import React from 'react';
import { Loading} from '../../components/loading';

export const getEntities = async () => {
    let url = config.appSettings.ServerUrl + 'entitycenter/get';

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

