using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IUserRepository : IRepository<Users>
    {
        public Users GetUserNameByEmail(string email);
    }
}
