﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WPF_CMS.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointmennt> Appointmennts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointmennt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC07FE12956A");

            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Appointmennts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Appointmennts_Customers");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC070D12C7F8");

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.IdNumber)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
