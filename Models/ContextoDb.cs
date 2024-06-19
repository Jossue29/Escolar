using Microsoft.EntityFrameworkCore;
namespace Escolar.Models;

public class ContextoDb : DbContext
{
    public ContextoDb(DbContextOptions<ContextoDb> options) : base(options)
    {

    }
    public DbSet<Estudiante> Estudiantes { get; set; }
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<CursoEstudiante> CursoEstudiantes { get; set; }

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
    }
}
