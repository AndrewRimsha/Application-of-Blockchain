
namespace ACW3_Blockchain
{
    partial class ACW3_Blockchain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ACW3_Blockchain));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelPublicID = new System.Windows.Forms.Label();
            this.labelBalance = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.labelID = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelLastSyncDate = new System.Windows.Forms.Label();
            this.labelLastStatusSync = new System.Windows.Forms.Label();
            this.buttonSync = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSendMoney = new System.Windows.Forms.Button();
            this.buttonCheckHash = new System.Windows.Forms.Button();
            this.buttonCheckSignature = new System.Windows.Forms.Button();
            this.buttonCheckNonce = new System.Windows.Forms.Button();
            this.buttonValidateBlockchain = new System.Windows.Forms.Button();
            this.dataGridViewBlockchain = new System.Windows.Forms.DataGridView();
            this.dataGridViewRequests = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.labelBlockchainFilePath = new System.Windows.Forms.Label();
            this.textBoxBlockchainPath = new System.Windows.Forms.TextBox();
            this.buttonFindPath = new System.Windows.Forms.Button();
            this.buttonReadBlockchain = new System.Windows.Forms.Button();
            this.groupBoxBlockchain = new System.Windows.Forms.GroupBox();
            this.groupBoxRequests = new System.Windows.Forms.GroupBox();
            this.buttonCreateRequest = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBlockchain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequests)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBoxBlockchain.SuspendLayout();
            this.groupBoxRequests.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxBlockchain, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxRequests, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(744, 411);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.Controls.Add(this.labelPublicID, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelBalance, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonLogout, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelID, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1, 51);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(742, 28);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // labelPublicID
            // 
            this.labelPublicID.AutoSize = true;
            this.labelPublicID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPublicID.Location = new System.Drawing.Point(21, 0);
            this.labelPublicID.Name = "labelPublicID";
            this.labelPublicID.Size = new System.Drawing.Size(558, 28);
            this.labelPublicID.TabIndex = 1;
            this.labelPublicID.Text = "Public ID";
            this.labelPublicID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBalance
            // 
            this.labelBalance.AutoSize = true;
            this.labelBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBalance.Location = new System.Drawing.Point(585, 0);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(74, 28);
            this.labelBalance.TabIndex = 2;
            this.labelBalance.Text = "Balance: 100000";
            this.labelBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Location = new System.Drawing.Point(663, 1);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(1);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(78, 26);
            this.buttonLogout.TabIndex = 0;
            this.buttonLogout.Text = "Log out";
            this.buttonLogout.UseVisualStyleBackColor = true;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelID.Location = new System.Drawing.Point(0, 0);
            this.labelID.Margin = new System.Windows.Forms.Padding(0);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(18, 28);
            this.labelID.TabIndex = 3;
            this.labelID.Text = "id:";
            this.labelID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.99813F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel3.Controls.Add(this.labelStatus, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelLastSyncDate, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelLastStatusSync, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonSync, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelName, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1, 81);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(742, 28);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStatus.ForeColor = System.Drawing.Color.Red;
            this.labelStatus.Location = new System.Drawing.Point(167, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(158, 28);
            this.labelStatus.TabIndex = 0;
            this.labelStatus.Text = "Status";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLastSyncDate
            // 
            this.labelLastSyncDate.AutoSize = true;
            this.labelLastSyncDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLastSyncDate.Location = new System.Drawing.Point(331, 0);
            this.labelLastSyncDate.Name = "labelLastSyncDate";
            this.labelLastSyncDate.Size = new System.Drawing.Size(158, 28);
            this.labelLastSyncDate.TabIndex = 1;
            this.labelLastSyncDate.Text = "Last sync date";
            this.labelLastSyncDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLastStatusSync
            // 
            this.labelLastStatusSync.AutoSize = true;
            this.labelLastStatusSync.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLastStatusSync.Location = new System.Drawing.Point(495, 0);
            this.labelLastStatusSync.Name = "labelLastStatusSync";
            this.labelLastStatusSync.Size = new System.Drawing.Size(158, 28);
            this.labelLastStatusSync.TabIndex = 2;
            this.labelLastStatusSync.Text = "Last statuc sync";
            this.labelLastStatusSync.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSync
            // 
            this.buttonSync.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSync.Location = new System.Drawing.Point(657, 1);
            this.buttonSync.Margin = new System.Windows.Forms.Padding(1);
            this.buttonSync.Name = "buttonSync";
            this.buttonSync.Size = new System.Drawing.Size(84, 26);
            this.buttonSync.TabIndex = 3;
            this.buttonSync.Text = "Sync";
            this.buttonSync.UseVisualStyleBackColor = true;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName.Location = new System.Drawing.Point(3, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(158, 28);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Name";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 6;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66611F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66945F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66611F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66611F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66611F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66611F));
            this.tableLayoutPanel4.Controls.Add(this.buttonSendMoney, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonCheckHash, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonCheckSignature, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonCheckNonce, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonValidateBlockchain, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonCreateRequest, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(1, 381);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(742, 29);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // buttonSendMoney
            // 
            this.buttonSendMoney.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSendMoney.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSendMoney.Location = new System.Drawing.Point(1, 1);
            this.buttonSendMoney.Margin = new System.Windows.Forms.Padding(1);
            this.buttonSendMoney.Name = "buttonSendMoney";
            this.buttonSendMoney.Size = new System.Drawing.Size(121, 27);
            this.buttonSendMoney.TabIndex = 0;
            this.buttonSendMoney.Text = "Send Money";
            this.buttonSendMoney.UseVisualStyleBackColor = true;
            // 
            // buttonCheckHash
            // 
            this.buttonCheckHash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCheckHash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCheckHash.Location = new System.Drawing.Point(247, 1);
            this.buttonCheckHash.Margin = new System.Windows.Forms.Padding(1);
            this.buttonCheckHash.Name = "buttonCheckHash";
            this.buttonCheckHash.Size = new System.Drawing.Size(121, 27);
            this.buttonCheckHash.TabIndex = 2;
            this.buttonCheckHash.Text = "Check Hash";
            this.buttonCheckHash.UseVisualStyleBackColor = true;
            // 
            // buttonCheckSignature
            // 
            this.buttonCheckSignature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCheckSignature.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCheckSignature.Location = new System.Drawing.Point(370, 1);
            this.buttonCheckSignature.Margin = new System.Windows.Forms.Padding(1);
            this.buttonCheckSignature.Name = "buttonCheckSignature";
            this.buttonCheckSignature.Size = new System.Drawing.Size(121, 27);
            this.buttonCheckSignature.TabIndex = 3;
            this.buttonCheckSignature.Text = "Check Signature";
            this.buttonCheckSignature.UseVisualStyleBackColor = true;
            // 
            // buttonCheckNonce
            // 
            this.buttonCheckNonce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCheckNonce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCheckNonce.Location = new System.Drawing.Point(493, 1);
            this.buttonCheckNonce.Margin = new System.Windows.Forms.Padding(1);
            this.buttonCheckNonce.Name = "buttonCheckNonce";
            this.buttonCheckNonce.Size = new System.Drawing.Size(121, 27);
            this.buttonCheckNonce.TabIndex = 4;
            this.buttonCheckNonce.Text = "Check Nonce";
            this.buttonCheckNonce.UseVisualStyleBackColor = true;
            // 
            // buttonValidateBlockchain
            // 
            this.buttonValidateBlockchain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonValidateBlockchain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonValidateBlockchain.Location = new System.Drawing.Point(616, 1);
            this.buttonValidateBlockchain.Margin = new System.Windows.Forms.Padding(1);
            this.buttonValidateBlockchain.Name = "buttonValidateBlockchain";
            this.buttonValidateBlockchain.Size = new System.Drawing.Size(125, 27);
            this.buttonValidateBlockchain.TabIndex = 5;
            this.buttonValidateBlockchain.Text = "Validate Blockchain";
            this.buttonValidateBlockchain.UseVisualStyleBackColor = true;
            // 
            // dataGridViewBlockchain
            // 
            this.dataGridViewBlockchain.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewBlockchain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBlockchain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBlockchain.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewBlockchain.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridViewBlockchain.Name = "dataGridViewBlockchain";
            this.dataGridViewBlockchain.Size = new System.Drawing.Size(736, 155);
            this.dataGridViewBlockchain.TabIndex = 3;
            // 
            // dataGridViewRequests
            // 
            this.dataGridViewRequests.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRequests.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewRequests.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridViewRequests.Name = "dataGridViewRequests";
            this.dataGridViewRequests.Size = new System.Drawing.Size(736, 73);
            this.dataGridViewRequests.TabIndex = 4;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel5.Controls.Add(this.labelBlockchainFilePath, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.textBoxBlockchainPath, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.buttonFindPath, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.buttonReadBlockchain, 3, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(1, 26);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(742, 23);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // labelBlockchainFilePath
            // 
            this.labelBlockchainFilePath.AutoSize = true;
            this.labelBlockchainFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBlockchainFilePath.Location = new System.Drawing.Point(1, 1);
            this.labelBlockchainFilePath.Margin = new System.Windows.Forms.Padding(1);
            this.labelBlockchainFilePath.Name = "labelBlockchainFilePath";
            this.labelBlockchainFilePath.Size = new System.Drawing.Size(103, 21);
            this.labelBlockchainFilePath.TabIndex = 1;
            this.labelBlockchainFilePath.Text = "Blockchain file path:";
            this.labelBlockchainFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxBlockchainPath
            // 
            this.textBoxBlockchainPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxBlockchainPath.Location = new System.Drawing.Point(106, 1);
            this.textBoxBlockchainPath.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxBlockchainPath.Name = "textBoxBlockchainPath";
            this.textBoxBlockchainPath.Size = new System.Drawing.Size(475, 20);
            this.textBoxBlockchainPath.TabIndex = 1;
            // 
            // buttonFindPath
            // 
            this.buttonFindPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFindPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFindPath.Location = new System.Drawing.Point(583, 1);
            this.buttonFindPath.Margin = new System.Windows.Forms.Padding(1);
            this.buttonFindPath.Name = "buttonFindPath";
            this.buttonFindPath.Size = new System.Drawing.Size(78, 21);
            this.buttonFindPath.TabIndex = 2;
            this.buttonFindPath.Text = "Find Path";
            this.buttonFindPath.UseVisualStyleBackColor = true;
            // 
            // buttonReadBlockchain
            // 
            this.buttonReadBlockchain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonReadBlockchain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReadBlockchain.Location = new System.Drawing.Point(663, 1);
            this.buttonReadBlockchain.Margin = new System.Windows.Forms.Padding(1);
            this.buttonReadBlockchain.Name = "buttonReadBlockchain";
            this.buttonReadBlockchain.Size = new System.Drawing.Size(78, 21);
            this.buttonReadBlockchain.TabIndex = 3;
            this.buttonReadBlockchain.Text = "Read";
            this.buttonReadBlockchain.UseVisualStyleBackColor = true;
            // 
            // groupBoxBlockchain
            // 
            this.groupBoxBlockchain.Controls.Add(this.dataGridViewBlockchain);
            this.groupBoxBlockchain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxBlockchain.Location = new System.Drawing.Point(1, 111);
            this.groupBoxBlockchain.Margin = new System.Windows.Forms.Padding(1);
            this.groupBoxBlockchain.Name = "groupBoxBlockchain";
            this.groupBoxBlockchain.Size = new System.Drawing.Size(742, 174);
            this.groupBoxBlockchain.TabIndex = 6;
            this.groupBoxBlockchain.TabStop = false;
            this.groupBoxBlockchain.Text = "Blockchain";
            // 
            // groupBoxRequests
            // 
            this.groupBoxRequests.Controls.Add(this.dataGridViewRequests);
            this.groupBoxRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxRequests.Location = new System.Drawing.Point(1, 287);
            this.groupBoxRequests.Margin = new System.Windows.Forms.Padding(1);
            this.groupBoxRequests.Name = "groupBoxRequests";
            this.groupBoxRequests.Size = new System.Drawing.Size(742, 92);
            this.groupBoxRequests.TabIndex = 7;
            this.groupBoxRequests.TabStop = false;
            this.groupBoxRequests.Text = "Requests";
            // 
            // buttonCreateRequest
            // 
            this.buttonCreateRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCreateRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateRequest.Location = new System.Drawing.Point(124, 1);
            this.buttonCreateRequest.Margin = new System.Windows.Forms.Padding(1);
            this.buttonCreateRequest.Name = "buttonCreateRequest";
            this.buttonCreateRequest.Size = new System.Drawing.Size(121, 27);
            this.buttonCreateRequest.TabIndex = 1;
            this.buttonCreateRequest.Text = "Create Request";
            this.buttonCreateRequest.UseVisualStyleBackColor = true;
            // 
            // ACW3_Blockchain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(744, 411);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(760, 450);
            this.Name = "ACW3_Blockchain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACW3_Blockchain";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBlockchain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequests)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.groupBoxBlockchain.ResumeLayout(false);
            this.groupBoxRequests.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label labelPublicID;
        private System.Windows.Forms.Label labelBalance;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelLastSyncDate;
        private System.Windows.Forms.Label labelLastStatusSync;
        private System.Windows.Forms.Button buttonSync;
        private System.Windows.Forms.DataGridView dataGridViewBlockchain;
        private System.Windows.Forms.DataGridView dataGridViewRequests;
        private System.Windows.Forms.Button buttonSendMoney;
        private System.Windows.Forms.Button buttonCheckHash;
        private System.Windows.Forms.Button buttonCheckSignature;
        private System.Windows.Forms.Button buttonCheckNonce;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label labelBlockchainFilePath;
        private System.Windows.Forms.TextBox textBoxBlockchainPath;
        private System.Windows.Forms.Button buttonFindPath;
        private System.Windows.Forms.Button buttonReadBlockchain;
        private System.Windows.Forms.Button buttonValidateBlockchain;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.GroupBox groupBoxBlockchain;
        private System.Windows.Forms.GroupBox groupBoxRequests;
        private System.Windows.Forms.Button buttonCreateRequest;
    }
}

