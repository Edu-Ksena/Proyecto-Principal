var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<mi_proyecto.Services.DataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
// Ensure WebRootPath points to the project wwwroot folder.
// Walk up from the current ContentRootPath to find the nearest folder that contains a `wwwroot` directory
// This handles running from `bin/Debug/...` where ContentRootPath may be the build output folder.
string foundWwwroot = null;
{
    string contentRoot = app.Environment.ContentRootPath;
    var dir = new System.IO.DirectoryInfo(contentRoot);
    while (dir != null)
    {
        var candidate = System.IO.Path.Combine(dir.FullName, "wwwroot");
        if (System.IO.Directory.Exists(candidate))
        {
            foundWwwroot = candidate;
            break;
        }

        try
        {
            var csproj = System.IO.Directory.GetFiles(dir.FullName, "*.csproj", System.IO.SearchOption.TopDirectoryOnly);
            if (csproj.Length > 0)
            {
                var projWww = System.IO.Path.Combine(dir.FullName, "wwwroot");
                if (System.IO.Directory.Exists(projWww))
                {
                    foundWwwroot = projWww;
                    break;
                }
            }
        }
        catch
        {
            // ignore permission errors
        }

        dir = dir.Parent;
    }

    if (!string.IsNullOrEmpty(foundWwwroot))
    {
        app.Environment.WebRootPath = foundWwwroot;
    }
}

// Log the resolved WebRootPath to help debugging when static files are not found.
app.Logger.LogInformation("Resolved WebRootPath: {WebRoot}", app.Environment.WebRootPath ?? "(null)");

// Serve static files from the resolved webroot (explicit FileProvider ensures correct directory used)
if (!string.IsNullOrEmpty(app.Environment.WebRootPath) && System.IO.Directory.Exists(app.Environment.WebRootPath))
{
    app.UseStaticFiles(new Microsoft.AspNetCore.Builder.StaticFileOptions
    {
        FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(app.Environment.WebRootPath)
    });
}
else
{
    // Fallback: call default UseStaticFiles which will use built-in webroot if available
    app.UseStaticFiles();
}
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
