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
    public partial class frmQLHoaDonNhap : Form
    {
        public frmQLHoaDonNhap()
        {
            InitializeComponent();
        }
        
        HoaDonNhapBUS hdb;
        List<NhanVien> nv;
        List<NCC> ncc;
        List<ChiTietHDN> ct;
        List<HoaDonNhap> hd;
        List<MayTinh> mt;
        DataTable dt2;
        int tongtien = 0;

        private void frmQLHoaDonNhap_Load(object sender, EventArgs e)
        {
            hdb = new HoaDonNhapBUS(Program.stcon);
            mt = hdb.GetMayTinh();
            cbMayTinh.DataSource = mt;
            cbMayTinh.ValueMember = "MaMT";
            cbMayTinh.DisplayMember = "MaMT";
            nv = hdb.GetNhanViens();
            cbNhanvien.DataSource = nv;
            cbNhanvien.ValueMember = "MaNV";
            cbNhanvien.DisplayMember = "MaNV";
            ncc = hdb.GetNCC();
            cbNhaCC.DataSource = ncc;
            cbNhaCC.ValueMember = "MaNCC";
            cbNhaCC.DisplayMember = "MaNCC";
            txtMaHDN.Text = "";
            cbNhanvien.Text = "";
            cbNhaCC.Text = "";
            cbMayTinh.Text = "";
            txtTenMT.Text = "";
            txtSoLuong.Text = "";
            txtGianhap.Text = "";
            txtTongtien.Text = "";

            dt2 = new DataTable();
            dt2.Columns.Add("MaHDN", typeof(string));
            dt2.Columns.Add("MaMT", typeof(string));
            dt2.Columns.Add("TenMT", typeof(string));
            dt2.Columns.Add("SoLuong", typeof(int));
            dt2.Columns.Add("Gianhap", typeof(int));
            dt2.Columns.Add("Tongtien", typeof(int));
        }
        private void data_load()
        {
            dgvHoaDonNhap.DataSource = hdb.GetCTHoaDon(txtMaHDN.Text.ToString());

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaHDN_TextChanged(object sender, EventArgs e)
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

        private void cbNhaCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            NCC k = ncc.Find(m => m.MaNCC == cbNhaCC.SelectedValue.ToString());
            if (k != null)
            {
                txtTenNCC.Text = k.TenNCC;
                txtDiachi.Text = k.Diachi;
                //mtxtSdt.Text = k.Sdt;
            }
        }

        private void btnThem_HD_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkData())
                {
                    HoaDonNhap h = new HoaDonNhap();
                    h.MaHDN = txtMaHDN.Text;
                    h.maNCC = cbNhaCC.SelectedValue.ToString();
                    h.MaNV = cbNhanvien.SelectedValue.ToString();
                    h.Nam = dtThoigianN.Value.Year;
                    h.Thang = dtThoigianN.Value.Month;
                    h.Ngay = dtThoigianN.Value.Day;
                    tongtien = CheckOut();
                    h.Tongtien = tongtien;

                    hdb.AddHoaDon(h);
                    hdb.AddAllDetails(dt2);
                    dt2.Rows.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNhapmoi_Click(object sender, EventArgs e)
        {
            txtMaHDN.Text = "";
            cbNhanvien.Text = "";
            cbNhaCC.Text = "";
            cbMayTinh.Text = "";
            txtTenMT.Text = "";
            txtSoLuong.Text = "";
            txtGianhap.Text = "";
            txtTongtien.Text = "";
        }

        private void btnThemCTHD_Click(object sender, EventArgs e)
        {
            if (cbMayTinh.Text == "")
            {
                DataHelper dh = new DataHelper(Program.stcon);
                txtMaHDN.Text = dh.CreateKey("HDN");
                DataRow a = dt2.NewRow();
            }
            else
            {
                DataRow a = dt2.NewRow();
                a["MaHDN"] = txtMaHDN.Text;
                a["MaMT"] = cbMayTinh.SelectedValue;
                a["TenMT"] = txtTenMT.Text;
                a["Soluong"] = txtSoLuong.Text;
                a["Gianhap"] = txtGianhap.Text;
                a["Tongtien"] = txtTongtien.Text;

                tongtien += int.Parse(txtTongtien.Text);
                txtTongthanhtoan.Text = tongtien.ToString();
                dt2.Rows.Add(a);
                dgvHoaDonNhap.DataSource = dt2;

            }

            if (dgvHoaDonNhap.Rows.Count > 1)
            {

                dgvHoaDonNhap.CurrentCell = dgvHoaDonNhap.Rows[dgvHoaDonNhap.Rows.Count - 1].Cells[0];
            }
            cbMayTinh.Text = "";
            txtTenMT.Text = "";
            txtSoLuong.Text = "";
            txtGianhap.Text = "";
            txtTongtien.Text = "";
        }

        private void cbMayTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            MayTinh a = mt.Find(m => m.MaMT == cbMayTinh.SelectedValue.ToString());
            if (a != null)
            {
                txtTenMT.Text = a.TenMT;
                txtGianhap.Text = a.Gianhap.ToString();
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            MayTinh a = mt.Find(m => m.MaMT == cbMayTinh.SelectedValue.ToString());
            try
            {
                if (txtSoLuong.Text != "")
                {
                    if (int.Parse(txtSoLuong.Text) > 1000)
                    {
                        MessageBox.Show("Chỉ cho phép nhập số lượng <1000 !", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSoLuong.Focus();
                        txtSoLuong.Text = "";
                        txtTongtien.Clear();
                    }
                    else
                    {
                        decimal s = decimal.Parse(txtGianhap.Text) * int.Parse(txtSoLuong.Text);
                        txtTongtien.Text = s.ToString();
                        //a.Soluong = a.Soluong + int.Parse(txtSoLuong.Text);
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

        private void btnXoaSPmoinhap_Click(object sender, EventArgs e)
        {
            dgvHoaDonNhap.Rows.RemoveAt(dgvHoaDonNhap.CurrentRow.Index);
            float tt = 0;

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                tt += float.Parse(dt2.Rows[i]["Tongtien"].ToString());
                txtTongthanhtoan.Text = tt.ToString();
            }
            if (dgvHoaDonNhap.Rows.Count == 0)
            {
                txtTongthanhtoan.Text = "0";
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
            if (string.IsNullOrWhiteSpace(cbNhaCC.Text))
            {
                MessageBox.Show("Bạn chưa nhập nhà sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbNhaCC.Focus();
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
    }
}
