using System.Net.WebSockets;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseWebSockets();
app.Use(async (context, next) =>
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
        var state = webSocket.State;
        await Echo(webSocket);
    }
    else
    {
        await next(context);
    }
});

app.Run();

static async Task Echo(WebSocket webSocket) => await Task.Delay(5000);