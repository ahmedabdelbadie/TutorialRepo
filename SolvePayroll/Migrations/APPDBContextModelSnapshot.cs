﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SolvePayroll.APP_DATA;

#nullable disable

namespace SolvePayroll.Migrations
{
    [DbContext(typeof(APPDBContext))]
    partial class APPDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SolvePayroll.Models.Attendance", b =>
                {
                    b.Property<int>("AttendanceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOnly")
                        .HasColumnType("date");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<int>("DayType")
                        .HasColumnType("int");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("AttendanceId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("SolvePayroll.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<double>("FeeAllowance")
                        .HasColumnType("float");

                    b.Property<double>("FeeDay")
                        .HasColumnType("float");

                    b.Property<double>("FeeDeduct")
                        .HasColumnType("float");

                    b.Property<double>("FeeDifferentiate")
                        .HasColumnType("float");

                    b.Property<double>("FeeSite")
                        .HasColumnType("float");

                    b.Property<string>("JobType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("SolvePayroll.Models.EmployeeAttendance", b =>
                {
                    b.Property<int>("AttendanceId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<double>("WorkingHourPerDay")
                        .HasColumnType("float");

                    b.HasKey("AttendanceId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeAttendance");
                });

            modelBuilder.Entity("SolvePayroll.Models.EmployeeAttendance", b =>
                {
                    b.HasOne("SolvePayroll.Models.Attendance", "Attendance")
                        .WithMany("EmployeeAttendance")
                        .HasForeignKey("AttendanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SolvePayroll.Models.Employee", "Employee")
                        .WithMany("EmployeeAttendance")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attendance");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("SolvePayroll.Models.Attendance", b =>
                {
                    b.Navigation("EmployeeAttendance");
                });

            modelBuilder.Entity("SolvePayroll.Models.Employee", b =>
                {
                    b.Navigation("EmployeeAttendance");
                });
#pragma warning restore 612, 618
        }
    }
}
