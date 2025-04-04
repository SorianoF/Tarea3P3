using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Consultorio> Consultorios { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Cita> Citas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Consultorio)
                .WithMany(c => c.users)
                .HasForeignKey(u => u.ConsultorioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Medico>()
                .HasOne(m => m.Consultorio)
                .WithMany(c => c.Medicos)
                .HasForeignKey(m => m.CusultorioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cita>()
                 .HasOne(c => c.Paciente)
                .WithMany()
                .HasForeignKey(c => c.PacienteId);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Medico)
                .WithMany()
                .HasForeignKey(c => c.MedicoId);

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.Username)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(u => u.PasswordHash)
                    .IsRequired();
            });

            modelBuilder.Entity<Consultorio>(entity =>
            {
                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
