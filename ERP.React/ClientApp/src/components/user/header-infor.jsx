import * as React from 'react';
import * as ReactDOM from 'react-dom';
import PropTypes from 'prop-types'
import AppContext from '../../providers/context/app-context';

export class HeaderInfor extends React.Component {

    constructor(props) {
        super(props);
    }

    username = localStorage.getItem('userName');

    componentDidMount = () => {
        let hour = new Date().getHours();
    }

    render() {
        return (
            <li className="nav-item dropdown user-menu" id="HeaderInfor">
                <a href="#" className="nav-link dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                        <img src="/images/avatar.png" className="user-image img-circle elevation-2" alt="@Model.Name" />
                        <span className="d-none d-md-inline" id="UsernameHeader">Tài khoản - Tên Nhân Viên</span>
                    </a>
                    <ul className="dropdown-menu dropdown-menu-lg dropdown-menu-right" style={{left: 'inherit', right: 0}}>
                        <li className="user-header bg-primary d-flex flex-column justify-content-center align-items-center">
                            <img src="/images/avatar.png" className="img-circle elevation-2" alt="@Model.Username - @Model.Name" />
                            <p>
                                <span id="Username">Tài khoản - Tên Nhân Viên</span>
                            </p>
                        </li>
                        <li className="user-body">
                            <div className="row">
                                <div className="text-center col-12">
                                    Công ty TNHH Sơn Tùng
                                </div>
                            </div>
                        </li>
                        <li className="user-footer">
                            <a className="btn btn-success btn-flat text-white">Đổi Mật Khẩu</a>
                            <AppContext.Consumer>
                                {({logOut}) => <button className="btn btn-warning btn-flat text-white float-right" onClick={() => logOut()}>Thoát</button>}
                            </AppContext.Consumer>
                        </li>
                    </ul>
            </li>
        )
    }
}




