using Cibertec.PokemonApi.API.Common.Security;
using Cibertec.PokemonApi.Application.DI;
using Cibertec.PokemonApi.Domain.Repositories;
using Cibertec.PokemonApi.Domain.Servicios;
using Cibertec.PokemonApi.Infraestructure.Context;
using Cibertec.PokemonApi.Infraestructure.DI;
using Cibertec.PokemonApi.Infraestructure.Repositories;
using Cibertec.PokemonApi.Infraestructure.Servicios;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AplicacionReact",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddApplicationServices();
builder.Services.AddAuthenticationByJWT();
builder.Services.AddLogger(builder.Configuration);

builder.Services.AddSqlite<PokemonApiDbContext>(builder.Configuration.GetConnectionString("SQLiteConnection"));

builder.Services.AddHttpClient<PokeApiService>();

builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IPokemonApiRepository, PokemonApiRepository>();
builder.Services.AddTransient<IPokemonRepository, PokemonRepository>();

builder.Services.AddTransient<ITokenService, TokenServicio>();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AplicacionReact");

app.UseStaticFiles();

app.MapControllers();
app.Run();
