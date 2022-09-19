using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.IValidation
{
    public interface IGuardService
    {
        public void AgainstNull(object obj, HttpStatusCode code, string message);
        public void AgainstDataUpdateSuccess(int rowCount, HttpStatusCode code, string message);
    }
}
