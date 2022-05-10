﻿using System;
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
    public partial class SendMoney : Form
    {
        //string to;
        //string dateOfTransaction;
        string exponent;
        string lastBlock;
        string privateKey;
        DataGridView dataGridViewBlockchain;

        public SendMoney(string privateKeyLoad, string loginAddressFrom, string exponentFrom, string lastBlockHash, List<string> addressesList, DataGridView dgvBlockchain)
        {
            InitializeComponent();
            dataGridViewBlockchain = dgvBlockchain;
            comboBoxToAddress.DataSource = addressesList;
            textBoxLoginAddress.Text = loginAddressFrom;
            privateKey = privateKeyLoad;
            exponent = exponentFrom;
            lastBlock = lastBlockHash;
            buttonSend.Click += ButtonSend_Click;
            buttonCancel.Click += ButtonCancel_Click;
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            //textBoxLoginAddress.Text = loginAddressFrom;
            
            int blockID = Convert.ToInt32(dataGridViewBlockchain["id", dataGridViewBlockchain.RowCount - 1].Value) + 1;
            string dateOfTransaction = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string sign = ACW3_Blockchain.SignData(privateKey, blockID.ToString(), textBoxLoginAddress.Text, comboBoxToAddress.Text, numericUpDownAmount.Value.ToString(), dateOfTransaction, exponent, lastBlock);
            long nonce = ACW3_Blockchain.FindNonce(ACW3_Blockchain.ZeroCount, blockID.ToString(), textBoxLoginAddress.Text, comboBoxToAddress.Text, numericUpDownAmount.Value.ToString(), dateOfTransaction, exponent, lastBlock, sign);
            dataGridViewBlockchain.Rows.Add(blockID.ToString(), textBoxLoginAddress.Text, comboBoxToAddress.Text, numericUpDownAmount.Value.ToString(), dateOfTransaction, exponent, lastBlock, sign, nonce);
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}