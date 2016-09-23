using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using TestCF.Contracts;

namespace TestCF.Services
{
    public class Serv1 : IServ1
    {
        public Data GetData(string s)
        {
            return new Data();
        }
    }
}
