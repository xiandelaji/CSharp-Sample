using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BitCoinApp.com.max.util
{
    class HttpUtilManager
    {
        private HttpUtilManager() { }
        private static HttpUtilManager instance = new HttpUtilManager();
        public static HttpUtilManager getInstance()
        {
            return instance;
        }

        
        public String requestHttpGet(String url_prex, String url, String param)
        {
            String responseContent = "";
            HttpWebResponse httpWebResponse = null;
            StreamReader streamReader = null;
            try
            {
                url = url_prex + url;
                if (param != null && !param.Equals(""))
                {
                    url = url + "?" + param;
                }
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "GET";
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                streamReader = new StreamReader(httpWebResponse.GetResponseStream());
                if (streamReader == null)
                {
                    return "";
                }
                responseContent = streamReader.ReadToEnd();
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
        
        public String requestHttpPost(String url_prex, String url, Dictionary<String, String> paras)
        {
            String responseContent = "";
            HttpWebResponse httpWebResponse = null;
            StreamReader streamReader = null;
            try
            {  
                url = url_prex + url;
                
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                
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
                    
                    httpWebRequest.GetRequestStream().Write(btBodys, 0, btBodys.Length);
                }
                
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                
                streamReader = new StreamReader(httpWebResponse.GetResponseStream());
                
                responseContent = streamReader.ReadToEnd();
                
                httpWebResponse.Close();
                streamReader.Close();
                
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
    }
}
