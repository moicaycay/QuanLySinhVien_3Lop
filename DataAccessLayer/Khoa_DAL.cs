﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataAccessLayer
{
    public class Khoa_DAL
    {
        ThaoTac_CSDL thaotac = new ThaoTac_CSDL();
        string[] name = { };
        object[] value = { };
        public DataTable khoa_select()
        {
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu("sl_Khoa");
        }
        public int khoa_insert(string makhoa, string tenkhoa, string sdt)
        {
            name = new string[3];
            value = new object[3];
            name[0] = "@makhoa"; value[0] = makhoa;
            name[1] = "@tenkhoa"; value[1] = tenkhoa;
            name[2] = "@SDt"; value[2] = sdt;
            return thaotac.SQL_Thuchien("is_Khoa",name, value, 3);
        }
        public int khoa_update(string makhoa, string tenkhoa, string sdt)
        {
            name = new string[3];
            value = new object[3];
            name[0] = "@makhoa"; value[0] = makhoa;
            name[1] = "@tenkhoa"; value[1] = tenkhoa;
            name[2] = "@SDt"; value[2] = sdt;
            return thaotac.SQL_Thuchien("ud_Khoa", name, value, 3);
        }
        public int khoa_delete(string ma)
        {
            name = new string[2];
            value = new object[2];
            name[0] = "@Ten"; value[0] = "Khoa";
            name[1] = "@ma"; value[1] = ma;
            return thaotac.SQL_Thuchien("de_Tuychon", name, value, 2);
        }
        public DataTable TimKiem(string text)
        {
            //thaotac.KetnoiCSDL();
            name = new string[1];
            value = new object[1];
            name[0] = "@chuoitim"; value[0] = text;


            return thaotac.SQL_Laydulieu("tk_Khoa", name, value, 1);
        }
    }
}
