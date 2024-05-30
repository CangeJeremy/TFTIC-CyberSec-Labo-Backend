using FQ24L007B.CrowdFunding.Domain.Configurations;
using FQ24L007B.CrowdFunding.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Channels;

namespace FQ24L007B.CrowdFunding.Domain
{
    public class CrowdFundingDbContext : DbContext
    {
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Projet> Projets { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public DbSet<Contrepartie> Contreparties { get; set; }

        //public CrowdFundingDbContext()
        //{             
        //}

        public CrowdFundingDbContext(DbContextOptions options) : base(options)
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CrowdFunding;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=True;";
        //    optionsBuilder.UseSqlServer(connectionString)
        //        .LogTo(Console.WriteLine, [DbLoggerCategory.Database.Command.Name], LogLevel.Information);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        

    }
}
