using DoAn2.Entities;
using DoAn2.DAL;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn2.BUS
{
    class ThongkeBUS
    {
        ThongkeDAL tk;
        public ThongkeBUS(string stcon)
        {
            tk = new ThongkeDAL(stcon);
        }

        public DataTable GetThongKe_HDB(HoaDonBan h1, HoaDonBan h2)
        {
            return tk.GetThongKe_HDB(h1, h2);
        }


        public DataTable GetThongKe_HDN(HoaDonNhap h1, HoaDonNhap h2)
        {
            return tk.GetThongKe_HDN(h1, h2);
        }

        public DataTable GetThongKe_LX(HoaDonBan h1, HoaDonBan h2)
        {
            return tk.GetThongKe_LX(h1, h2);
        }
    }
}
