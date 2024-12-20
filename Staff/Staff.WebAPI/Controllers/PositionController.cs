using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Staff.Domain.Models;
using Staff.WebAPI.Dto;
using Staff.Domain.Context;

namespace Staff.WebAPI.Controllers;

/// <summary>
/// Контроллер для работы с должностями.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class PositionController(IMapper mapper, StaffDbContext context) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly StaffDbContext _context = context;

    /// <summary>
    /// Получает список всех должностей.
    /// </summary>
    /// <returns>Список должностей.</returns>
    [HttpGet]
    public IActionResult Get()
    {
        var dtos = _mapper.Map<List<PositionDto>>(_context.Positions.ToList());
        return Ok(dtos);
    }

    /// <summary>
    /// Получает должность по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор должности.</param>
    /// <returns>Информация о должности.</returns>
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var position = _context.Positions.FirstOrDefault(p => p.PositionId == id);
        if (position == null)
        {
            return NotFound();
        }
        var dto = _mapper.Map<PositionDto>(position);
        return Ok(dto);
    }

    /// <summary>
    /// Добавляет новую должность.
    /// </summary>
    /// <param name="dto">DTO новой должности.</param>
    /// <returns>Результат создания должности.</returns>
    [HttpPost]
    public IActionResult Post([FromBody] PositionDto dto)
    {
        var position = _mapper.Map<Position>(dto);
        position.PositionId = _context.Positions.Count() + 1;
        _context.Positions.Add(position);
        _context.SaveChanges();
        var createdDto = _mapper.Map<PositionDto>(position);
        return CreatedAtAction(nameof(Get), new { id = position.PositionId }, createdDto);
    }

    /// <summary>
    /// Обновляет информацию о должности.
    /// </summary>
    /// <param name="id">Идентификатор должности.</param>
    /// <param name="updatedDto">Обновленные данные должности.</param>
    /// <returns>Результат обновления.</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] PositionDto updatedDto)
    {
        var position = _context.Positions.FirstOrDefault(p => p.PositionId == id);
        if (position == null)
        {
            return NotFound();
        }
        _mapper.Map(updatedDto, position);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Удаляет должность.
    /// </summary>
    /// <param name="id">Идентификатор должности.</param>
    /// <returns>Результат удаления.</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var position = _context.Positions.FirstOrDefault(p => p.PositionId == id);
        if (position == null)
        {
            return NotFound();
        }
        _context.Positions.Remove(position);
        _context.SaveChanges();
        return NoContent();
    }
}