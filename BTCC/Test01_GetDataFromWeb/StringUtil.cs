using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GetBTCData
{
    class StringUtil
    {
        public static string getValue(String str, String key, String separator, String replace1, String replace2)
        {
            String value = "";
            String[] s;
            s = Regex.Split(str, key, RegexOptions.IgnoreCase);
            if (s.Length > 1)
            {
                s = Regex.Split(s[1], separator);
                if (s.Length > 0)
                {
                    value = s[0].Replace(replace1, "").Replace(replace2, "");
                }
            }
            return value;
        }
    }
}
