using ModbusPoll.Interfaces;
using NModbus;
using System.Net.Sockets;
using System.Threading.Tasks;
using System;
using System.Timers;
using System.Windows.Forms;
using ModbusPoll;

public class ModbusTcpConnection : IModbusConnection
{
    private TcpClient _tcpClient;
    private IModbusMaster _modbusMaster;
    private byte _slaveId;
    private System.Timers.Timer _connectionTimer;



    public ModbusTcpConnection()
    {
        // 타이머 설정: 5초 간격으로 연결 상태 확인
        _connectionTimer = new System.Timers.Timer(2000);
        _connectionTimer.Elapsed += CheckConnectionStatus;
        _connectionTimer.AutoReset = true;
    }



    public void Connect(string ipAddress, int port, int slaveId)
    {
        try
        {
            _tcpClient = new TcpClient(ipAddress, port);
            _slaveId = (byte)slaveId;
            var factory = new ModbusFactory();
            _modbusMaster = factory.CreateMaster(_tcpClient);
            Console.WriteLine("Successfully connected to the Modbus Slave.");

            // 연결 성공 후 타이머 시작
            _connectionTimer.Start();
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

            // 연결 해제 시 타이머 중지
            _connectionTimer.Stop();
        }
    }

    public bool IsSocketConnected()
    {
        try
        {
            if (_tcpClient?.Client != null && _tcpClient.Client.Poll(0, SelectMode.SelectRead) && _tcpClient.Client.Available == 0)
            {
                return false; // 연결 끊김
            }
            return true; // 연결 유지 중
        }
        catch
        {
            return false; // 소켓 상태 확인 불가, 연결 끊김으로 간주
        }
    }

    private void CheckConnectionStatus(object sender, ElapsedEventArgs e)
    {
        if (!IsSocketConnected())
        {
            Console.WriteLine("Connection lost. Attempting to reconnect...");

        }
    }

    public async Task<ushort[]> ReadHoldingRegistersAsync(ushort startAddress, ushort quantity)
    {
        if (_modbusMaster == null)
        {
            throw new InvalidOperationException("ModbusMaster is not connected.");
        }
        return await _modbusMaster.ReadHoldingRegistersAsync(_slaveId, startAddress, quantity);
    }

    public async Task WriteHoldingRegistersAsync(ushort startAddress, ushort[] values)
    {
        if (_modbusMaster == null)
        {
            throw new InvalidOperationException("ModbusMaster is not connected.");
        }
        try
        {
            await _modbusMaster.WriteMultipleRegistersAsync(_slaveId, startAddress, values);
            Console.WriteLine("Successfully wrote data to the Modbus Slave.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to write data: {ex.Message}");
            throw;
        }
    }
}
