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
    class HoaDonBanCTCtr
    {
        HoaDonBanCTMod ctMod = new HoaDonBanCTMod();
        public DataTable GetData(string ma)
        {
            return ctMod.GetData(ma);
        }

        public bool AddData(HoaDonBanCT dt)
        {
            return ctMod.AddData(dt);
        }
        public bool DelData(int mahd,string mamh)
        {
            return ctMod.DelData(mahd,mamh);
        }
    }
}
