import { useState, useEffect } from 'react'
import { CreateEmployeeForm } from './CreateEmployeeForm'
import { employeeService } from '../../services/employeeService'

export function EmployeePage() {
  const [employees, setEmployees] = useState([])

  const loadEmployees = async () => {
    try {
      const response = await employeeService.getAll();
      setEmployees(response.data);
    } catch (error) {
      console.error('Ошибка при загрузке сотрудников:', error);
    }
  }

  const handleDelete = async (id) => {
    if (window.confirm('Вы уверены, что хотите удалить этого сотрудника?')) {
      try {
        await employeeService.delete(id);
        loadEmployees();
      } catch (error) {
        console.error('Ошибка при удалении сотрудника:', error);
      }
    }
  };

  useEffect(() => {
    loadEmployees()
  }, [])

  return (
    <div className="container mx-auto p-6 bg-gray-50 min-h-screen">
      <h2 className="text-3xl font-bold text-center mb-8">Управление Сотрудниками</h2>
      
      <div className="mb-10">
        <CreateEmployeeForm onCreated={loadEmployees} />
      </div>

      <div>
        <h3 className="text-2xl font-semibold mb-4">Список сотрудников</h3>
        {employees.length === 0 ? (
          <p className="text-gray-600">Нет сотрудников для отображения.</p>
        ) : (
          <ul className="space-y-4">
            {employees.map((emp) => (
              <li key={emp.registrationNumber} className="flex items-center justify-between p-4 bg-white rounded shadow">
                <div>
                  <span className="font-bold">{emp.surname} {emp.name}</span> ({emp.registrationNumber})
                  <div className="text-sm text-gray-500">
                    {emp.position?.title || 'Должность не указана'}
                  </div>
                </div>
                <button
                  onClick={() => handleDelete(emp.registrationNumber)}
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
  )
}