import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import AppContext from './providers/context/app-context';
import { AppProvider } from './providers/context/app-provider';
import registerServiceWorker from './registerServiceWorker';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

ReactDOM.render(
  <AppProvider>
    <App/>
  </AppProvider>,
  rootElement);

registerServiceWorker();

