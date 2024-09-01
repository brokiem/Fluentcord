namespace Fluentcord.Models.GuildChannels;

public abstract class ChannelModel : ModelBase
{
    public abstract ulong Id { get; }
    public abstract string? Name { get; set; }
}