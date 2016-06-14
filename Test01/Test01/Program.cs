using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Threading;

namespace Test01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World");
            //Console.ReadLine();

            try {

        WebClient MyWebClient = new WebClient();

        StreamWriter sw_btcc = new StreamWriter("C:\\Max\\Coin\\data\\btcc.txt");
        StreamWriter sw_okcoin = new StreamWriter("C:\\Max\\Coin\\data\\okcoin.txt");
        StreamWriter sw_btctrade = new StreamWriter("C:\\Max\\Coin\\data\\btctrade.txt");

        Byte[] pageData_btcc;
        Byte[] pageData_okcoin;
        Byte[] pageData_btctrade;

        string pageHtml_btcc;
        string pageHtml_okcoin;
        string pageHtml_btctrade;
        
        MyWebClient.Credentials = CredentialCache.DefaultCredentials;
        while (true)
        {
            pageData_btcc = MyWebClient.DownloadData("https://data.btcchina.com/data/ticker?market=btccny");
            pageData_okcoin = MyWebClient.DownloadData("https://www.okcoin.cn/api/v1/ticker.do?symbol=btc_cny");
            pageData_btctrade = MyWebClient.DownloadData("http://api.btctrade.com/api/ticker?coin=btc");

            pageHtml_btcc = Encoding.Default.GetString(pageData_btcc);
            pageHtml_okcoin = Encoding.Default.GetString(pageData_okcoin);
            pageHtml_btctrade = Encoding.Default.GetString(pageData_btctrade);

            sw_btcc.WriteLine(pageHtml_btcc);
            sw_btcc.Flush();

            sw_okcoin.WriteLine(pageHtml_okcoin);
            sw_okcoin.Flush();

            sw_btctrade.WriteLine(pageHtml_btctrade);
            sw_btctrade.Flush();

            Thread.Sleep(3000);

        }

        
    }

    catch(WebException webEx) {

        Console.WriteLine(webEx.Message.ToString());

    }

        }
    }
}
