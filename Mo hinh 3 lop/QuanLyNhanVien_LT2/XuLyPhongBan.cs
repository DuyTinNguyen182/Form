using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace QuanLyNhanVien_LT2
{
    class XuLyPhongBan
    {
        KetNoiDuLieu ketnoi = new KetNoiDuLieu();
        public DataTable bangpb = new DataTable();

        public void HienThiPhongBan(DataGridView dgv)
        {
            string sql = "select * from phongban";
            bangpb = ketnoi.DocDuLieu(sql);
            dgv.DataSource = bangpb;
        }

        public void ThemPhongBan(string maphong, string tenphong)
        {
            string sqltam = "select * from phongban where maphong = '" + maphong + "'";
            DataTable bangtam = ketnoi.DocDuLieu(sqltam);
            if (bangtam.Rows.Count > 0)
            {
                MessageBox.Show("Mã phòng ban đã tồn tại!", "Thông báo");
            }
            else
            {
                string sql = "insert into phongban Values('" + maphong + "', N'" + tenphong + "')";
                ketnoi.ThaoTacDuLieu(sql);
                bangpb.Clear();
            }
        }

        public void SuaPhongBan(string maphong, string tenphong)
        {
            string sql = "Update phongban set tenphong = N'" + tenphong + "' where maphong = '"+maphong+"'";
            ketnoi.ThaoTacDuLieu(sql);
            bangpb.Clear();
        }

        public void XoaPhongBan(string maphong)
        {
            string sql = "delete from phongban where maphong = '" + maphong + "'";
            ketnoi.ThaoTacDuLieu(sql);
            bangpb.Clear();
        }
    }
}
