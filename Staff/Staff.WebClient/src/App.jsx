import { useState } from 'react'
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import { EmployeePage } from './components/employee/EmployeePage';
import { DepartmentPage } from './components/department/DepartmentPage';
import { PositionPage } from './components/position/PositionPage';
import { WorkshopPage } from './components/workshop/WorkshopPage';
import { AddressPage } from './components/address/AddressPage';
import { ArchiveRecordPage } from './components/record/ArchiveRecordPage';
import { UnionBenefitPage } from './components/union/UnionBenefitPage';

import './App.css'

function App() {
  return (
    <Router>
      <div className="min-h-screen bg-gray-100">
        <nav className="bg-white shadow-lg mb-8">
          <div className="container mx-auto px-6 py-4">
            <ul className="flex space-x-8">
              <li>
                <Link to="/" className="text-gray-700 hover:text-blue-500">Сотрудники</Link>
              </li>
              <li>
                <Link to="/departments" className="text-gray-700 hover:text-blue-500">Отделы</Link>
              </li>
              <li>
                <Link to="/positions" className="text-gray-700 hover:text-blue-500">Должности</Link>
              </li>
              <li>
                <Link to="/workshops" className="text-gray-700 hover:text-blue-500">Цеха</Link>
              </li>
              <li>
                <Link to="/addresses" className="text-gray-700 hover:text-blue-500">Адреса</Link>
              </li>
              <li>
                <Link to="/record" className="text-gray-700 hover:text-blue-500">Архив</Link>
              </li>
              <li>
                <Link to="/benefits" className="text-gray-700 hover:text-blue-500">Льготы</Link>
              </li>
            </ul>
          </div>
        </nav>

        <Routes>
          <Route path="/" element={<EmployeePage />} />
          <Route path="/departments" element={<DepartmentPage />} />
          <Route path="/positions" element={<PositionPage />} />
          <Route path="/workshops" element={<WorkshopPage />} />
          <Route path="/addresses" element={<AddressPage />} />
          <Route path="/record" element={<ArchiveRecordPage />} />
          <Route path="/benefits" element={<UnionBenefitPage />} />
        </Routes>
      </div>
    </Router>
  )
}

export default App
