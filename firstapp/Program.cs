using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using Microsoft.OData.Edm;
using MyFirstApp.MiddleWare;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddTransient<CustomMiddleWare>();

builder.Services.AddControllersWithViews();
builder.Services.AddControllers().AddXmlSerializerFormatters();
var app = builder.Build();//will get instance of web application


app.UseStaticFiles();
//app.UseRouting();

app.MapControllers();




//app.UseEndpoints(endpoints =>
//{
//    endpoints.Map("/", async context =>
//    {
//        await context.Response.WriteAsync("Hello");
//        Microsoft.AspNetCore.Http.Endpoint endpoint = context.GetEndpoint()!;
//    });
//});

//app.UseEndpoints(endpoints => {
//    endpoints.Map("files/{filename}.{extension?}",async context =>
//        {
//            string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
//            string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

//            await context.Response.WriteAsync($"Filename: {filename}, Extension : {extension}");

//        });
//    endpoints.Map("Home/Profile/{Username}", async context =>
//    {
//        String? username = Convert.ToString(context.Request.RouteValues["Username"]);
//        await context.Response.WriteAsync($"{username}");
//    });

//    endpoints.Map("Udemy/Courses/{courseid:guid}", async context =>
//    {
//        Guid id = Guid.Parse(Convert.ToString(context.Request.RouteValues["courseid"])!);
//        await context.Response.WriteAsync($"Guid :{id}");
//    });
//});

//app.Use(async (HttpContext context, RequestDelegate next) =>
//{
//    await context.Response.WriteAsync("Hello Yuvaraj\n");
//    await next(context);
//    await context.Response.WriteAsync("Hello Karpagam\n");
//});

//app.UseMiddleware<CustomMiddleWare>();

//app.UseWhen(context =>  context.Request.Query.ContainsKey("firstname"),
//    app =>
//    {
//        app.Use(async (context, next) =>
//        {
//            string a = context.Request.Query["firstname"];
//            await context.Response.WriteAsync($"this my firstname:{a}\n");
//            await next();
//        });
//    });
//app.Run(async(context) =>
//{
//    await context.Response.WriteAsync("Hello Family\n");
//});


app.Run();
