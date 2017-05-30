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
    public partial class f_NhaCungCap : Form
    {
        NhaCungCapCtr nccCtr = new NhaCungCapCtr();
        private int flagLuu = 0;
        public f_NhaCungCap()
        {
            InitializeComponent();
        }
        private void f_NhaCungCap_Load(object sender, EventArgs e)
        {
            DataTable dtNhaCungCap = new DataTable();
            dtNhaCungCap = nccCtr.GetData(txtSearch.Text.Trim());
            grNCC.DataSource = dtNhaCungCap;
            Binding();
            DisEnl(false);
        }
        void Binding()
        {
            txtMaNCC.DataBindings.Clear();
            txtMaNCC.DataBindings.Add("Text", grNCC.DataSource, "MaNCC");
            txtTenNCC.DataBindings.Clear();
            txtTenNCC.DataBindings.Add("Text", grNCC.DataSource, "TenNCC");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", grNCC.DataSource, "DiaChi");
            txtDienThoai.DataBindings.Clear();
            txtDienThoai.DataBindings.Add("Text", grNCC.DataSource, "DienThoai");
            txtSoFax.DataBindings.Clear();
            txtSoFax.DataBindings.Add("Text", grNCC.DataSource, "SoFax");
        }

        private void ClearData()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDienThoai.Text = "";
            txtDiaChi.Text = "";
            txtSoFax.Text = "";
        }

        private void AddData(NhaCungCap ncc)
        {
            if (flagLuu == 1)
            {
                ncc.MaNCC = Convert.ToInt32(txtMaNCC.Text);
            }
            ncc.TenNCC = txtTenNCC.Text.Trim();
            ncc.DiaChi = txtDiaChi.Text.Trim();
            ncc.DienThoai = txtDienThoai.Text.Trim();
            ncc.SoFax = txtSoFax.Text.Trim();
        }

        private void DisEnl(bool e)
        {
            btnThem.Enabled = !e;
            btnXoa.Enabled = !e;
            btnSua.Enabled = !e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
            txtTenNCC.Enabled = e;
            txtSoFax.Enabled = e;
            txtDiaChi.Enabled = e;
            txtDienThoai.Enabled = e;
        }

        private bool CheckData()
        {
            long sdt;
            if (txtTenNCC.Text == "")
            {
                MessageBox.Show("Nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtDienThoai.Text == "")
            {
                MessageBox.Show("Nhập số điện thoại nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!Int64.TryParse(txtDienThoai.Text, out sdt))
            {
                MessageBox.Show("Nhập sai định dạng số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Nhập địa chỉ nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa nhà cung cấp này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (nccCtr.DelData(txtMaNCC.Text.Trim()))
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            f_NhaCungCap_Load(sender, e);
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            flagLuu = 1;
            DisEnl(true);

        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            NhaCungCap ncc = new NhaCungCap();
            if (CheckData())
            {
                AddData(ncc);
                if (flagLuu == 0)
                {
                    if (nccCtr.AddData(ncc))
                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (nccCtr.UpdData(ncc))
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                f_NhaCungCap_Load(sender, e);
            }
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn hủy thao tác đang làm?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                f_NhaCungCap_Load(sender, e);
            else
                return;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                f_NhaCungCap_Load(sender, e);
            }
        }
    }
}
