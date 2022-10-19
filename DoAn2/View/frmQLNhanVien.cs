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
    public partial class frmQLNhanVien : Form
    {
        public frmQLNhanVien()
        {
            InitializeComponent();
        }
        NhanVienBUS nb;
        List<NhanVien> nv;

        private void frmQLNhanVien_Load(object sender, EventArgs e)
        {
            load_data();
        }
        private void load_data()
        {
            nb = new NhanVienBUS(Program.stcon);
            nv = nb.GetNhanViens();
            dgvNhanVien.DataSource = nv;
        }

        private void btnThemnv_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVien n = new NhanVien();
                n.MaNV = txtMaNV.Text;
                n.TenNV = txtTenNV.Text;
                n.Diachi = txtDiachi.Text;
                n.Sdt = mtxtSdt.Text;
                n.Diachi = txtDiachi.Text;
                nb.AddNhanVien(n);
                nv.Add(n);
                dgvNhanVien.DataSource = null;
                dgvNhanVien.DataSource = nv;
                if (dgvNhanVien.Rows.Count > 1)
                {
                    dgvNhanVien.CurrentCell = dgvNhanVien.Rows[dgvNhanVien.Rows.Count - 1].Cells[0];
                    //chuyển đến dòng vừa thêm
                }
                MessageBox.Show("Thêm dữ liệu thành công !", "Thông báo", MessageBoxButtons.OKCancel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSuanv_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVien n = new NhanVien();
                n.MaNV = txtMaNV.Text;
                n.TenNV = txtTenNV.Text;
                n.Diachi = txtDiachi.Text;
                n.Sdt = mtxtSdt.Text;
                nb.EditNhanVien(n);

                NhanVien vien = nv.Find(v => v.MaNV == n.MaNV);
                vien.MaNV = n.MaNV;
                vien.TenNV = n.TenNV;
                
                vien.Sdt = n.Sdt;
                vien.Diachi = n.Diachi;

                load_data();
                dgvNhanVien.CurrentCell = dgvNhanVien.Rows[dgvNhanVien.Rows.Count - 1].Cells[0];
                MessageBox.Show("Update dữ liệu thành công !", "Thông báo", MessageBoxButtons.OKCancel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoanv_Click(object sender, EventArgs e)
        {
            try
            {
                nb.DeleteNhaVien(txtMaNV.Text);
                nv.Remove(nv.Find(m => m.MaNV == txtMaNV.Text));

                load_data();

                txtMaNV.Text = "";
                txtTenNV.Text = "";
                txtDiachi.Text = "";
                mtxtSdt.Text = "";
                MessageBox.Show("Delete thành công !", "Thông báo", MessageBoxButtons.OK);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SinhMaTuDong()
        {
            //txtMaNV.Text = MaNV.ToString();
            int count = 0;
            count = dgvNhanVien.Rows.Count;//đếm tất cả các dòng trong dgv rồi gán cho count
            string chuoi = "";
            int chuoi2 = 0;
            chuoi = Convert.ToString(dgvNhanVien.Rows[count - 1].Cells[0].Value);
            chuoi2 = Convert.ToInt32((chuoi.Remove(0, 3)));
            //loại bỏ ký tự mã MNV đã đặt trong sql là MNV01
            if (chuoi2 + 1 < 10)
                txtMaNV.Text = "NV0" + (chuoi2 + 1).ToString();
            //phép thử này giúp cộng dồn lên khi thoả mãn đk if, nếu vướt quá 10 thì thực hiện lệnh else if
            else if (chuoi2 + 1 < 100)
                txtMaNV.Text = "NV00" + (chuoi2 + 1).ToString();
        }

        private void btnNhapmoi_Click(object sender, EventArgs e)
        {
            //DataHelper dh = new DataHelper(Program.stcon);
            //txtMaNV.Text = dh.CreateKey("MNV0");
            SinhMaTuDong();
            txtTenNV.Text = "";
            txtDiachi.Text = "";
            mtxtSdt.Text = "";
            txtTimkiem.Text = "";
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVien n = new NhanVien();
                n.MaNV = txtTimkiem.Text;
                n.TenNV = txtTimkiem.Text;
                n.Sdt = txtTimkiem.Text;
                dgvNhanVien.DataSource = nb.FindNhanvien(n);
                if (dgvNhanVien.RowCount < 1)
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

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaNV.Text = dgvNhanVien.CurrentRow.Cells["MaNV"].Value.ToString();
                txtTenNV.Text = dgvNhanVien.CurrentRow.Cells["TenNV"].Value.ToString();
                txtDiachi.Text = dgvNhanVien.CurrentRow.Cells["Diachi"].Value.ToString();
                mtxtSdt.Text = dgvNhanVien.CurrentRow.Cells["Sdt"].Value.ToString();
        
                btnXoa.Enabled = true;
                btnThem.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng chọn bên trong bảng", "Thông báo", MessageBoxButtons.OK);
            }
        }
        public bool checkData()
        {
            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên Album nhạc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenNV.Focus();
                return false;//người dùng chưa nhập nên false
            }
            if (string.IsNullOrWhiteSpace(txtDiachi.Text))
            {
                MessageBox.Show("Bạn chưa nhập giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiachi.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(mtxtSdt.Text))
            {
                MessageBox.Show("Bạn chưa nhập ngày phát hành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtxtSdt.Focus();
                return false;
            }
            return true;//người dùng đã nhập đầy đủ nên true
        }

        private void btnTimkiem_Leave(object sender, EventArgs e)
        {
            txtTimkiem.Text = "Nhập thông tin cần tìm";
        }

        private void txtTimkiem_Click(object sender, EventArgs e)
        {
            txtTimkiem.Clear();
        }
    }
}
