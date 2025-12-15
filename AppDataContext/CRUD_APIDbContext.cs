
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using CRUD_API.Models;

namespace CRUD_API.AppDataContext
{

    // CRUD_APIDbContext class inherits from DbContext
     public class CRUD_APIDbContext : DbContext
     {

        // DbSettings field to store the connection string
         private readonly DbSettings _dbsettings;

        // Constructor to inject the DbSettings model
         public CRUD_APIDbContext(IOptions<DbSettings> dbSettings)
         {
             _dbsettings = dbSettings.Value;
         }

        // DbSet property to represent the Medicament table
         public DbSet<Medicament> Medicaments { get; set; }

        // Configuring the database provider and connection string
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseSqlServer(_dbsettings.ConnectionString);
         }

        // Configuring the model for the Medicament entity
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<Medicament>()
                 .ToTable("Medicaments")
                 .HasKey(x => x.Id);
         }
     }
}