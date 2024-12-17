using Microsoft.AspNetCore.Mvc;
using Staff.Domain.Models;

namespace Staff.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private static readonly List<Employee> Employees = new();

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Employees);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var employee = Employees.FirstOrDefault(e => e.RegistrationNumber == id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Employee employee)
    {
        employee.RegistrationNumber = Employees.Count + 1;
        Employees.Add(employee);
        return CreatedAtAction(nameof(Get), new { id = employee.RegistrationNumber }, employee);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Employee updatedEmployee)
    {
        var employee = Employees.FirstOrDefault(e => e.RegistrationNumber == id);
        if (employee == null)
        {
            return NotFound();
        }
        employee.Surname = updatedEmployee.Surname;
        employee.Name = updatedEmployee.Name;
        employee.Patronymic = updatedEmployee.Patronymic;
        employee.DateOfBirth = updatedEmployee.DateOfBirth;
        employee.Gender = updatedEmployee.Gender;
        employee.DateOfHire = updatedEmployee.DateOfHire;
        employee.Departments = updatedEmployee.Departments;
        employee.Workshop = updatedEmployee.Workshop;
        employee.Position = updatedEmployee.Position;
        employee.Address = updatedEmployee.Address;
        employee.WorkPhone = updatedEmployee.WorkPhone;
        employee.HomePhone = updatedEmployee.HomePhone;
        employee.MaritalStatus = updatedEmployee.MaritalStatus;
        employee.FamilySize = updatedEmployee.FamilySize;
        employee.NumberOfChildren = updatedEmployee.NumberOfChildren;
        employee.EmploymentArchive = updatedEmployee.EmploymentArchive;
        employee.IsUnionMember = updatedEmployee.IsUnionMember;
        employee.UnionBenefits = updatedEmployee.UnionBenefits;
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
