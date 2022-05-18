
using AutoMapper;
using Domain.Validation;
using Domain.Validation.People;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.EFModel;
using Infrastructure.Features.People;
using Infrastructure.Features.AdListing;
using MediatR;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using PetCareAppMVC;
using Sieve.Models;
using Sieve.Services;
using DomainServices.Validation.People;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllersWithViews().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddPersonCommandValidator>());

builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.ViewLocationExpanders.Add(new FeatureLocationExpander());
});

#region Setup dependencies
builder.Services.AddDbContext<ProjectContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Project")));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddMediatR(typeof(PeopleQueryHandler));
builder.Services.AddMediatR(typeof(AdlistingQueryHandler));

builder.Services.Configure<SieveOptions>(builder.Configuration.GetSection("Sieve"));
builder.Services.AddScoped<ISieveCustomFilterMethods, SieveCustomFilterMethods>();
builder.Services.AddScoped<ISieveProcessor, ApplicationSieveProcessor>();
#endregion

#region AutoMapper settings
Action<IServiceProvider, IMapperConfigurationExpression> mapperConfigAction = (serviceProvider, cfg) =>
{
    cfg.ConstructServicesUsing(serviceProvider.GetService);
};
builder.Services.AddAutoMapper(mapperConfigAction, typeof(PetCareAppMVC.MappingProfile), typeof(Infrastructure.MappingProfile)); //assemblies containing mapping profiles            
#endregion











// Add services to the container.
//builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();
