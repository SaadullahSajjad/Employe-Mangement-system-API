﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task1.DataBase;

#nullable disable

namespace Task1.Migrations
{
    [DbContext(typeof(UserInfoDBContext))]
    partial class UserInfoDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Task1.Models.Domain.Attendance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AttendanceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AttendanceStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CheckInTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CheckOutTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TotalHoursWorked")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Attendances");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d41cd31c-3fef-4c3c-9ebb-020a6c2dc256"),
                            AttendanceDate = new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AttendanceStatus = "Present",
                            CheckInTime = new DateTime(2023, 6, 15, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            CheckOutTime = new DateTime(2023, 6, 15, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            TotalHoursWorked = 8,
                            UserId = new Guid("89b876cc-a901-4467-bb50-1a23389805af")
                        },
                        new
                        {
                            Id = new Guid("39fcf329-d915-4c75-ab57-1cd4c1270788"),
                            AttendanceDate = new DateTime(2023, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AttendanceStatus = "Late",
                            CheckInTime = new DateTime(2023, 6, 16, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            CheckOutTime = new DateTime(2023, 6, 16, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            TotalHoursWorked = 7,
                            UserId = new Guid("3f470b47-eab2-4eca-a78c-44f1b62c1537")
                        },
                        new
                        {
                            Id = new Guid("29f73ba9-a5d3-4280-9580-0f3e4f9aac06"),
                            AttendanceDate = new DateTime(2023, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AttendanceStatus = "Present",
                            CheckInTime = new DateTime(2023, 6, 17, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            CheckOutTime = new DateTime(2023, 6, 17, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            TotalHoursWorked = 7,
                            UserId = new Guid("89b876cc-a901-4467-bb50-1a23389805af")
                        },
                        new
                        {
                            Id = new Guid("2f2763d3-a4d4-4d8b-b199-800882a1c601"),
                            AttendanceDate = new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AttendanceStatus = "Late",
                            CheckInTime = new DateTime(2023, 6, 18, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            CheckOutTime = new DateTime(2023, 6, 18, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            TotalHoursWorked = 6,
                            UserId = new Guid("3f470b47-eab2-4eca-a78c-44f1b62c1537")
                        });
                });

            modelBuilder.Entity("Task1.Models.Domain.Leave", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AllowedLeaves")
                        .HasColumnType("int");

                    b.Property<string>("LeaveStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Leaves");

                    b.HasData(
                        new
                        {
                            Id = new Guid("36127359-6b07-4a62-a3a0-2d96581321e1"),
                            AllowedLeaves = 5,
                            LeaveStatus = "Approved",
                            Reason = "fever",
                            UserId = new Guid("89b876cc-a901-4467-bb50-1a23389805af")
                        },
                        new
                        {
                            Id = new Guid("2ca6bfc2-4fa5-4e59-81d9-e52acaca096a"),
                            AllowedLeaves = 5,
                            LeaveStatus = "Pending",
                            Reason = "fever",
                            UserId = new Guid("3f470b47-eab2-4eca-a78c-44f1b62c1537")
                        },
                        new
                        {
                            Id = new Guid("9c3f9bf9-3680-4c5a-a3d4-bd1969dec093"),
                            AllowedLeaves = 5,
                            LeaveStatus = "disApproved",
                            Reason = "fever",
                            UserId = new Guid("3f470b47-eab2-4eca-a78c-44f1b62c1537")
                        });
                });

            modelBuilder.Entity("Task1.Models.Domain.Salary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Allowances")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NetSalary")
                        .HasColumnType("int");

                    b.Property<string>("PayMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Salarys");

                    b.HasData(
                        new
                        {
                            Id = new Guid("36127359-6b07-4a62-a3a0-2d96581321e1"),
                            Allowances = "Petrol incentives",
                            NetSalary = 20000,
                            PayMethod = "cash by Hand",
                            UserId = new Guid("89b876cc-a901-4467-bb50-1a23389805af")
                        },
                        new
                        {
                            Id = new Guid("2ca6bfc2-4fa5-4e59-81d9-e52acaca096a"),
                            Allowances = "Bonus incentives",
                            NetSalary = 50000,
                            PayMethod = "cash by Hand",
                            UserId = new Guid("3f470b47-eab2-4eca-a78c-44f1b62c1537")
                        },
                        new
                        {
                            Id = new Guid("9c3f9bf9-3680-4c5a-a3d4-bd1969dec093"),
                            Allowances = "Petrol incentives",
                            NetSalary = 30000,
                            PayMethod = "credit card",
                            UserId = new Guid("3f470b47-eab2-4eca-a78c-44f1b62c1537")
                        });
                });

            modelBuilder.Entity("Task1.Models.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c1415027-e627-4956-bf7b-d43e23feec06"),
                            Email = "gcch@gmail.com",
                            Name = "Ghufran",
                            Password = "1234567890",
                            Roles = "admin"
                        },
                        new
                        {
                            Id = new Guid("89b876cc-a901-4467-bb50-1a23389805af"),
                            Email = "nomi@gmail.com",
                            Name = "nomi",
                            Password = "1234567890",
                            Roles = "employee"
                        },
                        new
                        {
                            Id = new Guid("3f470b47-eab2-4eca-a78c-44f1b62c1537"),
                            Email = "ali@gmail.com",
                            Name = "ali",
                            Password = "1234567890",
                            Roles = "employee"
                        });
                });

            modelBuilder.Entity("Task1.Models.Domain.Attendance", b =>
                {
                    b.HasOne("Task1.Models.Domain.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Task1.Models.Domain.Leave", b =>
                {
                    b.HasOne("Task1.Models.Domain.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Task1.Models.Domain.Salary", b =>
                {
                    b.HasOne("Task1.Models.Domain.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });
#pragma warning restore 612, 618
        }
    }
}
