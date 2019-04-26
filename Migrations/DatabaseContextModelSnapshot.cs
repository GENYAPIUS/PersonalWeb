﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalWeb.Models;

namespace PersonalWeb.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity("PersonalWeb.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<DateTime>("DateTime");

                    b.Property<int?>("MessageId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("PersonalWeb.Models.Message", b =>
                {
                    b.HasOne("PersonalWeb.Models.Message")
                        .WithMany("Messages")
                        .HasForeignKey("MessageId");
                });
#pragma warning restore 612, 618
        }
    }
}
