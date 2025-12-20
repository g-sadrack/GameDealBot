using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;

public class Program
{

    private static DiscordSocketClient? _client;

    public static async Task Main()
    {
        _client = new DiscordSocketClient();

        var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        var token = config["Discord:Token"];

        _client.Log += Log;
        _client.Ready += Ready;

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        await Task.Delay(Timeout.Infinite);
    }

    private static Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }
    private static Task Ready()
    {
        Console.WriteLine($"Bot online como {_client?.CurrentUser.Username}!");
        return Task.CompletedTask;
    }
}