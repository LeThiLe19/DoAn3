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
using DoAn2.DAL;

namespace DoAn2.View
{
    public partial class frmQLHoaDonBan : Form
    {
        public frmQLHoaDonBan()
        {
            InitializeComponent();
        }
        #region Khai bao bien
        HoaDonBanBUS hdb;
        NhanVienBUS nb = new NhanVienBUS(Program.stcon);
        List<NhanVien> nv;
        List<KhachHang> kh;
        List<HoaDonBan> hd;
        List<ChiTietHDB> ct;
        List<MayTinh> al;
        int tongtien = 0;
        int soluong = 0;
        private List<ChiTietHDB> lct;
        DataTable dt = new DataTable();
        DataTable dt2;
        #endregion

        #region Load du lieu
        private void frmNew_Load(object sender, EventArgs e)
        {
            hdb = new HoaDonBanBUS(Program.stcon);
            al = hdb.GetMayTinh();
            cbMayTinh.DataSource = al;
            cbMayTinh.ValueMember = "MaMT";
            cbMayTinh.DisplayMember = "MaMT";
            nv = hdb.GetNhanViens();
            cbNhanvien.DataSource = nv;
            cbNhanvien.ValueMember = "MaNV";
            cbNhanvien.DisplayMember = "MaNV";
            kh = hdb.GetKhachHang();
            cbKhachang.DataSource = kh;
            cbKhachang.ValueMember = "MaKH";
            cbKhachang.DisplayMember = "MaKH";
            cbNhanvien.Text = "";
            txtTenNV.Text = "";
            cbKhachang.Text = "";
            dtThoigianB.Value = DateTime.Now;
            txtTenKH.Text = "";
            txtDiachi.Text = "";
            cbMayTinh.Text = "";
            txtSoLuong.Text = "";
            txtGiaban.Text = "";
            txtTongtien.Text = "0";

            dt2 = new DataTable();
            dt2.Columns.Add("MaHDB", typeof(string));
            dt2.Columns.Add("MaMT", typeof(string));
            dt2.Columns.Add("TenMT", typeof(string));
            dt2.Columns.Add("Soluong", typeof(int));
            dt2.Columns.Add("Giaban", typeof(float));
            dt2.Columns.Add("Tongtien", typeof(float));


        }
        private void data_load()
        {
            hdb = new HoaDonBanBUS(Program.stcon);
            //ct = hdb.GetCTHoaDonMa(txtMaHDB.Text.ToString());
            dgvHoaDonBan.DataSource = hdb.GetCTHoaDonH(txtMaHDB.Text.ToString());

        }


        #endregion

        #region Envent change
        private void txtMaHDB_TextChanged(object sender, EventArgs e)
        {
            data_load();
        }

        private void cbNhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            NhanVien n = nv.Find(m => m.MaNV == cbNhanvien.SelectedValue.ToString());
            if (n != null)
            {
                txtTenNV.Text = n.TenNV;
            }
        }

        private void cbKhachang_SelectedIndexChanged(object sender, EventArgs e)
        {
            KhachHang k = kh.Find(m => m.MaKH == cbKhachang.SelectedValue.ToString());
            if (k != null)
            {
                txtTenKH.Text = k.TenKH;
                txtDiachi.Text = k.Diachi;

            }
        }
        #endregion

        private void btnThem_HD_Click(object sender, EventArgs e)
        {
            try
            {

                HoaDonBan h = new HoaDonBan();
                ChiTietHDB ct = new ChiTietHDB();

                h.MaHDB = txtMaHDB.Text;
                h.MaKH = cbKhachang.SelectedValue.ToString();
                h.MaNV = cbNhanvien.SelectedValue.ToString();
                h.Nam = dtThoigianB.Value.Year;
                h.Thang = dtThoigianB.Value.Month;
                h.Ngay = dtThoigianB.Value.Day;
                tongtien = CheckOut();
                h.Tongtien = tongtien;
                hdb.AddHoaDon(h);
                hdb.AddAllDetails(dt2);
                dt2.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            nhapmoi();
        }

        private void cbMayTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            MayTinh a = al.Find(m => m.MaMT == cbMayTinh.SelectedValue.ToString());
            if (a != null)
            {
                txtTenMT.Text = a.TenMT;
                txtGiaban.Text = a.Giaban.ToString();
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            MayTinh a = al.Find(m => m.MaMT == cbMayTinh.SelectedValue.ToString());
            try
            {
                if (txtSoLuong.Text != "")
                {
                    if (int.Parse(txtSoLuong.Text) > a.Soluong)
                    {
                        MessageBox.Show("Bạn đã nhập quá số lượng trong kho !", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSoLuong.Focus();
                        txtSoLuong.Text = "0";
                        txtTongtien.Clear();
                    }
                    else
                    {
                        int s = int.Parse(txtGiaban.Text) * int.Parse(txtSoLuong.Text);
                        txtTongtien.Text = s.ToString();
                        //a.Soluong = a.Soluong - int.Parse(txtSoLuong.Text);
                        //hdb.UpdateSL(a);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn phải nhập số nguyên !", "Thông báo", MessageBoxButtons.OK);
                txtSoLuong.Focus();
            }
        }

        private void btnThemCTHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbMayTinh.Text == "")
                {
                    DataHelper dh = new DataHelper(Program.stcon);
                    txtMaHDB.Text = dh.CreateKey("HDB");
                    DataRow a = dt2.NewRow();
                }
                else
                {
                    DataRow a = dt2.NewRow();
                    a["MaHDB"] = txtMaHDB.Text;
                    a["MaMT"] = cbMayTinh.SelectedValue;
                    a["TenMT"] = txtTenMT.Text;
                    a["Soluong"] = txtSoLuong.Text;
                    a["Giaban"] = txtGiaban.Text;
                    a["Tongtien"] = txtTongtien.Text;

                    tongtien += int.Parse(txtTongtien.Text);
                    txtTongthanhtoan.Text = tongtien.ToString();
                    dt2.Rows.Add(a);
                    dgvHoaDonBan.DataSource = dt2;
                    cbMayTinh.Text = "";
                    txtTenMT.Text = "";
                    txtSoLuong.Text = "";
                    txtGiaban.Text = "";
                    txtTongtien.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã nhập máy tính đó");
            }

            if (dgvHoaDonBan.Rows.Count > 1)
            {

                dgvHoaDonBan.CurrentCell = dgvHoaDonBan.Rows[dgvHoaDonBan.Rows.Count - 1].Cells[0];
            }

        }
        private void nhapmoi()
        {

            //DataHelper dh = new DataHelper(Program.stcon);
            //txtMaHDB.Text = dh.CreateKey("HDB");
            txtMaHDB.Text = "";
            cbNhanvien.Text = "";
            txtTenNV.Text = "";
            cbKhachang.Text = "";
            dtThoigianB.Value = DateTime.Now;
            txtTenKH.Text = "";
            txtDiachi.Text = "";
            cbMayTinh.Text = "";
            txtTenMT.Text = "";
            txtSoLuong.Text = "";
            txtGiaban.Text = "";
            txtTongtien.Text = "";
        }

        private void btnXoaSPmoinhap_Click(object sender, EventArgs e)
        {
            dgvHoaDonBan.Rows.RemoveAt(dgvHoaDonBan.CurrentRow.Index);
            int tt = 0;
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                tt += int.Parse(dt2.Rows[i]["Tongtien"].ToString());
                txtTongthanhtoan.Text = tt.ToString();
            }
            if (dgvHoaDonBan.Rows.Count == 0)
            {
                txtTongthanhtoan.Text = "0";
            }
        }

        private void dgvHoaDonBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cbMayTinh.Text = dgvHoaDonBan.CurrentRow.Cells["MaMT"].Value.ToString();
                txtTenMT.Text = dgvHoaDonBan.CurrentRow.Cells["TenMT"].Value.ToString();
                txtSoLuong.Text = dgvHoaDonBan.CurrentRow.Cells["Soluong"].Value.ToString();
                txtGiaban.Text = dgvHoaDonBan.CurrentRow.Cells["Giaban"].Value.ToString();
                txtTongtien.Text = dgvHoaDonBan.CurrentRow.Cells["Tongtien"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng chọn bên trong bảng", "Thông báo", MessageBoxButtons.OK);
            }
        }
        public bool checkData()
        {

            if (string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                MessageBox.Show("Bạn chưa nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoLuong.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbKhachang.Text))
            {
                MessageBox.Show("Bạn chưa nhập nhà sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbKhachang.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbNhanvien.Text))
            {
                MessageBox.Show("Bạn chưa nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbNhanvien.Focus();
                return false;
            }
            return true;//người dùng đã nhập đầy đủ nên true
        }
        private int CheckOut()
        {
            int ressult = 0;
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                ressult += int.Parse(dt2.Rows[i]["Tongtien"].ToString());
            }
            return ressult;
        }
        private void txtSoLuong_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                MessageBox.Show("Bạn chưa nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoLuong.Focus();

            }
        }

        private void txtTongthanhtoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTongtien_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
