using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer;

namespace BussinessLogicLayer
{
    public class DangNhap_BLL
    {
        DangNhap dn = new DangNhap();
        public DataTable Select(string tk, string mk)
        {
            return dn.select(tk,mk);
        }
    }
}
