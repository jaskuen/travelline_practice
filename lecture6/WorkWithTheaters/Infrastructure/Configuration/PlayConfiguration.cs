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
    internal class PlayConfiguration : IEntityTypeConfiguration<Play>
    {
        public void Configure( EntityTypeBuilder<Play> builder )
        {
            builder.ToTable( nameof(Play) )
                .HasKey( p => p.Id );
            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property( p => p.StageDirector)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.TheaterId)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.StartDate)
                .IsRequired();
            builder.Property(p => p.EndDate)
                .IsRequired();

            // связь N to N между Play и Actor
            builder.HasMany(p => p.Actors)
                .WithMany(a => a.Plays)
                .UsingEntity("ActorToPlay");
        }
    }
}
