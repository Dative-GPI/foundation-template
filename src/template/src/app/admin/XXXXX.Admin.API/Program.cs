using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Foundation.Template.Admin.DI;
using Foundation.Template.Admin.Extensions;

using XXXXX.Admin.Kernel.DI;
using XXXXX.Context.Kernel.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddKernel(builder.Configuration);
builder.Services.AddAdminTemplate(builder.Configuration);
builder.Services.AddContext(builder.Configuration);
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseAdminTemplate();

app.MapControllers();

app.Run();
