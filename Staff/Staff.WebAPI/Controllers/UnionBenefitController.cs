using Microsoft.AspNetCore.Mvc;
using Staff.Domain.Models;

namespace Staff.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UnionBenefitController : ControllerBase
{
    private static readonly List<UnionBenefit> UnionBenefits = new();

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(UnionBenefits);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var unionBenefit = UnionBenefits.FirstOrDefault(ub => ub.UnionBenefitId == id);
        if (unionBenefit == null)
        {
            return NotFound();
        }
        return Ok(unionBenefit);
    }

    [HttpPost]
    public IActionResult Post([FromBody] UnionBenefit unionBenefit)
    {
        unionBenefit.UnionBenefitId = UnionBenefits.Count + 1;
        UnionBenefits.Add(unionBenefit);
        return CreatedAtAction(nameof(Get), new { id = unionBenefit.UnionBenefitId }, unionBenefit);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UnionBenefit updatedUnionBenefit)
    {
        var unionBenefit = UnionBenefits.FirstOrDefault(ub => ub.UnionBenefitId == id);
        if (unionBenefit == null)
        {
            return NotFound();
        }
        unionBenefit.BenefitType = updatedUnionBenefit.BenefitType;
        unionBenefit.DateReceived = updatedUnionBenefit.DateReceived;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var unionBenefit = UnionBenefits.FirstOrDefault(ub => ub.UnionBenefitId == id);
        if (unionBenefit == null)
        {
            return NotFound();
        }
        UnionBenefits.Remove(unionBenefit);
        return NoContent();
    }
}
