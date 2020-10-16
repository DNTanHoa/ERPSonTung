import * as React from 'react';
import * as ReactDOM from 'react-dom';
import PropTypes from 'prop-types'

export class SidebarInfor extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            greeting: "Chúc ngủ ngon "
        }
    }

    username = localStorage.getItem('userName');

    componentDidMount = () => {
        let hour = new Date().getHours();

        if(hour < 11) {
            this.setState({
                greeting : "Chào buổi sáng "
            })
        } else if (hour < 15) {
            this.setState({
                greeting : "Buồi trưa vui vẻ "
            })
        } else if (hour < 19) {
            this.setState({
                greeting : "Buồi chiều an lành "
            })
        }
    }

    render() {
        return (
            <div className="user-panel mt-3 pb-3 mb-3 d-flex" id="SidebarInfor">
                <div className="image">
                    <img src="/images/sontung.png" className="img-circle elevation-2" alt="" />
                </div>
                <div className="info px-1">
                    <a className="d-block text-center" id="UsernameSideBar">{this.state.greeting} {this.username}</a>
                </div>
            </div>
        )
    }
}




