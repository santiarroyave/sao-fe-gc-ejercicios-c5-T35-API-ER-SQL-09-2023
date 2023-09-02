using Microsoft.EntityFrameworkCore;

namespace Ejemplo.Models
{
    public partial class netflixContext : DbContext
    {
        public netflixContext(DbContextOptions<netflixContext> options) : base(options) { }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Videos> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.Id)
                .HasColumnName("id");

                entity.Property(e => e.Apellido)
                .HasColumnName("apellido")
                .HasMaxLength(250)
                .IsUnicode(false);

                entity.Property(e => e.Dni)
                .HasColumnName("dni");

                entity.Property(e => e.Fecha)
                .HasColumnName("fecha")
                .HasColumnType("date");

                entity.Property(e => e.Nombre)
                .HasColumnName("nombre")
                .HasMaxLength(250)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Videos>(entity =>
            {
                entity.ToTable("videos");

                entity.Property(e => e.Id)
                .HasColumnName("id");

                entity.Property(e => e.CliId)
                .HasColumnName("cli_id");

                entity.Property(e => e.Director)
                .HasColumnName("director");

                entity.Property(e => e.Title)
                .HasColumnName("title")
                .HasMaxLength(250)
                .IsUnicode(false);

                entity.HasOne(d => d.Cli)
                .WithMany(p => p.Videos)
                .HasForeignKey(d => d.CliId)
                .HasConstraintName("videos_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
