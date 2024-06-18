using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FerremasProductos.Models;

public partial class DucogymContext : DbContext
{
    public DucogymContext()
    {
    }

    public DucogymContext(DbContextOptions<DucogymContext> options)
        : base(options)
    {
    }

    public virtual DbSet<IpPrecio> IpPrecios { get; set; }

    public virtual DbSet<IpProducto> IpProductos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IpPrecio>(entity =>
        {
            entity.HasKey(e => e.IdPrecio).HasName("PK__IP_Preci__2450584BDC887E24");

            entity.ToTable("IP_Precio");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");

            entity.HasMany(d => d.IdProductos).WithMany(p => p.IdPrecios)
                .UsingEntity<Dictionary<string, object>>(
                    "IpPrecioProducto",
                    r => r.HasOne<IpProducto>().WithMany()
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__IP_Precio__IdPro__7755B73D"),
                    l => l.HasOne<IpPrecio>().WithMany()
                        .HasForeignKey("IdPrecio")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__IP_Precio__IdPre__76619304"),
                    j =>
                    {
                        j.HasKey("IdPrecio", "IdProducto").HasName("PK__IP_Preci__34C8D16ADF80A450");
                        j.ToTable("IP_PrecioProducto");
                    });
        });

        modelBuilder.Entity<IpProducto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__IP_Produ__098892109670DC0C");

            entity.ToTable("IP_Producto");

            entity.Property(e => e.Codigo).HasMaxLength(50);
            entity.Property(e => e.CodigoProducto).HasMaxLength(100);
            entity.Property(e => e.Marca).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
