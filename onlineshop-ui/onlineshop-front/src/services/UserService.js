import api from "../helpers/ConfigHelper";

export const getMyProfile = async () => {
  return await api.get(`/Korisnik/get-my-profile`);
};

export const register = async (registerData) => {
  return await api.post(`/Korisnik`, registerData, {headers: {"Content-Type":"multipart/form-data"}});
};

export const update = async (updateData) => {
  return await api.put(`/Korisnik`, updateData, {headers: {"Content-Type":"multipart/form-data"}});
};

export const acceptVerification = async (id) => {
  return await api.put(`/Korisnik/accept-verification/`+ id);
};

export const denyVerification = async (id) => {
  return await api.put(`/Korisnik/deny-verification/` + id);
};

export const getAllSalesmans = async () => {
  return await api.get(`/Korisnik/get-all-salesmans`);
};
