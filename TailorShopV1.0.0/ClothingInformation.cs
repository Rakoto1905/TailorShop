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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace TailorShopV1._0._0
{
    public partial class ClothingInformation : Form
    {
        public ClothingInformation()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=COMP-SERGEN;database=clothes;integrated security=true;");

        public object ConfigurationManager { get; private set; }

        public void List(string procedure)
        {
            SqlDataAdapter dr = new SqlDataAdapter(procedure, conn);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void ClothingInformation_Load(object sender, EventArgs e)
        {
            //
            this.customerTableAdapter.Fill(this.clothesDataSet1.customer);
            // 
            this.clothingspecTableAdapter.Fill(this.clothesDataSet.clothingspec);
            PanelProcessInfo.Visible = false;
        }
        private void TextColour_TextChanged(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            List("ListClothing");

        }

        private void BttnSaveClothing_Click(object sender, EventArgs e) //save clothing data and proceed cost time calculation
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("InsertClothing", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Clothes_Type", CmbCloType.Text);
            cmd.Parameters.AddWithValue("Clothes_Quantity", TextQuantity.Text);
            cmd.Parameters.AddWithValue("Clothes_Size", CmbSize.Text);
            cmd.Parameters.AddWithValue("Clothes_Colour", CmbColour.Text);
            cmd.Parameters.AddWithValue("Clothes_Description", TextDesc.Text);
            cmd.Parameters.AddWithValue("Clothes_IssueDate", DateIssue.Text);
            cmd.Parameters.AddWithValue("Customer_Name", CmbChCus.Text);

            cmd.ExecuteNonQuery();
            conn.Close();
            Receipt receipt = new Receipt();
            PanelProcessInfo.Show();
            PanelProcessInfo.Visible = true;



        }

        private void TextSearch_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SearchClothing", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Customer_Name", TextSearch.Text);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void PicExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PicHome_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            this.Close();
        }

        private void BtnEntCReg_Click(object sender, EventArgs e)
        {
            CustomerRegistration customer = new CustomerRegistration();
            customer.Show();
            this.Hide();
        }

        private void CmbChCus_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("SELECT * FROM customer where Customer_Name=@Customer_Name", conn); //list customer


            cmd.Parameters.AddWithValue("@Customer_Name", CmbChCus.Text);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string Customer_Type = dr["Customer_Type"].ToString(); //get customer type from customer db
                TextMemType.Text = Customer_Type;
            }
            conn.Close();
        }

        private void CmbCloType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM ServiceInformation where Clothes_Type=@Clothes_Type", conn);

            cmd.Parameters.AddWithValue("@Clothes_Type", CmbCloType.Text);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CmbService1.Items.Add(dr["Service_Name"]);
                CmbService2.Items.Add(dr["Service_Name"]);
                CmbService3.Items.Add(dr["Service_Name"]);

            }
            conn.Close();
        }

        private void CmbService1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ServiceInformation where Service_Name=@Service_Name1 and Clothes_Type=@Clothes_Type1", conn);

            cmd.Parameters.AddWithValue("@Service_Name1", CmbService1.Text);
            cmd.Parameters.AddWithValue("@Clothes_Type1", CmbCloType.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            comboBox1.DataSource = dt;
            if (TextMemType.Text == "Silver")
            {
                comboBox1.DisplayMember = "Service_CostSilver";
                comboBox1.ValueMember = "Service_TimeSilver";
                TextCost1.Text = comboBox1.Text;
                TextTime1.Text = comboBox1.SelectedValue.ToString();
            }
            if (TextMemType.Text == "Green")
            {
                comboBox1.DisplayMember = "Service_CostGreen";
                comboBox1.ValueMember = "Service_TimeGreen";
                TextCost1.Text = comboBox1.Text;
                TextTime1.Text = comboBox1.SelectedValue.ToString();
            }
            if (TextMemType.Text == "Gold")
            {
                comboBox1.DisplayMember = "Service_CostGold";
                comboBox1.ValueMember = "Service_TimeGold";
                TextCost1.Text = comboBox1.Text;
                TextTime1.Text = comboBox1.SelectedValue.ToString();
            }

            conn.Close();
        }

        private void CmbService2_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ServiceInformation where Service_Name=@Service_Name2 and Clothes_Type=@Clothes_Type2", conn);

            cmd.Parameters.AddWithValue("@Service_Name2", CmbService2.Text);
            cmd.Parameters.AddWithValue("@Clothes_Type2", CmbCloType.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            comboBox2.DataSource = dt;
            if (TextMemType.Text == "Silver")
            {
                comboBox2.DisplayMember = "Service_CostSilver";
                comboBox2.ValueMember = "Service_TimeSilver";
                TextCost2.Text = comboBox2.Text;
                TextTime2.Text = comboBox2.SelectedValue.ToString();
            }
            if (TextMemType.Text == "Green")
            {
                comboBox2.DisplayMember = "Service_CostGreen";
                comboBox2.ValueMember = "Service_TimeGreen";
                TextCost2.Text = comboBox2.Text;
                TextTime2.Text = comboBox2.SelectedValue.ToString();
            }
            if (TextMemType.Text == "Gold")
            {
                comboBox2.DisplayMember = "Service_CostGold";
                comboBox2.ValueMember = "Service_TimeGold";
                TextCost2.Text = comboBox2.Text;
                TextTime2.Text = comboBox2.SelectedValue.ToString();
            }
            conn.Close();
        }

        private void CmbService3_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ServiceInformation where Service_Name=@Service_Name3 and Clothes_Type=@Clothes_Type3", conn);

            cmd.Parameters.AddWithValue("@Service_Name3", CmbService3.Text);
            cmd.Parameters.AddWithValue("@Clothes_Type3", CmbCloType.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            comboBox3.DataSource = dt;
            if (TextMemType.Text == "Silver")
            {
                comboBox3.DisplayMember = "Service_CostSilver";
                comboBox3.ValueMember = "Service_TimeSilver";
                TextCost3.Text = comboBox3.Text;
                TextTime3.Text = comboBox3.SelectedValue.ToString();
            }
            if (TextMemType.Text == "Green")
            {
                comboBox3.DisplayMember = "Service_CostGreen";
                comboBox3.ValueMember = "Service_TimeGreen";
                TextCost3.Text = comboBox3.Text;
                TextTime3.Text = comboBox3.SelectedValue.ToString();
            }
            if (TextMemType.Text == "Gold")
            {
                comboBox3.DisplayMember = "Service_CostGold";
                comboBox3.ValueMember = "Service_TimeGold";
                TextCost3.Text = comboBox3.Text;
                TextTime3.Text = comboBox3.SelectedValue.ToString();
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextTotalTime.Text = (Convert.ToInt32(TextTime1.Text) + Convert.ToInt32(TextTime2.Text) + Convert.ToInt32(TextTime3.Text)).ToString(); //you can change the calculation. if you want it, you can determine the max time value with using " int maxValue = anArray.Max();
                                                                                                                                                   // int maxIndex = anArray.ToList().IndexOf(maxValue);
            TextTotalCost.Text = (Convert.ToDouble(TextCost1.Text) + Convert.ToDouble(TextCost2.Text) + Convert.ToDouble(TextCost3.Text)).ToString(); //except of taxes
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            Receipt receipt = new Receipt(); //create receipt page

            receipt.listBox1.Items.Add("***Thank you for choosing us - ^-^ ***");
            receipt.listBox1.Items.Add("**PICCIONE TAILOR SHOP**");
            receipt.listBox1.Items.Add("Customer Name : " + CmbChCus.Text);
            receipt.listBox1.Items.Add("Clothing Type : " + CmbCloType.Text);
            receipt.listBox1.Items.Add("Quantity : " + TextQuantity.Text);
            receipt.listBox1.Items.Add("Size : " + CmbSize.Text);
            receipt.listBox1.Items.Add("Colour : " + CmbColour.Text);
            receipt.listBox1.Items.Add("Description : " + TextDesc.Text);
            receipt.listBox1.Items.Add("Issue Date : " + DateIssue.Text);
            receipt.listBox1.Items.Add("Membership Type : " + TextMemType.Text);
            receipt.listBox1.Items.Add("**Cost Section**");
            receipt.listBox1.Items.Add("Name of Alteration-1  : " + CmbService1.Text);
            receipt.listBox1.Items.Add("Cost of Alteration-1  : " + TextCost1.Text);
            receipt.listBox1.Items.Add("Time of Alteration-1  : " + TextTime1.Text);
            if (CmbService2 != null)
            {
                receipt.listBox1.Items.Add("Name of Alteration-2  : " + CmbService2.Text);
                receipt.listBox1.Items.Add("Cost of Alteration-2  : " + TextCost2.Text);
                receipt.listBox1.Items.Add("Time of Alteration-2  : " + TextTime2.Text);
            }
            else
            {
                receipt.listBox1.Items.Add("Alteration-2 : None ");

            }
            if (CmbService3 != null)
            {
                receipt.listBox1.Items.Add("Name of Alteration-3  : " + CmbService3.Text);
                receipt.listBox1.Items.Add("Cost of Alteration-3  : " + TextCost3.Text);
                receipt.listBox1.Items.Add("Time of Alteration-3  : " + TextTime3.Text);
            }
            else
            {
                receipt.listBox1.Items.Add("Alteration-3 : None ");

            }
            receipt.listBox1.Items.Add("Total Cost  : " + TextTotalCost.Text);
            receipt.listBox1.Items.Add("Total Time  : " + TextTotalTime.Text);
            receipt.listBox1.Items.Add("Have a nice and healthy day");

            receipt.listBox1.Items.Add("When you come to take your clothes, please bring the receipt.");
            // receipt.Show();
            receipt.ShowDialog();
            //   this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}