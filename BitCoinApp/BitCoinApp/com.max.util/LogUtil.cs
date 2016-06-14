using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCoinApp.com.max.util
{
    class LogUtil
    {
        public static log4net.ILog getLog()
        {
            log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            return log;
        }
    }
}
