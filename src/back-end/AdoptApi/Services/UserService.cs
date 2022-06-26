using System.Security.Cryptography;
using System.Text;
using AdoptApi.Enums;
using AdoptApi.Models;
using AdoptApi.Models.Dtos;
using AdoptApi.Repositories;
using AdoptApi.Requests;
using AdoptApi.Requests.Dtos;
using AdoptApi.Services.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace AdoptApi.Services;

public class UserService
{

    private readonly IConfiguration _configuration;
    private readonly ModelStateDictionary _modelState;
    private UserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IConfiguration configuration, IActionContextAccessor actionContextAccessor, UserRepository repository, IMapper mapper)
    {
        _configuration = configuration;
        _modelState = actionContextAccessor.ActionContext.ModelState;
        _userRepository = repository;
        _mapper = mapper;
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
    
    private async Task<bool> ValidateCurrentUser(User user, UserEditRequestDto request)
    {
        if (request.Email == user.Email)
        {
            return true;
        }
        
        var userExists = await _userRepository.UserEmailExists(request.Email);
        if (userExists)
        {
            _modelState.AddModelError("User.Email", "Já existe um usuário cadastrado com este e-mail.");
        }
        
        return _modelState.IsValid;
    }
    
    private bool ValidateUserPassword(User user, UpdatePassword request)
    {
        if (EncryptPassword(request.CurrentPassword) != user.Password)
        {
            _modelState.AddModelError(nameof(request.CurrentPassword), "A senha não corresponde à senha atual.");
        }
        
        if (EncryptPassword(request.NewPassword) == user.Password)
        {
            _modelState.AddModelError(nameof(request.NewPassword), "Sua nova senha não pode ser igual à senha atual.");
        }
        
        return _modelState.IsValid;
    }
    
    private UserDto GetUserDto(User user)
    {
        return _mapper.Map<User, UserDto>(user);
    }

    public async Task<TokenDto?> Login(UserLoginRequest request, TokenService tokenService)
    {
        try
        {
            var user = await _userRepository.GetUserEmailAndByPassword(request.User.Email, EncryptPassword(request.User.Password));
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
        var user = new User {Email = userDto.Email.ToLower(), Name = userDto.Name, Type = userDto.Type, BirthDate = DateOnly.ParseExact(userDto.BirthDate, "yyyy-MM-dd"), Password = EncryptPassword(userDto.Password), IsActive = true, Document = document, Address = address};
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

    
    public async Task<UserDto?> UpdateInfo(int userId, UpdateProfileRequest request)
    {
        try
        {
            var user = await _userRepository.GetUserById(userId);
            var userEditDto = request.User;
            var userValidated = await ValidateCurrentUser(user, userEditDto);
            if (!userValidated)
            {
                return null;
            }
            user.Name = Utils.FieldUtils.UpdateFieldOrUseDefault(userEditDto.Name, user.Name)!;
            user.Email = Utils.FieldUtils.UpdateFieldOrUseDefault(userEditDto.Email, user.Email)!;
            if (user.Type == UserType.Protector)
            {
                var addressEditDto = request.Address;
                user.Address.ZipCode = Utils.FieldUtils.UpdateFieldOrUseDefault(addressEditDto.ZipCode, user.Address.ZipCode)!;
                var addressValidation = await ValidateAddress(user.Address);
                if (!addressValidation)
                {
                    return null;
                }
                user.Address.Name = Utils.FieldUtils.UpdateFieldOrUseDefault(addressEditDto.Name, user.Address.Name);
                user.Address.Number = Utils.FieldUtils.UpdateFieldOrUseDefault(addressEditDto.Number, user.Address.Number);
                user.Address.Complement = Utils.FieldUtils.UpdateFieldOrUseDefault(addressEditDto.Complement, user.Address.Complement);
            }
            user = await _userRepository.UpdateUser(user);
            return GetUserDto(user);
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }

    public async Task<UserDto?> GetProtectorProfile(int userId)
    {
        try
        {
            var protector = await _userRepository.GetAvailableProtector(userId);
            return GetUserDto(protector);
        } catch(InvalidOperationException)
        {
            _modelState.AddModelError("Protector","O usuário não existe ou não é uma ONG/Protetor.");
            return null;
        }
    }
    
    public async Task<UserDto?> UpdateProfilePicture(int userId, UpdateProfilePictureRequest request, ImageUploadService service)
    {
        try
        {
            var user = await _userRepository.GetUserById(userId);
            var picture = await service.UploadOne(request.Picture, PictureType.User);
            if (picture == null)
            {
                return null;
            }

            if (user.Picture != null)
            {
                await service.Delete(user.Picture);
            }
            user.Picture = picture;
            user = await _userRepository.UpdateUser(user);
            return GetUserDto(user);
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }
    
    public async Task<UserDto?> DeleteProfilePicture(int userId, ImageUploadService service)
    {
        try
        {
            var user = await _userRepository.GetUserById(userId);

            if (user.Picture == null) return GetUserDto(user);
            await service.Delete(user.Picture);
            user.Picture = null;
            user = await _userRepository.UpdateUser(user);

            return GetUserDto(user);
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }

    public async Task<UserDto?> UpdatePassword(int userId, UpdatePassword request)
    {
        try
        {
            var user = await _userRepository.GetUserById(userId);
            var validatedPassword = ValidateUserPassword(user, request);
            
            if (!validatedPassword)
            {
                return null;
            }
            
            user.Password = EncryptPassword(request.NewPassword);
            await _userRepository.UpdateUser(user);
            return GetUserDto(user);
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }
    public async Task<List<UserDto>> protectorList()
    {
        var protectors = await _userRepository.GetRegisteredProtector();
        return _mapper.Map<List<User>, List<UserDto>>(protectors);
    }


}