import * as React from 'react';
import * as ReactDOM from 'react-dom';

export class Loading extends React.Component {
    render() {
        const loadingPanel = (
            <div className="k-loading-mask">
                <span className="k-loading-text">Loading</span>
                <div className="k-loading-image"></div>
                <div className="k-loading-color"></div>
            </div>
        );
        const gridContent = document && document.querySelector('.k-grid-content');
        return gridContent ? ReactDOM.createPortal(loadingPanel, gridContent) : loadingPanel;
    }
}
