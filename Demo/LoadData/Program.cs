using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoadData
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyData btcc = new MyData();
            btcc.name = "BTCC";
            btcc.file = "C:\\Max\\data\\btcc.txt";
            btcc.url = "https://data.btcchina.com/data/ticker?market=btccny";
            btcc.second = 10;
            btcc.minute = 30;

            MyData okcoin = new MyData();
            okcoin.name = "OKCoin";
            okcoin.file = "C:\\Max\\data\\okcoin.txt";
            okcoin.url = "https://www.okcoin.cn/api/v1/ticker.do?symbol=btc_cny";
            okcoin.second = 10;
            okcoin.minute = 30;

            MyData btctrade = new MyData();
            btctrade.name = "BTCTrade";
            btctrade.file = "C:\\Max\\data\\btctrade.txt";
            btctrade.url = "http://api.btctrade.com/api/ticker?coin=btc";
            btctrade.second = 10;
            btctrade.minute = 30;

            MyData huobi = new MyData();
            huobi.name = "HUOBI";
            huobi.file = "C:\\Max\\data\\huobi.txt";
            huobi.url = "http://api.huobi.com/staticmarket/ticker_btc_json.js";
            huobi.second = 10;
            huobi.minute = 30;

            MyData bitstamp = new MyData();
            bitstamp.name = "BITSTAMP";
            bitstamp.file = "C:\\Max\\data\\bitstamp.txt";
            bitstamp.url = "https://www.bitstamp.net/api/v2/ticker/btcusd/";
            bitstamp.second = 10;
            bitstamp.minute = 30;

            MyData bitfinex = new MyData();
            bitfinex.name = "BITFINEX";
            bitfinex.file = "C:\\Max\\data\\bitfinex.txt";
            bitfinex.url = "https://api.bitfinex.com/v1/pubticker/btcusd";
            bitfinex.second = 10;
            bitfinex.minute = 30;

            Thread t1 = new Thread(new ThreadStart(btcc.load));
            Thread t2 = new Thread(new ThreadStart(okcoin.load));
            Thread t3 = new Thread(new ThreadStart(btctrade.load));
            Thread t4 = new Thread(new ThreadStart(huobi.load));
            Thread t5 = new Thread(new ThreadStart(bitstamp.load));
            Thread t6 = new Thread(new ThreadStart(bitfinex.load));
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();
            t6.Start();

        }
    }

    public class MyData
    {
        public string file, url, name;
        public int second, minute;

        public void load()
        {
            WebClient webClient = new WebClient();
            StreamWriter sw = new StreamWriter(this.file, true);
            Byte[] pageData;
            string pageHtml;
            webClient.Credentials = CredentialCache.DefaultCredentials;

            while (true)
            {
                try
                {
                    pageData = webClient.DownloadData(this.url);
                    pageHtml = Encoding.Default.GetString(pageData);
                    sw.WriteLine(pageHtml);
                    Thread.Sleep(this.second * 1000);
                }
                catch (WebException webEx)
                {
                    sw.Flush();                    
                    Console.WriteLine("Error occurred in thread <<" + this.name + ">>");
                    Console.WriteLine(webEx.Message.ToString());
                    Thread.Sleep(this.minute * 1000 * 60);
                }  
             }

        }

    }

}
