using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Fluentcord.Models;

public partial class GuildModel : ModelBase
{
    public ulong Id { get; }

    [ObservableProperty] private string _name;
    [ObservableProperty] private string _initials;
    [ObservableProperty] private string? _iconUrl;
    [ObservableProperty] private bool _isUnread;

    public GuildModel(ulong id, string name, string? iconUrl, bool isUnread)
    {
        Id = id;
        Name = name;
        Initials = Name.Split(' ').Select(x => x[0]).Aggregate("", (x, y) => x + y);
        IconUrl = iconUrl;
        IsUnread = isUnread;
    }
}