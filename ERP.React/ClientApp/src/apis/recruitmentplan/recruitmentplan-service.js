import config from '../../appsettings.json';
import axios from "axios";
import { getInit } from '../api-caller';
import React from 'react';
import { Loading} from '../../components/loading';

export const getRecruitmentPlans = () => {
    let url = config.appSettings.ServerUrl + '/recruitmentplan/getall';

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

export const insertRecruitmentPlan = (dataItem) => {
    let url = config.appSettings.ServerUrl + '/recruitmentplan/create';

    let init = getInit('POST');

    init.body = JSON.stringify(dataItem);

    let result = {};

    
}