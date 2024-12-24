import { useState, useEffect } from 'react';
import { workshopService } from '../../services/workshopService';
import { CreateWorkshopForm } from '../components/workshop/CreateWorkshopForm';

export function WorkshopPage() {
  const [workshops, setWorkshops] = useState([]);

  const loadWorkshops = async () => {
    try {
      const response = await workshopService.getAll();
      setWorkshops(response.data);
    } catch (error) {
      console.error('Ошибка при загрузке цехов:', error);
    }
  };

  useEffect(() => {
    loadWorkshops();
  }, []);

  return (
    <div className="container mx-auto p-6 bg-gray-50 min-h-screen">
      <h2 className="text-3xl font-bold text-center mb-8">Управление Цехами</h2>
      
      <div className="mb-10">
        <CreateWorkshopForm onCreated={loadWorkshops} />
      </div>

      <div>
        <h3 className="text-2xl font-semibold mb-4">Список цехов</h3>
        {workshops.length === 0 ? (
          <p className="text-gray-600">Нет цехов для отображения.</p>
        ) : (
          <ul className="space-y-4">
            {workshops.map((workshop) => (
              <li key={workshop.workshopId} className="flex items-center justify-between p-4 bg-white rounded shadow">
                <div className="font-medium">{workshop.name}</div>
              </li>
            ))}
          </ul>
        )}
      </div>
    </div>
  );
}
