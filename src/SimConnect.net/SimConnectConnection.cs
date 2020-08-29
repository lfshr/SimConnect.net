using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.FlightSimulator.SimConnect;
using SimConnectNet.Exceptions;
using SimConnectNet.Mapping;
using SimConnectNet.Models;

namespace SimConnectNet
{

    public enum SimConnectMessageType
    {
        Null,
        Exception,
        Open,
        Quit,
        Event,
        EventObjectAddRemove,
        EventFilename,
        EventFrame,
        EventSimObjectData,
        SimObjectData,
        SimObjectDataByType,
        WeatherObservation,
        CloudState,
        AssignedObjectId,
        ReservedKey,
        CustomAction,
        SystemState,
        ClientData,
        EventWeatherMode,
        AirportList,
        VorList,
        NdbList,
        WaypointList,
        MultiplayerServerStarted,
        MultiplayerClientStarted,
        MultiplayerSessionEnded,
        EventRaceEnd,
        EventRaceLap
    }

    public class SimConnectConnection
    {
        SimConnect _simConnect;

        private Thread _tickThread;
        private readonly string _name;
        private bool _isConnected = false;
        private bool _quitRequested = false;

        public SimConnectConnection(string name)
        {
            _name = name;
            _tickThread = new Thread(TickThread);
            _tickThread.IsBackground = true;
        }

        private void TickThread()
        {
            while (!_quitRequested)
            {
                if (_simConnect != null)
                {
                    _simConnect.ReceiveDispatch(SimConnect_ReceiveDispatch);
                    Thread.Sleep(1);
                }
            }
        }

        public async Task ConnectAsync()
        {
            if (_simConnect != null)
            {
                return;
            }

            try
            {
                _simConnect = new SimConnect(_name, IntPtr.Zero, 0x0402, null, 0);
            }
            catch (COMException exception)
            {
                throw new ConnectionFailureException("Failed to connect to Microsoft Flight Simulator. COM Error", exception);
            }

            _tickThread.Start();

            while (!_isConnected)
            {
                await Task.Delay(1);
            }
        }

        private void SimConnect_ReceiveDispatch(SIMCONNECT_RECV pdata, uint cbdata)
        {
            var messageType = (SimConnectMessageType) pdata.dwID;

            if (messageType == SimConnectMessageType.Open)
            {
                _isConnected = true;
            }
        }

        public T GetUser<T>()
            where T : SimObject, new()
        {
            var classAttribute = typeof(T).GetCustomAttribute<SimObjectTypeAttribute>();
            if (classAttribute == null || classAttribute.SimConnectType != SimConnectType.User)
            {
                throw new InvalidOperationException(
                    "Class specified in GetUser must contain a SimObjectTypeAttribute, and be of type SimConnectType.User!");
            }

            return GetObject<T>(1);
        }

        public T GetObject<T>(int objectId)
            where T : SimObject, new()
        {
            var obj = new T();
            obj.Initialize(_simConnect, objectId);
            return obj;
        }
    }
}
