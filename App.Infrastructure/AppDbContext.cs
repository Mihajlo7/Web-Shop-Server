
using Castle.Core.Configuration;
using ConnectionService;
using Generic.Entity;
using Generic.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Person.Core.Domain;

namespace App.Infrastructure
{
    public class AppDbContext : DbContext
    {
        private readonly IConnectionService _connectionService;


        public DbSet<Person.Core.Domain.Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BussinessEntitityCreditCard> BussinessEntitityCreditCards { get; set; }
        public DbSet<BusinessEntityAdress> BusinessEntityAdresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }
        public DbSet<Password> Passwords { get; set; }

        public AppDbContext(IConnectionService connectionService)
        {
            _connectionService=connectionService; 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_connectionService.GetRelationString())
                //.UseLazyLoadingProxies()
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
