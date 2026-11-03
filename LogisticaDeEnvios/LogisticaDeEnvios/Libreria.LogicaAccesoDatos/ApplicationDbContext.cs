using Libreria.LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAccesoDatos
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<EnvioComun> EnviosComunes { get; set; }
        public DbSet<EnvioUrgente> EnviosUrgentes { get; set; }
        public DbSet<Seguimiento> Seguimientos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ----- ENUMS -----
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Rol)
                .HasConversion<int>();

            modelBuilder.Entity<Envio>()
                .Property(e => e.Estado)
                .HasConversion<int>();

            // ----- HERENCIA -----
            modelBuilder.Entity<Envio>()
                .HasDiscriminator<string>("TipoEnvio")
                .HasValue<EnvioComun>("EnvioComun")
                .HasValue<EnvioUrgente>("EnvioUrgente");
            modelBuilder.Entity<Envio>()
                .HasIndex(e => e.Tracking)
                .IsUnique();

            /*Configuro el tipo de dato decimal para EF core*/
            modelBuilder.Entity<Envio>()
                     .Property(d => d.Peso)
                     .HasPrecision(18, 4); // o HasColumnType("decimal(18,4)")

            // ----- AGENCIA -----
            modelBuilder.Entity<Agencia>()
                .OwnsOne(a => a.Ubicacion);

            modelBuilder.Entity<Agencia>()
              .HasMany(a => a.Usuarios)
              .WithOne(u => u.Agencia)
              .HasForeignKey(u => u.AgenciaId)
              .OnDelete(DeleteBehavior.Restrict);


            // ----- ENVÍO COMUN -> AGENCIA (Destino) -----
            modelBuilder.Entity<EnvioComun>()
                .HasOne(c => c.Destino)
                .WithMany()
                .HasForeignKey("DestinoId")
                .OnDelete(DeleteBehavior.Restrict); // también evitar cascada

            // ----- SEGUIMIENTO -----
            modelBuilder.Entity<Seguimiento>()
                .HasOne(s => s.Envio)
                .WithMany(e => e.Seguimientos)
                .HasForeignKey("EnvioId")
                .OnDelete(DeleteBehavior.Cascade); // solo una cascada permitida

            modelBuilder.Entity<Seguimiento>()
                .HasOne<Usuario>()
                .WithMany()
                .HasForeignKey("EmpleadoId")
                .OnDelete(DeleteBehavior.Restrict);
            //Relacion multiple entre envio y usuario
            modelBuilder.Entity<Envio>()
                .HasOne(e => e.Cliente)
                .WithMany()
                .HasForeignKey(v => v.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Envio>()
               .HasOne(v => v.Funcionario)
               .WithMany()
               .HasForeignKey(v => v.FuncionarioId)
               .OnDelete(DeleteBehavior.Restrict);

        }

    }
}

