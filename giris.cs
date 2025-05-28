using MySql.Data.MySqlClient;
using Org.BouncyCastle.Pqc.Crypto.Frodo;
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
    public partial class giris : Form
    {

        void kodolustur()
        {
            Random rastgele = new Random();
            int sayi = rastgele.Next(10000,100000);
            textBox1.Text = sayi.ToString();
        }

        public giris()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kodolustur();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("boş bırakma","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                textBox1.Clear();
            }
            else
            {
                if (txtKullaniciAdi.Text == Properties.Settings.Default.kadi && txtSifre.Text == Properties.Settings.Default.sifre && textBox1.Text== textBox2.Text)
                {

                    MessageBox.Show("giriş başarılı","Başarılı Giriş",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Form2 frm = new Form2();
                    frm.kullanici = txtKullaniciAdi.Text;
                    frm.Show(); this.Hide();


                }
                else
                {
                    MessageBox.Show("hatalı Giriş","Hatalı Giriş",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }
             
        }

        private void lblMisafirGiris_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show(); this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 rgs = new Form1();
            rgs.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
