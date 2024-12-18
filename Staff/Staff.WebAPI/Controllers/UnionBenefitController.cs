using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Staff.Domain.Models;
using Staff.WebAPI.Dto;

namespace Staff.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UnionBenefitController(IMapper mapper) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private static readonly List<UnionBenefit> UnionBenefits = [];

    [HttpGet]
    public IActionResult Get()
    {
        var dtos = _mapper.Map<List<UnionBenefitDto>>(UnionBenefits);
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var unionBenefit = UnionBenefits.FirstOrDefault(ub => ub.UnionBenefitId == id);
        if (unionBenefit == null)
        {
            return NotFound();
        }
        var dto = _mapper.Map<UnionBenefitDto>(unionBenefit);
        return Ok(dto);
    }

    [HttpPost]
    public IActionResult Post([FromBody] UnionBenefitDto dto)
    {
        var unionBenefit = _mapper.Map<UnionBenefit>(dto);
        unionBenefit.UnionBenefitId = UnionBenefits.Count + 1;
        UnionBenefits.Add(unionBenefit);
        var createdDto = _mapper.Map<UnionBenefitDto>(unionBenefit);
        return CreatedAtAction(nameof(Get), new { id = unionBenefit.UnionBenefitId }, createdDto);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UnionBenefitDto updatedDto)
    {
        var unionBenefit = UnionBenefits.FirstOrDefault(ub => ub.UnionBenefitId == id);
        if (unionBenefit == null)
        {
            return NotFound();
        }
        _mapper.Map(updatedDto, unionBenefit);
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