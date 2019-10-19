using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {   
        public Form1()
        {
            InitializeComponent();
            InitPrintBox();
        }

        public enum Ua
        {
            URO,
            GLU,
            BIL,
            KET,
            SG,
            BLD,
            pH,
            PRO,
            NIT,
            LEU,
            ASA
        }
        public string[] urintPrint = new string[11];
        public string rbcPrint = "";
        public string wbcPrint = "";
        public int[] count = new int[10];

        public void InitCount()
        {
            for (int i = 0; i < count.Length; i++)
                count[i] = 0;
        }
        bool isStart = true;
        public void RefreshPrintBox()
        {
            CleanPrintBox();
            for (int i = 0; i < 10; i++)
            {
                if (count[i] == 0)
                {
                   urintPrint[i]="";
                }
                else if(urintPrint[i] != "")
                {
                    if (isStart) 
                    {
                        PrintBox.Text += urintPrint[i];
                        isStart = false;
                    }
                    else
                    PrintBox.Text += " , " + urintPrint[i]; }
            }
            if (rbcPrint == "")
                PrintBox.Text += wbcPrint;
            else 
            PrintBox.Text += rbcPrint +" , "+ wbcPrint;
            isStart =true;


            
        }
        private void CleanPrintBox() {
            PrintBox.Text = "";
            return;
        }
        #region BtnFunction
        //URO , GLU, BIL, 등 + 버튼
        private void UrineBtn_Click(object sender, EventArgs e)
        {
            InitBlood();
            var button = sender as Button;
            Ua buttonName = ((Ua)(Enum.Parse(typeof(Ua), button.Text)));
            if (count[(int)buttonName] < 0)
                count[(int)buttonName] = 0;
            count[(int)buttonName]++;
            if (count[(int)buttonName] < 2)
                urintPrint[(int)buttonName] = button.Text + " +";
            else urintPrint[(int)buttonName] += "+";

            RefreshPrintBox();
        }
        //URO , GLU, BIL, 등 +/- 버튼
        private void UrinePnBtn_Click(object sender, EventArgs e)
        {
            InitBlood();
            var button = sender as Button;
            Ua buttonName = ((Ua)(Enum.Parse(typeof(Ua), button.Name.Substring(0,3))));
            count[(int)buttonName]=-1;
           
           urintPrint[(int)buttonName] = buttonName.ToString() + " +/-";
           

            RefreshPrintBox();
        }
        //NIT 등 Pos. , Neg. Pos.만 적용
        private void PosBtn_Click(object sender, EventArgs e)
        {
            InitBlood();
            var button = sender as Button;
            Ua buttonName = ((Ua)(Enum.Parse(typeof(Ua), button.Text)));
            count[(int)buttonName]++;
            urintPrint[(int)buttonName] = button.Text+" pos.";
            RefreshPrintBox();
        }
        private void NormBtn_Click(object sender, EventArgs e)
        {
            InitBlood();
            InitCount();
            InitPrintBox();
            PrintBox.Text = "norm";

            if (PrintBox.Text != null)
                Clipboard.SetText(PrintBox.Text);
        }
        private void CopyBtn_Click(object sender, EventArgs e)
        {
            if (PrintBox.Text != null)
                Clipboard.SetText(PrintBox.Text);
        }

        private void BloodBtn_Click(object sender, EventArgs e)
        {
            InitCount();
            RefreshPrintBox();
            var button = sender as Button;
            if (button.Name.Substring(0, 3) == "Wbc")
            {
              
                    wbcPrint = "wbc : " + button.Text;
              

            }
            else rbcPrint = "rbc : " + button.Text;
            RefreshPrintBox();
        }
        private void InitBlood() 
        {
            wbcPrint = "";
            rbcPrint = "";
        }
        #endregion
        public void InitPrintBox() {
            wbcPrint = "";
            rbcPrint = "";
            for (int i = 0; i < 11; i++)
                urintPrint[i] = "";
            RefreshPrintBox();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            InitCount();
            InitPrintBox();
            RefreshPrintBox();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
