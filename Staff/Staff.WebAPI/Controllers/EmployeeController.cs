using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Staff.Domain.Context;
using Staff.Domain.Enums;
using Staff.Domain.Models;
using Staff.WebAPI.Dto;

namespace Staff.WebAPI.Controllers;

/// <summary>
/// Контроллер для работы с сотрудниками.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class EmployeeController(IMapper mapper, StaffDbContext context) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private static readonly List<Employee> Employees = [];
    private readonly StaffDbContext _context = context;

    /// <summary>
    /// Получает список всех сотрудников.
    /// </summary>
    /// <returns>Список сотрудников.</returns>
    [HttpGet]
    public IActionResult Get()
    {
        var employeeDtos = _mapper.Map<List<EmployeeDto>>(Employees);
        return Ok(employeeDtos);
    }

    /// <summary>
    /// Получает сотрудника по идентификатору.
    /// </summary>
    /// <param name="id">Регистрационный номер сотрудника.</param>
    /// <returns>Информация о сотруднике.</returns>
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var employee = Employees.FirstOrDefault(e => e.RegistrationNumber == id);
        if (employee == null)
        {
            return NotFound();
        }
        var employeeDto = _mapper.Map<EmployeeDto>(employee);
        return Ok(employeeDto);
    }

    /// <summary>
    /// Добавляет нового сотрудника.
    /// </summary>
    /// <param name="employeeDto">DTO нового сотрудника.</param>
    /// <returns>Результат создания сотрудника.</returns>
    [HttpPost]
    public IActionResult Post([FromBody] EmployeeDto employeeDto)
    {
        var employee = _mapper.Map<Employee>(employeeDto);
        employee.RegistrationNumber = Employees.Count + 1;
        Employees.Add(employee);
        var createdDto = _mapper.Map<EmployeeDto>(employee);
        return CreatedAtAction(nameof(Get), new { id = employee.RegistrationNumber }, createdDto);
    }

    /// <summary>
    /// Обновляет информацию о сотруднике.
    /// </summary>
    /// <param name="id">Регистрационный номер сотрудника.</param>
    /// <param name="updatedEmployeeDto">Обновленные данные сотрудника.</param>
    /// <returns>Результат обновления.</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] EmployeeDto updatedEmployeeDto)
    {
        var employee = Employees.FirstOrDefault(e => e.RegistrationNumber == id);
        if (employee == null)
        {
            return NotFound();
        }
        _mapper.Map(updatedEmployeeDto, employee);
        return NoContent();
    }

    /// <summary>
    /// Удаляет сотрудника.
    /// </summary>
    /// <param name="id">Регистрационный номер сотрудника.</param>
    /// <returns>Результат удаления.</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var employee = Employees.FirstOrDefault(e => e.RegistrationNumber == id);
        if (employee == null)
        {
            return NotFound();
        }
        Employees.Remove(employee);
        return NoContent();
    }

    /// <summary>
    /// Получает сотрудников по идентификатору отдела.
    /// </summary>
    /// <param name="departmentId">Идентификатор отдела.</param>
    /// <returns>Список сотрудников.</returns>
    [HttpGet("ByDepartment/{departmentId}")]
    public async Task<IActionResult> GetByDepartment(int departmentId)
    {
        var employees = await _context.Employees
            .Where(e => e.Departments.Any(d => d.DepartmentId == departmentId))
            .ToListAsync();
        return Ok(employees);
    }

    /// <summary>
    /// Получает сотрудников, работающих в нескольких отделах, упорядоченных по ФИО.
    /// </summary>
    /// <returns>Список сотрудников.</returns>
    [HttpGet("MultiDepartmentEmployees")]
    public async Task<IActionResult> GetEmployeesInMultipleDepartments()
    {
        var employees = await _context.Employees
            .Include(e => e.Departments)
            .Where(e => e.Departments.Count > 1)
            .OrderBy(e => e.Surname)
            .ThenBy(e => e.Name)
            .ThenBy(e => e.Patronymic)
            .ToListAsync();

        var employeeDtos = _mapper.Map<List<EmployeeDto>>(employees);
        return Ok(employeeDtos);
    }

    /// <summary>
    /// Получает сотрудников, получавших льготные профсоюзные путевки в прошлом году определенного вида.
    /// </summary>
    /// <param name="benefitType">Тип льготы.</param>
    /// <returns>Список сотрудников.</returns>
    [HttpGet("UnionBenefitsLastYear")]
    public async Task<IActionResult> GetEmployeesWithUnionBenefitsLastYear([FromQuery] BenefitType? benefitType)
    {
        var lastYear = DateTime.Now.Year - 1;
        var query = _context.Employees
            .Include(e => e.UnionBenefits)
            .Where(e => e.UnionBenefits.Any(ub => ub.DateReceived.Year == lastYear));

        if (benefitType.HasValue)
        {
            query = query.Where(e => e.UnionBenefits.Any(ub => ub.BenefitType == benefitType.Value));
        }

        var employees = await query.ToListAsync();
        var employeeDtos = _mapper.Map<List<EmployeeDto>>(employees);
        return Ok(employeeDtos);
    }

    /// <summary>
    /// Получает топ 5 сотрудников с наибольшим стажем работы.
    /// </summary>
    /// <returns>Список сотрудников.</returns>
    [HttpGet("Top5LongestTenure")]
    public async Task<IActionResult> GetTop5EmployeesWithLongestTenure()
    {
        var employees = await _context.Employees
            .OrderByDescending(e => e.DateOfHire)
            .Take(5)
            .ToListAsync();

        var employeeDtos = _mapper.Map<List<EmployeeDto>>(employees);
        return Ok(employeeDtos);
    }
}
