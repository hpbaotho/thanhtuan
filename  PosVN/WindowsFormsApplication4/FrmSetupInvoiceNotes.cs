using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Services;
using WindowsFormsApplication4.Controls;

namespace WindowsFormsApplication4
{
    public partial class FrmSetupInvoiceNotes : Form
    {
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private long m_lImageFileLength = 0;
        private byte[] m_barrImg;
        public FrmSetupInvoiceNotes()
        {
            InitializeComponent();
            openFileDialog1 = new OpenFileDialog();
        }

        private void FrmSetupInvoiceNotes_Load(object sender, EventArgs e)
        {
            Services.get_GUI get_GUI = new get_GUI();
            DataTable a =  get_GUI.GetSetupByStore(StaticClass.storeId);
            for (var i = 1; i < 10; i++)
            {
                this.tabControl1.TabPages[1].Controls["cretextbox" + i].Text = a.Rows[0][24+i].ToString();
            }
            textBox1.Text = a.Rows[0][34].ToString();
            try
            {
                byte[] barrImg = (byte[])a.Rows[0]["Logo"];
                string strfn = Convert.ToString(DateTime.Now.ToFileTime());
                FileStream fs = new FileStream(strfn, FileMode.CreateNew, FileAccess.Write);
                fs.Write(barrImg, 0, barrImg.Length);
                fs.Flush();
                fs.Close();

                pictureBox1.Image = Image.FromFile(strfn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Services.get_GUI get_GUI = new get_GUI();
            get_GUI.UpdateInvoiceNotes(StaticClass.storeId,creTextBox1.Text,creTextBox2.Text,creTextBox3.Text,creTextBox4.Text,creTextBox5.Text,creTextBox6.Text,creTextBox7.Text,creTextBox8.Text,creTextBox9.Text,textBox1.Text);
            get_GUI.UpdateLogo(m_barrImg,StaticClass.storeId);
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.ShowDialog();
            //if (openFileDialog.FileName != "")
            //{
            //    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            //}
            LoadImage();
        }
        protected void LoadImage()
        {

            try
            {
                this.openFileDialog1.ShowDialog();

                if (openFileDialog1.FileName != "")
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                    string strFn = this.openFileDialog1.FileName;
                    this.pictureBox1.Image = Image.FromFile(strFn);
                    FileInfo fiImage = new FileInfo(strFn);
                    this.m_lImageFileLength = fiImage.Length;
                    FileStream fs = new FileStream(strFn, FileMode.Open, FileAccess.Read, FileShare.Read);
                    m_barrImg = new byte[Convert.ToInt32(this.m_lImageFileLength)];
                    int iBytesRead = fs.Read(m_barrImg, 0, Convert.ToInt32(this.m_lImageFileLength));
                    fs.Close();
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadImage();
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            FrmKeyBoard frmKeyBoard = new FrmKeyBoard(textBox1.Text);
            if(frmKeyBoard.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = frmKeyBoard.value;
            }
        }
    }
}
