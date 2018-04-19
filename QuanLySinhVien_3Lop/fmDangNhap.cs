using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLogicLayer;

namespace QuanLySinhVien_3Lop
{
    public partial class fmDangNhap : Form
    {
        DangNhap_BLL dn = new DangNhap_BLL();
        public fmDangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = "";
            DataTable dt = dn.Select(textBox1.Text, textBox2.Text);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    id = dr["ID"].ToString();
                }
            }
            if (id != "")
            {
                Form1 fmain = new Form1();
                fmain.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Tài khoản và mật khẩu không đúng !");
            }

        }

        private void fmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
