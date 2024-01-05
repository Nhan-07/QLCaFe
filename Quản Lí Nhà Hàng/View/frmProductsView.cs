using Quản_Lí_Nhà_Hàng.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Quản_Lí_Nhà_Hàng.View
{
    public partial class frmProductsView : Form
    {
        public frmProductsView()
        {
            InitializeComponent();
        }
        private void ThongKeVaCapNhatSoLuongSanPham()
        {
            // Lấy số lượng sản phẩm từ DataGridView
            int soLuongSanPham = guna2DataGridView1.Rows.Count;

            // Hiển thị kết quả thống kê
            lblTongSp.Text = soLuongSanPham.ToString();

            // Cập nhật số lượng sản phẩm sau khi thêm mới
            if (guna2DataGridView1.Rows.Count > 0)
            {
                soLuongSanPham++; // Tăng số lượng sản phẩm lên 1
            }

            lblTongSp.Text = (soLuongSanPham-1).ToString();
        }

        private void frmProductsView_Load(object sender, EventArgs e)
        {
            GetData();
            ThongKeVaCapNhatSoLuongSanPham(); // Thống kê và cập nhật số lượng sản phẩm
        }
        public void GetData()
        {
            string qry = "select pID,pName,pPrice,CategoryID,c.catName from products  p inner Join category c on c.catID = p.CategoryID where pName like'%" + txtSearch.Text + "%'";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvId);
            lb.Items.Add(dgvName);
            lb .Items.Add(dgvPrice);
            lb.Items.Add(dgvcatID);
            lb.Items.Add(dgvcat);

            MainClass.LoadData(qry, guna2DataGridView1, lb);
            ThongKeVaCapNhatSoLuongSanPham();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new frmProductAdd());
            GetData();
            ThongKeVaCapNhatSoLuongSanPham(); // Thống kê và cập nhật số lượng sản phẩm sau khi thêm mới
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvEdit")
            {

                frmProductAdd frm = new frmProductAdd();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvId"].Value);
                frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
                frm.txtGiaTien.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvPrice"].Value);
                frm.cbCat.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvcat"].Value);
                frm.ShowDialog();
                GetData();

            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                // need to confirm before  delete
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;

                if (guna2MessageDialog1.Show("Bạn  có chắc muốn xóa không ?") == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvId"].Value);
                    string qry = "Delete from  products where  pID = " + id + "";
                    Hashtable ht = new Hashtable();
                    MainClass.SQl(qry, ht);

                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    guna2MessageDialog1.Show("Xóa Thành Công");
                    GetData();
                    ThongKeVaCapNhatSoLuongSanPham();
                }

            }
        }
    }
}
