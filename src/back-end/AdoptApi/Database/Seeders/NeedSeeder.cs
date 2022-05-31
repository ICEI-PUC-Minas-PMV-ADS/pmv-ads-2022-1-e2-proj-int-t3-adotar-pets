using AdoptApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AdoptApi.Database.Seeders;

public class NeedSeeder : ISeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Need>().HasData(
            new Need {Id = 1, Name = "Deficiência visual", IsActive = true},
            new Need {Id = 2, Name = "Deficiência auditiva", IsActive = true},
            new Need {Id = 3, Name = "Deficiência motora", IsActive = true},
            new Need {Id = 4, Name = "Doenças transmissíveis", IsActive = true}
        );
    }
}