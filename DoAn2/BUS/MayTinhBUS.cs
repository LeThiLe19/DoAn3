using DoAn2.DAL;
using DoAn2.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn2.BUS
{
    class MayTinhBUS
    {
        MayTinhDAL mtd;
        LoaiMTDAL lmtd;
        List<MayTinh> l;
        public MayTinhBUS(string stcon)
        {
            mtd = new MayTinhDAL(stcon);
            lmtd = new LoaiMTDAL(stcon);
        }
        public List<LoaiMT> GetLoaiMT()
        {
            return lmtd.GetLoaiMT();
        }
        public List<MayTinh> GetMayTinh()
        {
            return mtd.GetMayTinh();

        }
        public void AddMayTinh(MayTinh MayTinh)
        {
            MayTinh.MaLoai = SinhMaSP(MayTinh.MaLoai);
            mtd.AddMayTinh(MayTinh);
        }
        public List<MayTinh> GetMayTinhMaloai(string ma)
        {
            l = mtd.GetMayTinhMaLoai(ma);
            l.Sort(new MayTinhMaMayTinhComparper());
            return l;
        }
        public void DeleteMayTinh(string ma)
        {
            mtd.DeleteMayTinh(ma);
        }
        public void EditMayTinh(MayTinh MayTinh)
        {
            mtd.EditMayTinh(MayTinh);
        }
        public DataTable FindMayTinh(MayTinh g)
        {
            return mtd.FindMayTinh(g);
        }
        public string SinhMaSP(string maloai)//"L001.007"=>"L001.008";
        {
            string ma = "";
            if (l.Count > 0)//có các sp thuộc loại đấy
            {
                string mamt = l[l.Count - 1].MaMT.ToString();//lấy mã của bản ghi cuối cùng(001)
                                                             //string c = (int.Parse(masp.Substring(masp.IndexOf-3))+ 1).ToString();

                string c = (int.Parse(mamt.Substring(mamt.Length - 3)) + 1).ToString();//từ sâu chuyển sang số rồi công thêm 1 rồi đổi thành sâu:"4"->"004"
                while (c.Length < 3)
                    c = "0" + c;
                ma = maloai + "." + c;
            }
            else
            {
                ma = maloai + "." + "001";
            }
            return ma;
        }

        public class MayTinhMaMayTinhComparper : IComparer<MayTinh>
        {
            public int Compare(MayTinh x, MayTinh y)
            {
                return x.MaMT.CompareTo(y.MaMT);
            }

        }
    }
}
