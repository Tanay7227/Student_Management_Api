using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Practice_1.Models;

public partial class StudentdatabaseContext : DbContext
{
    public StudentdatabaseContext()
    {
    }

    public StudentdatabaseContext(DbContextOptions<StudentdatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StudentDb> StudentDbs { get; set; }

    public virtual DbSet<StudentTable> StudentTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentDb>(entity =>
        {
            entity.ToTable("Student_db");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StudentGender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Student_Gender");
            entity.Property(e => e.StudentName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Student_Name");
        });

        modelBuilder.Entity<StudentTable>(entity =>
        {
            entity.ToTable("StudentTable");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
