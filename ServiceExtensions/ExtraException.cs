using System;
using System.Globalization;

namespace OJTManagementAPI.ServiceExtensions
{
    public class ExtraException : Exception
    {
        public ExtraException()
        {
        }

        public ExtraException(string message) : base(message)
        {
        }

        public ExtraException(string message, params object[] args) : base(string.Format(CultureInfo.CurrentCulture,
            message, args))
        {
        }
    }
}