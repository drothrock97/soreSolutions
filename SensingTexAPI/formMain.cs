using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SensingTexAPI
{
    public partial class formMain : Form
    {
        public MattressDevice sensor;
        public const int ROWS = 16;
        public const int COLS = 16;
        public const int BUTTONSIZE = 40;

        public static Button[,] botones =new Button[ROWS,COLS];
        public static int threshold = 0;
        public static int age = 0;
        public static int height = 0;
        public static int weight = 0;
        public static bool pintando = false;

        public formMain()
        {
            InitializeComponent();

            sensor = new MattressDevice(16, 16, 0.1);
            sensor.DataReadyEvent += OnDataSensor;

            num_threshold.Value = 200;
            num_age.Value = 0;
            num_height.Value = 0;
            num_weight.Value = 0;

            for (int i = 0; i<ROWS; i++)
                for (int j = 0; j<COLS; j++)
                {
                    botones[i, j] = new Button();
                    botones[i, j].Size = new Size(BUTTONSIZE, BUTTONSIZE);
                    botones[i, j].Location = new Point(i * BUTTONSIZE, j * BUTTONSIZE);
                    botones[i, j].Text = "";
                    botones[i, j].FlatAppearance.BorderSize = 0;
                    botones[i, j].FlatStyle = FlatStyle.Flat;
                    botones[i, j].BackColor = Color.Black;//colorFromValor(i * 256, 0, 4096);
                    botones[i, j].Visible = true;
                    this.panel1.Controls.Add(botones[i, j]);
                }
        }

        public void OnDataSensor(object sender, DataReadyEventArgs e)
        {
            if (formMain.pintando == false)
            {
                Thread th = new Thread(pintarCuadro);
                th.Start(e.Data);
            }
        }

        void pintarCuadro(object datos)
        {
            formMain.pintando = true;
            try
            {
                cambiarLED();
                double[,] datosArray = (double[,])datos;
                double[,] copiaDatos = new double[ROWS, COLS];
                for (int i = 0; i < ROWS; i++)
                    for (int j = 0; j < COLS; j++)
                        copiaDatos[i, j] = datosArray[i, j];

                for (int i = 0; i < ROWS; i++)
                    for (int j = 0; j < COLS; j++)
                        asignarColor(i, j, (int)copiaDatos[i, j]);

                formMain.pintando = false;
            }
            catch (Exception ex)
            {
                formMain.pintando = false;
            }
        }

        delegate void asignarColorCB(int fila, int columna, int valor);
        private void asignarColorDirecto(int fila, int columna, int valor)
        {
            botones[fila, columna].Text = valor.ToString();
            botones[fila, columna].BackColor = colorFromValor(valor,threshold, 4096);
        }

        private void asignarColor(int fila, int columna, int valor)
        {
            asignarColorCB ac = new asignarColorCB(asignarColorDirecto);
            this.Invoke(ac, new object[] { fila, columna, valor });
        }

        delegate void cambiarLEDCB();
        private void cambiarLEDDirecto()
        {
            if (this.btn_LEDrx.BackColor== Color.Green)
                this.btn_LEDrx.BackColor = Color.Yellow;
            else
                this.btn_LEDrx.BackColor = Color.Green;
        }
        private void cambiarLED()
        {
            cambiarLEDCB ac = new cambiarLEDCB(cambiarLEDDirecto);
            this.Invoke(ac, new object[] {});
        }

        private Color colorFromValor(int dato, int threshold, int valorMaximo)
        {
            Color retorno;
            int red=0;
            int blue = 0;
            int green = 0;
            int valor = (int)((float)dato * (float)((float)1024 / (float)valorMaximo)); //normalizo a 1024 valores de color

            if (dato <= threshold)
            {
                red = 0; blue = 0; green = 0;
            }
            else if (dato > threshold && valor < 255)
            {
                red = 0; blue = 255; green = valor;
            }
            else if (valor > 255 && valor < 510)
            {
                red = 0; blue = 255 + 255 - valor; green = 255;
            }
            else if (valor > 510 && valor < 765)
            {
                red = valor - 510; blue = 0; green = 255;
            }
            else if (valor > 765)
            {
                red = 255; blue = 0; green = 1020 - valor;
            }
            else
            {
                red = 255; blue = 0; green = 0;
            }

            retorno = new Color();
            retorno = Color.FromArgb(red, green, blue);

            return retorno;
        }

        private void btn_conectar_Click(object sender, EventArgs e)
        {
            try
            {
                sensor.Open(this.txt_port.Text);
                sensor.StartDevice();

                if (sensor.IsOpen())
                    this.btn_ledConectado.BackColor = Color.Green;
                else
                    this.btn_ledConectado.BackColor = Color.Red;
            }
            catch (Exception ex)
            {
            }
        }

        private void btn_desconectar_Click(object sender, EventArgs e)
        {
            try
            {
                sensor.StopDevice();
                if (sensor.Stop())
                {
                }

                if (sensor.IsStart())
                    this.btn_ledConectado.BackColor = Color.Green;
                else
                    this.btn_ledConectado.BackColor = Color.Red;

            }
            catch (Exception ex)
            {
            }
        }

        private void num_threshold_ValueChanged(object sender, EventArgs e)
        {
            threshold = (int)num_threshold.Value;
        }

        private void num_age_ValueChanged(object sender, EventArgs e)
        {
            age = (int)num_age.Value;
        }

        private void num_weight_ValueChanged(object sender, EventArgs e)
        {
            weight = (int)num_weight.Value;
        }

        private void num_height_ValueChanged(object sender, EventArgs e)
        {
            height = (int)num_height.Value;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void formMain_Load(object sender, EventArgs e)
        {

        }
    }
}
