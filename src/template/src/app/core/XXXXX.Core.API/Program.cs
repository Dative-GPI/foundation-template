using System.Net;
using System.Net.Http;
using System.Diagnostics;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Foundation.Template.Core.DI;
using Foundation.Template.CrossCutting.DI;

using Foundation.Template.Core.Extensions;

using XXXXX.Core.Kernel.DI;
using XXXXX.Context.Kernel.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddKernel(builder.Configuration);
builder.Services.AddCoreTemplate(builder.Configuration);
builder.Services.AddContext(builder.Configuration);
builder.Services.AddCrossCutting(builder.Configuration);


builder.Services.AddHttpClient(string.Empty, c => { }).ConfigurePrimaryHttpMessageHandler(() =>
    new HttpClientHandler
    {
        ClientCertificateOptions = ClientCertificateOption.Manual,
        ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, certChain, policyErrors) => true
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCoreTemplate();

app.MapControllers();
app.MapCoreTemplateControllers();

app.Run();
