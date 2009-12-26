using System.Drawing;

namespace WindowsFormsApplication4.Controls
{
    partial class MyCash
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.panel_Ban = new System.Windows.Forms.Label();
            this.panel_ServerId = new System.Windows.Forms.Label();
            this.panel_Timer = new System.Windows.Forms.Label();
            this.Label_Ban = new System.Windows.Forms.Label();
            this.Label_ServerId = new System.Windows.Forms.Label();
            this.Label_Timer = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_Total = new System.Windows.Forms.Label();
            this.label_TongCong = new System.Windows.Forms.Label();
            this.label_Tax = new System.Windows.Forms.Label();
            this.label_Thue = new System.Windows.Forms.Label();
            this.button2 = new WindowsFormsApplication4.Controls.button();
            this.button1 = new WindowsFormsApplication4.Controls.button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.myItem1 = new WindowsFormsApplication4.Controls.MyItem();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(334, 56);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(18, 440);
            this.vScrollBar1.TabIndex = 0;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // panel_Ban
            // 
            this.panel_Ban.BackColor = System.Drawing.Color.DimGray;
            this.panel_Ban.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.panel_Ban.ForeColor = System.Drawing.Color.White;
            this.panel_Ban.Location = new System.Drawing.Point(0, 0);
            this.panel_Ban.Name = "panel_Ban";
            this.panel_Ban.Size = new System.Drawing.Size(90, 28);
            this.panel_Ban.TabIndex = 2;
            this.panel_Ban.Text = "Bàn #";
            this.panel_Ban.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_ServerId
            // 
            this.panel_ServerId.BackColor = System.Drawing.Color.DimGray;
            this.panel_ServerId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.panel_ServerId.ForeColor = System.Drawing.Color.White;
            this.panel_ServerId.Location = new System.Drawing.Point(90, 0);
            this.panel_ServerId.Name = "panel_ServerId";
            this.panel_ServerId.Size = new System.Drawing.Size(90, 28);
            this.panel_ServerId.TabIndex = 3;
            this.panel_ServerId.Text = "Nhân viên";
            this.panel_ServerId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_Timer
            // 
            this.panel_Timer.BackColor = System.Drawing.Color.DimGray;
            this.panel_Timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.panel_Timer.ForeColor = System.Drawing.Color.White;
            this.panel_Timer.Location = new System.Drawing.Point(180, 0);
            this.panel_Timer.Name = "panel_Timer";
            this.panel_Timer.Size = new System.Drawing.Size(172, 28);
            this.panel_Timer.TabIndex = 4;
            this.panel_Timer.Text = "Giờ";
            this.panel_Timer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Ban
            // 
            this.Label_Ban.BackColor = System.Drawing.Color.DimGray;
            this.Label_Ban.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Label_Ban.ForeColor = System.Drawing.Color.White;
            this.Label_Ban.Location = new System.Drawing.Point(0, 28);
            this.Label_Ban.Name = "Label_Ban";
            this.Label_Ban.Size = new System.Drawing.Size(90, 28);
            this.Label_Ban.TabIndex = 6;
            this.Label_Ban.Text = "N";
            this.Label_Ban.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_ServerId
            // 
            this.Label_ServerId.BackColor = System.Drawing.Color.DimGray;
            this.Label_ServerId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Label_ServerId.ForeColor = System.Drawing.Color.White;
            this.Label_ServerId.Location = new System.Drawing.Point(90, 28);
            this.Label_ServerId.Name = "Label_ServerId";
            this.Label_ServerId.Size = new System.Drawing.Size(90, 28);
            this.Label_ServerId.TabIndex = 7;
            this.Label_ServerId.Text = "N";
            this.Label_ServerId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Timer
            // 
            this.Label_Timer.BackColor = System.Drawing.Color.DimGray;
            this.Label_Timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Label_Timer.ForeColor = System.Drawing.Color.White;
            this.Label_Timer.Location = new System.Drawing.Point(180, 28);
            this.Label_Timer.Name = "Label_Timer";
            this.Label_Timer.Size = new System.Drawing.Size(172, 28);
            this.Label_Timer.TabIndex = 8;
            this.Label_Timer.Text = "N";
            this.Label_Timer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.label_Total);
            this.panel1.Controls.Add(this.label_TongCong);
            this.panel1.Controls.Add(this.label_Tax);
            this.panel1.Controls.Add(this.label_Thue);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(0, 496);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 89);
            this.panel1.TabIndex = 5;
            // 
            // label_Total
            // 
            this.label_Total.BackColor = System.Drawing.Color.DimGray;
            this.label_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Total.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_Total.Location = new System.Drawing.Point(187, 40);
            this.label_Total.Name = "label_Total";
            this.label_Total.Size = new System.Drawing.Size(165, 49);
            this.label_Total.TabIndex = 5;
            this.label_Total.Text = "0.00";
            this.label_Total.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_TongCong
            // 
            this.label_TongCong.BackColor = System.Drawing.Color.DarkGreen;
            this.label_TongCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TongCong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label_TongCong.Location = new System.Drawing.Point(128, 40);
            this.label_TongCong.Name = "label_TongCong";
            this.label_TongCong.Size = new System.Drawing.Size(59, 49);
            this.label_TongCong.TabIndex = 4;
            this.label_TongCong.Text = "TC";
            this.label_TongCong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Tax
            // 
            this.label_Tax.BackColor = System.Drawing.Color.DimGray;
            this.label_Tax.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Tax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_Tax.Location = new System.Drawing.Point(187, 0);
            this.label_Tax.Name = "label_Tax";
            this.label_Tax.Size = new System.Drawing.Size(165, 40);
            this.label_Tax.TabIndex = 3;
            this.label_Tax.Text = "0.00";
            this.label_Tax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Thue
            // 
            this.label_Thue.BackColor = System.Drawing.Color.DarkGreen;
            this.label_Thue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Thue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label_Thue.Location = new System.Drawing.Point(128, 0);
            this.label_Thue.Name = "label_Thue";
            this.label_Thue.Size = new System.Drawing.Size(59, 40);
            this.label_Thue.TabIndex = 2;
            this.label_Thue.Text = "Thuế";
            this.label_Thue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(64, 0);
            this.button2.Name = "button2";
            this.button2.OwnDrawColor = System.Drawing.Color.White;
            this.button2.Size = new System.Drawing.Size(64, 64);
            this.button2.TabIndex = 1;
            this.button2.Text = "▼";
            this.button2.UseOwnColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.OwnDrawColor = System.Drawing.Color.White;
            this.button1.Size = new System.Drawing.Size(64, 64);
            this.button1.TabIndex = 0;
            this.button1.Text = "▲";
            this.button1.UseOwnColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // myItem1
            // 
            this.myItem1.Click = false;
            this.myItem1.Enabled = false;
            this.myItem1.Gia = null;
            this.myItem1.Id = 0;
            this.myItem1.Location = new System.Drawing.Point(0, 56);
            this.myItem1.Mota = null;
            this.myItem1.Name = "myItem1";
            this.myItem1.Selected = false;
            this.myItem1.Size = new System.Drawing.Size(334, 30);
            this.myItem1.Soluong = "0";
            this.myItem1.TabIndex = 1;
            this.myItem1.Text = "myItem";
            // 
            // MyCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_Timer);
            this.Controls.Add(this.panel_ServerId);
            this.Controls.Add(this.panel_Ban);
            this.Controls.Add(this.Label_Ban);
            this.Controls.Add(this.Label_ServerId);
            this.Controls.Add(this.Label_Timer);
            this.Controls.Add(this.myItem1);
            this.Controls.Add(this.vScrollBar1);
            this.Name = "MyCash";
            this.Size = new System.Drawing.Size(352, 585);
            this.Load += new System.EventHandler(this.MyCash_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar vScrollBar1;
        private MyItem myItem1;
        private System.Windows.Forms.Label panel_Ban;

        public System.Windows.Forms.Label panel_ServerId;
        public System.Windows.Forms.Label panel_Timer;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label Label_Ban;
        public System.Windows.Forms.Label Label_ServerId;
        public System.Windows.Forms.Label Label_Timer;
        private button button1;
        private button button2;
        public System.Windows.Forms.Label label_Total;
        public System.Windows.Forms.Label label_TongCong;
        public System.Windows.Forms.Label label_Tax;
        public System.Windows.Forms.Label label_Thue;

        public System.Windows.Forms.Timer timer1;
        
    }
}
