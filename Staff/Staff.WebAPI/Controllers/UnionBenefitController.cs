using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Staff.Domain.Models;
using Staff.WebAPI.Dto;
using Staff.Domain.Context;

namespace Staff.WebAPI.Controllers;

/// <summary>
/// Контроллер для работы с профсоюзными льготами.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UnionBenefitController(IMapper mapper, StaffDbContext context) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly StaffDbContext _context = context;

    /// <summary>
    /// Получает список всех профсоюзных льгот.
    /// </summary>
    /// <returns>Список льгот.</returns>
    [HttpGet]
    public IActionResult Get()
    {
        var dtos = _mapper.Map<List<UnionBenefitDto>>(_context.UnionBenefits.ToList());
        return Ok(dtos);
    }

    /// <summary>
    /// Получает льготу по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор льготы.</param>
    /// <returns>Информация о льготе.</returns>
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var unionBenefit = _context.UnionBenefits.FirstOrDefault(ub => ub.UnionBenefitId == id);
        if (unionBenefit == null)
        {
            return NotFound();
        }
        var dto = _mapper.Map<UnionBenefitDto>(unionBenefit);
        return Ok(dto);
    }

    /// <summary>
    /// Добавляет новую льготу.
    /// </summary>
    /// <param name="dto">DTO новой льготы.</param>
    /// <returns>Результат создания льготы.</returns>
    [HttpPost]
    public IActionResult Post([FromBody] UnionBenefitDto dto)
    {
        var unionBenefit = _mapper.Map<UnionBenefit>(dto);
        unionBenefit.UnionBenefitId = _context.UnionBenefits.Count() + 1;
        _context.UnionBenefits.Add(unionBenefit);
        _context.SaveChanges();
        var createdDto = _mapper.Map<UnionBenefitDto>(unionBenefit);
        return CreatedAtAction(nameof(Get), new { id = unionBenefit.UnionBenefitId }, createdDto);
    }

    /// <summary>
    /// Обновляет информацию о льготе.
    /// </summary>
    /// <param name="id">Идентификатор льготы.</param>
    /// <param name="updatedDto">Обновленные данные льготы.</param>
    /// <returns>Результат обновления.</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UnionBenefitDto updatedDto)
    {
        var unionBenefit = _context.UnionBenefits.FirstOrDefault(ub => ub.UnionBenefitId == id);
        if (unionBenefit == null)
        {
            return NotFound();
        }
        _mapper.Map(updatedDto, unionBenefit);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Удаляет льготу.
    /// </summary>
    /// <param name="id">Идентификатор льготы.</param>
    /// <returns>Результат удаления.</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var unionBenefit = _context.UnionBenefits.FirstOrDefault(ub => ub.UnionBenefitId == id);
        if (unionBenefit == null)
        {
            return NotFound();
        }
        _context.UnionBenefits.Remove(unionBenefit);
        _context.SaveChanges();
        return NoContent();
    }
}