using Libreria.LogicaAccesoDatos;
using Libreria.LogicaAccesoDatos.Repositorios;
using Libreria.LogicaAplicacion.CasosUso.CUAgencia;
using Libreria.LogicaAplicacion.CasosUso.CUAltaUsuario;
using Libreria.LogicaAplicacion.CasosUso.CUEnvio;
using Libreria.LogicaAplicacion.CasosUso.CULogin;
using Libreria.LogicaAplicacion.CasosUso.CUSeguimiento;
using Libreria.LogicaAplicacion.CasosUso.CUUsuario;
using Libreria.LogicaAplicacion.ICasosUso.ICUAgencia;
using Libreria.LogicaAplicacion.ICasosUso.ICUAltaUsuario;
using Libreria.LogicaAplicacion.ICasosUso.ICUEnvio;
using Libreria.LogicaAplicacion.ICasosUso.ICULogin;
using Libreria.LogicaAplicacion.ICasosUso.ICUSeguimiento;
using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.InterfaceRepositorio;
using Microsoft.EntityFrameworkCore;

namespace LogisticaDeEnvios
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");//DefaultConnection debe coincidir con el nombre designado en el JSON.
            // Registrar el DbContext en el contenedor de servicios
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //DI - REPOS
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>(); 
            builder.Services.AddScoped<IRepositorioAgencia, RepositorioAgencia>();
            builder.Services.AddScoped<IRepositorioEnvio,RepositorioEnvio>();
            builder.Services.AddScoped<IRepositorioSeguimento,RepositorioSeguimiento>();



            //DI - CASOS USO
            builder.Services.AddScoped<ICULogin, CULogin>();
            builder.Services.AddScoped<ICUAltaUsuario, CUAltaUsuario>();
            builder.Services.AddScoped<ICUBorrarUsuario, CUBorrarUsuario>();
            builder.Services.AddScoped<ICUEditarUsuario, CUEditarUsuario>();
            builder.Services.AddScoped<ICUObtenerUsuario, CUObtenerUsuario>();
            builder.Services.AddScoped<ICUListarUsuarios, CUListarUsuarios>();
            builder.Services.AddScoped<ICUAltaEnvio, CUAltaEnvio>();
            builder.Services.AddScoped<ICUListarEnvio, CUListarEnvio>();
            builder.Services.AddScoped<ICUObtenerEnvio, CUObtenerEnvio>();
            builder.Services.AddScoped<ICUListarAgencias, CUListarAgencias>();
            builder.Services.AddScoped<ICUAltaSeguimiento, CUAltaSeguimiento>();
            builder.Services.AddScoped<ICUFinalizarEnvio, CUFinalizarEnvio>();
            builder.Services.AddScoped<ICUListarEnvioUsuario, CUListarEnvioUsuario>();







            builder.Services.AddSession();

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
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
