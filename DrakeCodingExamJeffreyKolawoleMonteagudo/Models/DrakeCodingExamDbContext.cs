using System;
using System.Collections.Generic;
using DrakeCodingExamJeffreyKolawoleMonteagudo.Responses;
using Microsoft.EntityFrameworkCore;

namespace DrakeCodingExamJeffreyKolawoleMonteagudo.Models;

public partial class DrakeCodingExamDbContext : DbContext
{
    public DrakeCodingExamDbContext()
    {
    }

    public DrakeCodingExamDbContext(DbContextOptions<DrakeCodingExamDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CityTbl> CityTbls { get; set; }

    public virtual DbSet<CourseTbl> CourseTbls { get; set; }

    public virtual DbSet<DegreeTypeTbl> DegreeTypeTbls { get; set; }

    public virtual DbSet<GenderTbl> GenderTbls { get; set; }

    public virtual DbSet<StudentTbl> StudentTbls { get; set; }

    public virtual DbSet<SubjectTbl> SubjectTbls { get; set; }

    public virtual DbSet<GetStudentRecordsResponse> StudentRecords { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=DESKTOP-KFEOOR5\\SQLEXPRESS;initial catalog=DrakeCodingExamDB;trusted_connection=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GetStudentRecordsResponse>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Get Student Records");

            entity.Property(e => e.StudentId).ValueGeneratedOnAdd();
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CityName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GenderName)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CourseName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DegreeTypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CourseDurationInMonths);
        });

        modelBuilder.Entity<CityTbl>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("City_tbl");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CourseTbl>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Course_tbl");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DegreeTypeTbl>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DegreeType_tbl");

            entity.Property(e => e.Degree)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<GenderTbl>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Gender_tbl");

            entity.Property(e => e.GenderName)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<StudentTbl>(entity =>
        {
            entity
                //.HasNoKey()
                .ToTable("Student_tbl");

            entity.Property(e => e.CityId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SubjectTbl>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Subject_tbl");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
