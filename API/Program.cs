using API.Helper;
using AutoMapper;
using Core.ILogger;
using Core.IRepository;
using Core.IValidation;
using Infrastucture.Logger;
using Infrastucture.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

#region authenticaton authorization
builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:7004";

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

// adds an authorization policy to make sure the token is for scope 'api1'
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "eshopapi");
    });
});

builder.Services.AddCors(options =>
{
    // this defines a CORS policy called "default"
    options.AddPolicy("default", policy =>
    {
        policy.WithOrigins("https://localhost:7005")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
#endregion
// add dbcontext
builder.Services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// registar db context
builder.Services.AddTransient<IEntityContext, BaseDbContext>();

#region Infrastructure setup
builder.Services.AddTransient(typeof(ILogManager<>), typeof(LoggerManager<>));
builder.Services.AddTransient(typeof(IGuardService), typeof(GurdService));
#endregion

#region repository registar
builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductVariationRepository, ProductVariationRepository>();
//builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();
#endregion

#region service registar
builder.Services.AddTransient<IUsersService, UserService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IProductVariationService, ProductVariationService>();
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
//builder.Host.UseSerilog(logger);
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseSerilogRequestLogging();

app.UseCors("default");

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

//app.MapControllers();
app.MapControllers().RequireAuthorization("ApiScope");

app.Run();
