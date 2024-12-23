// ...existing code...
import { CreateEmployeeForm } from './CreateEmployeeForm'

export function StaffClient() {
  const [employees, setEmployees] = useState([])

  const loadEmployees = () => {
    fetch('http://localhost:5032/api/Employee')
      .then((response) => response.json())
      .then((data) => setEmployees(data))
      .catch(console.error)
  }

  useEffect(() => {
    loadEmployees()
  }, [])

  return (
    <div>
      <h2>Сотрудники</h2>
      <CreateEmployeeForm onCreated={loadEmployees} />
      <ul>
        {employees.map((emp) => (
          <li key={emp.registrationNumber}>
            {emp.surname} {emp.name} ({emp.registrationNumber})
          </li>
        ))}
      </ul>
    </div>
  )
}