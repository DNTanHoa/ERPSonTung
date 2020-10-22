import config from '../../appsettings.json';
import axios from "axios";
import {getInit} from '../api-caller';
import React from 'react';
import { Loading} from '../../components/loading';
import { JsxEmit } from 'typescript';
import { dateFormat } from 'date-format-helper'

export const getDashboardOverview = async(fromDate, toDate) => {
    let url =  new URL(config.appSettings.ServerUrl + 'statistic/dashboardoverview');

    let init = getInit('GET');

    let params = {
        fromDate: dateFormat({t: fromDate, format: 'YYYY-MM-DD hh:mm'}),
        toDate: dateFormat({t: toDate, format: 'YYYY-MM-DD hh:mm'}),
    }

    let data = [];

    Object.keys(params).forEach(key => url.searchParams.append(key, params[key]));

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