using BitCoinApp.com.max.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCoinApp.com.max.okcoin
{
    class OKCoinAPI
    {
        
        private String secret_key;
        private String api_key;
        private String url_prex = "https://www.okcoin.cn";

        public String getSecret_key()
        {
            return secret_key;
        }

        public void setSecret_key(String secret_key)
        {
            this.secret_key = secret_key;
        }

        public String getApi_key()
        {
            return api_key;
        }

        public void setApi_key(String api_key)
        {
            this.api_key = api_key;
        }

        public String getUrl_prex()
        {
            return url_prex;
        }

        public void setUrl_prex(String url_prex)
        {
            this.url_prex = url_prex;
        }

        public OKCoinAPI(String api_key, String secret_key)
        {
            this.api_key = api_key;
            this.secret_key = secret_key;
        }
        public OKCoinAPI(String url_prex, String api_key, String secret_key)
        {
            this.api_key = api_key;
            this.secret_key = secret_key;
            this.url_prex = url_prex;
        }

        public OKCoinAPI(String url_prex)
        {
            this.url_prex = url_prex;
        }

        private const String TICKER_URL = "/api/v1/ticker.do";
        private const String DEPTH_URL = "/api/v1/depth.do";
        private const String TRADES_URL = "/api/v1/trades.do";
        private const String KLINE_URL = "/api/v1/kline.do";
        private const String USERINFO_URL = "/api/v1/userinfo.do";

        private const String TRADE_URL = "/api/v1/trade.do";

        private const String BATCH_TRADE_URL = "/api/v1/batch_trade.do";

        private const String CANCEL_ORDER_URL = "/api/v1/cancel_order.do";

        private const String ORDER_INFO_URL = "/api/v1/order_info.do";

        private const String ORDERS_INFO_URL = "/api/v1/orders_info.do";

        private const String ORDER_HISTORY_URL = "/api/v1/order_history.do";
        private const String WITHDRAW_URL = "/api/v1/withdraw.do";
        private const String CANCEL_WITHDRAW_RUL = "/api/v1/cancel_withdraw.do";
        private const String ORDER_FEE_URL = "/api/v1/order_fee.do";
        private const String LEND_DEPTH_URL = "/api/v1/lend_depth.do";
        private const String BORROWS_INFO_URL = "/api/v1/borrows_info.do";
        private const String BORROW_MONEY_URL = "/api/v1/borrow_money.do";
        private const String CANCEL_BORROW_URL = "/api/v1/cancel_borrow.do";
        private const String BORROW_ORDER_INFO = "/api/v1/borrow_order_info.do";
        private const String REPAYMENT_URL = "/api/v1/repayment.do";
        private const String UNREPAYMENTS_INFO_URL = "/api/v1/unrepayments_info.do";
        private const String ACCOUNT_RECORDS_URL = "/api/v1/account_records.do";
        private const String TRADE_HISTORY_URL = "/api/v1/trade_history.do";
        
        public String ticker(String symbol)
        {
            String result = "";
            try
            {
                HttpUtilManager httpUtil = HttpUtilManager.getInstance();
                String param = "";
                if (!StringUtil.isEmpty(symbol))
                {
                    if (!param.Equals(""))
                    {
                        param += "&";
                    }
                    param += "symbol=" + symbol;
                }
                result = httpUtil.requestHttpGet(url_prex, TICKER_URL, param);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        public String depth(String symbol, String size)
        {
            String result = "";
            try
            {
                HttpUtilManager httpUtil = HttpUtilManager.getInstance();
                String param = "";
                if (!StringUtil.isEmpty(symbol))
                {
                    if (!param.Equals(""))
                    {
                        param += "&";
                    }
                    param += "symbol=" + symbol;
                }
                if (!StringUtil.isEmpty(size))
                {
                    if (!param.Equals(""))
                    {
                        param += "&";
                    }
                    param += "size=" + size;
                }
                result = httpUtil.requestHttpGet(url_prex, DEPTH_URL, param);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        public String trades(String symbol, String since)
        {
            String result = "";
            try
            {
                HttpUtilManager httpUtil = HttpUtilManager.getInstance();
                String param = "";
                if (!StringUtil.isEmpty(symbol))
                {
                    if (!param.Equals(""))
                    {
                        param += "&";
                    }
                    param += "symbol=" + symbol;
                }
                if (!StringUtil.isEmpty(since))
                {
                    if (!param.Equals(""))
                    {
                        param += "&";
                    }
                    param += "since=" + since;
                }
                result = httpUtil.requestHttpGet(url_prex, TRADES_URL, param);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        
        public String kline(String symbol, String type, String size, String since)
        {
            String result = "";
            try
            {
                HttpUtilManager httpUtil = HttpUtilManager.getInstance();
                String param = "";
                if (!StringUtil.isEmpty(symbol))
                {
                    if (!param.Equals(""))
                    {
                        param += "&";
                    }
                    param += "symbol=" + symbol;
                }
                if (!StringUtil.isEmpty(type))
                {
                    if (!param.Equals(""))
                    {
                        param += "&";
                    }
                    param += "type=" + type;
                }
                if (!StringUtil.isEmpty(size))
                {
                    if (!param.Equals(""))
                    {
                        param += "&";
                    }
                    param += "size=" + size;
                }
                if (!StringUtil.isEmpty(since))
                {
                    if (!param.Equals(""))
                    {
                        param += "&";
                    }
                    param += "since=" + since;
                }
                result = httpUtil.requestHttpGet(url_prex, KLINE_URL, param);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        
        public String userinfo()
        {
            String result = "";
            try
            {
                Dictionary<String, String> paras = new Dictionary<String, String>();
                paras.Add("api_key", api_key);
                String sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);

                HttpUtilManager httpUtil = HttpUtilManager.getInstance();
                result = httpUtil.requestHttpPost(url_prex, USERINFO_URL,
                       paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        public String trade(String symbol, String type,
                String price, String amount)
        {
            String result = "";
            try
            {
                Dictionary<String, String> paras = new Dictionary<String, String>();
                paras.Add("api_key", api_key);
                if (!StringUtil.isEmpty(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!StringUtil.isEmpty(type))
                {
                    paras.Add("type", type);
                }
                if (!StringUtil.isEmpty(price))
                {
                    paras.Add("price", price);
                }
                if (!StringUtil.isEmpty(amount))
                {
                    paras.Add("amount", amount);
                }
                String sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);

                HttpUtilManager httpUtil = HttpUtilManager.getInstance();
                result = httpUtil.requestHttpPost(url_prex, TRADE_URL,
                       paras);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
        
        public String batch_trade(String symbol, String type,
                String orders_data)
        {
            String result = "";
            try
            { 
                Dictionary<String, String> paras = new Dictionary<String, String>();
                paras.Add("api_key", api_key);
                if (!StringUtil.isEmpty(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!StringUtil.isEmpty(type))
                {
                    paras.Add("type", type);
                }
                if (!StringUtil.isEmpty(orders_data))
                {
                    paras.Add("orders_data", orders_data);
                }
                String sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);

                
                HttpUtilManager httpUtil = HttpUtilManager.getInstance();
                result = httpUtil.requestHttpPost(url_prex, BATCH_TRADE_URL,
                       paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        public String cancel_order(String symbol, String order_id)
        {
            String result = "";
            try
            {
                Dictionary<String, String> paras = new Dictionary<String, String>();
                paras.Add("api_key", api_key);
                if (!StringUtil.isEmpty(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!StringUtil.isEmpty(order_id))
                {
                    paras.Add("order_id", order_id);
                }

                String sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);

                HttpUtilManager httpUtil = HttpUtilManager.getInstance();
                result = httpUtil.requestHttpPost(url_prex, CANCEL_ORDER_URL,
                       paras);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        public String order_info(String symbol, String order_id)
        {
            String result = "";
            try
            { 
                Dictionary<String, String> paras = new Dictionary<String, String>();
                paras.Add("api_key", api_key);
                if (!StringUtil.isEmpty(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!StringUtil.isEmpty(order_id))
                {
                    paras.Add("order_id", order_id);
                }

                String sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);

                
                HttpUtilManager httpUtil = HttpUtilManager.getInstance();
                result = httpUtil.requestHttpPost(url_prex, ORDER_INFO_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        public String orders_info(String type, String symbol,
                String order_id)
        {
            String result = "";
            try
            {
                
                Dictionary<String, String> paras = new Dictionary<String, String>();
                paras.Add("api_key", api_key);
                if (!StringUtil.isEmpty(type))
                {
                    paras.Add("type", type);
                }
                if (!StringUtil.isEmpty(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!StringUtil.isEmpty(order_id))
                {
                    paras.Add("order_id", order_id);
                }

                String sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);

                
                HttpUtilManager httpUtil = HttpUtilManager.getInstance();
                result = httpUtil.requestHttpPost(url_prex, ORDERS_INFO_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        public String order_history(String symbol, String status,
                String current_page, String page_length)
        {
            String result = "";
            try
            {
                
                Dictionary<String, String> paras = new Dictionary<String, String>();
                paras.Add("api_key", api_key);
                if (!StringUtil.isEmpty(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!StringUtil.isEmpty(status))
                {
                    paras.Add("status", status);
                }
                if (!StringUtil.isEmpty(current_page))
                {
                    paras.Add("current_page", current_page);
                }
                if (!StringUtil.isEmpty(page_length))
                {
                    paras.Add("page_length", page_length);
                }

                String sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);

                
                HttpUtilManager httpUtil = HttpUtilManager.getInstance();
                result = httpUtil.requestHttpPost(url_prex, ORDER_HISTORY_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
        
        public String withdraw(String symbol, String chargefee, String trade_pwd, String withdraw_address, String withdraw_amount)
        {
            String result = "";
            try
            {
                Dictionary<String, String> paras = new Dictionary<String, String>();
                paras.Add("api_key", api_key);
                if (!StringUtil.isEmpty(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!StringUtil.isEmpty(chargefee))
                {
                    paras.Add("chargefee", chargefee);
                }
                if (!StringUtil.isEmpty(trade_pwd))
                {
                    paras.Add("trade_pwd", trade_pwd);
                }
                if (!StringUtil.isEmpty(withdraw_address))
                {
                    paras.Add("withdraw_address", withdraw_address);
                }
                if (!StringUtil.isEmpty(withdraw_amount))
                {
                    paras.Add("withdraw_amount", withdraw_amount);
                }
                String sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);

                
                HttpUtilManager httpUtil = HttpUtilManager.getInstance();
                result = httpUtil.requestHttpPost(url_prex, WITHDRAW_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        
        public String cancel_withdraw(String symbol, String withdraw_id)
        {
            String result = "";
            try
            {
                HttpUtilManager httpUtil = HttpUtilManager.getInstance();
                Dictionary<String, String> paras = new Dictionary<String, String>();
                paras.Add("api_key", api_key);
                if (!StringUtil.isEmpty(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!StringUtil.isEmpty(withdraw_id))
                {
                    paras.Add("withdraw_id", withdraw_id);
                }
                String sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);
                
                result = httpUtil.requestHttpPost(url_prex, CANCEL_WITHDRAW_RUL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        
        public String order_fee(String order_id, String symbol)
        {
            String result = "";
            try
            {
                HttpUtilManager httpUtil = HttpUtilManager.getInstance();
                Dictionary<String, String> paras = new Dictionary<String, String>();
                paras.Add("api_key", api_key);
                if (!StringUtil.isEmpty(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!StringUtil.isEmpty(order_id))
                {
                    paras.Add("order_id", order_id);
                }
                String sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);
                
                result = httpUtil.requestHttpPost(url_prex, ORDER_FEE_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        
        public String lend_depth(String symbol)
        {
            String result = "";
            try
            {
                HttpUtilManager httpUtil = HttpUtilManager.getInstance();
                Dictionary<String, String> paras = new Dictionary<String, String>();
                paras.Add("api_key", api_key);
                if (!StringUtil.isEmpty(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                String sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);
                
                result = httpUtil.requestHttpPost(url_prex, LEND_DEPTH_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        
        public String borrows_info(String symbol)
        {
            String result = "";
            try
            {
                HttpUtilManager httpUtil = HttpUtilManager.getInstance();
                Dictionary<String, String> paras = new Dictionary<String, String>();
                paras.Add("api_key", api_key);
                if (!StringUtil.isEmpty(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                String sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);
                
                result = httpUtil.requestHttpPost(url_prex, BORROWS_INFO_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        
        public String borrow_money(String symbol, String days, String amount, String rate)
        {
            String result = "";
            try
            {
                HttpUtilManager httpUtil = HttpUtilManager.getInstance();
                Dictionary<String, String> paras = new Dictionary<String, String>();
                paras.Add("api_key", api_key);
                if (!StringUtil.isEmpty(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!StringUtil.isEmpty(days))
                {
                    paras.Add("days", days);
                }
                if (!StringUtil.isEmpty(amount))
                {
                    paras.Add("amount", amount);
                }
                if (!StringUtil.isEmpty(rate))
                {
                    paras.Add("rate", rate);
                }
                String sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);
                
                result = httpUtil.requestHttpPost(url_prex, BORROW_MONEY_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        
        public String cancel_borrow(String symbol, String borrow_id)
        {
            String result = "";
            try
            {
                HttpUtilManager httpUtil = HttpUtilManager.getInstance();
                Dictionary<String, String> paras = new Dictionary<String, String>();
                paras.Add("api_key", api_key);
                if (!StringUtil.isEmpty(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!StringUtil.isEmpty(borrow_id))
                {
                    paras.Add("borrow_id", borrow_id);
                }
                String sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);
                
                result = httpUtil.requestHttpPost(url_prex, CANCEL_BORROW_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        
        public String borrow_order_info(String borrow_id)
        {
            String result = "";
            try
            {
                HttpUtilManager httpUtil = HttpUtilManager.getInstance();
                Dictionary<String, String> paras = new Dictionary<String, String>();
                paras.Add("api_key", api_key);
                if (!StringUtil.isEmpty(borrow_id))
                {
                    paras.Add("borrow_id", borrow_id);
                }
                String sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);
                
                result = httpUtil.requestHttpPost(url_prex, BORROW_ORDER_INFO,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        
        public String repayment(String borrow_id)
        {
            String result = "";
            try
            {
                HttpUtilManager httpUtil = HttpUtilManager.getInstance();
                Dictionary<String, String> paras = new Dictionary<String, String>();
                paras.Add("api_key", api_key);
                if (!StringUtil.isEmpty(borrow_id))
                {
                    paras.Add("borrow_id", borrow_id);
                }
                String sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);
                
                result = httpUtil.requestHttpPost(url_prex, REPAYMENT_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        
        public String unrepayments_info(String symbol, String current_page, String page_length)
        {
            String result = "";
            try
            {
                HttpUtilManager httpUtil = HttpUtilManager.getInstance();
                Dictionary<String, String> paras = new Dictionary<String, String>();
                paras.Add("api_key", api_key);
                if (!StringUtil.isEmpty(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!StringUtil.isEmpty(current_page))
                {
                    paras.Add("current_page", current_page);
                }
                if (!StringUtil.isEmpty(page_length))
                {
                    paras.Add("page_length", page_length);
                }
                String sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);
                
                result = httpUtil.requestHttpPost(url_prex, UNREPAYMENTS_INFO_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        
        public String account_records(String symbol, String type, String current_page, String page_length)
        {
            String result = "";
            try
            {
                HttpUtilManager httpUtil = HttpUtilManager.getInstance();
                Dictionary<String, String> paras = new Dictionary<String, String>();
                paras.Add("api_key", api_key);
                if (!StringUtil.isEmpty(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!StringUtil.isEmpty(type))
                {
                    paras.Add("type", type);
                }
                if (!StringUtil.isEmpty(current_page))
                {
                    paras.Add("current_page", current_page);
                }
                if (!StringUtil.isEmpty(page_length))
                {
                    paras.Add("page_length", page_length);
                }
                String sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);
                
                result = httpUtil.requestHttpPost(url_prex, ACCOUNT_RECORDS_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        
        public String trade_history(String symbol, String since)
        {
            String result = "";
            try
            {
                HttpUtilManager httpUtil = HttpUtilManager.getInstance();
                Dictionary<String, String> paras = new Dictionary<String, String>();
                paras.Add("api_key", api_key);
                if (!StringUtil.isEmpty(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!StringUtil.isEmpty(since))
                {
                    paras.Add("since", since);
                }
                String sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);
                
                result = httpUtil.requestHttpPost(url_prex, TRADE_HISTORY_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
    }
}
