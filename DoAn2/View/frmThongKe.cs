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
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        ThongkeBUS tk;
        int tongtien = 0;
        int tt1 = 0, tt2 = 0;

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            tk = new ThongkeBUS(Program.stcon);
        }

        private void btnXem2_Click(object sender, EventArgs e)
        {
            HoaDonNhap h1 = new HoaDonNhap();
            HoaDonNhap h2 = new HoaDonNhap();
            h1.Nam = dtnHD1.Value.Year;
            h1.Thang = dtnHD1.Value.Month;
            h1.Ngay = dtnHD1.Value.Day;
            h2.Nam = dtnHD2.Value.Year;
            h2.Thang = dtnHD2.Value.Month;
            h2.Ngay = dtnHD2.Value.Day;


            dgvDSThongkeN.DataSource = tk.GetThongKe_HDN(h1, h2);
            if (dgvDSThongkeB.Rows.Count != 1)
            {
                for (int i = 0; i < dgvDSThongkeN.Rows.Count - 1; i++)
                {
                    tongtien = tongtien + int.Parse(dgvDSThongkeN.Rows[i].Cells[5].Value.ToString());
                    txtTongChii.Text = tongtien.ToString();
                }
            }
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            HoaDonBan hdb1 = new HoaDonBan();
            HoaDonBan hdb2 = new HoaDonBan();

            hdb1.Nam = dtDT1.Value.Year;
            hdb1.Thang = dtDT1.Value.Month;
            hdb1.Ngay = dtDT1.Value.Day;
            hdb2.Nam = dtDT2.Value.Year;
            hdb2.Thang = dtDT2.Value.Month;
            hdb2.Ngay = dtDT2.Value.Day;
            dgvHoaDonBan.DataSource = tk.GetThongKe_HDB(hdb1, hdb2);
            if (dgvHoaDonBan.Rows.Count != 1)
            {
                for (int i = 0; i < dgvHoaDonBan.Rows.Count - 1; i++)
                {
                    tt1 = tt1 + int.Parse(dgvHoaDonBan.Rows[i].Cells[5].Value.ToString());
                    txtTT.Text = tt1.ToString();
                }
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            HoaDonBan h1 = new HoaDonBan();
            HoaDonBan h2 = new HoaDonBan();
            h1.Nam = dtbHD1.Value.Year;
            h1.Thang = dtbHD1.Value.Month;
            h1.Ngay = dtbHD1.Value.Day;
            h2.Nam = dtbHD2.Value.Year;
            h2.Thang = dtbHD2.Value.Month;
            h2.Ngay = dtbHD2.Value.Day;

            dgvDSThongkeB.DataSource = tk.GetThongKe_HDB(h1, h2);
            if (dgvDSThongkeB.Rows.Count != 1)
            {
                for (int i = 0; i < dgvDSThongkeB.Rows.Count - 1; i++)
                {
                    tongtien = tongtien + int.Parse(dgvDSThongkeB.Rows[i].Cells[5].Value.ToString());
                    txtTongThu.Text = tongtien.ToString();
                }
            }
        }
    }
}
