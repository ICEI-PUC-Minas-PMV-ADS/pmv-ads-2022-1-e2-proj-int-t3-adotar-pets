namespace AdoptApi.Models.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateOnly BirthDate { get; set; }
    public DocumentDto Document { get; set; }
    public AddressDto Address { get; set; }
    
    public PictureDto? Picture { get; set; }
}