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


namespace sinema_bilet_sistemi1
{
    public partial class Form12 : Form
    {
        Dictionary<string, List<string>> seansSaatleri = new Dictionary<string, List<string>>();
        Dictionary<string, List<string>> salonTipleri = new Dictionary<string, List<string>>();
        Dictionary<string, List<string>> sinemaSalonlari = new Dictionary<string, List<string>>();
        Dictionary<string, List<string>> film = new Dictionary<string, List<string>>();
        private bool tiklandiMi = false;
        private Color varsayilanRenk;
       
        public Form12()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show(); this.Hide();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
           
            seansSaatleri.Add("Normal", new List<string> { "08:00", "10:00", "12:00", "14:00", "16:00", "18:00", "20:00", "22:00", "23:00" });
            seansSaatleri.Add("IMAX", new List<string> { "12:45", "14:00", "18:45", "20:00", "22:00" });
            seansSaatleri.Add("Gold Class", new List<string> { "14:00", "18:30", "22:00", });
            seansSaatleri.Add("ScreenX", new List<string> { "14:00", "16:00", "18:00", "20:00" });


            // İstanbul
            salonTipleri.Add("Cevahir Cinecity", new List<string> { "IMAX", "Gold Class", "ScreenX" });
            salonTipleri.Add("Akmerkez Paribu Cineverse", new List<string> { "Gold Class", "Normal" });
            salonTipleri.Add("Mall of İstanbul MOİ Sinemaları", new List<string> { "IMAX", "ScreenX", "Starium" });
            salonTipleri.Add("Emaar Square Cinemaximum", new List<string> { "Gold Class", "Normal" });
            salonTipleri.Add("Kanyon Cineplex", new List<string> { "IMAX", "Gold Class", "ScreenX", "Normal" });
            salonTipleri.Add("Kadıköy Rexx", new List<string> { "IMAX", "Gold Class", "ScreenX", "Normal" });
            salonTipleri.Add("City’s Nişantaşı CineCity", new List<string> { "IMAX", "Gold Class", "ScreenX", "Normal" });
            salonTipleri.Add("Akasya Avşar", new List<string> { "IMAX", "Gold Class", "ScreenX", "Normal" });
            salonTipleri.Add("Torium Cinecity", new List<string> { "ScreenX", "Normal" });
            salonTipleri.Add("Vialand Sineması", new List<string> { "IMAX", "Gold Class", "ScreenX", "Normal" });

            // Ankara
            salonTipleri.Add("Cepa Cinemaximum", new List<string> { "IMAX", "Normal" });
            salonTipleri.Add("Armada Paribu Cineverse", new List<string> { "Gold Class", "ScreenX" });
            salonTipleri.Add("Panora Avşar", new List<string> { "Starium", "Normal" });
            salonTipleri.Add("Gordion Cinecity", new List<string> { "IMAX", "Gold Class", "ScreenX", "Normal" });
            salonTipleri.Add("Antares Cinemaximum", new List<string> { "IMAX", "Normal" });
            salonTipleri.Add("Atlantis Cineplex", new List<string> { "Gold Class", "Normal" });
            salonTipleri.Add("Kızılay Büyülü Fener", new List<string> { "IMAX", "Gold Class", "ScreenX", "Normal" });
            salonTipleri.Add("Ankamall Cinemaximum", new List<string> { "IMAX", "Starium" });
            salonTipleri.Add("Kentpark Cinemaximum", new List<string> { "Gold Class", "Normal" });
            salonTipleri.Add("Next Level Cinecity", new List<string> { "IMAX", "Gold Class", "ScreenX", "Normal" });

            // İzmir
            salonTipleri.Add("MaviBahçe Cinemaximum", new List<string> { "ScreenX", "Normal" });
            salonTipleri.Add("Agora Cinemaximum", new List<string> { "Gold Class", "IMAX" });
            salonTipleri.Add("Forum Bornova Cinecity", new List<string> { "Starium", "Normal" });
            salonTipleri.Add("Ege Park Balçova", new List<string> { "Normal" });
            salonTipleri.Add("Konak Pier Cinemaximum", new List<string> { "Gold Class" });
            salonTipleri.Add("Kipa Cinebonus", new List<string> { "Normal" });
            salonTipleri.Add("İzmir Optimum Cinemaximum", new List<string> { "IMAX", "Gold Class" });
            salonTipleri.Add("Karşıyaka Hilltown Avşar", new List<string> { "Starium", "Normal" });
            salonTipleri.Add("İzmir Park Cinecity", new List<string> { "IMAX", "Gold Class", "ScreenX", "Normal" });
            salonTipleri.Add("Cinemarine Alsancak", new List<string> { "Normal" });

            // Bursa
            salonTipleri.Add("Korupark Cinemaximum", new List<string> { "Starium", "IMAX" });
            salonTipleri.Add("Kent Meydanı Cinecity", new List<string> { "Gold Class", "Normal" });
            salonTipleri.Add("Anatolium Cinemaximum", new List<string> { "ScreenX", "Normal" });
            salonTipleri.Add("Özdilek Cinemaximum", new List<string> { "IMAX", "Gold Class", "ScreenX", "Normal" });
            salonTipleri.Add("Zafer Plaza Cinecity", new List<string> { "Normal" });
            salonTipleri.Add("Carrefour Cinemaximum", new List<string> { "Gold Class" });
            salonTipleri.Add("Nilpark Avşar", new List<string> { "IMAX", "Gold Class", "ScreenX", "Normal" });
            salonTipleri.Add("FSM Cinecity", new List<string> { "Normal" });
            salonTipleri.Add("As Merkez Cinebonus", new List<string> { "Normal" });
            salonTipleri.Add("Sur Yapı Marka AVM Cinemaximum", new List<string> { "IMAX", "Gold Class" });

            // Adana
            salonTipleri.Add("Paribu Cineverse M1 Adana AVM", new List<string> { "IMAX", "Normal" });
            salonTipleri.Add("Adana Optimum Avşar", new List<string> { "Gold Class", "Starium" });
            salonTipleri.Add("Adana Metropol", new List<string> { "Normal" });
            salonTipleri.Add("Cinemaximum Sinanpaşa", new List<string> { "Gold Class" });
            salonTipleri.Add("Real AVM Cinemaximum", new List<string> { "Normal" });
            salonTipleri.Add("Cinecity Prime Mall", new List<string> { "ScreenX", "Normal" });
            salonTipleri.Add("Park Zirve Sineması", new List<string> { "Normal" });
            salonTipleri.Add("Toros AVM Avşar", new List<string> { "Gold Class" });
            salonTipleri.Add("Kozan Sineması", new List<string> { "Normal" });
            salonTipleri.Add("Seyhan Luna Sineması", new List<string> { "Normal" });

            // Antalya
            salonTipleri.Add("MarkAntalya Cinemaximum", new List<string> { "Gold Class", "ScreenX", "Normal" });
            salonTipleri.Add("Terracity Avşar", new List<string> { "Gold Class", "Normal" });
            salonTipleri.Add("Migros 5M Cinemaximum", new List<string> { "IMAX", "Starium" });
            salonTipleri.Add("Deepo Outlet Avşar", new List<string> { "ScreenX", "Normal" });
            salonTipleri.Add("Agora AVM Cinemaximum", new List<string> { "Gold Class", "Normal" });
            salonTipleri.Add("Özdilekpark Avşar", new List<string> { "IMAX", "Gold Class", "ScreenX", "Normal" });
            salonTipleri.Add("Mall of Antalya Cinemaximum", new List<string> { "IMAX", "Gold Class" });
            salonTipleri.Add("Erasta AVM Cinemaximum", new List<string> { "Normal" });
            salonTipleri.Add("Konyaaltı Cinecity", new List<string> { "Starium", "Normal" });
            salonTipleri.Add("Lara Sinemaları", new List<string> { "Normal" });

            // Konya
            salonTipleri.Add("Kent Plaza Cinemaximum", new List<string> { "Gold Class", "Normal" });
            salonTipleri.Add("Kulesite Paribu Cineverse", new List<string> { "IMAX", "Normal" });
            salonTipleri.Add("Real AVM Cinecity", new List<string> { "IMAX", "Gold Class", "ScreenX", "Normal" });
            salonTipleri.Add("Novada AVM Cinemaximum", new List<string> { "ScreenX", "Normal" });
            salonTipleri.Add("M1 Konya Avşar", new List<string> { "Gold Class", "Normal" });
            salonTipleri.Add("Zafer AVM Sineması", new List<string> { "Normal" });
            salonTipleri.Add("Cinemaximum Selçuklu", new List<string> { "Normal" });
            salonTipleri.Add("Saray Sineması", new List<string> { "IMAX", "Gold Class", "ScreenX", "Normal" });
            salonTipleri.Add("Konya Cinebox", new List<string> { "Normal" });
            salonTipleri.Add("Parkcinema", new List<string> { "Normal" });

            // Gaziantep
            salonTipleri.Add("Sanko Park Cinemaximum", new List<string> { "IMAX", "Normal" });
            salonTipleri.Add("Forum Gaziantep Avşar", new List<string> { "Gold Class", "Normal" });
            salonTipleri.Add("Primemall Gaziantep Cinecity", new List<string> { "IMAX", "Gold Class", "ScreenX", "Normal" });
            salonTipleri.Add("Gazimuhtar Cinecity", new List<string> { "IMAX", "Gold Class", "ScreenX", "Normal" });
            salonTipleri.Add("M1 AVM Cinemaximum", new List<string> { "IMAX", "Gold Class", "ScreenX", "Normal" });
            salonTipleri.Add("Alleben Sineması", new List<string> { "Normal" });
            salonTipleri.Add("Zirve Park Avşar", new List<string> { "Gold Class" });
            salonTipleri.Add("Gaziantep Parkcinema", new List<string> { "Normal" });
            salonTipleri.Add("Şehitkamil Cinebonus", new List<string> { "Normal" });
            salonTipleri.Add("Cinecity Nizip", new List<string> { "Gold Class", "Normal" });

            // Eskişehir
            salonTipleri.Add("Espark Cinemaximum", new List<string> { "IMAX", "Gold Class" });
            salonTipleri.Add("Vega AVM Cinecity", new List<string> { "IMAX", "Gold Class", "ScreenX", "Normal" });
            salonTipleri.Add("Kanatlı AVM Cinemaximum", new List<string> { "ScreenX", "Normal" });
            salonTipleri.Add("Neo AVM Avşar", new List<string> { "IMAX", "Gold Class", "ScreenX", "Normal" });
            salonTipleri.Add("Eskişehir Özdilek Avşar", new List<string> { "IMAX", "Gold Class", "ScreenX" });
            salonTipleri.Add("Eskişehir Luna Sineması", new List<string> { "IMAX", "Gold Class", "ScreenX" });
            salonTipleri.Add("Cinemarine Eskişehir", new List<string> { "Normal" });
            salonTipleri.Add("Kent Sineması", new List<string> { "IMAX", "Starium", "Screenx" });
            salonTipleri.Add("Tepebaşı Cinebox", new List<string> { "IMAX", "Gold Class", "ScreenX", "Normal" });
            salonTipleri.Add("Mavi Bahçe Cinecity", new List<string> { "Normal" });

            // Kayseri
            salonTipleri.Add("Forum Kayseri Avşar", new List<string> { "Gold Class", "Normal" });
            salonTipleri.Add("Kayseri Park Cinemaximum", new List<string> { "IMAX", "ScreenX" });
            salonTipleri.Add("İpeksaray AVM Cinecity", new List<string> { "Normal" });
            salonTipleri.Add("Kumsmall AVM Avşar", new List<string> { "Starium", "Normal" });
            salonTipleri.Add("Mix Sinemaları", new List<string> { "Normal" });
            salonTipleri.Add("Meysu Outlet Cinebonus", new List<string> { "IMAX", "Gold Class", "ScreenX", "Normal" });
            salonTipleri.Add("Erciyes Sineması", new List<string> { "Normal" });
            salonTipleri.Add("CinemaTime Kayseri", new List<string> { "IMAX", "Gold Class", "ScreenX", "Normal" });
            salonTipleri.Add("Kocasinan Luna Sineması", new List<string> { "Normal" });
            salonTipleri.Add("Cinemarine Talas", new List<string> { "IMAX", "Starium", "Normal" });



            sinemaSalonlari.Add("İstanbul", new List<string>
             {
        "Cevahir Cinecity",
        "Akmerkez Paribu Cineverse",
        "Mall of İstanbul MOİ Sinemaları",
        "Emaar Square Cinemaximum",
        "Kanyon Cineplex",
        "Kadıköy Rexx",
        "City’s Nişantaşı CineCity",
        "Akasya Avşar",
        "Torium Cinecity",
        "Vialand Sineması"
             });

            sinemaSalonlari.Add("Ankara", new List<string>
             {
        "Cepa Cinemaximum",
        "Armada Paribu Cineverse",
        "Panora Avşar",
        "Gordion Cinecity",
        "Antares Cinemaximum",
        "Atlantis Cineplex",
        "Kızılay Büyülü Fener",
        "Ankamall Cinemaximum",
        "Kentpark Cinemaximum",
        "Next Level Cinecity"
            });

            sinemaSalonlari.Add("İzmir", new List<string>
            {
        "MaviBahçe Cinemaximum",
        "Agora Cinemaximum",
        "Forum Bornova Cinecity",
        "Ege Park Balçova",
        "Konak Pier Cinemaximum",
         "Kipa Cinebonus",
        "İzmir Optimum Cinemaximum",
        "Karşıyaka Hilltown Avşar",
        "İzmir Park Cinecity",
        "Cinemarine Alsancak"
            });

            sinemaSalonlari.Add("Bursa", new List<string>
            {
        "Korupark Cinemaximum",
        "Kent Meydanı Cinecity",
        "Anatolium Cinemaximum",
        "Özdilek Cinemaximum",
        "Zafer Plaza Cinecity",
        "Carrefour Cinemaximum",
        "Nilpark Avşar",
        "FSM Cinecity",
        "As Merkez Cinebonus",
        "Sur Yapı Marka AVM Cinemaximum"
            });

            sinemaSalonlari.Add("Adana", new List<string>
            {
    "Paribu Cineverse M1 Adana AVM",
    "Adana Optimum Avşar",
    "Adana Metropol",
    "Cinemaximum Sinanpaşa",
    "Real AVM Cinemaximum",
    "Cinecity Prime Mall",
    "Park Zirve Sineması",
    "Toros AVM Avşar",
    "Kozan Sineması",
    "Seyhan Luna Sineması"
            });

            sinemaSalonlari.Add("Antalya", new List<string>
{
    "MarkAntalya Cinemaximum",
    "Terracity Avşar",
    "Migros 5M Cinemaximum",
    "Deepo Outlet Avşar",
    "Agora AVM Cinemaximum",
    "Özdilekpark Avşar",
    "Mall of Antalya Cinemaximum",
    "Erasta AVM Cinemaximum",
    "Konyaaltı Cinecity",
    "Lara Sinemaları"
});

            sinemaSalonlari.Add("Konya", new List<string>
{
    "Kent Plaza Cinemaximum",
    "Kulesite Paribu Cineverse",
    "Real AVM Cinecity",
    "Novada AVM Cinemaximum",
    "M1 Konya Avşar",
    "Zafer AVM Sineması",
    "Cinemaximum Selçuklu",
    "Saray Sineması",
    "Konya Cinebox",
    "Parkcinema"
});

            sinemaSalonlari.Add("Gaziantep", new List<string>
{
    "Sanko Park Cinemaximum",
    "Forum Gaziantep Avşar",
    "Primemall Gaziantep Cinecity",
    "Gazimuhtar Cinecity",
    "M1 AVM Cinemaximum",
    "Alleben Sineması",
    "Zirve Park Avşar",
    "Gaziantep Parkcinema",
    "Şehitkamil Cinebonus",
    "Cinecity Nizip"
});

            sinemaSalonlari.Add("Eskişehir", new List<string>
{
    "Espark Cinemaximum",
    "Vega AVM Cinecity",
    "Kanatlı AVM Cinemaximum",
    "Neo AVM Avşar",
    "Eskişehir Özdilek Avşar",
    "Eskişehir Luna Sineması",
    "Cinemarine Eskişehir",
    "Kent Sineması",
    "Tepebaşı Cinebox",
    "Mavi Bahçe Cinecity"
});

            sinemaSalonlari.Add("Kayseri", new List<string>
{
    "Forum Kayseri Avşar",
    "Kayseri Park Cinemaximum",
    "İpeksaray AVM Cinecity",
    "Kumsmall AVM Avşar",
    "Mix Sinemaları",
    "Meysu Outlet Cinebonus",
    "Erciyes Sineması",
    "CinemaTime Kayseri",
    "Kocasinan Luna Sineması",
    "Cinemarine Talas"
});
            comboBox1.Items.AddRange(sinemaSalonlari.Keys.ToArray());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button2.BackColor;
                button2.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button2.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button3.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button3.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button4.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button4.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button5.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button5.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button6.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button6.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button7.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button7.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button13.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button13.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button12.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button12.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button11.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button11.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button10.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button10.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button9.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button9.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button8.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button8.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button19.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button19.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button18.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button18.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button17.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button17.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button16.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button16.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button15.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button15.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button14.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button14.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button25.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button25.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button24.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button24.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button23.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button23.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button22.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button22.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button21.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button21.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button20.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button20.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button31.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button31.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button30.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button30.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button29.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button29.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button28.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button28.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button27.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button27.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button26.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button26.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button37.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button37.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button36.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button36.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button35.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button35.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button34.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button34.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button33.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button33.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (!tiklandiMi)

            {

                varsayilanRenk = button1.BackColor;
                button32.BackColor = Color.Green;

                tiklandiMi = true;

            }

            else

            {

                button32.BackColor = varsayilanRenk;

                tiklandiMi = false;

            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            string sehir = comboBox1.SelectedItem?.ToString() ?? "";
            string salonAdi = comboBox2.SelectedItem?.ToString() ?? "";
            string salonOzelligi = comboBox3.SelectedItem?.ToString() ?? "";
            string saat = comboBox4.SelectedItem?.ToString() ?? "";
            string film = comboBox5.SelectedItem?.ToString() ?? "";

            Form15 form15 = new Form15(sehir, salonAdi, salonOzelligi, saat ,film);
            form15.Show();

            MessageBox.Show("Seçilen Koltuklar Satın Alındı","Satın Alındı",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();

            string secilenSalon = comboBox2.SelectedItem.ToString();

            if (salonTipleri.ContainsKey(secilenSalon))
            {
                comboBox3.Items.AddRange(salonTipleri[secilenSalon].ToArray());
            }
            else
            {
                comboBox3.Items.Add("Normal");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            string secilenSehir = comboBox1.SelectedItem.ToString();

            if (sinemaSalonlari.ContainsKey(secilenSehir))
            {
                comboBox2.Items.AddRange(sinemaSalonlari[secilenSehir].ToArray());
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();

            string seans = comboBox3.SelectedItem.ToString();

            if (seansSaatleri.ContainsKey(seans))
            {
                comboBox4.Items.AddRange(seansSaatleri[seans].ToArray());
            }
            else
            {
                comboBox4.Items.Add("");
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            string film = comboBox5.SelectedItem.ToString();

            if (seansSaatleri.ContainsKey(film))
            {
                comboBox5.Items.AddRange(seansSaatleri[film].ToArray());
            }
            else
            {
                comboBox5.Items.Add("");
            }
        }
    }
}
