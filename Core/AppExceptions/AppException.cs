using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.AppExceptions
{
    public class AppException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public AppException() : base()
        {

        }

        public AppException(string message) : base(message)
        {

        }

        public AppException(string message, params object[] args)
        : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }

        public AppException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
        public AppException(HttpStatusCode statusCode, string message, Exception innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }
}
