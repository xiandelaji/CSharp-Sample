using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test00
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BTCChinaAPI a = new BTCChinaAPI("","");

            /*
            StreamReader sr;
            String str="";
            sr = File.OpenText("C:\\Max\\Coin\\test\\json1.txt");
            while (sr.Peek() != -1)
            {
                str = str+sr.ReadLine();

            }
            sr.Close();

            Console.WriteLine(str);
            Console.WriteLine("\n");
            
            JObject o = JObject.Parse(str);
            Console.WriteLine("order: " + o["result"]["order"]);
            //Console.WriteLine("order1: " + o["result"]["order"][0]);
            //Console.WriteLine("order2: " + o["result"]["order"][1]);
            //Console.WriteLine("amount1: " + o["result"]["order"][0]["amount"]);
            //Console.WriteLine("amount2: " + o["result"]["order"][1]["amount"]);
            Console.ReadLine();            
            */

            /*
            TimeSpan timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1);
            long milliSeconds = Convert.ToInt64(timeSpan.TotalMilliseconds*1000);

            Console.WriteLine("DateTime:" + DateTime.UtcNow);
            Console.WriteLine("TotalSeconds:" + timeSpan.TotalSeconds + ",Seconds:" + timeSpan.Seconds);

            //timeSpan.TotalSeconds + new DateTime(1970, 1, 1);
            Console.ReadLine();
            */
        }
    }
}
