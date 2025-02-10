using System.Linq;
using Avalonia.Media;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using Fluentcord.Models.Permissions;
using NetCord;

namespace Fluentcord.Models.GuildChannels;

public class VoiceChannelModel : ChannelModel
{
    public sealed override ulong Id { get; }
    public ulong? LastMessageId { get; set; }
    public sealed override string? Name { get; set; }
    public int? Position { get; set; }
    public ulong? ParentId { get; set; }
    public int? Bitrate { get; set; }
    public int? UserLimit { get; set; }
    public string? RtcRegion { get; set; }
    public ulong GuildId { get; set; }
    public PermissionOverwriteModel[] PermissionOverwrites { get; set; } = [];
    public int Slowmode { get; set; }
    public bool IsNsfw { get; set; }
    
    private bool _isHidden;
    public sealed override bool IsHidden
    {
        get => _isHidden;
        set { _isHidden = value; OnPropertyChanged(); }
    }

    public VoiceChannelModel(
        ulong id,
        ulong? lastMessageId,
        string name,
        int position,
        ulong parentId,
        int? bitrate,
        int? userLimit,
        string? rtcRegion,
        ulong guildId,
        PermissionOverwriteModel[] permissionOverwrites,
        int slowmode,
        bool isNsfw,
        bool isHidden
    )
    {
        Id = id;
        LastMessageId = lastMessageId;
        Name = name;
        Position = position;
        ParentId = parentId;
        Bitrate = bitrate;
        UserLimit = userLimit;
        RtcRegion = rtcRegion;
        GuildId = guildId;
        PermissionOverwrites = permissionOverwrites;
        Slowmode = slowmode;
        IsNsfw = isNsfw;
        IsHidden = isHidden;
    }

    public VoiceChannelModel(VoiceGuildChannel channel)
    {
        Id = channel.Id;
        LastMessageId = channel.LastMessageId;
        Name = channel.Name;
        Position = channel.Position;
        ParentId = channel.ParentId;
        Bitrate = channel.Bitrate;
        UserLimit = channel.UserLimit;
        RtcRegion = channel.RtcRegion;
        GuildId = channel.GuildId;
        PermissionOverwrites = channel.PermissionOverwrites.Select(pair => new PermissionOverwriteModel(pair.Value))
            .ToArray();
        Slowmode = channel.Slowmode;
        IsNsfw = channel.Nsfw;
        IsHidden = false;
    }
}