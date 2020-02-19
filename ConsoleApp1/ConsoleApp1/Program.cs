using System;
using System.Threading.Tasks;
using RingCentral;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            read_user_calllog().Wait();
        }
        static private async Task read_user_calllog()
        {
            RestClient rc = new RestClient("UJnZe75_RPieDcx9PPL3sQ", "JVoBgGEETSSHJvFQ3l7MLA4LCkpdmcTKeuccWkSgqLDA", false);
            await rc.Authorize("+19802691329", "101", "deadpool@1");
            var parameters = new ReadUserCallLogParameters();
            parameters.view = "Detailed";

            var resp = await rc.Restapi().Account().Extension().CallLog().List(parameters);
            foreach (var record in resp.records)
            {
                Console.WriteLine("Call type: " + record.type);
                Console.WriteLine("Call type: " + record.to);
                Console.WriteLine("Call type: " + record.from);
                Console.WriteLine("Call type: " + record.duration );
            }
        }
    }
}
