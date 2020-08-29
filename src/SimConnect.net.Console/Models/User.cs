using System;
using System.Collections.Generic;
using System.Text;
using SimConnectNet;
using SimConnectNet.Mapping;
using SimConnectNet.Models;

namespace SimConnect.net.Console.Models
{
    [SimObjectType(SimConnectType.User)]
    public class User : SimObject
    {
        [SimObjectVariable(SimVariable.AdfName, UnitOfMeasurement.String)]
        public string Name { get; set; }
    }
}
