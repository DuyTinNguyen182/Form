using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NhanVienPhongBan
{
    public partial class FrmNVPB : Form
    {
        public FrmNVPB()
        {
            InitializeComponent();
        }
        SqlConnection ketnoi;
        SqlDataAdapter bodocghi;
        SqlDataAdapter bodocghiphongban;
        int donghh;
        DataTable bangnv = new DataTable();
        DataTable bangpb = new DataTable();
        void KetNoiDuLieu()
        {
            ketnoi = new SqlConnection();
            string chuoiketnoi = "Data Source= .;Initial Catalog=QuanLyNhanVien_LT2;Integrated Security=True";
            ketnoi.ConnectionString = chuoiketnoi;
        }
        void LoadDuLieu()
        {
            KetNoiDuLieu();
            ketnoi.Open();
            string sql = "select * From NhanVien";
            bodocghi = new SqlDataAdapter(sql, ketnoi);
            bodocghi.Fill(bangnv);
            ketnoi.Close();
            dgvNhanVien.DataSource = bangnv;
        }
        void LoadPhongBan()
        {
            String sql = "Select * from phongban";
            bodocghiphongban = new SqlDataAdapter(sql, ketnoi);
            bodocghiphongban.Fill(bangpb);
            //Hiển thị combobox
            cmbPhongBan.DataSource = bangpb;
            cmbPhongBan.DisplayMember = "tenphong";
            cmbPhongBan.ValueMember = "maphong";
        }
        void ThemMoi()
        {
            txtMaNV.Enabled = true;
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            txtNamSinh.Text = "";
            cmbGioiTinh.Text = "";
            cmbDiaChi.Text = "";
            txtDienThoai.Text = "";
            cmbDiaChi.SelectedIndex = 0;
            cmbGioiTinh.SelectedIndex = 2;
        }
        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmNVPB_Load(object sender, EventArgs e)
        {
            cmbDiaChi.SelectedIndex = 0;
            cmbGioiTinh.SelectedIndex = 2;           
            LoadDuLieu();
            LoadPhongBan();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "")
                MessageBox.Show("Mã nhân viên không được để trống");
            else
            {
                ketnoi.Open();
                String sql = "Select count(*) From NhanVien where MaNV ='" + txtMaNV.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, ketnoi);
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!");
                    ketnoi.Close();
                }
                else
                {
                    DataRow dongmoi = bangnv.NewRow();
                    dongmoi["MaNV"] = txtMaNV.Text;
                    dongmoi["HoTen"] = txtHoTen.Text;
                    dongmoi["NamSinh"] = txtNamSinh.Text;
                    dongmoi["GioiTinh"] = cmbGioiTinh.Text;
                    dongmoi["DiaChi"] = cmbDiaChi.Text;
                    dongmoi["DienThoai"] = txtDienThoai.Text;
                    dongmoi["maphong"] = cmbPhongBan.SelectedValue;                    
                    bangnv.Rows.Add(dongmoi);
                    //cap nhat CSDL
                    SqlCommandBuilder capnhat = new SqlCommandBuilder(bodocghi);//Đi đôi với DataAdapter
                    bodocghi.Update(bangnv);
                    ketnoi.Close();
                    bangnv.Clear();
                    LoadDuLieu();
                    MessageBox.Show("Thêm nhân viên thành công!");
                    txtMaNV.Enabled = true;
                    ThemMoi();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bangnv.Rows[donghh].Delete();
            ketnoi.Open();
            SqlCommandBuilder capnhat = new SqlCommandBuilder(bodocghi);
            bodocghi.Update(bangnv);
            ketnoi.Close();
            bangnv.Clear();
            LoadDuLieu();
            MessageBox.Show("Xóa nhân viên thành công!");
            ThemMoi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            bangnv.Rows[donghh]["MaNV"] = txtMaNV.Text;
            bangnv.Rows[donghh]["HoTen"] = txtHoTen.Text;
            bangnv.Rows[donghh]["NamSinh"] = txtNamSinh.Text;
            bangnv.Rows[donghh]["GioiTinh"] = cmbGioiTinh.Text;
            bangnv.Rows[donghh]["DiaChi"] = cmbDiaChi.Text;
            bangnv.Rows[donghh]["DienThoai"] = txtDienThoai.Text;
            bangnv.Rows[donghh]["maphong"] = cmbPhongBan.SelectedValue;
            //cap nhat CSDL
            ketnoi.Open();
            SqlCommandBuilder capnhat = new SqlCommandBuilder(bodocghi);
            bodocghi.Update(bangnv);
            ketnoi.Close();
            bangnv.Clear();
            LoadDuLieu();
            MessageBox.Show("Thông tin nhân viên đã được sửa!");
            ThemMoi();
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            donghh = e.RowIndex;
            if (donghh >= 0)
            {
                txtMaNV.Text = bangnv.Rows[donghh]["MaNV"].ToString();
                txtHoTen.Text = bangnv.Rows[donghh]["HoTen"].ToString();
                txtNamSinh.Text = bangnv.Rows[donghh]["NamSinh"].ToString();
                cmbGioiTinh.Text = bangnv.Rows[donghh]["GioiTinh"].ToString();
                cmbDiaChi.Text = bangnv.Rows[donghh]["DiaChi"].ToString();
                txtDienThoai.Text = bangnv.Rows[donghh]["DienThoai"].ToString();                
                cmbPhongBan.SelectedValue = bangnv.Rows[donghh]["maphong"];
                txtMaNV.Enabled = false;
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            //ThemMoi();
        }
    }
}
