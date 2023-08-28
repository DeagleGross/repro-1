using System.Net.WebSockets;

var clientWebSocket = new ClientWebSocket();
clientWebSocket.Options.SetRequestHeader("Upgrade", "websocket"); // will make server handler get `Upgrade: websocket, websocket`

// IN CASE OF KESTREL
// await clientWebSocket.ConnectAsync(new Uri("ws://localhost:5292"), CancellationToken.None);

// IN CASE OF IIS
await clientWebSocket.ConnectAsync(new Uri("ws://localhost:27836"), CancellationToken.None);

Console.WriteLine(clientWebSocket.State);