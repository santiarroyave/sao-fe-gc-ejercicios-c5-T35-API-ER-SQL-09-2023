using ex03.Models;
using Microsoft.EntityFrameworkCore;

namespace ex03.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Producto> productos { get; set; }
        public DbSet<Cajero> cajeros { get; set; }
        public DbSet<Maquina_Registradora> maquinasRegistradoras { get; set; }
        public DbSet<Venta> ventas { get; set; }

        public MyDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(producto =>
            {
                producto.ToTable("Productos");
                producto.HasKey(p => p.codigo);

                producto.Property(p => p.nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Cajero>(cajero =>
            {
                cajero.ToTable("Productos");
                cajero.HasKey(p => p.codigo);

                cajero.Property(p => p.nomApels).HasMaxLength(255);
            });

            modelBuilder.Entity<Maquina_Registradora>(maquina =>
            {
                maquina.ToTable("Maquinas_Registradoras");
                maquina.HasKey(p => p.codigo);
            });

            modelBuilder.Entity<Venta>(venta =>
            {
                venta.ToTable("Venta");
                venta.HasKey(p => p.fk_producto);
                venta.HasKey(p => p.fk_cajero);
                venta.HasKey(p => p.fk_maquina);

                venta.Property(p => p.fk_producto).HasColumnName("producto");
                venta.Property(p => p.fk_cajero).HasColumnName("cajero");
                venta.Property(p => p.fk_maquina).HasColumnName("maquina");

                venta.HasOne(p => p.v_producto).WithMany(p => p.v_venta).HasForeignKey(p => p.fk_producto);
                venta.HasOne(p => p.v_cajero).WithMany(p => p.v_venta).HasForeignKey(p => p.fk_cajero);
                venta.HasOne(p => p.v_maquina).WithMany(p => p.v_venta).HasForeignKey(p => p.fk_maquina);
            });
        }
    }
}
