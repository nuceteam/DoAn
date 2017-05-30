using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnHDT.Controller;
using DoAnHDT.Object;
namespace DoAnHDT.View
{
    public partial class f_MatHang : Form
    {
        MatHangCtr mhCtr = new MatHangCtr();
        private int flagLuu = 0;
        public f_MatHang()
        {
            InitializeComponent();
        }
        private void f_MatHang_Load(object sender, EventArgs e)
        {
            DataTable dtMatHang = new DataTable();
            dtMatHang = mhCtr.GetData(txtSearch.Text.Trim());
            grMatHang.DataSource = dtMatHang;
            Binding();
            DisEnl(false);
        }
        void Binding()
        {
            txtMaMH.DataBindings.Clear();
            txtMaMH.DataBindings.Add("Text", grMatHang.DataSource, "MaMH");
            txtTenMH.DataBindings.Clear();
            txtTenMH.DataBindings.Add("Text", grMatHang.DataSource, "TenMH");
            txtHangSx.DataBindings.Clear();
            txtHangSx.DataBindings.Add("Text", grMatHang.DataSource, "HangSx");
            txtSoLuong.DataBindings.Clear();
            txtSoLuong.DataBindings.Add("Text", grMatHang.DataSource, "SoLuong");
            txtGiaBan.DataBindings.Clear();
            txtGiaBan.DataBindings.Add("Text", grMatHang.DataSource, "GiaBan");
        }

        private void ClearData()
        {
            txtMaMH.Text = "";
            txtTenMH.Text = "";
            txtSoLuong.Text = "";
            txtGiaBan.Text = "";
            txtHangSx.Text = "";
        }

        private void AddData(MatHang mh)
        {
            mh.MaMH = txtMaMH.Text.Trim();
            mh.TenMH = txtTenMH.Text.Trim();
            mh.SoLuong = int.Parse((txtSoLuong.Text.Trim()));
            mh.GiaBan = int.Parse(txtGiaBan.Text.Trim());
            mh.HangSx = txtHangSx.Text.Trim();
        }

        private void DisEnl(bool e)
        {
            btnThem.Enabled = !e;
            btnXoa.Enabled = !e;
            btnSua.Enabled = !e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
            txtMaMH.Enabled = e;
            txtTenMH.Enabled = e;
            txtSoLuong.Enabled = e;
            txtGiaBan.Enabled = e;
            txtHangSx.Enabled = e;
        }

        private bool CheckData()
        {
            int sl;
            int giaban;
            if (flagLuu ==0)
            {
                if (txtMaMH.Text == "")
                {
                    MessageBox.Show("Nhập mã mặt hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                
                if (mhCtr.CheckMaMH(txtMaMH.Text.Trim()))
                {
                    MessageBox.Show("Mã mặt hàng đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            if (txtTenMH.Text == "")
            {
                MessageBox.Show("Nhập tên mặt hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtHangSx.Text == "")
            {
                MessageBox.Show("Nhập hãng sản xuất mặt hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Nhập số lượng mặt hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!Int32.TryParse(txtSoLuong.Text, out sl))
            {
                MessageBox.Show("Nhập sai định dạng số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtGiaBan.Text == "")
            {
                MessageBox.Show("Nhập giá bán mặt hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!Int32.TryParse(txtGiaBan.Text, out giaban))
            {
                MessageBox.Show("Nhập sai định dạng giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


        private void btnThem_Click_1(object sender, EventArgs e)
        {
            flagLuu = 0;
            ClearData();
            DisEnl(true);
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa mặt hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (mhCtr.DelData(txtMaMH.Text.Trim()))
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            f_MatHang_Load(sender, e);
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            flagLuu = 1;
            DisEnl(true);
            txtMaMH.Enabled = false;
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {

            MatHang mh = new MatHang();
            if (CheckData())
            {
                AddData(mh);
                if (flagLuu == 0)
                {
                    if (mhCtr.AddData(mh))
                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (mhCtr.UpdData(mh))
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                f_MatHang_Load(sender, e);
            }
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn hủy thao tác đang làm?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                f_MatHang_Load(sender, e);
            else
                return;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                f_MatHang_Load(sender, e);
            }
        }
    }
}
