using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnHDT.Model;
using System.Data;
using DoAnHDT.Object;
namespace DoAnHDT.Controller
{
    class HoaDonBanCtr
    {
        HoaDonBanMod hdMod = new HoaDonBanMod();
        public DataTable GetData(string key)
        {
            return hdMod.GetData(key);
        }
        public bool AddData(HoaDonBan hd)
        {
            return hdMod.AddData(hd);
        }
        public bool DelData(string ma)
        {
            return hdMod.DelData(ma);
        }
    }
}
