using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SolvePayroll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvePayroll.APP_DATA
{
    public class APPDBContext : DbContext
    {
        //public APPDBContext() : base("name=PersonContext")
        //{

        //}

        private const string connectionString = "Server=AHMEDBADEA;Database=PayRollDB;Trusted_Connection=Yes;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<EmployeeAttendance>()
                .HasKey(ea => new { ea.AttendanceId, ea.EmployeeId});
            modelBuilder.Entity<EmployeeAttendance>()
                .HasOne(ea => ea.Attendance)
                .WithMany(ea => ea.EmployeeAttendance)
                .HasForeignKey(ea => ea.AttendanceId);
            modelBuilder.Entity<EmployeeAttendance>()
                .HasOne(ea => ea.Employee)
                .WithMany(ea => ea.EmployeeAttendance)
                .HasForeignKey(bc => bc.EmployeeId);
        }

        //entities
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendances{ get; set; }
        public DbSet<EmployeeAttendance> EmployeeAttendance { get; set; }
    }
    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        /// <summary>
        /// Creates a new instance of this converter.
        /// </summary>
        public DateOnlyConverter() : base(
                d => d.ToDateTime(TimeOnly.MinValue),
                d => DateOnly.FromDateTime(d))
        { }
    }
}
