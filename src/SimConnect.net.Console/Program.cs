using System;
using System.Threading.Tasks;
using SimConnect.net.Console.Models;
using SimConnectNet;
using SimConnectNet.Models;

namespace SimConnect.net.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var connection = new SimConnectConnection("Test");
            await connection.ConnectAsync();

            var user = connection.GetUser<User>();
        }
    }
}
