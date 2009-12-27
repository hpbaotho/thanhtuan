using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Services;
using WindowsFormsApplication4.Controls;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4
{
    public partial class FrmEditLayout : FrmPOS
    {
        public Hashtable listPanel = new Hashtable();
        private int pageIndex;
        private int pageNum;
        private ArrayList buttonKhu;
        private int selectedSection;
        private ArrayList sections;
        public ServiceGet serviceGet;
        public get_GUI getGui;
        public FrmLayout formLayout;

        public FrmEditLayout()
        {
            pageIndex = 1;
            selectedSection = 1;
            InitializeComponent();
            getGui = new get_GUI();
            sections = new ArrayList();
            buttonKhu = new ArrayList();
            buttonKhu.Add(button10);
            buttonKhu.Add(button11);
            buttonKhu.Add(button22);
            buttonKhu.Add(button23);

            but_AddSec.changeColor(Color.White,Color.Green);
            button17.changeColor(Color.White, Color.LightSkyBlue);
            button13.changeColor(Color.White, Color.Orange);
            button14.changeColor(Color.White, Color.Orange);
            button15.changeColor(Color.White, Color.Orange);
            button16.changeColor(Color.White, Color.Red);
            button21.changeColor(Color.White, Color.Red);

            but_Done.changeColor(Color.White, Color.DimGray);
            but_Cancel.changeColor(Color.White, Color.DimGray);
        }

        private void FrmEditLayout_Load(object sender, EventArgs e)
        {
            //ArrayList a = new ArrayList();
            //a.Add(new MyButton(100,100,50,50));

            //ArrayList b = new ArrayList();
            //b.Add(new MyButton(200, 200, 100, 100));

            //ArrayList c = new ArrayList();
            //c.Add(new MyButton(200, 200, 100, 100));

            //ArrayList d = new ArrayList();
            //d.Add(new MyButton(200, 200, 100, 100));

            //ArrayList f = new ArrayList();
            //f.Add(new MyButton(200, 200, 100, 100));


            //listPanel.Add("khu 1", new panel("khu 1"));
            //listPanel.Add("khu 2", new panel(b, "khu 2"));
            //listPanel.Add("khu 3", new panel(c, "khu 3"));
            //listPanel.Add("khu 4", new panel(d, "khu 4"));
            //listPanel.Add("khu 5", new panel(f, "khu 5"));

            //sections.Add("khu 1");
            //sections.Add("khu 2");
            //sections.Add("khu 3");
            //sections.Add("khu 4");
            //sections.Add("khu 5");

            //this.Controls.Add((panel)listPanel["khu 1"]);
            //this.Controls.Add((panel)listPanel["khu 2"]);
            //this.Controls.Add((panel)listPanel["khu 3"]);
            //this.Controls.Add((panel)listPanel["khu 4"]);
            //this.Controls.Add((panel)listPanel["khu 5"]);

            serviceGet = new ServiceGet();
            DataTable sectionList = serviceGet.getSections("1001");
            for (int i = 0; i < sectionList.Rows.Count; i++)
            {
                string sectionName = sectionList.Rows[i][1].ToString();
                ArrayList buttons = serviceGet.getTablesEdit("1001", sectionName);
                Color color1 = Color.FromArgb((int) sectionList.Rows[i][2]);
                Color color2 = Color.FromArgb((int)sectionList.Rows[i][3]);
                
                listPanel.Add(sectionName, new panel(buttons,sectionName,color1,color2));
                sections.Add(sectionName);
                if(buttons.Count != 0)
                {
                    ((panel) listPanel[sectionName]).colorBar3.color_prop = ((MyButton) buttons[0]).borColor;
                }
                
                this.Controls.Add((panel)listPanel[sectionName]);
            }

            button10.changeColor(Color.White, Color.Red);
            pageIndex = 1;
            selectedSection = 1;

            if (listPanel.Count % 4 == 0)
            {
                pageNum = listPanel.Count / 4;
            }
            else
            {
                pageNum = listPanel.Count / 4 + 1; 
            }

            int x;
            if (pageIndex * 4 <= listPanel.Count)
            {
                x = 4;
            }
            else
            {
                x = listPanel.Count % 4;
            }

            changeColorButton(x);
            checkInvisible();
        }


        public void checkInvisible()
        {
            if(pageIndex *4  <= listPanel.Count)
            {
                button10.Visible = true;
                button11.Visible = true;
                button22.Visible = true;
                button23.Visible = true;
            }
            else
            {
                int i = listPanel.Count%4;
                switch (i)
                {
                    case 1:
                        button10.Visible = true;
                        button11.Visible = false;
                        button22.Visible = false;
                        button23.Visible = false;
                        break;
                    case 2:
                        button10.Visible = true;
                        button11.Visible = true;
                        button22.Visible = false;
                        button23.Visible = false;
                        break;
                    case 3:
                        button10.Visible = true;
                        button11.Visible = true;
                        button22.Visible = true;
                        button23.Visible = false;
                        break;
                }
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            button10.changeColor(Color.White, Color.Red);
            button11.changeColor(Color.White, Color.Blue);
            button22.changeColor(Color.White, Color.Blue);
            button23.changeColor(Color.White, Color.Blue);
            ((panel)listPanel[button10.Text]).BringToFront();
            but_Done.BringToFront();
            but_Cancel.BringToFront();
            selectedSection = (pageIndex - 1)*4 + 1;
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button10.changeColor(Color.White, Color.Blue);
            button11.changeColor(Color.White, Color.Red);
            button22.changeColor(Color.White, Color.Blue);
            button23.changeColor(Color.White, Color.Blue);
            ((panel)listPanel[button11.Text]).BringToFront();
            but_Done.BringToFront();
            but_Cancel.BringToFront();
            selectedSection = (pageIndex - 1) * 4 + 2;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            button10.changeColor(Color.White, Color.Blue);
            button11.changeColor(Color.White, Color.Blue);
            button22.changeColor(Color.White, Color.Red);
            button23.changeColor(Color.White, Color.Blue);
            ((panel)listPanel[button22.Text]).BringToFront();
            but_Done.BringToFront();
            but_Cancel.BringToFront();
            selectedSection = (pageIndex - 1) * 4 + 3;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            button10.changeColor(Color.White, Color.Blue);
            button11.changeColor(Color.White, Color.Blue);
            button22.changeColor(Color.White, Color.Blue);
            button23.changeColor(Color.White, Color.Red);
            ((panel)listPanel[button23.Text]).BringToFront();
            but_Done.BringToFront();
            but_Cancel.BringToFront();
            selectedSection = (pageIndex - 1) * 4 + 4;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(pageNum > pageIndex)
            {
                pageIndex += 1;
                checkInvisible();
                int x;
                if(pageIndex * 4 <= listPanel.Count)
                {
                    x = 4;
                }
                else
                {
                    x = listPanel.Count%4;
                }

                for (int i = 1; i <= x; i++ )
                {
                    button tmp = (button) buttonKhu[i - 1];
                    tmp.Text = sections[(pageIndex - 1) * 4 + i - 1].ToString();
                    tmp.Visible = true;
                    if((pageIndex-1)*4 + i  == selectedSection )
                    {
                        tmp.changeColor(Color.White, Color.Red);
                    }
                    else
                    {
                        tmp.changeColor(Color.White, Color.Blue);
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(pageIndex != 1)
            {
                pageIndex -= 1;
                checkInvisible();
                int x;
                if (pageIndex * 4 <= listPanel.Count)
                {
                    x = 4;
                }
                else
                {
                    x = listPanel.Count % 4;
                }

                changeColorButton(x);
            }
        }


        private void changeColorButton(int x)
        {
            for (int i = 1; i <= x; i++)
            {
                button tmp = (button)buttonKhu[i - 1];
                tmp.Text = sections[(pageIndex - 1) * 4 + i - 1].ToString();
                tmp.Visible = true;
                if ((pageIndex - 1) * 4 + i == selectedSection)
                {
                    tmp.changeColor(Color.White, Color.Red);
                }
                else
                {
                    tmp.changeColor(Color.White, Color.Blue);
                }
            }
        }

        private void but_AddSec_Click(object sender, EventArgs e)
        {
            Form2 a = new Form2();
            if(a.ShowDialog() == DialogResult.OK)
            {
                string secName = a.text;
                listPanel.Add(secName, new panel(secName));
                sections.Add(secName);
                this.Controls.Add((panel)listPanel[secName]);
                ((panel) listPanel[secName]).isNew = true;
                selectedSection = listPanel.Count;
                
                int x;
                if (listPanel.Count % 4 == 0)
                {
                    pageNum = listPanel.Count / 4;
                    x = 4;
                }
                else
                {
                    pageNum = listPanel.Count / 4 + 1;
                    x = listPanel.Count%4;
                }
                pageIndex = pageNum;
                changeColorButton(x);
                checkInvisible();
                ((panel)listPanel[secName]).BringToFront();
                but_Done.BringToFront();
                but_Cancel.BringToFront();
            }

            

        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            var a = new FrmKeyBoard();
            if(a.ShowDialog() == DialogResult.OK)
            {
                var tmp = (panel)listPanel[sections[selectedSection - 1]];
                var tmpBut = new MyButton(100,100,100,100,MyButton.ButtonStyles.Rectangle);
                tmpBut.Text_pro = a.value;
                tmp.isNew = true;
                tmp.addButton(tmpBut);
            }
            
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var a = new FrmKeyBoard();
            if (a.ShowDialog() == DialogResult.OK)
            {
                var tmp = (panel)listPanel[sections[selectedSection - 1]];
                var tmpBut = new MyButton(100, 100, 100, 100, MyButton.ButtonStyles.Ellipse);
                tmpBut.Text_pro = a.value;
                tmpBut.isNew = true;
                tmp.addButton(tmpBut);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var a = new FrmKeyBoard();
            if (a.ShowDialog() == DialogResult.OK)
            {
                var tmp = (panel)listPanel[sections[selectedSection - 1]];
                var tmpBut = new MyButton(100, 100, 100, 100, MyButton.ButtonStyles.Rectangle);
                tmpBut.Text_pro = a.value;
                tmp.addButton(tmpBut);
            }
        }

        private void but_Done_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < sections.Count; i++)
            {
                var tmp = (panel)listPanel[sections[i]];
                if(tmp.isNew == false)
                {
                    if(tmp.isDelete == false)
                    {
                        getGui.UpdateSection(tmp.txtSection.Text, tmp.colorBar1.color_prop.ToArgb().ToString(), tmp.colorBar2.color_prop.ToArgb().ToString(), "1001", tmp.Text);
                        foreach (MyButton o in tmp.mangMyButton)
                        {
                            string style;
                            if (o.ButtonStyle == MyButton.ButtonStyles.Ellipse)
                            {
                                style = "2";
                            }
                            else
                            {
                                style = "0";
                            }
                            if(o.isNew == false)
                            {
                                if(o.isDelete == false)
                                {
                                    getGui.UpdateTable("1001", tmp.txtSection.Text, o.Text_pro, style, o.Left.ToString(), o.Top.ToString(), o.Height.ToString(), o.Width.ToString(), "0", "0", "false", "", tmp.colorBar3.color_prop.ToArgb().ToString(), "-16777216");
                                }
                                else
                                {
                                    getGui.DeleteTableDiagram("1001",tmp.txtSection.Text,o.Text_pro);
                                }   
                            }
                            else
                            {
                                if(o.isDelete == false)
                                {
                                    getGui.InsertTableDiagram("1001", tmp.txtSection.Text, o.Text_pro, style, o.Left.ToString(), o.Top.ToString(), o.Height.ToString(), o.Width.ToString(), "0", "0", "0", "false", "", tmp.colorBar3.color_prop.ToArgb().ToString(), "-16777216");
                                }
                                
                            }                   
                        }
                    }
                    else
                    {
                        getGui.DeleteSection("1001",tmp.Text);
                    }
                    
                }
                else
                {
                    if(tmp.isDelete == false)
                    {
                        getGui.InsertSection("1001", tmp.txtSection.Text, tmp.colorBar1.color_prop.ToArgb().ToString(), tmp.colorBar2.color_prop.ToArgb().ToString());
                        foreach (MyButton o in tmp.mangMyButton)
                        {
                            string style;
                            if (o.ButtonStyle == MyButton.ButtonStyles.Ellipse)
                            {
                                style = "2";
                            }
                            else
                            {
                                style = "0";
                            }
                            getGui.InsertTableDiagram("1001", tmp.txtSection.Text, o.Text_pro, style, o.Left.ToString(), o.Top.ToString(), o.Height.ToString(), o.Width.ToString(), "0", "0", "0", "false", "", tmp.colorBar3.color_prop.ToArgb().ToString(), "-16777216");
                        }
                    }  
                }
                
                
            }
            for (int i = 0; i < formLayout.sections.Count; i++)
            {
                var tmp = (PanelLayout)formLayout.listPanel[formLayout.sections[i].ToString()];
                tmp.Dispose();
            }
            formLayout.FrmLayout_Load(null,null);
            this.Dispose();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            var tmp = (panel)listPanel[sections[selectedSection - 1]];
            tmp.isDelete = true;
            foreach (MyButton o in tmp.mangMyButton)
            {
                o.Visible = false;
            }
            Label thongBao = new Label();

            thongBao.Location = new Point(350, 300);
            thongBao.Size = new Size(300, 25);
            thongBao.Font = new Font("Arial", 15);
            thongBao.Text = "Phòng này sẽ bị xóa !";
            thongBao.BackColor = Color.Red;
            tmp.Controls.Add(thongBao);
            //thongBao.Size = new Size();
            tmp.Refresh();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            var tmp = (panel)listPanel[sections[selectedSection - 1]];
            if(tmp.selectedButton != null)
            {
                FrmDelete frmDelete = new FrmDelete();
                if(frmDelete.ShowDialog() == DialogResult.OK)
                {
                    tmp.selectedButton.Visible = false;
                    tmp.selectedButton.isDelete = true;
                    tmp.Focus();
                    tmp.panelEditButton.Visible = false;
                    tmp.panelEditSection.Visible = true;
                    tmp.selectedButton = null;
                }             
            }
            else
            {
                MessageBox.Show("Hãy chọn 1 bàn để xóa !");
            }
        }

        
    }
}
