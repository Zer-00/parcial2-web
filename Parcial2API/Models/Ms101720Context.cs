using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Parcial2API.Models;

public partial class Ms101720Context : DbContext
{
    public Ms101720Context()
    {
    }

    public Ms101720Context(DbContextOptions<Ms101720Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Elecciones2019> Elecciones2019s { get; set; }

    public virtual DbSet<VistaElecciones2019> VistaElecciones2019s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=CC5-45\\SQLEXPRESS;Database=MS101720;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Elecciones2019>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("elecciones_2019");

            entity.Property(e => e.Candidato)
                .HasMaxLength(60)
                .HasColumnName("candidato");
            entity.Property(e => e.Departamento)
                .HasMaxLength(50)
                .HasColumnName("departamento");
            entity.Property(e => e.Votos).HasColumnName("votos");
        });

        modelBuilder.Entity<VistaElecciones2019>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VistaElecciones2019");

            entity.Property(e => e.Candidato)
                .HasMaxLength(60)
                .HasColumnName("candidato");
            entity.Property(e => e.Porcentaje).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
