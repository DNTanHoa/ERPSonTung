import React, { Component } from 'react';
import * as ReactDOM from 'react-dom';
import { Grid, GridColumn as Column, GridToolbar } from '@progress/kendo-react-grid';
import { UsersLoader } from './user-loader';
import { UserCommand } from './user-command';
import { process } from '@progress/kendo-data-query';

export class Category extends Component {
    constructor(props){
        super(props);
        
        this.state  = {
            data: [],
        }
    }

    render() {
        return(
            <Grid>
                <Column field="ProductID" title="Id" editable={false} />
                <Column field="ProductName" title="Name" editor="text" />
                <Column field="FirstOrderedOn" title="First Ordered" editor="date" />
                <Column field="UnitsInStock" title="Units" width="150px" editor="numeric" />
                <Column field="Discontinued" title="Discontinued" editor="boolean" />
            </Grid>
        )
    }
   
}
