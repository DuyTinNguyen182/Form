using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyNhanVien_LT.DAL
{
    public class NhanVienDAL
    {
        private string connectionString = "Data Source= .;Initial Catalog=QuanLyNhanVien_LT2;Integrated Security=True";

        public List<NhanVien> GetAllNhanVien()
        {
            List<NhanVien> list = new List<NhanVien>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM NhanVien", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    NhanVien nv = new NhanVien
                    {
                        MaNV = reader["MaNV"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        NamSinh = Convert.ToInt32(reader["NamSinh"]),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        DienThoai = reader["DienThoai"].ToString(),
                        MaPhong = reader["MaPhong"].ToString()
                    };
                    list.Add(nv);
                }
            }
            return list;
        }

        public bool AddNhanVien(NhanVien nv)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO NhanVien VALUES (@MaNV, @HoTen, @NamSinh, @GioiTinh, @DiaChi, @DienThoai, @MaPhong)", conn);
                cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
                cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
                cmd.Parameters.AddWithValue("@NamSinh", nv.NamSinh);
                cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
                cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
                cmd.Parameters.AddWithValue("@DienThoai", nv.DienThoai);
                cmd.Parameters.AddWithValue("@MaPhong", nv.MaPhong);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateNhanVien(NhanVien nv)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE NhanVien SET HoTen=@HoTen, NamSinh=@NamSinh, GioiTinh=@GioiTinh, DiaChi=@DiaChi, DienThoai=@DienThoai, MaPhong=@MaPhong WHERE MaNV=@MaNV", conn);
                cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
                cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
                cmd.Parameters.AddWithValue("@NamSinh", nv.NamSinh);
                cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
                cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
                cmd.Parameters.AddWithValue("@DienThoai", nv.DienThoai);
                cmd.Parameters.AddWithValue("@MaPhong", nv.MaPhong);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteNhanVien(string maNV)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM NhanVien WHERE MaNV=@MaNV", conn);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Tìm kiếm nhân viên theo mã
        public NhanVien TimKiemTheoMa(string maNV)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Sử dụng JOIN để lấy tên phòng từ bảng PhongBan
                string query = @"SELECT nv.MaNV, nv.HoTen, nv.NamSinh, nv.GioiTinh, nv.DiaChi, nv.DienThoai, pb.TenPhong 
                         FROM NhanVien nv
                         JOIN PhongBan pb ON nv.MaPhong = pb.MaPhong
                         WHERE nv.MaNV = @MaNV";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    NhanVien nv = new NhanVien
                    {
                        MaNV = reader["MaNV"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        NamSinh = Convert.ToInt32(reader["NamSinh"]),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        DienThoai = reader["DienThoai"].ToString(),
                        TenPhong = reader["TenPhong"].ToString()
                    };
                    reader.Close();
                    return nv;
                }
                reader.Close();
            }
            return null; // Không tìm thấy
        }

        // Tìm kiếm nhân viên theo tên
        public NhanVien TimKiemTheoTen(string tenNV)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT nv.MaNV, nv.HoTen, nv.NamSinh, nv.GioiTinh, nv.DiaChi, nv.DienThoai, pb.TenPhong 
                         FROM NhanVien nv
                         JOIN PhongBan pb ON nv.MaPhong = pb.MaPhong
                         WHERE nv.HoTen = @HoTen";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HoTen", tenNV);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    NhanVien nv = new NhanVien
                    {
                        MaNV = reader["MaNV"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        NamSinh = Convert.ToInt32(reader["NamSinh"]),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        DienThoai = reader["DienThoai"].ToString(),
                        TenPhong = reader["TenPhong"].ToString()
                    };
                    reader.Close();
                    return nv;
                }
                reader.Close();
            }
            return null; // Không tìm thấy
        }


        // Đếm số lượng nhân viên
        public int DemSoLuongNhanVien()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM NhanVien";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count;
            }
        }
    }
}
