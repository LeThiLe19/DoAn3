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
    class KhachHangBUS
    {
        KhachHangDAL kh;
        public KhachHangBUS(string stcon)
        {
            kh = new KhachHangDAL(stcon);
        }
        public DataTable getKhachHang()
        {
            return kh.getKhachHang();
        }
        public void AddKhachHang(KhachHang khach)
        {
            kh.AddKhachHang(khach);
        }
        public List<KhachHang> GetKhachHang()
        {
            return kh.GetKhachHang();
        }
        public List<KhachHang> GetLoaiMa(string makh)
        {
            return kh.GetLoaiMa(makh);
        }
        public DataTable FinMa(KhachHang khach)
        {
            return kh.FindMa(khach);
        }
        public DataTable FindTen(KhachHang khach)
        {
            return kh.FindTen(khach);
        }
        public DataTable FindKhachang(KhachHang tl)
        {
            return kh.FindKhachang(tl);
        }
        public void EditKhachHang(KhachHang khach)
        {
            kh.EditKhachHang(khach);
        }
        public void DeleteKhachHang(string ma)
        {
            kh.DeleteKhachHang(ma);
        }
    }
}
