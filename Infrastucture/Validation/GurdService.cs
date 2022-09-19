using Core.AppExceptions;
using Core.IValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Validation
{
    public class GurdService : IGuardService
    {
        public void AgainstNull(object obj, HttpStatusCode code, string message)
        {
            if(obj == null)
            {
                throw new AppException(code, message);
            }
        }


        public void AgainstDataUpdateSuccess(int rowCount, HttpStatusCode code, string message)
        {
            if(rowCount <= 0)
            {
                throw new AppException(code, message);
            }
        }
    }
}
