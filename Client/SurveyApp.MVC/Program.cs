using Microsoft.AspNetCore.Authentication.Cookies;
using SurveyApp.MVC.Middlewares;
using SurveyApp.MVC.Extensions;
using SurveyApp.MVC.Caching;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/auth/login";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        option.AccessDeniedPath = "/auth/accessdenied";
    });

builder.Services.AddRefitClients(builder.Configuration);

builder.Services.AddMemoryCache();

builder.Services.AddSingleton<ICache, InMemoryCache>();

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

app.UseMiddleware<NotFoundMiddleware>();
app.UseMiddleware<ExceptionHandleMiddleware>();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
