using DoAn2.Entities;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn2.DAL
{
    class NhanVienDAL
    {
        public DataHelper dh;
        public DataTable dt;
        public NhanVienDAL(string stcon)
        {
            dh = new DataHelper(stcon);
        }

        public List<NhanVien> GetNhanViens()
        {
            //SqlDataReader dr = dh.ExcuteReader("Select MaNV as 'Mã nhân viên', TenNV as 'Tên nhân viên', Gioitinh as 'Giới tính'," +
            //    "Sdt as 'Số điện thoại', Diachi as 'Địa chỉ'from NhanVien");
            SqlDataReader dr = dh.ExcuteReader("Select*from NhanVien");
            List<NhanVien> l = new List<NhanVien>();
            while (dr.Read())
            {
                NhanVien s = new NhanVien();
                s.MaNV = dr["MaNV"].ToString();
                s.TenNV = dr["TenNV"].ToString();
                s.Diachi = dr["Diachi"].ToString();
                s.Sdt = dr["Sdt"].ToString(); 
                l.Add(s);
            }
            dr.Close();
            dh.Close();
            return l;
        }
        public DataTable GetNhaVien()
        {
            string sql = "select* from NhanVien";
            dt = dh.FillDataTable(sql);//đổ dữ liệu vào kho
            return dt;
        }
        public DataTable GetNhaVienMa(string manv)
        {
            string sql = "select* from NhanVien where MaNV = '" + manv + "'";
            dt = dh.FillDataTable(sql);//đổ dữ liệu vào kho
            return dt;
        }
        //public List<NhanVien> GetNhaVienMa(string manv)
        //{
        //    //dt.Clear();
        //    dt = dh.FillDataTable("select*from NhanVien where MaNV='" + manv + "'");
        //    List<NhanVien> l = new List<NhanVien>();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        NhanVien s = new NhanVien();
        //        s.MaNV = dr["MaNV"].ToString();
        //        s.TenNV = dr["TenNV"].ToString();
        //        s.Gioitinh = dr["Gioitinh"].ToString();
        //        s.Sdt = dr["Sdt"].ToString();
        //        s.Diachi = dr["Diachi"].ToString();
        //        l.Add(s);
        //    }
        //    return l;
        //}
        public void AddNhanVien(NhanVien vien)
        {
            dh.ExcuteNonQuery("insert into NhanVien values('" + vien.MaNV + "',N'" + vien.TenNV + "',N'"  + vien.Diachi + "',N'" + vien.Sdt + "')");
        }

        public void EditNhanVien(NhanVien n)
        {
            dh.ExcuteNonQuery("update NhanVien set MaNV='" + n.MaNV + "',TenNV=N'" + n.TenNV + "', Diachi = N'" + n.Diachi + "'where MaNV='" + n.MaNV + "'");
        }
        public void DeleteNhaVien(string ma)
        {
            dh.ExcuteNonQuery("Delete from NhanVien where MaNV='" + ma + "'");
        }
        public DataTable FindNhanvien(NhanVien tl)
        {
            return dh.FillDataTable("select * from NhanVien where MaNV='" + tl.MaNV + "' or TenNV like N'%" + tl.TenNV + "%' or Sdt = '" + tl.Sdt + "'");
        }
        public void SaveChangeNhanvien(DataTable dt = null)
        {
            if (dt == null)
            {
                dh.UpdateDataTableToDataBase(this.dt, "NhanVien");
            }
            else
            {
                dh.UpdateDataTableToDataBase(dt, "NhanVien");
            }
        }
    }
}
