using System.Linq;
using Avalonia.Media;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using Fluentcord.Models.Permissions;
using NetCord;

namespace Fluentcord.Models.GuildChannels;

public class CategoryChannelModel : ChannelModel
{
    public sealed override ulong Id { get; }
    public sealed override string? Name { get; set; }
    public PermissionOverwriteModel[] PermissionOverwrites { get; set; }
    public int? Position { get; set; }
    public ulong GuildId { get; set; }
    
    private bool _isHidden;
    public sealed override bool IsHidden
    {
        get => _isHidden;
        set { _isHidden = value; OnPropertyChanged(); }
    }

    public CategoryChannelModel(
        ulong id,
        string name,
        PermissionOverwriteModel[] permissionOverwrites,
        int position,
        ulong guildId,
        bool isHidden
    )
    {
        Id = id;
        Name = name.ToUpper();
        PermissionOverwrites = permissionOverwrites;
        Position = position;
        GuildId = guildId;
        IsHidden = isHidden;
    }

    public CategoryChannelModel(CategoryGuildChannel channel)
    {
        Id = channel.Id;
        GuildId = channel.GuildId;
        Name = channel.Name.ToUpper();
        Position = channel.Position;
        PermissionOverwrites = channel.PermissionOverwrites.Select(pair => new PermissionOverwriteModel(pair.Value))
            .ToArray();
        IsHidden = false;
    }
}