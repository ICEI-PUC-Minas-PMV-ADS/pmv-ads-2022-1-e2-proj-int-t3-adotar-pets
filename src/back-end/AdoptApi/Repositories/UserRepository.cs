using AdoptApi.Database;
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
        return await _context.Users.Include(nameof(Address)).Include(nameof(Document)).SingleAsync(u => u.Email == email && u.Password == password);
    }
    
    public async Task<User> GetUserById(int id)
    {
        return await _context.Users.Include(nameof(Address)).Include(nameof(Document)).SingleAsync(u => u.Id == id);
    }

    public async Task<User> CreateUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    // @TODO: implementar camada de dados para atualizar user (chamar função
    // public async Task<User> UpdateUser(User user)
    // {
    // }
}