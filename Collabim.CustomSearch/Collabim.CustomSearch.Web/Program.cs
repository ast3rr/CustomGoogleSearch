using Collabim.CustomSearch.Business;
using Collabim.CustomSearch.Business.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddLogging(configure => { configure.ClearProviders(); configure.AddConsole(); });
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ISearchService, SearchService>(x =>
	new SearchService(builder.Configuration.GetValue<string>("ApiKey"), builder.Configuration.GetValue<string>("SearchEngineId")));
builder.Services.AddScoped<ICsvGeneratorHelper, CsvGeneratorHelper>();

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