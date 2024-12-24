import { useState } from 'react'
import { employeeService } from '../../services/employeeService'

export function CreateEmployeeForm({ onCreated }) {
  const [name, setName] = useState('')
  const [surname, setSurname] = useState('')
  const [patronymic, setPatronymic] = useState('')
  const [registrationNumber, setRegistrationNumber] = useState('')
  const [dateOfBirth, setDateOfBirth] = useState('')
  const [gender, setGender] = useState('0');
  const [dateOfHire, setDateOfHire] = useState('');
  const [workPhone, setWorkPhone] = useState('');
  const [homePhone, setHomePhone] = useState('');
  const [maritalStatus, setMaritalStatus] = useState('0');
  const [familySize, setFamilySize] = useState(0);
  const [numberOfChildren, setNumberOfChildren] = useState(0);
  const [isUnionMember, setIsUnionMember] = useState(false);
  const [street, setStreet] = useState('');
  const [houseNumber, setHouseNumber] = useState('');
  const [city, setCity] = useState('');
  const [postalCode, setPostalCode] = useState('');
  const [country, setCountry] = useState('');
  const [departmentIds, setDepartmentIds] = useState([]);
  const [workshopId, setWorkshopId] = useState('');
  const [positionId, setPositionId] = useState('');

  // Состояние для статуса
  const [statusMessage, setStatusMessage] = useState('');

  // Состояния для employmentArchive
  const [employmentArchive, setEmploymentArchive] = useState([
    { recordId: '', startDate: '', endDate: '', positionId: '', positionTitle: '' }
  ]);

  // Состояния для unionBenefits
  const [unionBenefits, setUnionBenefits] = useState([
    { unionBenefitId: '', benefitType: '', dateReceived: '' }
  ]);

  const formatDate = (dateString) => {
    if (!dateString) return null;
    const date = new Date(dateString);
    // Получаем текущее время
    const now = new Date();
    // Комбинируем дату из инпута со временем
    date.setHours(now.getHours());
    date.setMinutes(now.getMinutes());
    date.setSeconds(now.getSeconds());
    date.setMilliseconds(now.getMilliseconds());
    return date.toISOString().slice(0, -1); // Убираем 'Z' в конце
  };

  const handleEmploymentArchiveChange = (index, field, value) => {
    const updatedArchive = [...employmentArchive]
    updatedArchive[index][field] = value
    setEmploymentArchive(updatedArchive)
  }

  const addEmploymentArchive = () => {
    setEmploymentArchive([...employmentArchive, { recordId: '', startDate: '', endDate: '', positionId: '', positionTitle: '' }])
  }

  const removeEmploymentArchive = (index) => {
    const updatedArchive = employmentArchive.filter((_, i) => i !== index)
    setEmploymentArchive(updatedArchive)
  }

  const handleUnionBenefitsChange = (index, field, value) => {
    const updatedBenefits = [...unionBenefits]
    updatedBenefits[index][field] = value
    setUnionBenefits(updatedBenefits)
  }

  const addUnionBenefit = () => {
    setUnionBenefits([...unionBenefits, { unionBenefitId: '', benefitType: '', dateReceived: '' }])
  }

  const removeUnionBenefit = (index) => {
    const updatedBenefits = unionBenefits.filter((_, i) => i !== index)
    setUnionBenefits(updatedBenefits)
  }

  const handleSubmit = async (e) => {
    e.preventDefault()
    try {
      const employeeData = {
        registrationNumber: Number(registrationNumber),
        surname,
        name,
        patronymic,
        dateOfBirth: formatDate(dateOfBirth),
        gender: Number(gender),
        dateOfHire: formatDate(dateOfHire),
        departments: departmentIds.map(id => ({
          departmentId: Number(id),
          name: "string" // Возможно, вам нужно получать имя отдела откуда-то или позволить вводить его
        })),
        workshop: {
          workshopId: Number(workshopId),
          name: "string" // Аналогично, возможно, нужно получать имя цеха
        },
        position: {
          positionId: Number(positionId),
          title: "string" // Возможно, нужно получать название должности
        },
        address: {
          addressId: 0, // Если адрес создается вместе с сотрудником, возможно, backend сам назначит ID
          street,
          houseNumber,
          city,
          postalCode,
          country
        },
        workPhone,
        homePhone,
        maritalStatus: Number(maritalStatus),
        familySize: Number(familySize),
        numberOfChildren: Number(numberOfChildren),
        employmentArchive: employmentArchive.map(record => ({
          recordId: Number(record.recordId) || 0, // Если запись новая, возможно, ID не нужен
          startDate: formatDate(record.startDate),
          endDate: formatDate(record.endDate),
          position: {
            positionId: Number(record.positionId),
            title: record.positionTitle
          }
        })),
        isUnionMember,
        unionBenefits: unionBenefits.map(benefit => ({
          unionBenefitId: Number(benefit.unionBenefitId) || 0, // Аналогично, возможно, ID не нужен
          benefitType: Number(benefit.benefitType),
          dateReceived: formatDate(benefit.dateReceived)
        })
        )
      }

      console.log('Отправляемые данные:', employeeData); // Для отладки

      const response = await employeeService.create(employeeData)

      if (response.status === 201) {
        setStatusMessage('Сотрудник успешно создан')
        // Сброс всех полей
        setName('')
        setSurname('')
        setPatronymic('')
        setRegistrationNumber('')
        setDateOfBirth('')
        setGender('0')
        setDateOfHire('')
        setWorkPhone('')
        setHomePhone('')
        setMaritalStatus('0')
        setFamilySize(0)
        setNumberOfChildren(0)
        setIsUnionMember(false)
        setStreet('')
        setHouseNumber('')
        setCity('')
        setPostalCode('')
        setCountry('')
        setDepartmentIds([])
        setWorkshopId('')
        setPositionId('')
        setEmploymentArchive([{ recordId: '', startDate: '', endDate: '', positionId: '', positionTitle: '' }])
        setUnionBenefits([{ unionBenefitId: '', benefitType: '', dateReceived: '' }])
        onCreated && onCreated()
      }
    } catch (error) {
      setStatusMessage('Ошибка при создании сотрудника')
      console.error('Ошибка:', error)
      // Вывод детальной информации об ошибке
      if (error.response?.data?.errors) {
        console.error('Ошибки валидации:', error.response.data.errors)
      }
    }
  }

  return (
    <form onSubmit={handleSubmit} className="max-w-4xl mx-auto p-6 bg-white rounded shadow overflow-y-auto max-h-screen">
      {/* Основная информация */}
      <div className="grid grid-cols-2 gap-4 mb-6">
        <div className="col-span-2">
          <h3 className="text-lg font-semibold mb-4">Основная информация</h3>
        </div>
        
        <div>
          <label className="block font-medium mb-1">Фамилия*</label>
          <input 
            required
            className="border border-gray-300 p-2 w-full rounded"
            value={surname}
            onChange={(e) => setSurname(e.target.value)}
          />
        </div>

        <div>
          <label className="block font-medium mb-1">Имя*</label>
          <input 
            required
            className="border border-gray-300 p-2 w-full rounded"
            value={name}
            onChange={(e) => setName(e.target.value)}
          />
        </div>

        <div>
          <label className="block font-medium mb-1">Отчество*</label>
          <input 
            required
            className="border border-gray-300 p-2 w-full rounded"
            value={patronymic}
            onChange={(e) => setPatronymic(e.target.value)}
          />
        </div>

        <div>
          <label className="block font-medium mb-1">Регистрационный номер*</label>
          <input 
            required
            type="number"
            className="border border-gray-300 p-2 w-full rounded"
            value={registrationNumber}
            onChange={(e) => setRegistrationNumber(e.target.value)}
          />
        </div>

        <div>
          <label className="block font-medium mb-1">Пол</label>
          <select 
            className="border border-gray-300 p-2 w-full rounded"
            value={gender}
            onChange={(e) => setGender(e.target.value)}
          >
            <option value="0">Мужской</option>
            <option value="1">Женский</option>
          </select>
        </div>

        <div>
          <label className="block font-medium mb-1">Дата рождения*</label>
          <input 
            required
            type="date"
            className="border border-gray-300 p-2 w-full rounded"
            value={dateOfBirth}
            onChange={(e) => setDateOfBirth(e.target.value)}
          />
        </div>

        <div>
          <label className="block font-medium mb-1">Дата приема на работу*</label>
          <input 
            required
            type="date"
            className="border border-gray-300 p-2 w-full rounded"
            value={dateOfHire}
            onChange={(e) => setDateOfHire(e.target.value)}
          />
        </div>
      </div>

      {/* Контактная информация */}
      <div className="grid grid-cols-2 gap-4 mb-6">
        <div className="col-span-2">
          <h3 className="text-lg font-semibold mb-4">Контактная информация</h3>
        </div>

        <div>
          <label className="block font-medium mb-1">Рабочий телефон</label>
          <input 
            className="border border-gray-300 p-2 w-full rounded"
            value={workPhone}
            onChange={(e) => setWorkPhone(e.target.value)}
          />
        </div>

        <div>
          <label className="block font-medium mb-1">Домашний телефон</label>
          <input 
            className="border border-gray-300 p-2 w-full rounded"
            value={homePhone}
            onChange={(e) => setHomePhone(e.target.value)}
          />
        </div>

        {/* Адрес */}
        <div className="col-span-2">
          <h4 className="font-medium mb-2">Адрес</h4>
          <div className="grid grid-cols-2 gap-4">
            <div className="col-span-2">
              <label className="block font-medium mb-1">Улица</label>
              <input 
                className="border border-gray-300 p-2 w-full rounded"
                value={street}
                onChange={(e) => setStreet(e.target.value)}
              />
            </div>
            <div>
              <label className="block font-medium mb-1">Дом</label>
              <input 
                className="border border-gray-300 p-2 w-full rounded"
                value={houseNumber}
                onChange={(e) => setHouseNumber(e.target.value)}
              />
            </div>
            <div>
              <label className="block font-medium mb-1">Город</label>
              <input 
                className="border border-gray-300 p-2 w-full rounded"
                value={city}
                onChange={(e) => setCity(e.target.value)}
              />
            </div>
            <div>
              <label className="block font-medium mb-1">Индекс</label>
              <input 
                className="border border-gray-300 p-2 w-full rounded"
                value={postalCode}
                onChange={(e) => setPostalCode(e.target.value)}
              />
            </div>
            <div>
              <label className="block font-medium mb-1">Страна</label>
              <input 
                className="border border-gray-300 p-2 w-full rounded"
                value={country}
                onChange={(e) => setCountry(e.target.value)}
              />
            </div>
          </div>
        </div>
      </div>

      {/* Рабочая информация */}
      <div className="grid grid-cols-2 gap-4 mb-6">
        <div className="col-span-2">
          <h3 className="text-lg font-semibold mb-4">Рабочая информация</h3>
        </div>

        <div>
          <label className="block font-medium mb-1">ID Цеха*</label>
          <input 
            required
            type="number"
            className="border border-gray-300 p-2 w-full rounded"
            value={workshopId}
            onChange={(e) => setWorkshopId(e.target.value)}
          />
        </div>

        <div>
          <label className="block font-medium mb-1">ID Должности*</label>
          <input 
            required
            type="number"
            className="border border-gray-300 p-2 w-full rounded"
            value={positionId}
            onChange={(e) => setPositionId(e.target.value)}
          />
        </div>

        <div className="col-span-2">
          <label className="block font-medium mb-1">ID Отделов (через запятую)</label>
          <input 
            className="border border-gray-300 p-2 w-full rounded"
            placeholder="1, 2, 3"
            value={departmentIds}
            onChange={(e) => setDepartmentIds(e.target.value.split(',').map(id => id.trim()))}
          />
        </div>
      </div>

      {/* Личная информация */}
      <div className="grid grid-cols-2 gap-4 mb-6">
        <div className="col-span-2">
          <h3 className="text-lg font-semibold mb-4">Личная информация</h3>
        </div>

        <div>
          <label className="block font-medium mb-1">Семейное положение</label>
          <select 
            className="border border-gray-300 p-2 w-full rounded"
            value={maritalStatus}
            onChange={(e) => setMaritalStatus(e.target.value)}
          >
            <option value="0">Не женат/Не замужем</option>
            <option value="1">Женат/Замужем</option>
            <option value="2">Разведен(а)</option>
            <option value="3">Вдовец/Вдова</option>
          </select>
        </div>

        <div>
          <label className="block font-medium mb-1">Размер семьи</label>
          <input 
            type="number"
            min="0"
            className="border border-gray-300 p-2 w-full rounded"
            value={familySize}
            onChange={(e) => setFamilySize(e.target.value)}
          />
        </div>

        <div>
          <label className="block font-medium mb-1">Количество детей</label>
          <input 
            type="number"
            min="0"
            className="border border-gray-300 p-2 w-full rounded"
            value={numberOfChildren}
            onChange={(e) => setNumberOfChildren(e.target.value)}
          />
        </div>

        <div className="flex items-center">
          <input 
            type="checkbox"
            className="mr-2"
            checked={isUnionMember}
            onChange={(e) => setIsUnionMember(e.target.checked)}
          />
          <label className="font-medium">Член профсоюза</label>
        </div>
      </div>

      {/* Employment Archive */}
      <div className="mb-6">
        <h3 className="text-lg font-semibold mb-4">Архив трудовой деятельности</h3>
        {employmentArchive.map((record, index) => (
          <div key={index} className="border border-gray-300 p-4 mb-4 rounded">
            <div className="grid grid-cols-2 gap-4">
              <div>
                <label className="block font-medium mb-1">Record ID</label>
                <input 
                  type="number"
                  className="border border-gray-300 p-2 w-full rounded"
                  value={record.recordId}
                  onChange={(e) => handleEmploymentArchiveChange(index, 'recordId', e.target.value)}
                />
              </div>
              <div>
                <label className="block font-medium mb-1">Дата начала</label>
                <input 
                  type="date"
                  className="border border-gray-300 p-2 w-full rounded"
                  value={record.startDate}
                  onChange={(e) => handleEmploymentArchiveChange(index, 'startDate', e.target.value)}
                />
              </div>
              <div>
                <label className="block font-medium mb-1">Дата окончания</label>
                <input 
                  type="date"
                  className="border border-gray-300 p-2 w-full rounded"
                  value={record.endDate}
                  onChange={(e) => handleEmploymentArchiveChange(index, 'endDate', e.target.value)}
                />
              </div>
              <div>
                <label className="block font-medium mb-1">ID Должности</label>
                <input 
                  type="number"
                  className="border border-gray-300 p-2 w-full rounded"
                  value={record.positionId}
                  onChange={(e) => handleEmploymentArchiveChange(index, 'positionId', e.target.value)}
                />
              </div>
              <div className="col-span-2">
                <label className="block font-medium mb-1">Название должности</label>
                <input 
                  className="border border-gray-300 p-2 w-full rounded"
                  value={record.positionTitle}
                  onChange={(e) => handleEmploymentArchiveChange(index, 'positionTitle', e.target.value)}
                />
              </div>
            </div>
            {employmentArchive.length > 1 && (
              <button 
                type="button"
                className="mt-2 text-red-500"
                onClick={() => removeEmploymentArchive(index)}
              >
                Удалить запись
              </button>
            )}
          </div>
        ))}
        <button 
          type="button"
          className="bg-green-500 hover:bg-green-600 text-white font-bold py-2 px-4 rounded"
          onClick={addEmploymentArchive}
        >
          Добавить запись
        </button>
      </div>

      {/* Union Benefits */}
      <div className="mb-6">
        <h3 className="text-lg font-semibold mb-4">Профсоюзные льготы</h3>
        {unionBenefits.map((benefit, index) => (
          <div key={index} className="border border-gray-300 p-4 mb-4 rounded">
            <div className="grid grid-cols-2 gap-4">
              <div>
                <label className="block font-medium mb-1">Union Benefit ID</label>
                <input 
                  type="number"
                  className="border border-gray-300 p-2 w-full rounded"
                  value={benefit.unionBenefitId}
                  onChange={(e) => handleUnionBenefitsChange(index, 'unionBenefitId', e.target.value)}
                />
              </div>
              <div>
                <label className="block font-medium mb-1">Тип льготы</label>
                <select 
                  className="border border-gray-300 p-2 w-full rounded"
                  value={benefit.benefitType}
                  onChange={(e) => handleUnionBenefitsChange(index, 'benefitType', e.target.value)}
                >
                  <option value="">Выберите тип</option>
                  <option value="0">Тип 0</option>
                  <option value="1">Тип 1</option>
                  {/* Добавьте остальные типы по необходимости */}
                </select>
              </div>
              <div className="col-span-2">
                <label className="block font-medium mb-1">Дата получения</label>
                <input 
                  type="date"
                  className="border border-gray-300 p-2 w-full rounded"
                  value={benefit.dateReceived}
                  onChange={(e) => handleUnionBenefitsChange(index, 'dateReceived', e.target.value)}
                />
              </div>
            </div>
            {unionBenefits.length > 1 && (
              <button 
                type="button"
                className="mt-2 text-red-500"
                onClick={() => removeUnionBenefit(index)}
              >
                Удалить льготу
              </button>
            )}
          </div>
        ))}
        <button 
          type="button"
          className="bg-green-500 hover:bg-green-600 text-white font-bold py-2 px-4 rounded"
          onClick={addUnionBenefit}
        >
          Добавить льготу
        </button>
      </div>

      <div className="flex justify-end gap-4">
        <button
          type="submit"
          className="bg-blue-500 hover:bg-blue-600 text-white font-bold py-2 px-6 rounded"
        >
          Создать сотрудника
        </button>
      </div>

      {statusMessage && (
        <div className={`mt-4 p-3 rounded ${
          statusMessage === 'OK' || statusMessage === 'Сотрудник успешно создан' 
            ? 'bg-green-100 text-green-700' 
            : 'bg-red-100 text-red-700'
        }`}>
          {statusMessage}
        </div>
      )}
    </form>
  )
}
