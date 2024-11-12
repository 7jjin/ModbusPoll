using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ModbusPoll.Interfaces
{
    public interface IModbusConnection
    {
         bool IsConnected { get; set; }
         bool IsListened { get; set; }
        string LogMessage { get; set; }
        Task Connect(string ipAddress, int port,int slaveId);
        void Disconnect();
        bool IsSocketConnected();
        Task<ushort[]> ReadHoldingRegistersAsync(ushort startAddress, ushort quantity);
        Task WriteHoldingRegistersAsync(ushort startAddress, ushort[] values);
    }
}
