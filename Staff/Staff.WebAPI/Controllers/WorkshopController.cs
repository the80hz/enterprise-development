using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Staff.Domain.Models;
using Staff.WebAPI.Dto;

namespace Staff.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkshopController(IMapper mapper) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private static readonly List<Workshop> Workshops = [];

    [HttpGet]
    public IActionResult Get()
    {
        var dtos = _mapper.Map<List<WorkshopDto>>(Workshops);
        return Ok(dtos);
    }

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

    [HttpPost]
    public IActionResult Post([FromBody] WorkshopDto dto)
    {
        var workshop = _mapper.Map<Workshop>(dto);
        workshop.WorkshopId = Workshops.Count + 1;
        Workshops.Add(workshop);
        var createdDto = _mapper.Map<WorkshopDto>(workshop);
        return CreatedAtAction(nameof(Get), new { id = workshop.WorkshopId }, createdDto);
    }

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