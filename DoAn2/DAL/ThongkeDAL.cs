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
    class ThongkeDAL
    {
        public DataHelper dh;
        public DataTable dt;
        public ThongkeDAL(string stcon)
        {
            dh = new DataHelper(stcon);
        }
        public DataTable GetThongKe_HDB(HoaDonBan h1, HoaDonBan h2)
        {
            string sql = string.Format("exec thongkeB '{0}/{1}/{2}','{3}/{4}/{5}'", h1.Nam, h1.Thang, h1.Ngay, h2.Nam, h2.Thang, h2.Ngay);
            dt = dh.FillDataTable(sql);
            return dt;

        }
        public DataTable GetThongKe_LX(HoaDonBan h1, HoaDonBan h2)
        {
            string sql = string.Format("exec ThongkeLX '{0}/{1}/{2}','{3}/{4}/{5}'", h1.Nam, h1.Thang, h1.Ngay, h2.Nam, h2.Thang, h2.Ngay);
            dt = dh.FillDataTable(sql);
            return dt;

        }
        public DataTable GetThongKe_HDN(HoaDonNhap h1, HoaDonNhap h2)
        {
            string sql = string.Format("exec Pr_LX '{0}/{1}/{2}','{3}/{4}/{5}'", h1.Nam, h1.Thang, h1.Ngay, h2.Nam, h2.Thang, h2.Ngay);
            dt = dh.FillDataTable(sql);
            return dt;
        }
    }
}
