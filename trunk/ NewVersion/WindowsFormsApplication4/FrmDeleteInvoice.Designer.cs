namespace WindowsFormsApplication4
{
    partial class FrmDeleteInvoice
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
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new WindowsFormsApplication4.Controls.button();
            this.button2 = new WindowsFormsApplication4.Controls.button();
            this.button1 = new WindowsFormsApplication4.Controls.button();
            this.SuspendLayout();
            // 
            // txtEndTime
            // 
            this.txtEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndTime.Location = new System.Drawing.Point(182, 132);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(117, 29);
            this.txtEndTime.TabIndex = 27;
            this.txtEndTime.DoubleClick += new System.EventHandler(this.txtEndTime_DoubleClick);
            // 
            // txtStartTime
            // 
            this.txtStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartTime.Location = new System.Drawing.Point(182, 77);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(117, 29);
            this.txtStartTime.TabIndex = 26;
            this.txtStartTime.DoubleClick += new System.EventHandler(this.txtStartTime_DoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(178, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "Giờ kết thúc";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(178, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "Giờ bắt đầu";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndDate.Location = new System.Drawing.Point(17, 132);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(117, 29);
            this.txtEndDate.TabIndex = 23;
            this.txtEndDate.DoubleClick += new System.EventHandler(this.txtEndDate_DoubleClick);
            // 
            // txtStartDate
            // 
            this.txtStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartDate.Location = new System.Drawing.Point(17, 77);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(117, 29);
            this.txtStartDate.TabIndex = 22;
            this.txtStartDate.DoubleClick += new System.EventHandler(this.txtStartDate_DoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Ngày kết thúc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Ngày bắt đầu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 29);
            this.label3.TabIndex = 19;
            this.label3.Text = "Ngày/Giờ";
            // 
            // button3
            // 
            this.button3.Color2 = System.Drawing.Color.Blue;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(328, 186);
            this.button3.Name = "button3";
            this.button3.OwnDrawColor = System.Drawing.Color.White;
            this.button3.Size = new System.Drawing.Size(117, 84);
            this.button3.TabIndex = 30;
            this.button3.Text = "Thoát";
            this.button3.UseOwnColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Color2 = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(182, 186);
            this.button2.Name = "button2";
            this.button2.OwnDrawColor = System.Drawing.Color.White;
            this.button2.Size = new System.Drawing.Size(117, 84);
            this.button2.TabIndex = 29;
            this.button2.Text = "Xóa tất cả";
            this.button2.UseOwnColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(328, 77);
            this.button1.Name = "button1";
            this.button1.OwnDrawColor = System.Drawing.Color.White;
            this.button1.Size = new System.Drawing.Size(117, 84);
            this.button1.TabIndex = 28;
            this.button1.Text = "Xóa theo ngày";
            this.button1.UseOwnColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmDeleteInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 284);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtEndTime);
            this.Controls.Add(this.txtStartTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDeleteInvoice";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xóa hóa đơn";
            this.Load += new System.EventHandler(this.FrmDeleteInvoice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEndTime;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private WindowsFormsApplication4.Controls.button button1;
        private WindowsFormsApplication4.Controls.button button2;
        private WindowsFormsApplication4.Controls.button button3;
    }
}