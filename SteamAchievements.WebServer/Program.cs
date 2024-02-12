using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore;
using System.IO;
using System.Reflection;


namespace WebServer;

public class Program
{

    public static void Main(string[] args) => StartWebServer(args);

    public static void StartWebServer(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var app = builder.Build();

        app.UseStaticFiles();

        // Render index.html
        app.MapGet("/", async context =>
        {
            await context.Response.SendFileAsync(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html"));
        });

        app.Run();
    }
}