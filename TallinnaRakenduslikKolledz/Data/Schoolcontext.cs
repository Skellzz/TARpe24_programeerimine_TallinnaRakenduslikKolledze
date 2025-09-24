﻿using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

using TallinnaRakenduslikKolledz.Models;

public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }
    
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<PassportPhoto> PassportPhotos { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<CourseAssignment> CourseAssignments { get; set; }
    public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
    public DbSet<Department> Departments { get; set; }
    


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Course>().ToTable("Course");
        modelBuilder.Entity<Student>().ToTable("Student");
        modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
        modelBuilder.Entity<PassportPhoto>().ToTable("PassportPhoto");
        // modelBuilder.Entity<Instructor>().ToTable("Instructor");
        modelBuilder.Entity<Instructor>().ToTable("Instructor");
        modelBuilder.Entity<CourseAssignment>().ToTable("CourseAssignment");
        modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");
        modelBuilder.Entity<Department>().ToTable("Department");

    }



}
