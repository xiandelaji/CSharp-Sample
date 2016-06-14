<?php
require 'Btctrade.php';

# 实例化
$api = new Api_Btctrade();

# 非常重要：$secret_file所在目录，一定禁止外网用户访问，并且防止被非法分子通过其他途径获取。
# $api->secret_file = 'secret.store.dat';

# 完全公开
# print_r($api->ticker());
# print_r($api->get_depth());
# print_r($api->get_trades());

# 只读权限
print_r($api->get_balance());
# print_r($api->get_wallet());
# print_r($api->get_orders());
# print_r($api->fetch_order(3));

# 完整权限
# print_r($api->cancel_order(1080565));
# print_r($api->add_buy(1.234, 5.67));
# print_r($api->add_sell(1.234, 5.67));