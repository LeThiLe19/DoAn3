using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn2.Entities;
using System.Data;
using System.Data.SqlClient;

namespace DoAn2.DAL
{
    class ChiTietHDBDAL
    {
        public DataHelper dh;
        public DataTable dt;
        public ChiTietHDBDAL(string stcon)
        {
            dh = new DataHelper(stcon);
        }
        public DataTable GetCTHoaDonH()
        {
            string sql = "Select HoaDonBan.MaHDB,MayTinh.MaMayTinh,TenMayTinh, ChiTietHDB.Soluong, ChiTietHDB.Giaban, Tongtien " +
                "from MayTinh inner join ChiTietHDB on MayTinh.MaMT=ChiTietHDB.MaMayTinh inner join HoaDonBan on HoaDonBan.MaHDB=ChiTietHDB.MaHDB ";
            dt = dh.FillDataTable(sql);
            return dt;
        }
        public DataTable GetCTHoaDonH(string mahoadon)
        {
            string sql = "Select HoaDonBan.MaHDB,MayTinh.MaMayTinh,TenMayTinh, ChiTietHDB.Soluong, ChiTietHDB.Giaban, Tongtien " +
                "from MayTinh inner join ChiTietHDB on MayTinh.MaMT=ChiTietHDB.MaMayTinh inner join HoaDonBan on HoaDonBan.MaHDB=ChiTietHDB.MaHDB where HoaDonBan.MaHDB='" + mahoadon + "'";
            dt = dh.FillDataTable(sql);//đổ dữ liệu vào kho
            return dt;
        }
        public void AddCTHoaDon(ChiTietHDB hd)
        {
            string sql = string.Format("insert into ChiTietHDB(MaHDB,MaMayTinh,Soluong,Giaban,Thanhtien) values('{0}','{1}','{2}','{3}','{4}');", hd.MaHDB, hd.MaMT, hd.Soluong, hd.Giaban, hd.Tongtien);
            dh.ExcuteNonQuery(sql);

        }

        public void AddAllDetails(DataTable dt2, params object[] values)
        {
            string sql = "";
            for (int i = 0; i < dt2.Rows.Count; i++)
            {

                string a = dt2.Rows[0]["Tongtien"].ToString();
                sql = $"insert into ChiTietHDB(MaHDB,MaMT,Soluong,Giaban,Tongtien) values('{dt2.Rows[i]["MaHDB"].ToString()}','{dt2.Rows[i]["MaMT"].ToString()}','{(int)dt2.Rows[i]["SoLuong"]}','{(int)dt2.Rows[i]["Giaban"]}','{(int)dt2.Rows[i]["Tongtien"]}');";
                dh.ExcuteNonQuery(sql);

            }

        }
        public void DeleteCTHoaDon(string ma)
        {
            dh.ExcuteNonQuery("Delete from ChiTietHDB where MaHDB='" + ma + "'");
        }
        public void DeleteCTHoaDonMA(MayTinh a)
        {
            dh.ExcuteNonQuery("Delete from ChiTietHDB where MaMT ='" + a.MaMT + "'");
        }
        public DataTable FindMaHDB(ChiTietHDB tl)
        {
            return dh.FillDataTable("select * from ChiTietHDB where MaMT='" + tl.MaMT + "'");
        }
        //public int KiemTraTrungMa(string mahd, string mamt)
        //{
        //    string sql = string.Format("select count(*) from ChiTietHDB where MaHDB='" + mahd + "' and MaMayTinh='" + mamt + "'");
        //    int i = (int)dh.FillDataTable(sql);
        //    return i;
        //}
    }
}
