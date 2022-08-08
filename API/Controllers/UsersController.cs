using API.DTO;
using API.Helper;
using AutoMapper;
using Core.Model;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _userService;
        private readonly IMapper _mapper;
        // GET: api/<UsersController>
        public UsersController(IUsersService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
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
    }
}
