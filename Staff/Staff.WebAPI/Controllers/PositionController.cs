using Microsoft.AspNetCore.Mvc;
using Staff.Domain.Models;

namespace Staff.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PositionController : ControllerBase
{
    private static readonly List<Position> Positions = new();

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Positions);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var position = Positions.FirstOrDefault(p => p.PositionId == id);
        if (position == null)
        {
            return NotFound();
        }
        return Ok(position);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Position position)
    {
        position.PositionId = Positions.Count + 1;
        Positions.Add(position);
        return CreatedAtAction(nameof(Get), new { id = position.PositionId }, position);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Position updatedPosition)
    {
        var position = Positions.FirstOrDefault(p => p.PositionId == id);
        if (position == null)
        {
            return NotFound();
        }
        position.Title = updatedPosition.Title;
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
