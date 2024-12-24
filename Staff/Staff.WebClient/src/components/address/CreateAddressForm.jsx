import { useState } from 'react';
import api from '../../services/api';

export function CreateAddressForm({ onCreated }) {
  const [street, setStreet] = useState('');
  const [houseNumber, setHouseNumber] = useState('');
  const [city, setCity] = useState('');
  const [postalCode, setPostalCode] = useState('');
  const [country, setCountry] = useState('');
  const [statusMessage, setStatusMessage] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    setStatusMessage(''); // Сброс предыдущих сообщений

    try {
      const response = await api.post('Address', {
        street,
        houseNumber,
        city,
        postalCode,
        country
      });

      if (response.status === 201) {
        setStatusMessage('Адрес успешно добавлен!');
        // Сброс формы
        setStreet('');
        setHouseNumber('');
        setCity('');
        setPostalCode('');
        setCountry('');
        onCreated && onCreated();
      }
    } catch (error) {
      setStatusMessage('Не удалось добавить адрес.');
      console.error('Ошибка:', error.response?.data || error.message);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="max-w-md mx-auto p-6 bg-white rounded shadow space-y-6">
      <div>
        <label className="block text-sm font-medium text-gray-700 mb-1">Улица</label>
        <input
          type="text"
          className="mt-1 block w-full border border-gray-300 rounded-md shadow-sm p-2"
          value={street}
          onChange={(e) => setStreet(e.target.value)}
          required
        />
      </div>

      <div>
        <label className="block text-sm font-medium text-gray-700 mb-1">Номер дома</label>
        <input
          type="text"
          className="mt-1 block w-full border border-gray-300 rounded-md shadow-sm p-2"
          value={houseNumber}
          onChange={(e) => setHouseNumber(e.target.value)}
          required
        />
      </div>

      <div>
        <label className="block text-sm font-medium text-gray-700 mb-1">Город</label>
        <input
          type="text"
          className="mt-1 block w-full border border-gray-300 rounded-md shadow-sm p-2"
          value={city}
          onChange={(e) => setCity(e.target.value)}
          required
        />
      </div>

      <div>
        <label className="block text-sm font-medium text-gray-700 mb-1">Почтовый индекс</label>
        <input
          type="text"
          className="mt-1 block w-full border border-gray-300 rounded-md shadow-sm p-2"
          value={postalCode}
          onChange={(e) => setPostalCode(e.target.value)}
          required
        />
      </div>

      <div>
        <label className="block text-sm font-medium text-gray-700 mb-1">Страна</label>
        <input
          type="text"
          className="mt-1 block w-full border border-gray-300 rounded-md shadow-sm p-2"
          value={country}
          onChange={(e) => setCountry(e.target.value)}
          required
        />
      </div>

      <button
        type="submit"
        className="w-full bg-blue-600 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded-md"
      >
        Добавить адрес
      </button>

      {statusMessage && (
        <div className={`text-sm font-semibold mt-4 ${
          statusMessage.includes('успешно') ? 'text-green-600' : 'text-red-600'
        }`}>
          {statusMessage}
        </div>
      )}
    </form>
  );
}