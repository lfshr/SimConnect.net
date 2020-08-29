using System;
using System.Collections.Generic;
using System.Text;
using SimConnectNet;
using SimConnectNet.Mapping;
using SimConnectNet.Models;

namespace SimConnect.net.Console.Models
{
[SimQueryType(SimConnectType.Aircraft)]
public class Aircraft : SimDataQuery
{
    [SimQueryVariable(SimVariable.PlaneLatitude, UnitOfMeasurement.Degrees)]
    public double Latitude { get; set; }
}
}
