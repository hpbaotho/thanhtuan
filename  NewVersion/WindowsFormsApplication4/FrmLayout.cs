using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication4.Controls;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4
{
    public partial class FrmLayout : FrmPOS
    {
        public Hashtable listPanel = new Hashtable();
        private int pageIndex;
        private int pageNum;
        private int selectedSection;
        public ArrayList sections;
        public FrmLogin formLogin;
        public FrmEditLayout formEditLayout;
        public ServiceGet serviceGet = new ServiceGet();
        public bool isTransfer = false;
        public FrmBanHang formBanHang; // Xu ly transfer
        private static FrmLayout  m_Instance;

        public static FrmLayout GetInstance()
        {
            if (m_Instance == null)
                m_Instance = new FrmLayout();
            return m_Instance;
        }
        public static bool isInstance()
        {
            if (m_Instance == null)
                return false;
            return true;
        }
        public FrmLayout()
        {
            InitializeComponent();
            pageIndex = 1;
            selectedSection = 0;
            sections = new ArrayList();
            m_Instance = this;
            for (int i = 1; i < 8; i++)
            {
                sections.Add(i.ToString());
                ArrayList tmp = new ArrayList();
                button aa = new button(100,100,50,50);
                aa.Text = i.ToString();
                tmp.Add(aa);
                PanelLayout panel = new PanelLayout(tmp,i.ToString());
                listPanel.Add(i.ToString(),panel);
                this.Controls.Add((PanelLayout)listPanel[i.ToString()]);
            }
        }
        public FrmLayout(string userName)
        {
            m_Instance = this;
            InitializeComponent();
            label1.Text = userName;
            pageIndex = 1;
            selectedSection = 0;
           
        }

        public void FrmLayout_Load(object sender, EventArgs e)
        {
         
            
            button1.changeColor(Color.White,Color.Red);
            button2.changeColor(Color.White,Color.DimGray);
            button3.changeColor(Color.White, Color.DimGray);
            if(sections != null)
            {
                for (int i = 0; i < sections.Count; i++)
                {
                    ((PanelLayout)listPanel[sections[i].ToString()]).Dispose();
                }
                //sections.Clear();
                sections = null;
            }
            sections = new ArrayList(); 
            //listPanel.Clear();
            listPanel = null;
            System.GC.Collect();
            listPanel = new Hashtable();
            DataTable sectionList = serviceGet.getSections("1001");
            for (int i = 0; i < sectionList.Rows.Count; i++)
            {
                string sectionName = sectionList.Rows[i][1].ToString();
                sections.Add(sectionName);
                ArrayList tmp = new ArrayList();
                tmp = serviceGet.getTables("1001", sectionName);

                //Int64 a = (Int64)sectionList.Rows[i][2];
                Color color1 = Color.FromArgb((int)sectionList.Rows[i][2]);
                Color color2 = Color.FromArgb((int)sectionList.Rows[i][3]);
                PanelLayout panel = new PanelLayout(sectionName, tmp, color1, color2,isTransfer);
                listPanel.Add(sectionName, panel);
                this.Controls.Add((PanelLayout)listPanel[sectionName]);
            }
            if(isTransfer)
            {
                button1.Text = "Quay về";
                for (int i = 2; i < 8; i++)
                {
                    var tmp = (button)panel4.Controls["button" + i.ToString()];
                    //tmp.changeColor(Color.White,Color.LightGray);
                    tmp.Enabled = false;
                }
            }


            
            if (listPanel.Count % 4 == 0)
            {
                pageNum = listPanel.Count / 4;
            }
            else
            {
                pageNum = listPanel.Count / 4 + 1;
            }
            for (int i = 10; i < 14; i++)
            {
                var tmp = (button)panel3.Controls["button" + i.ToString()];
                //tmp.changeColor(Color.White,Color.LightGray);
                tmp.Click += new EventHandler(tmp_Click);
            }
            LoadSectionButton();
            var tmppanel = (PanelLayout)listPanel[sections[selectedSection].ToString()];
            tmppanel.BringToFront();
            this.Refresh();
        }

        void tmp_Click(object sender, EventArgs e)
        {
            var tmp = (button) sender;
            var txt = tmp.Name.Substring(7, 1);
            selectedSection = (pageIndex - 1)*4 + Convert.ToInt32(txt);
            for (int i = 10; i < 14; i++)
            {
                var tmp1 = (button)panel3.Controls["button" + i.ToString()];
                tmp1.changeColor(Color.White, Color.Gray);
            }
            tmp.changeColor(Color.White,Color.Red);
            var panel = (PanelLayout) listPanel[tmp.Text];
            panel.BringToFront();
            
        }


        public void LoadSectionButton()
        {
            for (int i = (pageIndex-1)*4; i < pageIndex*4 ; i++)
            {
                var tmp = (button)panel3.Controls["button" + (i -(pageIndex-1)*4 + 10).ToString()];
                if(i < listPanel.Count)
                {
                    tmp.Text = sections[i].ToString();
                    tmp.Visible = true;
                }
                else
                {
                    tmp.Visible = false;
                }
                if(i == selectedSection)
                {
                    tmp.changeColor(Color.White,Color.Red);
                }
                else
                {
                    tmp.changeColor(Color.White, Color.Gray);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (pageIndex < pageNum)
            {
                pageIndex++;
                LoadSectionButton();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(pageIndex > 1)
            {
                pageIndex--;
                LoadSectionButton();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!isTransfer)
            {
                formLogin.DisposeLogin();
                formLogin.FrmLogin_Load(null,null);
            }
            //formLogin.Dispose();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmAdminPass adminPass = new FrmAdminPass();
            if(adminPass.ShowDialog() == DialogResult.OK)
            {
                if(serviceGet.checkAdminPass(adminPass.text,"1001"))
                {
                    formEditLayout = new FrmEditLayout();
                    formEditLayout.formLayout = this;
                    formEditLayout.ShowDialog();
                }
                else
                {
                    Alert.Show("Bạn đã nhập sai \nmật khẩu !",Color.Red);
                }           
            }


            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmManager frmManager = new FrmManager();
            frmManager.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.FrmLayout_Load(null,null);
        }
        public delegate void RefreshFormDelegate();
        public void RefreshForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new RefreshFormDelegate(RefreshForm));
            }
            else
            {
                this.FrmLayout_Load(null, null);
            }


        }

        private void button10_Click(object sender, EventArgs e)
        {

        }
    }
}
