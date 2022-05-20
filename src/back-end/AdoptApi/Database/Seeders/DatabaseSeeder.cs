using Microsoft.EntityFrameworkCore;

namespace AdoptApi.Database.Seeders;

public class DatabaseSeeder : ISeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        NeedSeeder.Seed(modelBuilder);
    }
}