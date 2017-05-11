﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SeedData;
using System;

namespace SeedData.Migrations
{
    [DbContext(typeof(BloggingContext))]
    [Migration("20170511014618_FixUserData")]
    partial class FixUserData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-preview2-t004689b43")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SeedData.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OwnerId");

                    b.Property<string>("Url");

                    b.HasKey("BlogId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("SeedData.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlogId");

                    b.Property<string>("Content");

                    b.Property<string>("Title");

                    b.HasKey("PostId");

                    b.HasIndex("BlogId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("SeedData.PostTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PostId");

                    b.Property<string>("TagId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("TagId");

                    b.ToTable("PostTag");
                });

            modelBuilder.Entity("SeedData.Tag", b =>
                {
                    b.Property<string>("TagId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("TagId");

                    b.ToTable("Tags");

                    b.SeedData(new[]
                    {
                        new { TagId = ".NET" },
                        new { TagId = "VisualStudio" },
                        new { TagId = "C#" },
                        new { TagId = "F#" },
                        new { TagId = "VB.NET" },
                        new { TagId = "EnityFramework" },
                        new { TagId = "ASP.NET" }
                    });
                });

            modelBuilder.Entity("SeedData.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.SeedData(new[]
                    {
                        new { UserId = 2, UserName = "Administrator" }
                    });
                });

            modelBuilder.Entity("SeedData.Blog", b =>
                {
                    b.HasOne("SeedData.User", "Owner")
                        .WithMany("OwnedBlogs")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SeedData.Post", b =>
                {
                    b.HasOne("SeedData.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SeedData.PostTag", b =>
                {
                    b.HasOne("SeedData.Post", "Post")
                        .WithMany("Tags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SeedData.Tag", "Tag")
                        .WithMany("Posts")
                        .HasForeignKey("TagId");
                });
        }
    }
}
