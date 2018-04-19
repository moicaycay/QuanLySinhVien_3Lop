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
using System.IO;

namespace QuanLySinhVien_3Lop
{
    public partial class Form1 : Form
    {
        Khoa_BLL khoabll = new Khoa_BLL();
        Lop_BLL lopbll = new Lop_BLL();
        SinhVien_BLL svbll = new SinhVien_BLL();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtgKhoa.DataSource = khoabll.Khoa_Select();
            cboKhoa2.DataSource = khoabll.Khoa_Select();
            cboKhoa2.DisplayMember = "TenKhoa";
            cboKhoa2.ValueMember = "MaKhoa";
            cboKhoa3.DataSource = khoabll.Khoa_Select();
            cboKhoa3.DisplayMember = "TenKhoa";
            cboKhoa3.ValueMember = "MaKhoa";
            btnSave3.Enabled = false;
            btnSave2.Enabled = false;
            btnSave1.Enabled = false;
        }

        private void DtgKhoa_SelectionChanged(object sender, EventArgs e)
        {
            tbMaKhoa.Text = dtgKhoa[0, dtgKhoa.CurrentRow.Index].Value.ToString();
            tbTenKhoa.Text = dtgKhoa[1, dtgKhoa.CurrentRow.Index].Value.ToString();
            tbSDT.Text = dtgKhoa[2, dtgKhoa.CurrentRow.Index].Value.ToString();
            btnSave1.Enabled = false;
        }

        private void TbMaKhoa_TextChanged(object sender, EventArgs e)
        {
            btnSave1.Enabled = true;
        }

        private void BtnSave1_Click(object sender, EventArgs e)
        {
            DialogResult key = MessageBox.Show("Bạn có muốn lưu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (key == DialogResult.Yes)
            {
                try
                {
                    string[] s;
                    s = tbTenKhoa.Text.ToString().Split(' ');
                    string c = null;
                    for (int i = 0; i < s.Length; i++)
                        c = c + s[i].Substring(0, 1);
                    khoabll.Khoa_Insert(c.ToUpper(), tbTenKhoa.Text.ToString(), tbSDT.Text.ToString());
                    dtgKhoa.DataSource = dtgKhoa.DataSource = khoabll.Khoa_Select();
                    cboKhoa2.DataSource = khoabll.Khoa_Select();
                    cboKhoa2.DisplayMember = "TenKhoa";
                    cboKhoa2.ValueMember = "MaKhoa";
                    cboKhoa3.DataSource = khoabll.Khoa_Select();
                    cboKhoa3.DisplayMember = "TenKhoa";
                    cboKhoa3.ValueMember = "MaKhoa";

                }

                catch (Exception LOI)
                {
                    MessageBox.Show(LOI.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void BtnCapNhap_Click(object sender, EventArgs e)
        {
            DialogResult key = MessageBox.Show("Bạn có muốn cập nhập không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (key == DialogResult.Yes)
            {
                try
                {
                    khoabll.Khoa_Update(tbMaKhoa.Text.ToString(), tbTenKhoa.Text.ToString(), tbSDT.Text.ToString());
                    dtgKhoa.DataSource = khoabll.Khoa_Select();
                    cboKhoa2.DataSource = khoabll.Khoa_Select();
                    cboKhoa2.DisplayMember = "TenKhoa";
                    cboKhoa2.ValueMember = "MaKhoa";
                    cboKhoa3.DataSource = khoabll.Khoa_Select();
                    cboKhoa3.DisplayMember = "TenKhoa";
                    cboKhoa3.ValueMember = "MaKhoa";
                }

                catch (Exception LOI)
                {
                    MessageBox.Show(LOI.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            DialogResult key = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (key == DialogResult.Yes)
            {
                try
                {
                    khoabll.Khoa_Delete(dtgKhoa[0, dtgKhoa.CurrentRow.Index].Value.ToString());
                    dtgKhoa.DataSource = khoabll.Khoa_Select();
                    cboKhoa2.DataSource = khoabll.Khoa_Select();
                    cboKhoa2.DisplayMember = "TenKhoa";
                    cboKhoa2.ValueMember = "MaKhoa";
                    cboKhoa3.DataSource = khoabll.Khoa_Select();
                    cboKhoa3.DisplayMember = "TenKhoa";
                    cboKhoa3.ValueMember = "MaKhoa";
                }

                catch (Exception LOI)
                {
                    MessageBox.Show(LOI.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void CboKhoa2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgLop.DataSource = lopbll.Lop_Select(cboKhoa2.SelectedValue.ToString());
        }

        private void CboKhoa3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboLop1.DataSource = lopbll.Lop_Select(cboKhoa3.SelectedValue.ToString());
            cboLop1.DisplayMember = "TenLop";
            cboLop1.ValueMember = "MaLop";
        }

        private void BtnSave2_Click(object sender, EventArgs e)
        {
            DialogResult key = MessageBox.Show("Bạn có muốn lưu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (key == DialogResult.Yes)
            {
                try
                {
                    string[] s;
                    s = tbNganh2.Text.ToString().Split(' ');
                    string c = null;
                    for (int i = 0; i < s.Length; i++)
                        c = c + s[i].Substring(0, 1);
                    string d = tbKhoaL2.Text.ToString() + tbLop2.Text.ToString() + c.ToUpper();
                    string tenlop = tbKhoaL2.Text.ToString() + tbLop2.Text.ToString() + " " + tbNganh2.Text.ToString();
                    lopbll.Lop_Insert(d, cboKhoa2.SelectedValue.ToString(), tenlop, tbSiSo2.Text.ToString());
                    dtgLop.DataSource = lopbll.Lop_Select(cboKhoa2.SelectedValue.ToString());

                }

                catch (Exception LOI)
                {
                    MessageBox.Show(LOI.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void BtnCapNhap2_Click(object sender, EventArgs e)
        {
            DialogResult key = MessageBox.Show("Bạn có muốn cập nhật không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (key == DialogResult.Yes)
            {
                try
                {
                    lopbll.Lop_Update(dtgLop[0, dtgLop.CurrentRow.Index].Value.ToString(), cboKhoa2.SelectedValue.ToString(), tbKhoaL2.Text.ToString() + tbLop2.Text.ToString() + " " + tbNganh2.Text.ToString(), tbSiSo2.Text.ToString());
                    dtgLop.DataSource = lopbll.Lop_Select(cboKhoa2.SelectedValue.ToString());
                }

                catch (Exception LOI)
                {
                    MessageBox.Show(LOI.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void BtnXoa2_Click(object sender, EventArgs e)
        {
            DialogResult key = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (key == DialogResult.Yes)
            {
                try
                {
                    lopbll.Lop_Delete(dtgLop[0, dtgLop.CurrentRow.Index].Value.ToString());
                    dtgLop.DataSource = lopbll.Lop_Select(cboKhoa2.SelectedValue.ToString());
                }

                catch (Exception LOI)
                {
                    MessageBox.Show(LOI.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnTaoMoi1_Click(object sender, EventArgs e)
        {
            tbMaKhoa.Clear();
            tbTenKhoa.Focus();
            tbTenKhoa.Clear();
            tbSDT.Clear();
        }

        private void BtnNew2_Click(object sender, EventArgs e)
        {
            tbNganh2.Clear();
            tbKhoaL2.Focus();
            tbSiSo2.Clear();
            tbKhoaL2.Clear();
            tbLop2.Clear();
        }

        private void BtnNew3_Click(object sender, EventArgs e)
        {
            tbSDT3.Clear();
            tbHoTen3.Clear();
            tbHoTen3.Focus();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            dateTimePicker1.Refresh();
        }

        private void TbHoTen3_TextChanged(object sender, EventArgs e)
        {
            btnSave3.Enabled = true;
        }

        private void TbKhoaL2_TextChanged(object sender, EventArgs e)
        {
            btnSave2.Enabled = true;
        }

        private void cboLop1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgSinhVien.DataSource = svbll.SinhVien_Select(cboLop1.SelectedValue.ToString());
        }

        private void btnSave3_Click(object sender, EventArgs e)
        {
            DialogResult key = MessageBox.Show("Bạn có muốn lưu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (key == DialogResult.Yes)
            {
                try
                {
                    StreamReader sr = new StreamReader("data.txt");
                    string maSV = sr.ReadLine();
                    sr.Close();
                    int maSV1 = 1 + int.Parse(maSV);
                    StreamWriter sw = new StreamWriter("data.txt");
                    sw.Write(maSV1);
                    sw.Close();
                    svbll.SinhVien_Insert(maSV1.ToString(), cboLop1.SelectedValue.ToString(), tbHoTen3.Text.ToString(), (radioButton1.Checked == true ? "True" : "False"), dateTimePicker1.Value.ToString("yyyy/MM/dd"), tbSDT3.Text.ToString());
                    dtgSinhVien.DataSource = svbll.SinhVien_Select(cboLop1.SelectedValue.ToString());
                }

                catch (Exception LOI)
                {
                    MessageBox.Show(LOI.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnCapNhap3_Click(object sender, EventArgs e)
        {
            DialogResult key = MessageBox.Show("Bạn có muốn cập nhật không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (key == DialogResult.Yes)
            {
                try
                {
                    svbll.SinhVien_Update(dtgSinhVien[0, dtgSinhVien.CurrentRow.Index].Value.ToString(), cboLop1.SelectedValue.ToString(), tbHoTen3.Text.ToString(), (radioButton1.Checked == true ? "True" : "False"), dateTimePicker1.Value.ToString("yyyy/MM/dd"), tbSDT3.Text.ToString());
                    dtgSinhVien.DataSource = svbll.SinhVien_Select(cboLop1.SelectedValue.ToString());
                }

                catch (Exception LOI)
                {
                    MessageBox.Show(LOI.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void dtgSinhVien_SelectionChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Text = dtgSinhVien[4, dtgSinhVien.CurrentRow.Index].Value.ToString();
            tbHoTen3.Text = dtgSinhVien[2, dtgSinhVien.CurrentRow.Index].Value.ToString();
            tbSDT3.Text = dtgSinhVien[5, dtgSinhVien.CurrentRow.Index].Value.ToString();
            if (String.Compare(dtgSinhVien[3, dtgSinhVien.CurrentRow.Index].Value.ToString(), "True") == 0)
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;
        }

        private void btnXoa3_Click(object sender, EventArgs e)
        {
            DialogResult key = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (key == DialogResult.Yes)
            {
                try
                {
                    svbll.SinhVien_Delete(dtgSinhVien[0, dtgSinhVien.CurrentRow.Index].Value.ToString());
                    dtgSinhVien.DataSource = svbll.SinhVien_Select(cboLop1.SelectedValue.ToString());
                }

                catch (Exception LOI)
                {
                    MessageBox.Show(LOI.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dtgLop_SelectionChanged(object sender, EventArgs e)
        {
            string a = dtgLop[0, dtgLop.CurrentRow.Index].Value.ToString();
            tbKhoaL2.Text = a.Substring(0, 3);
            tbLop2.Text = a.Substring(3, 1);
            tbSiSo2.Text = dtgLop[3, dtgLop.CurrentRow.Index].Value.ToString();
            string[] s;
            string b = dtgLop[2, dtgLop.CurrentRow.Index].Value.ToString();
            s = b.Split(' ');
            string c = null;
            for (int i = 1; i < s.Length; i++)
                c = c + s[i] + " ";
            c = c.TrimEnd();
            tbNganh2.Text = c;
        }

        private void btnExit1_Click(object sender, EventArgs e)
        {
            if (btnSave1.Enabled == true)
            {
                BtnSave1_Click(sender, e);
                this.Close();
            }
            else
                this.Close();
        }

        private void btnExit2_Click(object sender, EventArgs e)
        {
            if (btnSave2.Enabled == true)
            {
                BtnSave2_Click(sender, e);
                this.Close();
            }
            else
                this.Close();
        }

        private void btnExit3_Click(object sender, EventArgs e)
        {
            if (btnSave3.Enabled == true)
            {
                btnSave3_Click(sender, e);
                this.Close();
            }
            else
                this.Close();
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 dlg2 = new Form2();
            dlg2.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tbTKSV_TextChanged(object sender, EventArgs e)
        {
            dtgSinhVien.DataSource = svbll.SinhVien_TimKiem(tbTKSV.Text.ToString());
        }

        private void tbTKLop_TextChanged(object sender, EventArgs e)
        {
            dtgLop.DataSource = lopbll.Lop_TimKiem(tbTKLop.Text.ToString());
        }

        private void tbTKKhoa_TextChanged(object sender, EventArgs e)
        {
            dtgKhoa.DataSource = khoabll.Khoa_TimKiem(tbTKKhoa.Text.ToString());
        }
    }
}

