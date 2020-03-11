using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace AutomationHomeExam
{
    /// <summary>
    /// Help methods to work with appsettings.json configuration file
    /// </summary>
    public class ConfigurationUtility
    {
        /// <summary>
        /// Initialize configuration from appsettings.json configuration file
        /// </summary>
        /// <returns></returns>
        public static IConfiguration InitializeConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();            
        }
    }
}
