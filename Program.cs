var builder = WebApplication.CreateBuilder(args); //create app
builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(); //service registration

var app = builder.Build(); //building

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection(); // pipelines

// app.Use(async (context, next) =>
// {
//     Console.WriteLine("1. Request entering middleware");

//     await next();

//     Console.WriteLine("4. Response leaving middleware");
// });

// // Middleware A
// app.Use(async (context, next) =>
// {
//     Console.WriteLine("A - Before");

//     await next();

//     Console.WriteLine("A - After");
// });


// // Middleware B
// app.Use(async (context, next) =>
// {
//     Console.WriteLine("B - Before");

//     await next();

//     Console.WriteLine("B - After");
// });

// // Terminal Middleware C
// app.Run(async context =>
// {
//     Console.WriteLine("C - Terminal middleware executing");

//     context.Response.ContentType = "text/plain";

//     await context.Response.WriteAsync(
//         "Request handled by terminal middleware."
//     );
// });
// Middleware branch
// app.Map("/hotel-check", hotelBranch =>
// {
//     hotelBranch.Run(async context =>
//     {
//         Console.WriteLine("Hotel Check branch executing");

//         await context.Response.WriteAsync(
//             "Welcome to Hotel Check!"
//         );
//     });
// });

// #region minimal API
// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast");
// #endregion
app.MapControllers();
app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
