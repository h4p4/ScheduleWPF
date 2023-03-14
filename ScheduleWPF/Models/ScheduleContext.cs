using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ScheduleWPF.Models;

public partial class ScheduleContext : DbContext
{
    public ScheduleContext()
    {
    }

    public ScheduleContext(DbContextOptions<ScheduleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Lecture> Lectures { get; set; }

    public virtual DbSet<Lecturer> Lecturers { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Time> Times { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=192.168.12.211;Port=5432;Database=user5;Username=user5;Password=3Z3MRD");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Group_pkey");

            entity.ToTable("Group", "Schedule");

            entity.Property(e => e.Title).HasMaxLength(10);
        });

        modelBuilder.Entity<Lecture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Lecture_pkey");

            entity.ToTable("Lecture", "Schedule");

            entity.Property(e => e.Description).HasColumnType("character varying");

            entity.HasOne(d => d.Group).WithMany(p => p.Lectures)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Lecture_GroupId_fkey");

            entity.HasOne(d => d.Lecturer).WithMany(p => p.Lectures)
                .HasForeignKey(d => d.LecturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Lecture_LecturerId_fkey");

            entity.HasOne(d => d.Room).WithMany(p => p.Lectures)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Lecture_RoomId_fkey");

            entity.HasOne(d => d.Subject).WithMany(p => p.Lectures)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Lecture_SubjectId_fkey");

            entity.HasOne(d => d.Time).WithMany(p => p.Lectures)
                .HasForeignKey(d => d.TimeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Lecture_TimeId_fkey");
        });

        modelBuilder.Entity<Lecturer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Lecturer_pkey");

            entity.ToTable("Lecturer", "Schedule");

            entity.Property(e => e.FirstName).HasColumnType("character varying");
            entity.Property(e => e.MiddleName).HasColumnType("character varying");
            entity.Property(e => e.Surname).HasColumnType("character varying");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Room_pkey");

            entity.ToTable("Room", "Schedule");

            entity.Property(e => e.Title).HasColumnType("character varying");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Subject_pkey");

            entity.ToTable("Subject", "Schedule");

            entity.Property(e => e.Title).HasColumnType("character varying");
        });

        modelBuilder.Entity<Time>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Time_pkey");

            entity.ToTable("Time", "Schedule");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
