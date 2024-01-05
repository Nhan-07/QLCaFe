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

namespace Quản_Lí_Nhà_Hàng.Model
{
    public partial class frmcategoryAdd : Form
    {
        public frmcategoryAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

        public virtual void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và hợp lệ thông tin sản phẩm!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            string qry = "";
            if (id == 0) //insert
            {
                qry = "Insert into category Values(@Name)";
            }
            else
            {
                qry = "Update category Set catName = @Name where catID = @id ";

            }

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtName.Text);

           if(MainClass.SQl(qry, ht) > 0)
            {
                guna2MessageDialog1.Show("Lưu Thành Công");
                id = 0;
                txtName.Text = "";
                txtName.Focus();
            }

            
        }




    }
}
