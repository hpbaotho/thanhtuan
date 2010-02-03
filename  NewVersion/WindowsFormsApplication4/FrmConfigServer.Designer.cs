namespace WindowsFormsApplication4
{
    partial class FrmConfigServer
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new WindowsFormsApplication4.Controls.button();
            this.button1 = new WindowsFormsApplication4.Controls.button();
            this.creTextBox1 = new WindowsFormsApplication4.Controls.CreTextBox();
            this.creTextBox2 = new WindowsFormsApplication4.Controls.CreTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "PORT";
            // 
            // button2
            // 
            this.button2.Color1 = System.Drawing.Color.Red;
            this.button2.Color2 = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(189, 137);
            this.button2.Name = "button2";
            this.button2.OwnDrawColor = System.Drawing.Color.White;
            this.button2.Size = new System.Drawing.Size(95, 50);
            this.button2.TabIndex = 5;
            this.button2.Text = "Hủy";
            this.button2.UseOwnColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Color1 = System.Drawing.Color.Blue;
            this.button1.Color2 = System.Drawing.Color.Blue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(93, 137);
            this.button1.Name = "button1";
            this.button1.OwnDrawColor = System.Drawing.Color.White;
            this.button1.Size = new System.Drawing.Size(95, 50);
            this.button1.TabIndex = 4;
            this.button1.Text = "Xác nhận";
            this.button1.UseOwnColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // creTextBox1
            // 
            this.creTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creTextBox1.Location = new System.Drawing.Point(93, 35);
            this.creTextBox1.Name = "creTextBox1";
            this.creTextBox1.Size = new System.Drawing.Size(150, 31);
            this.creTextBox1.TabIndex = 6;
            // 
            // creTextBox2
            // 
            this.creTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creTextBox2.Location = new System.Drawing.Point(93, 81);
            this.creTextBox2.Name = "creTextBox2";
            this.creTextBox2.Size = new System.Drawing.Size(95, 31);
            this.creTextBox2.TabIndex = 7;
            // 
            // FrmConfigServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 199);
            this.Controls.Add(this.creTextBox2);
            this.Controls.Add(this.creTextBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmConfigServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmConfigServer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private WindowsFormsApplication4.Controls.button button1;
        private WindowsFormsApplication4.Controls.button button2;
        private WindowsFormsApplication4.Controls.CreTextBox creTextBox1;
        private WindowsFormsApplication4.Controls.CreTextBox creTextBox2;
    }
}