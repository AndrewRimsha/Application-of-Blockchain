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

namespace ACW3_Blockchain
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            buttonFindPath.Click += ButtonFindPath_Click;
            buttonLogin.Click += ButtonLogin_Click;
            buttonExit.Click += ButtonExit_Click;

        }

        private void ButtonFindPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPathFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse blockchain File",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "xml",
                Filter = "xml files (*.xml)|*.xml|All files|*",
                FilterIndex = 1,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (openPathFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxPathToFile.Text = openPathFileDialog.FileName;
            }
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBoxPathToFile.Text))
            {
                try
                {
                    string privateKeyString = File.ReadAllText(textBoxPathToFile.Text);
                    if (ACW3_Blockchain.CheckPrivateKey(privateKeyString))
                    {
                        var loginForm = ActiveForm;
                        loginForm.Hide();
                        ACW3_Blockchain mainForm = new ACW3_Blockchain(privateKeyString);
                        mainForm.Closed += (s, args) => loginForm.Close();
                        mainForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Private key is invalid");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("File doesn't exist");
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
