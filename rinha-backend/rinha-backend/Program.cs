using System;
using Microsoft.EntityFrameworkCore;
using rinha_backend.Context;
using rinha_backend.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<RinhaContext>(options => options.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionString")));

builder.Services.AddTransient<IPessoaRepository, PessoaRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<RinhaContext>();
    db.Database.Migrate();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

