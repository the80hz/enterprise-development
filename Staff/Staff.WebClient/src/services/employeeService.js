import api from '../api/api';

export const employeeService = {
  getAll: () => api.get('/Employee'),
  getById: (id) => api.get(`/Employee/${id}`),
  create: (employee) => api.post('/Employee', employee),
  update: (id, employee) => api.put(`/Employee/${id}`, employee),
  delete: (id) => api.delete(`/Employee/${id}`),
};
