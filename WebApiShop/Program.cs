using Microsoft.EntityFrameworkCore;
using Repository;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IRepositoryUser, RepositoryUser>();

builder.Services.AddScoped<IServiceUser, ServiceUser>();

builder.Services.AddScoped<IServicePassword, ServicePassword>();
builder.Services.AddDbContext<ApiShopContext>(option=>option.UseSqlServer("Data Source=Noa;Initial Catalog=ApiShop;Integrated Security=True;Trust Server Certificate=True"));

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "My API V1");
});
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
