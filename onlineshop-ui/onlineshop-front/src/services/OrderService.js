import api from "../helpers/ConfigHelper";

export const getAllOrders = async () => {
  return await api.get(`/Porudzbina/get-all-orders`);
};
export const getCustomerDeliveredOrders = async () => {
  return await api.get(`/Porudzbina/get-customer-delivered-orders`);
};
export const getSalesmanDeliveredOrders = async () => {
  return await api.get(`/Porudzbina/get-salesman-delivered-orders`);
};

export const getCustomerInProgressOrders = async () => {
  return await api.get(`/Porudzbina/get-customer-in-progress-orders`);
};
export const getSalesmanInProgressOrders = async () => {
  return await api.get(`/Porudzbina/get-salesman-in-progress-orders`);
};

export const createOrder = async (orderData) => {
  return await api.post(`/Porudzbina/create-order`, orderData);
};

export const denyOrder = async (id) => {
  return await api.put(`/Porudzbina/deny-order/`+id);
};