using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.FlightSimulator.SimConnect;

namespace SimConnectNet.Mapping
{
    public static partial class MappingUtils
    {
        public static SIMCONNECT_DATATYPE GetSimConnectDataTypeMapping(Type type)
        {
            if (type == typeof(int))
                return SIMCONNECT_DATATYPE.INT32;
            if (type == typeof(long))
                return SIMCONNECT_DATATYPE.INT64;
            if (type == typeof(float))
                return SIMCONNECT_DATATYPE.FLOAT32;
            if (type == typeof(double))
                return SIMCONNECT_DATATYPE.FLOAT64;
            if (type == typeof(string))
                return SIMCONNECT_DATATYPE.STRINGV;

            return SIMCONNECT_DATATYPE.INVALID;
        }
    }
}
