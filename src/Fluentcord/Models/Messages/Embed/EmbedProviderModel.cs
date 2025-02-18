using NetCord;

namespace Fluentcord.Models.Messages.Embed;

public class EmbedProviderModel : ModelBase {
    public string? Name { get; set; }
    public string? Url { get; set; }

    public EmbedProviderModel(string? name = null, string? url = null) {
        Name = name;
        Url = url;
    }

    public EmbedProviderModel(EmbedProvider embedProvider) {
        Name = embedProvider.Name;
        Url = embedProvider.Url;
    }
}