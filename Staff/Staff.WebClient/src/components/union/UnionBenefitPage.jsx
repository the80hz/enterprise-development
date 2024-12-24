import { useState, useEffect } from 'react';
import { unionBenefitService } from '../services/unionBenefitService';
import { CreateUnionBenefitForm } from '../components/union/CreateUnionBenefitForm';

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
              <div key={benefit.unionBenefitId} className="bg-white p-4 rounded shadow">
                <div>Тип льготы: {benefit.benefitType}</div>
                <div>Дата получения: {new Date(benefit.dateReceived).toLocaleDateString()}</div>
              </div>
            ))}
          </div>
        )}
      </div>
    </div>
  );
}