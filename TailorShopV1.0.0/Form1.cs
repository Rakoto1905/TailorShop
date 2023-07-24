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

namespace TailorShopV1._0._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=COMP-SERGEN;database=clothes;integrated security=true;");
        public void List(string procedure)
        {
            SqlDataAdapter dr = new SqlDataAdapter(procedure, conn);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        class round : TextBox
        {
            [System.Runtime.InteropServices.DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
            private static extern IntPtr CreateRoundRectRgn
            (
                int nLeftRect, // X-coordinate of upper-left corner or padding at start
                int nTopRect,// Y-coordinate of upper-left corner or padding at the top of the textbox
                int nRightRect, // X-coordinate of lower-right corner or Width of the object
                int nBottomRect,// Y-coordinate of lower-right corner or Height of the object
                                //RADIUS, how round do you want it to be?
                int nheightRect, //height of ellipse 
                int nweightRect //width of ellipse
            );
            protected override void OnResize(EventArgs e)
            {
                base.OnResize(e);
                this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(2, 3, this.Width, this.Height, 50, 50)); //play with these values till you are happy
            }
        }
            private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List("ListCustomer"); //create proc
                                  //select * from customer
        }

       

        private void TextSearch_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SearchCustomer", conn); 
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Customer_Name", TextSearch.Text); // for searching customer on list
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClothingInformation newjob = new ClothingInformation(); //Clothing page button
            newjob.Show(); 
            this.Hide();
        }

        private void BtnEntCReg_Click(object sender, EventArgs e) 
        {
            CustomerRegistration customer = new CustomerRegistration(); ////Customer Registration page button
            customer.Show();
            this.Hide();
        }

        private void PicExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // exit button
        }

        private void PicHome_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1(); // form1=home page
            home.Show();
            this.Close();
        }

        private void BtnEntPInf_Click(object sender, EventArgs e)
        {
            UpdateCustomer updatecus = new UpdateCustomer(); //update&delete customer information page button
            updatecus.Show(); 
            this.Hide();
        }
    }
}
