using MySql.Data.MySqlClient;
using QuanLyBanHang.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //Console.OutputEncoding = Encoding.UTF8;

            //Console.WriteLine("Bắt dầu kết nối CSDL Mysql ...");

            //MySqlConnection conn = KetNoi.GetDBConnection();

            //try
            //{

            //    Console.WriteLine("Bắt đầu mở kết nối ...");

            //    conn.Open();

            //    Console.WriteLine("Kết nối thành công !");

            //}

            //catch (Exception e)
            //{

            //    Console.WriteLine("Kết nối thất bại với lỗi sau: " + e.Message);

            //}

            //Console.Read();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
