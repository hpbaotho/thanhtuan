namespace WindowsFormsApplication4
{
    partial class FrmChangePassAdmin
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
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new WindowsFormsApplication4.Controls.button();
            this.button1 = new WindowsFormsApplication4.Controls.button();
            this.creTextBox3 = new WindowsFormsApplication4.Controls.CreTextBox();
            this.creTextBox2 = new WindowsFormsApplication4.Controls.CreTextBox();
            this.creTextBox1 = new WindowsFormsApplication4.Controls.CreTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mật khẩu cũ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mật khẩu mới";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Xác nhận";
            // 
            // button2
            // 
            this.button2.Color2 = System.Drawing.Color.Lime;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(230, 252);
            this.button2.Name = "button2";
            this.button2.OwnDrawColor = System.Drawing.Color.White;
            this.button2.Size = new System.Drawing.Size(165, 100);
            this.button2.TabIndex = 7;
            this.button2.Text = "Hoàn tất";
            this.button2.UseOwnColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Color2 = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(13, 252);
            this.button1.Name = "button1";
            this.button1.OwnDrawColor = System.Drawing.Color.White;
            this.button1.Size = new System.Drawing.Size(166, 100);
            this.button1.TabIndex = 6;
            this.button1.Text = "Quay về";
            this.button1.UseOwnColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // creTextBox3
            // 
            this.creTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creTextBox3.Location = new System.Drawing.Point(157, 156);
            this.creTextBox3.Name = "creTextBox3";
            this.creTextBox3.PasswordChar = '●';
            this.creTextBox3.Size = new System.Drawing.Size(238, 29);
            this.creTextBox3.TabIndex = 4;
            // 
            // creTextBox2
            // 
            this.creTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creTextBox2.Location = new System.Drawing.Point(157, 93);
            this.creTextBox2.Name = "creTextBox2";
            this.creTextBox2.PasswordChar = '●';
            this.creTextBox2.Size = new System.Drawing.Size(238, 29);
            this.creTextBox2.TabIndex = 2;
            // 
            // creTextBox1
            // 
            this.creTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creTextBox1.Location = new System.Drawing.Point(157, 32);
            this.creTextBox1.Name = "creTextBox1";
            this.creTextBox1.PasswordChar = '●';
            this.creTextBox1.Size = new System.Drawing.Size(238, 29);
            this.creTextBox1.TabIndex = 0;
            // 
            // FrmChangePassAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 364);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.creTextBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.creTextBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.creTextBox1);
            this.Name = "FrmChangePassAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowsFormsApplication4.Controls.CreTextBox creTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private WindowsFormsApplication4.Controls.CreTextBox creTextBox2;
        private System.Windows.Forms.Label label3;
        private WindowsFormsApplication4.Controls.CreTextBox creTextBox3;
        private WindowsFormsApplication4.Controls.button button1;
        private WindowsFormsApplication4.Controls.button button2;
    }
}