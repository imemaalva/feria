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
        public bool finish, stop = false;
        public int capCarr = 9, capBarco = 5, capRueda = 8;
        public int caActCarr = 0, caActBar = 0, caActRue = 0;

        Random r = new Random();
        int r2 = 0;

        int s2 = 1000;
        Thread bar;
        Thread carr;
        Thread rued;
        Thread fila;
        Thread agregaFila;
        Queue <int> personas;

        public Form1()
        {
            InitializeComponent();
            personas = new Queue<int>();
            contBar.Text = "0";
            contCar.Text = "0";
            contRue.Text = "0";
            contFil.Text = "0";
            label13.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Start.Enabled = false;
            End.Enabled = true;
            finish = false;

            bar = new Thread(barco);
            carr = new Thread(carrusel);
            rued = new Thread(rueda);
            fila = new Thread(filaThread);
            agregaFila = new Thread(addFila);

            agregaFila.Start();
            fila.Start();
            bar.Start();
            carr.Start();
            rued.Start();
        }

        public void barco()
        {
            int aux = 0;

            while (finish != true)
            {
                if (caActBar != aux)
                {
                    aux = caActBar;
                    if (caActBar == capBarco)
                    {
                        SetStatus(contBar, 0, 1, 1);
                        for (int i = 0; i < 1000000000; i++) { }
                        caActBar = 0;
                        aux = 0;
                        SetStatus(contBar, 0, 3, 1);
                    }
                    else
                    {
                        SetStatus(contBar, 0, 2, 1);
                    }
                }
            }
        }

        public void carrusel()
        {
            int  aux= 0;

            while (finish != true)
            {
                if (caActCarr != aux)
                {
                    aux = caActCarr;
                    if(caActCarr == capCarr)
                    {
                        SetStatus(contCar, 0, 1, 2);
                        for (int i=0; i < 1000000000; i++) { }
                        caActCarr = 0;
                        aux = 0;
                        SetStatus(contCar, 0, 3, 2);
                    }
                    else
                    {
                        SetStatus(contCar, 0, 2, 2);
                    }
                }
            }
        }

        public void rueda()
        {
            int aux = 0;

            while (finish != true)
            {
                if (caActRue != aux)
                {
                    aux = caActRue;
                    if (caActRue == capRueda)
                    {
                        SetStatus(contRue, 0, 1, 3);
                        for (int i = 0; i < 1000000000; i++) { }
                         caActRue = 0;
                         aux = 0;
                        SetStatus(contRue, 0, 3, 3);
                    }
                    else
                    {
                        SetStatus(contRue, 0, 2, 3);
                    }
                }
            }
        }

        public void filaThread()
        {
            while(finish != true)
            {
                SetStatus(label13, 0, 1, 1);
                int i = 0;
                while (i < s2 + 200000000 && finish != true)
                {
                    i++;
                }
                int persona = personas.Dequeue();
                switch (persona)
                {
                    case 1:
                        if(caActBar < capBarco)
                        {
                            SetStatus(label13, 1, 1, persona);
                            i = 0;
                            while (i < 1000 && finish != true)
                            {
                                i++;
                            }
                            caActBar++;
                        }
                        else
                        {
                            SetStatus(label13, 1, 2, persona);
                            while (caActBar == capBarco && finish != true)
                            {
                                stop = true;
                            }
                            stop = false;
                            SetStatus(label13, 1, 1, persona);
                            i = 0;
                            while (i < 1000 && finish != true)
                            {
                                i++;
                            }
                            caActBar++;
                        }
                        break;
                    case 2:
                        if (caActCarr < capCarr)
                        {
                            SetStatus(label13, 1, 1, persona);
                            i = 0;
                            while (i < 1000 && finish != true)
                            {
                                i++;
                            }
                            caActCarr++;
                        }
                        else
                        {
                            SetStatus(label13, 1, 2, persona);
                            while (caActCarr == capCarr && finish != true)
                            {
                                stop = true;
                            }
                            stop = false;
                            SetStatus(label13, 1, 1, persona);
                            i = 0;
                            while (i < 1000 && finish != true)
                            {
                                i++;
                            }
                            caActCarr++;
                        }
                        break;
                    case 3:
                        if (caActRue < capRueda)
                        {
                            SetStatus(label13, 1, 1, persona);
                            i = 0;
                            while (i < 1000 && finish != true)
                            {
                                i++;
                            }
                            caActRue++;
                        }
                        else
                        {
                            SetStatus(label13, 1, 2, persona);
                            while (caActRue == capRueda && finish != true)
                            {
                                stop = true;
                            }
                            stop = false;
                            SetStatus(label13, 1, 1, persona);
                            i = 0;
                            while (i < 1000 && finish != true)
                            {
                                i++;
                            }
                            caActRue++;
                        }
                        break;
                    default:
                        break;
                }
                SetStatus(contFil, 1, personas.Count, 0);
            }
        }

        public void addFila()
        {
            while(finish != true)
            {
                while(stop != true && finish != true)
                {
                    r2 = r.Next(1,4);
                    personas.Enqueue(r2);
                    SetStatus(contFil, 1, personas.Count, 0);
                    int i = 1;
                    while(i < s2 + 130000000 && finish != true)
                    {
                        i++;
                    }
                }
            }
        }

        private delegate void SetStatusD(System.Windows.Forms.Label label, int id, int status, int id2);
        private void SetStatus(System.Windows.Forms.Label label, int id, int status, int id2)
        {
            if (contCar.InvokeRequired)
            {
                SetStatusD delegado = new SetStatusD(SetStatus);
                contCar.Invoke(delegado, new object[] { label, id, status, id2 });
            }
            else
            {
                switch (id)
                {
                    case 0:
                        switch (status)
                        {
                            case 1:
                                label.Text = "Lleno";
                                break;
                            case 2:
                                switch (id2)
                                {
                                    case 1:
                                     
                                        label.Text = caActBar.ToString();
                                        break;
                                    case 2:
                                        label.Text = caActCarr.ToString();  
                                        break;
                                    case 3:
                                        label.Text = caActRue.ToString();
                                        break;
                                }
                                break;
                            case 3:
                                switch (id2)
                                {
                                    case 1:
                                        label.Text = "0";
                                        break;
                                    case 2:
                                        label.Text = "0";
                                        break;
                                    case 3:
                                        label.Text = "0";
                                        break;
                                }
                                break;
                        }
                        break;
                    //Fila
                    case 1:
                        switch (status)
                        {
                            //Cooldown
                            case 0:
                                label.Text = "Siguiente persona";
                                break;
                            //Yendo
                            case 1:
                                switch (id2)
                                {
                                    case 1:
                                        label.Text = "Hacia el barco pirata";
                                        break;
                                    case 2:
                                        label.Text = "Hacia el carrusel";
                                        break;
                                    case 3:
                                        label.Text = "Hacia la rueda de la fortuna";
                                        break;
                                }

                                break;
                            default:
                                label.Text = "Personas en fila: " + status.ToString();
                                break;

                        }
                        break;
                    //Hilo
                    case 2:
                        if (status == 5) { label.Text = id2.ToString(); } 
                        else
                        {
                            label.Text = "Terminado";
                        }

                        break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            finish = true;
            Start.Enabled = true;
            End.Enabled = false;
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
