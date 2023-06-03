import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { login } from "../services/AutentitifkacijaService"
import jwtDecode from 'jwt-decode';

const AutentifikacijaKontekst = React.createContext({
    user: null,
    isLoggedIn: false,
    onLogin: (loginData) => {},
    onLogout: () => {},
});

const decodeToken = (token) => {
    console.log('token', token);
    try {
        const t = jwtDecode(token);
        return t;
    } catch (e) {
        console.log('Error. Token nije desifrovan.', e);
        return null;
    }
};

export const Autentifikacija = (props) => {
    const [token, setToken] = useState('');
    const [uloga, setUloga] = useState('');
    const [verifikovan, setVerifikacija] = useState('');
    const [isLoggedIn, setIsLoggedIn] = useState(false);

    const navigate = useNavigate();

    useEffect(() => {

        const ulogovan = sessionStorage.getItem('isLoggedIn');
        const trenutniToken = sessionStorage.getItem('token');
        const trenutnaUloga = sessionStorage.getItem('uloga');
        const trenutniStatusVerifikacije = sessionStorage.getItem('verifikovan');

        if (ulogovan === '1') {
            setIsLoggedIn(true);
            setVerifikacija(trenutniStatusVerifikacije);
            setToken(trenutniToken);
            setUloga(trenutnaUloga);

        }

    }, []);


    const loginHandler = async (loginData) => {
        try {
            const response = await login(loginData);
            const decodedToken = decodeToken(response.data);
            console.log('decoded token: ', decodeToken);
            let verification = decodedToken.Verification;
            let role = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];

            setIsLoggedIn(true);
            sessionStorage.setItem('isLoggedIn', '1');
            sessionStorage.setItem('token', response);
            sessionStorage.setItem('verifikovan', verification);
            sessionStorage.setItem('uloga', role);
            navigate("/home");

        } catch (error) {
            console.log(error.message);
        }
    };

    const logOutHandler = async() => {
        setIsLoggedIn(false);
        sessionStorage.removeItem('isLoggedIn');
        sessionStorage.removeItem('token');    
        sessionStorage.removeItem('verifikovan');
        sessionStorage.removeItem('uloga');    
        navigate("/login");       
    };

    return (
        <AutentifikacijaKontekst.Provider
        value={{
            isLoggedIn: isLoggedIn,
            token: token,
            verifikovan: verifikovan,
            uloga: uloga,
            onLogout: logOutHandler,
            onLogin: loginHandler
        }}>
            {props.children}       
        </AutentifikacijaKontekst.Provider>
    );

};

export default AutentifikacijaKontekst;