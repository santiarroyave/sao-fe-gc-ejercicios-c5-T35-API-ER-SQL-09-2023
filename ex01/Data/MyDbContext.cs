using ex01.Models;
using Microsoft.EntityFrameworkCore;

namespace ex01.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Pieza> piezas { get; set; }
        public DbSet<Piezas_Proveedores> piezas_Proveedores { get; set; }
        public DbSet<Proveedor> proveedores { get; set;}

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pieza>(pieza =>
            {
                pieza.ToTable("Piezas");
                pieza.HasKey(p => p.codigo);
                pieza.Property(p => p.nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Proveedor>(proveedor =>
            {
                proveedor.ToTable("Proveedores");
                proveedor.HasKey(p => p.id);
                proveedor.Property(p => p.id).HasMaxLength(4);
                proveedor.Property(p => p.nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Piezas_Proveedores>(pp =>
            {
                pp.ToTable("suministra");

                pp.HasKey(pp => pp.fk_idProveedor);
                pp.HasKey(pp => pp.fk_codigoPieza);

                pp.Property(p => p.fk_codigoPieza).HasColumnName("codigoPieza");
                pp.Property(p => p.fk_idProveedor).HasColumnName("idProveedor").HasMaxLength(4);

                pp.HasOne(pp => pp.v_pieza).WithMany(pp => pp.v_piezas_proveedores).HasForeignKey(pp => pp.fk_codigoPieza);
                pp.HasOne(pp => pp.v_proveedores).WithMany(pp => pp.v_piezas_proveedores).HasForeignKey(pp => pp.fk_idProveedor);
            });
        }
    }
}
