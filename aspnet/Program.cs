var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ITime, MyLocalTime>();
var app = builder.Build();

app.MapGet("/time", (ITime t) => "Zeit = "+t.time());
app.MapGet("/", () => Results.File(Path.Combine(Directory.GetCurrentDirectory(), "index.html"), "text/html"));
app.Run();

interface ITime
{
    String time();
}

class MyLocalTime : ITime
{
    public string time()
    {
        return DateTime.Now.ToString();
    }
}