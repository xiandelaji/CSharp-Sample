using BitCoinApp.com.max.btcc;
using BitCoinApp.com.max.business;
using BitCoinApp.com.max.okcoin;
using BitCoinApp.com.max.util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCoinApp
{
    public class Program
    {
        public static void vMain(string[] args)
        {

                        
            BTCChinaAPI btcc = new BTCChinaAPI(StringUtil.BTCCAccessKey, StringUtil.BTCCSecretKey);
            OKCoinAPI okcoin = new OKCoinAPI(StringUtil.OKCoinAccessKey, StringUtil.OKCoinSecretKey);

            BusinessProcessor bus = new BusinessProcessor();
            bus.execute(btcc, okcoin);

            //bus.initialBalance(btcc, okcoin);

            //Console.ReadLine();

        }
    }
}
