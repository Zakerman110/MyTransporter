using Transport.BLL.Interfaces.Services;
using Transport.BLL.Services;
using Transport.DAL.Infrastructure;
using Transport.DAL.Interfaces;
using Transport.DAL.Interfaces.IRepositories;
using Transport.DAL.Repositories;
using Transport.DAL.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

#region SQL repositories
builder.Services.AddTransient<IModelRepository, ModelRepository>();
builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
#endregion

#region SQL services
builder.Services.AddTransient<IModelService, ModelService>();
builder.Services.AddTransient<IVehicleService, VehicleService>();
#endregion

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<IConnectionFactory, ConnectionFactory>();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
