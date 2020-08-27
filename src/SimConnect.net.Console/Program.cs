using System;
using System.Threading.Tasks;
using SimConnectNet;

namespace SimConnect.net.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var connection = new SimConnectConnection("Test");
            await connection.ConnectAsync();
        }
    }
}
