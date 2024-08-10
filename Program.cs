using TankWiki.Models;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
//conect to db
//builder.Services.AddDbContext<MySqlDBContext>(options=>options.UseSqlServer( builder.Configuration.GetConnectionString("SqlConnect")));
builder.Services.AddDbContext<MySqlDBContext>(options => options
                                .UseSqlServer(builder.Configuration.GetConnectionString("AmazonDbConnectionString")));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000");
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();
app.Run();
