import { useState } from 'react';
import { unionBenefitService } from '../../services/unionBenefitService';

export function CreateUnionBenefitForm({ onCreated }) {
  const [benefitType, setBenefitType] = useState('0');
  const [dateReceived, setDateReceived] = useState('');
  const [statusMessage, setStatusMessage] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const benefitData = {
        benefitType: Number(benefitType),
        dateReceived: new Date(dateReceived + 'T00:00:00').toISOString().slice(0, -1)
      };

      const response = await unionBenefitService.create(benefitData);
      
      if (response.status === 201) {
        setStatusMessage('OK');
        setBenefitType('0');
        setDateReceived('');
        onCreated && onCreated();
      }
    } catch (error) {
      setStatusMessage('Not OK');
      console.error('Ошибка:', error.response?.data || error.message);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="max-w-md mx-auto p-4 bg-white rounded shadow space-y-4">
      <h3 className="text-lg font-semibold mb-4">Добавить профсоюзную льготу</h3>
      
      <div>
        <label className="block font-semibold mb-1">Тип льготы</label>
        <select
          className="border border-gray-300 p-2 w-full rounded"
          value={benefitType}
          onChange={(e) => setBenefitType(e.target.value)}
          required
        >
          <option value="0">Отпуск</option>
          <option value="1">Путёвка</option>
          <option value="2">Материальная помощь</option>
        </select>
      </div>

      <div>
        <label className="block font-semibold mb-1">Дата получения</label>
        <input
          type="date"
          className="border border-gray-300 p-2 w-full rounded"
          value={dateReceived}
          onChange={(e) => setDateReceived(e.target.value)}
          required
        />
      </div>

      <button
        type="submit"
        className="bg-blue-500 hover:bg-blue-600 text-white font-bold py-2 px-4 rounded w-full"
      >
        Добавить льготу
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
