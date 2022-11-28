using IdentityCoreProject.Authorization;
using IdentityCoreProject.utilities;
using Microsoft.AspNetCore.Authorization;
using static IdentityCoreProject.Authorization.HRManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddHttpClient("WebAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7154/");
});

UserAuthentication userAuthentication = new UserAuthentication(builder);
userAuthentication.AddAuthentication();
userAuthentication.AddPolicy();

builder.Services.AddSingleton<IAuthorizationHandler, HRManagerHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
