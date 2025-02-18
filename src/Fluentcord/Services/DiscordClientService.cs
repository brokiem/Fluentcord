using System;
using System.Threading.Tasks;
using NetCord.Gateway;

namespace Fluentcord.Services;

public interface IDiscordClientService {
    void Initialize(GatewayClient client);
    Task StartAsync();
    GatewayClient GetClient();
}

public class DiscordClientService : IDiscordClientService, IDisposable {
    private GatewayClient? _client;

    public void Initialize(GatewayClient client) {
        _client = client;
    }

    public async Task StartAsync() {
        await _client!.StartAsync().ConfigureAwait(false);
        await Task.Delay(-1).ConfigureAwait(false);
    }

    public GatewayClient GetClient() {
        if (_client == null) {
            throw new NullReferenceException("Client is not initialized");
        }

        return _client;
    }

    public void Dispose() {
        _client?.Dispose();
    }
}