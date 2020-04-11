using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace ConfigurationFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional:true, reloadOnChange:true);
            //builder.AddIniFile("appsettings.ini");
            var root = builder.Build();
            var config = new Config();
            root.Bind( config);
            Console.WriteLine(config.Key6);
            IChangeToken changeToken = root.GetReloadToken();
            _= ChangeToken.OnChange(() => root.GetReloadToken(),
                () => { Console.WriteLine($"kjs1:{root["kjs1"]}"); });
            
            Console.ReadKey();
            Console.ReadKey();
        }
    }

    class Config
    {
        public string kjs1 { get; set; }

        public bool Key5 { get; set; }
        public int Key6 { get; set; }
    }
}
