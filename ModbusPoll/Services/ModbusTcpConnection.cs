using ModbusPoll.Interfaces;
using NModbus;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System;

public class ModbusTcpConnection : IModbusConnection
{
    private TcpClient _tcpClient;
    private IModbusMaster _modbusMaster;
    private byte _slaveId;
    private System.Timers.Timer _connectionTimer;
    private string _ipAddress;
    private int _port;

    public ModbusTcpConnection()
    {
        // 타이머 설정: 2초 간격으로 연결 상태 확인
        _connectionTimer = new System.Timers.Timer(2000);
        _connectionTimer.Elapsed += CheckConnectionStatus;
        _connectionTimer.AutoReset = true;
    }

    public void Connect(string ipAddress, int port, int slaveId)
    {
        try
        {
            _tcpClient = new TcpClient(ipAddress, port);
            _ipAddress = ipAddress;
            _port = port;
            _slaveId = (byte)slaveId;
            var factory = new ModbusFactory();
            _modbusMaster = factory.CreateMaster(_tcpClient);

            // 연결 성공 후 타이머 시작
            _connectionTimer.Start();
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
            _modbusMaster.Dispose();
            Console.WriteLine("Disconnected from Modbus Slave.");
            _connectionTimer.Stop();
        }
    }

    // 실시간 연결 상태 확인
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

    private async void CheckConnectionStatus(object sender, ElapsedEventArgs e)
    {
        try
        {
            if (!await IsMasterConnectedAsync())
            {
                Console.WriteLine("Connection lost. Attempting to reconnect...");
                _connectionTimer.Stop();
                //await AttemptReconnectAsync();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during connection check: {ex.Message}");
        }
    }



    // Async 방식으로 연결 상태 확인
    private async Task<bool> IsMasterConnectedAsync()
    {
        try
        {
            // ReadHoldingRegisters 명령을 보내 연결 상태 확인
            ushort startAddress = 0;
            ushort quantity = 1;
            await _modbusMaster.ReadHoldingRegistersAsync(_slaveId, startAddress, quantity);
            return true; // 정상적으로 연결이 되었다면 true 반환
        }
        catch (Exception)
        {
            return false; // 연결 끊김, 예외 발생 시 false 반환
        }
    }

    private async Task AttemptReconnectAsync()
    {
        while (true)
        {
            try
            {
                Connect(_ipAddress, _port, _slaveId); // 실제 IP 및 포트 사용
                _connectionTimer.Start(); // 재연결 성공 시 타이머 재시작
                break;
            }
            catch
            {
                await Task.Delay(3000); // 재연결 대기 시간 설정
            }
        }
    }

    public async Task<ushort[]> ReadHoldingRegistersAsync(ushort startAddress, ushort quantity)
    {
        if (_modbusMaster == null)
        {
            MessageBox.Show("No Connection. Please connect first");
            return null;
        }
        return await _modbusMaster.ReadHoldingRegistersAsync(_slaveId, startAddress, quantity);
    }

    public async Task WriteHoldingRegistersAsync(ushort startAddress, ushort[] values)
    {
        if (_modbusMaster == null)
        {
            MessageBox.Show("No Connection. Please connect first");
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
            throw;
        }
    }
}
