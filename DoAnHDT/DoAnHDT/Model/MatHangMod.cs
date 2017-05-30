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
    class MatHangMod
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData(string keysearch)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "Select * from MatHang where ConCat(TenMH,HangSX,SoLuong) like N'%" + keysearch + "%'";
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

        public DataTable GetData(string mamh, int sl)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "Select * from MatHang where MaMH ='"+mamh+"' and SoLuong>"+sl;
            MessageBox.Show("Select * from MatHang where MaMH ='" + mamh + "' and SoLuong>" + sl);
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


        public bool CheckMaMH(string ma)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "Select * from MatHang where MaMH ='"+ma+"'";
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
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool AddData(MatHang mh)
        {
            cmd.CommandText = "Insert into MatHang values (N'" + mh.MaMH + "',N'" + mh.TenMH + "',N'" + mh.HangSx + "','" + mh.SoLuong + "','" + mh.GiaBan + "')";
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

        public bool UpdData(MatHang mh)
        {

            cmd.CommandText = "Update MatHang set TenMH =  N'" + mh.TenMH + "', HangSx = N'" + mh.HangSx + "', SoLuong =" +
                mh.SoLuong + ", GiaBan =" + mh.GiaBan + " Where MaMH ='" + mh.MaMH + "'";
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
            cmd.CommandText = "Delete MatHang Where MaMH = '" + ma + "'";
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
