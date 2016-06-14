using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCoinApp.com.max.test
{
    class TestConfig
    {
        public static void Main(string[] args)
        {
            string value = ConfigurationManager.AppSettings["TestSetting"];
            Console.WriteLine(value);
            
            /*string username;
            string password;
            
            string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string configFile = System.IO.Path.Combine(appPath, "Initial.config");
            Console.WriteLine("appPath=" + appPath);

            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = configFile;
            System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            username = ConfigurationManager.AppSettings["username"];
            password = ConfigurationManager.AppSettings["password"];

            Console.WriteLine("username=" + username);
            Console.WriteLine("password=" + password);

            config.AppSettings.Settings["username"].Value = "linux";
            config.AppSettings.Settings["password"].Value = "passw0rd";
            config.Save();

            username = ConfigurationManager.AppSettings["username"];
            password = ConfigurationManager.AppSettings["password"];

            Console.WriteLine("username=" + username);
            Console.WriteLine("password=" + password);
            */
            Console.ReadLine();
        }
    }
}
