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
                facultad.ToTable("facultad");
                facultad.HasKey(p => p.codigo);

                facultad.Property(p => p.nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Equipo>(equipo =>
            {
                equipo.ToTable("equipos");
                equipo.HasKey(p => p.numSerie);

                equipo.Property(p => p.numSerie).HasMaxLength(4);
                equipo.Property(p => p.nombre).HasMaxLength(100);

                equipo.Property(p => p.fk_facultad).IsRequired().HasColumnName("facultad");
            });

            modelBuilder.Entity<Investigador>(investigador =>
            {
                investigador.ToTable("investigadores");
                investigador.HasKey(p => p.dni);

                investigador.Property(p => p.dni).HasMaxLength(8);
                investigador.Property(p => p.nomApels).HasMaxLength(255);

                investigador.Property(p => p.fk_facultad).IsRequired().HasColumnName("facultad");
            });

            modelBuilder.Entity<Reserva>(reserva =>
            {
                reserva.ToTable("reserva");
                reserva.HasKey(p => p.fk_dni);
                reserva.HasKey(p => p.fk_numSerie);

                reserva.Property(p => p.fk_dni).HasMaxLength(8).HasColumnName("dni");
                reserva.Property(p => p.fk_numSerie).HasMaxLength(4).HasColumnName("numSerie");

                reserva.HasOne(p => p.v_investigador).WithMany(p => p.v_reservas).HasForeignKey(p => p.fk_dni);
                reserva.HasOne(p => p.v_equipo).WithMany(p => p.v_reservas).HasForeignKey(p => p.fk_numSerie);
            });
        }
    }
}
