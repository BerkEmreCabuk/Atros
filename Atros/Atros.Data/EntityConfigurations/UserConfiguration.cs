using Atros.Common.Enums;
using Atros.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Atros.Data.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(p => p.Id); //Primary key and idendity

            builder.Property(p => p.Id)
                .IsRequired(true);

            builder.Property(p => p.UserName)
                .HasMaxLength(255)
                .IsRequired(true);

            builder.Property(p => p.Password)
                .HasMaxLength(50)
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
