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
    public partial class MDI : Form
    {
        private int childFormNumber = 0;

        public MDI()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        
        
        

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        

        private void mnuLoaiMT_Click(object sender, EventArgs e)
        {
            frmQLLoaiMT f = new frmQLLoaiMT();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void mnuMayTinh_Click(object sender, EventArgs e)
        {
            frmQLMayTinh f = new frmQLMayTinh();
            this.Hide();
            f.ShowDialog();
            this.Show();

        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            frmQLKhachHang f = new frmQLKhachHang();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            frmQLNhanVien f = new frmQLNhanVien();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void mnuNCC_Click(object sender, EventArgs e)
        {
            frmQLNCC f = new frmQLNCC();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void mnHoaDonBan_Click(object sender, EventArgs e)
        {

        }

        private void mnuThongke_Click(object sender, EventArgs e)
        {
            frmThongKe f = new frmThongKe();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

       

        private void mnuLapHD_Click(object sender, EventArgs e)
        {
            frmQLHoaDonBan f = new frmQLHoaDonBan();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        

        private void mnuLapHDB_Click(object sender, EventArgs e)
        {
            frmQLHoaDonBan f = new frmQLHoaDonBan();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void mnuXemDSB_Click(object sender, EventArgs e)
        {
            frmQLBanHang f = new frmQLBanHang();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        
        

        private void mnuXemDSN_Click(object sender, EventArgs e)
        {
            frmQLNhapHang f = new frmQLNhapHang();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void mnuLapHDN_Click(object sender, EventArgs e)
        {
            frmQLHoaDonNhap f = new frmQLHoaDonNhap();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuMayTinh_Click_1(object sender, EventArgs e)
        {
            frmQLMayTinh f = new frmQLMayTinh();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
