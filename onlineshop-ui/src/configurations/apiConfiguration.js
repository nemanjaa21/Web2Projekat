import axios from "axios";
import {Token} from "./tokenConfiguration";

const apiEndpoint = axios.create({
    baseURL : process.env.REACT_APP_API_URL,
    headers:{
        'Content-Type' : 'application/json',
    },
});

apiEndpoint.interceptors.request.use((config) => {
    try{
          const token = Token();
          if(token){
            return {...config, headers: {
                ...config.headers,
                Authorization:`Bearer ${token}`,
            }};
          }

        return config;
    }
    catch(e)
    {
        console.log(e);
        return Promise.reject(e);
    }
});

export default apiEndpoint;