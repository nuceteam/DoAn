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
    public partial class f_KhachHang : Form
    {
        KhachHangCtr khctr = new KhachHangCtr();
        private int flagLuu = 0;
        public f_KhachHang()
        {
            InitializeComponent();
        }

        private void f_KhachHang_Load(object sender, EventArgs e)
        {
            DataTable dtKhachHang = new DataTable();
            dtKhachHang = khctr.GetData(txtSearch.Text.Trim());
            grKhachHang.DataSource = dtKhachHang;
            Binding();
            DisEnl(false);
        }
        void Binding()
        {
            txtMaKH.DataBindings.Clear();
            txtMaKH.DataBindings.Add("Text", grKhachHang.DataSource, "MaKH");
            txtTenKH.DataBindings.Clear();
            txtTenKH.DataBindings.Add("Text", grKhachHang.DataSource, "TenKH");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", grKhachHang.DataSource, "DiaChi");
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", grKhachHang.DataSource, "DienThoai");
        }

        private void ClearData()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
        }

        private void AddData(KhachHang kh)
        {
            if (flagLuu==1)
            {
                kh.MaKH = Convert.ToInt32(txtMaKH.Text);
            }
            kh.TenKH = txtTenKH.Text.Trim();
            kh.DiaChi = txtDiaChi.Text.Trim();
            kh.DienThoai = txtSDT.Text.Trim();
        }

        private void DisEnl(bool e)
        {
            btnThem.Enabled = !e;
            btnXoa.Enabled = !e;
            btnSua.Enabled = !e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
            txtTenKH.Enabled = e;
            txtSDT.Enabled = e;
            txtDiaChi.Enabled = e;
        }

        private bool CheckData()
        {
            long sdt;
            if (txtTenKH.Text =="")
            {
                MessageBox.Show("Nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtSDT.Text == "")
            {
                MessageBox.Show("Nhập số điện thoại khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!Int64.TryParse(txtSDT.Text, out sdt))
            {
                MessageBox.Show("Nhập sai định dạng số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Nhập địa chỉ khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (khctr.DelData(txtMaKH.Text.Trim()))
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            f_KhachHang_Load(sender, e);
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            flagLuu = 1;
            DisEnl(true);
           
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            if (CheckData())
            {
                AddData(kh);
                if (flagLuu == 0)
                {
                    if (khctr.AddData(kh))
                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (khctr.UpdData(kh))
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                f_KhachHang_Load(sender, e);
            }
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn hủy thao tác đang làm?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                f_KhachHang_Load(sender, e);
            else
                return;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                f_KhachHang_Load(sender, e);
            }
        }
    }
}
