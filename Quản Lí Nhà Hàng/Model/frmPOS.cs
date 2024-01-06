using Guna.UI2.WinForms;
using Newtonsoft.Json.Linq;
using Quản_Lí_Nhà_Hàng.ThanhToanQuaMomo;
using Quản_Lí_Nhà_Hàng.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ZXing;
using ZXing.QrCode;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Quản_Lí_Nhà_Hàng.Model
{
    public partial class frmPOS : Form
    {
        public frmPOS()
        {
            InitializeComponent();
        }
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public int MainID = 0;
        public string OrderType;
        public int staffID =0;
        public int tID = 0;

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Load thẻ loại và sản phẩm
        private void frmPOS_Load(object sender, EventArgs e)
        {
            dgvQL.BorderStyle = BorderStyle.FixedSingle;
            AddCategory();

            productsPanel.Controls.Clear();
            LoadProduct();
        }

        //thêm nút danh mục vào bảng điều khiển
        private void AddCategory()
        {
            string qry = "Select * from Category";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            categoryPanel.Controls.Clear();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                    b.FillColor = Color.FromArgb(50, 55, 89);
                    b.Size = new Size(134, 45);
                    b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                    b.Text = row["catName"].ToString();

                    // sự kiện khi click vào danh mục
                    b.Click += new EventHandler(b_Click);
                    categoryPanel.Controls.Add(b);
                }
            }
        }
        //hiển thị sản phẩm bằng cách nhấp vào nút danh mục
        private void b_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button b = (Guna.UI2.WinForms.Guna2Button)sender;
            foreach (var item in productsPanel.Controls)
            {
                var product = (ucProduct)item;
                product.Visible = product.PCategory.ToLower().Contains(b.Text.Trim().ToLower());
            }
            GetTotal();
        }
       
        private void AddItems(string id, string name, string proID, string cat, string price, Image image)
        {

            try
            {
                int rowindex = 1;
                var w = new ucProduct()
                {
                    PName = name,
                    PPrice = price,
                    PCategory = cat,
                    PImage = image,
                    id = Convert.ToInt32(proID)
                };

                productsPanel.Controls.Add(w);
                w.onSelect += (ss, ee) =>
                {
                    var wdg = (ucProduct)ss;
                    foreach (DataGridViewRow item in dgvQL.Rows)
                    {
                        // kiểm tra xem sản phẩm đã có sẵn chưa, sau đó sẽ kiểm tra số lượng và cập nhật giá
                        if (Convert.ToInt32(item.Cells["dgvproID"].Value) == wdg.id)
                        {
                            item.Cells["dgvSL"].Value = int.Parse(item.Cells["dgvSL"].Value.ToString()) + 1;
                            item.Cells["dgvTong"].Value = int.Parse(item.Cells["dgvSL"].Value.ToString()) *
                                                            double.Parse(item.Cells["dgvGia"].Value.ToString());
                            return;
                        }
                        rowindex++;
                    }
                    dgvQL.Rows.Add(new object[] { rowindex, 0, wdg.PName, wdg.id, 1, wdg.PPrice, wdg.PPrice });
                    GetTotal();
                };
            }
            catch (Exception)
            {

                MessageBox.Show("Error");
            }
        }
        //Load product to panel
        public void LoadProduct()
        {
            string qry = "Select * from products inner join category on catID = CategoryID";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                Byte[] imagearray = (byte[])item["pImage"];
                byte[] imagebytearray = imagearray;

                AddItems("0", item["pName"].ToString(), item["pID"].ToString(), item["catName"].ToString(),
                    Convert.ToInt32(item["pPrice"]).ToString("N0"), Image.FromStream(new MemoryStream(imagearray)));

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in productsPanel.Controls)
            {
                var product = (ucProduct)item;
                product.Visible = product.PName.ToLower().Contains(txtSearch.Text.Trim().ToLower());
            }
        }

        
        private void GetTotal()
        {
            double total = 0;
            lblTotal.Text = "";
            foreach (DataGridViewRow row in dgvQL.Rows)
            {
                total += double.Parse(row.Cells["dgvTong"].Value.ToString());
            }

            lblTotal.Text = total.ToString("N0");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            lblBan.Text = "";
            lblPhucVu.Text = "";
            lblPhucVu.Visible = false;
            lblPhucVu.Visible = false;
             dgvQL.Rows.Clear();
            MainID = 0;
            lblTotal.Text = "00";
        }

       

        private void btnAnTaiBan_Click(object sender, EventArgs e)
        {
            OrderType = "ăn tại bàn";
            //tạo form chọn bàn và chọn bồi bàn
            chonBan frm = new chonBan();
            MainClass.BlurBackground(frm);

            if (frm.TableName != "")
            {
                lblBan.Text = frm.TableName;
                lblBan.Visible = true;
            }
            else
            {
                lblBan.Text = "";
                lblBan.Visible = false;

            }

            if (lblBan.Text != "")
            {
                chonPhucVu frm1 = new chonPhucVu();
                MainClass.BlurBackground(frm1);

                if (frm1.WaiterName != "")
                {
                    lblPhucVu.Text = frm1.WaiterName;
                    lblPhucVu.Visible = true;
                }
             
            }

        }

       

       //Lập phiếu gọi món
        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            hoaDon frm = new hoaDon();
            MainClass.BlurBackground(frm);

            if (frm.mainID >0)
            {
                id= frm.mainID;
                LoadEntries();
            }
        }
        public int id = 0;
        private void LoadEntries()
        {
            string qry = @"select * from tblMain m
                                inner join tblDetails d on m.MainID = d.MainID
                                inner join products p on p.pID = d.proID
                                where d.MainID = " + id + "";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows[0]["orderType"].ToString() == "Delivery")
            {
               
                btnAnTaiBan.Checked = false;
              
                lblBan.Visible = false;
                lblPhucVu.Visible = false;
            }
            if (dt.Rows[0]["orderType"].ToString() == "Take Away")
            {
                btnAnTaiBan.Checked = false;
               
                lblBan.Visible = false;
                lblPhucVu.Visible = false;
            }
            else
            {
                btnAnTaiBan.Checked = true;
                lblBan.Visible = true;
                lblPhucVu.Visible = true;
            }
            dgvQL.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                lblBan.Text = item["TableName"].ToString();
                lblPhucVu.Text = item["WaiterName"].ToString();
                string detailID = item["DetailID"].ToString();
                string proName = item["pName"].ToString();
                string proid = item["proID"].ToString();
                string qty = item["qty"].ToString();
                string price =Convert.ToInt32( item["price"]).ToString("N0");
                string amount = Convert.ToInt32( item["amount"]).ToString("N0");
                object[] obj = {0,detailID,proName,proid,qty,price,amount };
                dgvQL.Rows.Add(obj);
            }
            GetTotal();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

            thanhToan frm = new thanhToan();
            frm.MainID = MainID;
            frm.total = double.Parse(lblTotal.Text);
            MainClass.BlurBackground(frm);

            MainID = 0;
            dgvQL.Rows.Clear();
            lblBan.Text = "";
            lblPhucVu.Text = "";
            lblBan.Visible = false;
            lblPhucVu.Visible = false;
            lblTotal.Text = "0.00";
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLapphieu_Click(object sender, EventArgs e)
        {
            frmKitChenView frmKitChen = new frmKitChenView();
            frmKitChen.Show();
        }

        private void dgvQL_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //for serial no
            int count = 0;
            foreach (DataGridViewRow row in dgvQL.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }

        private void btnKOT_Click_1(object sender, EventArgs e)
        {
            if (lblBan.Text != "" && lblPhucVu.Text != "")
            {
                //Save data into database
                //Create tables
                string qry1 = "";//Main table
                string qry2 = "";//Detail table

                int detailID = 0;
                if (MainID == 0)
                {
                    qry1 = @"Insert into tblMain Values(@aDate, @aTime, @TableName, @WaiterName, @status, @orderType,
                            @total, @received, @change, @staffid, @tID); 
                            Select SCOPE_IDENTITY()";
                    //This line will get recent add id value
                }
                else//Update detail
                {
                    qry1 = @"Update tblMain Set status = @status, total = @total, received = @received, change = @change
                         where MainID = @ID";
                }


                SqlCommand cmd = new SqlCommand(qry1, MainClass.con);
                cmd.Parameters.AddWithValue("@MainID", MainID);
                cmd.Parameters.AddWithValue("@aDate", Convert.ToDateTime(DateTime.Now.Date));
                cmd.Parameters.AddWithValue("@aTime", DateTime.Now.ToShortTimeString());
                cmd.Parameters.AddWithValue("@TableName", lblBan.Text);
                cmd.Parameters.AddWithValue("@WaiterName", lblPhucVu.Text);
                cmd.Parameters.AddWithValue("@status", "Pending");
                cmd.Parameters.AddWithValue("orderType", OrderType);
                cmd.Parameters.AddWithValue("total", Convert.ToDouble(lblTotal.Text));// as we only saving data for kitchen value will update when payment received
                cmd.Parameters.AddWithValue("@received", Convert.ToDouble(0));
                cmd.Parameters.AddWithValue("@change", Convert.ToDouble(0));

                string staffIdQuery = "SELECT staffID FROM staff WHERE sName = @StaffName";

                SqlCommand staffIdCmd = new SqlCommand(staffIdQuery, MainClass.con);
                staffIdCmd.Parameters.AddWithValue("@StaffName", lblPhucVu.Text);

                int staffId = 0; // Biến để lưu trữ giá trị staffid

                MainClass.con.Open(); // Mở kết nối tới cơ sở dữ liệu

                using (SqlDataReader reader = staffIdCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        staffId = Convert.ToInt32(reader["staffID"]);
                    }
                }

                MainClass.con.Close(); // Đóng kết nối sau khi hoàn thành câu truy vấn

                cmd.Parameters.AddWithValue("@staffid", staffId);



                string tidQuery = "SELECT tid FROM tables WHERE tname = @TableName";

                SqlCommand tidCmd = new SqlCommand(tidQuery, MainClass.con);
                tidCmd.Parameters.AddWithValue("@TableName", lblBan.Text);

                int tid = 0; // Biến để lưu trữ giá trị tid

                MainClass.con.Open(); // Mở kết nối tới cơ sở dữ liệu

                using (SqlDataReader reader = tidCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tid = Convert.ToInt32(reader["tid"]);
                    }
                }

                MainClass.con.Close(); // Đóng kết nối sau khi hoàn thành câu truy vấn

                cmd.Parameters.AddWithValue("@tID", tid);



                try
                {
                    if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                    if (MainID == 0) { MainID = Convert.ToInt32(cmd.ExecuteScalar()); } else { cmd.ExecuteNonQuery(); }
                    if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

                    foreach (DataGridViewRow row in dgvQL.Rows)
                    {
                        detailID = Convert.ToInt32(row.Cells["dgvID"].Value);

                        if (detailID == 0)
                        {
                            qry2 = @" Insert into tblDetails Values( @MainID, @proID, @qty, @price, @amount)";
                        }
                        else
                        {
                            qry2 = @" Update tblDetails Set proID = @proID, Số lượng = @qty, Giá = @price, Tổng giá = @amount 
                            where DetailID = @ID";
                        }

                        SqlCommand cmd2 = new SqlCommand(qry2, MainClass.con);
                        cmd2.Parameters.AddWithValue("@DetailID", detailID);
                        cmd2.Parameters.AddWithValue("@MainID", MainID);
                        cmd2.Parameters.AddWithValue("@proID", Convert.ToInt32(row.Cells["dgvproID"].Value));
                        cmd2.Parameters.AddWithValue("@qty" ,Convert.ToInt32(row.Cells["dgvSL"].Value));
                        cmd2.Parameters.AddWithValue("@price", Convert.ToDouble(row.Cells["dgvGia"].Value));
                        cmd2.Parameters.AddWithValue("@amount", Convert.ToDouble(row.Cells["dgvTong"].Value));

                        if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                        cmd2.ExecuteNonQuery();
                        if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }
                    }
                    guna2MessageDialog1.Show("Lưu thành công");
                    //MainID = 0;
                    //detailID = 0;
                    //dgvQL.Rows.Clear();
                    //lblBan.Text = "";
                    //lblPhucVu.Text = "";
                    //lblBan.Visible = false;
                    //lblPhucVu.Visible = false;
                    //lblTotal.Text = "0.00";
                }
                catch (Exception)
                {
                    MessageBox.Show("Kiểm tra lại đơn hàng!!!");
                }
            }
            else
            {
                MessageBox.Show("Kiểm tra lại thông tin bàn và phục vụ!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

            private void btnXoa_Click(object sender, EventArgs e)
        {

            // Kiểm tra xem có dòng nào được chọn không
            if (dgvQL.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa các dòng đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Lặp qua các dòng đã chọn và xóa chúng khỏi nguồn dữ liệu
                    foreach (DataGridViewRow row in dgvQL.SelectedRows)
                    {
                        dgvQL.Rows.Remove(row);
                    }
                    MessageBox.Show("Đã xóa các dòng đã chọn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        //public void LaydulieuQR()
        //{
        //    string payment = Thanhtoanquamomo(paymentData);

        //}
       
        
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            

            // Lấy dữ liệu từ DataGridView
            DataGridView dataGridView = dgvQL; 
            DataTable dataTable = dataGridView.DataSource as DataTable;

            // Thiết lập các thông số in ấn
            float marginLeft = e.MarginBounds.Left;
            float marginTop = e.MarginBounds.Top;
            float printAreaWidth = e.MarginBounds.Width;
            float printAreaHeight = e.MarginBounds.Height;
            float lineHeight = dataGridView.Font.GetHeight();

            // Lấy danh sách chỉ số cột được chọn
            List<int> selectedColumns = new List<int>();
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.Visible)
                {
                    selectedColumns.Add(column.Index);
                }
            }
            // Vẽ tiêu đề "HÓA ĐƠN THANH TOÁN"
            string headerText = "HÓA ĐƠN THANH TOÁN";
            float headerTextWidth = e.Graphics.MeasureString(headerText, dataGridView.Font).Width;
            float headerTextHeight = e.Graphics.MeasureString(headerText, dataGridView.Font).Height;
            float headerTextLeft = marginLeft + (printAreaWidth - headerTextWidth) / 2;
            float headerTextTop = Top + 70; // Cộng thêm chiều cao của tiêu đề các cột
            e.Graphics.DrawString(headerText, dataGridView.Font, Brushes.Black, headerTextLeft, headerTextTop);

            // Vẽ tiêu đề các cột
            float left = marginLeft;
            float top = marginTop;
            foreach (int colIndex in selectedColumns)
            {
                string columnName = dataGridView.Columns[colIndex].HeaderText;
                e.Graphics.DrawString(columnName, dataGridView.Font, Brushes.Black, left, top);
                left += printAreaWidth / selectedColumns.Count;
            }

            


            // Vẽ dữ liệu từ DataGridView
             top =  headerTextHeight + 100 ; // Cộng thêm chiều cao của tiêu đề "HÓA ĐƠN THANH TOÁN"

            for (int row = 0; row < dataGridView.Rows.Count; row++)
            {
                left = marginLeft;

                foreach (int colIndex in selectedColumns)
                {
                    string cellValue = dataGridView.Rows[row].Cells[colIndex].FormattedValue.ToString();
                    e.Graphics.DrawString(cellValue, dataGridView.Font, Brushes.Black, left, top);
                    left += printAreaWidth / selectedColumns.Count;
                }

                top += lineHeight;
            

            // Vẽ label tổng số tiền và số bàn ngồi
            if (row == dataGridView.Rows.Count - 1) // Vẽ label chỉ ở dòng cuối cùng
                {
                    string totalAmount ="Tổng tiền: " + lblTotal.Text; 
                    e.Graphics.DrawString(totalAmount, dataGridView.Font, Brushes.Black, marginLeft, top);

                    string seatCount ="Số bàn: "+ lblBan.Text; 
                    e.Graphics.DrawString(seatCount, dataGridView.Font, Brushes.Black, marginLeft, top + lineHeight);


                    // Vẽ ngày giờ
                    string dateTime = "Ngày giờ: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    e.Graphics.DrawString(dateTime, dataGridView.Font, Brushes.Black, marginLeft, top + 2 * lineHeight);
                }

            }

            ////Thanh toan qua MOMO
            string endpoint = "https://test-payment.momo.vn/v2/gateway/api/create";
            string partnerCode = "MOMO5RGX20191128";
            string accessKey = "M8brj9K6E22vXoDB";
            string serectkey = "nqQiVSgDMy809JoPF6OzP5OdBUB550Y4";
            string orderInfo = lblBan.Text;
            string redirectUrl = "https://webhook.site/b3088a6a-2d17-4f8d-a383-71389a6c600b";
            string ipnUrl = "https://webhook.site/b3088a6a-2d17-4f8d-a383-71389a6c600b";
            string requestType = "captureWallet";
            long total;
            long.TryParse(lblTotal.Text.Replace(".", ""), out total);
            long amount = total;
           // MessageBox.Show(total.ToString());
            string orderId = Guid.NewGuid().ToString();
            string requestId = Guid.NewGuid().ToString();
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "accessKey=" + accessKey +
                "&amount=" + amount +
                "&extraData=" + extraData +
                "&ipnUrl=" + ipnUrl +
                "&orderId=" + orderId +
                "&orderInfo=" + orderInfo +
                "&partnerCode=" + partnerCode +
                "&redirectUrl=" + redirectUrl +
                "&requestId=" + requestId +
                "&requestType=" + requestType
                ;

            log.Debug("rawHash = " + rawHash);

            Baomat crypto = new Baomat();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);
            log.Debug("Signature = " + signature);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "partnerName", "Test" },
                { "storeId", "MomoTestStore" },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderId },
                { "orderInfo", orderInfo },
                { "redirectUrl", redirectUrl },
                { "ipnUrl", ipnUrl },
                { "lang", "en" },
                { "extraData", extraData },
                { "requestType", requestType },
                { "signature", signature }
            };
            log.Debug("Json request to MoMo: " + message.ToString());
            string responseFromMomo = TaoAPI.sendPaymentRequest(endpoint, message.ToString());
            JToken jmessage = JToken.Parse(responseFromMomo);
            log.Debug("Return from MoMo: " + jmessage.ToString());
            ////Trường hợp 1 lấy mã QR về winform

            string paymentData = jmessage.Value<string>("qrCodeUrl");



            // Tạo đối tượng BarcodeWriter
            BarcodeWriter barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    DisableECI = true,
                    CharacterSet = "UTF-8",
                    Width = 200,
                    Height = 200
                }
            };

            // Tạo hình ảnh mã QR từ dữ liệu thanh toán
            Bitmap qrCodeImage = barcodeWriter.Write(paymentData);

            // Vẽ mã QR lên trang in
            float qrCodeX = marginLeft + (printAreaWidth - qrCodeImage.Width) / 2;
            float qrCodeY = top + lineHeight;
            e.Graphics.DrawImage(qrCodeImage, qrCodeX, qrCodeY);

        }

 
        private void btninbill_Click(object sender, EventArgs e)
        {
            if (dgvQL.Rows.Count == 0)
            {
                MessageBox.Show("Bảng dữ liệu trống","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else
            {
                //In Bill
                // Edit Page 
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += PrintDocument_PrintPage;

                // Hiển thị Print Preview Dialog
                printBILL.Document = printDocument;
                printBILL.ShowDialog();
            }
        }

    }
}
