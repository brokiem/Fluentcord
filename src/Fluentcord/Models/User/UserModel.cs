using Fluentcord.Helpers;
using NetCord;

namespace Fluentcord.Models.User;

public class UserModel : ModelBase
{
    public ulong Id { get; set; }
    public string Username { get; set; }
    public ushort Discriminator { get; set; }
    public string? GlobalName { get; set; }
    public string AvatarUrl { get; set; }
    public bool IsBot { get; set; }
    public bool? IsSystemUser { get; set; }
    public bool? MfaEnabled { get; set; }
    public string? BannerUrl { get; set; }
    public object? AccentColor { get; set; }
    public string? Locale { get; set; }
    public bool? Verified { get; set; }
    public string? Email { get; set; }
    public UserFlags? Flags { get; set; }
    public PremiumType? PremiumType { get; set; }
    public UserFlags? PublicFlags { get; set; }

    public UserModel(
        ulong id,
        string username,
        ushort discriminator,
        string avatarUrl,
        string? globalName = null,
        bool isBot = false,
        bool? isSystemUser = null,
        bool? mfaEnabled = null,
        string? bannerUrl = null,
        object? accentColor = null,
        string? locale = null,
        bool? verified = null,
        string? email = null,
        UserFlags? flags = null,
        PremiumType? premiumType = null,
        UserFlags? publicFlags = null)
    {
        Id = id;
        Username = username;
        Discriminator = discriminator;
        GlobalName = globalName;
        AvatarUrl = avatarUrl;
        IsBot = isBot;
        IsSystemUser = isSystemUser;
        MfaEnabled = mfaEnabled;
        BannerUrl = bannerUrl;
        AccentColor = accentColor;
        Locale = locale;
        Verified = verified;
        Email = email;
        Flags = flags;
        PremiumType = premiumType;
        PublicFlags = publicFlags;
    }

    public UserModel(NetCord.User user)
    {
        Id = user.Id;
        Username = user.Username;
        Discriminator = user.Discriminator;
        GlobalName = user.GlobalName;
        AvatarUrl = user.GetAvatarUrl(40);
        IsBot = user.IsBot;
        IsSystemUser = user.IsSystemUser;
        MfaEnabled = user.MfaEnabled;
        BannerUrl = user.GetBannerUrl(ImageFormat.WebP)!.ToString();
        AccentColor = Utils.Utils.NetCordColorToBrush(user.AccentColor);
        Locale = user.Locale;
        Verified = user.Verified;
        Email = user.Email;
        Flags = user.Flags;
        PremiumType = user.PremiumType;
        PublicFlags = user.PublicFlags;
    }
}
