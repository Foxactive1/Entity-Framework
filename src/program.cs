using InnovaTasks.Api.Data;
using InnovaTasks.Api.Repositories;
using InnovaTasks.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Db: use SQLite by default for dev
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=innovatasks.db";
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));

// DI
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
