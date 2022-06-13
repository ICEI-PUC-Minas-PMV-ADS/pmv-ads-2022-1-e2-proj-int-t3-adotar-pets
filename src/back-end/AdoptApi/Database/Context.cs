using AdoptApi.Models;
using AdoptApi.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdoptApi.Database;

public class Context : DbContext
{
    public Context(DbContextOptions options) : base(options) {}
    
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<Need> Needs { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Picture> Pictures { get; set; }
    public DbSet<User> Users { get; set; }

    public DbSet<Question> Questions { get; set; }
    public DbSet<Alternative> Alternatives { get; set; }
    public DbSet<AlternativeNeedPenalty> AlternativeNeedPenalties { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Form> Forms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();
        modelBuilder.SetQueryFilterOnAllEntities<ISoftDeletable>(p => p.DeletedOn == null);
        base.OnModelCreating(modelBuilder);
    }
}