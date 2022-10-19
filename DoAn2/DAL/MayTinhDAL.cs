using DoAn2.Entities;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn2.DAL;

namespace DoAn2.DAL
{
    class MayTinhDAL
    {
        public DataHelper dh;
        public DataTable dt;
        public MayTinhDAL(string stcon)
        {
            dh = new DataHelper(stcon);
        }
        public List<MayTinh> GetMayTinh()
        {
            SqlDataReader dr = dh.ExcuteReader("Select*from MayTinh");
            List<MayTinh> l = new List<MayTinh>();
            while (dr.Read())
            {
                MayTinh s = new MayTinh();
                s.MaMT = dr["MaMT"].ToString();
                s.TenMT = dr["TenMT"].ToString();
                s.Soluong = int.Parse(dr["Soluong"].ToString());
                s.Gianhap = int.Parse(dr["Gianhap"].ToString());
                s.Giaban = int.Parse(dr["Giaban"].ToString());
                s.MaLoai = dr["MaLoai"].ToString();
                l.Add(s);

            }
            dr.Close();
            dh.Close();
            return l;
        }
        public List<MayTinh> GetMayTinhMaLoai(string MaLoai)
        {
            //dt.Clear();
            dt = dh.FillDataTable("Select*from MayTinh where MaLoai ='" + MaLoai + "'");
            List<MayTinh> l = new List<MayTinh>();
            foreach (DataRow dr in dt.Rows)
            {
                MayTinh s = new MayTinh();
                s.MaMT = dr["MaMT"].ToString();
                s.TenMT = dr["TenMT"].ToString();
                s.Soluong = int.Parse(dr["Soluong"].ToString());
                s.Gianhap = int.Parse(dr["Gianhap"].ToString());
                s.Giaban = int.Parse(dr["Giaban"].ToString());
                s.MaLoai = dr["MaLoai"].ToString();
                l.Add(s);
            }
            return l;
        }
        public void AddMayTinh(MayTinh g)
        {
            dh.ExcuteNonQuery("insert into MayTinh values('" + g.MaMT + "','" + g.TenMT + "','" + g.Soluong + "','" + g.Gianhap + "','" + g.Giaban + "')");
        }
        public void DeleteMayTinh(string ma)
        {
            dh.ExcuteNonQuery("Delete from MayTinh where MaMT='" + ma + "'");
        }
        public void EditMayTinh(MayTinh g)
        {
            dh.ExcuteNonQuery("update MayTinh set MaMT='" + g.MaMT + "',TenMT='" + g.TenMT + "', Soluong = '" + g.Soluong + "', Gianhap = '" + g.Gianhap + "', Giaban = '" + g.Giaban + "', MaLoai = '" + g.Giaban + "'where MaMT='" + g.MaMT + "'");
        }
        public DataTable FindMayTinh(MayTinh g)
        {
            return dh.FillDataTable("select * from MayTinh where MaMT='" + g.MaMT + "'or TenMT like '%" + g.TenMT + "%'");
        }
        public void SaveChangMayTinh(DataTable dt = null)
        {
            if (dt == null)
            {
                dh.UpdateDataTableToDataBase(this.dt, "MayTinh");
            }
            else
            {
                dh.UpdateDataTableToDataBase(dt, "MayTinh");
            }
        }

        //internal DataTable GetThongKe_HDB(HoaDonBan h1, HoaDonBan h2)
        //{
        //    throw new NotImplementedException();
        //}

        public void UpdateSL(MayTinh a)
        {
            dh.ExcuteNonQuery("update MayTinh set Soluong='" + a.Soluong + "'where MaMT='" + a.MaMT + "'");
        }
    }
}
