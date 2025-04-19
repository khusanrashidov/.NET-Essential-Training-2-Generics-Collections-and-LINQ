using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Essentials2.Library
{
    [Serializable]
    public class InvalidOptionException : Exception
    {
        // `: base(message)` - This part calls the base class constructor of Exception
        // and passes the message parameter to it. + The base keyword is used to access
        // members of the base class from within a derived class.

        // The Exception(string) constructor overload simply stores the passed
        // parameter into a field exposed by the Exception.Message property.
        // Message property is used inside the Exception.ToString() method
        // when creating a string representation of the exception.
        public InvalidOptionException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public InvalidOptionException(string message) : base(message)
        { }
        public InvalidOptionException() : base() { }

        protected InvalidOptionException(SerializationInfo info, StreamingContext ctx) : base(info, ctx)
        {

        }
    }
}