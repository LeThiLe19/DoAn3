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
    class NCCDAL
    {
        public DataHelper dh;
        public DataTable dt;
        public NCCDAL(string stcon)
        {
            dh = new DataHelper(stcon);
        }
        public List<NCC> GetNCC()
        {
            SqlDataReader dr = dh.ExcuteReader("Select*from NCC");
            List<NCC> l = new List<NCC>();
            while (dr.Read())
            {
                NCC s = new NCC();
                s.MaNCC = dr["MaNCC"].ToString();
                s.TenNCC = dr["TenNCC"].ToString();
                s.Sdt = dr["Sdt"].ToString();
                s.Diachi = dr["Diachi"].ToString();
                l.Add(s);
            }
            dr.Close();
            dh.Close();
            return l;
        }
        public List<NCC> GetNCCMa(string mancc)
        {
            //dt.Clear();
            dt = dh.FillDataTable("select*from NCC where MaNCC='" + mancc + "'");
            List<NCC> l = new List<NCC>();
            foreach (DataRow dr in dt.Rows)
            {
                NCC s = new NCC();
                s.MaNCC = dr["MaNCC"].ToString();
                s.TenNCC = dr["TenNCC"].ToString();
                s.Sdt = dr["Sdt"].ToString();
                s.Diachi = dr["Diachi"].ToString();
                l.Add(s);
            }
            return l;
        }
        public void AddNhaCC(NCC nha)
        {
            dh.ExcuteNonQuery("insert into NCC values('" + nha.MaNCC + "',N'" + nha.TenNCC + "','" + nha.Sdt + "',N'" + nha.Diachi + "')");
        }
        public void EditNCC(NCC n)
        {
            dh.ExcuteNonQuery("update NCC set MaNCC='" + n.MaNCC + "',TenNCC=N'" + n.TenNCC + "', Sdt = '" + n.Sdt + "', Diachi = N'" + n.Diachi + "'where MaNCC='" + n.MaNCC + "'");
        }
        public void DeleteNCC(string ma)
        {
            dh.ExcuteNonQuery("Delete from NCC where MaNV='" + ma + "'");
        }
        public DataTable FindNhaCC(NCC tl)
        {
            return dh.FillDataTable("select * from NCC where MaNCC='" + tl.MaNCC + "' or TenNCC like N'%" + tl.TenNCC + "%' or Sdt = '" + tl.Sdt + "'");
        }
        public void SaveChangeNCC(DataTable dt = null)
        {
            if (dt == null)
            {
                dh.UpdateDataTableToDataBase(this.dt, "NCC");
            }
            else
            {
                dh.UpdateDataTableToDataBase(dt, "NCC");
            }
        }
    }
}
