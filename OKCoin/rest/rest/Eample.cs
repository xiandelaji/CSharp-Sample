using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.okcoin.rest.future;
using com.okcoin.rest.stock;
using System.IO;
namespace com.okcoin.rest
{
    class Client
    {
        static void Main(String[] args)
        {
            String api_key = "5951da08-4683-474e-a933-c9da9b4c2fdc";  //OKCoin申请的apiKey
            String secret_key = "78220807050D1AB44AB6A552BAC35C8A";  //OKCoin申请的secretKey
            String url_prex = "https://www.okcoin.cn"; //国内站账号配置 为 https://www.okcoin.cn
            //StreamWriter sw = new StreamWriter("C:\\Max\\Coin\\log\\okcoin.log");
            
            //期货操作
            //FutureRestApiV1 getRequest = new FutureRestApiV1(url_prex);
            //FutureRestApiV1 postRequest = new FutureRestApiV1(url_prex, api_key, secret_key);
            //期货行情信息
            //Console.WriteLine(getRequest.future_ticker("btc_cny", "this_week"));
            //期货深度信息
            //Console.WriteLine(getRequest.future_depth("btc_cny", "this_week"));
            //期货交易记录信息
            //Console.WriteLine(getRequest.future_trades("btc_cny","this_week"));
            //期货指数信息
            //Console.WriteLine(getRequest.future_index("btc_cny"));
            // 获取美元人民币汇率
            //Console.WriteLine(getRequest.exchange_rate());
            //获取交割预估价
            //Console.WriteLine(getRequest.future_estimated_price("btc_cny"));
            // 获取期货合约的K线数据
            //Console.WriteLine(getRequest.future_kline("btc_cny", "1min", "this_week", "1", "1417536000000"));
            //获取当前可用合约总持仓量
            //Console.WriteLine(getRequest.future_hold_amount("btc_cny","this_week"));
            // 获取期货账户信息 （全仓）
            //Console.WriteLine(postRequest.future_userinfo());
            // 获取用户持仓获取OKCoin期货账户信息 （全仓）
            //Console.WriteLine(postRequest.future_position("btc_cny","this_week"));
            //期货下单(862413180)
            //Console.WriteLine(postRequest.future_trade("btc_cny", "this_week", "1", "1", "1", "0"));
            //获取期货交易历史
            //Console.WriteLine(postRequest.future_trades_history("btc_cny", "2015-09-02", "1"));
            //批量下单(返回两个order_id(862492945,862492949)
            //Console.WriteLine(postRequest.future_batch_trade("btc_cny", "this_week", "[{price:1,amount:1,type:1,match_price:1},{price:1,amount:1,type:1,match_price:1}]", "10"));
            // 取消期货订单
            //Console.WriteLine(postRequest.future_cancel("btc_cny", "this_week", "order_id"));
            //获取期货订单信息
            //Console.WriteLine(postRequest.future_order_info("btc_cny", "this_week", "862413180", "2", "1", "2"));
            //批量获取期货订单信息
            // Console.WriteLine(postRequest.future_orders_info("btc_cny", "this_week", "order_id"));
            //获取逐仓期货账户信息
            //Console.WriteLine(postRequest.future_userinfo_4fix());
            // 逐仓用户持仓查询
            //Console.WriteLine(postRequest.future_position_4fix("btc_cny","this_week"));
            // 获取期货爆仓单
            //Console.WriteLine(postRequest.future_explosive("btc_cny","this_week","1","1","2"));



            //现货操作
            StockRestApi getRequest1 = new StockRestApi(url_prex);
            StockRestApi postRequest1 = new StockRestApi(url_prex, api_key, secret_key);

            //获取现货行情
            //Console.WriteLine(getRequest1.ticker("btc_cny"));
            //获取现货市场深度
            //Console.WriteLine(getRequest1.depth("btc_cny","2"));
            //获取最近600交易信息
            //Console.WriteLine(getRequest1.trades("btc_cny","20"));
            //获取比特币或莱特币的K线数据
            //Console.WriteLine(getRequest1.kline("btc_cny", "1min", "2", "1417536000000"));
            // 获取用户信息
            //Console.WriteLine(postRequest1.userinfo());

            //下单交易(order_id":32490296)
            //Console.WriteLine(postRequest1.trade("btc_cny","buy","0.01","0.01"));
            // 获取历史交易信息
            //Console.WriteLine(postRequest1.trade_history("btc_cny","2"));
            //批量下单
            //Console.WriteLine(postRequest1.batch_trade("btc_cny", "buy", "[{price:0.01,amount:0.01},{price:0.02,amount:0.02},{price:0.03,amount:0.03,type:'buy'}]"));
            //撤销订单
            //Console.WriteLine(postRequest1.cancel_order("btc_cny", "3044724963,3044724958,3044604770"));
            //获取用户的订单信息
            //Console.WriteLine(postRequest1.order_info("btc_cny", "-1"));
            //批量获取用户订单
            //Console.WriteLine(postRequest1.orders_info("0", "btc_cny", "3044741807,3044741797,3044741790,3044604770"));
            //获取历史订单信息，只返回最近七天的信息
            //Console.WriteLine(postRequest1.order_history("btc_cny","0","1","10"));
            
            //sw.WriteLine(postRequest1.order_history("btc_cny", "0", "1", "10"));

            // 提币BTC/LTC
            //Console.WriteLine(postRequest1.withdraw("btc_cny", "0.001", "trade_pwd", "withdraw_address", "withdraw_amount "));
            // 取消提币BTC/LTC
            //Console.WriteLine(postRequest1.cancel_withdraw("btc_cny", "withdraw_id"));
            //查询手续费
            //Console.WriteLine(postRequest1.order_fee("order_id","btc_cny"));
            //获取放款深度前10
            //Console.WriteLine(postRequest1.lend_depth("btc_cny"));
            // 查询用户借款信息
            //Console.WriteLine(postRequest1.borrows_info("btc_cny"));
            //申请借款(borrow_id":22789)
            //Console.WriteLine(postRequest1.borrow_money("btc_cny","three","1","0.001"));
            //取消借款申请
            //Console.WriteLine(postRequest1.cancel_borrow("btc_cny", "22789"));
            //获取借款订单记录
            //Console.WriteLine(postRequest1.borrow_order_info("22789"));
            //用户还全款
            //Console.WriteLine(postRequest1.repayment("22789"));
            // 未还款列表
            //Console.WriteLine(postRequest1.unrepayments_info("btc_cny", "1", "2"));
            //获取用户提现/充值记录
            //Console.WriteLine(postRequest1.account_records("btc_cny","1","1","2"));
            
            //sw.Flush();
            //sw.Close();

            Console.ReadLine();
        }
    }
}
