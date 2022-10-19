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
    class NCCBUS
    {
        NCCDAL nd;
        public NCCBUS(string stcon)
        {
            nd = new NCCDAL(stcon);
        }
        public void AddNhaCC(NCC nha)
        {
            nd.AddNhaCC(nha);
        }
        public List<NCC> GetNCC()
        {
            return nd.GetNCC();
        }
        public List<NCC> GetNCCMa(string mancc)
        {
            return nd.GetNCCMa(mancc);
        }
        public DataTable FindNhaCC(NCC tl)
        {
            return nd.FindNhaCC(tl);
        }
        public void EditNCC(NCC n)
        {
            nd.EditNCC(n);
        }
        public void DeleteNCC(string ma)
        {
            nd.DeleteNCC(ma);
        }
    }
}
