using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Test02_String
{
    public class Class1
    {
        static void Main(string[] args)
        {
            String str = "{\"high\":2927.98,\"low\":2869,\"buy\":2900.41,\"sell\":2902.63,\"last\":2900.48,\"vol\":141697.49,\"time\":1461288896}";
            String key = "buy";
            String separator = ",";
            String replace1 = ":";
            String replace2 = "\"";
            String value = "";

            //value = getValue(str, key, separator, replace1, replace2);

            Console.WriteLine("high:" + StringUtil.getValue(str, "high", separator, replace1, replace2));
            Console.WriteLine("low:" + StringUtil.getValue(str, "low", separator, replace1, replace2));
            Console.WriteLine("buy:" + StringUtil.getValue(str, "buy", separator, replace1, replace2));
            Console.WriteLine("sell:" + StringUtil.getValue(str, "sell", separator, replace1, replace2));
            Console.WriteLine("last:" + StringUtil.getValue(str, "last", separator, replace1, replace2));
            Console.WriteLine("vol:" + StringUtil.getValue(str, "vol", separator, replace1, replace2));
            Console.ReadLine();
        }

    }
}
