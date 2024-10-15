using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusPoll.Interfaces
{
    public interface IModbusConnection
    {
        void Connect(string ipAddress, int port);
        void Disconnect();
        bool IsConnected { get; }
    }
}
