using API.DTO.Users;
using AutoMapper;
using Core.ILogger;
using Core.Model;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Service.Interface;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _userService;
        private readonly IMapper _mapper;
        private readonly ILogManager<UsersController> _logger;
        // GET: api/<UsersController>
        public UsersController(IUsersService userService, IMapper mapper, ILogManager<UsersController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public List<UsersDTO> Get()
        {
            return _mapper.Map < List<Users>, List<UsersDTO>>(_userService.GetAllUsers());
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public UsersDTO Get(int id)
        {
            var users = _userService.GetUserInfo(id);
            return _mapper.Map<Users, UsersDTO>(users);
        }

        //GET api/<UsersController>/"mdkamrul@gmail.com"
        [HttpGet("GetUserByEmail/{email}")]
        public UsersDTO GetUserByEmail(string email)
        {
            return _mapper.Map<Users, UsersDTO>(_userService.GetUserInfoByEmail(email));
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post(UsersDTO user)
        {
            var userPram = _mapper.Map<UsersDTO, Users>(user);
            _userService.AddUser(userPram);
        }
        
        // POST api/<UsersController>
        [HttpPut]
        public void Update(UsersDTO user)
        {
            var userPram = _mapper.Map<UsersDTO, Users>(user);
            _userService.UpdateUser(userPram);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userService.DeleteUser(id);
        }

        [HttpGet("Test/{email}")]
        public string test([Required][EmailAddress] string email)
        {
            return "testData";
        }
    }
}
