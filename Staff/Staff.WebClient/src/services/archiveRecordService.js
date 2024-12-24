import api from '../api/api';

export const archiveRecordService = {
  getAll: () => api.get('/EmploymentArchiveRecord'),
  getById: (id) => api.get(`/EmploymentArchiveRecord/${id}`),
  create: (record) => api.post('/EmploymentArchiveRecord', record),
  update: (id, record) => api.put(`/EmploymentArchiveRecord/${id}`, record),
  delete: (id) => api.delete(`/EmploymentArchiveRecord/${id}`),
  getTerminationArchive: () => api.get('/EmploymentArchiveRecord/TerminationArchive')
};
