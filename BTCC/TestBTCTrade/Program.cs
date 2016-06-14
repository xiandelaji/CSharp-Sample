using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBTCTrade
{
    public class Program
    {
    }

    /*
    public function balance()
	{
		return $this->_request('balance');
	}
    */

    /*
    private function _request($path, $params = array()){
		static $ch = null;
		if(is_null($ch)){
			$ch = curl_init();
			curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
			curl_setopt($ch, CURLOPT_USERAGENT, 'Mozilla/4.0 (compatible; BtcTrade PHP client; ' . php_uname('s') . '; PHP/' . phpversion() . ')');
		}
		# 唯一的数字
		$mt = explode(' ', microtime());
		$params['nonce'] = $mt[1] . substr($mt[0], 2, 3);
		$params['version'] = 2;
		$params['key'] = self::ACCESS_KEY;
		$params['signature'] = hash_hmac('sha256', http_build_query($params, '', '&'), md5(self::SECRET_KEY));
		# 参数设定
		curl_setopt($ch, CURLOPT_POSTFIELDS, http_build_query($params, '', '&'));
		curl_setopt($ch, CURLOPT_URL, 'http://api.btctrade.com/api/' . $path);
		curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, false);
		return json_decode(curl_exec($ch), true);
	}
    */
}
