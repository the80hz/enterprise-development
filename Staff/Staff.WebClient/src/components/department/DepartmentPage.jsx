import { useState, useEffect } from 'react';
import { departmentService } from '../services/departmentService';
import { CreateDepartmentForm } from './CreateDepartmentForm';

export function DepartmentPage() {
  const [departments, setDepartments] = useState([]);

  const loadDepartments = async () => {
    try {
      const response = await departmentService.getAll();
      setDepartments(response.data);
    } catch (error) {
      console.error('Ошибка при загрузке отделов:', error);
    }
  };

  useEffect(() => {
    loadDepartments();
  }, []);

  return (
    <div className="container mx-auto p-6 bg-gray-50 min-h-screen">
      <h2 className="text-3xl font-bold text-center mb-8">Управление Отделами</h2>
      
      <div className="mb-10">
        <CreateDepartmentForm onCreated={loadDepartments} />
      </div>

      <div>
        <h3 className="text-2xl font-semibold mb-4">Список отделов</h3>
        {departments.length === 0 ? (
          <p className="text-gray-600">Нет отделов для отображения.</p>
        ) : (
          <ul className="space-y-4">
            {departments.map((dept) => (
              <li key={dept.departmentId} className="flex items-center justify-between p-4 bg-white rounded shadow">
                <div className="font-medium">{dept.name}</div>
              </li>
            ))}
          </ul>
        )}
      </div>
    </div>
  );
}
