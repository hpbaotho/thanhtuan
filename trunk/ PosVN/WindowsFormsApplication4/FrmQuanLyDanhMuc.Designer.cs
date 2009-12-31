namespace WindowsFormsApplication4
{
    partial class FrmQuanLyDanhMuc
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMa = new WindowsFormsApplication4.Controls.CreTextBox();
            this.button2 = new WindowsFormsApplication4.Controls.button();
            this.creComboBox1 = new WindowsFormsApplication4.Controls.CreComboBox();
            this.txtMota = new WindowsFormsApplication4.Controls.CreTextBox();
            this.button1 = new WindowsFormsApplication4.Controls.button();
            this.btn_thoat = new WindowsFormsApplication4.Controls.button();
            this.btn_xoa = new WindowsFormsApplication4.Controls.button();
            this.btn_capnhat = new WindowsFormsApplication4.Controls.button();
            this.btn_Them = new WindowsFormsApplication4.Controls.button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btn_thoat);
            this.panel1.Controls.Add(this.btn_xoa);
            this.panel1.Controls.Add(this.btn_capnhat);
            this.panel1.Controls.Add(this.btn_Them);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(141, 228);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã danh mục";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mô tả";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(113, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tìm theo mã danh mục";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtMa);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.creComboBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtMota);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(147, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(368, 228);
            this.panel2.TabIndex = 9;
            // 
            // txtMa
            // 
            this.txtMa.Enabled = false;
            this.txtMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa.Location = new System.Drawing.Point(24, 50);
            this.txtMa.MaxLength = 8;
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(140, 26);
            this.txtMa.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Color2 = System.Drawing.Color.CornflowerBlue;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(281, 181);
            this.button2.Name = "button2";
            this.button2.OwnDrawColor = System.Drawing.Color.White;
            this.button2.Size = new System.Drawing.Size(84, 47);
            this.button2.TabIndex = 6;
            this.button2.Text = "Sau";
            this.button2.UseOwnColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // creComboBox1
            // 
            this.creComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.creComboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creComboBox1.FormattingEnabled = true;
            this.creComboBox1.Location = new System.Drawing.Point(97, 192);
            this.creComboBox1.Name = "creComboBox1";
            this.creComboBox1.Size = new System.Drawing.Size(178, 28);
            this.creComboBox1.TabIndex = 8;
            this.creComboBox1.SelectedIndexChanged += new System.EventHandler(this.creComboBox1_SelectedIndexChanged);
            // 
            // txtMota
            // 
            this.txtMota.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMota.Location = new System.Drawing.Point(24, 120);
            this.txtMota.Name = "txtMota";
            this.txtMota.Size = new System.Drawing.Size(331, 26);
            this.txtMota.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Color2 = System.Drawing.Color.CornflowerBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(7, 181);
            this.button1.Name = "button1";
            this.button1.OwnDrawColor = System.Drawing.Color.White;
            this.button1.Size = new System.Drawing.Size(84, 47);
            this.button1.TabIndex = 5;
            this.button1.Text = "Trước";
            this.button1.UseOwnColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_thoat
            // 
            this.btn_thoat.Color2 = System.Drawing.Color.Salmon;
            this.btn_thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_thoat.Location = new System.Drawing.Point(10, 171);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.OwnDrawColor = System.Drawing.Color.White;
            this.btn_thoat.Size = new System.Drawing.Size(114, 47);
            this.btn_thoat.TabIndex = 3;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseOwnColor = false;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Color2 = System.Drawing.Color.Red;
            this.btn_xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoa.Location = new System.Drawing.Point(10, 118);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.OwnDrawColor = System.Drawing.Color.White;
            this.btn_xoa.Size = new System.Drawing.Size(114, 47);
            this.btn_xoa.TabIndex = 2;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseOwnColor = false;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_capnhat
            // 
            this.btn_capnhat.Color2 = System.Drawing.Color.Green;
            this.btn_capnhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_capnhat.Location = new System.Drawing.Point(10, 65);
            this.btn_capnhat.Name = "btn_capnhat";
            this.btn_capnhat.OwnDrawColor = System.Drawing.Color.White;
            this.btn_capnhat.Size = new System.Drawing.Size(114, 47);
            this.btn_capnhat.TabIndex = 1;
            this.btn_capnhat.Text = "Cập nhật";
            this.btn_capnhat.UseOwnColor = false;
            this.btn_capnhat.Click += new System.EventHandler(this.btn_capnhat_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.Color2 = System.Drawing.Color.Green;
            this.btn_Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.Location = new System.Drawing.Point(10, 12);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.OwnDrawColor = System.Drawing.Color.White;
            this.btn_Them.Size = new System.Drawing.Size(114, 47);
            this.btn_Them.TabIndex = 0;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseOwnColor = false;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // FrmQuanLyDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 228);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQuanLyDanhMuc";
            this.Text = "Quản Lý Danh Mục";
            this.Load += new System.EventHandler(this.FrmQuanLyDanhMuc_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private WindowsFormsApplication4.Controls.button btn_thoat;
        private WindowsFormsApplication4.Controls.button btn_xoa;
        private WindowsFormsApplication4.Controls.button btn_capnhat;
        private WindowsFormsApplication4.Controls.button btn_Them;
        private System.Windows.Forms.Label label1;
        private WindowsFormsApplication4.Controls.CreTextBox txtMa;
        private System.Windows.Forms.Label label2;
        private WindowsFormsApplication4.Controls.CreTextBox txtMota;
        private WindowsFormsApplication4.Controls.button button1;
        private WindowsFormsApplication4.Controls.button button2;
        private System.Windows.Forms.Label label3;
        private WindowsFormsApplication4.Controls.CreComboBox creComboBox1;
        private System.Windows.Forms.Panel panel2;

    }
}