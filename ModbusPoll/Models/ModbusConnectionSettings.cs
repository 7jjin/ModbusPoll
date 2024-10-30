using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusPoll.Models
{
    public class ModbusConnectionSettings
    {
        public string IpAddress { get; set; }
        public int Port { get; set; }

        public int SlaveId { get; set; }

        public ModbusConnectionSettings(string ipAddress, int port, int slaveId)
        {
            IpAddress = ipAddress;
            Port = port;
            SlaveId = slaveId;
        }
    }
}
