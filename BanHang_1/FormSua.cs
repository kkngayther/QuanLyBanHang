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
    public partial class FormSua : Form
    {
        public FormSua()
        {
            InitializeComponent();
        }
        public string suaTen;
        public string suaGia;

        private void btnXong_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            suaTen = txtSuaTen.Text;
            suaGia = txtSuaGia.Text;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSua_Load(object sender, EventArgs e)
        {
            txtSuaGia.Text = suaGia;
            txtSuaTen.Text = suaTen;
        }
    }
}
