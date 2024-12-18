using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Staff.Domain.Models;
using Staff.WebAPI.Dto;
using Microsoft.EntityFrameworkCore;
using Staff.Domain.Context;
using Staff.Domain.Enums;

namespace Staff.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IMapper _mapper;
    private static readonly List<Employee> Employees = new();
    private readonly StaffDbContext _context;

    public EmployeeController(IMapper mapper, StaffDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var employeeDtos = _mapper.Map<List<EmployeeDto>>(Employees);
        return Ok(employeeDtos);
    }

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

    [HttpPost]
    public IActionResult Post([FromBody] EmployeeDto employeeDto)
    {
        var employee = _mapper.Map<Employee>(employeeDto);
        employee.RegistrationNumber = Employees.Count + 1;
        Employees.Add(employee);
        var createdDto = _mapper.Map<EmployeeDto>(employee);
        return CreatedAtAction(nameof(Get), new { id = employee.RegistrationNumber }, createdDto);
    }

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

    [HttpGet("ByDepartment/{departmentId}")]
    public async Task<IActionResult> GetByDepartment(int departmentId)
    {
        var employees = await _context.Employees
            .Where(e => e.Departments.Any(d => d.DepartmentId == departmentId))
            .ToListAsync();
        return Ok(employees);
    }

    // Аналитический запрос 2: Получить сотрудников, работающих в нескольких отделах, упорядоченных по ФИО
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

    // Аналитический запрос 5: Получить сотрудников, получавших льготные профсоюзные путевки в прошлом году определенного вида
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

    // Аналитический запрос 6: Получить топ 5 сотрудников с наибольшим стажем работы
    [HttpGet("Top5LongestTenure")]
    public async Task<IActionResult> GetTop5EmployeesWithLongestTenure()
    {
        var employees = await _context.Employees
            .OrderBy(e => e.DateOfHire)
            .Take(5)
            .ToListAsync();

        var employeeDtos = _mapper.Map<List<EmployeeDto>>(employees);
        return Ok(employeeDtos);
    }
}
