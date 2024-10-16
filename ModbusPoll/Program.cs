using ModbusPoll.Interfaces;
using ModbusPoll.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusPoll
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Modbus TCP 연결 클래스 인스턴스 생성
            IModbusConnection modbusConnection = new ModbusTcpConnection();
            // DataViewService 인스턴스 생성
            IDataViewService dataViewService = new DataViewService();
            // ContextMenuService 인스턴스 생성
            IContextMenuService contextMenuService = new ContextMenuService();  

            // 연결 클래스 인스턴스를 Form1에 주입
            Form1 form1 = new Form1(modbusConnection,dataViewService, contextMenuService);

            Application.Run(form1);
        }
    }
}
