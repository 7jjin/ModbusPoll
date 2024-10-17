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
    public partial class Form1 : Form
    {
        private IModbusConnection _modbusConnection;
        private ModbusConnectionSettings _settings;
        private readonly IDataViewService _dataViewService;
        private readonly IContextMenuService _contextMenuService;

        public Form1(IModbusConnection modbusConnection, IDataViewService dataViewService, IContextMenuService contextMenuService)
        {
            InitializeComponent();
            _modbusConnection = modbusConnection;
            _dataViewService = dataViewService;
            _contextMenuService = contextMenuService;

            dataView.MouseDown += DataView_MouseDown;
        }

        /// <summary>
        /// Modbus Tcp 연결
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ipAddress = txt_IpAddress.Text;
            int port = int.Parse(txt_Port.Text);
            _settings = new ModbusConnectionSettings(ipAddress, port);
            try
                {
                _modbusConnection.Connect(_settings.IpAddress, _settings.Port);
                MessageBox.Show("Connected to Modbus Slave");
            }catch(Exception ex) {
                MessageBox.Show($"Connection failed : {ex.Message}");
            }
        }


        /// <summary>
        /// Modbus Tcp 연결 해제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _modbusConnection.Disconnect();
            MessageBox.Show("Disconnected from Modbus Slave");
        }


        /// <summary>
        /// Data Table 구조 생성
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // DataGridView 초기화
            _dataViewService.InitializeDataView(dataView);
            // Data Load
            _dataViewService.LoadData(dataView);

            // 첫 번째 열에 대한 유효성 검사 추가
            _dataViewService.AddKeyPressValidation(dataView);

        }

        private void DataView_MouseDown(object sender, MouseEventArgs e)
        {
            _contextMenuService.ShowContextMenu(dataView, e);
        }


    }
}
