namespace WindowsFormsApplication4
{
    partial class FrmCustomer
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtDateBirth = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblNumberOfAdd = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDateCloseAccount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDateOpenAccount = new System.Windows.Forms.TextBox();
            this.ckb_Sua = new System.Windows.Forms.CheckBox();
            this.btnNext = new WindowsFormsApplication4.Controls.button();
            this.btnSearch = new WindowsFormsApplication4.Controls.button();
            this.btnPrevious = new WindowsFormsApplication4.Controls.button();
            this.btnExit = new WindowsFormsApplication4.Controls.button();
            this.btnDeleteCustomer = new WindowsFormsApplication4.Controls.button();
            this.btnSaveCustomer = new WindowsFormsApplication4.Controls.button();
            this.btnAddCustomer = new WindowsFormsApplication4.Controls.button();
            this.txtDiscountPercent = new WindowsFormsApplication4.Controls.CreTextBox();
            this.txtNameCompany = new WindowsFormsApplication4.Controls.CreTextBox();
            this.txtDateCustomer = new WindowsFormsApplication4.Controls.CreTextBox();
            this.txtMobilephone = new WindowsFormsApplication4.Controls.CreTextBox();
            this.txtEmail = new WindowsFormsApplication4.Controls.CreTextBox();
            this.txtTelephone = new WindowsFormsApplication4.Controls.CreTextBox();
            this.txtAddress = new WindowsFormsApplication4.Controls.CreTextBox();
            this.txtMaxBalance = new WindowsFormsApplication4.Controls.CreTextBox();
            this.txtName = new WindowsFormsApplication4.Controls.CreTextBox();
            this.txtMaKH = new WindowsFormsApplication4.Controls.CreTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã khách hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(140, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên khách hàng";
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 115);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(720, 384);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Controls.Add(this.txtDateBirth);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtDiscountPercent);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtNameCompany);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtDateCustomer);
            this.tabPage1.Controls.Add(this.txtMobilephone);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtEmail);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtTelephone);
            this.tabPage1.Controls.Add(this.txtAddress);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(712, 348);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thông tin chung";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(359, 166);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 20);
            this.label16.TabIndex = 21;
            this.label16.Text = "Thẻ từ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(595, 272);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 66);
            this.button2.TabIndex = 20;
            this.button2.Text = "Xóa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(595, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 65);
            this.button1.TabIndex = 19;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(363, 194);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(225, 144);
            this.listBox1.TabIndex = 18;
            // 
            // txtDateBirth
            // 
            this.txtDateBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateBirth.Location = new System.Drawing.Point(501, 41);
            this.txtDateBirth.Name = "txtDateBirth";
            this.txtDateBirth.Size = new System.Drawing.Size(195, 26);
            this.txtDateBirth.TabIndex = 17;
            this.txtDateBirth.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtDateBirth_MouseDoubleClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(152, 244);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 24);
            this.label11.TabIndex = 16;
            this.label11.Text = "%";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 219);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 20);
            this.label10.TabIndex = 15;
            this.label10.Text = "Phần trăm khấu trừ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "Tên công ty";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(497, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Ngày tạo khách hàng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(287, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Số điện thoại di động";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(497, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ngày sinh";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(287, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Số điện thoại bàn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Địa chỉ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblNumberOfAdd);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.txtDateCloseAccount);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.txtDateOpenAccount);
            this.tabPage2.Controls.Add(this.txtMaxBalance);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(712, 348);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Thông tin tài khoản";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblNumberOfAdd
            // 
            this.lblNumberOfAdd.AutoSize = true;
            this.lblNumberOfAdd.Location = new System.Drawing.Point(500, 71);
            this.lblNumberOfAdd.Name = "lblNumberOfAdd";
            this.lblNumberOfAdd.Size = new System.Drawing.Size(67, 20);
            this.lblNumberOfAdd.TabIndex = 7;
            this.lblNumberOfAdd.Text = "label16";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(500, 42);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 20);
            this.label15.TabIndex = 6;
            this.label15.Text = "Số dư";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(238, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 20);
            this.label14.TabIndex = 5;
            this.label14.Text = "Max balance";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 103);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(154, 20);
            this.label13.TabIndex = 3;
            this.label13.Text = "Ngày đóng tài khoản";
            // 
            // txtDateCloseAccount
            // 
            this.txtDateCloseAccount.Location = new System.Drawing.Point(10, 126);
            this.txtDateCloseAccount.Name = "txtDateCloseAccount";
            this.txtDateCloseAccount.Size = new System.Drawing.Size(204, 26);
            this.txtDateCloseAccount.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 20);
            this.label12.TabIndex = 1;
            this.label12.Text = "Ngày mở tài khoản";
            // 
            // txtDateOpenAccount
            // 
            this.txtDateOpenAccount.Location = new System.Drawing.Point(10, 65);
            this.txtDateOpenAccount.Name = "txtDateOpenAccount";
            this.txtDateOpenAccount.Size = new System.Drawing.Size(204, 26);
            this.txtDateOpenAccount.TabIndex = 0;
            // 
            // ckb_Sua
            // 
            this.ckb_Sua.AutoSize = true;
            this.ckb_Sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckb_Sua.Location = new System.Drawing.Point(379, 76);
            this.ckb_Sua.Name = "ckb_Sua";
            this.ckb_Sua.Size = new System.Drawing.Size(57, 24);
            this.ckb_Sua.TabIndex = 50;
            this.ckb_Sua.Text = "Sửa";
            this.ckb_Sua.UseVisualStyleBackColor = true;
            this.ckb_Sua.CheckedChanged += new System.EventHandler(this.ckb_Sua_CheckedChanged);
            // 
            // btnNext
            // 
            this.btnNext.Color2 = System.Drawing.Color.Blue;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(222, 576);
            this.btnNext.Name = "btnNext";
            this.btnNext.OwnDrawColor = System.Drawing.Color.White;
            this.btnNext.Size = new System.Drawing.Size(112, 69);
            this.btnNext.TabIndex = 11;
            this.btnNext.Text = "Sau";
            this.btnNext.UseOwnColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Color2 = System.Drawing.Color.Blue;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(135, 576);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.OwnDrawColor = System.Drawing.Color.White;
            this.btnSearch.Size = new System.Drawing.Size(81, 69);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseOwnColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Color2 = System.Drawing.Color.Blue;
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(17, 576);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.OwnDrawColor = System.Drawing.Color.White;
            this.btnPrevious.Size = new System.Drawing.Size(112, 69);
            this.btnPrevious.TabIndex = 9;
            this.btnPrevious.Text = "Trước";
            this.btnPrevious.UseOwnColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnExit
            // 
            this.btnExit.Color2 = System.Drawing.Color.Orchid;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(584, 576);
            this.btnExit.Name = "btnExit";
            this.btnExit.OwnDrawColor = System.Drawing.Color.White;
            this.btnExit.Size = new System.Drawing.Size(145, 69);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseOwnColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.Color2 = System.Drawing.Color.Orchid;
            this.btnDeleteCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCustomer.Location = new System.Drawing.Point(584, 501);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.OwnDrawColor = System.Drawing.Color.White;
            this.btnDeleteCustomer.Size = new System.Drawing.Size(145, 69);
            this.btnDeleteCustomer.TabIndex = 7;
            this.btnDeleteCustomer.Text = "Xóa";
            this.btnDeleteCustomer.UseOwnColor = false;
            this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
            // 
            // btnSaveCustomer
            // 
            this.btnSaveCustomer.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSaveCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveCustomer.Location = new System.Drawing.Point(422, 576);
            this.btnSaveCustomer.Name = "btnSaveCustomer";
            this.btnSaveCustomer.OwnDrawColor = System.Drawing.Color.White;
            this.btnSaveCustomer.Size = new System.Drawing.Size(145, 69);
            this.btnSaveCustomer.TabIndex = 6;
            this.btnSaveCustomer.Text = "Lưu";
            this.btnSaveCustomer.UseOwnColor = false;
            this.btnSaveCustomer.Click += new System.EventHandler(this.btnSaveCustomer_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAddCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomer.Location = new System.Drawing.Point(422, 501);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.OwnDrawColor = System.Drawing.Color.White;
            this.btnAddCustomer.Size = new System.Drawing.Size(145, 69);
            this.btnAddCustomer.TabIndex = 5;
            this.btnAddCustomer.Text = "Thêm khách hàng";
            this.btnAddCustomer.UseOwnColor = false;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // txtDiscountPercent
            // 
            this.txtDiscountPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountPercent.Location = new System.Drawing.Point(5, 242);
            this.txtDiscountPercent.Name = "txtDiscountPercent";
            this.txtDiscountPercent.Size = new System.Drawing.Size(141, 26);
            this.txtDiscountPercent.TabIndex = 14;
            // 
            // txtNameCompany
            // 
            this.txtNameCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameCompany.Location = new System.Drawing.Point(6, 166);
            this.txtNameCompany.Name = "txtNameCompany";
            this.txtNameCompany.Size = new System.Drawing.Size(268, 26);
            this.txtNameCompany.TabIndex = 12;
            // 
            // txtDateCustomer
            // 
            this.txtDateCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateCustomer.Location = new System.Drawing.Point(501, 101);
            this.txtDateCustomer.Name = "txtDateCustomer";
            this.txtDateCustomer.ReadOnly = true;
            this.txtDateCustomer.Size = new System.Drawing.Size(195, 26);
            this.txtDateCustomer.TabIndex = 9;
            // 
            // txtMobilephone
            // 
            this.txtMobilephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobilephone.Location = new System.Drawing.Point(291, 101);
            this.txtMobilephone.Name = "txtMobilephone";
            this.txtMobilephone.Size = new System.Drawing.Size(195, 26);
            this.txtMobilephone.TabIndex = 8;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(6, 101);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(268, 26);
            this.txtEmail.TabIndex = 6;
            // 
            // txtTelephone
            // 
            this.txtTelephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelephone.Location = new System.Drawing.Point(291, 40);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(195, 26);
            this.txtTelephone.TabIndex = 1;
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(6, 40);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(268, 26);
            this.txtAddress.TabIndex = 0;
            // 
            // txtMaxBalance
            // 
            this.txtMaxBalance.Location = new System.Drawing.Point(242, 65);
            this.txtMaxBalance.Name = "txtMaxBalance";
            this.txtMaxBalance.Size = new System.Drawing.Size(190, 26);
            this.txtMaxBalance.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(144, 71);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(208, 29);
            this.txtName.TabIndex = 1;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaKH.Location = new System.Drawing.Point(12, 71);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(100, 29);
            this.txtMaKH.TabIndex = 0;
            // 
            // FrmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 659);
            this.ControlBox = false;
            this.Controls.Add(this.ckb_Sua);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDeleteCustomer);
            this.Controls.Add(this.btnSaveCustomer);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtMaKH);
            this.Name = "FrmCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khách hàng";
            this.Load += new System.EventHandler(this.FrmCustomer_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowsFormsApplication4.Controls.CreTextBox txtMaKH;
        private WindowsFormsApplication4.Controls.CreTextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private WindowsFormsApplication4.Controls.CreTextBox txtTelephone;
        private WindowsFormsApplication4.Controls.CreTextBox txtAddress;
        private System.Windows.Forms.Label label10;
        private WindowsFormsApplication4.Controls.CreTextBox txtDiscountPercent;
        private System.Windows.Forms.Label label9;
        private WindowsFormsApplication4.Controls.CreTextBox txtNameCompany;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private WindowsFormsApplication4.Controls.CreTextBox txtDateCustomer;
        private WindowsFormsApplication4.Controls.CreTextBox txtMobilephone;
        private System.Windows.Forms.Label label6;
        private WindowsFormsApplication4.Controls.CreTextBox txtEmail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDateBirth;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDateCloseAccount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDateOpenAccount;
        private System.Windows.Forms.Label label14;
        private WindowsFormsApplication4.Controls.CreTextBox txtMaxBalance;
        private WindowsFormsApplication4.Controls.button btnAddCustomer;
        private WindowsFormsApplication4.Controls.button btnSaveCustomer;
        private WindowsFormsApplication4.Controls.button btnDeleteCustomer;
        private WindowsFormsApplication4.Controls.button btnExit;
        private WindowsFormsApplication4.Controls.button btnPrevious;
        private WindowsFormsApplication4.Controls.button btnSearch;
        private WindowsFormsApplication4.Controls.button btnNext;
        private System.Windows.Forms.Label lblNumberOfAdd;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox ckb_Sua;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label16;
    }
}