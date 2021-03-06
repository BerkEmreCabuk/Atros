﻿// <auto-generated />
using System;
using Atros.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Atros.Data.Migrations
{
    [DbContext(typeof(AtrosDbContext))]
    partial class AtrosDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("Atros.Data.Entities.Movie", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Adult")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasDefaultValue(new DateTime(2020, 9, 7, 2, 27, 54, 467, DateTimeKind.Local).AddTicks(9033));

                    b.Property<string>("OriginalLanguage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OriginalTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Overview")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Popularity")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("DateTime");

                    b.Property<byte>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue((byte)1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("DateTime");

                    b.Property<bool>("Video")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("VoteAverage")
                        .HasColumnType("TEXT");

                    b.Property<int>("VoteCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("Atros.Data.Entities.MovieEvaluation", b =>
                {
                    b.Property<long>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasDefaultValue(new DateTime(2020, 9, 7, 2, 27, 54, 473, DateTimeKind.Local).AddTicks(7734));

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(255);

                    b.Property<byte>("Score")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue((byte)1);

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("DateTime");

                    b.HasKey("MovieId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("MovieEvaluation");
                });

            modelBuilder.Entity("Atros.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasDefaultValue(new DateTime(2020, 9, 7, 2, 27, 54, 463, DateTimeKind.Local).AddTicks(1059));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<byte>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue((byte)1);

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("DateTime");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5fb2c73b-afb0-4cd5-9b80-45a1c3510851"),
                            CreateDate = new DateTime(2020, 9, 7, 2, 27, 54, 478, DateTimeKind.Local).AddTicks(6714),
                            Password = "123456",
                            Status = (byte)1,
                            UserName = "berkemre"
                        },
                        new
                        {
                            Id = new Guid("8cc0e103-39af-4574-b31a-591bb4c94a1c"),
                            CreateDate = new DateTime(2020, 9, 7, 2, 27, 54, 478, DateTimeKind.Local).AddTicks(7935),
                            Password = "123456",
                            Status = (byte)1,
                            UserName = "ogulcan"
                        });
                });

            modelBuilder.Entity("Atros.Data.Entities.MovieEvaluation", b =>
                {
                    b.HasOne("Atros.Data.Entities.Movie", "Movie")
                        .WithMany("MovieEvaluationEntity")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK_MovieEvaluationEntity_Movie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Atros.Data.Entities.User", "User")
                        .WithMany("MovieEvaluationEntity")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_MovieEvaluationEntity_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
