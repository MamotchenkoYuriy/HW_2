using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_WPF.Sourse_Code
{
    [Serializable()]
    public class OperationNotFoundException : Exception
    {
        public OperationNotFoundException() : base() { }
        public OperationNotFoundException(string message) : base(message) { }
        public OperationNotFoundException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected OperationNotFoundException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
}
