using System;

namespace SimConnectNet.Mapping
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SimObjectVariableAttribute : Attribute
    {
        public SimVariable Variable { get; }
        public UnitOfMeasurement UnitOfMeasurement { get; }

        public SimObjectVariableAttribute(SimVariable variable, UnitOfMeasurement unitOfMeasurement)
        {
            Variable = variable;
            UnitOfMeasurement = unitOfMeasurement;
        }
    }
}
