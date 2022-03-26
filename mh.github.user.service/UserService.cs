using mh.github.user.entity;
using mh.github.user.interfaces.appservice;
using mh.github.user.interfaces.Data;

namespace mh.github.user.service
{
	public class UserService : IUserService
	{
		private readonly IUserRepository userRepository;

		public UserService(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}


		public async Task<IEnumerable<User>> GetUsersAsync()
        {
			return await userRepository.GetUsersAsync();
        }

		public async Task<User?> GetUserAsync(Guid userId)
        {
			return await userRepository.GetUserAsync(userId);
        }

	}
}

