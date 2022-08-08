using API.Helper;
using AutoMapper;
using Core.IRepository;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.IRepository;
using Repository.Repositories;
using Repository.UnitOfWork;
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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
