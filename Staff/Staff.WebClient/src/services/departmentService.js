import api from '../api/api';

export const departmentService = {
  getAll: () => api.get('/Department'),
  getById: (id) => api.get(`/Department/${id}`),
  create: (department) => api.post('/Department', department),
  update: (id, department) => api.put(`/Department/${id}`, department),
  delete: (id) => api.delete(`/Department/${id}`)
};
