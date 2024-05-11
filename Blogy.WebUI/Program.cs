using Blogy.BusinessLayer.Abstaract;
using Blogy.BusinessLayer.Concrete;
using Blogy.BusinessLayer.Container;
using Blogy.BusinessLayer.ValidationRules.ArticleValidation;
using Blogy.DataAccessLayer.Abstaract;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.EntityFramework;
using Blogy.EntityLayer.Concrete;
using Blogy.WebUI.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<BlogyContext>()
    .AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddHttpClient();
builder.Services.AddDbContext<BlogyContext>();
builder.Services.ContainerDependencies();
builder.Services.AddControllersWithViews();

//Localization start
builder.Services.AddLocalization(opt =>
{
    opt.ResourcesPath = "Resources";
});
builder.Services.AddMvc()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization();
builder.Services.Configure<RequestLocalizationOptions>(opt =>
{
    var supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("en-US"),
        new CultureInfo("tr-TR"),
        new CultureInfo("fr-FR"),
        new CultureInfo("de-DE"),
        new CultureInfo("es-ES")
    };
    opt.DefaultRequestCulture = new RequestCulture("tr-TR");
    opt.SupportedCultures = supportedCultures;
    opt.SupportedUICultures = supportedCultures;

    opt.RequestCultureProviders = new List<IRequestCultureProvider>
    {
        new QueryStringRequestCultureProvider(),
        new CookieRequestCultureProvider(),
        new AcceptLanguageHeaderRequestCultureProvider()
    };

});
//Localization end

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddFluentValidationAutoValidation(config =>
{
    config.DisableDataAnnotationsValidation = false;
});

builder.Services.AddValidatorsFromAssemblyContaining<CreateArticleValidator>();

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/Login/Index/";
    opt.AccessDeniedPath = "/ErrorPage/Page403/";
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStatusCodePagesWithRedirects("/ErrorPage/Page404/");

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//Localization start
var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);

//Localization end

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Blog}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
