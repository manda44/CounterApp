using CounterAppBack.Application.Interfaces;
using CounterAppBack.Application.Services;
using CounterAppBack.Infrastructure.Data;
using CounterAppBack.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<EventService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();;

app.Use(async (context, next) =>
{
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
    await next();
});
app.UseDefaultFiles();  // active la recherche d'un fichier par défaut comme index.html
app.UseStaticFiles();   // sert les fichiers statiques (css, js, images)

app.UseRouting();

app.MapControllers();

app.MapFallbackToFile("index.html");
app.Run();
