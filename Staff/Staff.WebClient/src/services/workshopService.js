import api from '../api/api';

export const workshopService = {
  getAll: () => api.get('/Workshop'),
  getById: (id) => api.get(`/Workshop/${id}`),
  create: (workshop) => api.post('/Workshop', workshop),
  update: (id, workshop) => api.put(`/Workshop/${id}`, workshop),
  delete: (id) => api.delete(`/Workshop/${id}`)
};
