using System.Threading.Tasks;
using NUnit.Framework;
using SimConnectNet;

namespace SimConnect.net.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            var connection = new SimConnectConnection("MyTestConnection");
            await connection.ConnectAsync();
        }
    }
}