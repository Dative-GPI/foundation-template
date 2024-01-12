using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Foundation.Template.Gateway.DI;
using Foundation.Template.CrossCutting.DI;
using Foundation.Template.Gateway.Extensions;

using XXXXX.Gateway.Kernel.DI;
using XXXXX.Context.Kernel.DI;

using Foundation.Template.Gateway.Middlewares;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddKernel(builder.Configuration);
builder.Services.AddGatewayTemplate(builder.Configuration);
builder.Services.AddContext(builder.Configuration);
builder.Services.AddCrossCutting(builder.Configuration);
builder.Services.AddHttpClient();

builder.Services.AddAuthentication("Custom"); // to remove
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseDeveloperExceptionPage();
}

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedProto
});

app.UseHealthChecks("/health");

app.UseRouting();

app.UseTemplateAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGatewayTemplateEndpoints();

    endpoints.MapForwarder("/api/admin/{**catch-all}", builder.Configuration.GetConnectionString("Admin"))
        .RequireAuthorization();

    endpoints.MapForwarder("/api/core/{**catch-all}", builder.Configuration.GetConnectionString("Core"))
        .RequireAuthorization();
});

app.Run();
