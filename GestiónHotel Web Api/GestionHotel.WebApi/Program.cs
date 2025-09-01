using GestionHotel.ApplicationLogic.InterfacesUseCase;
using GestionHotel.ApplicationLogic.UseCase;
using GestionHotel.BusinessLogic.Interfaces;
using GestionHotel.DataAccess.Repositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


var rutaArchivo = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GestionHotel.WebApi.xml");
builder.Services.AddSwaggerGen(opciones =>
{
    //Se agrega la opcion de autenticarse en Swagger
    opciones.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
    {
        Description = "Autorizacion estandar mediante esquema Bearer",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    opciones.OperationFilter<SecurityRequirementsOperationFilter>();

    //Se agregan las opciones para la documentación de swagger
    opciones.IncludeXmlComments(rutaArchivo);
    opciones.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Documentación de GestionHotel.WebApi",
        Description = "Aqui se encuentran todos los endpoint activos para utilizar los servicios del proyecto GestionHotel",
        Contact = new OpenApiContact
        {
            Email = "placeholder"
        },
        Version = "v1"
    });
});

// Configurar de la autenticacion
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opciones =>
{
    opciones.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:SecretTokenKey").Value!)),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});


/**************************** REPOSITORIOS **********************************/
builder.Services.AddScoped<IRepositorioConfiguracion, SQLRepositorioConfiguracion>();
builder.Services.AddScoped<IRepositorioTipo, SQLRepositorioTipo>();
builder.Services.AddScoped<IRepositorioCabania, SQLRepositorioCabania>();
builder.Services.AddScoped<IRepositorioMantenimiento, SQLRepositorioMantenimiento>();
builder.Services.AddScoped<IRepositorioUsuario, SQLRepositorioUsuario>();

/**************************** CASOS DE USO **********************************/
builder.Services.AddScoped<IUCAgregarTipo, UCAgregarTipo>();
builder.Services.AddScoped<IUCEditarTipo, UCEditarTipo>();
builder.Services.AddScoped<IUCEliminarTipo, UCEliminarTipo>();
builder.Services.AddScoped<IUCObtenerTipos, UCObtenerTipos>();

builder.Services.AddScoped<IUCAgregarCabania, UCAgregarCabania>();
builder.Services.AddScoped<IUCEditarCabania, UCEditarCabania>();
builder.Services.AddScoped<IUCEliminarCabania, UCEliminarCabania>();
builder.Services.AddScoped<IUCObtenerCabanias, UCObtenerCabanias>();

builder.Services.AddScoped<IUCAgregarMantenimiento, UCAgregarMantenimiento>();
builder.Services.AddScoped<IUCEditarMantenimiento, UCEditarMantenimiento>();
builder.Services.AddScoped<IUCEliminarMantenimiento, UCEliminarMantenimiento>();
builder.Services.AddScoped<IUCObtenerMantenimientos, UCObtenerMantenimientos>();

builder.Services.AddScoped<IUCObtenerUsuario, UCObtenerUsuario>();


//builder.Services.AddScoped<IUCGetUsuarioPorEmail, UCGetUsuarioPorEmail>();

// Configurar la autorización
builder.Services.AddAuthorization(opciones =>
{
    opciones.DefaultPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// autorization y authentication
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
