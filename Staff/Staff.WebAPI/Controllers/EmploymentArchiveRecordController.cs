using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Staff.Domain.Context;
using Staff.Domain.Models;
using Staff.WebAPI.Dto;

namespace Staff.WebAPI.Controllers;

/// <summary>
/// Контроллер для работы с архивными записями о трудоустройстве.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class EmploymentArchiveRecordController(StaffDbContext context, IMapper mapper) : ControllerBase
{
    private readonly StaffDbContext _context = context;
    private readonly IMapper _mapper = mapper;
    private static readonly List<EmploymentArchiveRecord> EmploymentArchiveRecords = [];

    /// <summary>
    /// Получает список всех архивных записей.
    /// </summary>
    /// <returns>Список архивных записей.</returns>
    [HttpGet]
    public IActionResult Get()
    {
        var dtos = _mapper.Map<List<EmploymentArchiveRecordDto>>(EmploymentArchiveRecords);
        return Ok(dtos);
    }

    /// <summary>
    /// Получает архивную запись по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор записи.</param>
    /// <returns>Информация об архивной записи.</returns>
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var record = EmploymentArchiveRecords.FirstOrDefault(r => r.RecordId == id);
        if (record == null)
        {
            return NotFound();
        }
        var dto = _mapper.Map<EmploymentArchiveRecordDto>(record);
        return Ok(dto);
    }

    /// <summary>
    /// Добавляет новую архивную запись.
    /// </summary>
    /// <param name="dto">DTO новой архивной записи.</param>
    /// <returns>Результат создания записи.</returns>
    [HttpPost]
    public IActionResult Post([FromBody] EmploymentArchiveRecordDto dto)
    {
        var record = _mapper.Map<EmploymentArchiveRecord>(dto);
        record.RecordId = EmploymentArchiveRecords.Count + 1;
        EmploymentArchiveRecords.Add(record);
        var createdDto = _mapper.Map<EmploymentArchiveRecordDto>(record);
        return CreatedAtAction(nameof(Get), new { id = record.RecordId }, createdDto);
    }

    /// <summary>
    /// Обновляет информацию об архивной записи.
    /// </summary>
    /// <param name="id">Идентификатор записи.</param>
    /// <param name="updatedDto">Обновленные данные записи.</param>
    /// <returns>Результат обновления.</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] EmploymentArchiveRecordDto updatedDto)
    {
        var record = EmploymentArchiveRecords.FirstOrDefault(r => r.RecordId == id);
        if (record == null)
        {
            return NotFound();
        }
        _mapper.Map(updatedDto, record);
        return NoContent();
    }

    /// <summary>
    /// Удаляет архивную запись.
    /// </summary>
    /// <param name="id">Идентификатор записи.</param>
    /// <returns>Результат удаления.</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var record = EmploymentArchiveRecords.FirstOrDefault(r => r.RecordId == id);
        if (record == null)
        {
            return NotFound();
        }
        EmploymentArchiveRecords.Remove(record);
        return NoContent();
    }

    /// <summary>
    /// Получает архив увольнений сотрудников.
    /// </summary>
    /// <returns>Список записей об увольнениях.</returns>
    [HttpGet("TerminationArchive")]
    public async Task<IActionResult> GetTerminationArchive()
    {
        var records = await _context.EmploymentArchiveRecords
            .Include(ea => ea.Employee)
                .ThenInclude(e => e!.Workshop)
            .Include(ea => ea.Employee)
                .ThenInclude(e => e!.Departments)
            .Include(ea => ea.Employee)
                .ThenInclude(e => e!.Position)
            .Where(ea => ea.EndDate != null && ea.Employee != null)
            .Select(ea => new
            {
                ea.Employee!.RegistrationNumber,
                FullName = $"{ea.Employee.Surname} {ea.Employee.Name} {ea.Employee.Patronymic}",
                ea.Employee.DateOfBirth,
                WorkshopName = ea.Employee.Workshop.Name,
                Departments = ea.Employee.Departments.Select(d => d.Name).ToList(),
                PositionTitle = ea.Employee.Position.Title,
                TerminationDate = ea.EndDate
            })
            .ToListAsync();

        return Ok(records);
    }
}