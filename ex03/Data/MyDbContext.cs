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
                producto.ToTable("PRODUCTOS");
                producto.HasKey(p => p.codigo);

                producto.Property(p => p.codigo).HasColumnName("Codigo").ValueGeneratedOnAdd();
                producto.Property(p => p.nombre).HasColumnName("Nombre").HasMaxLength(100);
                producto.Property(p => p.precio).HasColumnName("Precio");
            });

            modelBuilder.Entity<Cajero>(cajero =>
            {
                cajero.ToTable("CAJEROS");
                cajero.HasKey(p => p.codigo);

                cajero.Property(p => p.codigo).HasColumnName("Codigo").ValueGeneratedOnAdd();
                cajero.Property(p => p.nomApels).HasColumnName("NomApels").HasMaxLength(255);
            });

            modelBuilder.Entity<Maquina_Registradora>(maquina =>
            {
                maquina.ToTable("MAQUINAS_REGISTRADORAS");
                maquina.HasKey(p => p.codigo);

                maquina.Property(p => p.codigo).HasColumnName("Codigo").ValueGeneratedOnAdd();
                maquina.Property(p => p.piso).HasColumnName("Piso");
            });

            modelBuilder.Entity<Venta>(venta =>
            {
                venta.ToTable("VENTA");
                venta.HasKey(p => new {p.fk_producto, p.fk_cajero, p.fk_maquina});

                venta.Property(p => p.fk_producto).HasColumnName("Producto");
                venta.Property(p => p.fk_cajero).HasColumnName("Cajero");
                venta.Property(p => p.fk_maquina).HasColumnName("Maquina");

                venta.HasOne(p => p.v_producto).WithMany(p => p.v_venta).HasForeignKey(p => p.fk_producto);
                venta.HasOne(p => p.v_cajero).WithMany(p => p.v_venta).HasForeignKey(p => p.fk_cajero);
                venta.HasOne(p => p.v_maquina).WithMany(p => p.v_venta).HasForeignKey(p => p.fk_maquina);
            });
        }
    }
}
