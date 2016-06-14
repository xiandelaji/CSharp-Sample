using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Threading;
using GetBTCData;

namespace Test01_GetDataFromWeb
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World");
            //Console.ReadLine();

            try
            {

                WebClient MyWebClient = new WebClient();

                StreamWriter sw_btcc = new StreamWriter("C:\\Max\\data\\btcc.txt");
                StreamWriter sw_okcoin = new StreamWriter("C:\\Max\\data\\okcoin.txt");
                StreamWriter sw_btctrade = new StreamWriter("C:\\Max\\data\\btctrade.txt");
                StreamWriter sw_huobi = new StreamWriter("C:\\Max\\data\\huobi.txt");

                Byte[] pageData_btcc;
                Byte[] pageData_okcoin;
                Byte[] pageData_btctrade;
                Byte[] pageData_huobi;

                string pageHtml_btcc;
                string pageHtml_okcoin;
                string pageHtml_btctrade;
                string pageHtml_huobi;

                MyWebClient.Credentials = CredentialCache.DefaultCredentials;
                while (true)
                {
                    pageData_btcc = MyWebClient.DownloadData("https://data.btcchina.com/data/ticker?market=btccny");
                    pageData_okcoin = MyWebClient.DownloadData("https://www.okcoin.cn/api/v1/ticker.do?symbol=btc_cny");
                    pageData_btctrade = MyWebClient.DownloadData("http://api.btctrade.com/api/ticker?coin=btc");
                    pageData_huobi = MyWebClient.DownloadData("http://api.huobi.com/staticmarket/ticker_btc_json.js");
                    

                    pageHtml_btcc = Encoding.Default.GetString(pageData_btcc);
                    pageHtml_okcoin = Encoding.Default.GetString(pageData_okcoin);
                    pageHtml_btctrade = Encoding.Default.GetString(pageData_btctrade);
                    pageHtml_huobi = Encoding.Default.GetString(pageData_huobi);


                    sw_btcc.WriteLine(
                        StringUtil.getValue(pageHtml_btcc, "date", ",", ":", "\"") + "," +
                        StringUtil.getValue(pageHtml_btcc, "high", ",", ":", "\"") + "," +
                        StringUtil.getValue(pageHtml_btcc, "low", ",", ":", "\"") + "," +
                        StringUtil.getValue(pageHtml_btcc, "last", ",", ":", "\"") + "," +
                        StringUtil.getValue(pageHtml_btcc, "buy", ",", ":", "\"") + "," +
                        StringUtil.getValue(pageHtml_btcc, "sell", ",", ":", "\"") + "," +
                        StringUtil.getValue(pageHtml_btcc, "vol", ",", ":", "\"")
                        );
                    sw_btcc.Flush();

                    sw_okcoin.WriteLine(
                        StringUtil.getValue(pageHtml_okcoin, "date", ",", ":", "\"") + "," +
                        StringUtil.getValue(pageHtml_okcoin, "high", ",", ":", "\"") + "," +
                        StringUtil.getValue(pageHtml_okcoin, "low", ",", ":", "\"") + "," +
                        StringUtil.getValue(pageHtml_okcoin, "last", ",", ":", "\"") + "," +
                        StringUtil.getValue(pageHtml_okcoin, "buy", ",", ":", "\"") + "," +
                        StringUtil.getValue(pageHtml_okcoin, "sell", ",", ":", "\"") + "," +
                        StringUtil.getValue(pageHtml_okcoin, "vol", ",", ":", "\"")
                        );
                    sw_okcoin.Flush();

                    sw_btctrade.WriteLine(
                        StringUtil.getValue(pageHtml_btctrade, "time", ",", ":", "\"") + "," +
                        StringUtil.getValue(pageHtml_btctrade, "high", ",", ":", "\"") + "," +
                        StringUtil.getValue(pageHtml_btctrade, "low", ",", ":", "\"") + "," +
                        StringUtil.getValue(pageHtml_btctrade, "last", ",", ":", "\"") + "," +
                        StringUtil.getValue(pageHtml_btctrade, "buy", ",", ":", "\"") + "," +
                        StringUtil.getValue(pageHtml_btctrade, "sell", ",", ":", "\"") + "," +
                        StringUtil.getValue(pageHtml_btctrade, "vol", ",", ":", "\"")
                        );
                    sw_btctrade.Flush();

                    sw_huobi.WriteLine(
                        StringUtil.getValue(pageHtml_huobi, "time", ",", ":", "\"") + "," +
                        StringUtil.getValue(pageHtml_huobi, "high", ",", ":", "\"") + "," +
                        StringUtil.getValue(pageHtml_huobi, "low", ",", ":", "\"") + "," +
                        StringUtil.getValue(pageHtml_huobi, "last", ",", ":", "\"") + "," +
                        StringUtil.getValue(pageHtml_huobi, "buy", ",", ":", "\"") + "," +
                        StringUtil.getValue(pageHtml_huobi, "sell", ",", ":", "\"") + "," +
                        StringUtil.getValue(pageHtml_huobi, "vol", ",", ":", "\"")
                        );
                    sw_huobi.Flush();

                    Thread.Sleep(3000);

                }


            }

            catch (WebException webEx)
            {

                Console.WriteLine(webEx.Message.ToString());

            }

        }
    }



}
