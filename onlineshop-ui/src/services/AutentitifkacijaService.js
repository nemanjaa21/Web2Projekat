import apiEndpoint from '../configurations/apiConfiguration';


export const login = async (loginData) => {
    return await apiEndpoint.post(`/Autentifikacija`,loginData)
};