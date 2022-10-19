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
    class NhanVienBUS
    {
        NhanVienDAL nd;
        public NhanVienBUS(string stcon)
        {
            nd = new NhanVienDAL(stcon);
        }
        public List<NhanVien> GetNhanViens()
        {
            return nd.GetNhanViens();
        }
        public DataTable GetNhaVien()
        {
            return nd.GetNhaVien();
        }
        //public List<NhanVien> GetNhaVienMa(string manv)
        //{
        //    return nd.GetNhaVienMa(manv);
        //}
        public DataTable GetNhaVienMa(string manv)
        {
            return nd.GetNhaVienMa(manv);
        }
        public DataTable FindNhanvien(NhanVien tl)
        {
            return nd.FindNhanvien(tl);
        }
        public void DeleteNhaVien(string ma)
        {
            nd.DeleteNhaVien(ma);
        }
        public void AddNhanVien(NhanVien vien)
        {
            nd.AddNhanVien(vien);
        }
        public void EditNhanVien(NhanVien n)
        {
            nd.EditNhanVien(n);
        }
    }
}
