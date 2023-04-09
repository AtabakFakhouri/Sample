using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AFS.SAMPLE.WEBSERVICE.Middleware.ExceptionHandler
{
    public class DynamicException : Exception
    {
        public DynamicException() : base()
        {
        }

        public DynamicException(string message) : base(message)
        {
        }

        public DynamicException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
