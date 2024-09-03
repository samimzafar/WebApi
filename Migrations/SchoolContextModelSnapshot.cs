﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Data;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(SchoolContext))]
    partial class SchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApi.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "1234",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("WebApi.Models.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Fees")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Open")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Schools");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Fees = 1000m,
                            Location = "Sawat",
                            Name = "APS",
                            Open = true
                        },
                        new
                        {
                            Id = 2,
                            Fees = 1500m,
                            Location = "Kohat",
                            Name = "IQRA",
                            Open = true
                        },
                        new
                        {
                            Id = 3,
                            Fees = 1200m,
                            Location = "Mardan",
                            Name = "BIRD SKY",
                            Open = true
                        },
                        new
                        {
                            Id = 4,
                            Fees = 1100m,
                            Location = "Swabi",
                            Name = "CITY LEARN",
                            Open = true
                        },
                        new
                        {
                            Id = 5,
                            Fees = 1300m,
                            Location = "Lahore",
                            Name = "WALKSCHOOL",
                            Open = true
                        });
                });

            modelBuilder.Entity("WebApi.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.Property<int>("TransportId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.HasIndex("TransportId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("WebApi.Models.Transport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BusNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Transports");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BusNumber = "Bus101",
                            SchoolId = 1
                        },
                        new
                        {
                            Id = 2,
                            BusNumber = "Bus102",
                            SchoolId = 2
                        },
                        new
                        {
                            Id = 3,
                            BusNumber = "Bus103",
                            SchoolId = 3
                        },
                        new
                        {
                            Id = 4,
                            BusNumber = "Bus104",
                            SchoolId = 4
                        },
                        new
                        {
                            Id = 5,
                            BusNumber = "Bus105",
                            SchoolId = 5
                        });
                });

            modelBuilder.Entity("WebApi.Models.Student", b =>
                {
                    b.HasOne("WebApi.Models.School", "School")
                        .WithMany("Students")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Models.Transport", "Transport")
                        .WithMany()
                        .HasForeignKey("TransportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");

                    b.Navigation("Transport");
                });

            modelBuilder.Entity("WebApi.Models.Transport", b =>
                {
                    b.HasOne("WebApi.Models.School", "School")
                        .WithMany("Transports")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("WebApi.Models.School", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Transports");
                });
#pragma warning restore 612, 618
        }
    }
}
