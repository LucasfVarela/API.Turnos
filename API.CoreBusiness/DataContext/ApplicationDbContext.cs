<<<<<<< HEAD
﻿using API.CoreBusiness.Entity;
using API_CoreBusiness.Entity;
=======
﻿using API_CoreBusiness.Entity;
>>>>>>> rm-LN
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_CoreBusiness.DataContext
{
    public class ApplicationDbContext : DbContext
    {
<<<<<<< HEAD
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Turno> Turno { get; set; }

=======
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options) 
        {
                
        }

        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<Servicio> Servicio { get; set; }   
>>>>>>> rm-LN

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuraciones adicionales
            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.Id);
<<<<<<< HEAD
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Email);
                entity.HasKey(e => e.Fecha_Add);
                entity.Property(e => e.Fecha_Mod);
                entity.Property(e => e.PasswordSalt);
                entity.Property(e => e.PasswordHash);
                entity.Property(e => e.Activo);
                ;

            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Email);
                entity.HasKey(e => e.Fecha_Add);
                entity.Property(e => e.Fecha_Mod);
                entity.Property(e => e.PasswordSalt);
                entity.Property(e => e.PasswordHash);
                entity.Property(e => e.Activo);
                ;

            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id_Cliente);
                entity.Property(e => e.Id_Usuario);
                entity.Property(e => e.Status);
                entity.Property(e => e.Fecha_Inicio);
                entity.Property(e => e.Fecha_Fin);
                entity.Property(e => e.Observaciones);

                entity.HasOne(t => t.Usuario)
                      .WithMany()
                      .HasForeignKey(t => t.Id_Usuario);

                entity.HasOne(t => t.Cliente)
                      .WithMany()
                      .HasForeignKey(t => t.Id_Cliente);

            });


=======

                entity.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(e => e.Email);
                entity.Property(e => e.Fecha_Add);
                entity.Property(e => e.Fecha_Mod);
                entity.Property(e => e.PasswordSalt);
                entity.Property(e => e.PasswordHash);
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Precio).IsRequired().HasColumnType("decimal(18,2)");
            });

>>>>>>> rm-LN
        }
    }
}
