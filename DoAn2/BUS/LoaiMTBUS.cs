using DoAn2.Entities;
using DoAn2.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn2.BUS
{
    class LoaiMTBUS
    {
        LoaiMTDAL lmt;
        public LoaiMTBUS(string stcon)
        {
            lmt = new LoaiMTDAL(stcon);
        }
        public DataTable getLoaiMT()
        {
            return lmt.getLoaiMT();
        }

        public void AddLoaiMT(LoaiMT lm)
        {
            lmt.AddLoaiMT(lm);
        }

        public List<LoaiMT> GetLoaiMT()
        {
            return lmt.GetLoaiMT();
        }
        public List<LoaiMT> GetLoaiMa(string matl)
        {
            return lmt.GetLoaiMa(matl);
        }
        public DataTable FindMa(LoaiMT tl)
        {
            return lmt.FindMa(tl);
        }
        public DataTable FindTen(LoaiMT tl)
        {
            return lmt.FindTen(tl);
        }
        public void EditLoaiMT(LoaiMT tl)
        {
            lmt.EditLoaiMT(tl);
        }
        public void DeleteLoaiMT(string ma)
        {
            lmt.DelteLoaiMT(ma);
        }
    }
}
