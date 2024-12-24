import { useState, useEffect } from 'react';
import { unionBenefitService } from '../../services/unionBenefitService';
import { CreateUnionBenefitForm } from './CreateUnionBenefitForm';

export function UnionBenefitPage() {
  const [benefits, setBenefits] = useState([]);

  useEffect(() => {
    loadBenefits();
  }, []);

  const loadBenefits = async () => {
    try {
      const response = await unionBenefitService.getAll();
      setBenefits(response.data);
    } catch (error) {
      console.error('Ошибка при загрузке льгот:', error);
    }
  };

  const handleDelete = async (id) => {
    if (window.confirm('Вы действительно хотите удалить эту льготу?')) {
      try {
        await unionBenefitService.delete(id);
        loadBenefits();
      } catch (error) {
        console.error('Ошибка при удалении льготы:', error);
      }
    }
  };

  return (
    <div className="container mx-auto p-6 bg-gray-50 min-h-screen">
      <h2 className="text-3xl font-bold text-center mb-8">Профсоюзные льготы</h2>
      
      <div className="mb-10">
        <CreateUnionBenefitForm onCreated={loadBenefits} />
      </div>

      <div>
        <h3 className="text-2xl font-semibold mb-4">Список льгот</h3>
        {benefits.length === 0 ? (
          <p className="text-gray-600">Нет льгот для отображения.</p>
        ) : (
          <div className="grid gap-4">
            {benefits.map(benefit => (
              <div key={benefit.unionBenefitId} className="bg-white p-4 rounded shadow flex justify-between items-center">
                <div>
                  <div>Тип льготы: {benefit.benefitType}</div>
                  <div>Дата получения: {new Date(benefit.dateReceived).toLocaleDateString()}</div>
                </div>
                <button
                  onClick={() => handleDelete(benefit.unionBenefitId)}
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