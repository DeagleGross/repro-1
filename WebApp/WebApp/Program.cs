using System.Net.WebSockets;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseWebSockets();
app.Use(async (context, next) =>
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        LogHeaders(context.Request);
        using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
        await Echo(webSocket);
    }
    else
    {
        await next(context);
    }
});

app.Run();

static void LogHeaders(HttpRequest request)
{
    using var sw = new StreamWriter("output.txt", append: true);
    sw.WriteLine($"Request at {DateTime.Now}: Upgrade:'{request.Headers["Upgrade"]}', Connection:'{request.Headers["Connection"]}'");
}

static async Task Echo(WebSocket webSocket) => await Task.Delay(5000);