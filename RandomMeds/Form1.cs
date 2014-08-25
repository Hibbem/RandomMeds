using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomMeds
{
    public partial class Form1 : Form
    {
        public int outerLoop = 8;
        public int innerLoop = 10;
        private int raasOK = 0;
        private int raasNOT = 0;
        private int blockOK = 0;
        private int blockNOT = 0;
        private int teller = 0;
        private bool isGo = false;
        private bool isFailed = false;
        private List<String> defList = new List<string>();
        private List<String> strList = new List<string>();
        private List<String> exclList = new List<string>();
        private List<int> dbleBeta = new List<int>();
        private List<int> dbleRaas = new List<int>();
        private List<int> numberList = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            createLabels();
            createCheckBoxes();
            createNames();
            toolStripMenuItem5.Checked = true;
            numberList.Add(0);
        }

        private void Check_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            int nr = int.Parse(cb.Tag.ToString().Split(':')[0]);
            int rnd = int.Parse(cb.Tag.ToString().Split(':')[1]);
            if (cb.Checked == true && !isGo)
            {
                numberList.Add(nr);
                if (!exclList.Contains(cb.Tag.ToString()))
                {
                    exclList.Add(cb.Tag.ToString());
                }
                foreach (string s in exclList)
                {
                    int nrList = int.Parse(s.Split(':')[0]);
                    if (nrList == nr)
                    {
                        int rndList = int.Parse(s.Split(':')[1]);
                        switch (rndList)
                        {
                            case 1:
                                if (rnd == 2)
                                {
                                    dbleBeta.Add(nrList);
                                }
                                break;
                            case 2:
                                if (rnd == 1)
                                {
                                    dbleBeta.Add(nrList);
                                }

                                break;
                            case 3:
                                if (rnd == 4)
                                {
                                    dbleRaas.Add(nrList);
                                }
                                break;
                            case 4:
                                if (rnd == 3)
                                {
                                    dbleRaas.Add(nrList);
                                }
                                break;
                            default:
                                Console.WriteLine("Default case");
                                break;
                        }
                    }
                }
            }
            else if (!isGo)
            {
                exclList.Remove(cb.Tag.ToString());
            }
        }

        private void showBoxes()
        {
            //int max = numberList.Max() + 1;
            
            foreach (Control c in this.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    if (defList.Contains(cb.Tag.ToString()))
                    {
                        //int lastItem = numberList[numberList.Count - 1];
                        int currentNumber = int.Parse(cb.Tag.ToString().Split(':')[0]);
                        /*if ((dbleBeta.Contains(teller) || dbleRaas.Contains(teller)) && !isMaxed)
                        {
                            teller++;
                            break;
                            isMaxed = true;
                        }*/

                        if (int.Parse(cb.Tag.ToString().Split(':')[0]) <= (teller))
                        {
                            cb.Checked = true;

                        }
                        //defList.Add(cb.Tag.ToString());

                    }
                }
            }
            //strList.Clear();
            teller++;
        }
        private void updateTeller(int value)
        {
            if (value > teller)
            {
                teller = value;
            }
        }
        private void createNames()
        {
            int left = 90;
            int top = 33;
            for (int i = 0; i < 8; i++)
            {
                Label label = new Label();
                label.Left = left;
                label.Top = top;
                if ((i % 2) == 1)
                {
                    label.Text = "RAAS";
                    left += 120;
                }
                else
                {
                    label.Text = "Betablokker";
                    left += 80;
                }

                this.Controls.Add(label);
                label.BringToFront();

            }
        }
        private void createCheckBoxes()
        {

            int left = 100;
            int top = 55;
            for (int k = 0; k < 4; k++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    for (int i = 1; i <= 20; i++)
                    {
                        CheckBox ii = new CheckBox();
                        ii.AutoSize = false;
                        ii.Size = new System.Drawing.Size(17, 18);
                        ii.Name = "cbx" + i;
                        ii.Text = i.ToString();
                        ii.Location = new Point(left, top);
                        ii.Tag = ((20 * k) + i) + ":" + j; // Assuming you have your files in an array or similar
                        ii.CheckedChanged += new System.EventHandler(this.Check_CheckedChanged);
                        top += 25;
                        this.Controls.Add(ii);
                        ii.BringToFront();
                    }
                    top = 55;
                    if (j == 2)
                    {
                        left += 50;
                    }
                    else
                    {
                        left += 20;
                    }
                } left += 90;
            }
        }
        private void createLabels()
        {
            int top = 55;
            int left = 30;
            int nr = 1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Label label = new Label();
                    label.Left = left;
                    label.Top = top;
                    if (nr < 10) { label.Text = "STOP00" + nr; }
                    else
                    {
                        label.Text = "STOP0" + nr;
                    }
                    this.Controls.Add(label);
                    top += label.Height + 2;
                    nr++;
                }
                left += 200;
                top = 55;
            }
        }
        private void clearAll()
        {
            btnGo.Enabled = false;
            exclList.Clear();
            isGo = true;
            uncheckAll();
            isGo = false;
            defList.Clear();
            numberList.Clear();
            numberList.Add(0);
            teller = 0;
        }
        private void uncheckAll()
        {
            //numberList.Clear();
            raasOK = 0;
            raasNOT = 0;
            blockNOT = 0;
            blockOK = 0;
            foreach (Control c in this.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    //if ((!dbleBeta.Contains(int.Parse(c.Tag.ToString().Split(':')[0]))) && (!dbleRaas.Contains(int.Parse(c.Tag.ToString().Split(':')[0]))))
                    //{
                    cb.Checked = false;
                    //}
                }
            }
        }
        private void uncheckMenuItems()
        {
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
            toolStripMenuItem7.Checked = false;
            toolStripMenuItem8.Checked = false;
            toolStripMenuItem9.Checked = false;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (teller == 0)
            {
                teller++;
            }
            showBoxes();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            clearAll();
            dbleBeta.Clear();
            dbleRaas.Clear();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            //teller++;
            defList.Clear();
            //exclList.Sort();
            if (exclList.Count > 0)
            {
                teller = int.Parse(exclList[exclList.Count - 1].Split(':')[0]);
            }
            isGo = true;
            uncheckAll();
            int fails = 0;
            int nr = 0;
            Random rnd = new Random();
            for (int i = 1; i <= outerLoop; i++)
            {
                int tempROK = 0;
                int tempRNOT = 0;
                int tempBNOT = 0;
                int tempBOK = 0;
                bool neinBeta = false;
                bool neinRaas = false;
                List<String> dbles = new List<string>();
                for (int j = 1; j <= innerLoop; j++)
                {
                    nr++;
                    int rand1 = rnd.Next(1, 3);
                    int rand2 = rnd.Next(3, 5);
                    if (dbleBeta.Contains(nr))
                    {
                        neinBeta = true;
                        dbles.Add(nr + ":" + 1);
                        dbles.Add(nr + ":" + 2);
                    }
                    if (dbleRaas.Contains(nr))
                    {
                        dbles.Add(nr + ":" + 3);
                        dbles.Add(nr + ":" + 4);
                        neinRaas = true;
                    }
                    foreach (string s in exclList)
                    {
                        if (nr == int.Parse(s.Split(':')[0]))
                        {
                            int randVal = int.Parse(s.Split(':')[1]);
                            if (randVal > 2)
                            {
                                rand2 = randVal;
                            }
                            else
                            {
                                rand1 = randVal;
                            }
                        }
                    }
                    foreach (Control c in this.Controls)
                    {
                        if (c is CheckBox)
                        {
                            CheckBox cb = (CheckBox)c;
                            string tagString = cb.Tag.ToString();
                            if (cb.Tag.Equals(nr + ":" + rand1))
                            {
                                strList.Add(cb.Tag.ToString());
                                switch (rand1)
                                {
                                    case 1:
                                        tempBOK += 1;
                                        break;
                                    case 2:
                                        tempBNOT += 1;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }
                            }
                            if (cb.Tag.Equals(nr + ":" + rand2))
                            {
                                strList.Add(cb.Tag.ToString());
                                switch (rand2)
                                {
                                    case 3:
                                        tempROK += 1;
                                        break;
                                    case 4:
                                        tempRNOT += 1;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }
                            }
                        }
                    }

                }
                if (neinBeta)
                {
                    if (Math.Abs(tempBOK - tempBNOT) < 2)
                    {
                        tempBOK = tempBNOT;
                        strList.AddRange(dbles);
                    }
                }
                if (neinRaas)
                {
                    if (Math.Abs(tempROK - tempRNOT) < 2)
                    {
                        tempROK = tempRNOT;
                        strList.AddRange(dbles);
                    }
                }
                if ((tempBNOT != tempBOK) || (tempRNOT != tempROK))
                {
                    strList.Clear();
                    i--;
                    fails++;
                    tempRNOT = 0;
                    tempROK = 0;
                    tempBOK = 0;
                    tempBNOT = 0;
                    nr -= innerLoop;
                    if (fails > 5000)
                    {
                        MessageBox.Show("randomisatie kan niet worden voltooid");
                        isFailed = true;
                        fails = 0;
                        clearAll();
                        break;
                    }
                }
                else
                {
                    blockOK += tempBOK;
                    blockNOT += tempBNOT;
                    raasOK += tempROK;
                    raasNOT += tempRNOT;
                    lblBok.Text = "Betablokker OK: " + blockOK;
                    lblBnot.Text = "Betablokker NOT: " + blockNOT;
                    lblRok.Text = "Raas OK: " + raasOK;
                    lblRnot.Text = "Raas NOT: " + raasNOT;

                }foreach (Control c in this.Controls)
                    {
                        if (c is CheckBox)
                        {
                            CheckBox cb = (CheckBox)c;
                            if (strList.Contains(cb.Tag.ToString()))
                            {
                              defList.Add(cb.Tag.ToString());
                            }
                        }
                    }
                    strList.Clear();
                }
                isGo = false;
                defList.AddRange(strList);
                btnGo.Enabled = true;
                if (!isFailed)
                {
                    MessageBox.Show("Randomisatie voltooid");
                    showBoxes();
                } isFailed = false;
            }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            uncheckMenuItems();
            innerLoop = 4;
            outerLoop = 20;
            toolStripMenuItem2.Checked = true;

        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            uncheckMenuItems();
            innerLoop = 5;
            outerLoop = 16;
            toolStripMenuItem3.Checked = true;
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            uncheckMenuItems();
            innerLoop = 8;
            outerLoop = 10;
            toolStripMenuItem4.Checked = true;
        }
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            uncheckMenuItems();
            innerLoop = 10;
            outerLoop = 8;
            toolStripMenuItem5.Checked = true;
        }
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            uncheckMenuItems();
            innerLoop = 16;
            outerLoop = 5;
            toolStripMenuItem6.Checked = true;
        }
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            uncheckMenuItems();
            innerLoop = 20;
            outerLoop = 4;
            toolStripMenuItem7.Checked = true;
        }
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            uncheckMenuItems();
            innerLoop = 40;
            outerLoop = 2;
            toolStripMenuItem8.Checked = true;
        }
        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            uncheckMenuItems();
            innerLoop = 80;
            outerLoop = 1;
            toolStripMenuItem9.Checked = true;
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "AllOutput.rdm";
            save.Filter = "RandomMeds | *.rdm";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.OpenFile());
                foreach (string s in defList)
                {
                    writer.WriteLine(s);
                }
                writer.Dispose();
                writer.Close();
            }
        }
        private void personalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "PersonalOutput.rdm";
            save.Filter = "RandomMeds | *.rdm";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.OpenFile());
                foreach (string s in exclList)
                {
                    writer.WriteLine(s);
                }
                writer.Dispose();
                writer.Close();
            }
        }
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "RandomMeds|*.rdm";
            DialogResult result = open.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                StreamReader file = new StreamReader(open.FileName);
                string line;
                try
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        if (!exclList.Contains(line))
                        {
                            exclList.Add(line);
                            updateTeller(int.Parse(line.Split(':')[0]));
                        }
                    }
                    //isGo = true;
                    foreach (Control c in this.Controls)
                    {
                        if (c is CheckBox)
                        {
                            CheckBox cb = (CheckBox)c;
                            if (exclList.Contains(cb.Tag.ToString()))
                            {
                                cb.Checked = true;
                            }
                        }
                    } //isGo = false;
                }
                catch (IOException)
                {
                    MessageBox.Show("Er liep iet mis met het uitlezen..");
                }
            }
        }
        private void unloadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uncheckAll();
            exclList.Clear();
            defList.Clear();
        }

        private void showAll80ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    if (defList.Contains(cb.Tag.ToString()))
                    {
                        
                            cb.Checked = true;

                         //defList.Add(cb.Tag.ToString());

                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

       

        }
    }