using Microsoft.EntityFrameworkCore;
using WebApi;
using WebApiArch;
using WebApiArchExample.Middleware;

#region servicios

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WebApiDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")))
    .AddAutoMapper(typeof(ApplicationServiceExtensions));

builder.Services.AddCors();

#endregion

#region http
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader()
);

app.UseMiddleware<WebApiMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion