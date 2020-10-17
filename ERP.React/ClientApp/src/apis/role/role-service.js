import { getInit } from '../api-caller';
import config from '../../appsettings.json'

let data = [];

export const getItems = async () => {
    let url = config.appSettings.ServerUrl + 'Role/GetUserNavigationRole'

    let init = getInit('GET');

    await fetch(url, init)
        .then(response =>
            response.json()
        )
        .then(json => {
            data = json.data;
        });
    return data;
};