using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Staff.Domain.Models;
using Staff.WebAPI.Dto;

namespace Staff.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PositionController : ControllerBase
{
    private readonly IMapper _mapper;
    private static readonly List<Position> Positions = new();

    public PositionController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var dtos = _mapper.Map<List<PositionDto>>(Positions);
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var position = Positions.FirstOrDefault(p => p.PositionId == id);
        if (position == null)
        {
            return NotFound();
        }
        var dto = _mapper.Map<PositionDto>(position);
        return Ok(dto);
    }

    [HttpPost]
    public IActionResult Post([FromBody] PositionDto dto)
    {
        var position = _mapper.Map<Position>(dto);
        position.PositionId = Positions.Count + 1;
        Positions.Add(position);
        var createdDto = _mapper.Map<PositionDto>(position);
        return CreatedAtAction(nameof(Get), new { id = position.PositionId }, createdDto);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] PositionDto updatedDto)
    {
        var position = Positions.FirstOrDefault(p => p.PositionId == id);
        if (position == null)
        {
            return NotFound();
        }
        _mapper.Map(updatedDto, position);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var position = Positions.FirstOrDefault(p => p.PositionId == id);
        if (position == null)
        {
            return NotFound();
        }
        Positions.Remove(position);
        return NoContent();
    }
}