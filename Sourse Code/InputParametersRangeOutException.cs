using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_WPF.Sourse_Code
{
    [Serializable()]
    public class InputParametersRangeOutException: Exception
    {
        public InputParametersRangeOutException() : base() { }
        public InputParametersRangeOutException(string message) : base(message) { }
        public InputParametersRangeOutException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected InputParametersRangeOutException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
}
