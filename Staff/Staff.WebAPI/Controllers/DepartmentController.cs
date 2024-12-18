using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Staff.Domain.Context;
using Staff.Domain.Models;
using Staff.WebAPI.Dto;

namespace Staff.WebAPI.Controllers;

/// <summary>
/// Контроллер для работы с отделами.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class DepartmentController(StaffDbContext context, IMapper mapper) : ControllerBase
{
    private readonly StaffDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// Получает список всех отделов.
    /// </summary>
    /// <returns>Список отделов.</returns>
    [HttpGet]
    public IActionResult Get()
    {
        var departments = _context.Departments.ToList();
        var dtos = _mapper.Map<List<DepartmentDto>>(departments);
        return Ok(dtos);
    }

    /// <summary>
    /// Получает отдел по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор отдела.</param>
    /// <returns>Информация об отделе.</returns>
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

    /// <summary>
    /// Создает новый отдел.
    /// </summary>
    /// <param name="dto">DTO нового отдела.</param>
    /// <returns>Результат создания отдела.</returns>
    [HttpPost]
    public IActionResult Post([FromBody] DepartmentDto dto)
    {
        var department = _mapper.Map<Department>(dto);
        _context.Departments.Add(department);
        _context.SaveChanges();
        var createdDto = _mapper.Map<DepartmentDto>(department);
        return CreatedAtAction(nameof(Get), new { id = department.DepartmentId }, createdDto);
    }

    /// <summary>
    /// Обновляет информацию об отделе.
    /// </summary>
    /// <param name="id">Идентификатор отдела.</param>
    /// <param name="updatedDto">Обновленные данные отдела.</param>
    /// <returns>Результат обновления.</returns>
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

    /// <summary>
    /// Удаляет отдел.
    /// </summary>
    /// <param name="id">Идентификатор отдела.</param>
    /// <returns>Результат удаления.</returns>
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

    /// <summary>
    /// Получает средний возраст сотрудников по отделам.
    /// </summary>
    /// <returns>Список отделов со средним возрастом сотрудников.</returns>
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