using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnHDT.View
{
    public partial class f_DangNhap : Form
    {
        public f_DangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tk = txtTK.Text.Trim();
            string mk = txtMK.Text.Trim();
            if (tk=="" || mk=="")
            {
                MessageBox.Show("Tài khoản hay mật khẩu không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (tk!="admin" || mk!="admin")
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Đăng nhập thành công");
        }
    }
}
