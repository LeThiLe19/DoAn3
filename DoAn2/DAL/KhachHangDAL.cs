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
    class KhachHangDAL
    {
        public DataHelper dh;
        public DataTable dt;
        public KhachHangDAL(string stcon)
        {
            dh = new DataHelper(stcon);
        }
        public List<KhachHang> GetKhachHang()
        {
            SqlDataReader dr = dh.ExcuteReader("Select*from khachHang");
            List<KhachHang> l = new List<KhachHang>();
            while (dr.Read())
            {
                KhachHang kh = new KhachHang();
                kh.MaKH = dr["maKH"].ToString();
                kh.TenKH = dr["tenKH"].ToString();
                kh.Diachi = dr["diachi"].ToString();
                kh.Sdt = dr["sdt"].ToString();
                l.Add(kh);
            }
            dr.Close();
            dh.Close();
            return l;
        }
        public DataTable GetKhachHang(KhachHang kh)
        {
            string sql = "select* from KhachHang";
            dt = dh.FillDataTable(sql);
            return dt;
        }
        public DataTable getKhachHang()
        {
            return dh.FillDataTable("Select*from KhachHang");
        }
        public List<KhachHang> GetLoaiMa(string ml)
        {
            //dt.Clear();
            dt = dh.FillDataTable("select * from KhachHang where MaKH='" + ml + "'");
            List<KhachHang> l = new List<KhachHang>();
            foreach (DataRow dr in dt.Rows)
            {
                KhachHang kh = new KhachHang();
                kh.MaKH = dr["MaKH"].ToString();
                kh.TenKH = dr["TenKH"].ToString();
                kh.Diachi = dr["DiaChi"].ToString();
                kh.Sdt = dr["SDT"].ToString();
            }
            return l;
        }
        public void AddKhachHang(KhachHang kh)
        {
            dh.ExcuteNonQuery("insert into KhachHang values('" + kh.MaKH + "','" + kh.TenKH + "','" + kh.Diachi + "', '" + kh.Sdt + "')");
        }
        public void DeleteKhachHang(string ma)
        {
            dh.ExcuteNonQuery("Delete from KhachHang where MaKH='" + ma + "'");
        }
        public DataTable FindKhachang(KhachHang tl)
        {
            return dh.FillDataTable("select * from KhachHang where MaKH='" + tl.MaKH + "' or TenKH like N'%" + tl.TenKH + "%' or Sdt = '" + tl.Sdt + "'");
        }
        public void EditKhachHang(KhachHang kh)
        {
            dh.ExcuteNonQuery("update KhachHang set MaKH='" + kh.MaKH + "',TenKH='" + kh.TenKH + "',DiaChi='" + kh.Diachi + "',SDT='" + kh.Sdt + "'where MaKH='" + kh.MaKH + "'");
        }
        public DataTable FindMa(KhachHang kh)
        {
            return dh.FillDataTable("select * from KhachHang  where MaKH='" + kh.MaKH + "'");
        }
        public DataTable FindTen(KhachHang kh)
        {
            return dh.FillDataTable("select * from KhachHang where TenKH like N'%" + kh.TenKH + "%'");
        }
        public void SaveChangeKhachHang(DataTable dt = null)
        {
            if (dt == null)
            {
                dh.UpdateDataTableToDataBase(this.dt, "KhachHang ");
            }
            else
            {
                dh.UpdateDataTableToDataBase(dt, "KhachHang ");
            }
        }
    }
}
