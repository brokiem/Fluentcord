using CommunityToolkit.Mvvm.ComponentModel;

namespace Fluentcord.Models.GuildChannels;

public partial class VoiceChannelMemberModel : ChannelModel
{
    public ulong ChannelId { get; }
    public override ulong Id { get; }
    public sealed override string? Name { get; set; }
    public string AvatarUrl { get; set; }
    
    [ObservableProperty] private bool _isSelfMuted;
    [ObservableProperty] private bool _isSelfDeafened;

    public VoiceChannelMemberModel(ulong channelId, ulong id, string name, string avatarUrl, bool isSelfMuted, bool isSelfDeafened)
    {
        ChannelId = channelId;
        Id = id;
        Name = name;
        AvatarUrl = avatarUrl;
        IsSelfMuted = isSelfMuted;
        IsSelfDeafened = isSelfDeafened;
    }
}