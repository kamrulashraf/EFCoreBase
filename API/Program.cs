using API.Helper;
using AutoMapper;
using Core.ILogger;
using Core.IRepository;
using Infrastucture.Logger;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.IRepository;
using Repository.Repositories;
using Repository.UnitOfWork;
using Serilog;
using Service.Interface;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add dbcontext
builder.Services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// registar db context
builder.Services.AddTransient<IEntityContext, BaseDbContext>();

#region Infrastructure setup
builder.Services.AddTransient(typeof(ILogManager<>), typeof(LoggerManager<>));
#endregion

#region repository registar
builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IUserRepository, UserRepository>();
//builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();
#endregion

#region service registar
builder.Services.AddTransient<IUsersService, UserService>();
#endregion


#region automapper setup

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperProfile());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

#endregion

#region serilog setting

var serilogConfiguration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
        .Build();

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(serilogConfiguration)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
