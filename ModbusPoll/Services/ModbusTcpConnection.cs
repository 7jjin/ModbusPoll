using ModbusPoll.Interfaces;
using NModbus;
using NModbus.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ModbusPoll.Services
{
    public class ModbusTcpConnection : IModbusConnection
    {
        private TcpClient _tcpClient;
        private IModbusMaster _modbusMaster;
        public bool IsConnected => _tcpClient != null && _tcpClient.Connected;
        
        
        public void Connect(string ipAddress, int port)
        {
            try
            {
                _tcpClient = new TcpClient(ipAddress, port);
                var factory = new ModbusFactory();
                _modbusMaster = factory.CreateMaster(_tcpClient);
                Console.WriteLine("Successfully connected to the Modbus Slave.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to connect: {ex.Message}");
                throw;
            }
        }

        public void Disconnect()
        {
            if (_tcpClient != null)
            {
                _tcpClient.Close();
                _tcpClient = null;
                Console.WriteLine("Disconnected from Modbus Slave.");
            }
        }

        public async Task<ushort[]> ReadHoldingRegistersAsync(ushort startAddress, ushort quantity)
        {
            if (_modbusMaster == null)
            {
                throw new InvalidOperationException("ModbusMaster is not connected.");
            }
            return await _modbusMaster.ReadHoldingRegistersAsync(1,startAddress, quantity);
        }

        public async Task WriteHoldingRegistersAsync(ushort startAddress, ushort[] values)
        {
            if (_modbusMaster == null)
            {
                throw new InvalidOperationException("ModbusMaster is not connected.");
            }
            try
            {
                await _modbusMaster.WriteMultipleRegistersAsync(1, startAddress, values);
                Console.WriteLine("Successfully wrote data to the Modbus Slave.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write data: {ex.Message}");
                throw;
            }
        }
    }
}
