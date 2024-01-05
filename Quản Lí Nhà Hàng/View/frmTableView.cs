using Guna.UI2.WinForms;
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
    public partial class frmTableView : Form
    {
        public frmTableView()
        {
            InitializeComponent();
        }
        private void ThongKeVaCapNhatSoLuongBan()
        {
            // Lấy số lượng bàn từ DataGridView
            int soLuongBan = guna2DataGridView1.Rows.Count;

            // Hiển thị kết quả thống kê
            lblTongban.Text = soLuongBan.ToString();

            // Cập nhật số lượng bàn sau khi thêm mới
            if (guna2DataGridView1.Rows.Count > 0)
            {
                soLuongBan++; // Tăng số lượng bàn lên 1
            }

            lblTongban.Text = (soLuongBan-1).ToString();
        }

        private void frmTableView_Load(object sender, EventArgs e)
        {
            GetData();
            ThongKeVaCapNhatSoLuongBan(); // Thống kê và cập nhật số lượng bàn
        }
        public void GetData()
        {
            string qry = "Select * from tables where tName like '%" + txtSearch.Text + "%'";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvId);
            lb.Items.Add(dgvName);

            MainClass.LoadData(qry, guna2DataGridView1, lb);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new frmTableAdd());
            GetData();
            ThongKeVaCapNhatSoLuongBan(); // Thống kê và cập nhật số lượng bàn sau khi thêm mới
        }

        public virtual void  txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
                if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvEdit")
                {

                    frmcategoryAdd frm = new frmcategoryAdd();
                    frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvId"].Value);
                    frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
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
                        string qry = "Delete from   tables where  tID = " + id + "";
                        Hashtable ht = new Hashtable();
                        MainClass.SQl(qry, ht);

                        guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                        guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                        guna2MessageDialog1.Show("Xóa Thành Công");
                        GetData();
                    ThongKeVaCapNhatSoLuongBan();
                    }

                }
            

        }
    }
}
