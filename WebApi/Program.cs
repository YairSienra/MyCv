using Aplicacion.Usuarios;
using Dominio.Usuarios;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Persistencia;
using MediatR;
using System.Text.Json.Serialization;
using System.Reflection;
using Aplicacion.Contratos;
using Seguridad.Seguridad;
using WebApi.Reposirtorios;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Seguridad;
using Aplicacion.CV;
using FluentValidation.AspNetCore;
using Aplicacion.Comentarios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// contenedor para registros de ususarios y logueo //

var contenedor = builder.Services.AddIdentity<User, IdentityRole>(x =>
{
    x.Password.RequireDigit = false;
    x.Password.RequireLowercase = false;
    x.Password.RequireUppercase = false;
    x.Password.RequireNonAlphanumeric = false;
}

);

contenedor.AddSignInManager<SignInManager<User>>();
contenedor.AddEntityFrameworkStores<BaseDeDatosSB>();
var identityBuilder = new IdentityBuilder(contenedor.UserType, contenedor.Services);

 // Para Crear Roles

contenedor.AddRoles<IdentityRole>();
contenedor.AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<User, IdentityRole>>();
contenedor.AddEntityFrameworkStores<BaseDeDatosSB>();
builder.Services.TryAddSingleton<ISystemClock, SystemClock>();


// FluentValidation //

builder.Services.AddFluentValidation( cfg => cfg.RegisterValidatorsFromAssemblyContaining<EnviarComentario.Ejecuta>());


// JWT //


var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mi palabra secreta"));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key.Key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
// =========================================================================================

builder.Services.AddScoped<UserManager<User>>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
builder.Services.AddOptions();
builder.Services.AddCors(o => o.AddPolicy("corsApp", builder =>
{
    builder.AllowAnyHeader().AllowAnyHeader().AllowAnyOrigin();
}));
builder.Services.AddMvc();
builder.Services.AddControllers(opt =>
{
    var json = opt.InputFormatters.OfType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonInputFormatter>().Single();
    json.SupportedMediaTypes.Add("application/csp-report");

});

builder.Services.AddMediatR(typeof(CrearUsuario.Ejecuta).Assembly, typeof(Login.Ejecuta).Assembly, typeof(ObtenerCabecera.Ejecuta).Assembly);
builder.Services.AddScoped<IJwtGenerador, JwtGenerador>();
builder.Services.AddTransient<IRepositorios, Repositorio>();
builder.Services.AddCors();
builder.Services.AddCors(options =>
{
    var MyAllowSpecificOrigins = "_MyAllowSubdomainPolicy";
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://example.com",
                                              "http://www.contoso.com");
                      });
});
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

// ----------------------------------------- Conexion Base De Datos SB
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BaseDeDatosSB>(opt => {
    opt.UseSqlServer(connection, b => b.MigrationsAssembly("Persistencia"));
});
// ------------------------------------------------------------------------------


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyPolicy");
//app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();






