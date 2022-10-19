using DoAn2.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn2.DAL
{
    class HoaDonNhapDAL
    {
        public DataHelper dh;
        public DataTable dt;
        public HoaDonNhapDAL(string stcon)
        {
            dh = new DataHelper(stcon);
        }
        public DataTable GetHoaDon()
        {
            string sql = "Select MaHDN,NhanVien.MaNV, NCC.maNCC,TenNCC, NCC.Diachi, Tongtien, ThoigianN " +
                "from NCC inner join HoaDonNhap on NCC.maNCC=HoaDonNhap.maNCC inner join NhanVien on HoaDonNhap.MaNV=NhanVien.MaNV";
            dt = dh.FillDataTable(sql);
            return dt;

        }
        public DataTable GetHoaDon(string mahoadon)
        {
            string sql = "Select MaHDN,NhanVien.MaNV, NCC.maNCC,NCC.TenNCC,NCC.Diachi, Tongtien, ThoigianN " +
                "from NCC inner join HoaDonNhap on NCC.maNCC=HoaDonNhap.maNCC inner join NhanVien on HoaDonNhap.MaNV=NhanVien.MaNV where MaHDN='" + mahoadon + "'";
            dt = dh.FillDataTable(sql);
            return dt;
        }
        public void AddHoaDon(HoaDonNhap hd)
        {
            string sql = string.Format("insert into HoaDonNhap(MaHDN,maNCC,MaNV,ThoigianN,Tongtien) values('{0}','{1}','{2}','{3}/{4}/{5}','{6}');", hd.MaHDN, hd.maNCC, hd.MaNV, hd.Nam, hd.Thang, hd.Ngay, hd.Tongtien);
            dh.ExcuteNonQuery(sql);
            //dh.ExcuteNonQuery("insert into HoaDonNhap values('" + hd.MaHDN + "','" + hd.MaNV + "','" + hd.maNCC + "','" + hd.ThoigianN + "','" + hd.Tongtien + "')");
        }
        public void DeleteHoaDon(string ma)
        {
            dh.ExcuteNonQuery("Delete from HoaDonNhap where MaHDN='" + ma + "'");
        }
        public void EditHoaDon(HoaDonNhap h)
        {
            dh.ExcuteNonQuery("update HoaDonNhap set MaHDB='" + h.MaHDN + "',MaNV='" + h.MaNV + "', MaNCC = '" + h.maNCC + "'where MaHDN='" + h.MaHDN + "'");
        }
        public DataTable FindHDN(HoaDonNhap tl)
        {
            return dh.FillDataTable("Select MaHDN,NhanVien.MaNV, NCC.maNCC,TenNCC, NCC.Diachi, Tongtien, ThoigianN " +
                "from NCC inner join HoaDonNhap on NCC.maNCC=HoaDonNhap.maNCC inner join NhanVien on HoaDonNhap.MaNV=NhanVien.MaNV where MaHDN='" + tl.MaHDN + "' or NhanVien.MaNV='" + tl.MaNV + "' or NhaCungcap.MaNCC='" + tl.maNCC + "'");
        }

        public void UpdateTong(HoaDonNhap h)
        {
            dh.ExcuteNonQuery("update HoaDonNhap set Tongtien='" + h.Tongtien + "'where MaHDN='" + h.MaHDN + "'");

        }
        public DataTable GetThongKe_HDN(HoaDonNhap h1, HoaDonNhap h2)
        {
            string sql = string.Format("exec ThongkeN '{0}/{1}/{2}','{3}/{4}/{5}'", h1.Nam, h1.Thang, h1.Ngay, h2.Nam, h2.Thang, h2.Ngay);
            dt = dh.FillDataTable(sql);
            return dt;
        }
    }
}
