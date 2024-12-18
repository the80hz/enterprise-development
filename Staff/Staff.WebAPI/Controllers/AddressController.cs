using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Staff.Domain.Models;
using Staff.WebAPI.Dto;

namespace Staff.WebAPI.Controllers;

/// <summary>
/// Контроллер для работы с адресами сотрудников.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AddressController(IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Маппер для преобразования моделей в DTO и обратно.
    /// </summary>
    private readonly IMapper _mapper = mapper;
    /// <summary>
    /// Список адресов сотрудников.
    /// </summary>
    private static readonly List<Address> Addresses = [];

    /// <summary>
    /// Получает все адреса сотрудников.
    /// </summary>
    /// <returns>Список адресов сотрудников.</returns>
    [HttpGet]
    public IActionResult Get()
    {
        var dtos = _mapper.Map<List<AddressDto>>(Addresses);
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
        var address = Addresses.FirstOrDefault(a => a.AddressId == id);
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
        address.AddressId = Addresses.Count + 1;
        Addresses.Add(address);
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
        var address = Addresses.FirstOrDefault(a => a.AddressId == id);
        if (address == null)
        {
            return NotFound();
        }
        _mapper.Map(updatedDto, address);
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
        var address = Addresses.FirstOrDefault(a => a.AddressId == id);
        if (address == null)
        {
            return NotFound();
        }
        Addresses.Remove(address);
        return NoContent();
    }
}