using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.FlightSimulator.SimConnect;
using SimConnectNet.Mapping;

namespace SimConnectNet.Models
{
    internal enum DummyEnum
    {
        Dummy
    }

    public class SimDataQuery
    {
        private SimConnect _simConnect;

        private static readonly List<Type> DataDefinitions = new List<Type>();
        private static readonly ConcurrentDictionary<int, Action> RequestCallbacks = new ConcurrentDictionary<int, Action>();

        public int ObjectId { get; private set; }
        public int DefinitionId { get; private set; }
        public bool IsInitialized { get; private set; }


        public async Task AwaitInitAsync()
        {

        }

        internal void Initialize(SimConnect simConnect, int objectId)
        {
            _simConnect = simConnect;
            ObjectId = objectId;
            
            CreateDataDefinition();
        }

        private void CreateDataDefinition()
        {
            var type = GetType();

            int definitionId;
            lock (DataDefinitions)
            {
                if (DataDefinitions.Contains(type))
                {
                    // We've already declared this data definition so return
                    return;
                }

                definitionId = DataDefinitions.Count;
                DataDefinitions.Add(type);
            }

            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.GetCustomAttributes(typeof(SimQueryVariableAttribute)).Any())
                .ToList();

            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<SimQueryVariableAttribute>();
                var datumName = MappingUtils.ConvertSimVariableToSimulationString(attribute.Variable);
                var uom = MappingUtils.ConvertUnitOfMeasurementToSimulationString(attribute.UnitOfMeasurement);
                var simConnectType = MappingUtils.GetSimConnectDataTypeMapping(property.PropertyType);
                _simConnect.AddToDataDefinition((DummyEnum)definitionId, datumName, uom, simConnectType, 0f, 0);
            }
        }

        private void RequestData()
        {
            int requestId;
            lock (RequestCallbacks)
            {
                requestId = RequestCallbacks.Count;

            }
        }
    }
}
