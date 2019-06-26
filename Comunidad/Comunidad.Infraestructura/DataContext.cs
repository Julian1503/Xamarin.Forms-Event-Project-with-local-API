namespace Comunidad.Infraestructura
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Dominio.Entidades;
    using Dominio.MetaData;
    using Microsoft.EntityFrameworkCore;
    
    using static Conexion.CadenaConexion;

    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ObtenerCadenaConexionWin);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFks = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFks)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Acreditacion
            modelBuilder.Entity<Acreditacion>().HasOne(x => x.Persona)
                .WithMany(x => x.Acreditaciones)
                .HasForeignKey(x => x.PersonaId)
                .HasConstraintName("FK_Acreditacion_Persona");

            modelBuilder.Entity<Acreditacion>().HasOne(x => x.Programacion)
                .WithMany(x => x.Acreditaciones)
                .HasForeignKey(x => x.ProgramacionId)
                .HasConstraintName("FK_Acreditacion_Programacion");

         //Entrada
        

            modelBuilder.Entity<Entrada>().HasOne(x => x.Evento)
                .WithMany(x => x.Entradas)
                .HasForeignKey(x => x.EventoId)
                .HasConstraintName("FK_Entrada_Evento");

            // Evento
            modelBuilder.Entity<Evento>().HasOne(x => x.TipoEvento)
                .WithMany(x => x.Eventos)
                .HasForeignKey(x => x.TipoEventoId)
                .HasConstraintName("FK_Evento_TipoEvento");

            modelBuilder.Entity<Evento>().HasOne(x => x.TemaEvento)
                .WithMany(x => x.Eventos)
                .HasForeignKey(x => x.TemaEventoId)
                .HasConstraintName("FK_Evento_TemaEvento");


       

     
            // Inscripcion
            modelBuilder.Entity<Inscripcion>().HasOne(x => x.Entrada)
                .WithMany(x => x.Inscripciones)
                .HasForeignKey(x => x.EntradaId)
                .HasConstraintName("FK_Inscripcion_Entrada");

            modelBuilder.Entity<Inscripcion>().HasOne(x => x.Persona)
                .WithMany(x => x.Inscripciones)
                .HasForeignKey(x => x.PersonaId)
                .HasConstraintName("FK_Inscripcion_Persona");

             
            // Persona
            modelBuilder.Entity<Persona>().HasMany(x => x.Inscripciones)
                .WithOne(x => x.Persona)
                .HasForeignKey(x => x.PersonaId)
                .HasConstraintName("FK_Persona_Inscripciones");



            modelBuilder.Entity<Persona>().HasMany(x => x.Acreditaciones)
                .WithOne(x => x.Persona)
                .HasForeignKey(x => x.PersonaId)
                .HasConstraintName("FK_Persona_Acreditaciones");

            modelBuilder.Entity<Persona>().HasOne(x => x.Usuario)
                .WithOne(x => x.Persona)
                .HasConstraintName("FK_Persona_Usuario");

            //Usuario

            modelBuilder.Entity<Usuario>().HasOne(x => x.Persona)
                .WithOne(x => x.Usuario)
                .HasConstraintName("FK_Usuario_Persona");

            // Programacion
            modelBuilder.Entity<Programacion>().HasMany(x => x.Acreditaciones)
                .WithOne(x => x.Programacion)
                .HasForeignKey(x => x.ProgramacionId)
                .HasConstraintName("FK_Programacion_Acreditaciones");

            modelBuilder.Entity<Programacion>().HasOne(x => x.Evento)
                .WithMany(x => x.Programaciones)
                .HasForeignKey(x => x.EventoId)
                .HasConstraintName("FK_Programacion_Evento");

          
            // Tema Evento
            modelBuilder.Entity<TemaEvento>().HasMany(x => x.Eventos)
                .WithOne(x => x.TemaEvento)
                .HasForeignKey(x => x.TemaEventoId)
                .HasConstraintName("FK_TemaEvento_Eventos");

            // Tipo Evento
            modelBuilder.Entity<TipoEvento>().HasMany(x => x.Eventos)
                .WithOne(x => x.TipoEvento)
                .HasForeignKey(x => x.TipoEventoId)
                .HasConstraintName("FK_TipoEvento_Eventos");


            // Configuracion de Entidades
            modelBuilder.ApplyConfiguration<Acreditacion>(new AcreditacionMetaData());
            modelBuilder.ApplyConfiguration<Entrada>(new EntradaMetaData());
            modelBuilder.ApplyConfiguration<Evento>(new EventoMetaData());
            modelBuilder.ApplyConfiguration<Inscripcion>(new InscripcionMetaData());
            modelBuilder.ApplyConfiguration<Ocupacion>(new OcupacionMetaData());
            modelBuilder.ApplyConfiguration<Pais>(new PaisMetaData());
            modelBuilder.ApplyConfiguration<Persona>(new PersonaMetaData());
            modelBuilder.ApplyConfiguration<Programacion>(new ProgramacionMetaData());
            modelBuilder.ApplyConfiguration<TemaEvento>(new TemaEventoMetaData());
            modelBuilder.ApplyConfiguration<TipoEvento>(new TipoEventoMetaData());
            modelBuilder.ApplyConfiguration<Ubicacion>(new UbicacionMetaData());
            modelBuilder.ApplyConfiguration<Usuario>(new UsuarioMetaData());

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entidad in ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Deleted
                            && x.OriginalValues.Properties
                                .Any(p => p.Name.Contains("EstaBorrado"))))
            {
                entidad.State = EntityState.Unchanged;
                entidad.CurrentValues["EstaBorrado"] = true;
            }

            return base.SaveChangesAsync();
        }

        // Mapeo

        public DbSet<Acreditacion> Acreditaciones { get; set; }

 
        public DbSet<Entrada> Entradas { get; set; }

        public DbSet<Evento> Eventos { get; set; }


        public DbSet<Inscripcion> Inscripciones { get; set; }


        public DbSet<Ocupacion> Ocupaciones { get; set; }

        public DbSet<Pais> Paises { get; set; }

        public DbSet<Persona> Personas { get; set; }

        public DbSet<Programacion> Programaciones { get; set; }


        public DbSet<TemaEvento> TemaEventos { get; set; }

        public DbSet<TipoEvento> TipoEventos { get; set; }

        public DbSet<Ubicacion> Ubicaciones { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
