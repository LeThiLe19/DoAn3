using DoAn2.BUS;
using DoAn2.DAL;
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
    public partial class frmQLBanHang : Form
    {
        public frmQLBanHang()
        {
            InitializeComponent();
        }

        HoaDonBanBUS hdb;
        private void frmQLBanHang_Load(object sender, EventArgs e)
        {
            load_data();
        }
        private void load_data()
        {
            hdb = new HoaDonBanBUS(Program.stcon);
            dgvBanHang.DataSource = hdb.GetHoaDonH();
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            frmQLHoaDonBan frm = new frmQLHoaDonBan();
            frm.ShowDialog();
        }
        private void XemCTHD()
        {
            string mahd, manv, makh, tenkh, diachi, ngaylap;
            decimal tongtien;
            if (MessageBox.Show("Bạn có muốn xem thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mahd = dgvBanHang.CurrentRow.Cells["MaHDB"].Value.ToString();
                manv = dgvBanHang.CurrentRow.Cells["MaNV"].Value.ToString();
                tenkh = dgvBanHang.CurrentRow.Cells["TenKH"].Value.ToString();
                makh = dgvBanHang.CurrentRow.Cells["MaKH"].Value.ToString();
                diachi = dgvBanHang.CurrentRow.Cells["Diachi"].Value.ToString();
                ngaylap = dgvBanHang.CurrentRow.Cells["ThoigianB"].Value.ToString();
                tongtien = decimal.Parse(dgvBanHang.CurrentRow.Cells["Tongtien"].Value.ToString());
                frmQLChiTietHDB frm = new frmQLChiTietHDB();
                frm.txtMaHDB.Text = mahd;
                frm.txtMaNV.Text = manv;
                frm.txtMaKH.Text = makh;
                frm.txtTenKH.Text = tenkh;
                frm.txtDiachi.Text = diachi;
                frm.mtxtNgayph.Text = ngaylap;
                frm.txtTongthanhtoan.Text = tongtien.ToString();

                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }

        private void dgvBanHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            XemCTHD();
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            XemCTHD();
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HoaDonBan n = new HoaDonBan();
                    n.MaHDB = txtTimkiem.Text;
                    dgvBanHang.DataSource = hdb.FindHDB(n);
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

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDonBan n = new HoaDonBan();
                n.MaHDB = txtTimkiem.Text;
                dgvBanHang.DataSource = hdb.FindHDB(n);
                if (dgvBanHang.RowCount < 1)
                    MessageBox.Show("Không có dữ liệu bạn cần tìm", "Thông báo", MessageBoxButtons.OK);

                //btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = false;
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

        private void txtTimkiem_Click(object sender, EventArgs e)
        {

        }
        private void SinhMaTD()
        {
            int count = 0;
            count = dgvBanHang.Rows.Count;//đếm tất cả các dòng trong dgv rồi gán cho count
            string chuoi = "";
            int chuoi2 = 0;
            chuoi = Convert.ToString(dgvBanHang.Rows[count - 1].Cells[0].Value);
            chuoi2 = Convert.ToInt32((chuoi.Remove(0, 3)));
            //loại bỏ ký tự mã MNV đã đặt trong sql là MNV01
            if (chuoi2 + 1 < 10)
                txtTimkiem.Text = "Nv00" + (chuoi2 + 1).ToString();
            //phép thử này giúp cộng dồn lên khi thoả mãn đk if, nếu vướt quá 10 thì thực hiện lệnh else if
            else if (chuoi2 + 1 < 100)
                txtTimkiem.Text = "Nv0" + (chuoi2 + 1).ToString();
        }
    }
}
