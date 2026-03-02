using AstroHoraZ.SeoToolkit.DynamicSitemap.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers(); // ✅ ADD THIS
builder.Services.AddScoped<ISitemapService, SitemapService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();   // ✅ ADD THIS
app.MapRazorPages();

app.Run();