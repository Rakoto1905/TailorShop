using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TailorShopV1._0._0
{
    public partial class GreenAdvantages : Form
    {
        public GreenAdvantages()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer s = new System.Media.SoundPlayer();
            s.SoundLocation = "C:\\Users\\SERGEN\\Desktop\\Tailor Shop\\sef.wav";
            s.Load();
            s.Play();
            this.Close();
            
        }
    }
}
