import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import { Autentifikacija } from "./context/AutentifikacijeContext";
import { BrowserRouter } from "react-router-dom";
import { createRoot } from 'react-dom/client';


createRoot(document.getElementById('root')).render(
  <BrowserRouter>
    <Autentifikacija>
      <App />
    </Autentifikacija>
  </BrowserRouter>
);

