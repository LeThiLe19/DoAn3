using DoAn2.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn2.DAL
{
    class HoaDonBanDAL
    {
        public DataHelper dh;
        public DataTable dt;
        public HoaDonBanDAL(string stcon)
        {
            dh = new DataHelper(stcon);
        }
        public DataTable GetHoaDonH()
        {
            string sql = "Select MaHDB,NhanVien.MaNV, KhachHang.MaKH,TenKH, KhachHang.Diachi, Tongtien, ThoigianB " +
                "from KhachHang inner join HoaDonBan on KhachHang.MaKH=HoaDonBan.MaKH inner join NhanVien on HoaDonBan.MaNV=NhanVien.MaNV";
            dt = dh.FillDataTable(sql);//đổ dữ liệu vào kho(
            //dh.Close();
            return dt;
        }
        public DataTable GetHoaDonH(string mahoadon)
        {
            string sql = "Select MaHDB,NhanVien.MaNV,KhachHang.MaKH,TenKH, KhachHang.Diachi, Tongtien, ThoigianB " +
                "from KhachHang inner join HoaDonBan on KhachHang.MaKH=HoaDonBan.MaKH inner join NhanVien on HoaDonBan.MaNV=NhanVien.MaNV where MaHDB='" + mahoadon + "'";
            dt = dh.FillDataTable(sql);//đổ dữ liệu vào kho
            //dh.Close();
            return dt;
        }
        public void AddHoaDon(HoaDonBan hd)
        {
            string sql = string.Format("insert into HoaDonBan(MaHDB,MaKH,MaNV,ThoigianB,Tongtien) values('{0}','{1}','{2}','{3}/{4}/{5}','{6}');", hd.MaHDB, hd.MaKH, hd.MaNV, hd.Nam, hd.Thang, hd.Ngay, hd.Tongtien);
            dh.ExcuteNonQuery(sql);
        }
        public void DeleteHoaDon(string ma)
        {
            dh.ExcuteNonQuery("Delete from HoaDonBan where MaHDB='" + ma + "'");
        }
        public void EditHoaDon(HoaDonBan h)
        {
            dh.ExcuteNonQuery("update HoaDonBan set MaHDB='" + h.MaHDB + "',MaNV='" + h.MaNV + "', MaKH = '" + h.MaKH + "', ThoigianB = '" + "'where MaHDB='" + h.MaHDB + "'");
        }
        public DataTable FindHDB(HoaDonBan tl)
        {
            return dh.FillDataTable("Select MaHDB,NhanVien.MaNV,KhachHang.MaKH,TenKH, KhachHang.Diachi, Tongtien, ThoigianB " +
                "from KhachHang inner join HoaDonBan on KhachHang.MaKH=HoaDonBan.MaKH inner join NhanVien on HoaDonBan.MaNV=NhanVien.MaNV where HoaDonBan.MaHDB='" + tl.MaHDB + "' or NhanVien.MaNV = '" + tl.MaNV + "'or KhachHang.MaKH='" + tl.MaKH + "'");
        }
        public void UpdateTong(HoaDonBan h)
        {
            dh.ExcuteNonQuery("update HoaDonBan set Tongtien='" + h.Tongtien + "'where MaHDB='" + h.MaHDB + "'");

        }
        public DataTable GetThongKe_HDB(HoaDonBan h1, HoaDonBan h2)
        {
            string sql = string.Format("exec thongke '{0}/{1}/{2}','{3}/{4}/{5}'", h1.Nam, h1.Thang, h1.Ngay, h2.Nam, h2.Thang, h2.Ngay);
            dt = dh.FillDataTable(sql);
            return dt;
        }
    }
}
