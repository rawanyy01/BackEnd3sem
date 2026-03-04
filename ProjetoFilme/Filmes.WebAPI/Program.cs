using Filmes.WebAPI.BdContextFilme;
using Filmes.WebAPI.Interfaces;
using Filmes.WebAPI.Repositories;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FilmeContext>
(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddAuthentication(options => { options.DefaultChallengeScheme = "JwyBearer"; options.DefaultAuthenticateScheme = "JwyBearer"; })
    .AddJwtBearer("JwyBearer", options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,

            ValidateAudience = true,

            ValidateLifetime = true,

            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autentificacao-webapi-dev")),

            ClockSkew = TimeSpan.FromMinutes(5),

            ValidIssuer = "api-filmes",

            ValidAudience = "api-filmes"
        };
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
{
    Version = "v1",
    Title = "Filmes Api",
    Description = "Uma API com catálogo de filmes",
    TermsOfService = new Uri("https://exemplo.com/terms"),
    Contact = new Microsoft.OpenApi.OpenApiContact
    {
        Name = "rawanyy01",
        Url = new Uri("https://github.com/rawanyy01")
    },
    License = new Microsoft.OpenApi.OpenApiLicense
    {
        Name = "Example License",
        Url = new Uri("https://exemplo.com/License")
    }
});

options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
{
    Name = "Authorizationn",
    Type = SecuritySchemeType.Http,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "Insira o token JWT"
});

    options.AddSecurityRequirement(documento => new OpenApiSecurityRequirement
    {

        [new OpenApiSecuritySchemeReference("Bearer", documento)] = Array.Empty<string>().ToList(),

    });

});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});



builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options => { });

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/Swagger/v1/Swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });

    
}

app.UseCors("CorsPolicy");

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
