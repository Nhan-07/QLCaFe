using Quản_Lí_Nhà_Hàng.Model;
using Quản_Lí_Nhà_Hàng.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_Lí_Nhà_Hàng
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        //for accessing  frm main
        static frmMain obj;
        public static frmMain Instance
        {
            get { if( obj == null) {obj = new frmMain(); } return obj;}
        }

        public  void addControls(Form f)
        {
            controlsPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            controlsPanel.Controls.Add(f);
            f.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUser.Text = MainClass.USER;
            obj = this;
        }

      

        private void btnCategory_Click(object sender, EventArgs e)
        {
            addControls(new frmCategoryView());

        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            addControls(new frmTableView());
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            addControls(new frmStaffView());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            addControls(new frmProductsView());
        }


      

        private void btnSetting_Click(object sender, EventArgs e)
        {
            addControls(new frmTaotkchoNV());
        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
            addControls(new frmThongke());


        }

        private void btnPos_Click(object sender, EventArgs e)
        {
            addControls(new frmPOS());
        }
    }
}
