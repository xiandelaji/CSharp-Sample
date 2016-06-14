﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BitCoinApp.com.max.api.btcc
{
    [Serializable()]
    public class BTCChinaException : Exception
    {
        private string method;
        private string jsonID;

        public BTCChinaException() : base() { }
        public BTCChinaException(string callerMethod, string callerID, string message, Exception innerException)
            : base(message, innerException)
        {
            method = callerMethod;
            jsonID = callerID;
        }
        public BTCChinaException(string callerMethod, string callerID, string message)
            : base(message)
        {
            method = callerMethod;
            jsonID = callerID;
        }
        public BTCChinaException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public string RequestMethod { get { return method; } }
        public string RequestID { get { return jsonID; } }
    }
}
