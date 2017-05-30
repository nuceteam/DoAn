using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnHDT.Model;
using DoAnHDT.Object;
using System.Data;

namespace DoAnHDT.Controller
{
    class NhaCungCapCtr
    {
        NhaCungCapMod nccMod = new NhaCungCapMod();
        public DataTable GetData(string keysearch)
        {
            return nccMod.GetData(keysearch);
        }
        public bool AddData(NhaCungCap ncc)
        {
            return nccMod.AddData(ncc);
        }
        public bool UpdData(NhaCungCap ncc)
        {
            return nccMod.UpdData(ncc);
        }
        public bool DelData(string ma)
        {
            return nccMod.DelData(ma);
        }
    }
}
