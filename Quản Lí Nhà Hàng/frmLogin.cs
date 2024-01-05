using Quản_Lí_Nhà_Hàng.Model;
using Quản_Lí_Nhà_Hàng.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_Lí_Nhà_Hàng
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (MainClass.IsValidUser(txtUser.Text, txtPass.Text) == false)
            {
                guna2MessageDialog1.Show("Sai username hoặc password");
                return;
            }
            else
            {
                string ten = txtUser.Text;
                string qry = "SELECT * FROM Users WHERE Username = @Username";

                using (SqlCommand cmd = new SqlCommand(qry, MainClass.con))
                {
                    cmd.Parameters.AddWithValue("@Username", ten);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        // Dữ liệu được lấy thành công từ cơ sở dữ liệu
                        // Bạn có thể xử lý dữ liệu ở đây hoặc hiển thị nó trong MessageBox
                        string cv = dt.Rows[0]["Uname"].ToString();
                        // ...

                        if (cv.Equals("Nhân viên order"))
                        {
                            this.Hide();
                            frmPOS pOS = new frmPOS();
                            pOS.Show();
                        }
                        else
                        {
                            frmMain frm = new frmMain();
                            frm.Show();

                        }
                    }
                }

            }

        }

        private void lblQmk_Click(object sender, EventArgs e)
        {
           

        }
    }
}
