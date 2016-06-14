using BitCoinApp.com.max.btcc;
using BitCoinApp.com.max.okcoin;
using BitCoinApp.com.max.util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCoinApp.com.max.business
{
    class BusinessProcessor
    {

        public double btcc_balance_btc;
        public double btcc_balance_cny;
        public double btcc_frozen_btc;
        public double btcc_frozen_cny;
        public double okcoin_balance_btc;
        public double okcoin_balance_cny;
        public double okcoin_frozen_btc;
        public double okcoin_frozen_cny;

        public double currentBTCCNYPrice_BTCC;
        public double currentBTCCNYPrice_OKCoin;

        public double diffPriceCurrent;
        public double diffPriceActual;
        public double diffPriceBak;

        public string status = "0000";
        public int count = 0;

        public string orderResultBTCC;
        public string orderResultOKCoin;

        public double tradePriceBTCC;
        public double tradeAmountBTCC;
        public string tradeTypeBTCC;
        public double tradePriceOKCoin;
        public double tradeAmountOKCoin;
        public string tradeTypeOKCoin;

        public bool noError = true;

        public double limitBUY;
        public double limitSELL;

        public string orderStatusBTCC;
        public string orderStatusOKCoin;



        log4net.ILog log = LogUtil.getLog();

        public void getBalance(BTCChinaAPI btcc)
        {
            log.Info("is executing function getBalance(BTCChinaAPI)");
            string str = btcc.getAccountInfo();
            log.Info("get BTCC account info");
            log.Info(str);
            JObject o = JObject.Parse(str);
            this.btcc_balance_btc = (double)o["result"]["balance"]["btc"]["amount"];
            this.btcc_balance_cny = (double)o["result"]["balance"]["cny"]["amount"];
            this.btcc_frozen_btc = (double)o["result"]["frozen"]["btc"]["amount"];
            this.btcc_frozen_cny = (double)o["result"]["frozen"]["cny"]["amount"];
            log.Info("BTCC balance is btc=" + this.btcc_balance_btc + ", cny=" + btcc_balance_cny + "; frozen is btc=" + this.btcc_frozen_btc + ", cny=" + this.btcc_frozen_cny);

            if (this.status == "0000" && this.btcc_balance_btc < 0.01)
            {
                this.noError = false;
                log.Info("There is no enough btcc coin.");
            }
        }

        public void getBalance(OKCoinAPI okcoin)
        {
            log.Info("is executing function getBalance(OKCoinAPI)");
            string str = okcoin.userinfo();
            log.Info("get OKCoin account info");
            log.Info(str);
            JObject o = JObject.Parse(str);
            this.okcoin_balance_btc = (double)o["info"]["funds"]["free"]["btc"];
            this.okcoin_balance_cny = (double)o["info"]["funds"]["free"]["cny"];
            this.okcoin_frozen_btc = (double)o["info"]["funds"]["freezed"]["btc"];
            this.okcoin_frozen_cny = (double)o["info"]["funds"]["freezed"]["cny"];
            log.Info("OKCoin balance is btc=" + this.okcoin_balance_btc + ", cny=" + this.okcoin_balance_cny + "; frozen is btc=" + this.okcoin_frozen_btc + ", cny=" + this.okcoin_frozen_cny);

            if (this.status == "0000" && this.okcoin_balance_btc < 0.01)
            {
                this.noError = false;
                log.Info("There is no enough okcoin.");
            }
        }

        public void initialBalance(BTCChinaAPI btcc, OKCoinAPI okcoin)
        {
            this.getBalance(btcc);
            this.getBalance(okcoin);
        }

        public void getCurrentBTCPrice(BTCChinaAPI btcc)
        {
            log.Info("is executing function getCurrentBTCPrice(BTCChinaAPI)");
            string str = btcc.getMarketDepth(1, BTCChinaAPI.MarketType.BTCCNY);
            log.Info("get BTCC price");
            log.Info(str);
            JObject o = JObject.Parse(str);
            this.currentBTCCNYPrice_BTCC = (double)o["result"]["market_depth"]["ask"][0]["price"];
            log.Info("BTCC Price is: " + this.currentBTCCNYPrice_BTCC);
        }

        public void getCurrentOKCoinPrice(OKCoinAPI okcoin)
        {
            log.Info("is executing function getCurrentBTCPrice(OKCoinAPI)");
            string str = okcoin.depth("btc_cny", "1");
            log.Info("get OKCoin price");
            log.Info(str);
            JObject o = JObject.Parse(str);
            this.currentBTCCNYPrice_OKCoin = (double)o["asks"][0][0];
            log.Info("OKCoin Price is: " + this.currentBTCCNYPrice_OKCoin);
        }

        public void getCurrentPrice(BTCChinaAPI btcc, OKCoinAPI okcoin)
        {
            this.getCurrentBTCPrice(btcc);
            this.getCurrentOKCoinPrice(okcoin);
        }

        public bool checkStatus()
        {

            return false;
        }
        /*
        public void buyBTCCSellOKCOIN(BTCChinaAPI btcc, OKCoinAPI okcoin)
        {
            
            if(this.okcoin_balance_btc>=0.01){
                string str1;
                string str2;
                log.Info("is executing function buyBTCCSellOKCOIN()");

                str1 = okcoin.trade("btc_cny", "sell_market", "", "0.01");
                log.Info("okcoin status (sell_market): " + str1);

                if (!this.isError(str1))
                {
                    this.orderResultOKCoin = str1;
                    this.status = "1000";
                    log.Info("status: " + this.status);

                    str2 = btcc.PlaceOrder(-1, 0.01, BTCChinaAPI.MarketType.BTCCNY);
                    log.Info("btcc status (buy_market): " + str2);
                    if (!this.isError(str2))
                    {
                        this.orderResultBTCC = str2;
                        this.status = "1100";
                        log.Info("status: " + this.status);
                    }
                    else
                    {
                        this.noError = false;
                        log.Error("Error occurred when buy btcc, json result is " + str2);
                    }

                }
                else
                {
                    this.noError = false;
                    log.Error("Error occurred when sell okcoin, json result is " + str1);
                }
            }
            else
            {
                log.Info("There is no much coin in OKCoin to sell.");
            }
            
            
            
        }

        public void sellBTCCBuyOKCOIN(BTCChinaAPI btcc, OKCoinAPI okcoin)
        {
            if(this.btcc_balance_btc>=0.01){
                string str1;
                string str2;
                log.Info("is executing function sellBTCCBuyOKCOIN()");

                str1 = btcc.PlaceOrder(-1, -0.01, BTCChinaAPI.MarketType.BTCCNY);
                log.Info("btcc status (sell_market): " + str1);
                if (!this.isError(str1))
                {
                    this.orderResultBTCC = str1;
                    this.status = "1110";
                    log.Info("status: " + this.status);

                    str2 = okcoin.trade("btc_cny", "buy_market", "" + currentBTCCNYPrice_OKCoin * 0.01001 + "", "");
                    log.Info("okcoin status (buy_market): " + str2);
                    if (!this.isError(str2))
                    {
                        this.orderResultOKCoin = str2;
                        this.status = "1111";
                        log.Info("status: " + this.status);
                    }
                    else
                    {
                        this.noError = false;
                        log.Error("Error occurred when buy okcoin, json result is " + str2);
                    }

                }
                else
                {
                    this.noError = false;
                    log.Error("Error occurred when sell btcc, json result is " + str1);
                }
            }
            else
            {
                log.Info("There is no much coin in BTCC to sell.");
            }
        }
        */

        public void getTradePrice(BTCChinaAPI btcc)
        {
            uint orderID = this.getOrderID(btcc);
            string str = this.getOrderInfo(btcc, orderID);
            if (!this.isError(str))
            {
                JObject o = JObject.Parse(str);
                this.tradePriceBTCC = (double)o["result"]["order"]["avg_price"];
                this.tradeAmountBTCC = (double)o["result"]["order"]["amount_original"];
                this.tradeTypeBTCC = (string)o["result"]["order"]["type"];
                log.Info("BTCC actual trade price: " + tradePriceBTCC + ", Amount: " + tradeAmountBTCC + ", type: " + tradeTypeBTCC);
            }
            else
            {
                log.Error("Error occurred in getTradePrice(BTCChinaAPI), json result is: ");
                log.Error(str);
                log.Error("orderResultBTCC is: " + this.orderResultBTCC);
            }
        }

        public void getTradePrice(OKCoinAPI okcoin)
        {
            string orderID = this.getOrderID(okcoin);
            string str = this.getOrderInfo(okcoin, orderID);
            if (!this.isError(str))
            {
                JObject o = JObject.Parse(str);
                this.tradePriceOKCoin = (double)o["orders"][0]["avg_price"];
                this.tradeAmountOKCoin = (double)o["orders"][0]["amount"];
                this.tradeTypeOKCoin = (string)o["orders"][0]["type"];
                log.Info("OKCoin actual trade price: " + tradePriceOKCoin + ", Amount: " + tradeAmountOKCoin + ", type: " + tradeTypeOKCoin);
            }
            else
            {
                log.Error("Error occurred in getTradePrice(OKCoinAPI), json result is: ");
                log.Error(str);
                log.Error("orderResultOKCoin is: " + this.orderResultOKCoin);
            }
        }

        public void getTradePrice(BTCChinaAPI btcc, OKCoinAPI okcoin)
        {
            this.getTradePrice(btcc);
            this.getTradePrice(okcoin);
        }

        public void execute(BTCChinaAPI btcc, OKCoinAPI okcoin)
        {
            this.initialBalance(btcc, okcoin);

            while(this.count<5&&this.noError){
                this.getCurrentPrice(btcc, okcoin);
                this.diffPriceCurrent = this.currentBTCCNYPrice_OKCoin - this.currentBTCCNYPrice_BTCC;
                log.Info("@diffPriceCurrent is: " + this.diffPriceCurrent);

                
                if(this.status == "0000"){
                    if (Math.Abs(this.diffPriceCurrent) >= 1.5)
                    {
                        this.trade(btcc, okcoin, this.currentBTCCNYPrice_BTCC, this.currentBTCCNYPrice_OKCoin, 0.01, 0.01, this.diffPriceCurrent, 1);
                        this.waitOrderComplete(btcc, okcoin);
                        
                        this.initialBalance(btcc, okcoin);
                        this.getTradePrice(btcc, okcoin);
                        this.diffPriceActual = this.tradePriceOKCoin - this.tradePriceBTCC;
                        log.Info("1st @diffPriceActual is: " + this.diffPriceActual);
                        this.diffPriceBak = this.currentBTCCNYPrice_OKCoin - this.currentBTCCNYPrice_BTCC;
                        log.Info("diffPriceBak=" + this.diffPriceBak);
                    }
                }
                else if (this.status == "1100")
                {
                    if ((this.diffPriceBak > 0 && this.diffPriceCurrent <= 0.5) || (this.diffPriceBak < 0 && this.diffPriceCurrent >= -0.5))
                    {
                        this.trade(btcc, okcoin, this.currentBTCCNYPrice_BTCC, this.currentBTCCNYPrice_OKCoin, 0.01, 0.01, this.diffPriceBak, 2);
                        this.waitOrderComplete(btcc, okcoin);
                        this.status = "0000";
                        this.count = this.count + 1;

                        this.initialBalance(btcc, okcoin);

                        this.getTradePrice(btcc, okcoin);
                        this.diffPriceActual = this.tradePriceOKCoin - this.tradePriceBTCC;
                        log.Info("2nd @diffPriceActual is: " + this.diffPriceActual);
                        log.Info("Count is: "+this.count);
                    }
                }                
            }
        }

        public bool isError(string str)
        {
            return str.Contains("error");
        }

        public void tradeBTCC(BTCChinaAPI btcc, double currentPrice, double amount, string type)
        {
            string str;
            int flag;
            if(type == "sell"){
                flag = -1;
            }else{
                flag = 1;
            }
            log.Info("is executing function tradeBTCC(BTCChinaAPI) to (" + type + ")");
            log.Info("currentPrice=" + currentPrice + ", amount=" + amount + ", btcc_balance_cny=" + this.btcc_balance_cny + ", btcc_balance_btc=" + this.btcc_balance_btc);

            if ((type == "buy" && this.btcc_balance_cny > currentPrice * amount) || (type == "sell" && this.btcc_balance_btc >= amount))
            {
                str = btcc.PlaceOrder(currentPrice, flag * amount, BTCChinaAPI.MarketType.BTCCNY);
                log.Info("json result of (" + type + ") btcc is " + str);
                this.orderResultBTCC = str;

                if (this.isError(str))
                {
                    this.noError = false;
                    log.Error("Error occurred when (" + type + ") btcc, json result is " + str);
                }
                
            }

            if (type == "buy" && this.btcc_balance_cny < currentPrice * amount)
            {
                this.noError = false;
                log.Info("there is no enough money to buy btcc coin.");
            }

            if (type == "sell" && this.btcc_balance_btc < amount)
            {
                this.noError = false;
                log.Info("there is no enough btcc coin to sell.");
            }
        }

        public void tradeOKCoin(OKCoinAPI okcoin, double currentPrice, double amount, string type)
        {
            string str;
            log.Info("is executing function tradeBTCC(OKCoinAPI) to (" + type + ")");
            log.Info("currentPrice=" + currentPrice + ", amount=" + amount + ", okcoin_balance_cny=" + this.okcoin_balance_cny + ", okcoin_balance_btc=" + this.okcoin_balance_btc);

            if ((type == "buy" && this.okcoin_balance_cny > currentPrice * amount) || (type == "sell" && this.okcoin_balance_btc >= amount))
            {
                str = okcoin.trade("btc_cny", type, currentPrice.ToString("F2"), amount.ToString("F2"));
                log.Info("json result of (" + type + ") okcoin is " + str);
                this.orderResultOKCoin = str;

                if (this.isError(str))
                {
                    this.noError = false;
                    log.Error("Error occurred when (" + type + ") okcoin, json result is " + str);
                }

            }

            if (type == "buy" && this.okcoin_balance_cny < currentPrice * amount)
            {
                this.noError = false;
                log.Info("there is no enough money to buy okcoin.");
            }

            if (type == "sell" && this.okcoin_balance_btc < Math.Abs(amount))
            {
                this.noError = false;
                log.Info("there is no enough okcoin to sell.");
            }
        }

        public void trade(BTCChinaAPI btcc, OKCoinAPI okcoin, double currentPriceBTCC, double currentPriceOKCoin, double amountBTCC, double amountOKCoin, double diffPrice, int round)
        {
            if(this.noError){
                if (diffPrice > 0)
                {
                    if(round == 1){
                        log.Info("is executing round1 function trade()");
                        
                        this.tradeOKCoin(okcoin, currentPriceOKCoin, amountOKCoin, "sell");
                        this.status = "1000";
                        log.Info("status: " + this.status);

                        if (this.noError)
                        {
                            this.tradeBTCC(btcc, currentPriceBTCC, amountBTCC, "buy");
                            this.status = "1100";
                            log.Info("status: " + this.status);
                        }
                    }else if(round == 2){
                        log.Info("is executing round2 function trade()");
                        this.tradeBTCC(btcc, currentPriceBTCC, amountBTCC, "sell");
                        this.status = "1110";
                        log.Info("status: " + this.status);

                        if (this.noError)
                        {
                            this.tradeOKCoin(okcoin, currentPriceOKCoin, amountOKCoin, "buy");
                            this.status = "1111";
                            log.Info("status: " + this.status);
                        }
                    }

                }
                else if (diffPrice < 0)
                {
                    if (round == 1)
                    {
                        log.Info("is executing round1 function trade()");
                        this.tradeBTCC(btcc, currentPriceBTCC, amountBTCC, "sell");
                        this.status = "1000";
                        log.Info("status: " + this.status);

                        if (this.noError)
                        {
                            this.tradeOKCoin(okcoin, currentPriceOKCoin, amountOKCoin, "buy");
                            this.status = "1100";
                            log.Info("status: " + this.status);
                        }
                    }else if(round == 2){
                        log.Info("is executing round2 function trade()");
                        this.tradeOKCoin(okcoin, currentPriceOKCoin, amountOKCoin, "sell");
                        this.status = "1110";
                        log.Info("status: " + this.status);

                        if (this.noError)
                        {
                            this.tradeBTCC(btcc, currentPriceBTCC, amountBTCC, "buy");
                            this.status = "1111";
                            log.Info("status: " + this.status);
                        }
                    }
                }
                
                
            }
        }

        public void setLimitValue()
        {

        }

        public uint getOrderID(BTCChinaAPI btcc)
        {
            uint orderID = 0;
            if (!StringUtil.isEmpty(this.orderResultBTCC))
            {
                JObject o;
                o = JObject.Parse(this.orderResultBTCC);
                orderID = (uint)o["result"];
            }
            return orderID;
        }

        public string getOrderID(OKCoinAPI okcoin)
        {
            string orderID = "0";
            if (!StringUtil.isEmpty(this.orderResultOKCoin))
            {
                JObject o;
                o = JObject.Parse(this.orderResultOKCoin);
                orderID = (string)o["order_id"];
            }
            return orderID;
        }

        public string getOrderInfo(BTCChinaAPI btcc, uint orderID)
        {
            string info = "";
            if (orderID != 0)
            {
                info = btcc.getOrder(orderID, BTCChinaAPI.MarketType.BTCCNY);
                log.Info("get BTCC order info: ");
                log.Info(info);
            }
            return info;
        }

        public string getOrderInfo(OKCoinAPI okcoin, string orderID)
        {
            string info = "";
            if (orderID != "0")
            {
                info = okcoin.order_info("btc_cny", orderID);
                log.Info("get OKCoin order info: ");
                log.Info(info);
            }
            return info;
        }

        //[open |closed | cancelled | pending |error | insufficient_balance]
        public string getOrderStatus(BTCChinaAPI btcc, string info)
        {
            string status="";
            if (!this.isError(info))
            {
                JObject o = JObject.Parse(info);
                status = (string)o["result"]["order"]["status"];
                log.Info("BTCC Order Status: " + status);
            }
            return status;
        }

        //status： -1：已撤销,  0：未成交,  1：部分成交, 2：完全成交, 4:撤单处理中
        public string getOrderStatus(OKCoinAPI okcoin, string info)
        {
            string status = "";
            if (!this.isError(info))
            {
                JObject o = JObject.Parse(info);
                status = (string)o["orders"][0]["status"];
                if (status == "2")
                {
                    status = "closed";
                }
                log.Info("OKCoin Order Status: " + status);
            }
            return status;
        }

        public void waitOrderComplete(BTCChinaAPI btcc, OKCoinAPI okcoin)
        {
            string orderInfoBTCC;
            string orderInfoOKCoin;
            log.Info("in function waitOrderComplete()......");
            while (true)
            {
                orderInfoBTCC = this.getOrderInfo(btcc, this.getOrderID(btcc));
                this.orderStatusBTCC = this.getOrderStatus(btcc, orderInfoBTCC);
                this.getCurrentBTCPrice(btcc);
                if (this.orderStatusBTCC == "closed")
                {
                    log.Info("BTCC Order Info: " + orderInfoBTCC);
                    log.Info("BTCC Order Completed: status=" + this.status);
                    break;
                }
            }
            
            while (true)
            {
                orderInfoOKCoin = this.getOrderInfo(okcoin, this.getOrderID(okcoin));
                this.orderStatusOKCoin = this.getOrderStatus(okcoin, orderInfoOKCoin);
                this.getCurrentOKCoinPrice(okcoin);
                if (this.orderStatusOKCoin == "closed")
                {
                    log.Info("OKCoin Order Info: " + orderInfoOKCoin);
                    log.Info("OKCoin Order Completed: status=" + this.status);
                    break;
                }
            }
            log.Info("Function waitOrderComplete() is completed.");
        }
    }
}
