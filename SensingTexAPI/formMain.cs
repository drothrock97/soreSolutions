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
        // Constants that will be found throughout this class
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

        // Most important section of code for this project.
        // This section of code is responsible for
        // Changing application LED colors, sensor unit colors, 
        // calculating localized max PSI, and calculating pressure sore onset time.
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

                // Assigns color to each sensor square based on output value
                for (int i = 0; i < ROWS; i++)
                    for (int j = 0; j < COLS; j++)
                    {
                        assignColor(i, j, (int)copyData[i, j]);
                        
                    }

                // BMI factor for modifying pressure sore onset time
                // The factor constants can and should be adjusted based on testing and further research
                int calcBMI = (703 * (int)num_weight.Value / ((int)num_height.Value * (int)num_height.Value));
                double bmiConstant = 0;
                if (calcBMI > 30 || calcBMI < 18)
                    bmiConstant = 0.7;
                else if (calcBMI > 26 && calcBMI < 30)
                    bmiConstant = 0.8;
                else
                    bmiConstant = 1;

                // Age factor for modifying pressure sore onset time
                // The factor constants can and should be adjusted based on testing and further research
                int ageInput = (int)num_age.Value;
                double ageConstant;
                if (ageInput > 65)
                    ageConstant = 0.9;
                else
                    ageConstant = 1;

                //This section of code is for finding localized max PSI
                double maxPSI = 0;
                int maxRow = 0;
                int maxCol = 0;
                double totalPSI = 0;
                double nSensors = 0;
                double avgPSI = 0;
                double calcOnsetTime = 0;
                double adjustedTime = 0;
                if (timePassed % 0.5 == 0) // For reassessing pressure every 30 seconds. Can be changed to some other number
                {
                    //Finding absolute max
                    for (int i = 0; i < ROWS; i++)
                        for (int j = 0; j < COLS; j++)
                        {
                            if (copyData[i, j] > maxPSI)
                            {
                                maxPSI = copyData[i, j];
                                maxRow = i;
                                maxCol = j;
                            }
                        }
                    //Finding average of local area near max
                    int bottomRow = maxRow++;
                    int topRow = maxRow--;
                    int leftCol = maxCol--;
                    int rightCol = maxCol++;

                    if (topRow >= 0 && bottomRow <= ROWS && leftCol >= 0 && rightCol <= COLS)
                        avgPSI = (maxPSI + copyData[topRow, maxCol] + copyData[bottomRow, maxCol] + copyData[maxRow, leftCol] + copyData[maxRow, rightCol]) / 5;
                    else if (topRow < 0 && bottomRow <= ROWS && leftCol >= 0 && rightCol <= COLS)
                        avgPSI = (maxPSI + copyData[bottomRow, maxCol] + copyData[maxRow, leftCol] + copyData[maxRow, rightCol]) / 4;
                    else if (topRow >= 0 && bottomRow > ROWS && leftCol >= 0 && rightCol <= COLS)
                        avgPSI = (maxPSI + copyData[topRow, maxCol] + copyData[maxRow, leftCol] + copyData[maxRow, rightCol]) / 4;
                    else if (topRow >= 0 && bottomRow <= ROWS && leftCol < 0 && rightCol <= COLS)
                        avgPSI = (maxPSI + copyData[topRow, maxCol] + copyData[bottomRow, maxCol] + copyData[maxRow, rightCol]) / 4;
                    else if (topRow >= 0 && bottomRow <= ROWS && leftCol >= 0 && rightCol > COLS)
                        avgPSI = (maxPSI + copyData[topRow, maxCol] + copyData[bottomRow, maxCol] + copyData[maxRow, leftCol]) / 4;
                    else if (topRow < 0 && bottomRow <= ROWS && leftCol < 0 && rightCol <= COLS)
                        avgPSI = (maxPSI + copyData[bottomRow, maxCol] + copyData[maxRow, rightCol]) / 3;
                    else if (topRow < 0 && bottomRow <= ROWS && leftCol >= 0 && rightCol > COLS)
                        avgPSI = (maxPSI + copyData[bottomRow, maxCol] + copyData[maxRow, leftCol]) / 3;
                    else if (topRow >= 0 && bottomRow > ROWS && leftCol < 0 && rightCol <= COLS)
                        avgPSI = (maxPSI + copyData[topRow, maxCol] + copyData[maxRow, rightCol]) / 3;
                    else if (topRow >= 0 && bottomRow > ROWS && leftCol >= 0 && rightCol > COLS)
                        avgPSI = (maxPSI + copyData[topRow, maxCol] + copyData[maxRow, leftCol]) / 3;

                    // This is another method of calculating average localized PSI
                    // For some reason, it is not accurate, but not sure why...
                    //for (int i = maxRow - 1; i < maxRow + 1; i++)
                    //    for (int j = maxCol - 1; j < maxCol + 1; j++)
                    //        if (copyData[i, j] > 0)
                    //        {
                    //            totalPSI += copyData[i, j];
                    //            nSensors++;
                    //        }
                    //avgPSI = totalPSI / nSensors;

                    // Converting digital value to PSI value using calculated
                    // Based on Calibration. Should be changed after future calibrations
                    double calcAvgPSI = 0.00573 * System.Math.Exp(0.00239 * avgPSI);
                    averagePSIText.Text = calcAvgPSI.ToString();

                    // Converts PSI to kPa for time calculation
                    // Needs to be done because time calculation is based on kPa measurement
                    double kpaAvg = 6.89476 * calcAvgPSI;

                    // Calculates onset time based on sigmoid function equation Linder-Ganz 2006
                    calcOnsetTime = (20 / 3) * System.Math.Log((32 * System.Math.Exp(27 / 2) - kpaAvg * System.Math.Exp(27 / 2)) / (kpaAvg - 9));



                    // Adjusted time remaining
                    // This can and should be modified based on testing and additional resources
                    adjustedTime = (calcOnsetTime * bmiConstant * ageConstant);

                    if (timeLeft + timePassed < adjustedTime)
                    {
                        timeLeft = (int)adjustedTime;
                        timeLabel.Text = timeLeft.ToString() + " minutes";
                    }
                }

                

                formMain.painting = false;
            }
            catch (Exception ex)
            {
                formMain.painting = false;
            }
        }

        delegate void assignColorCB(int row, int column, int value);

        private void averageMaxPSI(int row, int column, int value)
        {
            

            //creating data array
            int [,] rawData = new int[ROWS, COLS];
            for (int i = 0; i < ROWS; i++)
                for (int j = 0; j < COLS; j++)
                    rawData[i,j] = value;
            //Finding absolute max
            int maxPSI = 0;
            int maxRow = 0;
            int maxCol = 0;
            for (int i = 0; i < ROWS; i++)
                for (int j = 0; j < COLS; j++)
                {
                    if (rawData[i, j] > maxPSI)
                    {
                        maxPSI = rawData[i, j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            //Finding average of local area near max
            int bottomRow = maxRow++;
            int topRow = maxRow--;
            int leftCol = maxCol--;
            int rightCol = maxCol++;
            int totalPSI = 0;
            int nSensors;
            double avgPSI = 0;

            if (topRow >= 0 && bottomRow <= ROWS && leftCol >= 0 && rightCol <= COLS)
                avgPSI = (maxPSI + rawData[topRow, maxCol] + rawData[bottomRow, maxCol] + rawData[maxRow, leftCol] + rawData[maxRow, rightCol]) / 5;
            else if (topRow < 0 && bottomRow <= ROWS && leftCol >= 0 && rightCol <= COLS)
                avgPSI = (maxPSI + rawData[bottomRow, maxCol] + rawData[maxRow, leftCol] + rawData[maxRow, rightCol]) / 4;
            else if (topRow >= 0 && bottomRow > ROWS && leftCol >= 0 && rightCol <= COLS)
                avgPSI = (maxPSI + rawData[topRow, maxCol] + rawData[maxRow, leftCol] + rawData[maxRow, rightCol]) / 4;
            else if (topRow >= 0 && bottomRow <= ROWS && leftCol < 0 && rightCol <= COLS)
                avgPSI = (maxPSI + rawData[topRow, maxCol] + rawData[bottomRow, maxCol] + rawData[maxRow, rightCol]) / 4;
            else if (topRow >= 0 && bottomRow <= ROWS && leftCol >= 0 && rightCol > COLS)
                avgPSI = (maxPSI + rawData[topRow, maxCol] + rawData[bottomRow, maxCol] + rawData[maxRow, leftCol]) / 4;
            else if (topRow < 0 && bottomRow <= ROWS && leftCol < 0 && rightCol <= COLS)
                avgPSI = (maxPSI + rawData[bottomRow, maxCol] + rawData[maxRow, rightCol]) / 3;
            else if (topRow < 0 && bottomRow <= ROWS && leftCol >= 0 && rightCol > COLS)
                avgPSI = (maxPSI + rawData[bottomRow, maxCol] + rawData[maxRow, leftCol]) / 3;
            else if (topRow >= 0 && bottomRow > ROWS && leftCol < 0 && rightCol <= COLS)
                avgPSI = (maxPSI + rawData[topRow, maxCol] + rawData[maxRow, rightCol]) / 3;
            else if (topRow >= 0 && bottomRow > ROWS && leftCol >= 0 && rightCol > COLS)
                avgPSI = (maxPSI + rawData[topRow, maxCol] + rawData[maxRow, leftCol]) / 3;

            // Converting digital value to PSI value using calculated
            double calcAvgPSI = 0.00573 * System.Math.Exp(0.00239 * avgPSI);
            averagePSIText.Text = calcAvgPSI.ToString();


        }
        
        // This is where sensor color is determined as well as displayed value
        private void assignColorDirect(int row, int column, int value)
        {
            buttons[row, column].BackColor = colorFromValue(value,threshold, 4096);

            // Converting digital value to PSI value using calculated
            // Based on calibration and should be changed with future calibrations
            double psiValue = 0.00573*System.Math.Exp(0.00239*value);
            psiValue = (double)System.Math.Round(psiValue, 2);
            

            buttons[row, column].Text = psiValue.ToString();


            // code for displaying raw data values as needed for calibration
            //buttons[row, column].Text = value.ToString();
        }

        private void assignColor(int row, int column, int value)
        {
            assignColorCB ac = new assignColorCB(assignColorDirect);
            this.Invoke(ac, new object[] { row, column, value });
        }

        // For changing LED to indicate that mat is connected
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
 
        // For determining what values get assigned what color
        // Could turn into a gradient if desired
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

        // When device is connected, the timers begin and connection status light changes to green
        private void btn_connect_Click(object sender, EventArgs e)
        {
            try
            {
                sensor.Open(this.txt_port.Text);
                sensor.StartDevice();

                if (sensor.IsOpen())
                {
                    this.btn_ledConnected.BackColor = Color.Green;
                    timePassed = 0;
                    timer1.Start();
                    elapsedTime.Start();
                }
                    
                else
                {
                    this.btn_ledConnected.BackColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
            }
        }

        // When device is disconnected, the timers stop and connection status light changes to red
        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            try
            {
                sensor.StopDevice();
                if (sensor.Stop())
                {
                    timeLabel.Text = "Connect to Start";
                    timer1.Stop();
                    elapsedTime.Stop();
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

        // Threshold is based on digital output value
        // This allows it to be changed in the application without going into the code
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        // This section is for displaying time left until onset.
        // Currently, it is set up to warn that patient is at risk 30 minutes before the calculated time value
        // This can and should be changed based on testing and future research
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 30)
            {
                // Display the amount of time left
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " minutes";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = ("You are at risk of a pressure sore");
            }
        }

        private void elapsedTime_Tick(object sender, EventArgs e)
        {

                timePassed = timePassed + 1;

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
