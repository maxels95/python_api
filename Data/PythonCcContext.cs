using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using python_api.Model;

namespace python_api.Data;

public partial class PythonCcContext : DbContext
{
    public PythonCcContext()
    {
    }

    public PythonCcContext(DbContextOptions<PythonCcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Reading> Readings { get; set; }

    public virtual DbSet<Sensor> Sensors { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=Python_CC.db;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reading>(entity =>
        {
            entity.Property(e => e.ReadingID)
                .ValueGeneratedOnAdd()
                .HasColumnName("ReadingID");
            entity.Property(e => e.SensorID).HasColumnName("SensorID");

            entity.HasOne(d => d.Sensor).WithMany(p => p.Readings).HasForeignKey(d => d.SensorID);
        });

        modelBuilder.Entity<Sensor>(entity =>
        {
            entity.Property(e => e.SensorID)
                .ValueGeneratedOnAdd()
                .HasColumnName("SensorID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .HasColumnName("UserID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
