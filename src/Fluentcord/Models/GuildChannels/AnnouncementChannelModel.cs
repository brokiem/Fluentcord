using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using Fluentcord.Models.Permissions;
using NetCord;

namespace Fluentcord.Models.GuildChannels;

public class AnnouncementChannelModel : ChannelModel {
    public sealed override ulong Id { get; }
    public ulong GuildId { get; set; }
    public sealed override string? Name { get; set; }
    public int? Position { get; set; }
    public PermissionOverwriteModel[] PermissionOverwrites { get; set; }
    public bool IsNsfw { get; set; }

    private string? _topic;

    public string? Topic {
        get => _topic;
        set => _topic = (value ?? string.Empty).ReplaceLineEndings(" ");
    }

    public ulong? LastMessageId { get; set; }
    public ulong? ParentId { get; set; }

    private bool _isHidden;

    public sealed override bool IsHidden {
        get => _isHidden;
        set {
            _isHidden = value;
            OnPropertyChanged();
        }
    }

    public AnnouncementChannelModel(ulong id,
        ulong guildId,
        string name,
        int? position,
        PermissionOverwriteModel[] permissionOverwrites,
        bool isNsfw,
        string topic,
        ulong? lastMessageId,
        ulong? parentId,
        bool isHidden
    ) {
        Id = id;
        GuildId = guildId;
        Name = name;
        Position = position;
        PermissionOverwrites = permissionOverwrites;
        IsNsfw = isNsfw;
        Topic = topic;
        LastMessageId = lastMessageId;
        ParentId = parentId;
        IsHidden = isHidden;
    }

    public AnnouncementChannelModel(AnnouncementGuildChannel channel) {
        Id = channel.Id;
        GuildId = channel.GuildId;
        Name = channel.Name;
        Position = channel.Position;
        PermissionOverwrites = channel.PermissionOverwrites.Select(pair => new PermissionOverwriteModel(pair.Value))
            .ToArray();
        IsNsfw = channel.Nsfw;
        Topic = channel.Topic;
        LastMessageId = channel.LastMessageId;
        ParentId = channel.ParentId;
        IsHidden = false;
    }
}