import config from '../../appsettings.json';
import axios from "axios";
import {getInit} from '../api-caller';
import React from 'react';
import { Loading} from '../../components/loading';

export const login = (loginRequest) => {
    axios
    .post(
        config.appSettings.ServerUrl + "user/login",
        {
            username: loginRequest.username,
            password: loginRequest.password,
            rememberPassword: loginRequest.rememberPassword
        }
    )
    .then(res => {
        var data = res.data;
        var result = data.result;
        if(result.resultType === 0) {
            var token = data.token;
            localStorage.setItem('token',token);
            return data.token;
        } else {
            return result.message
        }
    })
    .catch(err => {
        return err;
    });
}


export const getUsers = async () => {
    let url = config.appSettings.ServerUrl + 'user/get'

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

export const insertUser = (user) => {
    let url = config.appSettings.ServerUrl + 'user/create'

    let init = getInit('POST');

    fetch(url, init)
        .then(response =>
            response.json()
        )
        .then(json => {
            return json.data;
        });
}

export const updateUser = (user) => {
    let url = config.appSettings.ServerUrl + 'user/update'

    let init = getInit('PUT');

    fetch(url, init)
        .then(response =>
            response.json()
        )
        .then(json => {
            return json.data;
        })
}