using Sadin.Cms.Persistence;

var builder = WebApplication.CreateBuilder(args);

IConfiguration Configuration;

Configuration = builder.Environment.IsProduction()
    ? new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()
    : new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();

builder.Services.AddApiServices();
builder.Services.AddPresentationServices();
builder.Services.AddDomainServices();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(Configuration);
builder.Services.AddInfrastructureServices();
builder.Services.AddSharedServices();

var app = builder.Build();

app.UseApi();
app.UsePresentation();
app.UseDomain();
app.UseApplication();
app.UsePersistence();
app.UseInfrastructure();
app.UseShared();

app.Run();
