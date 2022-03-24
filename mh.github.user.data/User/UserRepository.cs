using mh.github.user.entity;
using mh.github.user.interfaces.Data;

public class UserRepository : IUserRepository
{
    private readonly IEnumerable<User> userList;

    public UserRepository()
    {
        //This is just to simulate an data repository such as SQL or NoSQL
        this.userList = new List<User>
            {
                new User { Id = Guid.Parse("1b2041cf-2324-4102-bfe0-0b9dd439ce36"), FirstName = "Joe", LastName = "Test", EmailAddress = "jt@test.com"},
                new User { Id = Guid.Parse("d50ef5d5-cad1-4070-9416-899a2ea83465"), FirstName = "Ollie", LastName = "Test", EmailAddress = "ollie@test.com"},
                new User { Id = Guid.Parse("da118aa1-f9e9-44a1-902d-9c9ba6440ea3"), FirstName = "Sheena", LastName = "Test", EmailAddress = "s1@test.com"}
            };
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        //Task.FromResult simulates async DB call.
        return await Task.FromResult(userList);
    }

    public async Task<User?> GetUserAsync(Guid userId)
    {
        var user = userList.SingleOrDefault(u => u.Id == userId);
        return await Task.FromResult(user);
    }
}

