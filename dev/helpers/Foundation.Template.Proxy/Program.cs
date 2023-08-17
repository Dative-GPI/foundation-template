using System.Net.Http;
using System.Collections.Generic;

using Microsoft.AspNetCore.Builder;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpForwarder();
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

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapForwarder("/{**catch-all}", app.Configuration.GetConnectionString("Foundation"));
});

app.Run();