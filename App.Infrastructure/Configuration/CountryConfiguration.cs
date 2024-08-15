using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persons.Domain.Domain;

namespace App.Infrastructure.Configuration
{
    internal class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasMany(c => c.Address)
                .WithOne(a => a.Country)
                .HasForeignKey(a => a.CountryId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasData(
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Germany", Code = "DE", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "France", Code = "FR", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Italy", Code = "IT", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Spain", Code = "ES", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Portugal", Code = "PT", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Netherlands", Code = "NL", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Belgium", Code = "BE", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Luxembourg", Code = "LU", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Austria", Code = "AT", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Switzerland", Code = "CH", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Poland", Code = "PL", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Czech Republic", Code = "CZ", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Hungary", Code = "HU", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Slovakia", Code = "SK", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Slovenia", Code = "SI", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Croatia", Code = "HR", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Serbia", Code = "RS", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Bosnia and Herzegovina", Code = "BA", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Montenegro", Code = "ME", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Kosovo", Code = "XK", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "North Macedonia", Code = "MK", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Albania", Code = "AL", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Greece", Code = "GR", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Bulgaria", Code = "BG", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Romania", Code = "RO", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Turkey", Code = "TR", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Ukraine", Code = "UA", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Belarus", Code = "BY", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Lithuania", Code = "LT", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Latvia", Code = "LV", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Estonia", Code = "EE", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Finland", Code = "FI", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Sweden", Code = "SE", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Norway", Code = "NO", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Denmark", Code = "DK", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Iceland", Code = "IS", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "United Kingdom", Code = "GB", CountryRegionCode = "EU" },
                new Country { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Name = "Ireland", Code = "IE", CountryRegionCode = "EU" }
                );
        }
    }
}
