import { useState } from 'react'

export function CreateEmployeeForm({ onCreated }) {
  const [name, setName] = useState('')
  const [surname, setSurname] = useState('')
  const [patronymic, setPatronymic] = useState('')
  const [registrationNumber, setRegistrationNumber] = useState('')
  const [dateOfBirth, setDateOfBirth] = useState('')
  const [gender, setGender] = useState('Male');
  const [dateOfHire, setDateOfHire] = useState('');
  const [workPhone, setWorkPhone] = useState('');
  const [homePhone, setHomePhone] = useState('');
  const [maritalStatus, setMaritalStatus] = useState('Single');
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

  // Добавляем состояние для статуса
  const [statusMessage, setStatusMessage] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault()
    try {
      const response = await fetch('http://localhost:5032/api/Employee', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          name,
          surname,
          patronymic,
          registrationNumber: Number(registrationNumber),
          dateOfBirth,
          gender,
          dateOfHire,
          workPhone,
          homePhone,
          maritalStatus,
          familySize: Number(familySize),
          numberOfChildren: Number(numberOfChildren),
          isUnionMember,
          address: {
            street,
            houseNumber,
            city,
            postalCode,
            country
          },
          departments: departmentIds.map(id => ({ departmentId: Number(id) })),
          workshop: { workshopId: Number(workshopId) },
          position: { positionId: Number(positionId) }
        }),
      })
      if (response.ok) {
        setStatusMessage('OK');
        setName('')
        setSurname('')
        setPatronymic('')
        setRegistrationNumber('')
        setDateOfBirth('')
        setGender('Male')
        setDateOfHire('')
        setWorkPhone('')
        setHomePhone('')
        setMaritalStatus('Single')
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
        onCreated && onCreated()
      } else {
        setStatusMessage('Not OK');
        console.error('Ошибка при создании сотрудника', response.statusText)
      }
    } catch (error) {
      setStatusMessage('Not OK');
      console.error(error)
    }
  }

  return (
    <form onSubmit={handleSubmit} className="max-w-md mx-auto p-4 bg-white rounded shadow space-y-4">
      <label className="block font-semibold mb-1">Имя</label>
      <input className="border border-gray-300 p-2 w-full rounded" value={name} onChange={(e) => setName(e.target.value)} />

      <label className="block font-semibold mb-1">Фамилия</label>
      <input className="border border-gray-300 p-2 w-full rounded" value={surname} onChange={(e) => setSurname(e.target.value)} />

      <label className="block font-semibold mb-1">Отчество</label>
      <input className="border border-gray-300 p-2 w-full rounded" value={patronymic} onChange={(e) => setPatronymic(e.target.value)} />

      <label className="block font-semibold mb-1">Дата рождения</label>
      <input
        type="date"
        className="border border-gray-300 p-2 w-full rounded"
        value={dateOfBirth}
        onChange={(e) => setDateOfBirth(e.target.value)}
      />

      <label className="block font-semibold mb-1">Рег. Номер</label>
      <input
        type="number"
        className="border border-gray-300 p-2 w-full rounded"
        value={registrationNumber}
        onChange={(e) => setRegistrationNumber(e.target.value)}
      />

      <label className="block font-semibold mb-1">Пол</label>
      <select className="border border-gray-300 p-2 w-full rounded" value={gender} onChange={(e) => setGender(e.target.value)}>
        <option value="Male">Мужской</option>
        <option value="Female">Женский</option>
      </select>

      <label className="block font-semibold mb-1">Дата приема на работу</label>
      <input
        type="date"
        className="border border-gray-300 p-2 w-full rounded"
        value={dateOfHire}
        onChange={(e) => setDateOfHire(e.target.value)}
      />

      <label className="block font-semibold mb-1">Рабочий телефон</label>
      <input className="border border-gray-300 p-2 w-full rounded" value={workPhone} onChange={(e) => setWorkPhone(e.target.value)} />

      <label className="block font-semibold mb-1">Домашний телефон</label>
      <input className="border border-gray-300 p-2 w-full rounded" value={homePhone} onChange={(e) => setHomePhone(e.target.value)} />

      <label className="block font-semibold mb-1">Семейное положение</label>
      <select className="border border-gray-300 p-2 w-full rounded" value={maritalStatus} onChange={(e) => setMaritalStatus(e.target.value)}>
        <option value="Single">Не женат/Не замужем</option>
        <option value="Married">Женат/Замужем</option>
      </select>

      <label className="block font-semibold mb-1">Размер семьи</label>
      <input
        type="number"
        className="border border-gray-300 p-2 w-full rounded"
        value={familySize}
        onChange={(e) => setFamilySize(e.target.value)}
      />

      <label className="block font-semibold mb-1">Число детей</label>
      <input
        type="number"
        className="border border-gray-300 p-2 w-full rounded"
        value={numberOfChildren}
        onChange={(e) => setNumberOfChildren(e.target.value)}
      />

      <label className="block font-semibold mb-1">Членство в профсоюзе</label>
      <input
        type="checkbox"
        className="border border-gray-300 p-2 w-full rounded"
        checked={isUnionMember}
        onChange={(e) => setIsUnionMember(e.target.checked)}
      />

      <h4 className="block font-semibold mb-1">Адрес</h4>
      <label className="block font-semibold mb-1">Улица</label>
      <input className="border border-gray-300 p-2 w-full rounded" value={street} onChange={(e) => setStreet(e.target.value)} />
      <label className="block font-semibold mb-1">Дом</label>
      <input className="border border-gray-300 p-2 w-full rounded" value={houseNumber} onChange={(e) => setHouseNumber(e.target.value)} />
      <label className="block font-semibold mb-1">Город</label>
      <input className="border border-gray-300 p-2 w-full rounded" value={city} onChange={(e) => setCity(e.target.value)} />
      <label className="block font-semibold mb-1">Индекс</label>
      <input className="border border-gray-300 p-2 w-full rounded" value={postalCode} onChange={(e) => setPostalCode(e.target.value)} />
      <label className="block font-semibold mb-1">Страна</label>
      <input className="border border-gray-300 p-2 w-full rounded" value={country} onChange={(e) => setCountry(e.target.value)} />

      <button
        type="submit"
        className="bg-blue-500 hover:bg-blue-600 text-white font-bold py-2 px-4 rounded"
      >
        Создать
      </button>
      {statusMessage && <div className="text-sm font-semibold">{statusMessage}</div>}
    </form>
  )
}