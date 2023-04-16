using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing;
using MySqlX.XDevAPI.Relational;

namespace QuanLyBanHang.Class
{
    internal class Functions
    {
        public static MySqlConnection conn;
        public static MySqlConnection Connect()
        {
            string host = "localhost";

            int port = 3306;

            string database = "quanlybanhang";

            string username = "root";

            string password = "1832003";
            String connString = "Server=" + host + ";Database=" + database + ";User=" + username

                + ";Port=" + port + ";Password=" + password + ";SSL Mode = None";

            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            //if (conn.State == ConnectionState.Open)
            //    MessageBox.Show("Kết nối thành công");
            //else MessageBox.Show("Không thể kết nối với dữ liệu");
            return conn;
        }
        public static void Disconnect()
        {
            if (Functions.conn.State == ConnectionState.Open)
            {
                Functions.conn.Close();     //Đóng kết nối
                Functions.conn.Dispose();   //Giải phóng tài nguyên
                Functions.conn = null;
            }
        }
        //Phương thức thực thi câu lệnh select dữ liệu
        public static DataTable GetDataToTableCL(string sql) {
            DataTable table = new DataTable();
            table.Columns.Add("Mã chất liệu", typeof(string));
            table.Columns.Add("Tên chất liệu", typeof(string));
            try
            {
                MySqlCommand command = new MySqlCommand(sql, Functions.Connect());
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string column1Value = reader.GetString(0);
                    string column2Value = reader.GetString(1);
                    DataRow row = table.NewRow();
                    row["Mã chất liệu"] = column1Value;
                    row["Tên chất liệu"] = column2Value;
                    table.Rows.Add(row);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                // Handle the exception here               
                Functions.conn.Close();
            }                                         
            return table;
        }
        public static DataTable GetDataToTableNV(string sql)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã nhân viên", typeof(string));
            table.Columns.Add("Tên nhân viên", typeof(string));
            table.Columns.Add("Giới tính", typeof(string));
            table.Columns.Add("Địa chỉ", typeof(string));
            table.Columns.Add("Điện thoại", typeof(string));
            table.Columns.Add("Ngày sinh", typeof(DateTime));
            try
            {
                MySqlCommand command = new MySqlCommand(sql, Functions.Connect());
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string column1Value = reader.GetString(0);
                    string column2Value = reader.GetString(1);
                    string column3Value = reader.GetString(2);
                    string column4Value = reader.GetString(3);
                    string column5Value = reader.GetString(4);
                    DateTime column6Value = reader.GetDateTime(5);
                    DataRow row = table.NewRow();
                    row["Mã nhân viên"] = column1Value;
                    row["Tên nhân viên"] = column2Value;
                    row["Giới tính"] = column3Value;
                    row["Địa chỉ"] = column4Value;
                    row["Điện thoại"] = column5Value;
                    row["Ngày sinh"] = column6Value;
                    table.Rows.Add(row);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                // Handle the exception here               
                Functions.Disconnect();
            }
            return table;
        }
        public static DataTable GetDataToTableKH(string sql)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã khách", typeof(string));
            table.Columns.Add("Tên khách", typeof(string));
            table.Columns.Add("Địa chỉ", typeof(string));
            table.Columns.Add("Điện thoại", typeof(string));
            try
            {
                MySqlCommand command = new MySqlCommand(sql, Functions.Connect());
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string column1Value = reader.GetString(0);
                    string column2Value = reader.GetString(1);
                    string column3Value = reader.GetString(2);
                    string column4Value = reader.GetString(3);
                    DataRow row = table.NewRow();
                    row["Mã khách"] = column1Value;
                    row["Tên khách"] = column2Value;
                    row["Địa chỉ"] = column3Value;
                    row["Điện thoại"] = column4Value;
                    table.Rows.Add(row);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                // Handle the exception here               
                Functions.conn.Close();
            }
            return table;
        }
        public static DataTable GetDataToTableH(string sql)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã hàng", typeof(string));
            table.Columns.Add("Tên hàng", typeof(string));
            table.Columns.Add("Mã chất liệu", typeof(string));
            table.Columns.Add("Số lượng", typeof(double));
            table.Columns.Add("Đơn giá nhập", typeof(double));
            table.Columns.Add("Đơn giá bán", typeof(double));
            table.Columns.Add("Ảnh", typeof(string));
            table.Columns.Add("Ghi chú", typeof(string));
            try
            {
                MySqlCommand command = new MySqlCommand(sql, Functions.Connect());
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string column1Value = reader.GetString(0);
                    string column2Value = reader.GetString(1);
                    string column3Value = reader.GetString(2);
                    double column4Value = reader.GetDouble(3);
                    double column5Value = reader.GetDouble(4);
                    double column6Value = reader.GetDouble(5);
                    string column7Value = reader.GetString(6);
                    string column8Value = reader.GetString(7);
                    DataRow row = table.NewRow();
                    row["Mã hàng"] = column1Value;
                    row["Tên hàng"] = column2Value; 
                    row["Mã chất liệu"] = column3Value;
                    row["Số lượng"] = column4Value;
                    row["Đơn giá nhập"] = column5Value;
                    row["Đơn giá bán"] = column6Value;
                    row["Ảnh"] = column7Value;
                    row["Ghi chú"] = column8Value;
                    table.Rows.Add(row);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                // Handle the exception here               
                Functions.conn.Close();
            }
            return table;
        }
        public static DataTable GetDataToTableCTHD(string sql)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã hàng", typeof(string));
            table.Columns.Add("Tên hàng", typeof(string));            
            table.Columns.Add("Số lượng", typeof(double));
            table.Columns.Add("Đơn giá", typeof(double));
            table.Columns.Add("Giảm giá", typeof(double));
            table.Columns.Add("Thành tiền", typeof(double));
            try
            {
                MySqlCommand command = new MySqlCommand(sql, Functions.Connect());
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string column1Value = reader.GetString(0);
                    string column2Value = reader.GetString(1);
                    double column3Value = reader.GetDouble(2);
                    double column4Value = reader.GetDouble(3);
                    double column5Value = reader.GetDouble(4);
                    double column6Value = reader.GetDouble(5);                   
                    DataRow row = table.NewRow();
                    row["Mã hàng"] = column1Value;
                    row["Tên hàng"] = column2Value;
                    row["Số lượng"] = column3Value;
                    row["Đơn giá"] = column4Value;
                    row["Giảm giá"] = column5Value;
                    row["Thành tiền"] = column6Value;                    
                    table.Rows.Add(row);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                // Handle the exception here               
                Functions.conn.Close();
            }
            return table;

        }
        public static DataTable GetDataToTableTTHD(string sql)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã HD Bán", typeof(string));
            table.Columns.Add("Ngày Bán", typeof(DateTime));
            table.Columns.Add("Tổng tiền", typeof(double));
            table.Columns.Add("Tên khách", typeof(string));
            table.Columns.Add("Địa chỉ", typeof(string));
            table.Columns.Add("Tên nhân viên", typeof(string));
            try
            {
                MySqlCommand command = new MySqlCommand(sql, Functions.Connect());
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string column1Value = reader.GetString(0);
                    DateTime column2Value = reader.GetDateTime(1);
                    double column3Value = reader.GetDouble(2);
                    string column4Value = reader.GetString(3);
                    string column5Value = reader.GetString(4);
                    string column6Value = reader.GetString(5);
                    DataRow row = table.NewRow();
                    row["Mã HD Bán"] = column1Value;
                    row["Ngày Bán"] = column2Value;
                    row["Tổng tiền"] = column3Value;
                    row["Tên khách"] = column4Value;
                    row["Địa chỉ"] = column5Value;
                    row["Tên nhân viên"] = column6Value;
                    table.Rows.Add(row);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                // Handle the exception here               
                Functions.conn.Close();
            }
            return table;
        }
        public static DataTable GetDataToTableTTMH(string sql)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Tên hàng", typeof(string));
            table.Columns.Add("Số lượng", typeof(double));
            table.Columns.Add("Đơn giá bán", typeof(double));
            table.Columns.Add("Giảm giá", typeof(double));
            table.Columns.Add("Thành tiền", typeof(double));            
            try
            {
                MySqlCommand command = new MySqlCommand(sql, Functions.Connect());
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string column1Value = reader.GetString(0);
                    double column2Value = reader.GetDouble(1);
                    double column3Value = reader.GetDouble(2);
                    double column4Value = reader.GetDouble(3);
                    double column5Value = reader.GetDouble(4);
                    DataRow row = table.NewRow();
                    row["Tên hàng"] = column1Value;
                    row["Số lượng"] = column2Value;
                    row["Đơn giá bán"] = column3Value;
                    row["Giảm giá"] = column4Value;
                    row["Thành tiền"] = column5Value;                   
                    table.Rows.Add(row);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                // Handle the exception here               
                Functions.conn.Close();
            }
            return table;
        }
        //insert update delete
        public static void RunSQL(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, Functions.Connect());
            try
            {
                command.ExecuteNonQuery(); //Thực hiện câu lệnh SQL
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            command.Dispose();//Giải phóng bộ nhớ
            command = null;
        }
        public static bool CheckKeyCL(string sql)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã chất liệu", typeof(string));
            //table.Columns.Add("Tên chất liệu", typeof(string));
            try
            {

                MySqlCommand command = new MySqlCommand(sql, Functions.Connect());
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string column1Value = reader.GetString(0);
                    //string column2Value = reader.GetString(1);
                    DataRow row = table.NewRow();
                    row["Mã chất liệu"] = column1Value;
                    //row["Tên chất liệu"] = column2Value;
                    table.Rows.Add(row);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                // Handle the exception here               
                Functions.Disconnect();
            }
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }
        public static bool CheckKeyNV(string sql)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã nhân viên", typeof(string));
            //table.Columns.Add("Tên nhân viên", typeof(string));
            //table.Columns.Add("Giới tính", typeof(string));
            //table.Columns.Add("Địa chỉ", typeof(string));
            //table.Columns.Add("Điện thoại", typeof(string));
            //table.Columns.Add("Ngày sinh", typeof(DateTime));
            try
            {
                MySqlCommand command = new MySqlCommand(sql, Functions.Connect());
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string column1Value = reader.GetString(0);
                    //string column2Value = reader.GetString(1);
                    //string column3Value = reader.GetString(2);
                    //string column4Value = reader.GetString(3);
                    //string column5Value = reader.GetString(4);
                    //DateTime column6Value = reader.GetDateTime(5);
                    DataRow row = table.NewRow();
                    row["Mã nhân viên"] = column1Value;
                    //row["Tên nhân viên"] = column2Value;
                    //row["Giới tính"] = column3Value;
                    //row["Địa chỉ"] = column4Value;
                    //row["Điện thoại"] = column5Value;
                    //row["Ngày sinh"] = column6Value;
                    table.Rows.Add(row);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                // Handle the exception here               
                Functions.Disconnect();
            }
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }
        public static bool CheckKeyKH(string sql)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã khách", typeof(string));
            //table.Columns.Add("Tên khách", typeof(string));
            //table.Columns.Add("Địa chỉ", typeof(string));
            //table.Columns.Add("Điện thoại", typeof(string));
            try
            {
                MySqlCommand command = new MySqlCommand(sql, Functions.Connect());
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string column1Value = reader.GetString(0);
                    //string column2Value = reader.GetString(1);
                    //string column3Value = reader.GetString(2);
                    //string column4Value = reader.GetString(3);
                    DataRow row = table.NewRow();
                    row["Mã khách"] = column1Value;
                    //row["Tên khách"] = column2Value;
                    //row["Địa chỉ"] = column3Value;
                    //row["Điện thoại"] = column4Value;
                    table.Rows.Add(row);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                // Handle the exception here               
                Functions.conn.Close();
            }
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }
        public static bool CheckKeyH(string sql)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã hàng", typeof(string));
            //table.Columns.Add("Tên hàng", typeof(string));
            //table.Columns.Add("Mã chất liệu", typeof(string));
            //table.Columns.Add("Số lượng", typeof(double));
            //table.Columns.Add("Đơn giá nhập", typeof(double));
            //table.Columns.Add("Đơn giá bán", typeof(double));
            //table.Columns.Add("Ảnh", typeof(string));
            //table.Columns.Add("Ghi chú", typeof(string));
            try
            {
                MySqlCommand command = new MySqlCommand(sql, Functions.Connect());
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string column1Value = reader.GetString(0);
                    //string column2Value = reader.GetString(1);
                    //string column3Value = reader.GetString(2);
                    //double column4Value = reader.GetDouble(3);
                    //double column5Value = reader.GetDouble(4);
                    //double column6Value = reader.GetDouble(5);
                    //string column7Value = reader.GetString(6);
                    //string column8Value = reader.GetString(7);
                    DataRow row = table.NewRow();
                    row["Mã hàng"] = column1Value;
                    //row["Tên hàng"] = column2Value;
                    //row["Mã chất liệu"] = column3Value;
                    //row["Số lượng"] = column4Value;
                    //row["Đơn giá nhập"] = column5Value;
                    //row["Đơn giá bán"] = column6Value;
                    //row["Ảnh"] = column7Value;
                    //row["Ghi chú"] = column8Value;
                    table.Rows.Add(row);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                // Handle the exception here               
                Functions.conn.Close();
            }
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }
        public static bool CheckKeyHDB(string sql)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã HD Bán", typeof(string));
            //table.Columns.Add("Tên hàng", typeof(string));
            //table.Columns.Add("Số lượng", typeof(double));
            //table.Columns.Add("Đơn giá", typeof(double));
            //table.Columns.Add("Giảm giá", typeof(double));
            //table.Columns.Add("Thành tiền", typeof(double));
            try
            {
                MySqlCommand command = new MySqlCommand(sql, Functions.Connect());
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string column1Value = reader.GetString(0);
                    //string column2Value = reader.GetString(1);
                    //double column3Value = reader.GetDouble(2);
                    //double column4Value = reader.GetDouble(3);
                    //double column5Value = reader.GetDouble(4);
                    //double column6Value = reader.GetDouble(5);
                    DataRow row = table.NewRow();
                    row["Mã HD Bán"] = column1Value;
                    //row["Tên hàng"] = column2Value;
                    //row["Số lượng"] = column3Value;
                    //row["Đơn giá"] = column4Value;
                    //row["Giảm giá"] = column5Value;
                    //row["Thành tiền"] = column6Value;
                    table.Rows.Add(row);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                // Handle the exception here               
                Functions.conn.Close();
            }
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }
        public static string ConvertDateTime(string date)
        {
            string[] elements = date.Split('/');
            string dt = string.Format("{0}/{1}/{2}", elements[2], elements[0], elements[1]);
            return dt;
        }
        public static string ConvertReverse(string date)
        {
            string[] elements = date.Split('-');
            string dt = string.Format("{0}/{1}/{2}", elements[2], elements[0], elements[1]);
            return dt;
        }
        public static void FillComboCL(string sql, ComboBox cbo, string ma, string ten)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã chất liệu", typeof(string));
            table.Columns.Add("Tên chất liệu", typeof(string));
            try
            {

                MySqlCommand command = new MySqlCommand(sql, Functions.Connect());
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string column1Value = reader.GetString(0);
                    string column2Value = reader.GetString(1);
                    DataRow row = table.NewRow();
                    row["Mã chất liệu"] = column1Value;
                    row["Tên chất liệu"] = column2Value;
                    table.Rows.Add(row);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                // Handle the exception here               
                Functions.Disconnect();
            }
            cbo.DataSource = table;
            cbo.ValueMember = ma; //Trường giá trị
            cbo.DisplayMember = ten; //Trường hiển thị
        }
        public static void FillComboKhach(string sql, ComboBox cbo, string ma, string ten)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã khách", typeof(string));
            table.Columns.Add("Tên khách", typeof(string));
            try
            {

                MySqlCommand command = new MySqlCommand(sql, Functions.Connect());
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string column1Value = reader.GetString(0);
                    string column2Value = reader.GetString(1);
                    DataRow row = table.NewRow();
                    row["Mã khách"] = column1Value;
                    row["Tên khách"] = column2Value;
                    table.Rows.Add(row);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                // Handle the exception here               
                Functions.Disconnect();
            }
            cbo.DataSource = table;
            cbo.ValueMember = ma; //Trường giá trị
            cbo.DisplayMember = ten; //Trường hiển thị
        }
        public static void FillComboNhanVien(string sql, ComboBox cbo, string ma, string ten)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã nhân viên", typeof(string));
            table.Columns.Add("Tên nhân viên", typeof(string));
            try
            {

                MySqlCommand command = new MySqlCommand(sql, Functions.Connect());
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string column1Value = reader.GetString(0);
                    string column2Value = reader.GetString(1);
                    DataRow row = table.NewRow();
                    row["Mã nhân viên"] = column1Value;
                    row["Tên nhân viên"] = column2Value;
                    table.Rows.Add(row);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                // Handle the exception here               
                Functions.Disconnect();
            }
            cbo.DataSource = table;
            cbo.ValueMember = ma; //Trường giá trị
            cbo.DisplayMember = ten; //Trường hiển thị
        }
        public static void FillComboHang(string sql, ComboBox cbo, string ma, string ten)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã hàng", typeof(string));
            table.Columns.Add("Tên hàng", typeof(string));
            try
            {

                MySqlCommand command = new MySqlCommand(sql, Functions.Connect());
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string column1Value = reader.GetString(0);
                    string column2Value = reader.GetString(1);
                    DataRow row = table.NewRow();
                    row["Mã hàng"] = column1Value;
                    row["Tên hàng"] = column2Value;
                    table.Rows.Add(row);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                // Handle the exception here               
                Functions.Disconnect();
            }
            cbo.DataSource = table;
            cbo.ValueMember = ma; //Trường giá trị
            cbo.DisplayMember = ten; //Trường hiển thị
        }
        public static void FillComboHDB(string sql, ComboBox cbo, string ma, string ten)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã HD Bán", typeof(string));
            //table.Columns.Add("Tên HD Bán", typeof(string));
            try
            {

                MySqlCommand command = new MySqlCommand(sql, Functions.Connect());
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string column1Value = reader.GetString(0);
                    //string column2Value = reader.GetString(1);
                    DataRow row = table.NewRow();
                    row["Mã HD Bán"] = column1Value;
                    //row["Tên HD Bán"] = column2Value;
                    table.Rows.Add(row);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                // Handle the exception here               
                Functions.Disconnect();
            }
            cbo.DataSource = table;
            cbo.ValueMember = ma; //Trường giá trị
            cbo.DisplayMember = ten; //Trường hiển thị
        }

        public static string GetFieldValues(string sql)
        {
            string ma = "";
            MySqlCommand command = new MySqlCommand(sql, Functions.Connect());
            MySqlDataReader reader = command.ExecuteReader();                        
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            return ma;
        }
        //123 => một trăm hai ba đồng
        //1,123,000=>một triệu một trăm hai ba nghìn đồng
        //1,123,345,000 => một tỉ một trăm hai ba triệu ba trăm bốn lăm ngàn đồng
        static string[] mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');
        //Viết hàm chuyển số hàng chục, giá trị truyền vào là số cần chuyển và một biến đọc phần lẻ hay không ví dụ 101 => một trăm lẻ một
        private static string DocHangChuc(double so, bool daydu)
        {
            string chuoi = "";
            //Hàm để lấy số hàng chục ví dụ 21/10 = 2
            Int64 chuc = Convert.ToInt64(Math.Floor((double)(so / 10)));
            //Lấy số hàng đơn vị bằng phép chia 21 % 10 = 1
            Int64 donvi = (Int64)so % 10;
            //Nếu số hàng chục tồn tại tức >=20
            if (chuc > 1)
            {
                chuoi = " " + mNumText[chuc] + " mươi";
                if (donvi == 1)
                {
                    chuoi += " mốt";
                }
            }
            else if (chuc == 1)
            {//Số hàng chục từ 10-19
                chuoi = " mười";
                if (donvi == 1)
                {
                    chuoi += " một";
                }
            }
            else if (daydu && donvi > 0)
            {//Nếu hàng đơn vị khác 0 và có các số hàng trăm ví dụ 101 => thì biến daydu = true => và sẽ đọc một trăm lẻ một
                chuoi = " lẻ";
            }
            if (donvi == 5 && chuc >= 1)
            {//Nếu đơn vị là số 5 và có hàng chục thì chuỗi sẽ là " lăm" chứ không phải là " năm"
                chuoi += " lăm";
            }
            else if (donvi > 1 || (donvi == 1 && chuc == 0))
            {
                chuoi += " " + mNumText[donvi];
            }
            return chuoi;
        }
        private static string DocHangTram(double so, bool daydu)
        {
            string chuoi = "";
            //Lấy số hàng trăm ví du 434 / 100 = 4 (hàm Floor sẽ làm tròn số nguyên bé nhất)
            Int64 tram = Convert.ToInt64(Math.Floor((double)so / 100));
            //Lấy phần còn lại của hàng trăm 434 % 100 = 34 (dư 34)
            so = so % 100;
            if (daydu || tram > 0)
            {
                chuoi = " " + mNumText[tram] + " trăm";
                chuoi += DocHangChuc(so, true);
            }
            else
            {
                chuoi = DocHangChuc(so, false);
            }
            return chuoi;
        }
        private static string DocHangTrieu(double so, bool daydu)
        {
            string chuoi = "";
            //Lấy số hàng triệu
            Int64 trieu = Convert.ToInt64(Math.Floor((double)so / 1000000));
            //Lấy phần dư sau số hàng triệu ví dụ 2,123,000 => so = 123,000
            so = so % 1000000;
            if (trieu > 0)
            {
                chuoi = DocHangTram(trieu, daydu) + " triệu";
                daydu = true;
            }
            //Lấy số hàng nghìn
            Int64 nghin = Convert.ToInt64(Math.Floor((double)so / 1000));
            //Lấy phần dư sau số hàng nghin 
            so = so % 1000;
            if (nghin > 0)
            {
                chuoi += DocHangTram(nghin, daydu) + " nghìn";
                daydu = true;
            }
            if (so > 0)
            {
                chuoi += DocHangTram(so, daydu);
            }
            return chuoi;
        }
        public static string ChuyenSoSangChuoi(double so)
        {
            if (so == 0)
                return mNumText[0];
            string chuoi = "", hauto = "";
            Int64 ty;
            do
            {
                //Lấy số hàng tỷ
                ty = Convert.ToInt64(Math.Floor((double)so / 1000000000));
                //Lấy phần dư sau số hàng tỷ
                so = so % 1000000000;
                if (ty > 0)
                {
                    chuoi = DocHangTrieu(so, true) + hauto + chuoi;
                }
                else
                {
                    chuoi = DocHangTrieu(so, false) + hauto + chuoi;
                }
                hauto = " tỷ";
            } while (ty > 0);
            return chuoi + " đồng";
        }
        public static string ConvertTimeTo24(string hour)
        {
            string h = "";
            switch (hour)
            {
                case "1":
                    h = "13";
                    break;
                case "2":
                    h = "14";
                    break;
                case "3":
                    h = "15";
                    break;
                case "4":
                    h = "16";
                    break;
                case "5":
                    h = "17";
                    break;
                case "6":
                    h = "18";
                    break;
                case "7":
                    h = "19";
                    break;
                case "8":
                    h = "20";
                    break;
                case "9":
                    h = "21";
                    break;
                case "10":
                    h = "22";
                    break;
                case "11":
                    h = "23";
                    break;
                case "12":
                    h = "0";
                    break;
            }
            return h;
        }
        //tao ma hoa don tu dong
        public static string CreateKey(string tiento)
        {
            string key = tiento;
            string[] partsDay;
            partsDay = DateTime.Now.ToShortDateString().Split('/');
            //Ví dụ 07/08/2009
            string d = String.Format("{0}{1}{2}", partsDay[0], partsDay[1], partsDay[2]);
            key = key + d;
            string[] partsTime;
            partsTime = DateTime.Now.ToLongTimeString().Split(':');
            //Ví dụ 7:08:03 PM hoặc 7:08:03 AM
            if (partsTime[2].Substring(3, 2) == "PM")
                partsTime[0] = ConvertTimeTo24(partsTime[0]);
            if (partsTime[2].Substring(3, 2) == "AM")
                if (partsTime[0].Length == 1)
                    partsTime[0] = "0" + partsTime[0];
            //Xóa ký tự trắng và PM hoặc AM
            partsTime[2] = partsTime[2].Remove(2, 3);
            string t;
            t = String.Format("_{0}{1}{2}", partsTime[0], partsTime[1], partsTime[2]);
            key = key + t;
            return key;
        }
    }
       
}

