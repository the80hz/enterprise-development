import api from '../api/api';

export const unionBenefitService = {
  getAll: () => api.get('/UnionBenefit'),
  getById: (id) => api.get(`/UnionBenefit/${id}`),
  create: (benefit) => api.post('/UnionBenefit', benefit),
  update: (id, benefit) => api.put(`/UnionBenefit/${id}`, benefit),
  delete: (id) => api.delete(`/UnionBenefit/${id}`)
};
