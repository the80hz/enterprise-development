import { useState, useEffect } from 'react';
import { positionService } from '../../services/positionService';
import { CreatePositionForm } from './CreatePositionForm';

export function PositionPage() {
  const [positions, setPositions] = useState([]);

  const loadPositions = async () => {
    try {
      const response = await positionService.getAll();
      setPositions(response.data);
    } catch (error) {
      console.error('Ошибка при загрузке должностей:', error);
    }
  };

  const handleDelete = async (id) => {
    if (window.confirm('Вы действительно хотите удалить эту должность?')) {
      try {
        await positionService.delete(id);
        loadPositions();
      } catch (error) {
        console.error('Ошибка при удалении должности:', error);
      }
    }
  };

  useEffect(() => {
    loadPositions();
  }, []);

  return (
    <div className="container mx-auto p-6 bg-gray-50 min-h-screen">
      <h2 className="text-3xl font-bold text-center mb-8">Управление Должностями</h2>
      
      <div className="mb-10">
        <CreatePositionForm onCreated={loadPositions} />
      </div>

      <div>
        <h3 className="text-2xl font-semibold mb-4">Список должностей</h3>
        {positions.length === 0 ? (
          <p className="text-gray-600">Нет должностей для отображения.</p>
        ) : (
          <ul className="space-y-4">
            {positions.map((position) => (
              <li key={position.positionId} className="flex items-center justify-between p-4 bg-white rounded shadow">
                <div className="font-medium">{position.title}</div>
                <button
                  onClick={() => handleDelete(position.positionId)}
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
