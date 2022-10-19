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
    public partial class frmQLNCC : Form
    {
        public frmQLNCC()
        {
            InitializeComponent();
        }
        NCCBUS nb;
        List<NCC> nha = new List<NCC>();

        private void frmQLNCC_Load(object sender, EventArgs e)
        {
            load_data();
        }
        private void load_data()
        {
            nb = new NCCBUS(Program.stcon);
            nha = nb.GetNCC();
            dgvNCC.DataSource = nha;
        }

        private void btnThemncc_Click(object sender, EventArgs e)
        {
            if (checkData())
            {
                NCC c = new NCC();
                c.MaNCC = txtMaNCC.Text;
                c.TenNCC = txtTenNCC.Text;
                c.Diachi = txtDiachi.Text;
                c.Sdt = txtSdt.Text;
                
                nb.AddNhaCC(c);
                nha.Add(c);
                load_data();

                if (dgvNCC.Rows.Count > 1)
                {
                    dgvNCC.CurrentCell = dgvNCC.Rows[dgvNCC.Rows.Count - 1].Cells[0];
                    //chuyển đến dòng vừa thêm
                }
                MessageBox.Show("Thêm dữ liệu thành công !", "Thông báo", MessageBoxButtons.OKCancel);
            }
            //try
            //{
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnSuancc_Click(object sender, EventArgs e)
        {
            try
            {
                NCC c = new NCC();
                c.MaNCC = txtMaNCC.Text;
                c.TenNCC = txtTenNCC.Text;
                c.Diachi = txtDiachi.Text;
                c.Sdt = txtSdt.Text;
                
                nb.EditNCC(c);
                load_data();
                dgvNCC.CurrentCell = dgvNCC.Rows[dgvNCC.Rows.Count - 1].Cells[0];
                MessageBox.Show("Update dữ liệu thành công !", "Thông báo", MessageBoxButtons.OKCancel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoancc_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    nb.DeleteNCC(txtMaNCC.Text);
                    nha.Remove(nha.Find(l => l.MaNCC == txtMaNCC.Text));
                    load_data();
                }
                txtMaNCC.Text = "";
                txtTenNCC.Text = "";
                txtDiachi.Text = "";
                txtSdt.Text = "";
                MessageBox.Show("Delete thành công !", "Thông báo", MessageBoxButtons.OK);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SinhMaTuDong()
        {
            int count = 0;
            count = dgvNCC.Rows.Count;//đếm tất cả các dòng trong dgv rồi gán cho count
            string chuoi = "";
            int chuoi2 = 0;
            chuoi = Convert.ToString(dgvNCC.Rows[count - 1].Cells[0].Value);
            chuoi2 = Convert.ToInt32((chuoi.Remove(0, 3)));
            //loại bỏ ký tự mã HDB đã đặt trong sql là NCC001
            if (chuoi2 + 1 < 10)
                txtMaNCC.Text = "Ncc0" + (chuoi2 + 1).ToString();
            //phép thử này giúp cộng dồn lên khi thoả mãn đk if, nếu vướt quá 10 thì thực hiện lệnh else if
            else if (chuoi2 + 1 < 100)
                txtMaNCC.Text = "Ncc0" + (chuoi2 + 1).ToString();
        }

        private void btnNhapmoi_Click(object sender, EventArgs e)
        {
            SinhMaTuDong();
            txtTenNCC.Text = "";
            txtDiachi.Text = "";
            txtSdt.Text = "";
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                NCC n = new NCC();
                n.MaNCC = txtTimkiem.Text;
                n.TenNCC = txtTimkiem.Text;
                n.Sdt = txtTimkiem.Text;
                dgvNCC.DataSource = nb.FindNhaCC(n);
                if (dgvNCC.RowCount < 1)
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

        private void dgvNCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaNCC.Text = dgvNCC.CurrentRow.Cells["MaNCC"].Value.ToString();
                txtTenNCC.Text = dgvNCC.CurrentRow.Cells["TenNCC"].Value.ToString();
                txtSdt.Text = dgvNCC.CurrentRow.Cells["Sdt"].Value.ToString();
                txtDiachi.Text = dgvNCC.CurrentRow.Cells["Diachi"].Value.ToString();

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
            if (string.IsNullOrWhiteSpace(txtTenNCC.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên Album nhạc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenNCC.Focus();
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
        private void txtTimkiem_Click(object sender, EventArgs e)
        {
            txtTimkiem.Clear();
        }

        private void btnTimkiem_Leave(object sender, EventArgs e)
        {
            txtTimkiem.Text = "Nhập thông tin cần tìm";
        }

        private void txtMaNCC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTenNCC.Focus();
            }
        }

        private void txtTenNCC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSdt.Focus();
            }
        }

        private void txtSdt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDiachi.Focus();
            }
        }

        
    }
    
}
