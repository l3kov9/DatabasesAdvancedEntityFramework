﻿// <auto-generated />
using Forum.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Forum.Migrations
{
    [DbContext(typeof(ForumDbContext))]
    [Migration("20171207162611_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Forum.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Forum.Data.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Content");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Forum.Data.Models.Reply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<string>("Content");

                    b.Property<int>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PostId");

                    b.ToTable("Replies");
                });

            modelBuilder.Entity("Forum.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Forum.Data.Models.Post", b =>
                {
                    b.HasOne("Forum.Data.Models.User", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Forum.Data.Models.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Forum.Data.Models.Reply", b =>
                {
                    b.HasOne("Forum.Data.Models.User", "Author")
                        .WithMany("Replies")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Forum.Data.Models.Post", "Post")
                        .WithMany("Replies")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
