using SixLabors.ImageSharp;

namespace AdoptApi.Attributes.Extensions;

public static class FormFileExtensions
{
    private static readonly string[] ValidImageContentTypes = {"image/jpg", "image/jpeg", "image/png"};

    private static readonly string[] ValidImageExtensions = {".jpg", ".jpeg", ".png"};

    public static bool IsImage(this IFormFile formFile)
    {
        if (!ValidImageContentTypes.Contains(formFile.ContentType.ToLower()))
        {
            return false;
        }

        if (!ValidImageExtensions.Contains(Path.GetExtension(formFile.FileName).ToLower()))
        {
            return false;
        }

        try
        {
            Image.Identify(formFile.OpenReadStream());
            return true;
        }
        catch (InvalidImageContentException)
        {
            return false;
        }
    }
}