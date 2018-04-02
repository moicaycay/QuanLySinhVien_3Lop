using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer;


namespace BussinessLogicLayer
{
    public class SinhVien_BLL
    {
        SinhVien_DAL svdal = new SinhVien_DAL();
        public DataTable SinhVien_Select()
        {
            return svdal.sv_select();
        }

        //phương thức này gọi phương thức sv_update() ở lớp SinhVien_DAL (tầng DAL)
        public int SinhVien_Update(string MaSV, string MaLop, string hoten, string gioitinh, string ngaysinh, string sdt)
        {
            return svdal.sv_update(MaSV,MaLop,hoten,gioitinh,ngaysinh,sdt);
        }
        public int SinhVien_Insert(string MaSV, string MaLop, string hoten, string gioitinh, string ngaysinh, string sdt)
        {
            return svdal.sv_insert(MaSV, MaLop, hoten, gioitinh, ngaysinh, sdt);
        }

        //phương thức này gọi phương thức sv_delete() ở lớp SinhVien_DAL (tầng DAL)
        public int SinhVien_Delete(string maSV)
        {
            return svdal.sv_delete(maSV);
        }


    }
}
