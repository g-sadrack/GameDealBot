using Discord;
using Discord.WebSocket;

public class Program
{

    private static DiscordSocketClient? _client;

    public static async Task Main()
    {
        _client = new DiscordSocketClient();

        var token = "SEU_TOKEN_AQUI";

        _client.Log += Log;

        await _client.LoginAsync(TokenType.Bot, token);

        await _client.StartAsync();

        await Task.Delay(Timeout.Infinite);
    }

    private static Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }
}