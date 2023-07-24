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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace TailorShopV1._0._0
{
    public partial class UpdateCustomer : Form
    {
        public UpdateCustomer()
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rowd = dataGridView1.CurrentRow;
            TextCusName.Tag = rowd.Cells["Customer_ID"].Value.ToString();
            TextCusName.Text = rowd.Cells["Customer_Name"].Value.ToString();
            MaskedTextPhone.Text = rowd.Cells["Customer_Phone"].Value.ToString();
            TextLocation.Text = rowd.Cells["Customer_Location"].Value.ToString();
            DateIssue.Text = rowd.Cells["Customer_Date"].Value.ToString();
            CmbCusType.Text = rowd.Cells["Customer_Type"].Value.ToString();


        }

        private void UpdateCustomer_Load(object sender, EventArgs e)
        {
            List("ListCustomer");
        }
        private void ClearData()
        {
            TextCusName.Text = "";
            MaskedTextPhone.Text = "";
            TextLocation.Text = "";
            DateIssue.Text = "";
            CmbCusType.Text = "";
        }
        private void DisplayData()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from clothes", conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void BttnSaveClothing_Click(object sender, EventArgs e) //update customer
        {
            SqlCommand cmd = new SqlCommand("update customer set Customer_Name=@Customer_Name , Customer_Phone=@Customer_Phone, Customer_Location=@Customer_Location,Customer_Date=@Customer_Date,Customer_Type=@Customer_Type WHERE Customer_ID = @Customer_ID", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@Customer_ID", TextCusName.Tag);
            cmd.Parameters.AddWithValue("@Customer_Name", TextCusName.Text);
            cmd.Parameters.AddWithValue("@Customer_Phone", MaskedTextPhone.Text);
            cmd.Parameters.AddWithValue("@Customer_Location", TextLocation.Text);
            cmd.Parameters.AddWithValue("@Customer_Date", DateIssue.Text);
            cmd.Parameters.AddWithValue("@Customer_Type", CmbCusType.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully");
            conn.Close();
            List("ListCustomer");
            ClearData();

        }

        private void button1_Click(object sender, EventArgs e) //delete customer account
        {
            SqlCommand cmd = new SqlCommand("delete customer where Customer_ID=@Customer_ID", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@Customer_ID", TextCusName.Tag);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Record Deleted Successfully!");
            List("ListCustomer");

            ClearData();
        }

        private void BtnEntCReg_Click(object sender, EventArgs e)
        {
            CustomerRegistration customer = new CustomerRegistration();
            customer.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClothingInformation newjob = new ClothingInformation();
            newjob.Show();
            this.Hide();
        }

        private void BtnEntPInf_Click(object sender, EventArgs e)
        {
            UpdateCustomer updatecus = new UpdateCustomer();
            updatecus.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
