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
    public partial class Form1 : Form
    {
        Khoa_BLL khoabll = new Khoa_BLL();
        Lop_BLL lopbll = new Lop_BLL();
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
                    khoabll.Khoa_Insert(tbMaKhoa.Text.ToString(), tbTenKhoa.Text.ToString(), tbSDT.Text.ToString());
                    dtgKhoa.DataSource = dtgKhoa.DataSource = khoabll.Khoa_Select();
                    cboKhoa2.DataSource = khoabll.Khoa_Select() ;
                    cboKhoa2.DisplayMember = "TenKhoa";
                    cboKhoa2.ValueMember = "MaKhoa";
                    cboKhoa3.DataSource =  khoabll.Khoa_Select() ;
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
                    khoabll.Khoa_Delete(dtgSinhVien[0, dtgSinhVien.CurrentRow.Index].Value.ToString());
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
            cboKhoa3.DataSource = lopbll.Lop_Select(cboKhoa3.SelectedValue.ToString());
            cboKhoa3.DisplayMember = "TenKhoa";
            cboKhoa3.ValueMember = "MaKhoa";
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
            tbMaKhoa.Focus();
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
    }
}
