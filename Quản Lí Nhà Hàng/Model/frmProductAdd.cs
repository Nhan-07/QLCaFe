using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_Lí_Nhà_Hàng.Model
{
    public partial class frmProductAdd : Form
    {
        public frmProductAdd()
        {
            InitializeComponent();
        }
        public int id = 0;
        public int cID =0;

       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProductAdd_Load(object sender, EventArgs e)
        {
            // For combobox fill
            string qry = "Select catID 'id' , catName 'name' from category ";
            MainClass.CBFill(qry, cbCat);

            if (cID > 0)// For updates
            {
                cbCat.SelectedValue = cID;
            }

            if (id > 0)
            {
                ForUpdateLoadData();
            }
        }
        string filepath;
        Byte[] imageByteArray;

        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg, .png)|* .png; *.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filepath = ofd.FileName;
                txtAnh.Image = new Bitmap(filepath);
            }
        }

        // for cb fill
        public void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(cbCat.Text) || txtAnh.Image == null || string.IsNullOrEmpty(txtName.Text) 
                || string.IsNullOrEmpty(txtGiaTien.Text) || !int.TryParse(txtGiaTien.Text, out _))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và hợp lệ thông tin sản phẩm!","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            string qry = "";

            if (id == 0)
            {
                qry = "Insert into products Values(@Name, @price, @cat, @img)";
            }
            else
            {
                qry = "Update products Set pName = @Name, pPrice = @price, CategoryID = @cat, pImage = @img where pID = @id";
            }

            //For image
            Image temp = new Bitmap(txtAnh.Image);
            MemoryStream ms = new MemoryStream();
            temp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            imageByteArray = ms.ToArray();

            Hashtable ht = new Hashtable();
            if (txtName.Text != "" && txtGiaTien.Text != "")
            {
                ht.Add("@id", id);
                ht.Add("@Name", txtName.Text);
                ht.Add("@price", txtGiaTien.Text);
                ht.Add("@cat", Convert.ToInt32(cbCat.SelectedValue));
                ht.Add("@img", imageByteArray);

                if (MainClass.SQl(qry, ht) > 0)
                {
                    guna2MessageDialog1.Show("Lưu Thành công");
                    id = 0;
                    cID = 0;
                    txtName.Text = "";
                    txtGiaTien.Text = "";
                    cbCat.SelectedIndex = -1;
                    cbCat.SelectedIndex = 0;

                    txtAnh.Image = Quản_Lí_Nhà_Hàng.Properties.Resources.picBlue;
                    txtName.Focus();
                }
            }
           
        }
        private void ForUpdateLoadData()
        {
            string qry = @"Select * from products where pid = " + id + "";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["pName"].ToString();
                txtGiaTien.Text = dt.Rows[0]["pPrice"].ToString();

                Byte[] imageArray = (byte[])(dt.Rows[0]["pImage"]);
                byte[] imageByteArray = imageArray;
                txtAnh.Image = Image.FromStream(new MemoryStream(imageArray));
            }
        }

    }
}
