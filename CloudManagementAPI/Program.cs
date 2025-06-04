using CloudManagementAPI.Data;
using CloudManagementAPI.Interfaces;
using CloudManagementAPI.Repositories;
using CloudManagementAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICloudResourceRepository, CloudResourceRepository>();
builder.Services.AddScoped<ICloudResourceService, CloudResourceService>();
builder.Services.AddScoped<IVirtualMachineService, VirtualMachineService>();
builder.Services.AddScoped<IVirtualMachineRepository, VirtualMachineRepository>();
builder.Services.AddScoped<IStorageBucketService, StorageBucketService>();
builder.Services.AddScoped<IStorageBucketRepository, StorageBucketRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CloudManagementAPI v1");
        c.RoutePrefix = string.Empty; 
    });
}

app.UseRouting();

app.MapControllers();

app.Run();
