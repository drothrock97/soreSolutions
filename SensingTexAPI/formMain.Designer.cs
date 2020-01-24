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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_port = new System.Windows.Forms.Label();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.btn_conectar = new System.Windows.Forms.Button();
            this.btn_desconectar = new System.Windows.Forms.Button();
            this.btn_LEDrx = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ledConectado = new System.Windows.Forms.Button();
            this.num_threshold = new System.Windows.Forms.NumericUpDown();
            this.num_age = new System.Windows.Forms.NumericUpDown();
            this.num_height = new System.Windows.Forms.NumericUpDown();
            this.num_weight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
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
            // btn_conectar
            // 
            this.btn_conectar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_conectar.Location = new System.Drawing.Point(1206, 107);
            this.btn_conectar.Margin = new System.Windows.Forms.Padding(6);
            this.btn_conectar.Name = "btn_conectar";
            this.btn_conectar.Size = new System.Drawing.Size(165, 42);
            this.btn_conectar.TabIndex = 4;
            this.btn_conectar.Text = "CONNECT";
            this.btn_conectar.UseVisualStyleBackColor = true;
            this.btn_conectar.Click += new System.EventHandler(this.btn_conectar_Click);
            // 
            // btn_desconectar
            // 
            this.btn_desconectar.Location = new System.Drawing.Point(1206, 155);
            this.btn_desconectar.Margin = new System.Windows.Forms.Padding(6);
            this.btn_desconectar.Name = "btn_desconectar";
            this.btn_desconectar.Size = new System.Drawing.Size(165, 42);
            this.btn_desconectar.TabIndex = 5;
            this.btn_desconectar.Text = "DISCONNECT";
            this.btn_desconectar.UseVisualStyleBackColor = true;
            this.btn_desconectar.Click += new System.EventHandler(this.btn_desconectar_Click);
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
            // btn_ledConectado
            // 
            this.btn_ledConectado.BackColor = System.Drawing.Color.Red;
            this.btn_ledConectado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ledConectado.Location = new System.Drawing.Point(1208, 233);
            this.btn_ledConectado.Margin = new System.Windows.Forms.Padding(6);
            this.btn_ledConectado.Name = "btn_ledConectado";
            this.btn_ledConectado.Size = new System.Drawing.Size(42, 42);
            this.btn_ledConectado.TabIndex = 8;
            this.btn_ledConectado.UseVisualStyleBackColor = false;
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
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1388, 1224);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.num_threshold);
            this.Controls.Add(this.num_age);
            this.Controls.Add(this.num_height);
            this.Controls.Add(this.num_weight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_ledConectado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_LEDrx);
            this.Controls.Add(this.btn_desconectar);
            this.Controls.Add(this.btn_conectar);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.lbl_port);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "formMain";
            this.Text = "SoreSolutions vA01";
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
        private System.Windows.Forms.Button btn_conectar;
        private System.Windows.Forms.Button btn_desconectar;
        private System.Windows.Forms.Button btn_LEDrx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_ledConectado;
        private System.Windows.Forms.NumericUpDown num_threshold;
        private System.Windows.Forms.NumericUpDown num_age;
        private System.Windows.Forms.NumericUpDown num_height;
        private System.Windows.Forms.NumericUpDown num_weight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

