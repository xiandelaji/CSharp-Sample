using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCoinApp.com.max.util
{
    class StringUtil
    {
        public static string BTCCAccessKey = "79a265b4-789f-4f6f-90e6-56e2eb82d4c0";
        public static string BTCCSecretKey = "b02c0e48-73da-401b-b0af-470bee442eab";
        public static string OKCoinAccessKey = "5951da08-4683-474e-a933-c9da9b4c2fdc";
        public static string OKCoinSecretKey = "78220807050D1AB44AB6A552BAC35C8A";

        public static double buyLimit = 1.5;
        public static double sellLimit = 0.2;
        public static double diffLimit = 1;

        public static Boolean isEmpty(String str)
        {
            if (str == null)
                return true;
            String tempStr = str.Trim();
            if (tempStr.Length == 0)
                return true;
            if (tempStr.Equals(("null")))
                return true;
            return false;
        }
    }
}
