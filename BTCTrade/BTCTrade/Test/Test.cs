using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BTCTrade.Test
{
    class Test
    {

        public static void abc(string[] args)
        {
            string accessKey = "a4pjn-wcpum-b2pzf-5bvp4-jbcdw-5k8jk-mupbd";
            string secretKey = "shX14-ts73r-HeRw}-Z*f8p-6j%q]-D(Ocm-~DDWE";

            

            TimeSpan timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1);
            long milliSeconds = Convert.ToInt64(timeSpan.TotalMilliseconds);
            string nonce = Convert.ToString(milliSeconds);


            Dictionary<String, String> paras = new Dictionary<String, String>();
            paras.Add("nonce", nonce);
            paras.Add("version", "2");
            paras.Add("key", accessKey);

            
            string paramsHash = GetHMACSHA1Hash(secretKey, "nonce=" + nonce + "&version=2&key=" + accessKey);
            paras.Add("signature", paramsHash);

            Console.WriteLine("nonce="+nonce);
            Console.WriteLine("signature=" + paramsHash);

            String result = requestHttpPost("http://api.btctrade.com/api/balance", paras);

            Console.WriteLine(result);
            Console.ReadLine();

        }


        public static String requestHttpPost(String url, Dictionary<String, String> paras)
        {
            String responseContent = "";
            HttpWebResponse httpWebResponse = null;
            StreamReader streamReader = null;
            try
            {  //组装访问路径
                //根据url创建HttpWebRequest对象
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                //设置请求方式和头信息
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                //遍历参数集合
                if (!(paras == null || paras.Count == 0))
                {
                    StringBuilder buffer = new StringBuilder();
                    int i = 0;
                    foreach (string key in paras.Keys)
                    {
                        if (i > 0)
                        {
                            buffer.AppendFormat("&{0}={1}", key, paras[key]);
                        }
                        else
                        {
                            buffer.AppendFormat("{0}={1}", key, paras[key]);
                        }
                        i++;
                    }
                    byte[] btBodys = Encoding.UTF8.GetBytes(buffer.ToString());
                    httpWebRequest.ContentLength = btBodys.Length;
                    //将请求内容封装在请求体中
                    httpWebRequest.GetRequestStream().Write(btBodys, 0, btBodys.Length);
                }
                //获取响应
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                //得到响应流
                streamReader = new StreamReader(httpWebResponse.GetResponseStream());
                //读取响应内容
                responseContent = streamReader.ReadToEnd();
                //关闭资源
                httpWebResponse.Close();
                streamReader.Close();
                //返回结果
                if (responseContent == null || "".Equals(responseContent))
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (httpWebResponse != null)
                {
                    httpWebResponse.Close();

                }
                if (streamReader != null)
                {
                    streamReader.Close();
                }
            }
            return responseContent;
        }

        private static string BuildQueryString(NameValueCollection parameters)
        {
            List<string> keyValues = new List<string>();
            foreach (string key in parameters)
            {
                keyValues.Add(key + "=" + parameters[key]);
            }
            return String.Join("&", keyValues.ToArray());
        }

        private static string GetHMACSHA1Hash(string secret_key, string input)
        {
            MD5 md5Hash = MD5.Create();
            HMACSHA256 hmacsha1 = new HMACSHA256(md5Hash.ComputeHash(Encoding.ASCII.GetBytes(secret_key)));
            //HMACSHA256 hmacsha1 = new HMACSHA256(Encoding.ASCII.GetBytes(secret_key));
            MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(input));


            byte[] hashData = hmacsha1.ComputeHash(stream);

            // Format as hexadecimal string.
            StringBuilder hashBuilder = new StringBuilder();
            foreach (byte data in hashData)
            {
                hashBuilder.Append(data.ToString("x2"));
            }
            return hashBuilder.ToString();
        }
        
    }
}
