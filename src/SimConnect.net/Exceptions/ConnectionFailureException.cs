using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SimConnectNet.Exceptions
{
    public class ConnectionFailureException : Exception
    {
        public ConnectionFailureException()
        {
        }

        protected ConnectionFailureException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ConnectionFailureException(string message) : base(message)
        {
        }

        public ConnectionFailureException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
