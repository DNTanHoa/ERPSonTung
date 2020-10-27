import * as React from 'react';
import { DatePicker } from '@progress/kendo-react-dateinputs';
import { dateFormat } from 'date-format-helper'

export class CustomDatePicker extends React.Component {
    constructor(props){
        super(props);
    }

    render() {
        const { dataItem, field } = this.props;
        const dataValue = dataItem[field] === null ? '' : dataItem[field];
        const format =  this.props.format != null ? this.props.format.toUpperCase() : 'DD-MM-YYYY';

        return (
            <td>
                {dataItem.inEdit ? (
                    <DatePicker format="dd-MM-yyyy"
                        navigation={false}
                        defaultValue={new Date()}/>
                ) : (
                    dateFormat({t: dataValue, format: format})
                )}
            </td>
        )
    }
}