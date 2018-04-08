using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien_3Lop
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            danhsach ds = new danhsach();
            crystalReportViewer1.ReportSource = ds;
        }
    }
}
