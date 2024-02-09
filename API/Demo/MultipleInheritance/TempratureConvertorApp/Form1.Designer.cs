namespace TempratureConvertorApp
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radio_F = new System.Windows.Forms.RadioButton();
            this.radio_C = new System.Windows.Forms.RadioButton();
            this.radio_K = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radio_ToK = new System.Windows.Forms.RadioButton();
            this.radio_ToC = new System.Windows.Forms.RadioButton();
            this.radio_ToF = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label_answer = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radio_K);
            this.groupBox1.Controls.Add(this.radio_C);
            this.groupBox1.Controls.Add(this.radio_F);
            this.groupBox1.Location = new System.Drawing.Point(45, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(135, 148);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Base Scale";
            // 
            // radio_F
            // 
            this.radio_F.AutoSize = true;
            this.radio_F.Location = new System.Drawing.Point(27, 42);
            this.radio_F.Name = "radio_F";
            this.radio_F.Size = new System.Drawing.Size(75, 17);
            this.radio_F.TabIndex = 1;
            this.radio_F.TabStop = true;
            this.radio_F.Text = "Fahrenheit";
            this.radio_F.UseVisualStyleBackColor = true;
            // 
            // radio_C
            // 
            this.radio_C.AutoSize = true;
            this.radio_C.Location = new System.Drawing.Point(27, 76);
            this.radio_C.Name = "radio_C";
            this.radio_C.Size = new System.Drawing.Size(58, 17);
            this.radio_C.TabIndex = 2;
            this.radio_C.TabStop = true;
            this.radio_C.Text = "Celsius";
            this.radio_C.UseVisualStyleBackColor = true;
            // 
            // radio_K
            // 
            this.radio_K.AutoSize = true;
            this.radio_K.Location = new System.Drawing.Point(27, 109);
            this.radio_K.Name = "radio_K";
            this.radio_K.Size = new System.Drawing.Size(54, 17);
            this.radio_K.TabIndex = 3;
            this.radio_K.TabStop = true;
            this.radio_K.Text = "Kelvin";
            this.radio_K.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radio_ToK);
            this.groupBox2.Controls.Add(this.radio_ToC);
            this.groupBox2.Controls.Add(this.radio_ToF);
            this.groupBox2.Location = new System.Drawing.Point(225, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(135, 148);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Convert To:";
            // 
            // radio_ToK
            // 
            this.radio_ToK.AutoSize = true;
            this.radio_ToK.Location = new System.Drawing.Point(27, 109);
            this.radio_ToK.Name = "radio_ToK";
            this.radio_ToK.Size = new System.Drawing.Size(54, 17);
            this.radio_ToK.TabIndex = 3;
            this.radio_ToK.TabStop = true;
            this.radio_ToK.Text = "Kelvin";
            this.radio_ToK.UseVisualStyleBackColor = true;
            // 
            // radio_ToC
            // 
            this.radio_ToC.AutoSize = true;
            this.radio_ToC.Location = new System.Drawing.Point(27, 76);
            this.radio_ToC.Name = "radio_ToC";
            this.radio_ToC.Size = new System.Drawing.Size(58, 17);
            this.radio_ToC.TabIndex = 2;
            this.radio_ToC.TabStop = true;
            this.radio_ToC.Text = "Celsius";
            this.radio_ToC.UseVisualStyleBackColor = true;
            // 
            // radio_ToF
            // 
            this.radio_ToF.AutoSize = true;
            this.radio_ToF.Location = new System.Drawing.Point(27, 42);
            this.radio_ToF.Name = "radio_ToF";
            this.radio_ToF.Size = new System.Drawing.Size(75, 17);
            this.radio_ToF.TabIndex = 1;
            this.radio_ToF.TabStop = true;
            this.radio_ToF.Text = "Fahrenheit";
            this.radio_ToF.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Temprature:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(127, 218);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 20);
            this.textBox1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(45, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(240, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label_answer
            // 
            this.label_answer.AutoSize = true;
            this.label_answer.Location = new System.Drawing.Point(45, 308);
            this.label_answer.Name = "label_answer";
            this.label_answer.Size = new System.Drawing.Size(31, 13);
            this.label_answer.TabIndex = 8;
            this.label_answer.Text = "Ans: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 450);
            this.Controls.Add(this.label_answer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radio_K;
        private System.Windows.Forms.RadioButton radio_C;
        private System.Windows.Forms.RadioButton radio_F;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radio_ToK;
        private System.Windows.Forms.RadioButton radio_ToC;
        private System.Windows.Forms.RadioButton radio_ToF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_answer;
    }
}

