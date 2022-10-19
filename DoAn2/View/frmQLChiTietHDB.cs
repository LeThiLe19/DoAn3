using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn2.BUS;
using DoAn2.Entities;

namespace DoAn2.View
{
    public partial class frmQLChiTietHDB : Form
    {
        public frmQLChiTietHDB()
        {
            InitializeComponent();
        }
        HoaDonBanBUS hdb;
        List<ChiTietHDB> ct;

        private void frmQLChiTietHDB_Load(object sender, EventArgs e)
        {
            hdb = new HoaDonBanBUS(Program.stcon);
        }

        private void txtMaHDB_TextChanged(object sender, EventArgs e)
        {
            hdb = new HoaDonBanBUS(Program.stcon);
            //ct = hdb.GetChiTietHDB(txtMaHDB.Text.ToString());
            dgvCTHoaDon.DataSource = hdb.GetCTHoaDonH(txtMaHDB.Text.ToString());
            dgvCTHoaDon.Columns["MaHDB"].Visible = false;
        }
    }
}
