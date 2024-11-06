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
    public partial class FrmPhongBan : Form
    {
        XuLyPhongBan xulyPB = new XuLyPhongBan();        
        int donghh;
        public FrmPhongBan()
        {
            InitializeComponent();
        }

        private void NhapLai()
        {
            txtMaPB.Text = "";
            txtTenPB.Text = "";
            txtMaPB.Enabled = true;
        }
        private void FrmPhongBan_Load(object sender, EventArgs e)
        {
            xulyPB.HienThiPhongBan(dgvPhongBan);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xulyPB.ThemPhongBan(txtMaPB.Text.ToString(), txtTenPB.Text.ToString());
            xulyPB.HienThiPhongBan(dgvPhongBan);
            NhapLai();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xulyPB.SuaPhongBan(txtMaPB.Text.ToString(), txtTenPB.Text.ToString());
            xulyPB.HienThiPhongBan(dgvPhongBan);
            NhapLai();
        }

        private void dgvPhongBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {            
        }

        private void dgvPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            donghh = e.RowIndex;
            if (donghh >= 0)
            {
                txtMaPB.Text = xulyPB.bangpb.Rows[donghh]["maphong"].ToString();
                txtTenPB.Text = xulyPB.bangpb.Rows[donghh]["tenphong"].ToString();
                txtMaPB.Enabled = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            xulyPB.XoaPhongBan(txtMaPB.Text.ToString());
            xulyPB.HienThiPhongBan(dgvPhongBan);
            NhapLai();
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            NhapLai();
        }
    }
}
