using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_Lí_Nhà_Hàng.Model
{
    public partial class hoaDon : Form
    {
        public hoaDon()
        {
            InitializeComponent();
        }
        public int mainID =0;

        private void hoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string qry = @"select MainID,TableName,WaiterName,status,orderType,total from tblMain where status <> 'Pending'";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvId);
            lb.Items.Add(dgvtable);
            lb.Items.Add(dgvWaiter);
            lb.Items.Add(dgvStatus);
            lb.Items.Add(dgvType);
            lb.Items.Add(dgvTotal);
            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }

        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //for serial no
            int count = 0;
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                string status = guna2DataGridView1.CurrentRow.Cells["dgvStatus"].Value.ToString();

                if (status == "Đã trả")
                {
                    MessageBox.Show("Đơn hàng đã được thanh toán");
                    return;
                }

                mainID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvId"].Value);
                this.Close();
            }
        }

      

        
    }
}
