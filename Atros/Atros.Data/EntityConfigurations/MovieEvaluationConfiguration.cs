using Atros.Common.Enums;
using Atros.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Atros.Data.EntityConfigurations
{
    public class MovieEvaluationConfiguration : IEntityTypeConfiguration<MovieEvaluation>
    {
        public void Configure(EntityTypeBuilder<MovieEvaluation> builder)
        {
            builder.ToTable("MovieEvaluation");

            builder.HasKey(p => new { p.MovieId, p.UserId }); //Primary key and idendity

            builder.Property(p => p.Note)
                .HasMaxLength(255)
                .IsRequired(true);

            builder.Property(p => p.Score)
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

            builder.HasOne(me => me.User)
                            .WithMany(me => me.MovieEvaluationEntity)
                            .HasForeignKey(me => me.UserId)
                            .HasConstraintName("FK_MovieEvaluationEntity_User");

            builder.HasOne(me => me.Movie)
                        .WithMany(me => me.MovieEvaluationEntity)
                        .HasForeignKey(me => me.MovieId)
                        .HasConstraintName("FK_MovieEvaluationEntity_Movie");
        }
    }
}
