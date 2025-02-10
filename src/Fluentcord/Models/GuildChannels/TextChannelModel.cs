using System.Linq;
using Avalonia.Media;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using Fluentcord.Models.Permissions;
using NetCord;

namespace Fluentcord.Models.GuildChannels;

public class TextChannelModel : ChannelModel
{
    public sealed override ulong Id { get; }
    public ulong GuildId { get; set; }
    public sealed override string? Name { get; set; }
    public int? Position { get; set; }
    public PermissionOverwriteModel[] PermissionOverwrites { get; set; }
    public int Slowmode { get; set; }
    public bool IsNsfw { get; set; }

    private string? _topic;

    public string? Topic
    {
        get => _topic;
        set => _topic = (value ?? string.Empty).ReplaceLineEndings(" ");
    }

    public ulong? LastMessageId { get; set; }
    public ulong? ParentId { get; set; }
    public bool IsUnread { get; set; }

    private bool _isHidden;
    public sealed override bool IsHidden
    {
        get => _isHidden;
        set { _isHidden = value; OnPropertyChanged(); }
    }

    public TextChannelModel(
        ulong id,
        ulong guildId,
        string name,
        int? position,
        PermissionOverwriteModel[] permissionOverwrites,
        int slowmode,
        bool isNsfw,
        string topic,
        ulong? lastMessageId,
        ulong? parentId,
        bool isUnread,
        bool isHidden
    )
    {
        Id = id;
        GuildId = guildId;
        Name = name.ToLower();
        Position = position;
        PermissionOverwrites = permissionOverwrites;
        Slowmode = slowmode;
        IsNsfw = isNsfw;
        Topic = topic;
        LastMessageId = lastMessageId;
        ParentId = parentId;
        IsUnread = isUnread;
        IsHidden = isHidden;
    }

    public TextChannelModel(TextGuildChannel channel)
    {
        Id = channel.Id;
        GuildId = channel.GuildId;
        Name = channel.Name.ToLower();
        Position = channel.Position;
        PermissionOverwrites = channel.PermissionOverwrites.Select(pair => new PermissionOverwriteModel(pair.Value))
            .ToArray();
        Slowmode = channel.Slowmode;
        IsNsfw = channel.Nsfw;
        Topic = channel.Topic;
        LastMessageId = channel.LastMessageId;
        ParentId = channel.ParentId;
        IsUnread = false;
        IsHidden = false;
    }
}