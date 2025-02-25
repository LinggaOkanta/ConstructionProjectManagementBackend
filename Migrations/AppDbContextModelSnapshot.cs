﻿// <auto-generated />
using System;
using ConstructionProjectManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConstructionProjectManagement.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ConstructionProjectManagement.Domain.Entities.ConstructionProject", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProjectId"));

                    b.Property<DateTime>("ConstructionStartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uuid");

                    b.Property<string>("ProjectCategory")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProjectDetails")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProjectLocation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProjectStage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProjectId");

                    b.HasIndex("CreatorId");

                    b.ToTable("ConstructionProjects");
                });

            modelBuilder.Entity("ConstructionProjectManagement.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ConstructionProjectManagement.Domain.Entities.ConstructionProject", b =>
                {
                    b.HasOne("ConstructionProjectManagement.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
