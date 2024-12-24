import api from '../api/api';

export const positionService = {
  getAll: () => api.get('/Position'),
  getById: (id) => api.get(`/Position/${id}`),
  create: (position) => api.post('/Position', position),
  update: (id, position) => api.put(`/Position/${id}`, position),
  delete: (id) => api.delete(`/Position/${id}`)
};
