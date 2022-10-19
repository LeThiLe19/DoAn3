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
    public partial class frmQLMayTinh : Form
    {
        public frmQLMayTinh()
        {
            InitializeComponent();
        }
        MayTinhBUS mtb;
        List<MayTinh> mt;
        List<LoaiMT> lmt;

        private void frmQLMaytinh_Load(object sender, EventArgs e)
        {
            mtb = new MayTinhBUS(Program.stcon);
            mt = mtb.GetMayTinh();
            dgvMayTinh.DataSource = mt;
            lmt = mtb.GetLoaiMT();
            cboMaloai.DataSource = lmt;
            cboMaloai.DisplayMember = "TenLoai";
            cboMaloai.ValueMember = "MaLoai";
            cboMaloai.Text = "";
        }

        private void cbTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            mtb = new MayTinhBUS(Program.stcon);
            mt = mtb.GetMayTinhMaloai(cboMaloai.SelectedValue.ToString());
            dgvMayTinh.DataSource = mt;
        }

        private void dgvMaytinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMamt.Text = dgvMayTinh.CurrentRow.Cells["MaMT"].Value.ToString();
                txtTenmt.Text = dgvMayTinh.CurrentRow.Cells["TenMT"].Value.ToString();

                txtSoluong.Text = dgvMayTinh.CurrentRow.Cells["Soluong"].Value.ToString();
                txtGianhap.Text = dgvMayTinh.CurrentRow.Cells["Gianhap"].Value.ToString();
                txtGiaban.Text = dgvMayTinh.CurrentRow.Cells["Giaban"].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng chọn bên trong bảng", "Thông báo", MessageBoxButtons.OK);
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                MayTinh maytinh = new MayTinh();
                maytinh.MaLoai = cboMaloai.SelectedValue.ToString();
                maytinh.MaMT = txtMamt.Text;
                maytinh.TenMT = txtTenmt.Text;
                maytinh.Soluong = int.Parse(txtSoluong.Text);
                maytinh.Gianhap = int.Parse(txtGianhap.Text);
                maytinh.Giaban = int.Parse(txtGiaban.Text);
                mtb.AddMayTinh(maytinh);
                mt.Add(maytinh);
                load_data();
                if (dgvMayTinh.Rows.Count > 1)
                {
                    dgvMayTinh.CurrentCell = dgvMayTinh.Rows[dgvMayTinh.Rows.Count - 1].Cells[0];
                }
                MessageBox.Show("Thêm dữ liệu thành công !", "Thông báo", MessageBoxButtons.OKCancel);
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
                MayTinh l = new MayTinh();
                l.MaMT = txtMamt.Text;
                l.TenMT = txtTenmt.Text;
                l.MaLoai = cboMaloai.Text;
                l.Soluong = int.Parse(txtSoluong.Text);
                l.Gianhap = int.Parse(txtGianhap.Text);
                l.Giaban = int.Parse(txtGiaban.Text);
                mtb.EditMayTinh(l);
                load_data();
                dgvMayTinh.CurrentCell = dgvMayTinh.Rows[dgvMayTinh.Rows.Count - 1].Cells[0];
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
                mtb.DeleteMayTinh(txtMamt.Text);
                mt.Remove(mt.Find(l => l.MaMT == txtMamt.Text));

                dgvMayTinh.DataSource = null;
                dgvMayTinh.DataSource = mt;
            }
            txtMamt.Text = "";
            txtTenmt.Text = "";
            cboMaloai.Text = "";
            txtSoluong.Text = "";
            txtGianhap.Text = "";
            txtGiaban.Text = "";
            MessageBox.Show("Delete thành công !", "Thông báo", MessageBoxButtons.OK);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            MayTinh n = new MayTinh();
            n.MaMT = txtTimkiem.Text;
            dgvMayTinh.DataSource = mtb.FindMayTinh(n);
            if (dgvMayTinh.RowCount == 0)
                MessageBox.Show("Không có dữ liệu bạn cần tìm", "Thông báo", MessageBoxButtons.OK);

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
        }

        private void cbMaloai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTenmt.Focus();
            }
        }

        private void txtGianhap_TextChanged(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            int value = int.Parse(txtGianhap.Text, System.Globalization.NumberStyles.AllowThousands);
            txtGianhap.Text = String.Format(culture, "{0:N0}", value);
            txtGianhap.Select(txtGianhap.Text.Length, 0);
        }

        private void txtGiaban_TextChanged(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            int value = int.Parse(txtGiaban.Text, System.Globalization.NumberStyles.AllowThousands);
            txtGiaban.Text = String.Format(culture, "{0:N0}", value);
            txtGiaban.Select(txtGiaban.Text.Length, 0);
        }

        private void txtGianhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && !(e.KeyChar == 8))
                e.Handled = true;
        }

        private void txtGiaban_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && !(e.KeyChar == 8))
                e.Handled = true;
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            txtTimkiem.Clear();
        }

        private void txtTimkiem_Click(object sender, EventArgs e)
        {
            txtTimkiem.Clear();
        }

        private void btnTimkiem_Leave(object sender, EventArgs e)
        {
            txtTimkiem.Text = "Nhập thông tin cần tìm";
        }

        private void txtGianhap_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtSoluong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtGiaban.Focus();
            }
        }

        private void txtTenMT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtGianhap.Focus();
            }
        }

        private void txtGiaban_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGiaban.Text))
            {
                MessageBox.Show("Bạn chưa nhập giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGiaban.Focus();
            }
            if (float.Parse(txtGiaban.Text) < float.Parse(txtGianhap.Text))
            {
                MessageBox.Show("Giá bán phải lớn hơn hoặc bằng giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGiaban.Focus();
            }
        }
        public bool checkData()
        {
            if (string.IsNullOrWhiteSpace(txtTenmt.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên máy tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenmt.Focus();
                return false;//người dùng chưa nhập nên false
            }
            if (string.IsNullOrWhiteSpace(txtGianhap.Text))
            {
                MessageBox.Show("Bạn chưa nhập giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGianhap.Focus();
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtSoluong.Text))
            {
                MessageBox.Show("Bạn chưa nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoluong.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtGiaban.Text))
            {
                MessageBox.Show("Bạn chưa nhập giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGiaban.Focus();
                return false;
            }
            return true;//người dùng đã nhập đầy đủ nên true
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {

        }
    }
}
