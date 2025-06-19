namespace Domain.Users;

public class Role
{
    public int RoleId { get; set; }
    public string? RoleName { get; set; }
    
    //Relations:
    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    
    
    public static readonly Role Registered = new(1, "Registered");

    public Role(int id, string name)
    {
        RoleId = id;
        RoleName = name;
    }

}