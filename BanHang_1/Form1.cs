using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace BanHang_1
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        List<string> listDic = new List<string>();
        DataTable dt = new DataTable();
        double tongTien = 0;
        double khuyenMai = 0;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Clear();
            dt.Columns.Add("Tên", typeof(string));
            dt.Columns.Add("Số lượng", typeof(string));
            dt.Columns.Add("Đơn giá", typeof(string));
            dt.Columns.Add("Thành tiền", typeof(string));   
            khoiTaoDuLieu();
        }
        private void khoiTaoDuLieu()
        {
            dic.Add("Trà đào cam sả", "15000");
            dic.Add("Trà đào", "16000");
            dic.Add("Trà chanh", "18000");

            dic.Add("Trà sữa trân châu đường đen", "35000");
            dic.Add("Trà sữa trân châu hoàng gia", "39000");
            dic.Add("Trà sữa Ba anh em", "27000");
            //dic.Add("Trà Ô Long", "21000");
            //dic.Add("Trà đá", "5000");
            //dic.Add("Trà việt quất", "22000");
        }

        private void btnHongTra_Click(object sender, EventArgs e)
        {
            loai = "hongtra";
            pnlHongTra.Visible = true;
            pnlTraSua.Visible = false;
        }

        private void btnTraSua_Click(object sender, EventArgs e)
        {
            loai = "trasua";
            pnlTraSua.Visible = true;
            pnlHongTra.Visible = false;
        }
        private string loai = "";
        private void btnHome_Click(object sender, EventArgs e)
        {
            loai = "main";
            pnlMain.Visible = true;
            pnlHongTra.Visible = false;
            pnlTraSua.Visible = false;
        }
        private int isExist(string str, List<string> ls)
        {
            int ktra = -1;
            for (int i = 0; i < ls.Count(); i++)
            {
                if (str == ls[i])
                {
                    ktra = i;
                    break;
                } 
            }
            return ktra;
        }
        private void check(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int count;
            foreach (KeyValuePair<string, string> item in dic)
            {
                if (item.Key == btn.Text)
                {
                    int ktra = isExist(item.Key, listDic);
                    if (ktra != -1)
                    {
                        count = Convert.ToInt32(dt.Rows[ktra].ItemArray[1]);
                        count++;
                        dt.Rows[ktra][1] = count.ToString();
                        dt.Rows[ktra][3] = (count * Convert.ToInt32(item.Value)).ToString();
                        tongTien += Double.Parse(item.Value);
                        txtTongTien.Text = string.Format("{0:#,##0}", tongTien);
                    }
                    else
                    {
                        listDic.Add(item.Key);
                        dt.Rows.Add(item.Key, "1", item.Value, item.Value);
                        dataGridView1.DataSource = dt;
                        tongTien += Double.Parse(item.Value);
                        txtTongTien.Text = string.Format("{0:#,##0}", tongTien);
                        break;
                    }
                }
            }
        }

        

        private void mouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                FormSua frm = new FormSua();
                Button btn = (Button)sender;
                frm.suaTen = btn.Text;
                foreach (KeyValuePair<string, string> item in dic)
                {
                    if (item.Key == frm.suaTen)
                    {
                        frm.suaGia = item.Value;
                    }
                }
                frm.ShowDialog();
                dic.Remove(btn.Text);
                btn.Text = frm.suaTen;
                dic.Add(frm.suaTen, frm.suaGia);
                //MessageBox.Show("Xong !!!");
            }
        }

        private bool kiemTra = false;

        private void btnThem_Click(object sender, EventArgs e)
        {
            Button btn = new Button();

            btn.Size = new Size(180, 55);
            btn.ForeColor = Color.FromArgb(91, 91, 91);
            btn.Font = new Font("Century", 12f, FontStyle.Bold);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.Cyan;
            btn.Margin = new Padding(10, 10, 10, 10);

            FormThem frm = new FormThem();
            frm.ShowDialog();
            btn.Text = frm.themTen;

            foreach (KeyValuePair<string, string> item in dic)
            {
                if (frm.themTen == item.Key)
                {
                    kiemTra = true;
                    break;
                }
            }

            if (kiemTra)
            {
                MessageBox.Show("Đã tồn tại trong menu!");
            }
            else 
            {
                if (frm.themTen == null && frm.themGia == null)
                {}
                else
                {
                    dic.Add(frm.themTen, frm.themGia);
                    btn.Click += check;
                    btn.MouseDown += mouseClick;
                    switch (loai)
                    {
                        case "hongtra":
                            flpHongTra.Controls.Add(btn);
                            break;
                        case "trasua":
                            flpTraSua.Controls.Add(btn);
                            break;
                    }
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            khuyenMai = Double.Parse(txtKhuyenMai.Text);
            double thanhTien = tongTien * (100 - khuyenMai) / 100;
            txtThanhTien.Text = string.Format("{0:#,##0}", thanhTien);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Button btn = new Button();

            btn.Size = new Size(180, 55);
            btn.ForeColor = Color.FromArgb(91, 91, 91);
            btn.Font = new Font("Century", 12f, FontStyle.Bold);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.Cyan;
            btn.Margin = new Padding(10, 10, 10, 10);

            FormThem frm = new FormThem();
            frm.ShowDialog();
            btn.Text = frm.themTen;
            foreach (KeyValuePair<string, string> item in dic)
            {
                if (frm.themTen == item.Key)
                {
                    kiemTra = true;
                    break;
                }
            }
            if (kiemTra)
            {
                MessageBox.Show("Đã tồn tại trong menu!");
            }
            else
            {
                if (frm.themTen == null && frm.themGia == null)
                { }
                else
                {
                    dic.Add(frm.themTen, frm.themGia);
                    btn.Click += check;
                    btn.MouseDown += mouseClick;
                    switch (loai)
                    {
                        case "hongtra":
                            flpHongTra.Controls.Add(btn);
                            break;
                        case "trasua":
                            flpTraSua.Controls.Add(btn);
                            break;
                    }
                }
            }
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            txtKhuyenMai.Text = "0";
            txtThanhTien.Text = "";
            txtTongTien.Text = "0";
            tongTien = 0;
            dt.Clear();
            dataGridView1.DataSource = dt;
            listDic.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
            {
                int temp = Convert.ToInt32(dt.Rows[row.Index].ItemArray[3]);
                string str = dt.Rows[row.Index].ItemArray[0].ToString();
                dataGridView1.Rows.RemoveAt(row.Index);
                xoaListDic(str);
                //listDic.RemoveAt(row.Index);
                tongTien = tongTien - temp;
                khuyenMai = Double.Parse(txtKhuyenMai.Text);
                txtTongTien.Text = string.Format("{0:#,##0}", tongTien);
                double thanhTien = tongTien * (100 - khuyenMai) / 100;
                txtThanhTien.Text = string.Format("{0:#,##0}", thanhTien);
            }
        }

        private void xoaListDic(string str)
        {
            for (int i = 0; i < listDic.Count(); i++)
            {
                if (listDic[i] == str)
                {
                    listDic.RemoveAt(i);
                }
            }
        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            khuyenMai = Double.Parse(txtKhuyenMai.Text);
            double thanhTien = tongTien * (100 - khuyenMai) / 100;
            txtThanhTien.Text = string.Format("{0:#,##0}", thanhTien);
        }

        private void txtKhuyenMai_TextChanged(object sender, EventArgs e)
        {
            khuyenMai = Double.Parse(txtKhuyenMai.Text);
            double thanhTien = tongTien * (100 - khuyenMai) / 100;
            txtThanhTien.Text = string.Format("{0:#,##0}", thanhTien);
        }
    }
}
