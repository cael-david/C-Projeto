using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=materiais.db"));

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
