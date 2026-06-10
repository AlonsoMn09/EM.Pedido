using System;
using System.Collections.Generic;
using EM.Pedido.Entities;
using Microsoft.EntityFrameworkCore;

namespace EM.Pedido.DataAccess.Context;

public partial class BdpedidosContext : DbContext
{
    public BdpedidosContext()
    {
    }

    public BdpedidosContext(DbContextOptions<BdpedidosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Catalogo> Catalogos { get; set; }

    public virtual DbSet<CatalogoDetalle> CatalogoDetalles { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Pedidos> Pedidos { get; set; }

    public virtual DbSet<PedidoDetalle> PedidoDetalles { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("server=localhost,1402;database=bdpedidos;uid=sa;password=Password2026;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Catalogo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Catalogo__3214EC07DA2BB0EF");

            entity.ToTable("Catalogo", "sch_configuracion");

            entity.HasIndex(e => e.Codigo, "UQ__Catalogo__06370DAC56E71385").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [seq_catalogo])");
            entity.Property(e => e.Codigo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("SqlServer");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CatalogoDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Catalogo__3214EC07BAF28BC6");

            entity.ToTable("CatalogoDetalle", "sch_configuracion");

            entity.HasIndex(e => e.Codigo, "UQ__Catalogo__06370DAC2A16AA19").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [seq_catalogo_detalle])");
            entity.Property(e => e.Codigo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("SqlServer");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Valor)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCatalogoNavigation).WithMany(p => p.CatalogoDetalles)
                .HasForeignKey(d => d.IdCatalogo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CatalogoDetalle_ToCatalogo");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3214EC078A5DEEF2");

            entity.ToTable("Cliente", "sch_pedido");

            entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [seq_clientes])");
            entity.Property(e => e.Celular)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.IdTipoDocumentoCat).HasComment("Tipo de documento del cliente");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Representante)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("SqlServer");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRubroCatNavigation).WithMany(p => p.ClienteIdRubroCatNavigations)
                .HasForeignKey(d => d.IdRubroCat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_cliente_ToCatalogoDetalle");

            entity.HasOne(d => d.IdTipoDocumentoCatNavigation).WithMany(p => p.ClienteIdTipoDocumentoCatNavigations)
                .HasForeignKey(d => d.IdTipoDocumentoCat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_ToTipoDocumento");
        });

        modelBuilder.Entity<Pedidos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pedido__3214EC07AD8C5E16");

            entity.ToTable("Pedido", "sch_pedido");

            entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [seq_pedidos])");
            entity.Property(e => e.Adelanto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.TotalBruto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalNeto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("SqlServer");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedido_ToCliente");
        });

        modelBuilder.Entity<PedidoDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PedidoDe__3214EC073D8C8F34");

            entity.ToTable("PedidoDetalle", "sch_pedido");

            entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [seq_pedidos_detalle])");
            entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalBruto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalNeto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("SqlServer");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.PedidoDetalles)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PedidoDetalle_ToPedido");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.PedidoDetalles)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PedidoDetalle_ToProducto");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC072C0F8374");

            entity.ToTable("Producto", "sch_pedido");

            entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [seq_productos])");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("SqlServer");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCategoriaCatNavigation).WithMany(p => p.ProductoIdCategoriaCatNavigations)
                .HasForeignKey(d => d.IdCategoriaCat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Producto_ToCategoria");

            entity.HasOne(d => d.IdMarcaCatNavigation).WithMany(p => p.ProductoIdMarcaCatNavigations)
                .HasForeignKey(d => d.IdMarcaCat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Producto_ToMarca");
        });
        modelBuilder.HasSequence("seq_catalogo");
        modelBuilder.HasSequence("seq_catalogo_detalle");
        modelBuilder.HasSequence("seq_clientes");
        modelBuilder.HasSequence("seq_pedidos");
        modelBuilder.HasSequence("seq_pedidos_detalle");
        modelBuilder.HasSequence("seq_productos");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
