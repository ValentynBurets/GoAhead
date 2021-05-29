using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace girl_go_ahead.patterns
{
    //thread safety singleton
    public class Singleton
    {
        private Singleton() { }

        private static Singleton _instance;

        private static readonly object threadlock = new object();

        public static Singleton GetInstance()
        {
            lock (threadlock)
            {
                if (_instance == null)
                {                    
                    _instance = new Singleton();
                }
                    return _instance;
                }
        }
        public static void Log(string message)
        {
            string time = " curent time is: " +  DateTime.Now.ToString("h:mm:ss tt");
            message += time;
            File.AppendAllText("log.txt", message);
        }
    }

    //lazy loading
    public sealed class lazy_Singleton
    {
        private lazy_Singleton() { }

        private static readonly Lazy<lazy_Singleton> lazy =
            new Lazy<lazy_Singleton>(() => new lazy_Singleton());

        public static lazy_Singleton Source { 
            get
            {
                return lazy.Value; 
            } 
        }

        public static void Log(string message)
        {
            string time = " curent time is: " + DateTime.Now.ToString("h:mm:ss tt");
            message += time;
            message += "\n";
            File.AppendAllText("log.txt", message);
        }
    }

}
