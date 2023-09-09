using BlazorApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//AddSingleton<>();
// We gonna create one instance for the entire life of the application and the same instance will be shared for all the users in every sessions and browsers it will be the same Use only for reading data from it not ideal typically
//builder.Services.AddSingleton<IDataAccess,DummyDataAccess>();

//AddScoped<>();
// it will create an instance of the object and give it to the user and it will give the same instance every time that they are asking(request to server) for it(like switching between pages and when they came back to the page which is using this instance will show the same value because session did not changed) unless they refresh the browser or open up a new session by opening a new instance of the browser or a different browser
//builder.Services.AddScoped<IDataAccess,DummyDataAccess>();

//AddTransient

//What AddTransient essentially is every time you call this it will give you a new instance even that you are in the same session or not every single time!!!

builder.Services.AddTransient<IDataAccess,DummyDataAccess>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
