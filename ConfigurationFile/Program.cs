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
            builder.AddJsonFile("appsettings.json");
            builder.AddIniFile("appsettings.ini");
            var root = builder.Build();
            Console.WriteLine($"kini:{root["keyini"]}");
            Console.WriteLine($"kjs1:{root["kjs1"]}");
            IChangeToken changeToken = root.GetReloadToken();

            ChangeToken.OnChange(()=>root.GetReloadToken(),()=>
            {
                Console.WriteLine($"restart");
                Console.WriteLine($"kjs1:{root["kjs1"]}");
            });
                

            Console.WriteLine($"start");
            Console.WriteLine($"kjs1:{root["kjs1"]}");

            Console.ReadKey();

            Console.WriteLine($"restart");
            Console.WriteLine($"kjs1:{root["kjs1"]}");

        }
    }
}
