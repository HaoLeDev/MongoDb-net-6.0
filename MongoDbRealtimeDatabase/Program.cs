using Application.Data.Repositories;
using Application.Service.Services;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MongoDbRealtimeDatabase.Api.Infrastructure.Extentsions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var host = new HostBuilder()
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        // builder.RegisterModule(new ContainerModule());
        builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();
        builder.RegisterAssemblyTypes(typeof(ITestRepository).Assembly)
           .Where(t => t.Name.EndsWith("Repository"))
            .As(x => x.GetInterfaces().FirstOrDefault(t => t.Name.EndsWith("Repository")));
        builder.RegisterAssemblyTypes(typeof(ITestService).Assembly)
           .Where(t => t.Name.EndsWith("Service"))
           .As(x => x.GetInterfaces().FirstOrDefault(t => t.Name.EndsWith("Service")));
    })
    .ConfigureServices(services =>
    {
    })
    .Build();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();