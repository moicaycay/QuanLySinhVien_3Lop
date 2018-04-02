using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;

namespace BussinessLogicLayer
{
    public class Lop_BLL
    {
        Lop_DAL lopdal = new Lop_DAL();
        public DataTable Lop_Select(string malop)
        {
            return lopdal.Lop_select(malop);
        }
        public int Lop_Update(string malop, string makhoa, string tenlop, string siso)
        {
            return lopdal.Lop_update(malop,makhoa, tenlop, siso);
        }
        public int Lop_Insert(string malop, string makhoa, string tenlop, string siso)
        {
            return lopdal.Lop_insert(malop, makhoa, tenlop, siso);
        }

        //phương thức này gọi phương thức lop_delete() ở lớp Lop_DAL (tầng DAL)
        public int Lop_Delete(string malop)
        {
            return lopdal.Lop_delete(malop);
        }
    }
}
