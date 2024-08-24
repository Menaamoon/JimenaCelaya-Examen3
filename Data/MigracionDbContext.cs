using Microsoft.EntityFrameworkCore;
using JimenaCelaya_Examen3.Models;

namespace JimenaCelaya_Examen3.Data
{
    public class MigracionDbContext : DbContext
    {
        public MigracionDbContext(DbContextOptions<MigracionDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Viajero> Viajeros { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<EntradaSalida> EntradasSalidas { get; set; }
        public DbSet<Visa> Visas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IDUsuario);

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(100);

            });

            modelBuilder.Entity<Viajero>(entity =>
            {
                entity.HasKey(e => e.IDViajero);

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NumeroPasaporte)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nacionalidad)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FechaNacimiento)
                    .IsRequired();

                entity.HasMany(e => e.EntradasSalidas)
                    .WithOne(d => d.Viajero)
                    .HasForeignKey(d => d.IDViajero)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.Visas)
                    .WithOne(d => d.Viajero)
                    .HasForeignKey(d => d.IDViajero)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.HasKey(e => e.IDPais);

                entity.Property(e => e.NombrePais)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasMany(e => e.Visas)
                    .WithOne(d => d.Pais)
                    .HasForeignKey(d => d.IDPais)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<EntradaSalida>(entity =>
            {
                entity.HasKey(e => e.IDRegistro);

                entity.Property(e => e.FechaEntrada)
                    .IsRequired(false);

                entity.Property(e => e.LugarEntrada)
                    .HasMaxLength(100);

                entity.Property(e => e.FechaSalida)
                    .IsRequired(false);

                entity.Property(e => e.LugarSalida)
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Visa>(entity =>
            {
                entity.HasKey(e => e.IDVisa);

                entity.Property(e => e.FechaEmision)
                    .IsRequired();

                entity.Property(e => e.FechaVencimiento)
                    .IsRequired();
            });
        }
    }
}
