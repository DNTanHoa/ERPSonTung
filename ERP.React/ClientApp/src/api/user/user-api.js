import config from '../../appsettings.json';
import axios from "axios";

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