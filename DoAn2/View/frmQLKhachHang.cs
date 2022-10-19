using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn2.Entities;
using DoAn2.BUS;

namespace DoAn2.View
{
    public partial class frmQLKhachHang : Form
    {
        public frmQLKhachHang()
        {
            InitializeComponent();
        }
        KhachHangBUS kb;
        List<KhachHang> khach;

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            load_data();
        }
        private void load_data()
        {
            kb = new KhachHangBUS(Program.stcon);
            khach = kb.GetKhachHang();
            dgvKhachHang.DataSource = khach;
        }
        private void txtMaKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTenKH.Focus();
            }
        }

        private void txtTenKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSdt.Focus();
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                KhachHang n = new KhachHang();
                n.MaKH = txtTimkiem.Text;
                n.TenKH = txtTimkiem.Text;
                n.Sdt = txtTimkiem.Text;
                dgvKhachHang.DataSource = kb.FindKhachang(n);
                if (dgvKhachHang.RowCount == 0)
                    MessageBox.Show("Không có dữ liệu bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThemkh_Click(object sender, EventArgs e)
        {
            KhachHang k = new KhachHang();
            k.MaKH = txtMaKH.Text;
            k.TenKH = txtTenKH.Text;
            k.Diachi = txtDiachi.Text;
            k.Sdt = txtSdt.Text;

            kb.AddKhachHang(k);
            khach.Add(k);
            load_data();
            if (dgvKhachHang.Rows.Count > 1)
            {
                dgvKhachHang.CurrentCell = dgvKhachHang.Rows[dgvKhachHang.Rows.Count - 1].Cells[0];//chuyển đến dòng vừa thêm
            }
            MessageBox.Show("Thêm dữ liệu thành công !", "Thông báo", MessageBoxButtons.OKCancel);
        }

        private void btnXoakh_Click(object sender, EventArgs e)
        {
            try
            {
                kb.DeleteKhachHang(txtMaKH.Text);
                //khach.Remove(khach.Find(m => m.MaKH == txtMaKH.Text));

                load_data();

                txtMaKH.Text = "";
                txtTenKH.Text = "";
                txtDiachi.Text = "";
                txtSdt.Text = "";
               
                MessageBox.Show("Delete thành công !", "Thông báo", MessageBoxButtons.OK);
                btnThem.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SinhMaTuDong()
        {
            int count = 0;
            count = dgvKhachHang.Rows.Count;//đếm tất cả các dòng trong dgv rồi gán cho count
            string chuoi = "";
            int chuoi2 = 0;
            chuoi = Convert.ToString(dgvKhachHang.Rows[count - 1].Cells[0].Value);
            chuoi2 = Convert.ToInt32((chuoi.Remove(0, 3)));
            //loại bỏ ký tự mã MKH đã đặt trong sql là MKH01
            if (chuoi2 + 1 < 10)
                txtMaKH.Text = "Kh00" + (chuoi2 + 1).ToString();
            //phép thử này giúp cộng dồn lên khi thoả mãn đk if, nếu vướt quá 10 thì thực hiện lệnh else if
            else if (chuoi2 + 1 < 100)
                txtMaKH.Text = "Kh00" + (chuoi2 + 1).ToString();
        }

        private void btnNhapmoi_Click(object sender, EventArgs e)
        {
            SinhMaTuDong();
            //KhachHang k = new KhachHang();
            //k.MaKH = txtMaKH.Text;
            txtTenKH.Text = "";
            txtDiachi.Text = "";
            txtSdt.Text = "";
           
        }

        private void btnSuakh_Click(object sender, EventArgs e)
        {
            try
            {
                KhachHang k = new KhachHang();
                k.MaKH = txtMaKH.Text;
                k.TenKH = txtTenKH.Text;
                k.Diachi = txtDiachi.Text;
                k.Sdt = txtSdt.Text; 
                kb.EditKhachHang(k);
                load_data();
                dgvKhachHang.CurrentCell = dgvKhachHang.Rows[dgvKhachHang.Rows.Count - 1].Cells[0];
                MessageBox.Show("Update dữ liệu thành công !", "Thông báo", MessageBoxButtons.OKCancel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSdt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDiachi.Focus();
            }
        }
        public bool checkData()
        {
            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên Album nhạc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenKH.Focus();
                return false;//người dùng chưa nhập nên false
            }
            if (string.IsNullOrWhiteSpace(txtDiachi.Text))
            {
                MessageBox.Show("Bạn chưa nhập giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiachi.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSdt.Text))
            {
                MessageBox.Show("Bạn chưa nhập ngày phát hành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSdt.Focus();
                return false;
            }
            return true;//người dùng đã nhập đầy đủ nên true
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaKH.Text = dgvKhachHang.CurrentRow.Cells["MaKH"].Value.ToString();
                txtTenKH.Text = dgvKhachHang.CurrentRow.Cells["TenKH"].Value.ToString();
                txtDiachi.Text = dgvKhachHang.CurrentRow.Cells["Diachi"].Value.ToString();
                txtSdt.Text = dgvKhachHang.CurrentRow.Cells["Sdt"].Value.ToString();

                btnXoa.Enabled = true;
                //btnThem.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng chọn bên trong bảng", "Thông báo", MessageBoxButtons.OK);
            }
        }
    }
}
