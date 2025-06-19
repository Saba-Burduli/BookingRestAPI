namespace Domain.Users;

public class Permission
{
    public int PermissionId { get; set; }
    public string PermissionName { get; init; }
    
    public static readonly Permission UsersRoad = new(1, "users:read");

    public Permission(int permissionId, string permissionName)
    {
        PermissionId = permissionId;
        PermissionName = permissionName;
    }
}