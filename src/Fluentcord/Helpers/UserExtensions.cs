using NetCord;

namespace Fluentcord.Helpers;

public static class UserExtensions {
    public static string GetAvatarUrl(this User user, int size) =>
        user.HasAvatar
            ? user.GetAvatarUrl(ImageFormat.WebP)!.ToString(size)
            : user.DefaultAvatarUrl.ToString(size);

    public static string GetAvatarUrl(this GuildUser user, int size) =>
        user.HasAvatar
            ? user.GetAvatarUrl(ImageFormat.WebP)!.ToString(size)
            : user.DefaultAvatarUrl.ToString(size);
}