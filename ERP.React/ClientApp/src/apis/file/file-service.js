import config from '../../appsettings.json';
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { getInitToPostFormData } from '../api-caller.js';
import { post } from 'axios';

export const employeeCheckFileImport = async (file) => {
    let url = config.appSettings.ServerUrl + 'fileimport/checkfileemployees'

    let form = new FormData();
    form.append('file', file);

    let data = [];
    
    const init = {
      headers: {
        'content-type': 'multipart/form-data',
        Authorization: 'Bearer ' + localStorage.getItem('token'),
      },
    };
    await post(url, form, init)
    .then(res => {
        let result = res.data.result;
        if(result.resultType == 0) {
            data = res.data.data;
            return data;
        }
    })
    .catch(err => {
        console.log("Import dữ liệu thất bại lỗi: " + err);
    });

    return data;
}
