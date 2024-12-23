import { useState } from 'react'

export function CreateEmployeeForm({ onCreated }) {
  const [name, setName] = useState('')
  const [surname, setSurname] = useState('')
  const [registrationNumber, setRegistrationNumber] = useState('')

  const handleSubmit = async (e) => {
    e.preventDefault()
    try {
      const response = await fetch('http://localhost:5032/api/Employee', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ name, surname, registrationNumber }),
      })
      if (response.ok) {
        setName('')
        setSurname('')
        setRegistrationNumber('')
        onCreated && onCreated()
      }
    } catch (error) {
      console.error(error)
    }
  }

  return (
    <form onSubmit={handleSubmit}>
      <label>Имя</label>
      <input value={name} onChange={(e) => setName(e.target.value)} />

      <label>Фамилия</label>
      <input value={surname} onChange={(e) => setSurname(e.target.value)} />

      <label>Рег. Номер</label>
      <input
        value={registrationNumber}
        onChange={(e) => setRegistrationNumber(e.target.value)}
      />

      <button type="submit">Создать</button>
    </form>
  )
}