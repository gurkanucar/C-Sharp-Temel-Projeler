using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kelimeOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int puan = 0;
        string secilen;
        private void Form1_Load(object sender, EventArgs e)
        {

            Karistir();


        }

        Random rnd = new Random();
        public void Karistir()
        {
            String[] kelimeler = {"elma","armut","televizyon","bilgisayar","kalem","peçete","zımba","makas","pano" };

            secilen = kelimeler[rnd.Next(0, kelimeler.Length)].ToUpper();

            List<String> harfler = new List<string>();

            foreach (var item in secilen)
            {
                harfler.Add(item.ToString());
            }


            for (int i = 0; i < secilen.Length; i++)
            {
                int a = rnd.Next(0, secilen.Length);
                int b = rnd.Next(0, secilen.Length);

                int tekrar = rnd.Next(3, 20);

                for (int j = 0; j < tekrar; j++)
                {
                    string gecici = harfler[a];
                    harfler[a] = harfler[b];
                    harfler[b] = gecici;
                    
                }

            }

            string sonHal = "";

            foreach (var item in harfler)
            {
                sonHal += item;
            }

            if(secilen==sonHal)
            {
                Karistir();
            }
            else
            {
                label1.Text = sonHal;
            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            puan -= 5;
            label3.Text = puan + "";
            Karistir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(secilen==textBox1.Text.ToUpper())
            {
                puan += 10;
              
            }
            else
            {
                puan-=7;
            }

              label3.Text = puan+"";
              Karistir();
              textBox1.Text = "";
        }
        int sayac = 10;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(sayac>0)
            {
                sayac--;
                label2.Text = sayac + "";
            }
            else
            {
                timer1.Enabled = false;
                MessageBox.Show("Puanınız:"+puan,"OYUN");

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sayac = 10;
            timer1.Enabled = true;
            puan = 0;
            label3.Text = puan + ""; ;
            label2.Text = sayac + "";
            textBox1.Text = "";
            Karistir();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (secilen == textBox1.Text.ToUpper())
            {
                puan += 10;
                label3.Text = puan + "";
                Karistir();
                textBox1.Text = "";

            }
         
           
        }


    }
}
