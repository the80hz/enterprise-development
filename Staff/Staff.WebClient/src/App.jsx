import { useState } from 'react'

import { StaffClient } from './components/StaffClient'
import { CreateEmployeeForm } from './components/CreateEmployeeForm'

import './App.css'

function App() {
  return (
    <>
      <StaffClient />
      <CreateEmployeeForm />
    </>
  )
}

export default App
