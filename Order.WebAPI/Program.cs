using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Order.BLL.Interfaces.Services;
using Order.BLL.Services;
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
#endregion

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MyTransporter.WebAPI",
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
                                        "MyTransporter.WebAPI v1"));

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
