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
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            // Added config for Password
            builder.HasMany(person => person.Passwords)
                .WithOne(password => password.Person)
                .HasForeignKey(password => password.PersonId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            // Added config for Email
            builder.HasOne(person => person.EmailAddress)
                .WithOne(e => e.Person)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // Added config for Address
            builder.HasMany(p => p.Adresses)
                .WithOne(a => a.Person)
                .HasForeignKey(a => a.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
            // Added config for CreditCards
            builder.HasMany(p => p.CreditCards)
                .WithOne(a => a.Person)
                .HasForeignKey(a => a.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
