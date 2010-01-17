namespace WindowsFormsApplication4
{
    partial class FrmRegister
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
            this.creTextBox1 = new WindowsFormsApplication4.Controls.CreTextBox();
            this.creTextBox2 = new WindowsFormsApplication4.Controls.CreTextBox();
            this.creTextBox3 = new WindowsFormsApplication4.Controls.CreTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new WindowsFormsApplication4.Controls.button();
            this.button2 = new WindowsFormsApplication4.Controls.button();
            this.SuspendLayout();
            // 
            // creTextBox1
            // 
            this.creTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creTextBox1.Location = new System.Drawing.Point(33, 73);
            this.creTextBox1.Name = "creTextBox1";
            this.creTextBox1.ReadOnly = true;
            this.creTextBox1.Size = new System.Drawing.Size(559, 31);
            this.creTextBox1.TabIndex = 0;
            // 
            // creTextBox2
            // 
            this.creTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creTextBox2.Location = new System.Drawing.Point(33, 163);
            this.creTextBox2.Name = "creTextBox2";
            this.creTextBox2.Size = new System.Drawing.Size(559, 31);
            this.creTextBox2.TabIndex = 1;
            // 
            // creTextBox3
            // 
            this.creTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creTextBox3.Location = new System.Drawing.Point(33, 251);
            this.creTextBox3.Name = "creTextBox3";
            this.creTextBox3.Size = new System.Drawing.Size(559, 31);
            this.creTextBox3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã bảo vệ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mã kích hoạt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mã đăng kí";
            // 
            // button1
            // 
            this.button1.Color2 = System.Drawing.Color.Lime;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(232, 319);
            this.button1.Name = "button1";
            this.button1.OwnDrawColor = System.Drawing.Color.White;
            this.button1.Size = new System.Drawing.Size(163, 76);
            this.button1.TabIndex = 6;
            this.button1.Text = "Đăng kí";
            this.button1.UseOwnColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Color2 = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(429, 319);
            this.button2.Name = "button2";
            this.button2.OwnDrawColor = System.Drawing.Color.White;
            this.button2.Size = new System.Drawing.Size(163, 76);
            this.button2.TabIndex = 7;
            this.button2.Text = "Hủy";
            this.button2.UseOwnColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 421);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.creTextBox3);
            this.Controls.Add(this.creTextBox2);
            this.Controls.Add(this.creTextBox1);
            this.Name = "FrmRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRegister";
            this.Load += new System.EventHandler(this.FrmRegister_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowsFormsApplication4.Controls.CreTextBox creTextBox1;
        private WindowsFormsApplication4.Controls.CreTextBox creTextBox2;
        private WindowsFormsApplication4.Controls.CreTextBox creTextBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private WindowsFormsApplication4.Controls.button button1;
        private WindowsFormsApplication4.Controls.button button2;
    }
}