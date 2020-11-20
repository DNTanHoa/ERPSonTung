import config from '../../appsettings.json';
import { getInit } from '../api-caller';

export const getRecruitmentPlans = async () => {
    let url = config.appSettings.ServerUrl + 'recruitmentplan/getall';

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

export const insertRecruitmentPlan = async (dataItem) => {
    let url = config.appSettings.ServerUrl + 'recruitmentplan/create';

    let init = getInit('POST');

    init.body = JSON.stringify(dataItem);

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

export const updateRecruitmentPlan = async (dataItem) => {
    let url = config.appSettings.ServerUrl + 'recruitmentplan/update';

    let init = getInit('POST');

    init.body = JSON.stringify(dataItem);

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

export const deleteRecruitmentPlan = async (dataItem) => {
    let url = config.appSettings.ServerUrl + 'recruitmentplan/update';

    let init = getInit('DELETE');

    let params = {
        id: dataItem.id
    }

    Object.keys(params).forEach(key => url.searchParams.append(key, params[key]));

    let result = {};

    await fetch(url, init)
        .then(response =>
            response.json()
        )
        .then(json => {
            result = json.data;
            return result;
        });
    return result;

}