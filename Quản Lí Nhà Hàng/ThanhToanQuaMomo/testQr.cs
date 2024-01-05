using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_Lí_Nhà_Hàng.ThanhToanQuaMomo
{
    public partial class testQr : Form
    {
        public Bitmap QRCodeImage { get; set; }
       // public string soTien { get; set; }
        public testQr()
        {
            InitializeComponent();
        }

        private void testQr_Load(object sender, EventArgs e)
        {

           ptbQr.Image = QRCodeImage;
        }
    }
}
