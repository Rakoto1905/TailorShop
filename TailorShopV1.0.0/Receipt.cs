using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Imaging;


namespace TailorShopV1._0._0
{
    public partial class Receipt : Form
    {
        public Receipt()
        {
            InitializeComponent();
        }
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintImage);
            pd.Print();
        }
        //void PrintImage(object o, PrintPageEventArgs e)
        //{
        //    int x = SystemInformation.WorkingArea.X;
        //    int y = SystemInformation.WorkingArea.Y;
        //    int width = this.Width;
        //    int height = this.Height;

        //    Rectangle bounds = new Rectangle(x, y, width, height);

        //    Bitmap img = new Bitmap(width, height);

        //    this.DrawToBitmap(img, bounds);
        //    Point p = new Point(100, 100);
        //    e.Graphics.DrawImage(img, p);

        //    this.DrawToBitmap(img, this.ClientRectangle);
        //    img.Save("myPrintScreen.bmp");
        //}

        private void PrintImage(object sender, PrintPageEventArgs e)
        {
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            Bitmap bmp = new Bitmap(listBox1.ClientSize.Width, listBox1.ClientSize.Height);

            float tgtWidthMM = 120;  // 5cm
            float tgtHeightMM = 85;  // 3.5cm
            float tgtWidthInches = tgtWidthMM / 18.4f;
            float tgtHeightInches = tgtHeightMM / 18.4f;
            float srcWidthPx = bmp.Width; //  633
            float srcHeightPx = bmp.Height; //  381
            float dpiX = srcWidthPx / tgtWidthInches;
            float dpiY = srcHeightPx / tgtHeightInches;

            bmp.SetResolution(dpiX, dpiY);

            listBox1.DrawToBitmap(bmp, listBox1.ClientRectangle);
            e.Graphics.DrawImage((Image)bmp, x, y);
        }

        private void PicHome_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            this.Close();
        }

        private void PicExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnEntPInf_Click(object sender, EventArgs e)
        {
            UpdateCustomer updatecus = new UpdateCustomer();
            updatecus.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClothingInformation newjob = new ClothingInformation();
            newjob.Show();
            this.Hide();
        }

        private void BtnEntCReg_Click(object sender, EventArgs e)
        {
            CustomerRegistration customer = new CustomerRegistration();
            customer.Show();
            this.Hide();
        }
    }
}
