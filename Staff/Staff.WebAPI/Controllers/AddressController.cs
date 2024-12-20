using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Staff.Domain.Models;
using Staff.WebAPI.Dto;
using Staff.Domain.Context;

namespace Staff.WebAPI.Controllers;

/// <summary>
/// Контроллер для работы с адресами сотрудников.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AddressController(IMapper mapper, StaffDbContext context) : ControllerBase
{
    /// <summary>
    /// Маппер для преобразования моделей в DTO и обратно.
    /// </summary>
    private readonly IMapper _mapper = mapper;
    private readonly StaffDbContext _context = context;

    /// <summary>
    /// Получает все адреса сотрудников.
    /// </summary>
    /// <returns>Список адресов сотрудников.</returns>
    [HttpGet]
    public IActionResult Get()
    {
        var dtos = _mapper.Map<List<AddressDto>>(_context.Addresses.ToList());
        return Ok(dtos);
    }

    /// <summary>
    /// Получает адрес сотрудника по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор адреса.</param>
    /// <returns>Адрес сотрудника.</returns>
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var address = _context.Addresses.FirstOrDefault(a => a.AddressId == id);
        if (address == null)
        {
            return NotFound();
        }
        var dto = _mapper.Map<AddressDto>(address);
        return Ok(dto);
    }

    /// <summary>
    /// Добавляет новый адрес сотрудника.
    /// </summary>
    /// <param name="dto">DTO нового адреса.</param>
    /// <returns>Результат добавления нового адреса.</returns>
    [HttpPost]
    public IActionResult Post([FromBody] AddressDto dto)
    {
        var address = _mapper.Map<Address>(dto);
        address.AddressId = _context.Addresses.Count() + 1;
        _context.Addresses.Add(address);
        _context.SaveChanges();
        var createdDto = _mapper.Map<AddressDto>(address);
        return CreatedAtAction(nameof(Get), new { id = address.AddressId }, createdDto);
    }

    /// <summary>
    /// Обновляет существующий адрес сотрудника.
    /// </summary>
    /// <param name="id">Идентификатор адреса для обновления.</param>
    /// <param name="updatedDto">DTO с обновленными данными адреса.</param>
    /// <returns>Результат обновления адреса.</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] AddressDto updatedDto)
    {
        var address = _context.Addresses.FirstOrDefault(a => a.AddressId == id);
        if (address == null)
        {
            return NotFound();
        }
        _mapper.Map(updatedDto, address);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Удаляет адрес сотрудника по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор адреса для удаления.</param>
    /// <returns>Результат удаления адреса.</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var address = _context.Addresses.FirstOrDefault(a => a.AddressId == id);
        if (address == null)
        {
            return NotFound();
        }
        _context.Addresses.Remove(address);
        _context.SaveChanges();
        return NoContent();
    }
}