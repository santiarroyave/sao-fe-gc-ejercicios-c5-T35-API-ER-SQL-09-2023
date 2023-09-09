using ex02.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ex02.Data
{
    public class MyDbContext : DbContext
    {
        // Atributos
        public DbSet<Proyecto> proyecto { get; set; }
        public DbSet<Cientifico> cientifico { get; set; }
        public DbSet<Cientifico_Proyecto> cientifico_Proyectos { get; set; }

        // Constructor
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        // Metodos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tabla intermedia (Cientifico_Proyecto)
            modelBuilder.Entity<Cientifico_Proyecto>(cp =>
            {
                cp.ToTable("asignado_a");
                cp.HasKey(cp => cp.fk_cientifico_dni);
                cp.HasKey(cp => cp.fk_proyecto_id);

                cp.HasOne(p => p.v_cientifico).WithMany(p => p.v_cientifico_proyecto).HasForeignKey(p => p.fk_cientifico_dni);
                cp.HasOne(p => p.v_proyecto).WithMany(p => p.v_cientifico_proyecto).HasForeignKey(p => p.fk_proyecto_id);

                cp.Property(p => p.fk_proyecto_id).HasColumnName("proyecto");
                cp.Property(p => p.fk_cientifico_dni).HasColumnName("cientifico");
            });

            // TablaA (Cientifico)
            modelBuilder.Entity<Cientifico>(cientifico =>
            {
                cientifico.ToTable("Cliente");
                cientifico.HasKey(p => p.dni);
                cientifico.Property(p => p.dni).HasMaxLength(8);
                cientifico.Property(p => p.nomApels).HasMaxLength(255);
            });

            // TablaB (Proyecto)
            modelBuilder.Entity<Proyecto>(proyecto =>
            {
                proyecto.ToTable("Proyecto");
                proyecto.HasKey(p => p.id);
                proyecto.Property(p => p.id).HasMaxLength(4);
                proyecto.Property(p => p.nombre).HasMaxLength(255);
            });
        }
    }
}
