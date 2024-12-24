import { useState } from 'react';
import { positionService } from '../../services/positionService';

export function CreatePositionForm({ onCreated }) {
  const [title, setTitle] = useState('');
  const [statusMessage, setStatusMessage] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await positionService.create({ title });
      if (response.status === 201) {
        setStatusMessage('OK');
        setTitle('');
        onCreated && onCreated();
      }
    } catch (error) {
      setStatusMessage('Not OK');
      console.error('Ошибка:', error.response?.data || error.message);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="max-w-md mx-auto p-4 bg-white rounded shadow space-y-4">
      <label className="block font-semibold mb-1">Название должности</label>
      <input
        className="border border-gray-300 p-2 w-full rounded"
        value={title}
        onChange={(e) => setTitle(e.target.value)}
        required
      />
      <button
        type="submit"
        className="bg-blue-500 hover:bg-blue-600 text-white font-bold py-2 px-4 rounded"
      >
        Создать
      </button>
      {statusMessage && <div className="text-sm font-semibold">{statusMessage}</div>}
    </form>
  );
}
