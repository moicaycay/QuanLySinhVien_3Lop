using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataAccessLayer
{
    public class SinhVien_DAL
    {
        ThaoTac_CSDL thaotac = new ThaoTac_CSDL();
        string[] name = { };
        object[] value = { };
        public DataTable sv_select()
        {
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu("sl_SinhVien");
        }
        public DataTable sv_select(string malop)
        {
            //thaotac.KetnoiCSDL();
            name = new string[1];
            value = new object[1];
            name[0] = "@malop"; value[0] = malop;

            return thaotac.SQL_Laydulieu("sl_SinhVienLop", name, value, 1);
        }
        public int sv_insert(string MaSV, string MaLop,string hoten, string gioitinh,string ngaysinh,string sdt)
        {
            //thaotac.KetnoiCSDL();
            name = new string[6];
            value = new object[6];
            name[0] = "@MaSV"; value[0] = MaSV;//@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[1] = "@Malop"; value[1] = MaLop;
            name[2] = "@TenSV"; value[2] = hoten;
            name[3] = "@gioitinh"; value[3] = gioitinh;
            name[4] = "@Ngaysinh"; value[4] = ngaysinh;
            name[5] = "@sdt"; value[5] = sdt;
            return thaotac.SQL_Thuchien("is_SinhVien", name, value, 6);
        }
        public int sv_update(string MaSV, string MaLop, string hoten, string gioitinh, string ngaysinh, string sdt)
        {
            name = new string[6];
            value = new object[6];
            name[0] = "@MaSV"; value[0] = MaSV;//@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[1] = "@Malop"; value[1] = MaLop;
            name[2] = "@TenSV"; value[2] = hoten;
            name[3] = "@gioitinh"; value[3] = gioitinh;
            name[4] = "@Ngaysinh"; value[4] = ngaysinh;
            name[5] = "@sdt"; value[5] = sdt;
            return thaotac.SQL_Thuchien("ud_SinhVien", name, value, 6);
        }
        public int sv_delete(string maSV)
        {
            name = new string[2];
            value = new object[2];
            name[0] = "@Ten"; value[0] = "sinhvien";
            name[1] = "@ma"; value[1] = maSV;
            return thaotac.SQL_Thuchien("SinhVien_Delete", name, value, 2);
        }
        public DataTable sv_TimKiem(string ten, string malop)
        {
            //thaotac.KetnoiCSDL();
            name = new string[2];
            value = new object[2];
            name[0] = "@ten"; value[0] = ten;
            name[1] = "@malop"; value[1] = malop;

            return thaotac.SQL_Laydulieu("tk_SinhVien", name, value, 2);
        }


        }
}
