namespace AdoptApi.Models.Dtos;

public class AddressDto
{
    public string City { get; set; }
    public string Name { get; set; }
    public string ZipCode { get; set; }
    public int? Number { get; set; }
    public string? Complement { get; set; }
}