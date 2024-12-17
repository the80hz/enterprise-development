using Microsoft.AspNetCore.Mvc;
using Staff.Domain.Models;

namespace Staff.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private static readonly List<Department> Departments = new();

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Departments);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var department = Departments.FirstOrDefault(d => d.DepartmentId == id);
        if (department == null)
        {
            return NotFound();
        }
        return Ok(department);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Department department)
    {
        department.DepartmentId = Departments.Count + 1;
        Departments.Add(department);
        return CreatedAtAction(nameof(Get), new { id = department.DepartmentId }, department);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Department updatedDepartment)
    {
        var department = Departments.FirstOrDefault(d => d.DepartmentId == id);
        if (department == null)
        {
            return NotFound();
        }
        department.Name = updatedDepartment.Name;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var department = Departments.FirstOrDefault(d => d.DepartmentId == id);
        if (department == null)
        {
            return NotFound();
        }
        Departments.Remove(department);
        return NoContent();
    }
}
