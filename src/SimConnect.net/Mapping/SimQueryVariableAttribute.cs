using System;

namespace SimConnectNet.Mapping
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SimQueryVariableAttribute : Attribute
    {
        public SimVariable Variable { get; }
        public UnitOfMeasurement UnitOfMeasurement { get; }

        public SimQueryVariableAttribute(SimVariable variable, UnitOfMeasurement unitOfMeasurement)
        {
            Variable = variable;
            UnitOfMeasurement = unitOfMeasurement;
        }
    }
}
