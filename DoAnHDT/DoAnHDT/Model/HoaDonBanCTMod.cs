using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DoAnHDT.Object;
using System.Windows.Forms;

namespace DoAnHDT.Model
{
    class HoaDonBanCTMod
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData(string ma)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = " select ct.MaHDB,hh.MaMH, hh.TenMH, ct.SoLuong, ct.GiamGia from HoaDonBanCT ct, MatHang hh where ct.MaMH = hh.MaMH and MaHDB =" + ma;
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

        public bool AddData(HoaDonBanCT dt)
        {
            cmd.CommandText = "Insert into HoaDonBanCT values (" + dt.MaHDB + ",'" + dt.MaMH + "'," + dt.SoLuong + ","+dt.GiamGia+")";
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

        public bool DelData(int mahd,string mamh)
        {
            cmd.CommandText = "Delete HoaDonBanCT Where MaHDB = " + mahd + " and MaMH ='"+mamh+"'";
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
