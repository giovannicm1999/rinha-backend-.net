using System;
using Microsoft.EntityFrameworkCore;
using rinha_backend.Context;
using rinha_backend.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<RinhaContext>(options => options.UseNpgsql("Host=db;Database=root;Username=postgres;Password=2309"));

builder.Services.AddTransient<IPessoaRepository, PessoaRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<RinhaContext>();
        db.Database.Migrate();
    }
    catch (Exception ex)
    {

    }
}

app.UseAuthorization();

app.MapControllers();

app.Run();

