using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Staff.Domain.Models;
using Staff.WebAPI.Dto;

namespace Staff.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController(IMapper mapper) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private static readonly List<Address> Addresses = [];

    [HttpGet]
    public IActionResult Get()
    {
        var dtos = _mapper.Map<List<AddressDto>>(Addresses);
        return Ok(dtos);
    }

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

    [HttpPost]
    public IActionResult Post([FromBody] AddressDto dto)
    {
        var address = _mapper.Map<Address>(dto);
        address.AddressId = Addresses.Count + 1;
        Addresses.Add(address);
        var createdDto = _mapper.Map<AddressDto>(address);
        return CreatedAtAction(nameof(Get), new { id = address.AddressId }, createdDto);
    }

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