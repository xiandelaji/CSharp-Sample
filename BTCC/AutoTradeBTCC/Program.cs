using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AutoTradeBTCC
{
    public class Program
    {
        public static string result;

        public static double balanceCNYAmount;
        public static double balanceBTCAmount;

        public static WebRequest webRequest;
        public static string tonce;


        public Program()
        {

        }

        public static void Main(string[] args)
        {
            string accessKey = "79a265b4-789f-4f6f-90e6-56e2eb82d4c0";
            string secretKey = "b02c0e48-73da-401b-b0af-470bee442eab";
            string url = "https://api.btcc.com/api_trade_v1.php";
            webRequest = WebRequest.Create(url);
            tonce = getCurrentTonce();

            //setInitialAmount(accessKey, secretKey, tonce);

            cancelOpenOrders(accessKey, secretKey, tonce);

            //Console.WriteLine("balanceCNYAmount:" + balanceCNYAmount);
            //Console.WriteLine("balanceBTCAmount:" + balanceBTCAmount);
            Console.ReadLine();

            //test();

        }

        public static void initial()
        {

        }

        public static void test()
        {
            Console.WriteLine(">>0<<");
            StreamWriter sw = new StreamWriter("C:\\Max\\Coin\\log\\btcc.log");
            // For https.
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            Console.WriteLine(">>1<<");
            string accessKey = "79a265b4-789f-4f6f-90e6-56e2eb82d4c0";
            string secretKey = "b02c0e48-73da-401b-b0af-470bee442eab";
            string method = "getAccountInfo";//sellOrder2
            string paras = "";//2989.50,0.001,BTCCNY
            //string tonce = getCurrentTonce();
            string paramQueryString = "tonce=" + tonce + "&accesskey=" + accessKey + "&requestmethod=post&id=1&method=" + method + "&params=" + paras;
            
            Console.WriteLine(">>2<<");
            string hash_hmac = getHMACSHA1Hash(accessKey, secretKey, paramQueryString);
            string postData = "{\"method\": \"" + method + "\", \"params\": [" + paras + "], \"id\": 1}";

            Console.WriteLine(">>4<<");
            string tmp = sendPostByWebRequest(hash_hmac, tonce, postData, sw);
            Console.WriteLine(tmp);
            Console.ReadLine();
        }

        public static void cancelOpenOrders(string accessKey, string secretKey, string tonce)
        {
            string paramQueryString = "tonce=" + tonce + "&accesskey=" + accessKey + "&requestmethod=post&id=1&method=getOrders&params=";
            string hash_hmac = getHMACSHA1Hash(accessKey, secretKey, paramQueryString);
            string str = sendPostByWebRequest(hash_hmac, tonce, "{\"method\": \"getOrders\", \"params\": [], \"id\": 1}");
            JObject o = JObject.Parse(str);
            JEnumerable<JToken> orders = o["result"]["order"].Children();
            while (orders.Count() > 0)
            {
                foreach (var item in orders)
                {

                }
            }

            Console.WriteLine(orders.Count());
        }

        public static void setInitialAmount(string accessKey, string secretKey, string tonce)
        {
            string paramQueryString = "tonce=" + tonce + "&accesskey=" + accessKey + "&requestmethod=post&id=1&method=getAccountInfo&params=";
            string hash_hmac = getHMACSHA1Hash(accessKey, secretKey, paramQueryString);
            string str = sendPostByWebRequest(hash_hmac, tonce, "{\"method\": \"getAccountInfo\", \"params\": [], \"id\": 1}");
            if (str != null && str != "")
            {
                JObject o = JObject.Parse(str);
                balanceCNYAmount = (double)o["result"]["balance"]["cny"]["amount"];
                balanceBTCAmount = (double)o["result"]["balance"]["btc"]["amount"];
            }
        }

        public static string getCurrentTonce()
        {
            /*
            TimeSpan timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1);
            long milliSeconds = Convert.ToInt64(timeSpan.TotalMilliseconds * 1000);
            string tonce = Convert.ToString(milliSeconds);
            */
            return Convert.ToString(Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds * 1000));
        }

        public static string sendPostByWebRequest(string hash_hmac, string tonce, string postData)
        {
            if (webRequest == null)
            {
                Console.WriteLine("Failed to create btcc web request.");
                return "";
            }
            byte[] bytes = Encoding.ASCII.GetBytes(postData);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json-rpc";
            webRequest.ContentLength = bytes.Length;
            webRequest.Headers["Authorization"] = "Basic " + hash_hmac;
            webRequest.Headers["Json-Rpc-Tonce"] = tonce;
            try
            {
                // Send the json authentication post request
                using (Stream dataStream = webRequest.GetRequestStream())
                {
                    dataStream.Write(bytes, 0, bytes.Length);
                    dataStream.Close();
                }
                // Get authentication response
                using (WebResponse response = webRequest.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            var content = reader.ReadToEnd();
                            return content;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public static string sendPostByWebRequest(string hash_hmac, string tonce, string postData, StreamWriter sw)
        {
            if (webRequest == null)
            {
                Console.WriteLine("Failed to create btcc web request.");
                return "";
            }
            byte[] bytes = Encoding.ASCII.GetBytes(postData);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json-rpc";
            webRequest.ContentLength = bytes.Length;
            webRequest.Headers["Authorization"] = "Basic " + hash_hmac;
            webRequest.Headers["Json-Rpc-Tonce"] = tonce;
            try
            {
                // Send the json authentication post request
                using (Stream dataStream = webRequest.GetRequestStream())
                {
                    dataStream.Write(bytes, 0, bytes.Length);
                    dataStream.Close();
                }
                // Get authentication response
                using (WebResponse response = webRequest.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            var content = reader.ReadToEnd();
                            sw.WriteLine(content);
                            sw.Flush();
                            sw.Close();
                            return content;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
                sw.WriteLine(ex.Message);
                sw.Flush();
                sw.Close();
                return "";
            }
        }

        private static string getHMACSHA1Hash(string access_key, string secret_key, string input)
        {
            HMACSHA1 hmacsha1 = new HMACSHA1(Encoding.ASCII.GetBytes(secret_key));
            MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(input));
            byte[] hashData = hmacsha1.ComputeHash(stream);
            // Format as hexadecimal string.
            StringBuilder hashBuilder = new StringBuilder();
            foreach (byte data in hashData)
            {
                hashBuilder.Append(data.ToString("x2"));
            }
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(access_key + ':' + hashBuilder.ToString()));
        }

    }
}
