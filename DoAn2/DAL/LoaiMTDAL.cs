using DoAn2.Entities;
using DoAn2.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn2.DAL
{
    class LoaiMTDAL
    {
        public DataHelper dh;
        public DataTable dt;
        public LoaiMTDAL(string stcon)
        {
            dh = new DataHelper(stcon);
        }
        public List<LoaiMT> GetLoaiMT()
        {
            SqlDataReader dr = dh.ExcuteReader("Select*from LoaiMT");
            List<LoaiMT> l = new List<LoaiMT>();
            while (dr.Read())
            {
                LoaiMT s = new LoaiMT();
                s.MaLoai = dr["MaLoai"].ToString();
                s.TenLoai = dr["TenLoai"].ToString();

                l.Add(s);
            }
            dr.Close();
            dh.Close();
            return l;
        }
        public DataTable getLoaiMT()
        {
            return dh.FillDataTable("Select*from LoaiMT");
        }
        public List<LoaiMT> GetLoaiMa(string ml)
        {
            //dt.Clear();
            dt = dh.FillDataTable("select*from LoaiMT where MaLoai='" + ml + "'");
            List<LoaiMT> l = new List<LoaiMT>();
            foreach (DataRow dr in dt.Rows)
            {
                LoaiMT s = new LoaiMT();
                s.MaLoai = dr["MaLoai"].ToString();
                s.TenLoai = dr["TenLoai"].ToString();

            }

            return l;
        }
        public void AddLoaiMT(LoaiMT lmt)
        {
            dh.ExcuteNonQuery("insert into LoaiMT values('" + lmt.MaLoai + "','" + lmt.TenLoai + "')");

        }
        public void DelteLoaiMT(string ma)
        {
            dh.ExcuteNonQuery("Delete from LoaiMT where MaLoai='" + ma + "'");
        }

        public void EditLoaiMT(LoaiMT lmt)
        {
            dh.ExcuteNonQuery("update LoaiMT set MaLoai='" + lmt.MaLoai + "',TenLoai='" + lmt.TenLoai + "'where MaLoai='" + lmt.MaLoai + "'");
        }
        public DataTable FindMa(LoaiMT lmt)
        {
            return dh.FillDataTable("select * from LoaiMT  where MaLoai='" + lmt.MaLoai + "'");
        }
        public DataTable FindTen(LoaiMT lsp)
        {
            return dh.FillDataTable("select * from LoaiMT where TenLoai like N'%" + lsp.TenLoai + "%'");
        }
        public void SaveChangeLoaiMT(DataTable dt = null)
        {
            if (dt == null)
            {
                dh.UpdateDataTableToDataBase(this.dt, "LoaiMT ");
            }
            else
            {
                dh.UpdateDataTableToDataBase(dt, "LoaiMT ");
            }
        }
    }

}
