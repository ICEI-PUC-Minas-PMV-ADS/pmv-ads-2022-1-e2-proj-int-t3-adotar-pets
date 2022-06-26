using AdoptApi.Database;
using AdoptApi.Enums;
using AdoptApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AdoptApi.Repositories;

public class UserRepository
{
    private Context _context;

    public UserRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<bool> UserEmailExists(string email)
    {
        return await _context.Users.CountAsync(u => u.Email == email) == 1;
    }
    
    public async Task<bool> UserDocumentExists(string document)
    {
        return await _context.Users.CountAsync(u => u.Document.Number == document) == 1;
    }
    
    public async Task<User> GetUserEmailAndByPassword(string email, string password)
    {
        return await _context.Users.Include(nameof(Address)).Include(nameof(Document)).Include(nameof(Picture)).SingleAsync(u => u.Email == email && u.Password == password);
    }
    
    public async Task<User> GetUserById(int id)
    {
        return await _context.Users.Include(nameof(Address)).Include(nameof(Document)).Include(nameof(Picture)).SingleAsync(u => u.Id == id);
    }
    
    public async Task<User> GetAvailableProtector(int userId)
    {
        return await _context.Users.Include(nameof(Address)).Include(nameof(Document)).Include(nameof(Picture)).Where(u => u.IsActive == true && u.Id == userId && u.Type == UserType.Protector).SingleAsync();
    }
    
    public async Task<User> CreateUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }
    
    public async Task<User> UpdateUser(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<List<User>> GetRegisteredProtector()
    {
        return await _context.Users.Include(nameof(Address)).Include(nameof(Document)).Include(nameof(Picture)).Where(u => u.IsActive == true && u.Type == UserType.Protector).ToListAsync();
    }
}

