using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace TestCF.Contracts
{
    [ServiceContract]
    public interface IServ1
    {
        [OperationContract]
        Data GetData(string s);
    }

    [DataContract]
    public class Data
    {
        [DataMember]
        public bool isTrue { get; set; }

        public bool isFalse { get; set; }
    }


}
