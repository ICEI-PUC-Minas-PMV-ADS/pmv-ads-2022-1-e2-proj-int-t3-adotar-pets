using AdoptApi.Attributes.Extensions;
using AdoptApi.Enums;
using AdoptApi.Models;
using AdoptApi.Models.Dtos;
using AdoptApi.Repositories;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.StaticFiles;

namespace AdoptApi.Services;

public class ImageUploadService
{
    private readonly IConfiguration _configuration;
    private readonly ModelStateDictionary _modelState;
    private PictureRepository _pictureRepository;
    private BlobContainerClient? _client;

    public ImageUploadService(IConfiguration configuration, IActionContextAccessor actionContextAccessor, PictureRepository repository)
    {
        _configuration = configuration;
        _modelState = actionContextAccessor.ActionContext.ModelState;
        _pictureRepository = repository;
    }

    private BlobContainerClient GetAzureClient()
    {
        if (_client != null)
        {
            return _client;
        }
        var blobStorageConnectionString = _configuration.GetConnectionString("BlobStorage");
        var blobStorageContainerName = _configuration["BlobStorage:Container"];
        if (string.IsNullOrEmpty(blobStorageConnectionString) || string.IsNullOrEmpty(blobStorageContainerName))
        {
            throw new Exception("Não foi possível comunicar com o gateway de storage.");
        }
        _client = new BlobContainerClient(blobStorageConnectionString, blobStorageContainerName);
        return _client;
    }

    private bool IsValidFile(IFormFile file)
    {
        if (!file.IsImage())
        {
            _modelState.AddModelError("Picture", "Imagem inválida.");
        }

        return _modelState.IsValid;
    }

    private async Task<Response<BlobContentInfo>?> UploadBlob(string fileName, IFormFile file)
    {
        var validatedFile = IsValidFile(file);

        if (!validatedFile)
        {
            return null;
        }
        
        try
        {
            var containerClient = GetAzureClient();
            var blobClient = containerClient.GetBlobClient(fileName);

            try
            {
                var provider = new FileExtensionContentTypeProvider();
                if (!provider.TryGetContentType(fileName, out var contentType))
                {
                    contentType = "application/octet-stream";
                }
                var uploadedFile = await blobClient.UploadAsync(file.OpenReadStream(), new BlobHttpHeaders{ContentType = contentType});
                return uploadedFile;
            }
            catch (RequestFailedException)
            {
                _modelState.AddModelError("Picture", "Um erro ocorreu ao fazer o upload da imagem.");
                return null;
            }
        }
        catch (Exception e)
        {
            _modelState.AddModelError("Picture", e.Message);
            return null;
        }
    }
    
    private async Task<Response?> DeleteBlob(string fileName)
    {
        try
        {
            var containerClient = GetAzureClient();
            var blobClient = containerClient.GetBlobClient(fileName);

            try
            {
                return await blobClient.DeleteAsync();
            }
            catch (RequestFailedException)
            {
                _modelState.AddModelError("Picture", "Um erro ocorreu ao remover a imagem.");
                return null;
            }
        }
        catch (Exception e)
        {
            _modelState.AddModelError("Picture", e.Message);
            return null;
        }
    }

    public async Task<Picture?> UploadOne(IFormFile file, PictureType type)
    {
        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName).ToLower();
        var uploadedFile = await UploadBlob(fileName, file);

        if (uploadedFile == null)
        {
            return null;
        }

        return await _pictureRepository.AddPicture(new Picture
        {
            Type = type,
            Url = fileName,
            IsActive = true
        });
    }

    public async Task<Picture?> Delete(Picture picture)
    {
        var deletedFile = await DeleteBlob(picture.Url);

        if (deletedFile == null)
        {
            return null;
        }

        return await _pictureRepository.DeletePicture(picture);
    }
}