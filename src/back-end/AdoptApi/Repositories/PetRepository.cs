using AdoptApi.Database;
using AdoptApi.Enums;
using AdoptApi.Models;
using AdoptApi.Requests;
using Microsoft.EntityFrameworkCore;

namespace AdoptApi.Repositories;

public class PetRepository
{
    private Context _context;

    public PetRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<Pet> GetPetByIdAndUserId(int id, int userId)
    {
        return await _context.Pets.Include(nameof(Pet.Pictures)).Include(nameof(Pet.Needs)).Include(nameof(Pet.User)).SingleAsync(p => p.Id == id && p.User.Id == userId);
    }
    
    public async Task<Pet> GetPetById(int id)
    {
        return await _context.Pets.Include(nameof(Pet.Pictures)).Include(nameof(Pet.Needs)).Include(nameof(Pet.User)).SingleAsync(p => p.Id == id);
    }

    public async Task<Pet> CreatePet(Pet pet)
    {
        await _context.Pets.AddAsync(pet);
        await _context.SaveChangesAsync();
        return pet;
    }

    public async Task<Pet> UpdatePet(Pet pet)
    {
        _context.Pets.Update(pet);
        await _context.SaveChangesAsync();
        return pet;
    }
    
    public async Task<List<Need>> GetAvailableNeeds()
    {
        return await _context.Needs.Where(n => n.IsActive == true).ToListAsync();
    }

    public async Task<List<Need>> GetAvailableNeedsByIds(int[] ids)
    {
        return await _context.Needs.Where(n => ids.Contains(n.Id) && n.IsActive).ToListAsync();
    }

    public async Task<Pet> GetAvailablePet(int petId)
    {
        return await _context.Pets.Include(nameof(Pet.Pictures)).Include(nameof(Pet.Needs)).Where(p => p.IsActive == true && p.Id == petId).SingleAsync();
    }

    public async Task<List<Pet>> GetRegisteredPets(int userId)
    {
        return await _context.Pets.Include(nameof(Pet.Pictures)).Include(nameof(Pet.Needs)).Where(p => p.UserId == userId).OrderByDescending(p => p.Id).ToListAsync();
    }

    public async Task<List<Pet>> GetFilteredPets(SearchPetRequest search)
    {
        var filter = _context.Pets.Include(nameof(Pet.Pictures)).Include(nameof(Pet.Needs)).Where(p => p.IsActive == true);
        if (search.Type != null)
        {
            filter = filter.Where(p => p.Type == search.Type);
        }
        if (search.Gender != null)
        {
            filter = filter.Where(p => p.Gender == search.Gender);
        }
        if (search.Size != null)
        {
            filter = filter.Where(p => p.Size == search.Size);
        }
        if (search.Age is PetAge.Baby)
        {
            filter = filter.Where(p => DateTime.Now.Year - p.BirthDate.Year < 1);
        }
        if (search.Age is PetAge.Adult)
        {
            filter = filter.Where(p => DateTime.Now.Year - p.BirthDate.Year >= 1 && DateTime.Now.Year - p.BirthDate.Year < 7);
        }
        if (search.Age is PetAge.Senior)
        {
            filter = filter.Where(p => DateTime.Now.Year - p.BirthDate.Year >= 7);
        }
        return await filter.ToListAsync();
    }
}