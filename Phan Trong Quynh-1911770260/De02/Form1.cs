using System.Collections.Generic;
using System.Windows.Forms;
using System;
namespace QLSP
{
    public partial class FormSanPham : Form
    {
        List<SanPham> danhSachSanPham = new List<SanPham>();
        SanPham sanPhamMoi;

        public FormSanPham()
        {
            InitializeComponent();

            // Khởi tạo dữ liệu mẫu
            danhSachSanPham.Add(new SanPham() { MaSP = "SP001", TenSP = "Sản phẩm A", NgayNhap = DateTime.Now, LoaiSP = "Loại 1" });
            HienThiDanhSach();
        }

        public FormSanPham(SanPham sanPham)
        {
            InitializeComponent();
            sanPhamMoi = sanPham;
        }

        private void HienThiDanhSach()
        {
            listView1.Items.Clear();
            foreach (SanPham sp in danhSachSanPham)
            {
                ListViewItem item = new ListViewItem(sp.MaSP);
                item.SubItems.Add(sp.TenSP);
                item.SubItems.Add(sp.NgayNhap.ToShortDateString());
                item.SubItems.Add(sp.LoaiSP);
                listView1.Items.Add(item);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SanPham sanPhamMoi = new SanPham();
            sanPhamMoi.MaSP = txtMaSP.Text;
            sanPhamMoi.TenSP = txtTenSP.Text;
            sanPhamMoi.NgayNhap = DateTime.Parse(txtNgayNhap.Text);
            sanPhamMoi.LoaiSP = txtLoaiSP.Text;

            FormSanPham frmSanPham = new FormSanPham(sanPhamMoi);
            if (frmSanPham.ShowDialog() == DialogResult.OK)
            {
                danhSachSanPham.Add(frmSanPham.sanPhamMoi);
                HienThiDanhSach();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SanPham sanPhamMoi = new SanPham();
            FormSanPham frmSanPham = new FormSanPham(sanPhamMoi);
            if (frmSanPham.ShowDialog() == DialogResult.OK)
            {
                danhSachSanPham.Add(frmSanPham.sanPhamMoi);
                HienThiDanhSach();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                string maSP = item.SubItems[0].Text;
                SanPham sp = danhSachSanPham.Find(x => x.MaSP == maSP);

                if (sp != null)
                {
                    FormSanPham frmSanPham = new FormSanPham(sp);
                    if (frmSanPham.ShowDialog() == DialogResult.OK)
                    {
                        // Cập nhật thông tin sản phẩm
                        int index = danhSachSanPham.FindIndex(x => x.MaSP == maSP);
                        if (index != -1)
                        {
                            danhSachSanPham[index] = frmSanPham.sanPhamMoi;
                            HienThiDanhSach();
                            MessageBox.Show("Đã cập nhật thông tin sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SanPham sanPhamMoi = new SanPham();
            sanPhamMoi.MaSP = txtMaSP.Text;
            sanPhamMoi.TenSP = txtTenSP.Text;
            sanPhamMoi.NgayNhap = DateTime.Parse(txtNgayNhap.Text);
            sanPhamMoi.LoaiSP = txtLoaiSP.Text;

            FormSanPham frmSanPham = new FormSanPham(sanPhamMoi);
            if (frmSanPham.ShowDialog() == DialogResult.OK)
            {
                danhSachSanPham.Add(frmSanPham.sanPhamMoi);
                HienThiDanhSach();
            }
        }
        private void XoaSanPham(string maSP)
        {
            if (danhSachSanPham.RemoveAll(x => x.MaSP == maSP) > 0)
            {
                MessageBox.Show("Đã xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSach();
            }
        }
        public class SanPham
        {
            public string MaSP { get; set; }
            public string TenSP { get; set; }
            public DateTime NgayNhap { get; set; }
            public string LoaiSP { get; set; }
        }
    }
}