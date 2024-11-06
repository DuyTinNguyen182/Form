using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanVien_LT2
{
    public partial class FrmQuanLyNhanVien_LT2 : Form
    {
        XuLyNhanVien xulyNV = new XuLyNhanVien();
        int donghh;

        public FrmQuanLyNhanVien_LT2()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NhapLai()
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            txtNamSinh.Text = "";
            txtDienThoai.Text = "";
            cbDiaChi.SelectedIndex = 0;
            cbGioiTinh.SelectedIndex = 2;
        }
        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void FrmQuanLyNhanVien_LT2_Load(object sender, EventArgs e)
        {
            xulyNV.HienThiNhanVien(dgvNhanVien);
            xulyNV.HienThiPhong(cbMaPhong);
            cbDiaChi.SelectedIndex = 0;
            cbGioiTinh.SelectedIndex = 2;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xulyNV.ThemNhanVien(txtMaNV.Text.ToString(), txtHoTen.Text.ToString(), int.Parse(txtNamSinh.Text.ToString()), cbGioiTinh.Text.ToString(), cbDiaChi.Text.ToString(), txtDienThoai.Text.ToString(), cbMaPhong.SelectedValue.ToString());
            xulyNV.HienThiNhanVien(dgvNhanVien);
            NhapLai();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xulyNV.SuaNhanVien(txtMaNV.Text.ToString(), txtHoTen.Text.ToString(), int.Parse(txtNamSinh.Text.ToString()), cbGioiTinh.Text.ToString(), cbDiaChi.Text.ToString(), txtDienThoai.Text.ToString(), cbMaPhong.SelectedValue.ToString());
            xulyNV.HienThiNhanVien(dgvNhanVien);
            NhapLai();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            xulyNV.XoaNhanVien(txtMaNV.Text.ToString());
            xulyNV.HienThiNhanVien(dgvNhanVien);
        }

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            donghh = e.RowIndex;
            if (donghh >= 0)
            {
                txtMaNV.Text = xulyNV.bangnv.Rows[donghh]["MaNV"].ToString();
                txtHoTen.Text = xulyNV.bangnv.Rows[donghh]["HoTen"].ToString();
                txtNamSinh.Text = xulyNV.bangnv.Rows[donghh]["NamSinh"].ToString();
                cbGioiTinh.Text = xulyNV.bangnv.Rows[donghh]["GioiTinh"].ToString();
                cbDiaChi.Text = xulyNV.bangnv.Rows[donghh]["DiaChi"].ToString();
                txtDienThoai.Text = xulyNV.bangnv.Rows[donghh]["DienThoai"].ToString();
                cbMaPhong.SelectedValue = xulyNV.bangnv.Rows[donghh]["maphong"];
                txtMaNV.Enabled = false;
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            NhapLai();
        }

        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            FrmPhongBan frmpb = new FrmPhongBan();
            frmpb.Show();
        }
    }
}
