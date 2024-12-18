using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Staff.Domain.Context;
using Staff.Domain.Models;
using Staff.WebAPI.Dto;

namespace Staff.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly StaffDbContext _context;
    private readonly IMapper _mapper;

    public DepartmentController(StaffDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var departments = _context.Departments.ToList();
        var dtos = _mapper.Map<List<DepartmentDto>>(departments);
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var department = _context.Departments.FirstOrDefault(d => d.DepartmentId == id);
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
        _context.Departments.Add(department);
        _context.SaveChanges();
        var createdDto = _mapper.Map<DepartmentDto>(department);
        return CreatedAtAction(nameof(Get), new { id = department.DepartmentId }, createdDto);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DepartmentDto updatedDto)
    {
        var department = _context.Departments.FirstOrDefault(d => d.DepartmentId == id);
        if (department == null)
        {
            return NotFound();
        }
        _mapper.Map(updatedDto, department);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var department = _context.Departments.FirstOrDefault(d => d.DepartmentId == id);
        if (department == null)
        {
            return NotFound();
        }
        _context.Departments.Remove(department);
        _context.SaveChanges();
        return NoContent();
    }

    // Аналитический запрос 4: Получить средний возраст сотрудников в каждом отделе
    [HttpGet("AverageAge")]
    public async Task<IActionResult> GetAverageAgeByDepartment()
    {
        var departments = await _context.Departments
            .Include(d => d.Employees)
            .ToListAsync();

        var result = departments.Select(d => new
        {
            DepartmentName = d.Name,
            AverageAge = d.Employees.Count > 0
                ? d.Employees.Average(e => (DateTime.Now - e.DateOfBirth).Days / 365.25)
                : 0
        })
        .ToList();

        return Ok(result);
    }
}