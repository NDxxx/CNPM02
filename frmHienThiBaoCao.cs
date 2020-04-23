using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QuanLyBanSach
{
    public partial class frmHienThiBaoCao : Form
    {
        /// <summary>
        /// khai báo thuộc tính để truyền tên báo cáo phục vụ hiển thị
        /// </summary>
        /// 

        private String strTenBaoCao = "";

        public string StrTenBaoCao
        {
            get { return strTenBaoCao; }
            set { strTenBaoCao = value; }
        }

        public frmHienThiBaoCao()
        {
            InitializeComponent();
        }

        private void frmHienThiBaoCao_Load(object sender, EventArgs e)
        {
            
            try
            {
                // TODO: This line of code loads data into the 'DataSetChiTietHoaDon.CTHOADON' table. You can move, or remove it, as needed.
                this.CTHOADONTableAdapter.Fill(this.DataSetChiTietHoaDon.CTHOADON);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.StackTrace, "Lỗi");
            }

            //khai báo đển đường dẫn của reportview
            reportViewerChiTietHoaDon.LocalReport.ReportPath = "Reports/" + strTenBaoCao;

            //tạo dataSource để hiển thị cho report
            ReportDataSource reportDataSource = new ReportDataSource();

            DataTable dt;

            //gọi tên kháo tương ứng
            switch (strTenBaoCao)
            {
                case "rptChiTietHoaDon.rdlc":

                    //lấy dữ liệu từ data
                    ChiTietHoaDonBusiness ct = new ChiTietHoaDonBusiness();
                    dt = ct.LayDanhSachCTHoaDon();
                    reportDataSource.Name = "DataSetChiTietHoaDon.xsd";
                    reportDataSource.Value = dt;


                    ReportParameter[] reportPars = new ReportParameter[1];
                    reportPars[0] = new ReportParameter("ngayBaoCao",DateTime.Now.ToString("dd/MM/yyyy"));
 
                    //thêm vào báo cáo
                    reportViewerChiTietHoaDon.LocalReport.SetParameters(reportPars);

                    break;


                case "rptSoLuongSachTon.rdlc":

                    //lấy dữ liệu từ data
                    SachBusiness sach = new SachBusiness();
                    dt = sach.LayTableSach();
                    reportDataSource.Name = "DataSetSoLuongSachTon";
                    reportDataSource.Value = dt;

                    break;
            }

            //thêm vào report để lấy hiển thị
            reportViewerChiTietHoaDon.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewerChiTietHoaDon.RefreshReport();
        }
    }
}
