namespace Domain.Users;

public interface IUserRepository
{
    //check what is CancellationToken
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(User user);
}