using DoAn2.BUS;
using DoAn2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn2.View
{
    public partial class frmQLChiTietHDN : Form
    {
        public frmQLChiTietHDN()
        {
            InitializeComponent();
        }

        HoaDonNhapBUS hdb;
        private void frmQLChiTietHDN_Load(object sender, EventArgs e)
        {
            hdb = new HoaDonNhapBUS(Program.stcon);
            dgvCTHoaDon.Columns["MaHDN"].Visible = false;
        }

        private void txtMaHDN_TextChanged(object sender, EventArgs e)
        {
            hdb = new HoaDonNhapBUS(Program.stcon);
            //ct = hdb.GetChiTietHDN(txtMaHDN.Text.ToString());
            dgvCTHoaDon.DataSource = hdb.GetCTHoaDon(txtMaHDN.Text.ToString());
            dgvCTHoaDon.Columns["MaHDN"].Visible = false;
        }
    }
}
