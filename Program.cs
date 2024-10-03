using Microsoft.EntityFrameworkCore;
using SimpleRestApiPostgres.Data;
using SimpleRestApiPostgres.Services.ToDoItems;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string? connectionString = Environment.GetEnvironmentVariable("SimpleRestApiPostgres-DbConnectionString");

builder.Services.AddDbContextPool<AppDbContext>(options =>
    options.UseNpgsql(connectionString ?? builder.Configuration.GetConnectionString("DefaultConnection")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IToDoItemsService, ToDoItemsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
