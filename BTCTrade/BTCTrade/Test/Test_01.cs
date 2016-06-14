using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;
using System.Threading;

namespace BTCTrade.Test
{
    class Test_01
    {
        public static void Main(string[] args)
        {

            while (true)
            {
                TimeSpan timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1);

                long milliSeconds = Convert.ToInt64(timeSpan.TotalSeconds);
                string nonce = Convert.ToString(Math.Round(timeSpan.TotalSeconds * 100, 0));
                Console.WriteLine(nonce + "     " + timeSpan.TotalSeconds + "     " + Math.Round(timeSpan.TotalSeconds * 100,0));

                Thread.Sleep(1333);

            }

            Console.ReadLine();
        }


    }
}
