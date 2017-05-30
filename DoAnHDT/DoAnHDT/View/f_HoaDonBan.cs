using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DoAnHDT.Model;
using DoAnHDT.Object;
using DoAnHDT.Controller;

namespace DoAnHDT.View
{
    public partial class f_HoaDonBan : Form
    {
        HoaDonBanCtr hdCtr = new HoaDonBanCtr();
        HoaDonBanCTCtr ctCtr = new HoaDonBanCTCtr();
        MatHangCtr mhctr = new MatHangCtr();
        DataTable dtDSCT = new System.Data.DataTable();
        int maclick;

        public f_HoaDonBan()
        {
            InitializeComponent();
        }

        private void f_HoaDonBan_Load(object sender, EventArgs e)
        {
            maclick = 1;
            Dis_Enl(false);
           // Dis_ct(false);
            DataTable dt = new System.Data.DataTable();
            dt = hdCtr.GetData(txtSearch.Text.Trim());
            grHoaDon.DataSource = dt;
            Binding();
            txtGiamGia.Text = "0";
            //loadCTHD(dt.Rows[0][0].ToString());
          //  Binding1();
        }
        private void loadCTHD(string ma)
        {
            DataTable dtct = new System.Data.DataTable();
            dtct = ctCtr.GetData(ma);
            grHDCT.DataSource = dtct;
        }

        private void LoadGridHoaDon()
        {

        }
        private void Binding()
        {
            txtMaHD.DataBindings.Clear();
            txtMaHD.DataBindings.Add("Text", grHoaDon.DataSource, "MaHDB");
            txtNgayBan.DataBindings.Clear();
            txtNgayBan.DataBindings.Add("Text", grHoaDon.DataSource, "NgayBan");
            cbKhachHang.DataBindings.Clear();
            cbKhachHang.DataBindings.Add("Text", grHoaDon.DataSource, "TenKH");
            txtGhiChu.DataBindings.Clear();
            txtGhiChu.DataBindings.Add("Text", grHoaDon.DataSource, "GhiChu");
        }


        private void Binding1()
        {
            txtSoLuong.DataBindings.Clear();
            txtSoLuong.DataBindings.Add("Text", grHDCT.DataSource, "SoLuong");
            txtGiamGia.DataBindings.Clear();
            txtGiamGia.DataBindings.Add("Text", grHDCT.DataSource, "GiamGia");
            cbTenMH.DataBindings.Clear();
            cbTenMH.DataBindings.Add("Text", grHDCT.DataSource, "TenMH");
        }

        private void Dis_Enl(bool e)
        {
            cbKhachHang.Enabled = e;
            txtGhiChu.Enabled = e;
            txtNgayBan.Enabled = e;
            btnThem.Enabled = !e;
            btnXoa.Enabled = !e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
        }
        private void Dis_ct(bool e)
        {
            btnThemCT.Enabled = e;
            btnXoaCT.Enabled = e;
            txtSoLuong.Enabled = e;
            txtGiamGia.Enabled = e;
            cbTenMH.Enabled = e;
        }

        private void LoadcmbKhachHang()
        {
            KhachHangCtr khctr = new KhachHangCtr();
            cbKhachHang.DataSource = khctr.GetData("");
            cbKhachHang.DisplayMember = "TenKH";
            cbKhachHang.ValueMember = "MaKH";
            cbKhachHang.SelectedIndex = 0;
        }

        private void LoadcmbMH()
        {
            MatHangCtr mhctr = new MatHangCtr();
            cbTenMH.DataSource = mhctr.GetData("");
            cbTenMH.DisplayMember = "TenMH";
            cbTenMH.ValueMember = "MaMH";

        }

        private void clearData()
        {
            txtMaHD.Text = "";
            txtNgayBan.Text = DateTime.Now.Date.ToShortDateString();
            txtGhiChu.Text = "";
            LoadcmbKhachHang();
        }

        private void addData(HoaDonBan hd)
        {
            hd.NgayBan =Convert.ToDateTime(txtNgayBan.Text.Trim());
            hd.MaKH = int.Parse(cbKhachHang.SelectedValue.ToString());
            hd.GhiChu = txtGhiChu.Text.Trim();
        }

        private bool checktrung(string mahh)
        {
            for (int i = 0; i < dtDSCT.Rows.Count; i++)
                if (dtDSCT.Rows[i][1].ToString() == mahh)
                    return true;
            return false;
        }

        private void capnhatSL(string mahh, int SL)
        {
            for (int i = 0; i < dtDSCT.Rows.Count; i++)
                if (dtDSCT.Rows[i][1].ToString() == mahh)
                {
                    int soluong = int.Parse(dtDSCT.Rows[i][3].ToString()) + SL;
                    dtDSCT.Rows[i][3] = soluong;
                    double dongia = double.Parse(dtDSCT.Rows[i][2].ToString());
                    dtDSCT.Rows[i][4] = (dongia * soluong).ToString();
                    break;
                }
        }

          private bool kiemtraSL(string mamh, int sl)
          {
              DataTable dt = new DataTable();
              dt = mhctr.GetData(mamh,sl);
              if (dt.Rows.Count > 0)
                  return false;
              return true;
          }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Dis_Enl(true);
           // Dis_ct(false);
            clearData();
            LoadcmbMH();
            LoadcmbKhachHang();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa hóa đơn này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (hdCtr.DelData(txtMaHD.Text.Trim()))
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
              f_HoaDonBan_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            HoaDonBan hd = new HoaDonBan();
            addData(hd);
            if (hdCtr.AddData(hd))
            {
                MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Thêm hóa đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            f_HoaDonBan_Load(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn hủy thao tác đang làm?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                f_HoaDonBan_Load(sender, e);
            else
                return;
        }

        private void grHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in grHoaDon.SelectedRows)
            {
                 maclick = int.Parse(row.Cells[0].Value.ToString());
                //...
            }
        }

        private void grHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            maclick =int.Parse(grHoaDon.Rows[e.RowIndex].Cells["MaHDB"].Value.ToString());
            loadCTHD(grHoaDon.Rows[e.RowIndex].Cells["MaHDB"].Value.ToString());
            Binding1();
            LoadcmbMH();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                f_HoaDonBan_Load (sender, e);
            }
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            HoaDonBanCT hdct = new HoaDonBanCT();
            addDataCT(hdct);
            if (ctCtr.AddData(hdct))
            {
                if (kiemtraSL(hdct.MaMH,hdct.SoLuong))
                {
                    MessageBox.Show("Số lượng trong kho không đủ","Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Thêm mới mặt hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Thêm hóa đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            loadCTHD(hdct.MaHDB.ToString());
        }

        private void addDataCT(HoaDonBanCT hdct)
        {
            hdct.MaHDB = maclick;
            hdct.MaMH = cbTenMH.SelectedValue.ToString();
            hdct.SoLuong = int.Parse(txtSoLuong.Text.Trim());
            hdct.GiamGia = int.Parse(txtGiamGia.Text.Trim());
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa mặt hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (ctCtr.DelData(maclick, mamhclick))
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loadCTHD(maclick.ToString());
        }
        string mamhclick;
        private void grHDCT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mamhclick = grHDCT.Rows[e.RowIndex].Cells["MaMH"].Value.ToString();
        }
    }
}
