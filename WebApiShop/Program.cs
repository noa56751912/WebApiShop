using Repository;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IRepositoryUser, RepositoryUser>();

builder.Services.AddScoped<IServiceUser, ServiceUser>();

builder.Services.AddScoped<IServicePassword, ServicePassword>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
