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
    class ChiTietHDNDAL
    {
        public DataHelper dh;
        public DataTable dt;
        public ChiTietHDNDAL(string stcon)
        {
            dh = new DataHelper(stcon);
        }
        public DataTable GetCTHoaDon()
        {
            string sql = "Select HoaDonNhap.MaHDN,MayTinh.MaMT,TenMT, ChiTietHDN.Soluong, ChiTietHDN.Gianhap, Tongtien " +
                "from MayTinh inner join ChiTietHDN on MayTinh.MaMT=ChiTietHDN.MaMT inner join HoaDonNhap on HoaDonNhap.MaHDN=ChiTietHDN.MaHDN ";
            dt = dh.FillDataTable(sql);//đổ dữ liệu vào kho
            return dt;
        }
        public DataTable GetCTHoaDon(string mahoadon)
        {
            string sql = "Select HoaDonNhap.MaHDN,MayTinh.MaMT,TenMT, ChiTietHDN.Soluong, ChiTietHDN.Gianhap, Tongtien " +
                "from MayTinh inner join ChiTietHDN on MayTinh.MaMT=ChiTietHDN.MaMT inner join HoaDonNhap on HoaDonNhap.MaHDN=ChiTietHDN.MaHDN where HoaDonNhap.MaHDN='" + mahoadon + "'";
            dt = dh.FillDataTable(sql);//đổ dữ liệu vào kho
            return dt;
        }
        public void AddAllDetails(DataTable dt2, params object[] values)
        {
            string sql = "";
            for (int i = 0; i < dt2.Rows.Count; i++)
            {

                string a = dt2.Rows[0]["Thanhtien"].ToString();
                sql = $"insert into ChiTietHDN(MaHDN,MaMT,Soluong,Gianhap,Tongtien) values('{dt2.Rows[i]["MaHDN"].ToString()}','{dt2.Rows[i]["MaMT"].ToString()}','{(int)dt2.Rows[i]["SoLuong"]}','{(int)dt2.Rows[i]["Gianhap"]}','{(int)dt2.Rows[i]["Tongtien"]}');";
                dh.ExcuteNonQuery(sql);

            }

        }
        public void AddCTHoaDon(ChiTietHDN hd)
        {
            dh.ExcuteNonQuery("insert into ChiTietHDN values('" + hd.MaHDN + "','" + hd.MaMT + "','" + hd.Soluong + "','" + hd.Gianhap + "','" + hd.Tongtien + "')");
        }
        public void DeleteCTHoaDon(string ma)
        {
            dh.ExcuteNonQuery("Delete from ChiTietHDN where MaHDN='" + ma + "'");
        }
        public void DeleteCTHoaDonMA(MayTinh a)
        {
            dh.ExcuteNonQuery("Delete from ChiTietHDN where MaMT ='" + a.MaMT + "'");
        }
        public DataTable FindMaHDB(ChiTietHDN tl)
        {
            return dh.FillDataTable("select * from ChiTietHDN where MaMT='" + tl.MaMT + "'");
        }

    }
}
