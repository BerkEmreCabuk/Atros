using Atros.Common.Enums;
using Atros.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atros.Data.EntityConfigurations
{
    public class SeedData : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User 
                {
                    Id=Guid.NewGuid(),
                    UserName="berkemre",
                    Password = "123456",
                    CreateDate=DateTime.Now,
                    Status=Status.Active
                },
                new User 
                {
                    Id = Guid.NewGuid(),
                    UserName = "ogulcan",
                    Password = "123456",
                    CreateDate = DateTime.Now,
                    Status = Status.Active
                });
        }
    }
}

