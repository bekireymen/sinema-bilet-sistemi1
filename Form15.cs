using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace sinema_bilet_sistemi1
{
    public partial class Form15 : Form
    {
        public Form15(string sehir, string salonAdi, string salonOzelligi, string saat,string film)
        {
            InitializeComponent();

            // Bu değerleri TextBox'lara atıyoruz
            textBox1.Text = sehir;
            textBox2.Text = salonAdi;
            textBox3.Text = salonOzelligi;
            textBox4.Text = saat;
            textBox5.Text = film;
        }

        public Form15()
        {
            InitializeComponent();

        }

        private void button19_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show(); this.Hide();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            
            

        }
    }
}