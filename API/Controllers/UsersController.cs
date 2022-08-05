using Core.Model;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _userService;
        // GET: api/<UsersController>
        public UsersController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //GET api/<UsersController>/"mdkamrul@gmail.com"
        [HttpGet("GetUserByEmail/{email}")]
        public Users GetUserByEmail(string email)
        {
            return _userService.GetUserInfoByEmail(email);
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post(Users user)
        {
            _userService.AddUser(user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
