using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Person.Core.Domain;

namespace App.Infrastructure.Configuration
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            // Bussiness Address
            builder.HasMany(a => a.Adresses)
                .WithOne(ba => ba.Address)
                .HasForeignKey(a => a.AddressId)
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
