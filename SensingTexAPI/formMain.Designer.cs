namespace SensingTexAPI
{
    partial class formMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_port = new System.Windows.Forms.Label();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.btn_LEDrx = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ledConnected = new System.Windows.Forms.Button();
            this.num_threshold = new System.Windows.Forms.NumericUpDown();
            this.num_age = new System.Windows.Forms.NumericUpDown();
            this.num_height = new System.Windows.Forms.NumericUpDown();
            this.num_weight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bmi_calculated = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.averagePSIText = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.num_threshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_age)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_weight)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(22, 22);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1173, 1182);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lbl_port
            // 
            this.lbl_port.AutoSize = true;
            this.lbl_port.Location = new System.Drawing.Point(1206, 30);
            this.lbl_port.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_port.Name = "lbl_port";
            this.lbl_port.Size = new System.Drawing.Size(134, 25);
            this.lbl_port.TabIndex = 2;
            this.lbl_port.Text = "Port (COMxx)";
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(1206, 59);
            this.txt_port.Margin = new System.Windows.Forms.Padding(6);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(162, 29);
            this.txt_port.TabIndex = 3;
            this.txt_port.Text = "COMXX";
            // 
            // btn_connect
            // 
            this.btn_connect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_connect.Location = new System.Drawing.Point(1206, 107);
            this.btn_connect.Margin = new System.Windows.Forms.Padding(6);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(165, 42);
            this.btn_connect.TabIndex = 4;
            this.btn_connect.Text = "CONNECT";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Location = new System.Drawing.Point(1206, 155);
            this.btn_disconnect.Margin = new System.Windows.Forms.Padding(6);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(165, 42);
            this.btn_disconnect.TabIndex = 5;
            this.btn_disconnect.Text = "DISCONNECT";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // btn_LEDrx
            // 
            this.btn_LEDrx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LEDrx.Location = new System.Drawing.Point(1208, 325);
            this.btn_LEDrx.Margin = new System.Windows.Forms.Padding(6);
            this.btn_LEDrx.Name = "btn_LEDrx";
            this.btn_LEDrx.Size = new System.Drawing.Size(42, 42);
            this.btn_LEDrx.TabIndex = 6;
            this.btn_LEDrx.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1206, 295);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "RX";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1206, 203);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "CONNECTED";
            // 
            // btn_ledConnected
            // 
            this.btn_ledConnected.BackColor = System.Drawing.Color.Red;
            this.btn_ledConnected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ledConnected.Location = new System.Drawing.Point(1208, 233);
            this.btn_ledConnected.Margin = new System.Windows.Forms.Padding(6);
            this.btn_ledConnected.Name = "btn_ledConnected";
            this.btn_ledConnected.Size = new System.Drawing.Size(42, 42);
            this.btn_ledConnected.TabIndex = 8;
            this.btn_ledConnected.UseVisualStyleBackColor = false;
            // 
            // num_threshold
            // 
            this.num_threshold.Location = new System.Drawing.Point(1208, 434);
            this.num_threshold.Margin = new System.Windows.Forms.Padding(6);
            this.num_threshold.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.num_threshold.Name = "num_threshold";
            this.num_threshold.Size = new System.Drawing.Size(165, 29);
            this.num_threshold.TabIndex = 10;
            this.num_threshold.ValueChanged += new System.EventHandler(this.num_threshold_ValueChanged);
            // 
            // num_age
            // 
            this.num_age.Location = new System.Drawing.Point(1208, 558);
            this.num_age.Margin = new System.Windows.Forms.Padding(6);
            this.num_age.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.num_age.Name = "num_age";
            this.num_age.Size = new System.Drawing.Size(165, 29);
            this.num_age.TabIndex = 10;
            this.num_age.ValueChanged += new System.EventHandler(this.num_age_ValueChanged);
            // 
            // num_height
            // 
            this.num_height.Location = new System.Drawing.Point(1208, 625);
            this.num_height.Margin = new System.Windows.Forms.Padding(6);
            this.num_height.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.num_height.Name = "num_height";
            this.num_height.Size = new System.Drawing.Size(165, 29);
            this.num_height.TabIndex = 10;
            this.num_height.ValueChanged += new System.EventHandler(this.num_height_ValueChanged);
            // 
            // num_weight
            // 
            this.num_weight.Location = new System.Drawing.Point(1208, 692);
            this.num_weight.Margin = new System.Windows.Forms.Padding(6);
            this.num_weight.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.num_weight.Name = "num_weight";
            this.num_weight.Size = new System.Drawing.Size(165, 29);
            this.num_weight.TabIndex = 10;
            this.num_weight.ValueChanged += new System.EventHandler(this.num_weight_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1206, 407);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Threshold";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1206, 529);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Age";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1206, 596);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Height";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1206, 663);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Weight";
            // 
            // bmi_calculated
            // 
            this.bmi_calculated.Location = new System.Drawing.Point(1206, 761);
            this.bmi_calculated.Margin = new System.Windows.Forms.Padding(6);
            this.bmi_calculated.Name = "bmi_calculated";
            this.bmi_calculated.ReadOnly = true;
            this.bmi_calculated.Size = new System.Drawing.Size(162, 29);
            this.bmi_calculated.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1207, 730);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "BMI";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1208, 816);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 25);
            this.label8.TabIndex = 15;
            this.label8.Text = "Average PSI";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // averagePSIText
            // 
            this.averagePSIText.Location = new System.Drawing.Point(1207, 847);
            this.averagePSIText.Margin = new System.Windows.Forms.Padding(6);
            this.averagePSIText.Name = "averagePSIText";
            this.averagePSIText.ReadOnly = true;
            this.averagePSIText.Size = new System.Drawing.Size(162, 29);
            this.averagePSIText.TabIndex = 14;
            this.averagePSIText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1207, 918);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(153, 25);
            this.label9.TabIndex = 17;
            this.label9.Text = "Time Remaining";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // timeLabel
            // 
            this.timeLabel.Location = new System.Drawing.Point(1206, 949);
            this.timeLabel.Margin = new System.Windows.Forms.Padding(6);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.ReadOnly = true;
            this.timeLabel.Size = new System.Drawing.Size(162, 29);
            this.timeLabel.TabIndex = 16;
            //this.timeLabel.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1388, 1224);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.averagePSIText);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bmi_calculated);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.num_threshold);
            this.Controls.Add(this.num_age);
            this.Controls.Add(this.num_height);
            this.Controls.Add(this.num_weight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_ledConnected);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_LEDrx);
            this.Controls.Add(this.btn_disconnect);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.lbl_port);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "formMain";
            this.Text = "SoreSolutions";
            this.Load += new System.EventHandler(this.formMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_threshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_age)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_weight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_port;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.Button btn_LEDrx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_ledConnected;
        private System.Windows.Forms.NumericUpDown num_threshold;
        private System.Windows.Forms.NumericUpDown num_age;
        private System.Windows.Forms.NumericUpDown num_height;
        private System.Windows.Forms.NumericUpDown num_weight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox bmi_calculated;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox averagePSIText;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox timeLabel;
    }
}

