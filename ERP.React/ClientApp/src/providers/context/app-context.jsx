import React, { Component} from 'react';

export const UserConxtext = React.createContext();

export class UserProvider extends Component {
    
    constructor(props) {
        super(props);
        
        this.state = {
            users : [],
        }
            
        this.add  = this.add.bind(this);
    }

    add = (user) => {
        this.setState({
            users: this.state.users.concat(user),
        })
    }

    render = () => {
        return(
            <UserConxtext.Provider value={{
                users: this.state.users,
                add: this.add
            }}>
                {this.props.children}
            </UserConxtext.Provider>
        )
    }

}