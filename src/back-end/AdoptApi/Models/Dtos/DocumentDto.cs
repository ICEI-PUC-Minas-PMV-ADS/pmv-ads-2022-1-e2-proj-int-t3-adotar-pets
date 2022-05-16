using AdoptApi.Enums;

namespace AdoptApi.Models.Dtos;

public class DocumentDto
{
    public DocumentType Type { get; set; }
    public string Number { get; set; }
}