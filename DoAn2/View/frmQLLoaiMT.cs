using DoAn2;
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

namespace DoAn2
{
    public partial class frmQLLoaiMT : Form
    {
        LoaiMTBUS lmtb;
        List<LoaiMT> maytinh;
        public frmQLLoaiMT()
        {
            InitializeComponent();
        }

        private void frmQLLoaiMT_Load(object sender, EventArgs e)
        {
            load_data();
        }
        private void load_data()
        {
            lmtb = new LoaiMTBUS(Program.stcon);
            maytinh = lmtb.GetLoaiMT();
            dgvLoaiMT.DataSource = maytinh;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkData())
                {
                    LoaiMT tl = new LoaiMT();
                    tl = new LoaiMT();
                    tl.MaLoai = txtMaLoai.Text;
                    tl.TenLoai = txtTenLoai.Text;
                    lmtb.AddLoaiMT(tl);
                    maytinh.Add(tl);

                    //load_data();
                    dgvLoaiMT.DataSource = null;
                    dgvLoaiMT.DataSource = maytinh;

                    if (dgvLoaiMT.Rows.Count > 1)
                    {
                        dgvLoaiMT.CurrentCell = dgvLoaiMT.Rows[dgvLoaiMT.Rows.Count - 1].Cells[0];//chuyển đến dòng vừa thêm
                    }
                    MessageBox.Show("Thêm dữ liệu thành công !", "Thông báo", MessageBoxButtons.OKCancel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                LoaiMT l = new LoaiMT();
                l.MaLoai = txtMaLoai.Text;
                l.TenLoai = txtTenLoai.Text;
                lmtb.EditLoaiMT(l);

                LoaiMT loai = maytinh.Find(tl => l.MaLoai == tl.MaLoai);
                loai.MaLoai = l.MaLoai;
                loai.TenLoai = l.TenLoai;

                load_data();
                dgvLoaiMT.CurrentCell = dgvLoaiMT.Rows[dgvLoaiMT.Rows.Count - 1].Cells[0];
                MessageBox.Show("Update dữ liệu thành công !", "Thông báo", MessageBoxButtons.OKCancel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                lmtb.DeleteLoaiMT(txtMaLoai.Text);
                maytinh.Remove(maytinh.Find(l => l.MaLoai == txtMaLoai.Text));

                load_data();
            }
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
            MessageBox.Show("Delete thành công !", "Thông báo", MessageBoxButtons.OK);

        }
        private void SinhMaTuDong()
        {
            int count = 0;
            count = dgvLoaiMT.Rows.Count;//đếm tất cả các dòng trong dgv rồi gán cho count
            string chuoi = "";
            int chuoi2 = 0;
            chuoi = Convert.ToString(dgvLoaiMT.Rows[count - 1].Cells[0].Value);
            chuoi2 = Convert.ToInt32((chuoi.Remove(0, 2)));
            //loại bỏ ký tự mã HDB đã đặt trong sql là HDB001
            if (chuoi2 + 1 < 10)
                txtMaLoai.Text = "ML00" + (chuoi2 + 1).ToString();
            //phép thử này giúp cộng dồn lên khi thoả mãn đk if, nếu vướt quá 10 thì thực hiện lệnh else if
            else if (chuoi2 + 1 < 100)
                txtMaLoai.Text = "ML0" + (chuoi2 + 1).ToString();
        }
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                LoaiMT n = new LoaiMT();
                n.MaLoai = txtTimkiem.Text;
                dgvLoaiMT.DataSource = lmtb.FindMa(n);
                if (dgvLoaiMT.RowCount < 1)
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvLoaiMT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaLoai.Text = dgvLoaiMT.CurrentRow.Cells["Maloai"].Value.ToString();
                txtTenLoai.Text = dgvLoaiMT.CurrentRow.Cells["Tenloai"].Value.ToString();
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
            if (string.IsNullOrWhiteSpace(txtMaLoai.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã loại máy tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaLoai.Focus();
                return false;//người dùng chưa nhập nên false
            }
            if (string.IsNullOrWhiteSpace(txtTenLoai.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên loại máy tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenLoai.Focus();
                return false;
            }
            return true;
        }

        private void btnNhapmoi_Click(object sender, EventArgs e)
        {
            SinhMaTuDong();
            txtTenLoai.Text = "";
        }

        

        private void dgvLoaiMT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaLoai.Text = dgvLoaiMT.CurrentRow.Cells["MaLoai"].Value.ToString();
                txtTenLoai.Text = dgvLoaiMT.CurrentRow.Cells["TenLoai"].Value.ToString();

                btnXoa.Enabled = true;
                btnThem.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng chọn bên trong bảng", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void txtMaLoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTenLoai.Focus();
            }
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {

        }
    }



}
