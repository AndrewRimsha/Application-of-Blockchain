using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACW3_Blockchain
{
    public partial class RequestForm : Form
    {
        public RequestForm()
        {
            InitializeComponent();
            tableLayoutPanel1.RowStyles[5].Height = 0;
            tableLayoutPanel1.RowStyles[6].Height = 0;
            tableLayoutPanel1.RowStyles[7].Height = 0;
            tableLayoutPanel1.RowStyles[8].Height = 0;
            tableLayoutPanel1.RowStyles[9].Height = 0;
            this.MinimumSize = new System.Drawing.Size(430, 220);
            this.Size = this.MinimumSize;
            numericUpDownMembersCount.ValueChanged += NumericUpDownMembersCount_ValueChanged;
            buttonSeparate.Click += ButtonSeparate_Click;
        }

        private void ButtonSeparate_Click(object sender, EventArgs e)
        {
            decimal separatedValue = numericUpDownTotalAmount.Value / numericUpDownMembersCount.Value;
            if (numericUpDownMembersCount.Value == 1)
            {
                numericUpDownFrom1.Value = numericUpDownTotalAmount.Value;
            }
            if (numericUpDownMembersCount.Value == 2)
            {
                numericUpDownFrom1.Value = numericUpDownTotalAmount.Value - Math.Round(separatedValue,6) * 1;
                numericUpDownFrom2.Value = separatedValue;
            }
            if (numericUpDownMembersCount.Value == 3)
            {
                numericUpDownFrom1.Value = numericUpDownTotalAmount.Value - Math.Round(separatedValue, 6) * 2;
                numericUpDownFrom2.Value = separatedValue;
                numericUpDownFrom3.Value = separatedValue;
            }
            if (numericUpDownMembersCount.Value == 4)
            {
                numericUpDownFrom1.Value = numericUpDownTotalAmount.Value - Math.Round(separatedValue, 6) * 3;
                numericUpDownFrom2.Value = separatedValue;
                numericUpDownFrom3.Value = separatedValue;
                numericUpDownFrom4.Value = separatedValue;
            }
            if (numericUpDownMembersCount.Value == 5)
            {
                numericUpDownFrom1.Value = numericUpDownTotalAmount.Value - Math.Round(separatedValue, 6) * 4;
                numericUpDownFrom2.Value = separatedValue;
                numericUpDownFrom3.Value = separatedValue;
                numericUpDownFrom4.Value = separatedValue;
                numericUpDownFrom5.Value = separatedValue;
            }
            if (numericUpDownMembersCount.Value == 6)
            {
                numericUpDownFrom1.Value = numericUpDownTotalAmount.Value - Math.Round(separatedValue, 6) * 5;
                numericUpDownFrom2.Value = separatedValue;
                numericUpDownFrom3.Value = separatedValue;
                numericUpDownFrom4.Value = separatedValue;
                numericUpDownFrom5.Value = separatedValue;
                numericUpDownFrom6.Value = separatedValue;
            }
        }

        private void NumericUpDownMembersCount_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownMembersCount.Value == 1)
            {
                tableLayoutPanel1.RowStyles[5].Height = 0;
                tableLayoutPanel1.RowStyles[6].Height = 0;
                tableLayoutPanel1.RowStyles[7].Height = 0;
                tableLayoutPanel1.RowStyles[8].Height = 0;
                tableLayoutPanel1.RowStyles[9].Height = 0;
                this.MinimumSize = new System.Drawing.Size(430, 220);
            }
            if (numericUpDownMembersCount.Value == 2)
            {
                tableLayoutPanel1.RowStyles[5].Height = 30;
                tableLayoutPanel1.RowStyles[6].Height = 0;
                tableLayoutPanel1.RowStyles[7].Height = 0;
                tableLayoutPanel1.RowStyles[8].Height = 0;
                tableLayoutPanel1.RowStyles[9].Height = 0;
                this.MinimumSize = new System.Drawing.Size(430, 220 + 1*30);
            }
            if (numericUpDownMembersCount.Value == 3)
            {
                tableLayoutPanel1.RowStyles[5].Height = 30;
                tableLayoutPanel1.RowStyles[6].Height = 30;
                tableLayoutPanel1.RowStyles[7].Height = 0;
                tableLayoutPanel1.RowStyles[8].Height = 0;
                tableLayoutPanel1.RowStyles[9].Height = 0;
                this.MinimumSize = new System.Drawing.Size(430, 220 + 2 * 30);
            }
            if (numericUpDownMembersCount.Value == 4)
            {
                tableLayoutPanel1.RowStyles[5].Height = 30;
                tableLayoutPanel1.RowStyles[6].Height = 30;
                tableLayoutPanel1.RowStyles[7].Height = 30;
                tableLayoutPanel1.RowStyles[8].Height = 0;
                tableLayoutPanel1.RowStyles[9].Height = 0;
                this.MinimumSize = new System.Drawing.Size(430, 220 + 3 * 30);
            }
            if (numericUpDownMembersCount.Value == 5)
            {
                tableLayoutPanel1.RowStyles[5].Height = 30;
                tableLayoutPanel1.RowStyles[6].Height = 30;
                tableLayoutPanel1.RowStyles[7].Height = 30;
                tableLayoutPanel1.RowStyles[8].Height = 30;
                tableLayoutPanel1.RowStyles[9].Height = 0;
                this.MinimumSize = new System.Drawing.Size(430, 220 + 4 * 30);
            }
            if (numericUpDownMembersCount.Value == 6)
            {
                tableLayoutPanel1.RowStyles[5].Height = 30;
                tableLayoutPanel1.RowStyles[6].Height = 30;
                tableLayoutPanel1.RowStyles[7].Height = 30;
                tableLayoutPanel1.RowStyles[8].Height = 30;
                tableLayoutPanel1.RowStyles[9].Height = 30;
                this.MinimumSize = new System.Drawing.Size(430, 220 + 5 * 30);
            }
            this.Size = this.MinimumSize;
        }
    }
}
