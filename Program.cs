using BlazorServer_ControlDinero.Data;
using BlazorServer_ControlDinero.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("SQLServer")!;
string connectionStringPostgre = builder.Configuration.GetConnectionString("Postgres")!;

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IControlDineroService,ControlDineroService>();

builder.Services.AddDbContext<ApplicationDbContext>(op =>
{
    //op.UseNpgsql(connectionStringPostgre);
    op.UseSqlServer(connectionString);
});

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
