using System;
using Microsoft.Extensions.Configuration;

namespace ConfigurationEnviromentVariable
{
    class Program
    {
        static void Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddEnvironmentVariables("pre_");
            var root = configurationBuilder.Build();
            Console.WriteLine($"key1:{root["key1"]}");
        }
    }
}
