using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TestCF.Contracts;
using TestCF.Proxies;
using PFWServiceApplication;

namespace TestCF.Clients
{
    class Client
    {
        static void Main(string[] args)
        {
            IServ1 service = new IServ1Proxy();
            var data = service.GetData("");
            Console.WriteLine(data);

            //string a = System.IO.Path.Combine(Environment.CurrentDirectory, "modules");

            PFWLocationManager lm = new PFWLocationManager(@"C:\Users\rsun\Desktop\test");
            lm.parse();
            Dictionary<string, string> map = lm.getMap();
            
        }
    }
}
