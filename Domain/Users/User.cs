using Microsoft.AspNetCore.Components.Forms;

namespace Domain.Users;

public class User
{
    private readonly List<Role> _roles = new();

    public User UserId { get; set; }
    public FirstName FirstName { get; set; }
    public LastName LastName { get; set; }
    public Email Email { get; set; }
    
    private User(
        guid id, FirstName firstName, LastName lastName, Email email) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    private User()
    {
        
    }
    
    public string IdentityId { get; private set; } = String.Empty;
    public IReadOnlyCollection<Role> Roles => _roles.ToList();

    public static User Create(FirstName firstName, LastName lastName, Email email)
    {
        var user = new User(Guid.NewGuid(),firstName, lastName, email);
        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.UserId));
        user._roles.Add(Role.Registered);
        return user;
    }

    public void SetIdentityId(string identityId)
    {
        IdentityId = identityId;
    }

}