using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhanVien_LT.DAL;

namespace QuanLyNhanVien_LT.BLL
{
    public class NhanVienBLL
    {
        private NhanVienDAL dal = new NhanVienDAL();

        public List<NhanVien> GetAllNhanVien()
        {
            return dal.GetAllNhanVien();
        }

        public bool AddNhanVien(NhanVien nv)
        {
            return dal.AddNhanVien(nv);
        }

        public bool UpdateNhanVien(NhanVien nv)
        {
            return dal.UpdateNhanVien(nv);
        }

        public bool DeleteNhanVien(string maNV)
        {
            return dal.DeleteNhanVien(maNV);
        }

        public NhanVien TimKiemTheoMa(string maNV)
        {
            return dal.TimKiemTheoMa(maNV);
        }

        public NhanVien TimKiemTheoTen(string tenNV)
        {
            return dal.TimKiemTheoTen(tenNV);
        }

        public int DemSoLuongNhanVien()
        {
            return dal.DemSoLuongNhanVien();
        }
    }
}
