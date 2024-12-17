using Microsoft.AspNetCore.Mvc;
using Staff.Domain.Models;

namespace Staff.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController : ControllerBase
{
    private static readonly List<Address> Addresses = new();

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Addresses);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var address = Addresses.FirstOrDefault(a => a.AddressId == id);
        if (address == null)
        {
            return NotFound();
        }
        return Ok(address);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Address address)
    {
        address.AddressId = Addresses.Count + 1;
        Addresses.Add(address);
        return CreatedAtAction(nameof(Get), new { id = address.AddressId }, address);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Address updatedAddress)
    {
        var address = Addresses.FirstOrDefault(a => a.AddressId == id);
        if (address == null)
        {
            return NotFound();
        }
        address.Street = updatedAddress.Street;
        address.HouseNumber = updatedAddress.HouseNumber;
        address.City = updatedAddress.City;
        address.PostalCode = updatedAddress.PostalCode;
        address.Country = updatedAddress.Country;
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
