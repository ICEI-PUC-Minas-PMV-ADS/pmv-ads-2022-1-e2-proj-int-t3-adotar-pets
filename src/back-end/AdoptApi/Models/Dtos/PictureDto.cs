namespace AdoptApi.Models.Dtos;

public class PictureDto
{
    private readonly string _baseUrl;
    private string _url = "";

    public string Url
    {
        get => _url;
        set => _url = $"{_baseUrl}/{value}";
    }

    public PictureDto(IConfiguration configuration)
    {
        _baseUrl = $"{configuration["BlobStorage:BaseUrl"]}/{configuration["BlobStorage:Container"]}";
    }
}