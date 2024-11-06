using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Nếu chưa có cái nào thì khai báo
using System.Data;
using System.Windows.Forms;

namespace QuanLyNhanVien_LT2
{
    class XuLyNhanVien
    {
        KetNoiDuLieu ketnoi = new KetNoiDuLieu();
        public DataTable bangnv = new DataTable();

        public void HienThiNhanVien(DataGridView dgv)
        {
            string sql = "select * from nhanvien";
            bangnv = ketnoi.DocDuLieu(sql);
            dgv.DataSource = bangnv;
        }

        public void HienThiPhong(ComboBox cmb)
        {
            string sql = "select * from phongban";
            cmb.DataSource = ketnoi.DocDuLieu(sql);
            cmb.DisplayMember = "tenphong";
            cmb.ValueMember = "maphong";
        }

        public void ThemNhanVien(string manv, string hoten, int namsinh, string gioitinh, string diachi, string dienthoai, string maphong)
        {
            string sqltam = "select * from nhanvien where manv = '" + manv + "'";
            DataTable bangtam = ketnoi.DocDuLieu(sqltam);
            if (bangtam.Rows.Count > 0)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại!", "Thông báo");
            }
            else
            {
                string sql = "insert into nhanvien Values('" + manv + "', N'" + hoten + "', '" + namsinh + "', N'" + gioitinh + "', N'" + diachi + "', '" + dienthoai + "', '" + maphong + "')";
                ketnoi.ThaoTacDuLieu(sql);
                bangnv.Clear();
            }            
        }

        public void SuaNhanVien(string manv, string hoten, int namsinh, string gioitinh, string diachi, string dienthoai, string maphong)
        {
            string sql = "Update nhanvien set hoten = N'" + hoten + "', namsinh = '" + namsinh + "', gioitinh =  N'" + gioitinh + "', diachi = N'" + diachi + "', dienthoai = '" + dienthoai + "', maphong = '" + maphong + "' where manv = '" + manv + "'";
            ketnoi.ThaoTacDuLieu(sql);
            bangnv.Clear();
        }

        public void XoaNhanVien(string manv)
        {
            string sql = "delete from nhanvien where MaNV = '" + manv + "'";
            ketnoi.ThaoTacDuLieu(sql);
            bangnv.Clear();
        }

        public void TimMa(string manv)
        {
            string sql = "select * from nhanvien where manv = '" + manv + "'";
            ketnoi.ThaoTacDuLieu(sql);

        }
    }
}
