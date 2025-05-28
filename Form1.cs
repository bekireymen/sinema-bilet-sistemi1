using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sinema_bilet_sistemi1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kadi.Text == "" || sifre.Text == "")
            {
                MessageBox.Show("lütfen boş bırakma");
            }
            else
            {

                Properties.Settings.Default.kadi = kadi.Text;
                Properties.Settings.Default.sifre = sifre.Text;

                Properties.Settings.Default.Save();
                MessageBox.Show("başarılı bir şekilde kayıt oldun" + kadi.Text);
                this.Close();

            }
        }
    }
}
