using EventBus.Messages.Common;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Order.BLL.Configurations;
using Order.BLL.EventBusConsumer;
using Order.BLL.Interfaces.Services;
using Order.BLL.Services;
using Order.BLL.Services.Grpc;
using Order.DAL;
using Order.DAL.Interfaces;
using Order.DAL.Interfaces.Repositories;
using Order.DAL.Repositories;
using Order.DAL.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MyTransporterOrderContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", config =>
    {
        config.Authority = "https://localhost:7225/";
        config.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
        //config.Audience = "OrderAPI";

        //config.RequireHttpsMetadata = false;
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ClientIdPolicy", policy => policy.RequireClaim("client_id", "angular"));
});

builder.Services.AddCors(confg =>
    confg.AddPolicy("AllowAll",
        p => p.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()));

// MassTransit-RabbitMQ Configuration
builder.Services.AddMassTransit(config => {
    config.AddConsumer<VehicleUpdateConsumer>();
    config.AddConsumer<VehicleAddConsumer>();
    config.UsingRabbitMq((ctx, cfg) => {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);

        cfg.ReceiveEndpoint(EventBusConstants.VehicleAddQueue, c =>
        {
            c.ConfigureConsumer<VehicleAddConsumer>(ctx);
        });
        cfg.ReceiveEndpoint(EventBusConstants.VehicleUpdateQueue, c =>
        {
            c.ConfigureConsumer<VehicleUpdateConsumer>(ctx);
        });
    });
});

#region SQL repositories
builder.Services.AddTransient<ICountryRepository, CountryRepository>();
builder.Services.AddTransient<IRegionRepository, RegionRepository>();
builder.Services.AddTransient<ICityRepository, CityRepository>();
builder.Services.AddTransient<IRouteRepository, RouteRepository>();
builder.Services.AddTransient<IJourneyRepository, JourneyRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
#endregion

#region SQL services
builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddTransient<IRegionService, RegionService>();
builder.Services.AddTransient<ICityService, CityService>();
builder.Services.AddTransient<IRouteService, RouteService>();
builder.Services.AddTransient<IJourneyService, JourneyService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IVehicleService, VehicleService>();
#endregion

builder.Services.AddScoped<IVehicleDataClient, VehicleDataClient>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton(MapperBuilder.Build());

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "MyTransporterOrderInstance";
});

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Order.WebAPI",
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
                                        "Order.WebAPI v1"));

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("AllowAll");

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

try
{
    //await PrebDb.PrepPopulationAsync(app);
}
catch (Exception ex)
{
    
}

app.Run();

public partial class Program { }
