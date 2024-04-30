using BooksApi.Data;
using BooksApi.Repository;
using Microsoft.EntityFrameworkCore;
using Steeltoe.Connector.MySql.EFCore;
using Steeltoe.Extensions.Configuration.CloudFoundry;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.AddCloudFoundryConfiguration();

builder.Services.AddTransient<IBookRepository, BookRepository>();
// builder.Services.AddDbContext<BookDbContext>(options => options.UseInMemoryDatabase("BooksDb"));
builder.Services.AddDbContext<BookDbContext>(options => options.UseMySql(builder.Configuration));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:5124").AllowAnyHeader().AllowAnyMethod();
            policy.WithOrigins("https://books.apps.h2o-2-24070.h2o.vmware.com").AllowAnyHeader().AllowAnyMethod();
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

app.MapControllers()
.WithOpenApi();

app.UseCors();

app.Run();
