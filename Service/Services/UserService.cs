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
            throw new NotImplementedException();
        }

        public void GetUserInfo(long userID)
        {
            throw new NotImplementedException();
        }

        public Users GetUserInfoByEmail(string email)
        {
            return _userRepository.GetUserNameByEmail(email);
        }

        public void UpdateUser(Users user)
        {
            throw new NotImplementedException();
        }

        Users IUsersService.GetUserInfo(long userID)
        {
            throw new NotImplementedException();
        }
    }
}
