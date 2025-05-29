using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGet("/time", () => 
{
    return new 
    {
        CurrentTime = DateTime.UtcNow,
        TimeZone = "UTC"
    };
});

app.Run();