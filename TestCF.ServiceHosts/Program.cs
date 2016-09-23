using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCF.Contracts;
using System.ServiceModel;
using System.Runtime.Serialization;
using TestCF.Services;

namespace TestCF.ServiceHosts
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost sh = new ServiceHost(typeof(Serv1)))
            {
                sh.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.ReadLine();
                sh.Close();
            }
        }
    }
}
