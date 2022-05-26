using MassTransit;
using Microsoft.OpenApi.Models;
using Transport.BLL.Interfaces.Services;
using Transport.BLL.Services;
using Transport.BLL.Services.Grpc;
using Transport.DAL.Infrastructure;
using Transport.DAL.Interfaces;
using Transport.DAL.Interfaces.IRepositories;
using Transport.DAL.Repositories;
using Transport.DAL.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// MassTransit-RabbitMQ Configuration
builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
    });
});

builder.Services.AddGrpc();

builder.Services.AddControllers();

#region SQL repositories
builder.Services.AddTransient<IMakeRepository, MakeRepository>();
builder.Services.AddTransient<IModelRepository, ModelRepository>();
builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
#endregion

#region SQL services
//builder.Services.AddTransient<IMakeService, MakeService>();
builder.Services.AddTransient<IModelService, ModelService>();
builder.Services.AddTransient<IVehicleService, VehicleService>();
#endregion

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<IConnectionFactory, ConnectionFactory>();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Transport.WebAPI",
        Version = "v1"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
                                        "Transport.WebAPI v1"));

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<GrpcVehicleService>();
    endpoints.MapControllers();
});

app.MapGet("/protos/vehicle.proto", async context =>
{
    await context.Response.WriteAsync(File.ReadAllText("Protos/vehicle.proto"));
});

app.Run();
