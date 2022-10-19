using DoAn2.Entities;
using DoAn2.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn2.BUS
{
    class HoaDonBanBUS
    {
        MayTinhDAL mtd;
        ChiTietHDBDAL ctd;
        HoaDonBanDAL hdd;
        NhanVienDAL nv;
        KhachHangDAL kh;
        public HoaDonBanBUS(string stcon)
        {
            hdd = new HoaDonBanDAL(stcon);
            ctd = new ChiTietHDBDAL(stcon);
            mtd = new MayTinhDAL(stcon);
            nv = new NhanVienDAL(stcon);
            kh = new KhachHangDAL(stcon);
        }
        public List<MayTinh> GetMayTinh()
        {
            return mtd.GetMayTinh();
        }
        public List<NhanVien> GetNhanViens()
        {
            return nv.GetNhanViens();
        }
        public DataTable GetNhaVien()
        {
            return nv.GetNhaVien();
        }
        public List<KhachHang> GetKhachHang()
        {
            return kh.GetKhachHang();
        }
        public void AddCTHoaDon(ChiTietHDB l)
        {
            ctd.AddCTHoaDon(l);

        }
        public void AddAllDetails(DataTable dt)
        {
            ctd.AddAllDetails(dt);

        }
        public void AddHoaDon(HoaDonBan h)
        {
            hdd.AddHoaDon(h);
        }
        public DataTable GetCTHoaDonH()
        {
            return ctd.GetCTHoaDonH();
        }
        public DataTable GetCTHoaDonH(string mahoadon)
        {
            return ctd.GetCTHoaDonH(mahoadon);
        }
        public DataTable GetHoaDonH(string mahoadon)
        {
            return hdd.GetHoaDonH(mahoadon);
        }
        public DataTable GetHoaDonH()
        {
            return hdd.GetHoaDonH();
        }
        public void DeleteHoaDon(string ma)
        {
            ctd.DeleteCTHoaDon(ma);
            hdd.DeleteHoaDon(ma);
        }
        public void EditHoaDon(HoaDonBan h)
        {
            hdd.EditHoaDon(h);
        }
        public void UpdateSL(MayTinh h)
        {
            mtd.UpdateSL(h);
        }
        public void DeleteCTHoaDon(string ma)
        {
            ctd.DeleteCTHoaDon(ma);
        }
        public void UpdateTong(HoaDonBan h)
        {
            hdd.UpdateTong(h);
        }
        public DataTable FindHDB(HoaDonBan tl)
        {
            return hdd.FindHDB(tl);
        }
        public void EditMayTinh(MayTinh maytinh)
        {
            mtd.EditMayTinh(maytinh);
        }
        public void DeleteCTHoaDonMA(MayTinh a)
        {
            ctd.DeleteCTHoaDonMA(a);
        }
        public DataTable FindMayTinh(MayTinh g)
        {
            return mtd.FindMayTinh(g);
        }
        public DataTable GetThongKe_HDB(HoaDonBan h1, HoaDonBan h2)
        {
            return hdd.GetThongKe_HDB(h1, h2);
        }
    }
    
}
