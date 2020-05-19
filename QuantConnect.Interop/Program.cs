using ProtoBuf;
using ProtoBuf.Meta;
using QuantConnect.Algorithm;
using QuantConnect.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantConnect.Interop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var algo = new QCAlgorithm();
            var ms = new MemoryStream();

            var suggestion = (Serializer.GetProto<List<BaseData>>(ProtoSyntax.Proto3));
            File.WriteAllText("qc.proto", suggestion);

            Console.WriteLine(suggestion);
        }
    }
}
