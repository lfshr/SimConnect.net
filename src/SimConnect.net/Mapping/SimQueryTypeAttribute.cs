using System;
using System.Collections.Generic;
using System.Text;

namespace SimConnectNet.Mapping
{
    public enum SimConnectType
    {
        User,
        All,
        Aircraft,
        Helicopter,
        Boat,
        Ground
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class SimQueryTypeAttribute : Attribute
    {
        public SimConnectType SimConnectType { get; }

        public SimQueryTypeAttribute(SimConnectType simConnectType)
        {
            SimConnectType = simConnectType;
        }
    }
}
