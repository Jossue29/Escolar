using Escolar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var conn = builder.Configuration.GetConnectionString("ConexionDb");

builder.Services.AddDbContext<ContextoDb>( options =>
  options.UseMySql(conn, ServerVersion.AutoDetect(conn))
);

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ContextoDb>();
builder.Services.AddScoped<IrepositorioCurso, CursoRepositorio>();
builder.Services.AddScoped<IrepositorioEstudiante, EstudianteRepositorio>();
builder.Services.AddScoped<IRepositorioCursoEstudiante, CursoEstudianteRepositorio>();
builder.Services.AddScoped<IrepositorioProfesor, ProfesorRepositorio>();
builder.Services.AddScoped<IrepositorioAsignatura, AsignaturaRepositorio>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
