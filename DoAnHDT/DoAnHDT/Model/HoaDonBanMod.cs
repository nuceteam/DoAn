using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnHDT.Model;
using System.Data;
using System.Data.SqlClient;
using DoAnHDT.Object;
using System.Windows.Forms;

namespace DoAnHDT.Model
{
    class HoaDonBanMod
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData(string key)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "select hd.MaHDB,kh.TenKH,hd.NgayBan,hd.GhiChu from HoaDonBan hd, KhachHang kh where kh.MaKH = hd.MaKH and CONCAT(kh.TenKH,hd.NgayBan,hd.GhiChu) like '%"+key+"%'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return dt;
        }

        public bool AddData(HoaDonBan hd)
        {
    
            cmd.CommandText = "insert into HoaDonBan values ("+hd.MaKH+ ", CONVERT (VARCHAR(10),'" + hd.NgayBan+"',103),0,0,'"+hd.GhiChu+"')";
            MessageBox.Show(cmd.CommandText);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }

        public bool DelData(string ma)
        {
            cmd.CommandText = "Delete HoaDonBan Where MaHDB = " + ma;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }
    }
}
