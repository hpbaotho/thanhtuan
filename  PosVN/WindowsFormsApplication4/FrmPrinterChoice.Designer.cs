namespace WindowsFormsApplication4
{
    partial class FrmPrinterChoice
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
            this.creListBox1 = new WindowsFormsApplication4.Controls.CreListBox();
            this.button1 = new WindowsFormsApplication4.Controls.button();
            this.button2 = new WindowsFormsApplication4.Controls.button();
            this.SuspendLayout();
            // 
            // creListBox1
            // 
            this.creListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creListBox1.FormattingEnabled = true;
            this.creListBox1.ItemHeight = 29;
            this.creListBox1.Location = new System.Drawing.Point(55, 22);
            this.creListBox1.Name = "creListBox1";
            this.creListBox1.Size = new System.Drawing.Size(314, 323);
            this.creListBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Color2 = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(55, 381);
            this.button1.Name = "button1";
            this.button1.OwnDrawColor = System.Drawing.Color.White;
            this.button1.Size = new System.Drawing.Size(134, 80);
            this.button1.TabIndex = 1;
            this.button1.Text = "Quay về";
            this.button1.UseOwnColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Color2 = System.Drawing.Color.Lime;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(232, 381);
            this.button2.Name = "button2";
            this.button2.OwnDrawColor = System.Drawing.Color.White;
            this.button2.Size = new System.Drawing.Size(137, 80);
            this.button2.TabIndex = 2;
            this.button2.Text = "Chọn";
            this.button2.UseOwnColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmPrinterChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 473);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.creListBox1);
            this.Name = "FrmPrinterChoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPrinterChoice";
            this.Load += new System.EventHandler(this.FrmPrinterChoice_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsFormsApplication4.Controls.CreListBox creListBox1;
        private WindowsFormsApplication4.Controls.button button1;
        private WindowsFormsApplication4.Controls.button button2;
    }
}