using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Staff.Domain.Models;
using Staff.WebAPI.Dto;

namespace Staff.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IMapper _mapper;
    private static readonly List<Department> Departments = new();

    public DepartmentController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var dtos = _mapper.Map<List<DepartmentDto>>(Departments);
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var department = Departments.FirstOrDefault(d => d.DepartmentId == id);
        if (department == null)
        {
            return NotFound();
        }
        var dto = _mapper.Map<DepartmentDto>(department);
        return Ok(dto);
    }

    [HttpPost]
    public IActionResult Post([FromBody] DepartmentDto dto)
    {
        var department = _mapper.Map<Department>(dto);
        department.DepartmentId = Departments.Count + 1;
        Departments.Add(department);
        var createdDto = _mapper.Map<DepartmentDto>(department);
        return CreatedAtAction(nameof(Get), new { id = department.DepartmentId }, createdDto);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DepartmentDto updatedDto)
    {
        var department = Departments.FirstOrDefault(d => d.DepartmentId == id);
        if (department == null)
        {
            return NotFound();
        }
        _mapper.Map(updatedDto, department);
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