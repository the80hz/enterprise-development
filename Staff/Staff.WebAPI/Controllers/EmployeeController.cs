using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Staff.Domain.Models;
using Staff.WebAPI.Dto;

namespace Staff.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IMapper _mapper;
    private static readonly List<Employee> Employees = new();

    public EmployeeController(IMapper mapper)
    {
        _mapper = mapper;
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
}
