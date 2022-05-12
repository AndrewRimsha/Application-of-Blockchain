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
        DataGridView dataGridViewRequests;
        List<Dictionary<string, string>> requestList;
        string exponent;
        string privateKey;
        int requestID = 0;

        public RequestForm(string privateKeyLoad, string loginAddressFrom, string exponentFrom, List<string> addressesList, DataGridView dgvRequest, ref List<Dictionary<string, string>> requestListDictionary)
        {
            InitializeComponent();
            //addressesList.Add(loginAddressFrom);
            dataGridViewRequests = dgvRequest;
            requestList = requestListDictionary;
            privateKey = privateKeyLoad;
            exponent = exponentFrom;
            textBoxCreator.Text = loginAddressFrom;
            string[] arrayComboBoxTo = new string[addressesList.Count + 1];
            addressesList.CopyTo(arrayComboBoxTo);
            arrayComboBoxTo[addressesList.Count] = loginAddressFrom;
            string[] arrayComboBox1 = new string[addressesList.Count + 1];
            addressesList.CopyTo(arrayComboBox1);
            arrayComboBox1[addressesList.Count] = loginAddressFrom;
            string[] arrayComboBox2 = new string[addressesList.Count + 1];
            addressesList.CopyTo(arrayComboBox2);
            arrayComboBox2[addressesList.Count] = loginAddressFrom;
            string[] arrayComboBox3 = new string[addressesList.Count + 1];
            addressesList.CopyTo(arrayComboBox3);
            arrayComboBox3[addressesList.Count] = loginAddressFrom;
            string[] arrayComboBox4 = new string[addressesList.Count + 1];
            addressesList.CopyTo(arrayComboBox4);
            arrayComboBox4[addressesList.Count] = loginAddressFrom;
            string[] arrayComboBox5 = new string[addressesList.Count + 1];
            addressesList.CopyTo(arrayComboBox5);
            arrayComboBox5[addressesList.Count] = loginAddressFrom;
            string[] arrayComboBox6 = new string[addressesList.Count + 1];
            addressesList.CopyTo(arrayComboBox6);
            arrayComboBox6[addressesList.Count] = loginAddressFrom;
            comboBoxTo.DataSource = arrayComboBoxTo;
            comboBoxFrom1.DataSource = arrayComboBox1;
            comboBoxFrom2.DataSource = arrayComboBox2;
            comboBoxFrom3.DataSource = arrayComboBox3;
            comboBoxFrom4.DataSource = arrayComboBox4;
            comboBoxFrom5.DataSource = arrayComboBox5;
            comboBoxFrom6.DataSource = arrayComboBox6;
            for (int i = 0; i < requestList.Count; i++)
            {
                try
                {
                    int currentID = Convert.ToInt32(requestList[i]["id"]);
                    if (requestID < currentID)
                        requestID = currentID;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            tableLayoutPanel1.RowStyles[5].Height = 0;
            tableLayoutPanel1.RowStyles[6].Height = 0;
            tableLayoutPanel1.RowStyles[7].Height = 0;
            tableLayoutPanel1.RowStyles[8].Height = 0;
            tableLayoutPanel1.RowStyles[9].Height = 0;
            this.MinimumSize = new System.Drawing.Size(430, 220);
            this.Size = this.MinimumSize;
            numericUpDownMembersCount.ValueChanged += NumericUpDownMembersCount_ValueChanged;
            buttonSeparate.Click += ButtonSeparate_Click;
            buttonCreateRequest.Click += ButtonCreateRequest_Click;
            buttonCancel.Click += ButtonCancel_Click;
        }

        private void ButtonCreateRequest_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Create the request?", "Create?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                string dateOfTransaction = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if (numericUpDownMembersCount.Value >= 1)
                {
                    requestID++;
                    addRequest(requestID.ToString(), comboBoxFrom1.Text, numericUpDownFrom1.Value.ToString(), dateOfTransaction);
                }
                if (numericUpDownMembersCount.Value >= 2)
                {
                    requestID++;
                    addRequest(requestID.ToString(), comboBoxFrom2.Text, numericUpDownFrom2.Value.ToString(), dateOfTransaction);
                }
                if (numericUpDownMembersCount.Value >= 3)
                {
                    requestID++;
                    addRequest(requestID.ToString(), comboBoxFrom3.Text, numericUpDownFrom3.Value.ToString(), dateOfTransaction);
                }
                if (numericUpDownMembersCount.Value >= 4)
                {
                    requestID++;
                    addRequest(requestID.ToString(), comboBoxFrom4.Text, numericUpDownFrom4.Value.ToString(), dateOfTransaction);
                }
                if (numericUpDownMembersCount.Value >= 5)
                {
                    requestID++;
                    addRequest(requestID.ToString(), comboBoxFrom5.Text, numericUpDownFrom5.Value.ToString(), dateOfTransaction);
                }
                if (numericUpDownMembersCount.Value >= 6)
                {
                    requestID++;
                    addRequest(requestID.ToString(), comboBoxFrom6.Text, numericUpDownFrom6.Value.ToString(), dateOfTransaction);
                }
                ACW3_Blockchain.FillDataGridViewRequests(dataGridViewRequests);
                this.Close();
            }

        }

        void addRequest(string idRequest, string from, string amount, string dateOfTransaction)
        {
            Dictionary<string, string> request = new Dictionary<string, string>();
            string creator = textBoxCreator.Text;
            string description = textBoxDescription.Text;
            string to = comboBoxTo.Text;
            string sign = ACW3_Blockchain.SignRequest(privateKey, idRequest, creator, description, from,
                to, amount,dateOfTransaction,exponent);
            requestList.Add(request);
            request.Add("id", idRequest);
            request.Add("Creator", creator);
            request.Add("Description", description);
            request.Add("From", from);
            request.Add("To", to);
            request.Add("Amount", amount);
            request.Add("Date", dateOfTransaction);
            request.Add("Sign", sign);
            request.Add("Status", "Awaiting");
            request.Add("Exponent", exponent);
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
