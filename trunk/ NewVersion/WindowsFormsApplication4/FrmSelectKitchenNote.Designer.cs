namespace WindowsFormsApplication4
{
    partial class FrmSelectKitchenNote
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button3 = new WindowsFormsApplication4.Controls.button();
            this.button2 = new WindowsFormsApplication4.Controls.button();
            this.button1 = new WindowsFormsApplication4.Controls.button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 31;
            this.listBox1.Location = new System.Drawing.Point(4, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(342, 624);
            this.listBox1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Color2 = System.Drawing.Color.Lime;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(379, 18);
            this.button3.Name = "button3";
            this.button3.OwnDrawColor = System.Drawing.Color.White;
            this.button3.Size = new System.Drawing.Size(127, 81);
            this.button3.TabIndex = 3;
            this.button3.Text = "Chọn";
            this.button3.UseOwnColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Color2 = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(379, 192);
            this.button2.Name = "button2";
            this.button2.OwnDrawColor = System.Drawing.Color.White;
            this.button2.Size = new System.Drawing.Size(127, 81);
            this.button2.TabIndex = 2;
            this.button2.Text = "Trở về";
            this.button2.UseOwnColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(379, 105);
            this.button1.Name = "button1";
            this.button1.OwnDrawColor = System.Drawing.Color.White;
            this.button1.Size = new System.Drawing.Size(127, 81);
            this.button1.TabIndex = 1;
            this.button1.Text = "Khác";
            this.button1.UseOwnColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmSelectKitchenNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 684);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Name = "FrmSelectKitchenNote";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ghi chú";
            this.Load += new System.EventHandler(this.FrmSelectKitchenNote_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private WindowsFormsApplication4.Controls.button button1;
        private WindowsFormsApplication4.Controls.button button2;
        private WindowsFormsApplication4.Controls.button button3;
    }
}