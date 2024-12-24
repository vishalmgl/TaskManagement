using System;
using System.Globalization;

namespace TaskManagement.Application.Exceptions
{
    public class APIException : Exception
    {
        public APIException() : base()
        { }

        public APIException(string message) : base(message)
        { }

        public APIException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        { }
    }
}
