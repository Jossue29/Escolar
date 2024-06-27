using Escolar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Inyeccion de dependencia de Mysql
var conn = builder.Configuration.GetConnectionString("ConexionDb") ??
   throw new InvalidOperationException("Connection string 'ConexionDb' not found.");

builder.Services.AddDbContext<ContextoDb>( options =>
  options.UseMySql(conn, ServerVersion.AutoDetect(conn))
);

builder.Services.AddDefaultIdentity<IdentityUser>()
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ContextoDb>();

builder.Services.AddScoped<IrepositorioCurso, CursoRepositorio>();
builder.Services.AddScoped<IrepositorioEstudiante, EstudianteRepositorio>();
builder.Services.AddScoped<IRepositorioCursoEstudiante, CursoEstudianteRepositorio>();
builder.Services.AddScoped<IrepositorioProfesor, ProfesorRepositorio>();
builder.Services.AddScoped<IrepositorioAsignatura, AsignaturaRepositorio>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true; // Make the session cookie essential
});

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

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
