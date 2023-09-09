using ex04.Models;
using Microsoft.EntityFrameworkCore;

namespace ex04.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Facultad> facultades { get; set; }
        public DbSet<Equipo> equipos { get; set; }
        public DbSet<Investigador> investigadores { get; set; }
        public DbSet<Reserva> reservas { get; set; }


        public MyDbContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Facultad>(facultad =>
            {
                facultad.ToTable("FACULTAD");
                facultad.HasKey(p => p.codigo);

                facultad.Property(p => p.codigo).HasColumnName("Codigo");
                facultad.Property(p => p.nombre).HasColumnName("Nombre").HasMaxLength(100);
            });

            modelBuilder.Entity<Equipo>(equipo =>
            {
                equipo.ToTable("EQUIPOS");
                equipo.HasKey(p => p.numSerie);

                equipo.Property(p => p.numSerie).HasColumnName("NumSerie").HasMaxLength(4);
                equipo.Property(p => p.nombre).HasColumnName("Nombre").HasMaxLength(100);

                equipo.Property(p => p.fk_facultad).HasColumnName("Facultad").IsRequired();
                equipo.HasOne(p => p.v_facultad).WithMany(p => p.v_equipos).HasForeignKey(p => p.fk_facultad);
            });

            modelBuilder.Entity<Investigador>(investigador =>
            {
                investigador.ToTable("INVESTIGADORES");
                investigador.HasKey(p => p.dni);

                investigador.Property(p => p.dni).HasColumnName("DNI").HasMaxLength(8);
                investigador.Property(p => p.nomApels).HasColumnName("NomApels").HasMaxLength(255);

                investigador.Property(p => p.fk_facultad).HasColumnName("Facultad").IsRequired();
                investigador.HasOne(p => p.v_facultad).WithMany(p => p.v_investigadores).HasForeignKey(p => p.fk_facultad);
            });

            modelBuilder.Entity<Reserva>(reserva =>
            {
                reserva.ToTable("RESERVA");
                reserva.HasKey(p => new { p.fk_dni, p.fk_numSerie });

                reserva.Property(p => p.fk_dni).HasColumnName("DNI").HasMaxLength(8);
                reserva.Property(p => p.fk_numSerie).HasColumnName("NumSerie").HasMaxLength(4);
                reserva.Property(p => p.comienzo).HasColumnName("Comienzo");
                reserva.Property(p => p.fin).HasColumnName("Fin");

                reserva.HasOne(p => p.v_investigador).WithMany(p => p.v_reservas).HasForeignKey(p => p.fk_dni);
                reserva.HasOne(p => p.v_equipo).WithMany(p => p.v_reservas).HasForeignKey(p => p.fk_numSerie);
            });
        }
    }
}
