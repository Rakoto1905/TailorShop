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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TailorShopV1._0._0
{
    public partial class CustomerRegistration : Form
    {
        public CustomerRegistration()
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

        private void BttnSaveClothing_Click(object sender, EventArgs e)
        {
            if (TextCusName.Text == "" || MaskedTextPhone.Text == "" || TextLocation.Text == "" || CmbCusType.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Boş Geçilemez");
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("InsertCustomer", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Customer_Name", TextCusName.Text);
                cmd.Parameters.AddWithValue("Customer_Phone", MaskedTextPhone.Text);
                cmd.Parameters.AddWithValue("Customer_Location", TextLocation.Text);
                cmd.Parameters.AddWithValue("Customer_Date", DateIssue.Text);
                cmd.Parameters.AddWithValue("Customer_Type", CmbCusType.Text);

                cmd.ExecuteNonQuery();



                conn.Close();
            }
            List("ListCustomer");

            if (CmbCusType.Text == "Gold")
            {
                // string squirrel = "C:\\Users\\SERGEN\\Desktop\\Squirrel.mp4";
                // axWindowsMediaPlayer1.URL = squirrel;
                axWindowsMediaPlayer1.Visible = true;
                axWindowsMediaPlayer1.stretchToFit = true;
                axWindowsMediaPlayer1.openPlayer("C:\\Users\\SERGEN\\source\\repos\\TailorShop\\TailorShopV1.0.0\\Resources\\Squirrel.mp4");  //easteregg-1 
                // if you want to put another video clip instead of this cutie dancing squirrel, you have to choose mp4 video and right click on the video, then click "properties" and copy the full path on "Location" then paste it. 
                axWindowsMediaPlayer1.currentPlaylist.clear(); //for one time play the video



            }

        }
        void axWindowsMediaPlayer1_PlayStateChange(object sender,
    AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 1) // Stopped
                axWindowsMediaPlayer1.Hide(); //for one time play the video
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            List("ListCustomer");
            axWindowsMediaPlayer1.Visible = false;

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

        private void CmbCusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbCusType.SelectedItem.ToString() == "Gold") //easter egg-2
            {
                GoldAdvantages gold = new GoldAdvantages();
                gold.Show();
            }
            if (CmbCusType.SelectedItem.ToString() == "Silver")
            {
                SilverAdvantages silver = new SilverAdvantages();
                silver.Show();
            }
            if (CmbCusType.SelectedItem.ToString() == "Green") //easter egg-3
            {
                GreenAdvantages green = new GreenAdvantages();
                green.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClothingInformation newjob = new ClothingInformation();
            newjob.Show();
            this.Hide();
        }

       

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rowdie = dataGridView1.CurrentRow; //get the data from datagridview to textboxes


            TextCusName.Tag = rowdie.Cells["Customer_ID"].Value.ToString();
            TextCusName.Text = rowdie.Cells["Customer_Name"].Value.ToString();
            MaskedTextPhone.Text = rowdie.Cells["Customer_Phone"].Value.ToString();
            TextLocation.Text = rowdie.Cells["Customer_Location"].Value.ToString();
            DateIssue.Text = rowdie.Cells["Customer_Date"].Value.ToString();
            CmbCusType.Text = rowdie.Cells["Customer_Type"].Value.ToString();
            this.Hide();
        }

        private void BtnEntPInf_Click(object sender, EventArgs e)
        {
            UpdateCustomer updatecus = new UpdateCustomer();
            updatecus.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClothingInformation newjob = new ClothingInformation();
            newjob.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustomerRegistration customer = new CustomerRegistration();
            customer.Show();
            this.Hide();
        }

        private void BtnEntPInf_Click_1(object sender, EventArgs e)
        {
            UpdateCustomer updatecus = new UpdateCustomer();
            updatecus.Show();
            this.Hide();
        }
    }
}
