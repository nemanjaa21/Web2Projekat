import api from "../helpers/ConfigHelper";

export const getAllProducts = async () => {
  return await api.get(`/Artikal/get-all-products`)
}

export const getMyProducts = async () => {
  return await api.get(`/Artikal/get-my-products`);
};

export const getProductById = async (id) => {
  return await api.get(`/Artikal/` + id);
};

export const createNewProduct = async (productData) => {
  return await api.post(`/Artikal`, productData, {headers: {"Content-Type":"multipart/form-data"}});
};

export const updateProduct = async (id, productData) => {
  return await api.put(`/Artikal` + id, productData);
};

export const deleteProduct = async (id) => {
  return await api.delete(`/Artikal/` + id);
};
