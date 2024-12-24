import { useState, useEffect } from 'react';
import { addressService } from '../../services/addressService';
import { CreateAddressForm } from './CreateAddressForm';

export function AddressPage() {
  const [addresses, setAddresses] = useState([]);

  useEffect(() => {
    loadAddresses();
  }, []);

  const loadAddresses = async () => {
    try {
      const response = await addressService.getAll();
      setAddresses(response.data);
    } catch (error) {
      console.error('Ошибка при загрузке адресов:', error);
    }
  };

  const handleDelete = async (id) => {
    if (window.confirm('Вы уверены, что хотите удалить этот адрес?')) {
      try {
        await addressService.delete(id);
        loadAddresses();
      } catch (error) {
        console.error('Ошибка при удалении адреса:', error);
      }
    }
  };

  return (
    <div className="container mx-auto p-6 bg-gray-50 min-h-screen">
      <h2 className="text-3xl font-bold text-center mb-8">Управление Адресами</h2>
      
      <div className="mb-10">
        <CreateAddressForm onCreated={loadAddresses} />
      </div>

      <div>
        <h3 className="text-2xl font-semibold mb-4">Список адресов</h3>
        {addresses.length === 0 ? (
          <p className="text-gray-600">Нет адресов для отображения.</p>
        ) : (
          <ul className="space-y-4">
            {addresses.map(address => (
              <li key={address.addressId} className="flex items-center justify-between p-4 bg-white rounded shadow">
                <div>
                  <div className="font-bold">{address.street}, {address.houseNumber}</div>
                  <div className="text-sm text-gray-600">{address.city}, {address.postalCode}</div>
                  <div className="text-sm text-gray-600">{address.country}</div>
                </div>
                <button
                  onClick={() => handleDelete(address.addressId)}
                  className="bg-red-500 hover:bg-red-600 text-white px-4 py-2 rounded"
                >
                  Удалить
                </button>
              </li>
            ))}
          </ul>
        )}
      </div>
    </div>
  );
}
