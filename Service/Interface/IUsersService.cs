using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUsersService
    {
        public List<Users> GetAllUsers();
        public Users GetUserInfo(long userID);
        public Users GetUserInfoByEmail(string email);
        public void UpdateUser(Users user);

        public void DeleteUser(long userID);
        public void AddUser(Users User);
    }
}
