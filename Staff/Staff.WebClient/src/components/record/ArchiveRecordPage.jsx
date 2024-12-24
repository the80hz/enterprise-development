import { useState, useEffect } from 'react';
import { archiveRecordService } from '../../services/archiveRecordService';
import { CreateArchiveRecordForm } from './CreateArchiveRecordForm';

export function ArchiveRecordPage() {
  const [records, setRecords] = useState([]);
  const [terminationRecords, setTerminationRecords] = useState([]);

  useEffect(() => {
    loadRecords();
    loadTerminationArchive();
  }, []);

  const loadRecords = async () => {
    try {
      const response = await archiveRecordService.getAll();
      setRecords(response.data);
    } catch (error) {
      console.error('Ошибка при загрузке записей:', error);
    }
  };

  const loadTerminationArchive = async () => {
    try {
      const response = await archiveRecordService.getTerminationArchive();
      setTerminationRecords(response.data);
    } catch (error) {
      console.error('Ошибка при загрузке архива увольнений:', error);
    }
  };

  const handleDelete = async (id) => {
    if (window.confirm('Вы действительно хотите удалить эту запись?')) {
      try {
        await archiveRecordService.delete(id);
        loadRecords();
      } catch (error) {
        console.error('Ошибка при удалении записи:', error);
      }
    }
  };

  return (
    <div className="container mx-auto p-6 bg-gray-50 min-h-screen">
      <h2 className="text-3xl font-bold text-center mb-8">Архив трудоустройства</h2>
      
      <div className="mb-10">
        <CreateArchiveRecordForm onCreated={loadRecords} />
      </div>

      <div>
        <h3 className="text-2xl font-semibold mb-4">Список архивных записей</h3>
        {records.length === 0 ? (
          <p className="text-gray-600">Нет архивных записей для отображения.</p>
        ) : (
          <div className="grid gap-4">
            {records.map(record => (
              <div key={record.recordId} className="bg-white p-4 rounded shadow flex justify-between items-center">
                <div>
                  <div>Начало: {new Date(record.startDate).toLocaleDateString()}</div>
                  {record.endDate && (
                    <div>Окончание: {new Date(record.endDate).toLocaleDateString()}</div>
                  )}
                  <div>Должность: {record.position?.title || 'Не указана'}</div>
                </div>
                <button
                  onClick={() => handleDelete(record.recordId)}
                  className="bg-red-500 hover:bg-red-600 text-white px-4 py-2 rounded"
                >
                  Удалить
                </button>
              </div>
            ))}
          </div>
        )}
      </div>
    </div>
  );
}