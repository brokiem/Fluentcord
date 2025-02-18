using NetCord;

namespace Fluentcord.Models.Permissions;

public class PermissionOverwriteModel : ModelBase {
    public ulong Id { get; }
    public PermissionOverwriteType Type { get; set; }
    public NetCord.Permissions Allowed { get; set; }
    public NetCord.Permissions Denied { get; set; }

    public PermissionOverwriteModel(ulong id,
        PermissionOverwriteType type,
        NetCord.Permissions allowed,
        NetCord.Permissions denied
    ) {
        Id = id;
        Type = type;
        Allowed = allowed;
        Denied = denied;
    }

    public PermissionOverwriteModel(PermissionOverwrite permissionOverwrite) {
        Id = permissionOverwrite.Id;
        Type = permissionOverwrite.Type;
        Allowed = permissionOverwrite.Allowed;
        Denied = permissionOverwrite.Denied;
    }
}