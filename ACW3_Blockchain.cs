using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ACW3_Blockchain
{
    public partial class ACW3_Blockchain : Form
    {
        string loginAddressFrom;
        string exponentFrom;
        public static int ZeroCount = 4;
        //string filenamePrivateKeyXml;    //remove!
        string privateKeyLoad;
        List<string> addressessList = new List<string>();
        public ACW3_Blockchain(string privateKeyString)
        {
            InitializeComponent();
            loginAddressFrom = getPublicKeyString(privateKeyString, "Modulus");
            //labelPublicID.Text = string.Format("id:{0}", loginAddressFrom);
            labelPublicID.Text = loginAddressFrom;
            exponentFrom = getPublicKeyString(privateKeyString, "Exponent");
            //filenamePrivateKeyXml = @"D:\privatekey2048.xml";
            //privateKeyLoad = File.ReadAllText(privateKeyString);
            privateKeyLoad = privateKeyString;
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
            changeDataGridView(ref dataGridViewLog);
            buttonFindPath.Click += ButtonFindPath_Click;
            buttonReadBlockchain.Click += ButtonReadBlockchain_Click;
            buttonLogout.Click += ButtonLogout_Click;
            buttonSync.Click += ButtonSync_Click;
            buttonSendMoney.Click += ButtonSendMoney_Click;
            buttonCheckHash.Click += buttonCheckHash_Click;
            buttonCheckSignature.Click += ButtonCheckSignature_Click;
            buttonCheckNonce.Click += buttonCheckNonce_Click;
            buttonValidateBlockchain.Click += ButtonValidateBlockchain_Click;


            string dataToEncryptString = "The quick brown fox jumps over the lazy dog";
            byte[] bytesDataToEncryptString = Encoding.ASCII.GetBytes(dataToEncryptString);

            RSACryptoServiceProvider rSA = new RSACryptoServiceProvider();
            var privateKey = rSA.ToXmlString(true);
            var publicKey = rSA.ToXmlString(false);

            //byte[] signature = rSA.SignHash(bytesDataToEncryptString, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);

            string filenamePrivateKeyXml = @"D:\privatekey2048_3.xml";
            //string filenamePublicKeyXml = @"D:\publickey2048_3.xml";
            using (StreamWriter writer = new StreamWriter(filenamePrivateKeyXml))
            {
                writer.WriteLine(privateKey);
            }
            //using (StreamWriter writer = new StreamWriter(filenamePublicKeyXml))
            {
            //    writer.WriteLine(publicKey);
            }

            var EncodedString = Convert.ToBase64String(Encoding.UTF8.GetBytes(privateKey));



            Debug.WriteLine(privateKey);
            Debug.WriteLine(EncodedString);
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
                List<Dictionary<string, string>> blockList = parseBlockchain(textBoxBlockchainPath.Text);
                foreach (Dictionary<string,string> block in blockList)
                {
                    dataGridViewBlockchain.Rows.Add(block["id"], block["From"], block["To"], block["Amount"], block["Date"], block["Exponent"],block["PreviousHash"], block["Sign"], block["Nonce"]);
                    if (!addressessList.Contains(block["From"]))
                        addressessList.Add(block["From"]);
                    if (!addressessList.Contains(block["To"]))
                        addressessList.Add(block["To"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonLogout_Click(object sender, EventArgs e)
        {
            string fileName = @"D:\123.blockchain";
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    for (int i = 0; i < dataGridViewBlockchain.RowCount; i++)
                    {
                        
                        //string currentBlockData = string.Empty;

                            
                        if (i > 0)
                        {
                            dataGridViewBlockchain["PreviousHash", i].Value = getHashDataFromRowDGV(i-1, dataGridViewBlockchain);

                        }
                        //currentBlockData += string.Format("{0};", dataGridViewBlockchain["id", i].Value.ToString());
                        //currentBlockData += string.Format("{0};", dataGridViewBlockchain["From", i].Value.ToString());
                        //currentBlockData += string.Format("{0};", dataGridViewBlockchain["To", i].Value.ToString());
                        //currentBlockData += string.Format("{0};", dataGridViewBlockchain["Amount", i].Value.ToString());
                        //currentBlockData += string.Format("{0};", dataGridViewBlockchain["Date", i].Value.ToString());
                        ////currentBlockData += string.Format("{0};", DateTime.Now.ToString("M/d/yyyyMMdd HH:mm:ss"));                     //change!!!!!!!!!!!!!
                        //currentBlockData += string.Format("{0};", dataGridViewBlockchain["Exponent", i].Value.ToString());
                        //currentBlockData += string.Format("{0};", dataGridViewBlockchain["PreviousHash", i].Value.ToString());
                        //long nonce = FindNonce(currentBlockData, 4);
                        string sign = SignData(privateKeyLoad, dataGridViewBlockchain["id", i].Value.ToString(), dataGridViewBlockchain["From", i].Value.ToString(),
                            dataGridViewBlockchain["To", i].Value.ToString(), dataGridViewBlockchain["Amount", i].Value.ToString(),
                            dataGridViewBlockchain["Date", i].Value.ToString(), dataGridViewBlockchain["Exponent", i].Value.ToString(),
                            dataGridViewBlockchain["PreviousHash", i].Value.ToString());
                        long nonce = FindNonce(ZeroCount, dataGridViewBlockchain["id", i].Value.ToString(), dataGridViewBlockchain["From", i].Value.ToString(),
                            dataGridViewBlockchain["To", i].Value.ToString(), dataGridViewBlockchain["Amount", i].Value.ToString(),
                            dataGridViewBlockchain["Date", i].Value.ToString(), dataGridViewBlockchain["Exponent", i].Value.ToString(),
                            dataGridViewBlockchain["PreviousHash", i].Value.ToString(), dataGridViewBlockchain["Sign", i].Value.ToString());
                        dataGridViewBlockchain["Nonce", i].Value = nonce;
                        //writer.WriteLine("{");
                        //writer.WriteLine(string.Format("\t{0}:{1}", "id", dataGridViewBlockchain["id", i].Value.ToString()));
                        //writer.WriteLine(string.Format("\t{0}:{1}", "From", dataGridViewBlockchain["From", i].Value.ToString()));
                        //writer.WriteLine(string.Format("\t{0}:{1}", "To", dataGridViewBlockchain["To", i].Value.ToString()));
                        //writer.WriteLine(string.Format("\t{0}:{1}", "Amount", dataGridViewBlockchain["Amount", i].Value.ToString()));
                        //writer.WriteLine(string.Format("\t{0}:{1}", "Date", dataGridViewBlockchain["Date", i].Value.ToString()));
                        //writer.WriteLine(string.Format("\t{0}:{1}", "Exponent", dataGridViewBlockchain["Exponent", i].Value.ToString()));
                        //writer.WriteLine(string.Format("\t{0}:{1}", "PreviousHash", dataGridViewBlockchain["PreviousHash", i].Value.ToString()));
                        //writer.WriteLine(string.Format("\t{0}:{1}", "Nonce", dataGridViewBlockchain["Nonce", i].Value.ToString()));
                        //writer.WriteLine("}");

                        StringBuilder sbToFile = new StringBuilder();
                        writer.WriteLine("{");
                        sbToFile.AppendFormat("\t{0}:{1}\n", "id", dataGridViewBlockchain["id", i].Value.ToString());
                        sbToFile.AppendFormat("\t{0}:{1}\n", "From", dataGridViewBlockchain["From", i].Value.ToString());
                        sbToFile.AppendFormat("\t{0}:{1}\n", "To", dataGridViewBlockchain["To", i].Value.ToString());
                        sbToFile.AppendFormat("\t{0}:{1}\n", "Amount", dataGridViewBlockchain["Amount", i].Value.ToString());
                        //sbToFile.AppendFormat("\t{0}:{1}\n", "Date", dataGridViewBlockchain["Date", i].Value.ToString());
                        sbToFile.AppendFormat("\t{0}:{1}\n", "Date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        sbToFile.AppendFormat("\t{0}:{1}\n", "Exponent", dataGridViewBlockchain["Exponent", i].Value.ToString());
                        //sbToFile.AppendFormat("\t{0}:{1}\n", "PreviousHash", getHashString(sbToFile.ToString()));
                        sbToFile.AppendFormat("\t{0}:{1}\n", "PreviousHash", dataGridViewBlockchain["PreviousHash", i].Value.ToString());
                        //sbToFile.AppendFormat("\t{0}:{1}\n", "Nonce", nonce);
                        sbToFile.AppendFormat("\t{0}:{1}", "Nonce", dataGridViewBlockchain["Nonce", i].Value.ToString());
                        writer.WriteLine(sbToFile.ToString());
                        writer.WriteLine("}");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonSync_Click(object sender, EventArgs e)
        {
            this.Text = string.Format("x={0},y={1}",this.Width,this.Height);
        }

        private void ButtonSendMoney_Click(object sender, EventArgs e)
        {
            if (dataGridViewBlockchain.RowCount > 0)
            {
                string lastBlockHash = getHashDataFromRowDGV(dataGridViewBlockchain.RowCount - 1, dataGridViewBlockchain);
                SendMoney sendMoney = new SendMoney(privateKeyLoad, loginAddressFrom, exponentFrom, lastBlockHash, addressessList, dataGridViewBlockchain);
                sendMoney.ShowDialog();
            }
            else
                MessageBox.Show("Blockchain is empty");
        }

        private void buttonCheckHash_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewBlockchain.RowCount; i++)
            {
                if (i > 0)
                {
                    string previousHash = getHashDataFromRowDGV(i - 1, dataGridViewBlockchain);
                    if (dataGridViewBlockchain["PreviousHash", i].Value.ToString() != previousHash)
                        dataGridViewBlockchain["PreviousHash", i].Style.BackColor = Color.Red;
                    else
                        dataGridViewBlockchain["PreviousHash", i].Style.BackColor = Color.White;
                }
            }
        }
        
        private void ButtonCheckSignature_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewBlockchain.RowCount; i++)
            {
                string sign = SignData(privateKeyLoad, dataGridViewBlockchain["id", i].Value.ToString(), dataGridViewBlockchain["From", i].Value.ToString(),
                    dataGridViewBlockchain["To", i].Value.ToString(), dataGridViewBlockchain["Amount", i].Value.ToString(),
                    dataGridViewBlockchain["Date", i].Value.ToString(), dataGridViewBlockchain["Exponent", i].Value.ToString(),
                    dataGridViewBlockchain["PreviousHash", i].Value.ToString());
                if (dataGridViewBlockchain["Sign", i].Value.ToString() != sign)
                    dataGridViewBlockchain["Sign", i].Style.BackColor = Color.Red;
                else
                    dataGridViewBlockchain["Sign", i].Style.BackColor = Color.White;
            }
        }

        private void buttonCheckNonce_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewBlockchain.RowCount; i++)
            {
                long nonce = FindNonce(ZeroCount, dataGridViewBlockchain["id", i].Value.ToString(), dataGridViewBlockchain["From", i].Value.ToString(),
                    dataGridViewBlockchain["To", i].Value.ToString(), dataGridViewBlockchain["Amount", i].Value.ToString(),
                    dataGridViewBlockchain["Date", i].Value.ToString(), dataGridViewBlockchain["Exponent", i].Value.ToString(),
                    dataGridViewBlockchain["PreviousHash", i].Value.ToString(), dataGridViewBlockchain["Sign", i].Value.ToString());
                if (dataGridViewBlockchain["Nonce", i].Value.ToString() != nonce.ToString())
                    dataGridViewBlockchain["Nonce", i].Style.BackColor = Color.Red;
                else
                    dataGridViewBlockchain["Nonce", i].Style.BackColor = Color.White;
            }
        }

        private void ButtonValidateBlockchain_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewBlockchain.RowCount; i++)
            {
                if (i > 0)
                {
                    string previousHash = getHashDataFromRowDGV(i - 1, dataGridViewBlockchain);
                    if (dataGridViewBlockchain["PreviousHash", i].Value.ToString() != previousHash)
                        dataGridViewBlockchain["PreviousHash", i].Style.BackColor = Color.Red;
                    else
                        dataGridViewBlockchain["PreviousHash", i].Style.BackColor = Color.White;
                }
                string sign = SignData(privateKeyLoad, dataGridViewBlockchain["id", i].Value.ToString(), dataGridViewBlockchain["From", i].Value.ToString(),
                    dataGridViewBlockchain["To", i].Value.ToString(), dataGridViewBlockchain["Amount", i].Value.ToString(),
                    dataGridViewBlockchain["Date", i].Value.ToString(), dataGridViewBlockchain["Exponent", i].Value.ToString(),
                    dataGridViewBlockchain["PreviousHash", i].Value.ToString());
                long nonce = FindNonce(ZeroCount, dataGridViewBlockchain["id", i].Value.ToString(), dataGridViewBlockchain["From", i].Value.ToString(),
                    dataGridViewBlockchain["To", i].Value.ToString(), dataGridViewBlockchain["Amount", i].Value.ToString(),
                    dataGridViewBlockchain["Date", i].Value.ToString(), dataGridViewBlockchain["Exponent", i].Value.ToString(),
                    dataGridViewBlockchain["PreviousHash", i].Value.ToString(), dataGridViewBlockchain["Sign", i].Value.ToString());
                if (dataGridViewBlockchain["Sign", i].Value.ToString() != sign)
                    dataGridViewBlockchain["Sign", i].Style.BackColor = Color.Red;
                else
                    dataGridViewBlockchain["Sign", i].Style.BackColor = Color.White;
                if (dataGridViewBlockchain["Nonce", i].Value.ToString() != nonce.ToString())
                    dataGridViewBlockchain["Nonce", i].Style.BackColor = Color.Red;
                else
                    dataGridViewBlockchain["Nonce", i].Style.BackColor = Color.White;
            }
        }

        static List<Dictionary<string, string>> parseBlockchain(string filePath)
        {
            List<Dictionary<string, string>> blockList = new List<Dictionary<string, string>>();
            using (StreamReader reader = File.OpenText(filePath))
            {
                string line = String.Empty;
                Dictionary<string, string> block = new Dictionary<string, string>();
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    //Console.WriteLine(line);
                    if (line == "{")
                    {
                        block = new Dictionary<string, string>();
                        blockList.Add(block);
                    }
                    else
                    {
                        if (line != "}")
                        {
                            string field = line.Substring(0, line.IndexOf(':'));
                            string value = line.Substring(line.IndexOf(':') + 1);
                            block.Add(field, value);
                        }
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

        static bool verifyData(string id, string from, string to, string amount, string date, string exponent, string previousHash, string sign, string publicIDString, string exponentString)
        {
            string publicKeyString = string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent></RSAKeyValue>", publicIDString, exponentString);
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
            XmlNode node = doc.DocumentElement.SelectSingleNode(selectNode);
            return node.InnerText;
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

        public static long FindNonce(int zeroCount, string id, string from, string to, string amount, string date, string exponent, string previousHash, string sign)
        {
            long nonce = -1;
            string stringSymbols = new string('0', zeroCount);
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
            while (blockHash.Substring(0, zeroCount) != stringSymbols);
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