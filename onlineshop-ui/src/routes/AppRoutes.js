import React, { useContext } from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import AutentifikacijaKontekst from "../context/AutentifikacijeContext.js";
import Register from "../components/Register/Register.js";
import Login from "../components/Login/Login.js";


const AppRoutees = () => {
    const autentifikacijaKontekst = useContext(AutentifikacijaKontekst);

    const ulogovan = autentifikacijaKontekst.isLoggedIn;
    const uloga = autentifikacijaKontekst.uloga;
    const verifikovan = autentifikacijaKontekst.verifikovan;
  
    return(
        <Routes>
            <Route
            path="/"
            element={ulogovan ? <Navigate to="/home" /> : <Login />}
          />
          <Route
            path="/register"
            element={ulogovan ? <Navigate to="/home" /> : <Register />}
          />
        </Routes>
    );
   
}

export default AppRoutees;
