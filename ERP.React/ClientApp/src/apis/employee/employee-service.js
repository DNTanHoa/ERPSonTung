import axios from "axios";
import config from "../../appsettings.json";
import { getInit } from "../api-caller.js";
import queryString from "query-string";

class EmployeeService {
  saveEmployeeDetail = async (formData) => {
    let token = localStorage.getItem("token");
    let url = config.appSettings.ServerUrl + "employee/SaveChange";

    return await axios({
      method: "post",
      url: url,
      data: formData,
      headers: {
        "Content-Type": "multipart/form-data",
        Authorization: "Bearer " + token,
      },
    });
  };

  getById = async (id) => {
    let url = config.appSettings.ServerUrl + "employee/Detail?Id=" + id;

    let init = getInit("GET");

    let data = {};

    await fetch(url, init)
      .then((response) => response.json())
      .then((json) => {
        data = json.data;
        return data;
      });
    return data;
  };

  getModelTemplates = async () => {
    let url = config.appSettings.ServerUrl + "employee/GetModelTemplates";

    let init = getInit("GET");

    let data = [];

    await fetch(url, init)
      .then((response) => response.json())
      .then((json) => {
        data = json.data;
        return data;
      });
    return data;
  };

  getEmployeesHasFillter = async (filter) => {
    let url =
      config.appSettings.ServerUrl + "employee/getdatatransferhasfilter";

    let token = localStorage.getItem("token");

    return await axios({
      method: "get",
      url: url,
      params:filter,
      headers: {
        Authorization: "Bearer " + token,
        "Content-Type": "application/json",
      },
    })
      .then((response) => {
        return response.data.data;
      })
      .catch((error) => {
        console.log(error);
        return [];
      });
  };

}

export default new EmployeeService();
