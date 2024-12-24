import api from '../api/api';

export const addressService = {
  getAll: () => api.get('/Address'),
  getById: (id) => api.get(`/Address/${id}`),
  create: (address) => api.post('/Address', address),
  update: (id, address) => api.put(`/Address/${id}`, address),
  delete: (id) => api.delete(`/Address/${id}`)
};
