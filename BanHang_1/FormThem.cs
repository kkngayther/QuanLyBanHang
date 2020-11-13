using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanHang_1
{
    public partial class FormThem : Form
    {
        public FormThem()
        {
            InitializeComponent();
        }
        public string themTen = "";
        public string themGia = "";
        private void btnXong_Click(object sender, EventArgs e)
        {
            if (txtThemTen.Text != "" && txtThemGia.Text != "")
            {
                themTen = txtThemTen.Text;
                themGia = txtThemGia.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !!!");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            themTen = null;
            themGia = null;
            this.Close();
        }
    }
}
