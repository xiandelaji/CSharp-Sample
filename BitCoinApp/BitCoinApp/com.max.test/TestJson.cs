using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCoinApp.com.max.test
{
    class TestJson
    {

        public static void vMain(string[] args)
        {
            //string str = "{    \"result\": true,    \"orders\": [        {            \"amount\": 0.1,      \"avg_price\": 0,            \"create_date\": 1418008467000,            \"deal_amount\": 0,            \"order_id\": 10000591,            \"orders_id\": 10000591,            \"price\": 500,            \"status\": 0,            \"symbol\": \"btc_cny\",            \"type\": \"sell\"        },        {            \"amount\": 0.2,            \"avg_price\": 0,            \"create_date\": 1417417957000,            \"deal_amount\": 0,            \"order_id\": 10000724,            \"orders_id\": 10000724,            \"price\": 0.1,            \"status\": 0,            \"symbol\": \"btc_cny\",            \"type\": \"buy\"        }    ]}";
            string str = "{   \"result\":{    \"order\":{    \"id\":2,    \"type\":\"ask\",    \"price\":\"46.84\",    \"currency\":\"CNY\",    \"amount\":\"0.00000000\",    \"amount_original\":\"3.18400000\",    \"date\":1406860694,    \"status\":\"closed\",    \"details\":[{    \"dateline\":\"1406860696\",    \"price\":\"46.84\",    \"amount\":3.184}]    }},    \"id\":\"1\"}";
            JObject o;
            try
            {
                o = JObject.Parse(str);

                Console.WriteLine((double)o["result"]["order"]["price"]);
                Console.WriteLine((double)o["result"]["order"]["amount"]);
                Console.WriteLine((string)o["result"]["order"]["type"]);
            }catch(Exception e){
                Console.WriteLine(e.ToString());
            }
            
            Console.ReadLine();
        }
        

    }
}
