using Microsoft.AspNetCore.Mvc;
using Staff.Domain.Models;

namespace Staff.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmploymentArchiveRecordController : ControllerBase
{
    private static readonly List<EmploymentArchiveRecord> EmploymentArchiveRecords = new();

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(EmploymentArchiveRecords);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var record = EmploymentArchiveRecords.FirstOrDefault(r => r.Id == id);
        if (record == null)
        {
            return NotFound();
        }
        return Ok(record);
    }

    [HttpPost]
    public IActionResult Post([FromBody] EmploymentArchiveRecord record)
    {
        record.Id = EmploymentArchiveRecords.Count + 1;
        EmploymentArchiveRecords.Add(record);
        return CreatedAtAction(nameof(Get), new { id = record.Id }, record);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] EmploymentArchiveRecord updatedRecord)
    {
        var record = EmploymentArchiveRecords.FirstOrDefault(r => r.Id == id);
        if (record == null)
        {
            return NotFound();
        }
        record.StartDate = updatedRecord.StartDate;
        record.EndDate = updatedRecord.EndDate;
        record.Position = updatedRecord.Position;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var record = EmploymentArchiveRecords.FirstOrDefault(r => r.Id == id);
        if (record == null)
        {
            return NotFound();
        }
        EmploymentArchiveRecords.Remove(record);
        return NoContent();
    }
}
