using System.Security.Cryptography;
using System.Text;
using AdoptApi.Models;
using AdoptApi.Models.Dtos;
using AdoptApi.Repositories;
using AdoptApi.Requests;
using AdoptApi.Services.Dtos;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace AdoptApi.Services;

public class UserService
{

    private readonly IConfiguration _configuration;
    private readonly ModelStateDictionary _modelState;
    private UserRepository _userRepository;

    public UserService(IConfiguration configuration, IActionContextAccessor actionContextAccessor, UserRepository repository)
    {
        _configuration = configuration;
        _modelState = actionContextAccessor.ActionContext.ModelState;
        _userRepository = repository;
    }

    private static string EncryptPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        return Convert.ToBase64String(sha256.ComputeHash(passwordBytes));
    }

    private async Task<bool> ValidateAddress(Address address)
    {
        try
        {
            var apiToken = _configuration["CepAberto:Token"];
            if (string.IsNullOrEmpty(apiToken))
            {
                throw new Exception("Não foi possível comunicar com o gateway de CEP.");
            }
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Token token={apiToken}");
            HttpResponseMessage response = await client.GetAsync($"https://www.cepaberto.com/api/v3/cep?cep={address.ZipCode}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            CepAbertoDto cepAbertoDto = JsonConvert.DeserializeObject<CepAbertoDto>(responseBody);
            address.City = cepAbertoDto.cidade.nome;
            address.Name = cepAbertoDto.logradouro;
            address.Latitude = float.Parse(cepAbertoDto.latitude);
            address.Longitude = float.Parse(cepAbertoDto.longitude);
        }
        catch (JsonSerializationException)
        {
            _modelState.AddModelError("Address.ZipCode", "Não foi possível extrair dados do CEP fornecido.");
        }
        catch (Exception e)
        {
            _modelState.AddModelError("Address.ZipCode", e.Message);
        }
        return _modelState.IsValid;
    }

    private async Task<bool> ValidateNewUser(User user)
    {
        var userExists = await _userRepository.UserEmailExists(user.Email);
        if (userExists)
        {
            _modelState.AddModelError("User.Email", "Já existe um usuário cadastrado com este e-mail.");
        }

        var documentExists = await _userRepository.UserDocumentExists(user.Document.Number);
        if (documentExists)
        {
            _modelState.AddModelError("Document.Number", "Já existe um usuário cadastrado com este documento.");
        }
        return _modelState.IsValid;
    }

    private static UserDto GetUserDto(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            BirthDate = user.BirthDate,
            Address = new AddressDto {
                City = user.Address.City,
                Name = user.Address.Name,
                ZipCode = user.Address.ZipCode
            },
            Document = new DocumentDto {
                Number = user.Document.Number,
                Type = user.Document.Type
            }
        };
    }

    public async Task<TokenDto?> Login(UserLoginRequest request, TokenService tokenService)
    {
        try
        {
            var user = await _userRepository.GetUserEmailAndByPassword(request.Email, EncryptPassword(request.Password));
            return new TokenDto {User = GetUserDto(user), Token = tokenService.GenerateToken(user)};
        }
        catch (InvalidOperationException)
        {
            _modelState.AddModelError("User.Email", "E-mail ou senha não coincidem.");
            return null;
        }
    }

    public async Task<UserDto?> Register(CreateUserRequest request)
    {
        var documentDto = request.Document;
        var document = new Document {Type = documentDto.Type, Number = documentDto.Number};
        var addressDto = request.Address;
        var address = new Address {ZipCode = addressDto.ZipCode};
        var addressValidation = await ValidateAddress(address);
        if (!addressValidation)
        {
            return null;
        }
        var userDto = request.User;
        var user = new User {Email = userDto.Email.ToLower(), Name = userDto.Name, Type = userDto.Type, BirthDate = DateOnly.ParseExact(userDto.BirthDate, "yyyy-MM-dd"), Password = EncryptPassword(userDto.Password), Document = document, Address = address};
        var userValidation = await ValidateNewUser(user);
        if (!userValidation)
        {
            return null;
        }
        var createdUser = await _userRepository.CreateUser(user);
        return GetUserDto(createdUser);
    }
    
    public async Task<UserDto?> GetInfo(int userId)
    {
        try
        {
            var user = await _userRepository.GetUserById(userId);
            return GetUserDto(user);
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }

    // @TODO: implementar regra de negócio chamando o método UpdateUser no UserRepository
    // public async Task<UserDto?> UpdateInfo(UpdateProfileRequest request)
    // {
    //     
    // }

}