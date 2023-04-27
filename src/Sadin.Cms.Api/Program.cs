var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices();
builder.Services.AddPresentationServices();
builder.Services.AddDomainServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddSharedServices();

var app = builder.Build();

app.UseApi();
app.UsePresentation();
app.UseDomain();
app.UseApplication();
app.UseInfrastructure();
app.UseShared();

app.Run();
