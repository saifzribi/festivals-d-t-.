using ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    internal class ConcertConfiguration : IEntityTypeConfiguration<Concert>
    {
        public void Configure(EntityTypeBuilder<Concert> builder)
        {
            builder.HasOne(c => c.Artiste).WithMany(p => p.Concerts)
                .HasForeignKey(c => c.ArtisteFk)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(f => f.Festival).WithMany(p => p.Concerts)
                .HasForeignKey(f => f.FestivalFk)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasKey(t => new { t.ArtisteFk, t.FestivalFk, t.DateConcert });
        }

    }
}
