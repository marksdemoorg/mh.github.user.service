using System.DirectoryServices;
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
			//BAD
			var user = FindUser("*");
			var myVar = "aa";
			return await userRepository.GetUserAsync(userId);

        }

		private SearchResultCollection FindUser(string userName)
        {
			var filter = "(uid=" + userName + ")";

			// In this example, if we send the * character in the user parameter which will
			// result in the filter variable in the code to be initialized with (uid=*).
			// The resulting LDAP statement will make the server return any object that
			// contains a uid attribute.
			DirectorySearcher searcher = new DirectorySearcher(filter);
			SearchResultCollection results = searcher.FindAll();
			return results;
		}

	}
}

