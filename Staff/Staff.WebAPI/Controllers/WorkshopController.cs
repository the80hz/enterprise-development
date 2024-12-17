using Microsoft.AspNetCore.Mvc;
using Staff.Domain.Models;

namespace Staff.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkshopController : ControllerBase
{
    private static readonly List<Workshop> Workshops = new();

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Workshops);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var workshop = Workshops.FirstOrDefault(w => w.WorkshopId == id);
        if (workshop == null)
        {
            return NotFound();
        }
        return Ok(workshop);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Workshop workshop)
    {
        workshop.WorkshopId = Workshops.Count + 1;
        Workshops.Add(workshop);
        return CreatedAtAction(nameof(Get), new { id = workshop.WorkshopId }, workshop);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Workshop updatedWorkshop)
    {
        var workshop = Workshops.FirstOrDefault(w => w.WorkshopId == id);
        if (workshop == null)
        {
            return NotFound();
        }
        workshop.Name = updatedWorkshop.Name;
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
