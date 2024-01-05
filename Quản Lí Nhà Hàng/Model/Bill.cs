using System;
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
    public partial class Bill : Form
    {
        private DataTable _data;
        public Bill(DataTable data)
        {
            InitializeComponent();
            _data = data;
        }


        private void Bill_Load(object sender, EventArgs e)
        {

            // Gán dữ liệu vào DataGridView trên Form2
            dgvBill.DataSource = _data;
        }
    }

}
