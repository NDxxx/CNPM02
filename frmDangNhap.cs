using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyBanSach
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectToDB.ConnectionString);

            try
            {
                //mở sql
                conn.Open();
                string tk = txtId.Text;
                string mk = txtPassWord.Text;
                string strQuery = "select * from NguoiDung where TaiKhoan ='" + tk + "' and MatKhau ='" + mk + "'";

                SqlCommand cmd = new SqlCommand(strQuery, conn);

                SqlDataReader dta = cmd.ExecuteReader();

                if (dta.Read() == true)
                {
                    // MessageBox.Show("Bạn đã đăng nhập thành công !");

                    this.Visible = false;
                    frmCuaSoChinh frmCuaSo = new frmCuaSoChinh();
                    frmCuaSo.ShowDialog();
                    //  this.Visible = true;
                }
                else
                {
                    txtPassWord.Text = "";
                    MessageBox.Show("Đăng nhập thất bại!");
                    txtPassWord.Focus();
                    return;
                }
                this.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Bạn muốn thoát??", "Thoát", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                this.Close();
            }
        }

     
    }
}
