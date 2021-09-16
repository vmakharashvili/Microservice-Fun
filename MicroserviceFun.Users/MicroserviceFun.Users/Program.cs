using MicroserviceFun.Users.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


IConfiguration _config;
builder.Host.ConfigureAppConfiguration((context, config) =>
{
    _config = config.Build();
    builder.Services.AddDbContext<UsersDbContext>(c =>
    {
        Console.WriteLine(_config.GetSection("ConnectionStrings:DefaultconnectionString").Value);
        c.UseSqlServer(_config.GetSection("ConnectionStrings:DefaultconnectionString").Value);
    }, ServiceLifetime.Scoped);

});


builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "MicroserviceFun.Users", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

var scope = app.Services.CreateScope();
var usersDbContextOptions = scope.ServiceProvider.GetService<DbContextOptions<UsersDbContext>>() ?? throw new InvalidOperationException("No DbContext Options");
using (var context = new UsersDbContext(usersDbContextOptions))
{
    context.Database.EnsureCreated();
}

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MicroserviceFun.Users v1"));

app.UseAuthorization();

app.MapControllers();

app.Run();
