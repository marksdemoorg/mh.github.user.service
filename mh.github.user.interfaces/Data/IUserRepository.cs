using mh.github.user.entity;

namespace mh.github.user.interfaces.Data
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(Guid userId);
        Task<IEnumerable<User>> GetUsersAsync();
    }
}

