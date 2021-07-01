using System;
using System.Collections.Generic;
using System.Text;

namespace Ciber.Utilities.Exceptions
{
    public class CiberManagerException : Exception
    {
        public CiberManagerException()
        {

        }
        public CiberManagerException(string message):base(message)
        {

        }
        public CiberManagerException(string message, Exception inner):base(message, inner)
        {

        }
    }
}
