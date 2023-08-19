import api from "../helpers/ConfigHelper";

export const login = async (logInData) => {
  return await api.post(`/Autentifikacija`, logInData);
};

export const googleLogin = async (logInData) => {
  return await api.post(`/Autentifikacija/google-login`, logInData, {headers: {"Content-Type":"multipart/form-data"}});
};
