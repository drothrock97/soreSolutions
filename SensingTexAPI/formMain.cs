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

        public static Button[,] buttons =new Button[ROWS,COLS];
        public static int threshold = 0;
        public static int age = 0;
        public static int height = 0;
        public static int weight = 0;
        public static int bmi;
        public static bool painting = false;

        public formMain()
        {
            InitializeComponent();

            sensor = new MattressDevice(16, 16, 0.1);
            sensor.DataReadyEvent += OnDataSensor;

            num_threshold.Value = 200;
            num_age.Value = 0;
            num_height.Value = 70;
            num_weight.Value = 180;

            bmi_calculated.Text = (703 * (int)num_weight.Value / ((int)num_height.Value * (int)num_height.Value)).ToString();


            for (int i = 0; i<ROWS; i++)
                for (int j = 0; j<COLS; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(BUTTONSIZE, BUTTONSIZE);
                    buttons[i, j].Location = new Point(i * BUTTONSIZE, j * BUTTONSIZE);
                    buttons[i, j].Text = "";
                    buttons[i, j].FlatAppearance.BorderSize = 0;
                    buttons[i, j].FlatStyle = FlatStyle.Flat;
                    buttons[i, j].BackColor = Color.Black;//colorFromValue(i * 256, 0, 4096);
                    buttons[i, j].Visible = true;
                    this.panel1.Controls.Add(buttons[i, j]);
                }
        }

        public void OnDataSensor(object sender, DataReadyEventArgs e)
        {
            if (formMain.painting == false)
            {
                Thread th = new Thread(paintPicture);
                th.Start(e.Data);
            }
        }

        void paintPicture(object data)
        {
            formMain.painting = true;
            try
            {
                changeLED();
                double[,] dataArray = (double[,])data;
                double[,] copyData = new double[ROWS, COLS];
                for (int i = 0; i < ROWS; i++)
                    for (int j = 0; j < COLS; j++)
                        copyData[i, j] = dataArray[i, j];

                for (int i = 0; i < ROWS; i++)
                    for (int j = 0; j < COLS; j++)
                        assignColor(i, j, (int)copyData[i, j]);

                formMain.painting = false;
            }
            catch (Exception ex)
            {
                formMain.painting = false;
            }
        }

        delegate void assignColorCB(int row, int column, int value);
        private void assignColorDirect(int row, int column, int value)
        {
            buttons[row, column].BackColor = colorFromValue(value,threshold, 4096);

            // Converting digital value to PSI value
            double psiValue = 0.00573*System.Math.Exp(0.00239*value);
            psiValue = (double)System.Math.Round(psiValue, 2);
            buttons[row, column].Text = psiValue.ToString();

            //buttons[row, column].Text = value.ToString();
        }

        private void assignColor(int row, int column, int value)
        {
            assignColorCB ac = new assignColorCB(assignColorDirect);
            this.Invoke(ac, new object[] { row, column, value });
        }

        delegate void changeLEDCB();
        private void changeLEDDirect()
        {
            if (this.btn_LEDrx.BackColor== Color.Green)
                this.btn_LEDrx.BackColor = Color.Yellow;
            else
                this.btn_LEDrx.BackColor = Color.Green;
        }
        private void changeLED()
        {
            changeLEDCB ac = new changeLEDCB(changeLEDDirect);
            this.Invoke(ac, new object[] {});
        }

        private Color colorFromValue(int data, int threshold, int maxValue)
        {
            Color returnColor;
            int red=0;
            int blue = 0;
            int green = 0;
            int value = (int)((float)data * (float)((float)1024 / (float)maxValue)); //normalizes to 1024 values of color

            if (data <= threshold)
            {
                red = 0; blue = 0; green = 0;
            }
            else if (data > threshold && value < 255)
            {
                red = 0; blue = 255; green = value;
            }
            else if (value > 255 && value < 510)
            {
                red = 0; blue = 255 + 255 - value; green = 255;
            }
            else if (value > 510 && value < 765)
            {
                red = value - 510; blue = 0; green = 255;
            }
            else if (value > 765)
            {
                red = 255; blue = 0; green = 1020 - value;
            }
            else
            {
                red = 255; blue = 0; green = 0;
            }

            returnColor = new Color();
            returnColor = Color.FromArgb(red, green, blue);

            return returnColor;
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            try
            {
                sensor.Open(this.txt_port.Text);
                sensor.StartDevice();

                if (sensor.IsOpen())
                    this.btn_ledConnected.BackColor = Color.Green;
                else
                    this.btn_ledConnected.BackColor = Color.Red;
            }
            catch (Exception ex)
            {
            }
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            try
            {
                sensor.StopDevice();
                if (sensor.Stop())
                {
                }

                if (sensor.IsStart())
                    this.btn_ledConnected.BackColor = Color.Green;
                else
                    this.btn_ledConnected.BackColor = Color.Red;

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
            try
            {
                bmi_calculated.Text = (703 * (int)num_weight.Value / ((int)num_height.Value * (int)num_height.Value)).ToString();

            }
            catch
            {

            }
        }

        private void num_height_ValueChanged(object sender, EventArgs e)
        {
            height = (int)num_height.Value;
            weight = (int)num_weight.Value;
            try
            {
                bmi_calculated.Text = (703 * (int)num_weight.Value / ((int)num_height.Value * (int)num_height.Value)).ToString();

            }
            catch
            {

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void formMain_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
