using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace scientificCalculatorBackEnd.Models;

public partial class PremadeInnovationsContext : DbContext
{
    public PremadeInnovationsContext()
    {
    }

    public PremadeInnovationsContext(DbContextOptions<PremadeInnovationsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Calculator> Calculators { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calculator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Calculat__3213E83FA8FFC196");

            entity.ToTable("Calculator");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ComplexValue)
                .HasColumnType("numeric(20, 5)")
                .HasColumnName("complexValue");
            entity.Property(e => e.Expression)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("expression");
            entity.Property(e => e.RealValue)
                .HasColumnType("numeric(20, 5)")
                .HasColumnName("realValue");
            entity.Property(e => e.Result)
                .HasColumnType("numeric(20, 5)")
                .HasColumnName("result");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
