using Hydro.Configuration;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the DI container.
builder.Services.AddRazorPages();

// Add Hydro to the DI container.
builder.Services.AddHydro();

WebApplication app = builder.Build();

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

// Make sure the web app uses Hydro. Needs to be after UseRouting and before UseStaticFiles to work correctly.
app.UseHydro(builder.Environment);

app.UseAuthorization();

app.MapRazorPages();

app.Run();