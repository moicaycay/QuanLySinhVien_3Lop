using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataAccessLayer
{
    public class Lop_DAL
    {
        ThaoTac_CSDL thaotac = new ThaoTac_CSDL();
        string[] name = { };
        object[] value = { };
        public DataTable Lop_select(string makhoa)
        {
            //thaotac.KetnoiCSDL();
            name = new string[1];
            value = new object[1];
            name[0] = "@makhoa"; value[0] = makhoa;
            
            return thaotac.SQL_Laydulieu("sl_LopKhoa",name,value,1);
        }
        public int Lop_insert(string malop,string makhoa, string tenlop, string siso)
        {
            name = new string[4];
            value = new object[4];
            name[0] = "@Malop"; value[0] = malop;
            name[1] = "@MaKhoa"; value[1] = makhoa;
            name[2] = "@TenLop"; value[2] = tenlop;
            name[3] = "@SiSo"; value[3] = siso;
            return thaotac.SQL_Thuchien("is_lop", name, value, 4);
        }
        public int Lop_update(string malop, string makhoa, string tenlop, string siso)
        {
            name = new string[4];
            value = new object[4];
            name[0] = "@malop"; value[0] = malop;
            name[1] = "@makhoa"; value[1] = makhoa;
            name[2] = "@tenlop"; value[2] = tenlop;
            name[3] = "@siso"; value[3] = siso;
            return thaotac.SQL_Thuchien("ud_lop", name, value, 4);
        }
        public int Lop_delete(string maSV)
        {
            name = new string[2];
            value = new object[2];
            name[0] = "@Ten"; value[0] = "Lop";
            name[1] = "@ma"; value[1] = maSV;
            return thaotac.SQL_Thuchien("de_TuyChon", name, value, 2);
        }
    }
}
