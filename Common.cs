using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanSach
{
    public class Common
    {
        public static Boolean KiemTraBatLoi(TextBox txt)
        {
            if (txt.Text == "")
            {
                MessageBox.Show(String.Format("Mời bạn nhập vào Giá trị" + txt.Name));
                return false;
            }
            return true;
        }
    }
}
