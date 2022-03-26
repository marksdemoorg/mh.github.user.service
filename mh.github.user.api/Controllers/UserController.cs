using mh.github.user.entity;
using mh.github.user.interfaces.appservice;
using Microsoft.AspNetCore.Mvc;

namespace mh.github.user.api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<User>> GetAsync()
        {
            try
            {
                return await userService.GetUsersAsync();
            }
            catch(Exception ex)
            {
                LogHandler.Log(ex.ToString());
                return null;
            }
            
        }

        // GET api/values/{{Guid}}
        [HttpGet("{id}")]
        public async Task<User?> GetAsync(Guid id)
        {
            return await userService.GetUserAsync(id);
        }
    }
}

