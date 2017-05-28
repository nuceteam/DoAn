using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DoAnHDT.Object;
using System.Windows.Forms;

namespace DoAnHDT.Model
{
    class KhachHangMod
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();
        public DataTable GetData(string keysearch)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "Select * from KhachHang where ConCat(TenKh,DiaChi,DienThoai) like N'%"+keysearch+"%'";
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

        public bool AddData(KhachHang kh)
        {
            cmd.CommandText = "Insert into KhachHang values (N'" + kh.TenKH + "',N'" + kh.DiaChi + "',N'" + kh.DienThoai+"')";
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

        public bool UpdData(KhachHang kh)
        {
            
            cmd.CommandText = "Update KhachHang set TenKH =  N'" + kh.TenKH + "', DiaChi = N'" + kh.DiaChi + "', DienThoai ='" + kh.DienThoai + "' Where MaKH =" + kh.MaKH + "";
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
            cmd.CommandText = "Delete KhachHang Where MaKH = '" + ma + "'";
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
