using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ACW3_Blockchain
{
    public partial class ACW3_Blockchain : Form
    {
        static string loginAddressFrom;
        string exponentFrom;
        public static int ZeroCount = 4;
        //string filenamePrivateKeyXml;    //remove!
        string privateKeyLoad;
        string nameString;
        decimal balance;
        List<string> addressessList = new List<string>();
        List<Dictionary<string, string>> blockList = new List<Dictionary<string, string>>();
        static List<Dictionary<string, string>> requestList = new List<Dictionary<string, string>>();
        public ACW3_Blockchain(string privateKeyString)
        {
            InitializeComponent();
            balance = 0;
            privateKeyLoad = privateKeyString;
            nameString = getPublicKeyString(privateKeyString, "Name");
            loginAddressFrom = getPublicKeyString(privateKeyString, "Modulus");
            exponentFrom = getPublicKeyString(privateKeyString, "Exponent");
            labelPublicID.Text = loginAddressFrom;
            labelName.Text = string.Format("Name: {0}", nameString);
            labelBalance.Text = string.Format("Balance: {0}", balance);
            changeDataGridView(ref dataGridViewBlockchain);
            dataGridViewBlockchain.Columns.Add("id", "id");
            dataGridViewBlockchain.Columns["id"].Width = 25;
            dataGridViewBlockchain.Columns.Add("From", "From");
            dataGridViewBlockchain.Columns["From"].Width = 120;
            dataGridViewBlockchain.Columns.Add("To", "To");
            dataGridViewBlockchain.Columns["To"].Width = 120;
            dataGridViewBlockchain.Columns.Add("Amount", "Amount");
            dataGridViewBlockchain.Columns["Amount"].Width = 50;
            dataGridViewBlockchain.Columns.Add("Date", "Date");
            dataGridViewBlockchain.Columns["Date"].Width = 110;
            dataGridViewBlockchain.Columns.Add("Exponent", "Exponent");
            //dataGridViewBlockchain.Columns["Exponent"].Width = 60;
            dataGridViewBlockchain.Columns["Exponent"].Visible = false;
            dataGridViewBlockchain.Columns.Add("PreviousHash", "PreviousHash");
            dataGridViewBlockchain.Columns["PreviousHash"].Width = 120;
            dataGridViewBlockchain.Columns.Add("Sign", "Sign");
            dataGridViewBlockchain.Columns["Sign"].Width = 120;
            dataGridViewBlockchain.Columns.Add("Nonce", "Nonce");
            dataGridViewBlockchain.Columns["Nonce"].Width = 50;
            dataGridViewBlockchain.MouseClick += DataGridViewBlockchain_MouseClick;
            dataGridViewBlockchain.SortCompare += DataGridViewBlockchain_SortCompare;

            changeDataGridView(ref dataGridViewRequests);
            dataGridViewRequests.Columns.Add("id", "id");
            dataGridViewRequests.Columns["id"].Width = 25;
            dataGridViewRequests.Columns.Add("Creator", "Creator");
            dataGridViewRequests.Columns["Creator"].Width = 90;
            dataGridViewRequests.Columns.Add("Description", "Description");
            dataGridViewRequests.Columns["Description"].Width = 80;
            dataGridViewRequests.Columns.Add("From", "From");
            dataGridViewRequests.Columns["From"].Width = 90;
            dataGridViewRequests.Columns.Add("To", "To");
            dataGridViewRequests.Columns["To"].Width = 90;
            dataGridViewRequests.Columns.Add("Amount", "Amount");
            dataGridViewRequests.Columns["Amount"].Width = 50;
            dataGridViewRequests.Columns.Add("Date", "Date");
            dataGridViewRequests.Columns["Date"].Width = 110;
            dataGridViewRequests.Columns.Add("Sign", "Sign");
            dataGridViewRequests.Columns["Sign"].Width = 80;
            dataGridViewRequests.Columns.Add("Status", "Status");
            //dataGridViewRequests.Columns["Status"].Width = 50;
            dataGridViewRequests.Columns["Status"].Visible = false;
            dataGridViewRequests.Columns.Add("Exponent", "Exponent");
            dataGridViewRequests.Columns["Exponent"].Visible = false;
            DataGridViewButtonColumn dataGridViewButtonColumnAccept = new DataGridViewButtonColumn();
            dataGridViewButtonColumnAccept.Text = "Accept";
            dataGridViewButtonColumnAccept.UseColumnTextForButtonValue = true;
            dataGridViewButtonColumnAccept.Width = 50;
            dataGridViewButtonColumnAccept.Name = "Accept";
            //dataGridViewButtonColumnAccept.DataPropertyName = "Accept";
            dataGridViewButtonColumnAccept.ReadOnly = true;
            dataGridViewRequests.Columns.Add(dataGridViewButtonColumnAccept);
            DataGridViewButtonColumn dataGridViewButtonColumnReject = new DataGridViewButtonColumn();
            dataGridViewButtonColumnReject.Text = "Reject";
            dataGridViewButtonColumnReject.UseColumnTextForButtonValue = true;
            dataGridViewButtonColumnReject.Width = 50;
            dataGridViewButtonColumnReject.Name = "Reject";
            //dataGridViewButtonColumnReject.DataPropertyName = "Reject";
            dataGridViewButtonColumnReject.ReadOnly = true;
            dataGridViewRequests.Columns.Add(dataGridViewButtonColumnReject);
            dataGridViewRequests.CellContentClick += DataGridViewRequests_CellContentClick;
            
            buttonFindPath.Click += ButtonFindPath_Click;
            buttonReadBlockchain.Click += ButtonReadBlockchain_Click;
            buttonLogout.Click += ButtonLogout_Click;
            buttonSave.Click += ButtonSave_Click;
            buttonSendMoney.Click += ButtonSendMoney_Click;
            buttonCreateRequest.Click += ButtonCreateRequest_Click;
            buttonCheckBalance.Click += ButtonCheckBalance_Click;
            buttonCheckDate.Click += ButtonCheckDate_Click;
            buttonCheckHash.Click += buttonCheckHash_Click;
            buttonCheckSignature.Click += ButtonCheckSignature_Click;
            buttonCheckNonce.Click += buttonCheckNonce_Click;
            buttonValidateBlockchain.Click += ButtonValidateBlockchain_Click;
            buttonRemoveUnvalidatedBlocks.Click += ButtonRemoveUnvalidatedBlocks_Click;
            buttonRemoveUnvalidatedChain.Click += ButtonRemoveUnvalidatedChain_Click;
        }

        private void DataGridViewBlockchain_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index == dataGridViewBlockchain.Columns["id"].Index)
            {
                e.SortResult = int.Parse(e.CellValue1.ToString()).CompareTo(int.Parse(e.CellValue2.ToString()));
                e.Handled = true;
            }
        }

        private void ButtonRemoveUnvalidatedChain_Click(object sender, EventArgs e)
        {
            if (labelValidateStatus.Text == "Validated")
            {
                dataGridViewBlockchain.Sort(dataGridViewBlockchain.Columns["id"], ListSortDirection.Ascending);
                int rowToRemove = -1;
                for (int i = 0; i < dataGridViewBlockchain.RowCount; i++)
                {
                    if (i > 0)
                    {
                        for (int j = 0; j < dataGridViewBlockchain.ColumnCount; j++)
                        {
                            if (dataGridViewBlockchain[j, i].Style.BackColor == Color.Red)
                            {
                                rowToRemove = i;
                                break;
                            }
                        }
                        if (rowToRemove != -1)
                            break;
                    }
                }
                if (rowToRemove != -1)
                {
                    int removedRows = dataGridViewBlockchain.RowCount - rowToRemove;
                    for (int i = 0; i < removedRows; i++)
                        dataGridViewBlockchain.Rows.RemoveAt(rowToRemove);
                }
            }
            else
            {
                MessageBox.Show("Blockchain is not validated");
            }
        }

        private void ButtonRemoveUnvalidatedBlocks_Click(object sender, EventArgs e)
        {
            if (labelValidateStatus.Text == "Validated")
            {
                dataGridViewBlockchain.Sort(dataGridViewBlockchain.Columns["id"], ListSortDirection.Ascending);
                List<int> removedRows = new List<int>();
                int removedCount = 0;
                for (int i = 0; i < dataGridViewBlockchain.RowCount; i++)
                {
                    if(i>0)
                    {
                        for (int j = 0; j < dataGridViewBlockchain.ColumnCount; j++)
                        {
                            if (dataGridViewBlockchain[j, i].Style.BackColor == Color.Red)
                            {
                                removedRows.Add(i);
                                break;
                            }
                        }
                    }
                }
                foreach (int row in removedRows)
                {
                    dataGridViewBlockchain.Rows.RemoveAt(row - removedCount);
                    removedCount++;
                }
            }
            else
            {
                MessageBox.Show("Blockchain is not validated");
            }
        }

        void updateValidateStatus(string status, Color color)
        {
            labelValidateStatus.Text = status;
            labelValidateStatus.ForeColor = color;
        }

        public void UpdateStatus(string status, Color color, bool date)
        {
            labelStatus.Text = status;
            labelStatus.ForeColor = color;
            if (date)
                labelLastSyncDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void DataGridViewRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (senderGrid.Columns[e.ColumnIndex].Name == "Accept")
                {
                    for (int i = 0; i < requestList.Count; i++)
                    {
                        string requestID = senderGrid[dataGridViewRequests.Columns["id"].Index, e.RowIndex].Value.ToString();
                        if (requestList[i]["id"] == requestID)
                        {
                            DialogResult dialog = MessageBox.Show("Accept the request?", "Accept?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialog == DialogResult.Yes)
                            {
                                string requestCreator = senderGrid[dataGridViewRequests.Columns["Creator"].Index, e.RowIndex].Value.ToString();
                                string requestDescription = senderGrid[dataGridViewRequests.Columns["Description"].Index, e.RowIndex].Value.ToString();
                                string requestTo = senderGrid[dataGridViewRequests.Columns["To"].Index, e.RowIndex].Value.ToString();
                                string requestAmount = senderGrid[dataGridViewRequests.Columns["Amount"].Index, e.RowIndex].Value.ToString();
                                string requestDate = senderGrid[dataGridViewRequests.Columns["Date"].Index, e.RowIndex].Value.ToString();
                                string requestSign = senderGrid[dataGridViewRequests.Columns["Sign"].Index, e.RowIndex].Value.ToString();
                                string requestExponent = senderGrid[dataGridViewRequests.Columns["Exponent"].Index, e.RowIndex].Value.ToString();
                                try
                                {
                                    bool verified = verifyRequestRow(requestID, requestCreator, requestDescription, loginAddressFrom, requestTo, requestAmount, requestDate, requestExponent, requestSign, requestCreator);
                                    if (verified)
                                    {
                                        requestList[i]["Status"] = "Accepted";
                                        dataGridViewBlockchain.Sort(dataGridViewBlockchain.Columns["id"], ListSortDirection.Ascending);
                                        string lastBlockHash = getHashDataFromRowDGV(dataGridViewBlockchain.RowCount - 1, dataGridViewBlockchain);
                                        int blockID = Convert.ToInt32(dataGridViewBlockchain["id", dataGridViewBlockchain.RowCount - 1].Value) + 1;
                                        string dateOfTransaction = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                        string sign = SignData(privateKeyLoad, blockID.ToString(), loginAddressFrom, requestTo, requestAmount, dateOfTransaction, exponentFrom, lastBlockHash);
                                        long nonce = FindNonce(blockID.ToString(), loginAddressFrom, requestTo, requestAmount, dateOfTransaction, exponentFrom, lastBlockHash, sign);
                                        dataGridViewBlockchain.Rows.Add(blockID.ToString(), loginAddressFrom, requestTo, requestAmount, dateOfTransaction, exponentFrom, lastBlockHash, sign, nonce);
                                        dataGridViewRequests.Rows.RemoveAt(e.RowIndex);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Sign of request is invalid");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            break;
                        }
                    }
                    countBalance();
                }
                if (senderGrid.Columns[e.ColumnIndex].Name == "Reject")
                {
                    for (int i = 0; i < requestList.Count; i++)
                    {
                        string requestID = senderGrid[dataGridViewRequests.Columns["id"].Index, e.RowIndex].Value.ToString();
                        if (requestList[i]["id"] == requestID)
                        {
                            DialogResult dialog = MessageBox.Show("Reject the request?", "Reject?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialog == DialogResult.Yes)
                            {
                                requestList[i]["Status"] = "Rejected";
                                dataGridViewRequests.Rows.RemoveAt(e.RowIndex);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void DataGridViewBlockchain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //dataGridViewBlockchain.ContextMenuStrip = contextMenuStripBlockchainDGV;
                int currentMouseOverColumn = dataGridViewBlockchain.HitTest(e.X, e.Y).ColumnIndex;
                int currentMouseOverRow = dataGridViewBlockchain.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverColumn != -1 && currentMouseOverRow != -1)
                {
                    ToolStripMenuItem toolStripMenuItemFixHash = createToolStripMenuItemEvent("toolStripMenuItemFixHash", "Fix Hash", null, ToolStripMenuItemFixHash_Click);
                    ToolStripMenuItem toolStripMenuItemFixSign = createToolStripMenuItemEvent("toolStripMenuItemFixSign", "Fix Sign", null, ToolStripMenuItemFixSign_Click);
                    ToolStripMenuItem toolStripMenuItemFixNonce = createToolStripMenuItemEvent("toolStripMenuItemFixNonce", "Fix Nonce", null, ToolStripMenuItemFixNonce_Click);

                    ToolStripItem[] toolStripItems = null;
                    if (currentMouseOverColumn == dataGridViewBlockchain.Columns["PreviousHash"].Index)
                        toolStripItems = new ToolStripItem[] { toolStripMenuItemFixHash };
                    if (currentMouseOverColumn == dataGridViewBlockchain.Columns["Sign"].Index)
                        toolStripItems = new ToolStripItem[] { toolStripMenuItemFixSign };
                    if (currentMouseOverColumn == dataGridViewBlockchain.Columns["Nonce"].Index)
                        toolStripItems = new ToolStripItem[] { toolStripMenuItemFixNonce };
                    if (toolStripItems != null)
                    {
                        ContextMenuStrip contextMenuStripBlockchainDGV = createContextMenuStrip("contextMenuStripBlockchainDGV", toolStripItems);
                        contextMenuStripBlockchainDGV.Show(dataGridViewBlockchain, new Point(e.X, e.Y));
                    }
                    dataGridViewBlockchain[currentMouseOverColumn, currentMouseOverRow].Selected = true;
                }
            }
        }

        private void ToolStripMenuItemFixHash_Click(object sender, EventArgs e)
        {
            if (dataGridViewBlockchain.SelectedCells.Count > 0)
            {
                if (dataGridViewBlockchain.SelectedCells[0].ColumnIndex == dataGridViewBlockchain.Columns["PreviousHash"].Index)
                {
                    int selectedRow = dataGridViewBlockchain.SelectedCells[0].RowIndex;
                    if (selectedRow == 0)
                        dataGridViewBlockchain["PreviousHash", selectedRow].Value = "0000000000000000000000000000000000000000000000000000000000000000";
                    else
                    {
                        string previousBlockHash = getHashDataFromRowDGV(selectedRow - 1, dataGridViewBlockchain);
                        dataGridViewBlockchain["PreviousHash", selectedRow].Value = previousBlockHash;
                        string stringSymbols = new string('0', ZeroCount);
                        if(previousBlockHash.Substring(0, ZeroCount) == stringSymbols)
                            dataGridViewBlockchain["PreviousHash", selectedRow].Style.BackColor = Color.White;
                        else
                            dataGridViewBlockchain["PreviousHash", selectedRow].Style.BackColor = Color.Red;
                    }
                    if(checkBoxAutosave.Checked)
                    {
                        saveBlockchainAndRequests();
                        UpdateStatus("Saved", Color.Green, true);
                    }
                    else
                        UpdateStatus("Unsaved", Color.Orange, false);
                }
                else
                    MessageBox.Show("Hash cells not selected");
            }
            else
                MessageBox.Show("Cells not selected");
        }

        private void ToolStripMenuItemFixSign_Click(object sender, EventArgs e)
        {
            if (dataGridViewBlockchain.SelectedCells.Count > 0)
            {
                if (dataGridViewBlockchain.SelectedCells[0].ColumnIndex == dataGridViewBlockchain.Columns["Sign"].Index)
                {
                    int selectedRow = dataGridViewBlockchain.SelectedCells[0].RowIndex;
                    string from = dataGridViewBlockchain["From", selectedRow].Value.ToString();
                    string id = dataGridViewBlockchain["id", selectedRow].Value.ToString();
                    string to = dataGridViewBlockchain["To", selectedRow].Value.ToString();
                    string amount = dataGridViewBlockchain["Amount", selectedRow].Value.ToString();
                    string date = dataGridViewBlockchain["Date", selectedRow].Value.ToString();
                    string exponent = dataGridViewBlockchain["Exponent", selectedRow].Value.ToString();
                    string previousHash = dataGridViewBlockchain["PreviousHash", selectedRow].Value.ToString();
                    if (selectedRow == 0)
                    {
                        if (to == loginAddressFrom)
                        {
                            string sign = SignData(privateKeyLoad, id, from, to, amount, date, exponent, previousHash);
                            dataGridViewBlockchain["Sign", selectedRow].Value = sign;
                            dataGridViewBlockchain["Sign", selectedRow].Style.BackColor = Color.White;
                            if (checkBoxAutosave.Checked)
                            {
                                saveBlockchainAndRequests();
                                UpdateStatus("Saved", Color.Green, true);
                            }
                            else
                                UpdateStatus("Unsaved", Color.Orange, false);
                        }
                        else
                            MessageBox.Show("The signature can only be corrected by the recipient");
                    }
                    else
                    {
                        if (from == loginAddressFrom)
                        {
                            string sign = SignData(privateKeyLoad, id, from, to, amount, date, exponent, previousHash);
                            dataGridViewBlockchain["Sign", selectedRow].Value = sign;
                            dataGridViewBlockchain["Sign", selectedRow].Style.BackColor = Color.White;
                            if (checkBoxAutosave.Checked)
                            {
                                saveBlockchainAndRequests();
                                UpdateStatus("Saved", Color.Green, true);
                            }
                            else
                                UpdateStatus("Unsaved", Color.Orange, false);
                        }
                        else
                            MessageBox.Show("The signature can only be corrected by the sender");
                    }
                }
                else
                    MessageBox.Show("Sign cells not selected");
            }
            else
                MessageBox.Show("Cells not selected");
        }

        private void ToolStripMenuItemFixNonce_Click(object sender, EventArgs e)
        {
            if (dataGridViewBlockchain.SelectedCells.Count > 0)
            {
                if (dataGridViewBlockchain.SelectedCells[0].ColumnIndex == dataGridViewBlockchain.Columns["Nonce"].Index)
                {
                    int selectedRow = dataGridViewBlockchain.SelectedCells[0].RowIndex;
                    string id = dataGridViewBlockchain["id", selectedRow].Value.ToString();
                    string from = dataGridViewBlockchain["From", selectedRow].Value.ToString();
                    string to = dataGridViewBlockchain["To", selectedRow].Value.ToString();
                    string amount = dataGridViewBlockchain["Amount", selectedRow].Value.ToString();
                    string date = dataGridViewBlockchain["Date", selectedRow].Value.ToString();
                    string exponent = dataGridViewBlockchain["Exponent", selectedRow].Value.ToString();
                    string previousHash = dataGridViewBlockchain["PreviousHash", selectedRow].Value.ToString();
                    string sign = dataGridViewBlockchain["Sign", selectedRow].Value.ToString();
                    long nonce = FindNonce(id,from,to,amount,date,exponent,previousHash,sign);
                    dataGridViewBlockchain["Nonce", selectedRow].Value = nonce.ToString();
                    dataGridViewBlockchain["Nonce", selectedRow].Style.BackColor = Color.White;
                    if (checkBoxAutosave.Checked)
                    {
                        saveBlockchainAndRequests();
                        UpdateStatus("Saved", Color.Green, true);
                    }
                    else
                        UpdateStatus("Unsaved", Color.Orange, false);
                }
                else
                    MessageBox.Show("Nonce cells not selected");
            }
            else
                MessageBox.Show("Cells not selected");
        }

        private void generateKeyPairRSA(string pathToSaveKeys)
        {
            RSA rsa = new RSACryptoServiceProvider(1024); // Generate a new 1024-bit RSA key
            string privateKeyXML = rsa.ToXmlString(true);
            //string publicOnlyKeyXML = rsa.ToXmlString(false);
            //File.WriteAllText(pathToSaveKeys, privateKeyXML);
            using (StreamWriter writer = new StreamWriter(pathToSaveKeys))
            {
                writer.WriteLine(privateKeyXML);
            }
        }

        private void saveBlockchainAndRequests()
        {
            string fileName = textBoxBlockchainPath.Text;
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    dataGridViewBlockchain.Sort(dataGridViewBlockchain.Columns["id"], ListSortDirection.Ascending);
                    for (int i = 0; i < dataGridViewBlockchain.RowCount; i++)
                    {
                        StringBuilder sbToFile = new StringBuilder();
                        writer.WriteLine("{");
                        sbToFile.AppendFormat("\t{0}:{1}\n", "id", dataGridViewBlockchain["id", i].Value.ToString());
                        sbToFile.AppendFormat("\t{0}:{1}\n", "From", dataGridViewBlockchain["From", i].Value.ToString());
                        sbToFile.AppendFormat("\t{0}:{1}\n", "To", dataGridViewBlockchain["To", i].Value.ToString());
                        sbToFile.AppendFormat("\t{0}:{1}\n", "Amount", dataGridViewBlockchain["Amount", i].Value.ToString());
                        sbToFile.AppendFormat("\t{0}:{1}\n", "Date", dataGridViewBlockchain["Date", i].Value.ToString());
                        sbToFile.AppendFormat("\t{0}:{1}\n", "Exponent", dataGridViewBlockchain["Exponent", i].Value.ToString());
                        sbToFile.AppendFormat("\t{0}:{1}\n", "PreviousHash", dataGridViewBlockchain["PreviousHash", i].Value.ToString());
                        sbToFile.AppendFormat("\t{0}:{1}\n", "Sign", dataGridViewBlockchain["Sign", i].Value.ToString());
                        sbToFile.AppendFormat("\t{0}:{1}", "Nonce", dataGridViewBlockchain["Nonce", i].Value.ToString());
                        writer.WriteLine(sbToFile.ToString());
                        writer.WriteLine("}");
                    }
                    requestList.Sort((a, b) => int.Parse(a["id"]).CompareTo(int.Parse(b["id"])));
                    for (int i = 0; i < requestList.Count; i++)
                    {
                        StringBuilder sbToFile = new StringBuilder();
                        writer.WriteLine("[");
                        sbToFile.AppendFormat("\t{0}:{1}\n", "id", requestList[i]["id"]);
                        sbToFile.AppendFormat("\t{0}:{1}\n", "Creator", requestList[i]["Creator"]);
                        sbToFile.AppendFormat("\t{0}:{1}\n", "Description", requestList[i]["Description"]);
                        sbToFile.AppendFormat("\t{0}:{1}\n", "From", requestList[i]["From"]);
                        sbToFile.AppendFormat("\t{0}:{1}\n", "To", requestList[i]["To"]);
                        sbToFile.AppendFormat("\t{0}:{1}\n", "Amount", requestList[i]["Amount"]);
                        sbToFile.AppendFormat("\t{0}:{1}\n", "Date", requestList[i]["Date"]);
                        sbToFile.AppendFormat("\t{0}:{1}\n", "Exponent", requestList[i]["Exponent"]);
                        sbToFile.AppendFormat("\t{0}:{1}\n", "Sign", requestList[i]["Sign"]);
                        sbToFile.AppendFormat("\t{0}:{1}", "Status", requestList[i]["Status"]);
                        writer.WriteLine(sbToFile.ToString());
                        writer.WriteLine("]");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void countBalance()
        {
            balance = 0;
            for (int i = 0; i < dataGridViewBlockchain.RowCount; i++)
            {
                if (dataGridViewBlockchain["To", i].Value.ToString() == loginAddressFrom)
                    balance += Convert.ToDecimal(dataGridViewBlockchain["Amount", i].Value.ToString());
                if (dataGridViewBlockchain["From", i].Value.ToString() == loginAddressFrom)
                    balance -= Convert.ToDecimal(dataGridViewBlockchain["Amount", i].Value.ToString());
            }
            labelBalance.Text = string.Format("Balance: {0}", balance);
        }

        static void changeDataGridView(ref DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.MultiSelect = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.RowHeadersVisible = false;
            dgv.Dock = DockStyle.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //dgv.Name = nameDataGridView;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            //dgv.AutoGenerateColumns = true;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgv.BorderStyle = BorderStyle.Fixed3D;
        }

        static ToolStripMenuItem createToolStripMenuItemEvent(string nameToolStripMenuItem, string textToolStripMenuItem, ToolStripItem[] toolStripItems, EventHandler eventHandler)
        {
            ToolStripMenuItem TSMI = new ToolStripMenuItem();
            TSMI.Name = nameToolStripMenuItem;
            TSMI.Text = textToolStripMenuItem;
            if (toolStripItems != null)
                TSMI.DropDownItems.AddRange(toolStripItems);
            TSMI.Click += eventHandler;
            return TSMI;
        }

        static public ContextMenuStrip createContextMenuStrip(string nameContextMenuStrip, ToolStripItem[] toolStripItems)
        {
            ContextMenuStrip CMS = new ContextMenuStrip();
            CMS.Name = nameContextMenuStrip;
            CMS.Items.AddRange(toolStripItems);
            return CMS;
        }

        private void ButtonFindPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPathFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse blockchain File",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "blockchain",
                Filter = "blockchain files (*.blockchain)|*.blockchain|All files|*",
                FilterIndex = 1,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (openPathFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxBlockchainPath.Text = openPathFileDialog.FileName;
            }
        }

        private void ButtonReadBlockchain_Click(object sender, EventArgs e)
        {
            dataGridViewBlockchain.Rows.Clear();
            try
            {
                addressessList = new List<string>();
                blockList = new List<Dictionary<string, string>>();
                requestList = new List<Dictionary<string, string>>();
                parseBlockchain(textBoxBlockchainPath.Text, ref blockList, ref requestList);
                foreach (Dictionary<string,string> block in blockList)
                {
                    dataGridViewBlockchain.Rows.Add(block["id"], block["From"], block["To"], block["Amount"], block["Date"], block["Exponent"],block["PreviousHash"], block["Sign"], block["Nonce"]);
                    if (!addressessList.Contains(block["From"]) && block["From"]!= loginAddressFrom && block["From"] != "0")
                        addressessList.Add(block["From"]);
                    if (!addressessList.Contains(block["To"]) && block["To"] != loginAddressFrom && block["To"] != "0")
                        addressessList.Add(block["To"]);
                }
                countBalance();
                FillDataGridViewRequests(dataGridViewRequests);
                UpdateStatus("Loaded", Color.Green, true);
                updateValidateStatus("Not Validated", Color.Red);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //public void FillDataGridViewRequests(List<Dictionary<string,string>> requestListDictionary)
        public static void FillDataGridViewRequests(DataGridView dgv)
        {
            dgv.Rows.Clear();
            foreach (Dictionary<string, string> request in requestList)
            {
                if (request["From"] == loginAddressFrom && request["Status"] == "Awaiting")
                    dgv.Rows.Add(request["id"], request["Creator"], request["Description"],
                        request["From"], request["To"], request["Amount"], request["Date"], request["Sign"], request["Status"],
                        request["Exponent"]);
            }
        }

        private void ButtonLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to log out?", "Log out?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                var blockchainForm = ActiveForm;
                blockchainForm.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Closed += (s, args) => blockchainForm.Close();
                loginForm.Show();
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            //this.Text = string.Format("x={0},y={1}",this.Width,this.Height);
            //generateKeyPairRSA(@"D:\123.xml");
            saveBlockchainAndRequests();
            UpdateStatus("Saved",Color.Green,true);
            MessageBox.Show(string.Format("Blockchain saved by the following path {0}",textBoxBlockchainPath.Text));
        }

        private void ButtonSendMoney_Click(object sender, EventArgs e)
        {
            if (dataGridViewBlockchain.RowCount > 0)
            {
                if (balance > 0)
                {
                    int countRow = dataGridViewBlockchain.RowCount;
                    string lastBlockHash = getHashDataFromRowDGV(dataGridViewBlockchain.RowCount - 1, dataGridViewBlockchain);
                    SendMoney sendMoney = new SendMoney(balance, privateKeyLoad, loginAddressFrom, exponentFrom, lastBlockHash, addressessList, dataGridViewBlockchain);
                    sendMoney.ShowDialog();
                    countBalance();
                    if(countRow< dataGridViewBlockchain.RowCount)
                    {
                        if (checkBoxAutosave.Checked)
                        {
                            saveBlockchainAndRequests();
                            UpdateStatus("Saved", Color.Green, true);
                        }
                        else
                            UpdateStatus("Unsaved", Color.Orange, false);
                    }
                }
                else
                    MessageBox.Show("Balance should be more than 0");
            }
            else
                MessageBox.Show("Blockchain is empty");
        }

        private void ButtonCreateRequest_Click(object sender, EventArgs e)
        {
            if (dataGridViewBlockchain.RowCount > 0)
            {
                int requestCount = requestList.Count;
                RequestForm requestForm = new RequestForm(privateKeyLoad,loginAddressFrom,exponentFrom,addressessList, dataGridViewRequests,ref requestList);
                requestForm.ShowDialog();
                if (requestCount < requestList.Count)
                {
                    if (checkBoxAutosave.Checked)
                    {
                        saveBlockchainAndRequests();
                        UpdateStatus("Saved", Color.Green, true);
                    }
                    else
                        UpdateStatus("Unsaved", Color.Orange, false);
                }
            }
            else
                MessageBox.Show("Blockchain is empty");
        }

        void checkBalance()
        {
            Dictionary<string, decimal> balances = new Dictionary<string, decimal>();
            for (int i = 0; i < dataGridViewBlockchain.RowCount; i++)
            {
                string to = dataGridViewBlockchain["To", i].Value.ToString();
                decimal amount = Convert.ToDecimal(dataGridViewBlockchain["Amount", i].Value.ToString());
                if (i > 0)
                {
                    string from = dataGridViewBlockchain["From", i].Value.ToString();
                    if (!balances.ContainsKey(from))
                    {
                        balances.Add(from, 0);
                    }
                    if (!balances.ContainsKey(to))
                    {
                        balances.Add(to, 0);
                    }
                    balances[from] -= amount;
                    balances[to] += amount;
                    if (balances[from] < 0 || balances[to] < 0)
                    {
                        if (balances[from] < 0)
                            dataGridViewBlockchain["From", i].Style.BackColor = Color.Red;
                        else
                            dataGridViewBlockchain["From", i].Style.BackColor = Color.White;
                        if (balances[to] < 0)
                            dataGridViewBlockchain["To", i].Style.BackColor = Color.Red;
                        else
                            dataGridViewBlockchain["To", i].Style.BackColor = Color.White;
                        dataGridViewBlockchain["Amount", i].Style.BackColor = Color.Red;
                    }
                    else
                        dataGridViewBlockchain["Amount", i].Style.BackColor = Color.White;
                }
                else
                {
                    if (!balances.ContainsKey(to))
                    {
                        balances.Add(to, 0);
                    }
                    balances[to] += amount;
                }
            }
        }

        void checkDate()
        {
            List<string> uniqueDates = new List<string>();
            Dictionary<string, int> repeatedDates = new Dictionary<string, int>();
            for (int i = 0; i < dataGridViewBlockchain.RowCount; i++)
            {
                string date = dataGridViewBlockchain["Date", i].Value.ToString();
                if (uniqueDates.Contains(date))
                    repeatedDates.Add(date, 0);
                else
                    uniqueDates.Add(date);
            }
            for (int i = 0; i < dataGridViewBlockchain.RowCount; i++)
            {
                string date = dataGridViewBlockchain["Date", i].Value.ToString();
                if (repeatedDates.ContainsKey(date))
                {
                    if (repeatedDates[date] > 0)
                        dataGridViewBlockchain["Date", i].Style.BackColor = Color.Red;
                    else
                    {
                        dataGridViewBlockchain["Date", i].Style.BackColor = Color.White;
                        repeatedDates[date]++;
                    }
                }
            }
        }

        void checkHash()
        {
            for (int i = 0; i < dataGridViewBlockchain.RowCount; i++)
            {
                if (i > 0)
                {
                    string previousBlockHash = getHashDataFromRowDGV(i - 1, dataGridViewBlockchain);
                    string stringSymbols = new string('0', ZeroCount);
                    if (dataGridViewBlockchain["PreviousHash", i].Value.ToString() == previousBlockHash && previousBlockHash.Substring(0, ZeroCount) == stringSymbols)
                        dataGridViewBlockchain["PreviousHash", i].Style.BackColor = Color.White;
                    else
                        dataGridViewBlockchain["PreviousHash", i].Style.BackColor = Color.Red;

                }
            }
        }

        void checkSign()
        {
            for (int i = 0; i < dataGridViewBlockchain.RowCount; i++)
            {
                if (i > 0)
                {
                    try
                    {
                        bool verified = verifyBlockchainRow(dataGridViewBlockchain["id", i].Value.ToString(), dataGridViewBlockchain["From", i].Value.ToString(),
                        dataGridViewBlockchain["To", i].Value.ToString(), dataGridViewBlockchain["Amount", i].Value.ToString(),
                        dataGridViewBlockchain["Date", i].Value.ToString(), dataGridViewBlockchain["Exponent", i].Value.ToString(),
                        dataGridViewBlockchain["PreviousHash", i].Value.ToString(), dataGridViewBlockchain["Sign", i].Value.ToString(),
                        dataGridViewBlockchain["From", i].Value.ToString());
                        if (verified)
                            dataGridViewBlockchain["Sign", i].Style.BackColor = Color.White;
                        else
                            dataGridViewBlockchain["Sign", i].Style.BackColor = Color.Red;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        bool verified = verifyBlockchainRow(dataGridViewBlockchain["id", i].Value.ToString(), dataGridViewBlockchain["From", i].Value.ToString(),
                        dataGridViewBlockchain["To", i].Value.ToString(), dataGridViewBlockchain["Amount", i].Value.ToString(),
                        dataGridViewBlockchain["Date", i].Value.ToString(), dataGridViewBlockchain["Exponent", i].Value.ToString(),
                        dataGridViewBlockchain["PreviousHash", i].Value.ToString(), dataGridViewBlockchain["Sign", i].Value.ToString(),
                        dataGridViewBlockchain["To", i].Value.ToString());
                        if (verified)
                            dataGridViewBlockchain["Sign", i].Style.BackColor = Color.White;
                        else
                            dataGridViewBlockchain["Sign", i].Style.BackColor = Color.Red;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        void checkNonce()
        {
            for (int i = 0; i < dataGridViewBlockchain.RowCount; i++)
            {
                long nonce = FindNonce(dataGridViewBlockchain["id", i].Value.ToString(), dataGridViewBlockchain["From", i].Value.ToString(),
                    dataGridViewBlockchain["To", i].Value.ToString(), dataGridViewBlockchain["Amount", i].Value.ToString(),
                    dataGridViewBlockchain["Date", i].Value.ToString(), dataGridViewBlockchain["Exponent", i].Value.ToString(),
                    dataGridViewBlockchain["PreviousHash", i].Value.ToString(), dataGridViewBlockchain["Sign", i].Value.ToString());
                if (dataGridViewBlockchain["Nonce", i].Value.ToString() != nonce.ToString())
                    dataGridViewBlockchain["Nonce", i].Style.BackColor = Color.Red;
                else
                    dataGridViewBlockchain["Nonce", i].Style.BackColor = Color.White;
            }
        }

        private void ButtonCheckBalance_Click(object sender, EventArgs e)
        {
            dataGridViewBlockchain.Sort(dataGridViewBlockchain.Columns["id"], ListSortDirection.Ascending);
            checkBalance();
        }

        private void ButtonCheckDate_Click(object sender, EventArgs e)
        {
            dataGridViewBlockchain.Sort(dataGridViewBlockchain.Columns["id"], ListSortDirection.Ascending);
            checkDate();
        }

        private void buttonCheckHash_Click(object sender, EventArgs e)
        {
            dataGridViewBlockchain.Sort(dataGridViewBlockchain.Columns["id"], ListSortDirection.Ascending);
            checkHash();
        }
        
        private void ButtonCheckSignature_Click(object sender, EventArgs e)
        {
            dataGridViewBlockchain.Sort(dataGridViewBlockchain.Columns["id"], ListSortDirection.Ascending);
            checkSign();
        }

        private void buttonCheckNonce_Click(object sender, EventArgs e)
        {
            dataGridViewBlockchain.Sort(dataGridViewBlockchain.Columns["id"], ListSortDirection.Ascending);
            checkNonce();
        }

        private void ButtonValidateBlockchain_Click(object sender, EventArgs e)
        {
            dataGridViewBlockchain.Sort(dataGridViewBlockchain.Columns["id"], ListSortDirection.Ascending);
            checkBalance();
            checkDate();
            checkHash();
            checkSign();
            checkNonce();
            updateValidateStatus("Validated", Color.Green);
        }

        static List<Dictionary<string, string>> parseBlockchain(string filePath, ref List<Dictionary<string, string>> blockList, ref List<Dictionary<string, string>> requestList)
        {
            using (StreamReader reader = File.OpenText(filePath))
            {
                string line = String.Empty;
                Dictionary<string, string> block = new Dictionary<string, string>();
                Dictionary<string, string> request = new Dictionary<string, string>();
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line == "{")
                    {
                        line = reader.ReadLine().Trim();
                        block = new Dictionary<string, string>();
                        blockList.Add(block);
                        do
                        {
                            string field = line.Substring(0, line.IndexOf(':'));
                            string value = line.Substring(line.IndexOf(':') + 1);
                            block.Add(field, value);
                            if((line = reader.ReadLine()) != null)
                                line = line.Trim();
                        }
                        while (line != null && line != "}");
                    }
                    if (line == "[")
                    {
                        line = reader.ReadLine().Trim();
                        request = new Dictionary<string, string>();
                        requestList.Add(request);
                        do
                        {
                            string field = line.Substring(0, line.IndexOf(':'));
                            string value = line.Substring(line.IndexOf(':') + 1);
                            request.Add(field, value);
                            line = reader.ReadLine().Trim();
                        }
                        while (line != null && line != "]");
                    }
                }
            }
            return blockList;
        }

        public static string SignData(string privateKeyString, string id, string from, string to, string amount, string date, string exponent, string previousHash)
        {
            //// The array to store the signed message in bytes
            byte[] signedBytes;
            string message = string.Empty;
            message += string.Format("{0};", id);
            message += string.Format("{0};", from);
            message += string.Format("{0};", to);
            message += string.Format("{0};", amount);
            message += string.Format("{0};", date);
            message += string.Format("{0};", exponent);
            message += string.Format("{0}", previousHash);
            using (var rsa = new RSACryptoServiceProvider())
            {
                //// Write the message to a byte array using UTF8 as the encoding.
                var encoder = new UTF8Encoding();
                byte[] originalData = encoder.GetBytes(message);
                try
                {
                    //// Import the private key used for signing the message
                    //rsa.ImportParameters(privateKey);
                    rsa.FromXmlString(privateKeyString);
                    //// Sign the data, using SHA512 as the hashing algorithm 
                    signedBytes = rsa.SignData(originalData, CryptoConfig.MapNameToOID("SHA512"));
                }
                catch (CryptographicException e)
                {
                    MessageBox.Show(e.Message);
                    return null;
                }
                finally
                {
                    //// Set the keycontainer to be cleared when rsa is garbage collected.
                    rsa.PersistKeyInCsp = false;
                }
            }
            //// Convert the a base64 string before returning
            return Convert.ToBase64String(signedBytes);
        }

        public static string SignRequest(string privateKeyString, string id, string creator, string description, string from, string to, string amount, string date, string exponent)
        {
            //// The array to store the signed message in bytes
            byte[] signedBytes;
            string message = string.Empty;
            message += string.Format("{0};", id);
            message += string.Format("{0};", creator);
            message += string.Format("{0};", description);
            message += string.Format("{0};", from);
            message += string.Format("{0};", to);
            message += string.Format("{0};", amount);
            message += string.Format("{0};", date);
            message += string.Format("{0}", exponent);
            using (var rsa = new RSACryptoServiceProvider())
            {
                //// Write the message to a byte array using UTF8 as the encoding.
                var encoder = new UTF8Encoding();
                byte[] originalData = encoder.GetBytes(message);
                try
                {
                    //// Import the private key used for signing the message
                    //rsa.ImportParameters(privateKey);
                    rsa.FromXmlString(privateKeyString);
                    //// Sign the data, using SHA512 as the hashing algorithm 
                    signedBytes = rsa.SignData(originalData, CryptoConfig.MapNameToOID("SHA512"));
                }
                catch (CryptographicException e)
                {
                    MessageBox.Show(e.Message);
                    return null;
                }
                finally
                {
                    //// Set the keycontainer to be cleared when rsa is garbage collected.
                    rsa.PersistKeyInCsp = false;
                }
            }
            //// Convert the a base64 string before returning
            return Convert.ToBase64String(signedBytes);
        }

        static bool verifyBlockchainRow(string id, string from, string to, string amount, string date, string exponent, string previousHash, string sign, string publicIDString)
        {
            string publicKeyString = string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent></RSAKeyValue>", publicIDString, exponent);
            bool success = false;
            string message = string.Empty;
            message += string.Format("{0};", id);
            message += string.Format("{0};", from);
            message += string.Format("{0};", to);
            message += string.Format("{0};", amount);
            message += string.Format("{0};", date);
            message += string.Format("{0};", exponent);
            message += string.Format("{0}", previousHash);
            using (var rsa = new RSACryptoServiceProvider())
            {
                var encoder = new UTF8Encoding();
                byte[] bytesToVerify = encoder.GetBytes(message);
                byte[] signedBytes = Convert.FromBase64String(sign);
                try
                {
                    rsa.FromXmlString(publicKeyString);
                    success = rsa.VerifyData(bytesToVerify, CryptoConfig.MapNameToOID("SHA512"), signedBytes);
                }
                catch (CryptographicException e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
            return success;
        }

        static bool verifyRequestRow(string id, string creator, string description, string from, string to, 
            string amount, string date, string exponent, string sign, string publicIDString)
        {
            string publicKeyString = string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent></RSAKeyValue>", publicIDString, exponent);
            bool success = false;
            string message = string.Empty;
            message += string.Format("{0};", id);
            message += string.Format("{0};", creator);
            message += string.Format("{0};", description);
            message += string.Format("{0};", from);
            message += string.Format("{0};", to);
            message += string.Format("{0};", amount);
            message += string.Format("{0};", date);
            message += string.Format("{0}", exponent);
            using (var rsa = new RSACryptoServiceProvider())
            {
                var encoder = new UTF8Encoding();
                byte[] bytesToVerify = encoder.GetBytes(message);
                byte[] signedBytes = Convert.FromBase64String(sign);
                try
                {
                    rsa.FromXmlString(publicKeyString);
                    success = rsa.VerifyData(bytesToVerify, CryptoConfig.MapNameToOID("SHA512"), signedBytes);
                }
                catch (CryptographicException e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
            return success;
        }

        public static bool CheckPrivateKey(string privateKeyString)
        {
            string message = "test";
            byte[] signedBytes;
            bool success = false;
            using (var rsa = new RSACryptoServiceProvider())
            {
                //// Write the message to a byte array using UTF8 as the encoding.
                var encoder = new UTF8Encoding();
                byte[] originalData = encoder.GetBytes(message);
                try
                {
                    //// Import the private key used for signing the message
                    //rsa.ImportParameters(privateKey);
                    rsa.FromXmlString(privateKeyString);
                    //// Sign the data, using SHA512 as the hashing algorithm 
                    signedBytes = rsa.SignData(originalData, CryptoConfig.MapNameToOID("SHA512"));
                }
                catch (CryptographicException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                finally
                {
                    //// Set the keycontainer to be cleared when rsa is garbage collected.
                    rsa.PersistKeyInCsp = false;
                }
            }
            using (var rsa = new RSACryptoServiceProvider())
            {
                var encoder = new UTF8Encoding();
                byte[] bytesToVerify = encoder.GetBytes(message);
                try
                {
                    rsa.FromXmlString(privateKeyString);
                    success = rsa.VerifyData(bytesToVerify, CryptoConfig.MapNameToOID("SHA512"), signedBytes);
                }
                catch (CryptographicException e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
            return success;
        }

        static string getPublicKeyString(string privateKeyString, string selectNode)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(privateKeyString);
            try
            {
                XmlNode node = doc.DocumentElement.SelectSingleNode(selectNode);
                if (node != null)
                    return node.InnerText;
                else
                    return string.Empty;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return string.Empty;
            }
        }

        static byte[] getHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        static string getHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in getHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        static string getPublicKey(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in Encoding.UTF8.GetBytes(inputString))
                sb.Append(b.ToString("X2"));
            string s = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(sb.ToString()));
            return sb.ToString();
        }

        public static long FindNonce(string id, string from, string to, string amount, string date, string exponent, string previousHash, string sign)
        {
            long nonce = -1;
            string stringSymbols = new string('0', ZeroCount);
            string blockHash = string.Empty;
            string currentBlockData = string.Empty;
            currentBlockData += string.Format("{0};", id);
            currentBlockData += string.Format("{0};", from);
            currentBlockData += string.Format("{0};", to);
            currentBlockData += string.Format("{0};", amount);
            currentBlockData += string.Format("{0};", date);
            currentBlockData += string.Format("{0};", exponent);
            currentBlockData += string.Format("{0};", previousHash);
            currentBlockData += string.Format("{0};", sign);
            do
            {
                nonce++;
                currentBlockData = currentBlockData.Remove(currentBlockData.LastIndexOf(';'));
                currentBlockData += string.Format(";{0}",nonce.ToString());
                blockHash = getHashString(currentBlockData.ToString());
            }
            while (blockHash.Substring(0, ZeroCount) != stringSymbols);
            return nonce;
        }

        static string getHashDataFromRowDGV(int rowNumber, DataGridView dgv)
        {
            string previousBlockData = string.Empty;
            previousBlockData += string.Format("{0};", dgv["id", rowNumber].Value.ToString());
            previousBlockData += string.Format("{0};", dgv["From", rowNumber].Value.ToString());
            previousBlockData += string.Format("{0};", dgv["To", rowNumber].Value.ToString());
            previousBlockData += string.Format("{0};", dgv["Amount", rowNumber].Value.ToString());
            previousBlockData += string.Format("{0};", dgv["Date", rowNumber].Value.ToString());
            previousBlockData += string.Format("{0};", dgv["Exponent", rowNumber].Value.ToString());
            previousBlockData += string.Format("{0};", dgv["PreviousHash", rowNumber].Value.ToString());
            previousBlockData += string.Format("{0};", dgv["Sign", rowNumber].Value.ToString());
            previousBlockData += string.Format("{0}", dgv["Nonce", rowNumber].Value.ToString());
            return getHashString(previousBlockData); 
        }
    }
}