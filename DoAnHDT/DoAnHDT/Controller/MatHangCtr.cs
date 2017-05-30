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
    class MatHangCtr
    {
        MatHangMod mhMod = new MatHangMod();
        public DataTable GetData(string keysearch)
        {
            return mhMod.GetData(keysearch);
        }
        public DataTable GetData(string mamh,int sl)
        {
            return mhMod.GetData(mamh,sl);
        }
        public bool CheckMaMH(string ma)
        {
            return mhMod.CheckMaMH(ma);
        }
        public bool AddData(MatHang mh)
        {
            return mhMod.AddData(mh);
        }
        public bool UpdData(MatHang mh)
        {
            return mhMod.UpdData(mh);
        }
        public bool DelData(string ma)
        {
            return mhMod.DelData(ma);
        }
    }
}
