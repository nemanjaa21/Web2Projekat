import apiEndpoint from '../configurations/apiConfiguration';


export const GetUser = async (token) =>{

    return await apiEndpoint.get(`/Korisnik/getUser`)

};

