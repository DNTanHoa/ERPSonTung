import React, { Component } from 'react';

export class Footer extends Component {

    render() {
        return (
            <div>
                <aside className="control-sidebar control-sidebar-dark"></aside>
                <footer className="main-footer">
                    <div className="row">
                    <strong className="col-sm-6">© 2020 <a className="text-primary" href="http://sontungjeans.com/">Công ty TNHH Sơn Tùng.</a></strong>
                    <strong className="col-sm-6 text-sm-left text-md-right hiden-xs">Thiết kế Dương Nguyễn Tấn Hòa</strong>
                    </div>
                </footer>
            </div>
        );
    }
}