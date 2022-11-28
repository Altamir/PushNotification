global using FastEndpoints;
using FastEndpoints.Swagger;
using PushNotification.API.Configuration;
using PushNotification.Domain;


var builder = WebApplication.CreateBuilder();

builder.Services.AddSingleton<IPushNotificationService, PushNotificationService>();

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDocWithConfig();

var app = builder.Build();
app.UseDefaultExceptionHandler();
app.UseAuthorization();
app.UseFastEndpoints(c => { c.Versioning.Prefix = "v"; });
app.UseSwaggerGen();
app.AddClientGenerator();
app.Run();