using ExamAppEntities.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamAppDataAccess.Implementations.EntityFramework
{
    public class ExamAppContext : DbContext
    {
        private readonly string _connectionString;
        public ExamAppContext()
        {
            _connectionString = "Data Source=localhost; Initial Catalog=ExamApp; Integrated Security=true; TrustServerCertificate=True;";
        }
        public ExamAppContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Exam> Exams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Code).IsRequired().HasColumnType("char(3)");
                entity.HasIndex(e => e.Code).IsUnique();
                entity.Property(e => e.Name).IsRequired().HasColumnType("varchar(30)").HasMaxLength(30);
                entity.Property(e => e.Class).IsRequired().HasColumnType("tinyint");
                entity.Property(e => e.TeacherName).IsRequired().HasColumnType("varchar(20)").HasMaxLength(20);
                entity.Property(e => e.TeacherSurname).IsRequired().HasColumnType("varchar(20)").HasMaxLength(20);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Number).IsRequired().HasColumnType("int");
                entity.HasIndex(e => e.Number).IsUnique();
                entity.Property(e => e.Name).IsRequired().HasColumnType("varchar(30)").HasMaxLength(30);
                entity.Property(e => e.Surname).IsRequired().HasColumnType("varchar(30)").HasMaxLength(30);
                entity.Property(e => e.Class).IsRequired().HasColumnType("tinyint");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Date).IsRequired().HasColumnType("date");
                entity.Property(e => e.SubjectCode).IsRequired().HasColumnType("char(3)");
                entity.Property(e => e.StudentNumber).IsRequired().HasColumnType("int");
                entity.Property(e => e.Grade).IsRequired().HasColumnType("tinyint");
            });
        }
    }
}
