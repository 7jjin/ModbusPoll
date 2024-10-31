using ModbusPoll.Interfaces;
using ModbusPoll.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusPoll
{
    public partial class ConnectionForm : Form
    {
        private ModbusConnectionSettings _settings;
        private IModbusConnection _modbusConnection;
        public ConnectionForm(IModbusConnection modbusConnection)
        {
            InitializeComponent();
            _modbusConnection = modbusConnection;
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            string ipAddress = txt_IpAddress.Text;
            int port = int.Parse(txt_Port.Text);
            int slaveId = int.Parse(txt_SlaveId.Text);
            _settings = new ModbusConnectionSettings(ipAddress, port, slaveId);
            try
            {
                _modbusConnection.Connect(_settings.IpAddress, _settings.Port, _settings.SlaveId);
                MessageBox.Show("Connected to Modbus Slave");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection failed : {ex.Message}");
            }
        }

        private void ConnectionForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 창 닫는 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
