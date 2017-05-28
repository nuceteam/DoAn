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
    class NhaCungCapMod
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData(string keysearch)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "Select * from NhaCungCap where ConCat(Tenncc,DiaChi,DienThoai) like N'%" + keysearch + "%'";
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

        public bool AddData(NhaCungCap ncc)
        {
            cmd.CommandText = "Insert into NhaCungCap values (N'" + ncc.TenNCC + "',N'" + ncc.DiaChi + "',N'" + ncc.DienThoai + "')";
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

        public bool UpdData(NhaCungCap ncc)
        {

          //  cmd.CommandText = "Update NhaCungCap set Tenncc =  N'" + ncc.TenNCC + "', DiaChi = N'" + ncc.DiaChi + "', DienThoai ='" + ncc.DienThoai + "' Where Mancc =" + ncc.Mancc + "";
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
            cmd.CommandText = "Delete NhaCungCap Where Mancc = '" + ma + "'";
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
