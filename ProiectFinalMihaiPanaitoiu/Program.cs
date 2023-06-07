using Data.Models;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using Data.Services;
using ProiectFinalMihaiPanaitoiu.Filters;

var builder = WebApplication.CreateBuilder(args);
var dbConString = builder.Configuration.GetConnectionString("SqlDbConnString");

// Add services to the container.
builder.Services.AddDbContext<SchoolDbContext>(options => options.UseSqlServer(dbConString));

builder.Services.AddScoped<IDataAccessLayerService, DataAccessLayerService>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<InvalidIdExceptionFilter>();
    options.Filters.Add<DuplicatedIdExceptionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o => AddSwaggerDocumentation(o));

static void AddSwaggerDocumentation(SwaggerGenOptions o)
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
}

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
