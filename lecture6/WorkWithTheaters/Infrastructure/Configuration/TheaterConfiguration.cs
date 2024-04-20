using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    internal class TheaterConfiguration : IEntityTypeConfiguration<Theater>
    {
        public void Configure( EntityTypeBuilder<Theater> builder)
        {
            builder.ToTable(nameof(Theater))
                .HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Address)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.PhoneNumber)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.OpeningDate)
                .IsRequired();

            builder.HasMany(t => t.Plays)
                .WithOne()
                .HasForeignKey(p => p.TheaterId);
                
              
        }
    }
}
