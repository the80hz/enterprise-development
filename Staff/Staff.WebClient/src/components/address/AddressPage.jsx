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
    <div className="container mx-auto p-6">
      <h2 className="text-2xl font-bold mb-4">Управление адресами</h2>
      
      <div className="mb-8">
        <h3 className="text-xl font-semibold mb-4">Добавить новый адрес</h3>
        <CreateAddressForm onCreated={loadAddresses} />
      </div>

      <div>
        <h3 className="text-xl font-semibold mb-4">Список адресов</h3>
        {addresses.length === 0 ? (
          <p className="text-gray-600">Нет адресов для отображения.</p>
        ) : (
          <div className="grid gap-4">
            {addresses.map(address => (
              <div key={address.addressId} className="bg-white p-4 rounded shadow flex justify-between items-center">
                <div>
                  <div className="font-medium">{address.street}, {address.houseNumber}</div>
                  <div className="text-gray-600">{address.city}, {address.postalCode}</div>
                  <div className="text-gray-600">{address.country}</div>
                </div>
                <button
                  onClick={() => handleDelete(address.addressId)}
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
