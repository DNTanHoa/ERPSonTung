export const getInit = (method) => {

    let token = localStorage.getItem('token');

    if(token == undefined) {
        
    }

    let init = { 
        method: method,
        headers: new Headers({
            Accept: 'application/json, text/plain',
            'Content-Type': 'application/json;charset=UTF-8',
            Authorization: 'Bearer ' + localStorage.getItem('token'),
        })
    };
    return init;
}