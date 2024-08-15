using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semantic_Kernel_CoreSkills
{
    public class Settings
    {
        public static (string apiKey, string? orgId) LoadFromSecrets()
        {
            IConfiguration config = new ConfigurationBuilder()
                       .AddUserSecrets<Settings>()
                       .Build();

            try
            {

                string? apiKey = string.IsNullOrEmpty(config["apiKey"]) ? null : config["apiKey"];
                string? orgId = config["orgId"] ?? null;
                return (apiKey, orgId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
                return ("", "");
            }
        }
    }
}
