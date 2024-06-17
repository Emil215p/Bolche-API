using System;
using System.Collections.Generic;
using BolcheAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BolcheAPI.Data;

public partial class BolcherContext : DbContext
{
    public BolcherContext()
    {
    }

    public BolcherContext(DbContextOptions<BolcherContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BolcheStat> BolcheStats { get; set; }

    public virtual DbSet<BolcheType> BolcheTypes { get; set; }

    public virtual DbSet<Bolcher> Bolchers { get; set; }

    public virtual DbSet<ForsendelsesInfo> ForsendelsesInfos { get; set; }

    public virtual DbSet<Indkøbsvogn> Indkøbsvogns { get; set; }

    public virtual DbSet<ItemTrait> ItemTraits { get; set; }

    public virtual DbSet<Kunder> Kunders { get; set; }

    public virtual DbSet<Ordre> Ordres { get; set; }

    public virtual DbSet<TypeofTrait> TypeofTraits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=Bolcher");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BolcheStat>(entity =>
        {
            entity.HasKey(e => e.StatsId).HasName("PK__BolcheSt__C23A1F433D756A19");

            entity.Property(e => e.StatsId).HasColumnName("StatsID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Unit).HasMaxLength(255);
        });

        modelBuilder.Entity<BolcheType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__BolcheTy__516F0395D50C877A");

            entity.ToTable("BolcheType");

            entity.Property(e => e.TypeId).HasColumnName("TypeID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Bolcher>(entity =>
        {
            entity.HasKey(e => e.BolcheId).HasName("PK__Bolcher__2BA201E0D830DB87");

            entity.ToTable("Bolcher");

            entity.Property(e => e.BolcheId).HasColumnName("BolcheID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.TypeId).HasColumnName("TypeID");

            entity.HasOne(d => d.Type).WithMany(p => p.Bolchers)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bolcher__TypeID__286302EC");
        });

        modelBuilder.Entity<ForsendelsesInfo>(entity =>
        {
            entity.HasKey(e => e.ForsendelsesInfoId).HasName("PK__Forsende__A010CA4EE5C7D114");

            entity.ToTable("ForsendelsesInfo");

            entity.Property(e => e.ForsendelsesInfoId).HasColumnName("ForsendelsesInfoID");
            entity.Property(e => e.Adresse).HasMaxLength(255);
            entity.Property(e => e.ByNavn).HasMaxLength(255);
        });

        modelBuilder.Entity<Indkøbsvogn>(entity =>
        {
            entity.HasKey(e => e.IndkøbsvognId).HasName("PK__Indkøbsv__42FA4A74ABD2D7F6");

            entity.ToTable("Indkøbsvogn");

            entity.Property(e => e.IndkøbsvognId).HasColumnName("IndkøbsvognID");
            entity.Property(e => e.BolcheId).HasColumnName("BolcheID");

            entity.HasOne(d => d.Bolche).WithMany(p => p.Indkøbsvogns)
                .HasForeignKey(d => d.BolcheId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Indkøbsvo__Bolch__30F848ED");
        });

        modelBuilder.Entity<ItemTrait>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BolcheId).HasColumnName("BolcheID");
            entity.Property(e => e.StatsId).HasColumnName("StatsID");
            entity.Property(e => e.TraitTypeId).HasColumnName("TraitTypeID");
            entity.Property(e => e.Value).HasMaxLength(255);

            entity.HasOne(d => d.Bolche).WithMany()
                .HasForeignKey(d => d.BolcheId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItemTrait__Bolch__2C3393D0");

            entity.HasOne(d => d.Stats).WithMany()
                .HasForeignKey(d => d.StatsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItemTrait__Stats__2E1BDC42");

            entity.HasOne(d => d.TraitType).WithMany()
                .HasForeignKey(d => d.TraitTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItemTrait__Trait__2D27B809");
        });

        modelBuilder.Entity<Kunder>(entity =>
        {
            entity.HasKey(e => e.KundeId).HasName("PK__Kunder__7F871DE1056026D9");

            entity.ToTable("Kunder");

            entity.HasIndex(e => e.Telefon, "UQ__Kunder__92EB4169D151A36B").IsUnique();

            entity.Property(e => e.KundeId).HasColumnName("KundeID");
            entity.Property(e => e.Adgangskode).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.ForsendelsesInfoId).HasColumnName("ForsendelsesInfoID");
            entity.Property(e => e.Navn).HasMaxLength(255);
            entity.Property(e => e.Telefon).HasMaxLength(255);

            entity.HasOne(d => d.ForsendelsesInfo).WithMany(p => p.Kunders)
                .HasForeignKey(d => d.ForsendelsesInfoId)
                .HasConstraintName("FK__Kunder__Forsende__36B12243");
        });

        modelBuilder.Entity<Ordre>(entity =>
        {
            entity.HasKey(e => e.OrdreId).HasName("PK__Ordre__1B4D5C764EF48E78");

            entity.ToTable("Ordre");

            entity.Property(e => e.OrdreId).HasColumnName("OrdreID");
            entity.Property(e => e.ForsendelsesInfoId).HasColumnName("ForsendelsesInfoID");
            entity.Property(e => e.IndkøbsvognId).HasColumnName("IndkøbsvognID");
            entity.Property(e => e.KundeId).HasColumnName("KundeID");
            entity.Property(e => e.OrdreDato).HasPrecision(3);

            entity.HasOne(d => d.ForsendelsesInfo).WithMany(p => p.Ordres)
                .HasForeignKey(d => d.ForsendelsesInfoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ordre__Forsendel__3B75D760");

            entity.HasOne(d => d.Indkøbsvogn).WithMany(p => p.Ordres)
                .HasForeignKey(d => d.IndkøbsvognId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ordre__Indkøbsvo__3A81B327");

            entity.HasOne(d => d.Kunde).WithMany(p => p.Ordres)
                .HasForeignKey(d => d.KundeId)
                .HasConstraintName("FK__Ordre__KundeID__398D8EEE");
        });

        modelBuilder.Entity<TypeofTrait>(entity =>
        {
            entity.HasKey(e => e.TraitTypeId).HasName("PK__TypeofTr__3DD6F3ED1F188FD8");

            entity.ToTable("TypeofTrait");

            entity.Property(e => e.TraitTypeId).HasColumnName("TraitTypeID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
