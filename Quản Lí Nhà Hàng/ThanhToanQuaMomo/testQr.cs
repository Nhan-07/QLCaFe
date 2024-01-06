using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
namespace Quản_Lí_Nhà_Hàng.ThanhToanQuaMomo
{
    public partial class testQr : Form
    {
        private ChromiumWebBrowser browser;
        public testQr()
        {
            InitializeComponent();
            // Khởi tạo ChromiumWebBrowser
            browser = new ChromiumWebBrowser();
            browser.Dock = DockStyle.Fill;

            // Thêm ChromiumWebBrowser vào Form2
            Controls.Add(browser);
        }
        public void LoadWebsite(string url)
        {
            browser.Load(url);
        }
    }
}
