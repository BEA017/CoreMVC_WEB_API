using System;
using System.Collections.Generic;
using CoreMVC_WEB_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreMVC_WEB_API.Data;

public partial class PubsContext : DbContext
{
    public PubsContext()
    {
    }

    public PubsContext(DbContextOptions<PubsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuId).HasName("UPKCL_auidind");

            entity.Property(e => e.Phone)
                .HasDefaultValueSql("('UNKNOWN')")
                .IsFixedLength();
            entity.Property(e => e.State).IsFixedLength();
            entity.Property(e => e.Zip).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
