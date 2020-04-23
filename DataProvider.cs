using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanSach
{
    public class DataProvider
    {
        private static SachBusiness _sachBusi = new SachBusiness();

        public static SachBusiness SachBusi
        {
            get { return _sachBusi; }
            set { _sachBusi = value; }
        }

        private static KhachHangBusiness _khachBusiness = new KhachHangBusiness();

        public static KhachHangBusiness KhachBusiness
        {
            get { return _khachBusiness; }
            set { _khachBusiness = value; }
        }

        private static HoaDonBusiness _hoaDonBusiness = new HoaDonBusiness();

        public static HoaDonBusiness HoaDonBusiness
        {
            get { return _hoaDonBusiness; }
            set { _hoaDonBusiness = value; }
        }

        private static ChiTietHoaDonBusiness _chiTietHoaDonBusiness = new ChiTietHoaDonBusiness();

        public static ChiTietHoaDonBusiness ChiTietHoaDonBusiness
        {
            get { return _chiTietHoaDonBusiness; }
            set { _chiTietHoaDonBusiness = value; }
        }

        public static void _ExcuteNonQuery(String strQuery,SqlParameter[] pars = null)
        {
            //tạo conection đến sql
            SqlConnection conn = new SqlConnection(ConnectToDB.ConnectionString);

            SqlCommand command = new SqlCommand();
            command.Connection = conn; //chỉ ra connection đnag làm việc
            command.CommandType = CommandType.Text; //chỉ ra kiểu command
            command.CommandText = strQuery; //Gán nội dung câu lệnh


            //Nếu có tham số thì thêm vào công việc cần thực để không bị lỗi
            //khi công việc đó thực thi
            if (pars != null && pars.Length > 0)
            {
                command.Parameters.AddRange(pars);
            }


            //thực hieennj câu lệnh
            try
            {
                //mở kết nối
                conn.Open();

                //chạy câu lệnh
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            
            {
                MessageBox.Show("Lỗi kết nối: " + e.StackTrace, "Lỗi");
            }

            //đóng kết nối
            conn.Close();
        }

        public static DataTable _ExCuteDataTable(String strQuery)
        {
            DataTable dt= new DataTable();

            //tạo conection đến sql
            SqlConnection conn = new SqlConnection(ConnectToDB.ConnectionString);

            SqlCommand command = new SqlCommand();
            command.Connection = conn; //chỉ ra connection đnag làm việc
            command.CommandType = CommandType.Text; //chỉ ra kiểu command
            command.CommandText = strQuery; //Gán nội dung câu lệnh

            //thực hiện câu lệnh
            try
            {
                //mở kết nối
                conn.Open();

                //chạy câu lệnh
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                //đổ dữ liệu vào bảng
                adapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối: " + e.StackTrace, "Lỗi");
            }

            return dt;
        }



        public static void StoreExcuteNonQuery(String strQuery, SqlParameter[] pars = null)
        {
            //tạo conection đến sql
            SqlConnection conn = new SqlConnection(ConnectToDB.ConnectionString);

            SqlCommand command = new SqlCommand(strQuery,conn);
            command.Connection = conn; //chỉ ra connection đnag làm việc
            command.CommandType = CommandType.StoredProcedure; //chỉ ra kiểu command

            //Nếu có tham số thì thêm vào công việc cần thực để không bị lỗi
            //khi công việc đó thực thi
            if (pars != null && pars.Length > 0)
            {
                command.Parameters.AddRange(pars);
            }


            //thực hiện câu lệnh
            try
            {
                //mở kết nối
                conn.Open();

                //chạy câu lệnh
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối: " + e.StackTrace, "Lỗi");
            }

            //đóng kết nối
            conn.Close();
        }


        public static DataTable StoreExCuteDataTable(String strQuery)
        {
            DataTable dt = new DataTable();

            //tạo conection đến sql
            SqlConnection conn = new SqlConnection(ConnectToDB.ConnectionString);

            SqlCommand command = new SqlCommand(strQuery,conn);
            command.Connection = conn; //chỉ ra connection đnag làm việc
            command.CommandType = CommandType.StoredProcedure; //chỉ ra kiểu command

            //thực hiện câu lệnh
            try
            {
                //mở kết nối
                conn.Open();

                //chạy câu lệnh
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                //đổ dữ liệu vào bảng
                adapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối: " + e.StackTrace, "Lỗi");
            }

            return dt;
        }
    }
}
