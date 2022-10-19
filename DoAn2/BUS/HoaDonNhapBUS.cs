using DoAn2.DAL;
using DoAn2.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn2.BUS
{
    class HoaDonNhapBUS
    {
        MayTinhDAL mtd;
        ChiTietHDNDAL ctd;
        HoaDonNhapDAL hdd;
        NhanVienDAL nv;
        NCCDAL ncc;
        public HoaDonNhapBUS(string stcon)
        {
            hdd = new HoaDonNhapDAL(stcon);
            ctd = new ChiTietHDNDAL(stcon);
            mtd = new MayTinhDAL(stcon);
            ncc = new NCCDAL(stcon);
            nv = new NhanVienDAL(stcon);
        }
        public List<MayTinh> GetMayTinh()
        {
            return mtd.GetMayTinh();
        }
        public List<NhanVien> GetNhanViens()
        {
            return nv.GetNhanViens();
        }
        public List<NCC> GetNCC()
        {
            return ncc.GetNCC();
        }
        public void AddCTHoaDon(ChiTietHDN l)
        {
            ctd.AddCTHoaDon(l);
        }
        public void AddHoaDon(HoaDonNhap h)
        {
            hdd.AddHoaDon(h);
        }
        public void AddAllDetails(DataTable dt2, params object[] values)
        {
            ctd.AddAllDetails(dt2);

        }
        public DataTable GetHoaDon()
        {
            return hdd.GetHoaDon();
        }
        public DataTable GetoaDon(string mahoadon)
        {
            return hdd.GetHoaDon(mahoadon);
        }
        public void DeleteHoaDon(string ma)
        {
            ctd.DeleteCTHoaDon(ma);
            hdd.DeleteHoaDon(ma);
        }
        public void EditHoaDon(HoaDonNhap h)
        {
            hdd.EditHoaDon(h);
        }
        public void DeleteCTHoaDon(string ma)
        {
            ctd.DeleteCTHoaDon(ma);
        }
        public void UpdateTong(HoaDonNhap h)
        {
            hdd.UpdateTong(h);
        }
        public DataTable FindHDN(HoaDonNhap tl)
        {
            return hdd.FindHDN(tl);
        }
        public DataTable GetCTHoaDon()
        {
            return ctd.GetCTHoaDon();
        }
        public DataTable GetCTHoaDon(string mahoadon)
        {
            return ctd.GetCTHoaDon(mahoadon);
        }
        public void DeleteCTHoaDonMA(MayTinh a)
        {
            ctd.DeleteCTHoaDonMA(a);
        }
        public void DeleteMayTinh(string ma)
        {
            mtd.DeleteMayTinh(ma);
        }
        public DataTable FindMayTinh(MayTinh g)
        {
            return mtd.FindMayTinh(g);
        }
        public void UpdateSL(MayTinh h)
        {
            mtd.UpdateSL(h);
        }
        public DataTable GetThongKe_HDN(HoaDonNhap h1, HoaDonNhap h2)
        {
            return hdd.GetThongKe_HDN(h1, h2);
        }
    }
}
