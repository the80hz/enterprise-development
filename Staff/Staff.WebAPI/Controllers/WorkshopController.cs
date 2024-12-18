using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Staff.Domain.Models;
using Staff.WebAPI.Dto;

namespace Staff.WebAPI.Controllers;

/// <summary>
/// Контроллер для работы с цехами.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class WorkshopController(IMapper mapper) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private static readonly List<Workshop> Workshops = [];

    /// <summary>
    /// Получает список всех цехов.
    /// </summary>
    /// <returns>Список цехов.</returns>
    [HttpGet]
    public IActionResult Get()
    {
        var dtos = _mapper.Map<List<WorkshopDto>>(Workshops);
        return Ok(dtos);
    }

    /// <summary>
    /// Получает цех по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор цеха.</param>
    /// <returns>Информация о цехе.</returns>
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var workshop = Workshops.FirstOrDefault(w => w.WorkshopId == id);
        if (workshop == null)
        {
            return NotFound();
        }
        var dto = _mapper.Map<WorkshopDto>(workshop);
        return Ok(dto);
    }

    /// <summary>
    /// Добавляет новый цех.
    /// </summary>
    /// <param name="dto">DTO нового цеха.</param>
    /// <returns>Результат создания цеха.</returns>
    [HttpPost]
    public IActionResult Post([FromBody] WorkshopDto dto)
    {
        var workshop = _mapper.Map<Workshop>(dto);
        workshop.WorkshopId = Workshops.Count + 1;
        Workshops.Add(workshop);
        var createdDto = _mapper.Map<WorkshopDto>(workshop);
        return CreatedAtAction(nameof(Get), new { id = workshop.WorkshopId }, createdDto);
    }

    /// <summary>
    /// Обновляет информацию о цехе.
    /// </summary>
    /// <param name="id">Идентификатор цеха.</param>
    /// <param name="updatedDto">Обновленные данные цеха.</param>
    /// <returns>Результат обновления.</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] WorkshopDto updatedDto)
    {
        var workshop = Workshops.FirstOrDefault(w => w.WorkshopId == id);
        if (workshop == null)
        {
            return NotFound();
        }
        _mapper.Map(updatedDto, workshop);
        return NoContent();
    }

    /// <summary>
    /// Удаляет цех.
    /// </summary>
    /// <param name="id">Идентификатор цеха.</param>
    /// <returns>Результат удаления.</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var workshop = Workshops.FirstOrDefault(w => w.WorkshopId == id);
        if (workshop == null)
        {
            return NotFound();
        }
        Workshops.Remove(workshop);
        return NoContent();
    }
}