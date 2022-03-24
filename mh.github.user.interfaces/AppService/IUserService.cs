using mh.github.user.entity;

namespace mh.github.user.interfaces.appservice
{
    public interface IUserService
    {
        Task<User?> GetUserAsync(Guid userId);
        Task<IEnumerable<User>> GetUsersAsync();
    }
}

