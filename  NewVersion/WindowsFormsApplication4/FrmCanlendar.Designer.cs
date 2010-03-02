namespace WindowsFormsApplication4
{
    partial class FrmCanlendar
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPreM = new WindowsFormsApplication4.Controls.button();
            this.btnPreY = new WindowsFormsApplication4.Controls.button();
            this.btnNextY = new WindowsFormsApplication4.Controls.button();
            this.btnNextM = new WindowsFormsApplication4.Controls.button();
            this.txtNow = new WindowsFormsApplication4.Controls.CreTextBox();
            this.button1 = new WindowsFormsApplication4.Controls.button();
            this.btnSelect = new WindowsFormsApplication4.Controls.button();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendar1.Location = new System.Drawing.Point(1, 60);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // btnPreM
            // 
            this.btnPreM.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnPreM.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreM.Location = new System.Drawing.Point(69, 467);
            this.btnPreM.Name = "btnPreM";
            this.btnPreM.OwnDrawColor = System.Drawing.Color.White;
            this.btnPreM.Size = new System.Drawing.Size(64, 65);
            this.btnPreM.TabIndex = 8;
            this.btnPreM.Text = "Tháng Trước";
            this.btnPreM.UseOwnColor = false;
            this.btnPreM.Click += new System.EventHandler(this.btnPreM_Click);
            // 
            // btnPreY
            // 
            this.btnPreY.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnPreY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreY.Location = new System.Drawing.Point(4, 467);
            this.btnPreY.Name = "btnPreY";
            this.btnPreY.OwnDrawColor = System.Drawing.Color.White;
            this.btnPreY.Size = new System.Drawing.Size(64, 65);
            this.btnPreY.TabIndex = 7;
            this.btnPreY.Text = "Năm Trước";
            this.btnPreY.UseOwnColor = false;
            this.btnPreY.Click += new System.EventHandler(this.btnPreY_Click);
            // 
            // btnNextY
            // 
            this.btnNextY.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnNextY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextY.Location = new System.Drawing.Point(406, 467);
            this.btnNextY.Name = "btnNextY";
            this.btnNextY.OwnDrawColor = System.Drawing.Color.White;
            this.btnNextY.Size = new System.Drawing.Size(64, 65);
            this.btnNextY.TabIndex = 6;
            this.btnNextY.Text = "Năm Tới";
            this.btnNextY.UseOwnColor = false;
            this.btnNextY.Click += new System.EventHandler(this.btnNextY_Click);
            // 
            // btnNextM
            // 
            this.btnNextM.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnNextM.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextM.Location = new System.Drawing.Point(341, 467);
            this.btnNextM.Name = "btnNextM";
            this.btnNextM.OwnDrawColor = System.Drawing.Color.White;
            this.btnNextM.Size = new System.Drawing.Size(64, 65);
            this.btnNextM.TabIndex = 5;
            this.btnNextM.Text = "Tháng Tới";
            this.btnNextM.UseOwnColor = false;
            this.btnNextM.Click += new System.EventHandler(this.btnNextM_Click);
            // 
            // txtNow
            // 
            this.txtNow.Enabled = false;
            this.txtNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNow.Location = new System.Drawing.Point(144, 481);
            this.txtNow.Name = "txtNow";
            this.txtNow.Size = new System.Drawing.Size(191, 38);
            this.txtNow.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Color2 = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1, 538);
            this.button1.Name = "button1";
            this.button1.OwnDrawColor = System.Drawing.Color.White;
            this.button1.Size = new System.Drawing.Size(101, 63);
            this.button1.TabIndex = 3;
            this.button1.Text = "Thoát";
            this.button1.UseOwnColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Location = new System.Drawing.Point(102, 538);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.OwnDrawColor = System.Drawing.Color.White;
            this.btnSelect.Size = new System.Drawing.Size(376, 63);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "Chọn";
            this.btnSelect.UseOwnColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // FrmCanlendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 602);
            this.ControlBox = false;
            this.Controls.Add(this.btnPreM);
            this.Controls.Add(this.btnPreY);
            this.Controls.Add(this.btnNextY);
            this.Controls.Add(this.btnNextM);
            this.Controls.Add(this.txtNow);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "FrmCanlendar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn ngày tháng";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowsFormsApplication4.Controls.button btnSelect;
        private WindowsFormsApplication4.Controls.button button1;
        private WindowsFormsApplication4.Controls.CreTextBox txtNow;
        private WindowsFormsApplication4.Controls.button btnNextM;
        private WindowsFormsApplication4.Controls.button btnNextY;
        private WindowsFormsApplication4.Controls.button btnPreM;
        private WindowsFormsApplication4.Controls.button btnPreY;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}