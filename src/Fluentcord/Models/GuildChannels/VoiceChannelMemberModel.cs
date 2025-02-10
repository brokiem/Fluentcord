using CommunityToolkit.Mvvm.ComponentModel;

namespace Fluentcord.Models.GuildChannels;

public partial class VoiceChannelMemberModel : ChannelModel
{
    public ulong ChannelId { get; }
    public override ulong Id { get; }
    public ulong ChannelParentId { get; set; }
    public sealed override string? Name { get; set; }
    public string AvatarUrl { get; set; }
   
    private bool _isHidden;
    public sealed override bool IsHidden
    {
        get => _isHidden;
        set { _isHidden = value; OnPropertyChanged(); }
    }
    
    [ObservableProperty] private bool _isSelfMuted;
    [ObservableProperty] private bool _isSelfDeafened;

    public VoiceChannelMemberModel(ulong channelId, ulong id, ulong channelParentId, string name, string avatarUrl, bool isSelfMuted, bool isSelfDeafened, bool isHidden)
    {
        ChannelId = channelId;
        Id = id;
        ChannelParentId = channelParentId;
        Name = name;
        AvatarUrl = avatarUrl;
        IsSelfMuted = isSelfMuted;
        IsSelfDeafened = isSelfDeafened;
        IsHidden = isHidden;
    }
}