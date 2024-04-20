using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    internal class ActorConfiguretion : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            // Привязка к таблице
            // Задаем свойство PrimaryKey
            builder.ToTable(nameof(Actor))
                .HasKey( a => a.Id );

            builder.Property(a => a.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.Surname)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.PhoneNumber) 
                .HasMaxLength(50)
                .IsRequired();

            // datetime2
            builder.Property(a => a.DateOfBirth)
                .IsRequired();

            builder.Ignore(a => a.FullName);
        }
    }
}
