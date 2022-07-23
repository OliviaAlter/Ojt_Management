using System;
using System.Globalization;

namespace OJTManagementAPI.ServiceExtensions
{
    public class ExtraException : Exception
    {
        public ExtraException() : base()
        {
        }
        public ExtraException(string message) : base(message)
        {
        }
        public ExtraException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}