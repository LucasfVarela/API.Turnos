using API.CoreBusiness.Entity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Nodes;
using API_CoreBusiness.Entity;

namespace API_CoreBusiness.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Turno> Turno { get; set; }
        public DbSet<Comercio> Comercio { get; set; } 
        public DbSet<Servicio> Servicio { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(200);
            });

           
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(200);
            });

           
            modelBuilder.Entity<Turno>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id_Comercio); 
                entity.Property(e => e.Id_Usuario);
                entity.Property(e => e.Id_Servicio); 
                entity.Property(e => e.Status);
                entity.Property(e => e.Fecha_Inicio);
                entity.Property(e => e.Fecha_Fin);
                entity.Property(e => e.Observaciones);

                
                entity.HasOne(t => t.Usuario)
                      .WithMany()
                      .HasForeignKey(t => t.Id_Usuario);

                entity.HasOne(t => t.Comercio) 
                      .WithMany()
                      .HasForeignKey(t => t.Id_Comercio); 

                entity.HasOne(t => t.Servicio)
                      .WithMany()
                      .HasForeignKey(t => t.Id_Servicio);
            });
            
            modelBuilder.Entity<Comercio>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Direccion).HasMaxLength(500);
    
                entity.Property(e => e.DatosAdicionales).HasColumnType("nvarchar(max)"); 
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Id_Comercio).IsRequired();
            });
        }
    }
}