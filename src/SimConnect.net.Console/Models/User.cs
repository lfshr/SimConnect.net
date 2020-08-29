using System;
using System.Collections.Generic;
using System.Text;
using SimConnectNet;
using SimConnectNet.Mapping;
using SimConnectNet.Models;

namespace SimConnect.net.Console.Models
{
    [SimQueryType(SimConnectType.User)]
    public class User : SimDataQuery
    {
        [SimQueryVariable(SimVariable.AdfName, UnitOfMeasurement.String)]
        public string Name { get; set; }
    }
}
