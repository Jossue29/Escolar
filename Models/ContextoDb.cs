using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Escolar.Models
{
    public class ContextoDb : IdentityDbContext
    {
        public ContextoDb(DbContextOptions<ContextoDb> options)
            : base(options)
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<CursoEstudiante> CursoEstudiantes { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la relación muchos a muchos entre Curso y Estudiante
            modelBuilder.Entity<CursoEstudiante>()
                .HasKey(ce => new { ce.CursoId, ce.EstudianteId });

            modelBuilder.Entity<CursoEstudiante>()
                .HasOne(ce => ce.Curso)
                .WithMany(c => c.CursoEstudiantes)
                .HasForeignKey(ce => ce.CursoId);

            modelBuilder.Entity<CursoEstudiante>()
                .HasOne(ce => ce.Estudiante)
                .WithMany(e => e.CursoEstudiantes)
                .HasForeignKey(ce => ce.EstudianteId);

            modelBuilder.Entity<Asignatura>()
                .HasOne(a => a.Profesor)
                .WithMany(p => p.Asignaturas)
                .HasForeignKey(a => a.ProfesorId);

            // Configuración de la relación uno a muchos entre Curso y Asignatura
            modelBuilder.Entity<Asignatura>()
                .HasOne(a => a.Curso)
                .WithMany()
                .HasForeignKey(a => a.CursoId);
        }
    }
}
