using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace feria
{
    public partial class Form1 : Form
    {
        public bool finish = false;
        public int capCarr = 9, capBarco = 5, capRueda = 8;
        public int caActCarr = 0, caActBar = 0, caActRue = 0;
        Random r = new Random();
        Thread bar;
        Thread carr;
        Thread rued;
        Thread fila;

        public Form1()
        {
            InitializeComponent();
            bar = new Thread(barco);
            carr = new Thread(carrusel);
            rued = new Thread(rueda);
            fila = new Thread(filaThread);

        }

        public void barco()
        {
            int  actual = 0;

            while(finish != true)
            {
                if(actual == capBarco)
                {
                    for(int i = 0; i < 1000000; i++) { }
                    actual = 0;
                }
            }
        }

        public void carrusel()
        {
            int  actual = 0;

            while (finish != true)
            {
                if (actual == capCarr)
                {
                    for (int i = 0; i < 1000000; i++) { }
                    actual = 0;
                }
            }
        }

        public void rueda()
        {
            int actual = 0;

            while (finish != true)
            {
                if (actual == capRueda)
                {
                    for (int i = 0; i < 1000000; i++) { }
                    actual = 0;
                }
            }
        }

        public void filaThread()
        {
            while(finish != true)
            {
                int persona = r.Next(1, 3);
                switch (persona)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fila.Start();
            bar.Start();
            carr.Start();
            rued.Start();
            button1.Enabled= false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            finish = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        
    }
}
