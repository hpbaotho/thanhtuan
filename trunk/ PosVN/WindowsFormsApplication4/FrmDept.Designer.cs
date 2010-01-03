namespace WindowsFormsApplication4
{
    partial class FrmDept
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
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckb_Sua = new System.Windows.Forms.CheckBox();
            this.txtDeptDesc = new WindowsFormsApplication4.Controls.CreTextBox();
            this.txtDeptID = new WindowsFormsApplication4.Controls.CreTextBox();
            this.cmbCate = new WindowsFormsApplication4.Controls.CreComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.creTextBox2 = new WindowsFormsApplication4.Controls.CreTextBox();
            this.creTextBox1 = new WindowsFormsApplication4.Controls.CreTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new WindowsFormsApplication4.Controls.button();
            this.button2 = new WindowsFormsApplication4.Controls.button();
            this.button3 = new WindowsFormsApplication4.Controls.button();
            this.button4 = new WindowsFormsApplication4.Controls.button();
            this.button5 = new WindowsFormsApplication4.Controls.button();
            this.button7 = new WindowsFormsApplication4.Controls.button();
            this.button8 = new WindowsFormsApplication4.Controls.button();
            this.button9 = new WindowsFormsApplication4.Controls.button();
            this.button10 = new WindowsFormsApplication4.Controls.button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(473, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(126, 24);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Thông thường";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(473, 68);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(92, 24);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.Text = "Cho thuê";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.Location = new System.Drawing.Point(473, 113);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(97, 24);
            this.radioButton3.TabIndex = 5;
            this.radioButton3.Text = "Nhân viên";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.ckb_Sua);
            this.panel1.Controls.Add(this.txtDeptDesc);
            this.panel1.Controls.Add(this.txtDeptID);
            this.panel1.Controls.Add(this.cmbCate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Location = new System.Drawing.Point(1, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 174);
            this.panel1.TabIndex = 6;
            // 
            // ckb_Sua
            // 
            this.ckb_Sua.AutoSize = true;
            this.ckb_Sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckb_Sua.Location = new System.Drawing.Point(342, 74);
            this.ckb_Sua.Name = "ckb_Sua";
            this.ckb_Sua.Size = new System.Drawing.Size(51, 20);
            this.ckb_Sua.TabIndex = 12;
            this.ckb_Sua.Text = "Sửa";
            this.ckb_Sua.UseVisualStyleBackColor = true;
            this.ckb_Sua.CheckedChanged += new System.EventHandler(this.ckb_Sua_CheckedChanged);
            // 
            // txtDeptDesc
            // 
            this.txtDeptDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeptDesc.Location = new System.Drawing.Point(173, 110);
            this.txtDeptDesc.Name = "txtDeptDesc";
            this.txtDeptDesc.Size = new System.Drawing.Size(255, 29);
            this.txtDeptDesc.TabIndex = 11;
            // 
            // txtDeptID
            // 
            this.txtDeptID.Enabled = false;
            this.txtDeptID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeptID.Location = new System.Drawing.Point(173, 65);
            this.txtDeptID.MaxLength = 8;
            this.txtDeptID.Name = "txtDeptID";
            this.txtDeptID.Size = new System.Drawing.Size(144, 29);
            this.txtDeptID.TabIndex = 10;
            this.txtDeptID.TextChanged += new System.EventHandler(this.txtDeptID_TextChanged);
            // 
            // cmbCate
            // 
            this.cmbCate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCate.FormattingEnabled = true;
            this.cmbCate.Location = new System.Drawing.Point(173, 22);
            this.cmbCate.Name = "cmbCate";
            this.cmbCate.Size = new System.Drawing.Size(255, 32);
            this.cmbCate.TabIndex = 9;
            this.cmbCate.SelectedIndexChanged += new System.EventHandler(this.cmbCate_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 24);
            this.label6.TabIndex = 8;
            this.label6.Text = "Mô tả loại hàng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "Mã loại hàng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Danh mục";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(1, 255);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(814, 230);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.creTextBox2);
            this.tabPage1.Controls.Add(this.creTextBox1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.checkBox4);
            this.tabPage1.Controls.Add(this.checkBox3);
            this.tabPage1.Controls.Add(this.checkBox2);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(806, 193);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Options";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // creTextBox2
            // 
            this.creTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creTextBox2.Location = new System.Drawing.Point(558, 74);
            this.creTextBox2.Name = "creTextBox2";
            this.creTextBox2.Size = new System.Drawing.Size(188, 29);
            this.creTextBox2.TabIndex = 13;
            this.creTextBox2.Text = "0";
            // 
            // creTextBox1
            // 
            this.creTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creTextBox1.Location = new System.Drawing.Point(558, 26);
            this.creTextBox1.Name = "creTextBox1";
            this.creTextBox1.Size = new System.Drawing.Size(188, 29);
            this.creTextBox1.TabIndex = 12;
            this.creTextBox1.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(409, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 48);
            this.label3.TabIndex = 7;
            this.label3.Text = "   Item Cost\r\n  Percentage\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(406, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Square Footage";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(26, 128);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(172, 28);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "Bar Tax Inclusive";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(26, 94);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(319, 28);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "Require Serial # / Reference Entry ";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(26, 60);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(271, 28);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Require Permissions for Sale";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(26, 26);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(264, 28);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Print Department on Receipt";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(806, 193);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Receipt Notes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(4, 7);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(795, 180);
            this.textBox1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(1, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(814, 34);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông tin chung cho ";
            // 
            // button1
            // 
            this.button1.Color2 = System.Drawing.Color.Green;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(435, 507);
            this.button1.Name = "button1";
            this.button1.OwnDrawColor = System.Drawing.Color.White;
            this.button1.Size = new System.Drawing.Size(122, 43);
            this.button1.TabIndex = 8;
            this.button1.Text = "Thêm mới loại hàng";
            this.button1.UseOwnColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Color2 = System.Drawing.Color.DarkGreen;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(563, 507);
            this.button2.Name = "button2";
            this.button2.OwnDrawColor = System.Drawing.Color.White;
            this.button2.Size = new System.Drawing.Size(122, 43);
            this.button2.TabIndex = 9;
            this.button2.Text = "Lưu thay đổi";
            this.button2.UseOwnColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Color2 = System.Drawing.Color.DarkOrange;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(689, 507);
            this.button3.Name = "button3";
            this.button3.OwnDrawColor = System.Drawing.Color.White;
            this.button3.Size = new System.Drawing.Size(122, 43);
            this.button3.TabIndex = 10;
            this.button3.Text = "Quản lý danh mục";
            this.button3.UseOwnColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Color2 = System.Drawing.Color.DarkGreen;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(435, 556);
            this.button4.Name = "button4";
            this.button4.OwnDrawColor = System.Drawing.Color.White;
            this.button4.Size = new System.Drawing.Size(122, 43);
            this.button4.TabIndex = 11;
            this.button4.Text = "Sao chép";
            this.button4.UseOwnColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Color2 = System.Drawing.Color.Red;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(563, 555);
            this.button5.Name = "button5";
            this.button5.OwnDrawColor = System.Drawing.Color.White;
            this.button5.Size = new System.Drawing.Size(122, 43);
            this.button5.TabIndex = 12;
            this.button5.Text = "Xóa";
            this.button5.UseOwnColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button7
            // 
            this.button7.Color2 = System.Drawing.Color.IndianRed;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(689, 555);
            this.button7.Name = "button7";
            this.button7.OwnDrawColor = System.Drawing.Color.White;
            this.button7.Size = new System.Drawing.Size(122, 43);
            this.button7.TabIndex = 14;
            this.button7.Text = "Thoát";
            this.button7.UseOwnColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Color2 = System.Drawing.Color.CornflowerBlue;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(5, 530);
            this.button8.Name = "button8";
            this.button8.OwnDrawColor = System.Drawing.Color.White;
            this.button8.Size = new System.Drawing.Size(101, 69);
            this.button8.TabIndex = 15;
            this.button8.Text = "Trước";
            this.button8.UseOwnColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Red;
            this.button9.Color2 = System.Drawing.Color.CornflowerBlue;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(201, 530);
            this.button9.Name = "button9";
            this.button9.OwnDrawColor = System.Drawing.Color.White;
            this.button9.Size = new System.Drawing.Size(101, 69);
            this.button9.TabIndex = 16;
            this.button9.Text = "Sau";
            this.button9.UseOwnColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Color2 = System.Drawing.Color.CornflowerBlue;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(107, 530);
            this.button10.Name = "button10";
            this.button10.OwnDrawColor = System.Drawing.Color.White;
            this.button10.Size = new System.Drawing.Size(96, 69);
            this.button10.TabIndex = 17;
            this.button10.Text = "Tìm Kiếm";
            this.button10.UseOwnColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // FrmDept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 610);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmDept";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDept";
            this.Load += new System.EventHandler(this.FrmDept_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private WindowsFormsApplication4.Controls.CreTextBox txtDeptDesc;
        private WindowsFormsApplication4.Controls.CreTextBox txtDeptID;
        private WindowsFormsApplication4.Controls.CreComboBox cmbCate;
        private WindowsFormsApplication4.Controls.button button1;
        private WindowsFormsApplication4.Controls.button button2;
        private WindowsFormsApplication4.Controls.button button3;
        private WindowsFormsApplication4.Controls.button button4;
        private WindowsFormsApplication4.Controls.button button5;
        private WindowsFormsApplication4.Controls.button button7;
        private WindowsFormsApplication4.Controls.button button8;
        private WindowsFormsApplication4.Controls.button button9;
        private WindowsFormsApplication4.Controls.button button10;
        private WindowsFormsApplication4.Controls.CreTextBox creTextBox2;
        private WindowsFormsApplication4.Controls.CreTextBox creTextBox1;
        private System.Windows.Forms.CheckBox ckb_Sua;
    }
}