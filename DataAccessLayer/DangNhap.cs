using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataAccessLayer
{
    public class DangNhap
    {
        ThaoTac_CSDL thaotac = new ThaoTac_CSDL();
        string[] name = { };
        object[] value = { };
        public DataTable select(string tk, string mk)
        {
            name = new string[2];
            value = new string[2];
            name[0] = "@Ten"; value[0] = tk;
            name[1] = "@matkhau"; value[1] = mk;
            return thaotac.SQL_Laydulieu("sl_user", name, value, 2);


        }
    }
}
