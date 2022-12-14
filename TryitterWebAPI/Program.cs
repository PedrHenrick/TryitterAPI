using Microsoft.EntityFrameworkCore;
using TryitterWebAPI.Repository;
using TryitterWebAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TryitterContext>(optionsAction: options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<StudentRepository>();
builder.Services.AddScoped<PostRepository>();

builder.Services.AddScoped<ITryitterContext, TryitterContext>();
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
