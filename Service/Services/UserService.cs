using Core.IRepository;
using Core.Model;
using Repository.IRepository;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUsersService
    {
        private readonly IBaseRepository <Users> _generictRepository;
        private readonly IUserRepository _userRepository;

        public UserService(IBaseRepository<Users> generictRepository, IUserRepository userRepository)
        {
            _generictRepository = generictRepository;
            _userRepository = userRepository;
        }


        public void AddUser(Users user)
        {
            _userRepository.Insert(user);
        }

        public void DeleteUser(long userID)
        {
            _userRepository.Delete(userID);
        }

        public List<Users> GetAllUsers()
        {
            return _userRepository.GetAllAsync().Result.ToList();
        }

        public Users GetUserInfo(long userID)
        {
            return _userRepository.GetByIdAsync(userID).Result;
        }

        public Users GetUserInfoByEmail(string email)
        {
            return _userRepository.GetUserNameByEmail(email);
        }

        public void UpdateUser(Users user)
        {
            _userRepository.Update(user);
        }
        
    }
}
