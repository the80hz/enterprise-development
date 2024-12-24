import { useState } from 'react';
import { archiveRecordService } from '../../services/archiveRecordService';

export function CreateArchiveRecordForm({ onCreated }) {
  const [startDate, setStartDate] = useState('');
  const [endDate, setEndDate] = useState('');
  const [positionId, setPositionId] = useState('');
  const [statusMessage, setStatusMessage] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const recordData = {
        startDate: new Date(startDate + 'T00:00:00').toISOString().slice(0, -1),
        endDate: endDate ? new Date(endDate + 'T00:00:00').toISOString().slice(0, -1) : null,
        position: {
          positionId: Number(positionId),
          title: "Position"
        }
      };

      const response = await archiveRecordService.create(recordData);
      
      if (response.status === 201) {
        setStatusMessage('OK');
        setStartDate('');
        setEndDate('');
        setPositionId('');
        onCreated && onCreated();
      }
    } catch (error) {
      setStatusMessage('Not OK');
      console.error('Ошибка:', error.response?.data || error.message);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="max-w-md mx-auto p-4 bg-white rounded shadow space-y-4">
      <h3 className="text-lg font-semibold mb-4">Добавить запись в архив</h3>
      
      <div>
        <label className="block font-semibold mb-1">Дата начала</label>
        <input
          type="date"
          className="border border-gray-300 p-2 w-full rounded"
          value={startDate}
          onChange={(e) => setStartDate(e.target.value)}
          required
        />
      </div>

      <div>
        <label className="block font-semibold mb-1">Дата окончания</label>
        <input
          type="date"
          className="border border-gray-300 p-2 w-full rounded"
          value={endDate}
          onChange={(e) => setEndDate(e.target.value)}
        />
      </div>

      <div>
        <label className="block font-semibold mb-1">ID Должности</label>
        <input
          type="number"
          className="border border-gray-300 p-2 w-full rounded"
          value={positionId}
          onChange={(e) => setPositionId(e.target.value)}
          required
        />
      </div>

      <button
        type="submit"
        className="bg-blue-500 hover:bg-blue-600 text-white font-bold py-2 px-4 rounded w-full"
      >
        Создать запись
      </button>

      {statusMessage && (
        <div className={`text-sm font-semibold ${
          statusMessage === 'OK' ? 'text-green-600' : 'text-red-600'
        }`}>
          {statusMessage}
        </div>
      )}
    </form>
  );
}
