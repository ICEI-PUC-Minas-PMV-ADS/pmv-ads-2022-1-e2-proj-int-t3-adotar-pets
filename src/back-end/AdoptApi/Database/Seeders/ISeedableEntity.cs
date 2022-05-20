using Microsoft.EntityFrameworkCore;

namespace AdoptApi.Database.Seeders;

public interface ISeeder
{
    static void Seed(ModelBuilder modelBuilder) {}
}