using AdoptApi.Models.Dtos;
using AutoMapper;

namespace AdoptApi.Models.Mappings.Resolvers;

public class PictureResolver : IValueResolver<Picture, PictureDto, string>
{
    private readonly IConfiguration _configuration;

    public PictureResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Resolve(Picture source, PictureDto target, string destMember, ResolutionContext context)
    {
        return $"{_configuration["BlobStorage:BaseUrl"]}/{_configuration["BlobStorage:Container"]}/{source.Url}";
    }
}