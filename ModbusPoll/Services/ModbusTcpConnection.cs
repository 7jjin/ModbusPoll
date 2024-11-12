using ModbusPoll.Interfaces;
using NModbus;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System;
using System.Net;


public class ModbusTcpConnection : IModbusConnection
{
    private TcpClient _tcpClient;
    private IModbusMaster _modbusMaster;
    private byte _slaveId;
    private string _ipAddress;
    private int _port;

    // 연결 및 Listen 상태를 나타내는 속성
    public bool IsConnected { get;  set; }
    public bool IsListened { get;  set; }
    public string LogMessage { get; set; }

    string currentTime = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]");

    public async Task Connect(string ipAddress, int port, int slaveId)
    {
        
        try
        {
            _tcpClient = new TcpClient();
            await _tcpClient.ConnectAsync(ipAddress, port);

            _ipAddress = ipAddress;
            _port = port;
            _slaveId = (byte)slaveId;

            var factory = new ModbusFactory();
            _modbusMaster = factory.CreateMaster(_tcpClient);
            LogMessage = $"{currentTime} connected slaveId - {slaveId} {ipAddress} {port}";
            IsConnected = true;  // 연결 성공 시 상태 업데이트
            Console.WriteLine("Successfully connected to the Modbus Slave.");
        }
        catch (Exception ex)
        {
            IsConnected = false;
            MessageBox.Show($"{currentTime} Slave Connection Failed. {ipAddress}:{port}", "Failed to Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            LogMessage = $"{currentTime} Slave Connection Failed. {ipAddress}:{port}";
            throw;
        }
    }

    public void Disconnect()
    {
        if (_tcpClient != null)
        {
            _modbusMaster?.Dispose();
            _modbusMaster = null;

            _tcpClient?.Close();
            _tcpClient = null;

            IsConnected = false;  // 연결 해제 시 상태 업데이트
            Console.WriteLine("Disconnected from Modbus Slave.");
            LogMessage = $"{currentTime} Disconnected from Modbus Slave.";
        }
    }


    public bool IsSocketConnected()
    {
        if (_tcpClient != null)
        {
            try
            {
                var isConnected = _tcpClient.Client.Poll(0, SelectMode.SelectRead) && _tcpClient.Client.Available == 0;
                if (isConnected)
                {
                    Console.WriteLine("Connection with Modbus Master lost.");
                    return false; // 연결 끊김
                }
                return true; // 연결 유지 중
            }
            catch
            {
                Console.WriteLine("Unable to verify connection with Modbus Master. Assuming disconnection.");
                return false;
            }
        }
        return false;
    }

    private async Task<bool> AttemptReconnectAsync()
    {
        while (true)
        {
            try
            {
                await Connect(_ipAddress, _port, _slaveId);
                return true;
            }
            catch
            {
                await Task.Delay(3000);
            }
        }
    }

    public async Task<ushort[]> ReadHoldingRegistersAsync(ushort startAddress, ushort quantity)
    {
        if (_modbusMaster == null || !IsConnected)
        {
            MessageBox.Show("No Connection. Please connect first");
            return null;
        }

        try
        {
            return await _modbusMaster.ReadHoldingRegistersAsync(_slaveId, startAddress, quantity);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to read data: {ex.Message}");
            return null;
        }
    }

    public async Task WriteHoldingRegistersAsync(ushort startAddress, ushort[] values)
    {
        if (_modbusMaster == null || !IsConnected)
        {
            MessageBox.Show("Modbus 연결이 되어 있지 않습니다. 먼저 연결하세요.");
            return;
        }

        try
        {
            await _modbusMaster.WriteMultipleRegistersAsync(_slaveId, startAddress, values);
            Console.WriteLine("Successfully wrote data to the Modbus Slave.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to write data: {ex.Message}");
        }
    }
}


