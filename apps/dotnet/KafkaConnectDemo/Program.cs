using System.Net.Http.Json;

var connectUrl = Environment.GetEnvironmentVariable("CONNECT_URL") ?? "http://localhost:8083";
using var http = new HttpClient { BaseAddress = new Uri(connectUrl) };
var command = args.FirstOrDefault() ?? "list";

if (command == "create")
{
    var payload = new { name = "file-source-orders", config = new Dictionary<string, string> {
        ["connector.class"] = "FileStreamSource", ["tasks.max"] = "1", ["topic"] = "connect-orders", ["file"] = "/data/input/orders.txt" } };
    var response = await http.PostAsJsonAsync("/connectors", payload);
    Console.WriteLine(await response.Content.ReadAsStringAsync());
}
else if (command == "delete")
{
    var response = await http.DeleteAsync("/connectors/file-source-orders");
    Console.WriteLine($"Delete status: {response.StatusCode}");
}
else
{
    Console.WriteLine(await http.GetStringAsync("/connectors"));
    Console.WriteLine("Use: dotnet run -- create | list | delete");
}
