using DoAn2.Entities;
using DoAn2.BUS;
using DoAn2.DAL;
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
    public partial class frmQLNhapHang : Form
    {
        public frmQLNhapHang()
        {
            InitializeComponent();
        }
        HoaDonNhapBUS hdb;
        List<NhanVien> nv;
        List<NCC> ncc;
        List<HoaDonNhap> hd;

        private void frmQLNhapHang_Load(object sender, EventArgs e)
        {
            load_data();

        }
        private void load_data()
        {
            hdb = new HoaDonNhapBUS(Program.stcon);
            dgvNhapHang.DataSource = hdb.GetHoaDon();
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            frmQLHoaDonNhap frm = new frmQLHoaDonNhap();
            //frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void dgvHoaDonNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string mahd, manv, mancc, tenncc, diachi, ngaylap;
            int tongtien;
            if (MessageBox.Show("Bạn có muốn xem thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mahd = dgvNhapHang.CurrentRow.Cells["MaHDN"].Value.ToString();
                manv = dgvNhapHang.CurrentRow.Cells["MaNV"].Value.ToString();
                tenncc = dgvNhapHang.CurrentRow.Cells["TenNCC"].Value.ToString();
                mancc = dgvNhapHang.CurrentRow.Cells["maNCC"].Value.ToString();
                diachi = dgvNhapHang.CurrentRow.Cells["Diachi"].Value.ToString();
                ngaylap = dgvNhapHang.CurrentRow.Cells["ThoigianN"].Value.ToString();
                tongtien = int.Parse(dgvNhapHang.CurrentRow.Cells["Tongtien"].Value.ToString());
                frmQLChiTietHDN frm = new frmQLChiTietHDN();
                frm.txtMaHDN.Text = mahd;
                frm.txtMaNV.Text = manv;
                frm.txtMaNCC.Text = mancc;
                frm.txtTenNCC.Text = tenncc;
                frm.txtDiachi.Text = diachi;
                frm.mtxtNgayph.Text = ngaylap;
                frm.txtTongthanhtoan.Text = tongtien.ToString();

                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }

        private void btnXemCT_Click(object sender, EventArgs e)
        {
            string mahd, manv, mancc, tenncc, diachi, ngaylap;
            double tongtien;
            mahd = dgvNhapHang.CurrentRow.Cells["MaHDN"].Value.ToString();
            manv = dgvNhapHang.CurrentRow.Cells["MaNV"].Value.ToString();
            tenncc = dgvNhapHang.CurrentRow.Cells["TenNCC"].Value.ToString();
            mancc = dgvNhapHang.CurrentRow.Cells["MaNCC"].Value.ToString();
            diachi = dgvNhapHang.CurrentRow.Cells["Diachi"].Value.ToString();
            ngaylap = dgvNhapHang.CurrentRow.Cells["ThoigianN"].Value.ToString();
            tongtien = double.Parse(dgvNhapHang.CurrentRow.Cells["Tongtien"].Value.ToString());
            frmQLChiTietHDN frm = new frmQLChiTietHDN();
            frm.txtMaHDN.Text = mahd;
            frm.txtMaNV.Text = manv;
            frm.txtMaNCC.Text = mancc;
            frm.txtTenNCC.Text = tenncc;
            frm.txtDiachi.Text = diachi;
            frm.mtxtNgayph.Text = ngaylap;
            frm.txtTongthanhtoan.Text = tongtien.ToString();

            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HoaDonNhap n = new HoaDonNhap();
                    n.MaHDN = txtTimkiem.Text;
                    dgvNhapHang.DataSource = hdb.FindHDN(n);
                    hdb.DeleteHoaDon(txtTimkiem.Text);
                    load_data();
                }
                MessageBox.Show("Xoá dữ liệu thành công !", "Thông báo", MessageBoxButtons.OKCancel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            load_data();
            btnThem.Enabled = true;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDonNhap n = new HoaDonNhap();
                n.MaHDN = txtTimkiem.Text;
                dgvNhapHang.DataSource = hdb.FindHDN(n);
                if (dgvNhapHang.RowCount == 0)
                    MessageBox.Show("Không có dữ liệu bạn cần tìm", "Thông báo", MessageBoxButtons.OK);

                btnXoa.Enabled = true;
                //btnSua.Enabled = true;
                btnThem.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTimkiem_Click(object sender, EventArgs e)
        {
            txtTimkiem.Clear();
        }

        private void btnTimkiem_Leave(object sender, EventArgs e)
        {
            txtTimkiem.Text = "Nhập thông tin cần tìm";
        }
    }
}
