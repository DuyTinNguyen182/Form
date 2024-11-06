using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Nếu chưa có cái nào thì khai báo
using System.Data;
using System.Data.SqlClient;

namespace QuanLyNhanVien_LT2
{
    class KetNoiDuLieu
    {
        public SqlConnection ketnoi;
        public SqlDataAdapter bodocghi;
        public SqlCommand lenh;
        public SqlCommandBuilder capnhat;

        public KetNoiDuLieu()
        {
            ketnoi = new SqlConnection();
            string chuoiketnoi = "Data Source = .; initial Catalog = QuanLyNhanVien_LT2; Integrated Security = true";
            ketnoi.ConnectionString = chuoiketnoi;
        }

        public DataTable DocDuLieu(string sql)
        {
            ketnoi.Open();
            bodocghi = new SqlDataAdapter(sql, ketnoi);
            DataTable bangtam = new DataTable();
            bodocghi.Fill(bangtam);
            ketnoi.Close();
            return bangtam;
        }

        public void ThaoTacDuLieu(string sql)
        {
            ketnoi.Open();
            lenh = new SqlCommand(sql, ketnoi);
            lenh.ExecuteNonQuery();
            ketnoi.Close();
        }

        public void CapNhatDuLieu(SqlDataAdapter bdg, DataTable dt)
        {
            capnhat = new SqlCommandBuilder(bdg);
            bdg.Update(dt);
        }
    }
}
