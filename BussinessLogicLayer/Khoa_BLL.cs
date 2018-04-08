using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer;

namespace BussinessLogicLayer
{
    public class Khoa_BLL
    {
       
        Khoa_DAL khoadal = new Khoa_DAL();
        public DataTable Khoa_Select()
        {
            return khoadal.khoa_select();
        }

        //phương thức này gọi phương thức khoa_update() ở lớp SinhVien_DAL (tầng DAL)
        public int Khoa_Update(string Makhoa, string TenKhoa, string sdt)
        {
            return khoadal.khoa_update(Makhoa,TenKhoa, sdt);
        }
        public int Khoa_Insert(string Makhoa, string TenKhoa, string sdt)
        {
            return khoadal.khoa_insert(Makhoa,TenKhoa,sdt);
        }

        //phương thức này gọi phương thức khoa_delete() ở lớp SinhVien_DAL (tầng DAL)
        public int Khoa_Delete(string makhoa)
        {
            return khoadal.khoa_delete(makhoa);
        }
        public DataTable Khoa_TimKiem(string text)
        {
            return khoadal.TimKiem(text);
        }
    }
}
