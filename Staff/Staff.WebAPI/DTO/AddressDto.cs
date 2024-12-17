namespace Staff.WebAPI.Dto;

public class AddressDto
{
    public int AddressId { get; set; }
    public required string Street { get; set; }
    public required string HouseNumber { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }
    public required string Country { get; set; }
}