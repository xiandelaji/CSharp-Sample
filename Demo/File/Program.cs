using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace File
{
    public class Program
    {
        static void vMain(string[] args)
        {

            WebClient webClient = new WebClient();

            StreamWriter sw_btcc = new StreamWriter("C:\\Max\\data\\btcc.txt", true);

            Byte[] pageData_btcc;

            string pageHtml_btcc;

            webClient.Credentials = CredentialCache.DefaultCredentials;
            try
            {

                while (true)
                {
                    pageData_btcc = webClient.DownloadData("https://data.btcchina.com/data/ticker?market=btccny");

                    pageHtml_btcc = Encoding.Default.GetString(pageData_btcc);


                    sw_btcc.WriteLine(pageHtml_btcc);
                    Console.WriteLine(pageHtml_btcc);
                    //sw_btcc.Flush();

                    Thread.Sleep(0);

                }


            }

            catch (WebException webEx)
            {

                Console.WriteLine(webEx.Message.ToString());
                sw_btcc.Flush();
                sw_btcc.Close();

            }
        }
    }
}
