namespace QuanLyBanSach
{
    partial class frmHienThiBaoCao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.CTHOADONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetChiTietHoaDon = new QuanLyBanSach.DataSetChiTietHoaDon();
            this.reportViewerChiTietHoaDon = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CTHOADONTableAdapter = new QuanLyBanSach.DataSetChiTietHoaDonTableAdapters.CTHOADONTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CTHOADONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetChiTietHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // CTHOADONBindingSource
            // 
            this.CTHOADONBindingSource.DataMember = "CTHOADON";
            this.CTHOADONBindingSource.DataSource = this.DataSetChiTietHoaDon;
            // 
            // DataSetChiTietHoaDon
            // 
            this.DataSetChiTietHoaDon.DataSetName = "DataSetChiTietHoaDon";
            this.DataSetChiTietHoaDon.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewerChiTietHoaDon
            // 
            this.reportViewerChiTietHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetChiTietHoaDon";
            reportDataSource1.Value = this.CTHOADONBindingSource;
            this.reportViewerChiTietHoaDon.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerChiTietHoaDon.LocalReport.ReportEmbeddedResource = "QuanLyBanSach.Reports.rptChiTietHoaDon.rdlc";
            this.reportViewerChiTietHoaDon.Location = new System.Drawing.Point(0, 0);
            this.reportViewerChiTietHoaDon.Name = "reportViewerChiTietHoaDon";
            this.reportViewerChiTietHoaDon.Size = new System.Drawing.Size(874, 434);
            this.reportViewerChiTietHoaDon.TabIndex = 0;
            // 
            // CTHOADONTableAdapter
            // 
            this.CTHOADONTableAdapter.ClearBeforeFill = true;
            // 
            // frmHienThiBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 434);
            this.Controls.Add(this.reportViewerChiTietHoaDon);
            this.Name = "frmHienThiBaoCao";
            this.Text = "frmHienThiBaoCao";
            this.Load += new System.EventHandler(this.frmHienThiBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CTHOADONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetChiTietHoaDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerChiTietHoaDon;
        private System.Windows.Forms.BindingSource CTHOADONBindingSource;
        private DataSetChiTietHoaDon DataSetChiTietHoaDon;
        private DataSetChiTietHoaDonTableAdapters.CTHOADONTableAdapter CTHOADONTableAdapter;
    }
}