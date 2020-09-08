using Atros.Common.Enums;
using Atros.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Atros.Data.EntityConfigurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movie");

            builder.HasKey(p => p.Id); //Primary key and idendity
            
            builder.Property(p => p.Id)
                .IsRequired(true);

            builder.Property(p => p.Popularity)
                .IsRequired(true);

            builder.Property(p => p.VoteCount)
                .IsRequired(true);

            builder.Property(p => p.OriginalLanguage)
                .IsRequired(true);

            builder.Property(p => p.OriginalTitle)
                .IsRequired(true);

            builder.Property(p => p.Title)
                .IsRequired(true);

            builder.Property(p => p.VoteAverage)
                .IsRequired(true);

            builder.Property(p => p.Adult)
                .IsRequired(true);

            builder.Property(p => p.Video)
                .IsRequired(true);

            builder.Property(p => p.ReleaseDate)
                .HasColumnType("DateTime")
                .IsRequired(false);

            builder.Property(p => p.Overview)
                .IsRequired(true);

            builder.Property(p => p.Status)
                .HasDefaultValue(Status.Active)
                .IsRequired(true);

            builder.Property(p => p.CreateDate)
                .HasDefaultValue(DateTime.Now)
                .HasColumnType("DateTime")
                .IsRequired(true);

            builder.Property(p => p.UpdateDate)
                .HasColumnType("DateTime")
                .IsRequired(false);

        }
    }
}
