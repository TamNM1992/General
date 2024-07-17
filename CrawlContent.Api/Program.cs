

using General.Api.Configurations;
using General.Api.Providers;
using General.Common.Configuration;
using General.DataAccess.DBContext;
using General.DataAccess.Interface;
using General.DataAccess.Repositories;
using General.DataAccess.UnitOfWork;
using General.DataDto.Base;
using General.Services;
using General.Services.Permissions;
using Microsoft.EntityFrameworkCore;

using Q101.ServiceCollectionExtensions.ServiceCollectionExtensions;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();
AppConfigs.LoadAll(config);
builder.Services.AddHttpContextAccessor();
//--register CommonDBContext
builder.Services.AddDbContext<CommonDBContext>(options =>
            options.UseSqlServer(AppConfigs.SqlConnection, options => { }),
            ServiceLifetime.Scoped
            );
builder.Services.AddTransient(typeof(ICommonRepository<>), typeof(CommonRepository<>));
builder.Services.AddTransient(typeof(ICommonUoW), typeof(CommonUoW));
//builder.Services.AddScoped(typeof(IOrderFunction), typeof(OrderFunction));
//--register Service
builder.Services.RegisterAssemblyTypesByName(typeof(IPermissionService).Assembly,
     name => name.EndsWith("Service")) // Condition for name of type
.AsScoped()
.AsImplementedInterfaces()
     .Bind();
builder.Services.AddCommonServices();
builder.Services.Configure<AppSettings>(config.GetSection("AppSettings"));

// Add services to the container.
builder.Services.AddHttpClient<IMyTypedClientServices, MyTypedClientServices>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
var app = builder.Build();
StaticServiceProvider.Provider = app.Services;
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pk Api"));
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//UpdateTimer.Init();
app.Run();

