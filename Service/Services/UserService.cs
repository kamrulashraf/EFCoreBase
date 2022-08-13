using Core.ILogger;
using Core.IRepository;
using Core.Model;
using Microsoft.Extensions.Logging;
using Repository.IRepository;
using Service.Interface;

namespace Service.Services
{
    public class UserService : IUsersService
    {
        private readonly IBaseRepository <Users> _generictRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogManager<UserService> _logger;

        public UserService(IBaseRepository<Users> generictRepository, IUserRepository userRepository, ILogManager<UserService> logger)
        {
            _generictRepository = generictRepository;
            _userRepository = userRepository;
            _logger = logger;
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
            var existedUser = _userRepository.Query(u => u.UserID == user.UserID).FirstOrDefault();
            if (existedUser == null) throw new AppException(System.Net.HttpStatusCode.NotFound, "This user does not exists.");
            _userRepository.Update(user);
        }
        
    }
}
