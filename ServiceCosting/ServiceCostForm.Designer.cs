namespace ServiceCosting
{
    partial class ServicesCostForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnGenExcelData = new System.Windows.Forms.Button();
            this.KMeansDGV = new System.Windows.Forms.DataGridView();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.dgHsCostGap = new System.Windows.Forms.DataGridView();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.dgTlsCostGap = new System.Windows.Forms.DataGridView();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.dgEthCostGap = new System.Windows.Forms.DataGridView();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.dgvVPN = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvEthernet = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvTLS = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvHS = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgVpnM2 = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dgEthM2 = new System.Windows.Forms.DataGridView();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dgTLSM2 = new System.Windows.Forms.DataGridView();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.dgHSM2 = new System.Windows.Forms.DataGridView();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.dgVpnCostGap = new System.Windows.Forms.DataGridView();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.KMeansDGV)).BeginInit();
            this.tabPage14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHsCostGap)).BeginInit();
            this.tabPage13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTlsCostGap)).BeginInit();
            this.tabPage12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEthCostGap)).BeginInit();
            this.tabPage11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVPN)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEthernet)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTLS)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHS)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVpnM2)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEthM2)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTLSM2)).BeginInit();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHSM2)).BeginInit();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVpnCostGap)).BeginInit();
            this.tabPage9.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenExcelData
            // 
            this.btnGenExcelData.Location = new System.Drawing.Point(769, 605);
            this.btnGenExcelData.Name = "btnGenExcelData";
            this.btnGenExcelData.Size = new System.Drawing.Size(157, 36);
            this.btnGenExcelData.TabIndex = 5;
            this.btnGenExcelData.Text = "Send Data to Python";
            this.btnGenExcelData.UseVisualStyleBackColor = true;
            this.btnGenExcelData.Click += new System.EventHandler(this.btnGenExcelData_Click);
            // 
            // KMeansDGV
            // 
            this.KMeansDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.KMeansDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KMeansDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KMeansDGV.Location = new System.Drawing.Point(3, 3);
            this.KMeansDGV.Name = "KMeansDGV";
            this.KMeansDGV.RowTemplate.Height = 24;
            this.KMeansDGV.Size = new System.Drawing.Size(1226, 564);
            this.KMeansDGV.TabIndex = 5;
            this.KMeansDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.KMeansDGV_CellContentClick);
            this.KMeansDGV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.KMeansDGV_CellFormatting);
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.KMeansDGV);
            this.tabPage14.Location = new System.Drawing.Point(4, 25);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage14.Size = new System.Drawing.Size(1232, 570);
            this.tabPage14.TabIndex = 13;
            this.tabPage14.Text = "K-Means -CostGap";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // dgHsCostGap
            // 
            this.dgHsCostGap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgHsCostGap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHsCostGap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgHsCostGap.Location = new System.Drawing.Point(3, 3);
            this.dgHsCostGap.Name = "dgHsCostGap";
            this.dgHsCostGap.RowTemplate.Height = 24;
            this.dgHsCostGap.Size = new System.Drawing.Size(1226, 564);
            this.dgHsCostGap.TabIndex = 5;
            this.dgHsCostGap.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgHsCostGap_CellFormatting);
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.dgHsCostGap);
            this.tabPage13.Location = new System.Drawing.Point(4, 25);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage13.Size = new System.Drawing.Size(1232, 570);
            this.tabPage13.TabIndex = 12;
            this.tabPage13.Text = "HS Cost Gap";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // dgTlsCostGap
            // 
            this.dgTlsCostGap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgTlsCostGap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTlsCostGap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTlsCostGap.Location = new System.Drawing.Point(3, 3);
            this.dgTlsCostGap.Name = "dgTlsCostGap";
            this.dgTlsCostGap.RowTemplate.Height = 24;
            this.dgTlsCostGap.Size = new System.Drawing.Size(1226, 564);
            this.dgTlsCostGap.TabIndex = 4;
            this.dgTlsCostGap.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgTlsCostGap_CellFormatting);
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.dgTlsCostGap);
            this.tabPage12.Location = new System.Drawing.Point(4, 25);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage12.Size = new System.Drawing.Size(1232, 570);
            this.tabPage12.TabIndex = 11;
            this.tabPage12.Text = "TLS Cost Gap";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // dgEthCostGap
            // 
            this.dgEthCostGap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgEthCostGap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEthCostGap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgEthCostGap.Location = new System.Drawing.Point(3, 3);
            this.dgEthCostGap.Name = "dgEthCostGap";
            this.dgEthCostGap.RowTemplate.Height = 24;
            this.dgEthCostGap.Size = new System.Drawing.Size(1226, 564);
            this.dgEthCostGap.TabIndex = 3;
            this.dgEthCostGap.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgEthCostGap_CellFormatting);
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.dgEthCostGap);
            this.tabPage11.Location = new System.Drawing.Point(4, 25);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(1232, 570);
            this.tabPage11.TabIndex = 10;
            this.tabPage11.Text = "Ethernet Cost Gap";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-1, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1232, 571);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.dataGridView1);
            this.tabPage10.Location = new System.Drawing.Point(4, 25);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(1232, 570);
            this.tabPage10.TabIndex = 9;
            this.tabPage10.Text = "Network Infrastructure Cost";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // dgvVPN
            // 
            this.dgvVPN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVPN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVPN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVPN.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvVPN.Location = new System.Drawing.Point(6, 2);
            this.dgvVPN.Name = "dgvVPN";
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvVPN.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvVPN.RowTemplate.Height = 24;
            this.dgvVPN.Size = new System.Drawing.Size(1222, 564);
            this.dgvVPN.TabIndex = 0;
            this.dgvVPN.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvVPN_CellFormatting);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.dgvVPN);
            this.tabPage1.ForeColor = System.Drawing.Color.Transparent;
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1232, 570);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "IPVPN-M1";
            // 
            // dgvEthernet
            // 
            this.dgvEthernet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEthernet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEthernet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEthernet.Location = new System.Drawing.Point(3, 3);
            this.dgvEthernet.Name = "dgvEthernet";
            this.dgvEthernet.RowTemplate.Height = 24;
            this.dgvEthernet.Size = new System.Drawing.Size(1226, 564);
            this.dgvEthernet.TabIndex = 0;
            this.dgvEthernet.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEthernet_CellFormatting);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvEthernet);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1232, 570);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ethernet-M1";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvTLS
            // 
            this.dgvTLS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTLS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTLS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTLS.Location = new System.Drawing.Point(3, 3);
            this.dgvTLS.Name = "dgvTLS";
            this.dgvTLS.RowTemplate.Height = 24;
            this.dgvTLS.Size = new System.Drawing.Size(1226, 564);
            this.dgvTLS.TabIndex = 0;
            this.dgvTLS.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTLS_CellFormatting);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvTLS);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1232, 570);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "TLS-M1";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvHS
            // 
            this.dgvHS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHS.Location = new System.Drawing.Point(3, 3);
            this.dgvHS.Name = "dgvHS";
            this.dgvHS.RowTemplate.Height = 24;
            this.dgvHS.Size = new System.Drawing.Size(1226, 564);
            this.dgvHS.TabIndex = 0;
            this.dgvHS.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHS_CellFormatting);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvHS);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1232, 570);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "HS-M1";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgVpnM2
            // 
            this.dgVpnM2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgVpnM2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgVpnM2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVpnM2.Location = new System.Drawing.Point(6, 2);
            this.dgVpnM2.Name = "dgVpnM2";
            this.dgVpnM2.RowTemplate.Height = 24;
            this.dgVpnM2.Size = new System.Drawing.Size(1222, 567);
            this.dgVpnM2.TabIndex = 1;
            this.dgVpnM2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgVpnM2_CellFormatting);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dgVpnM2);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1232, 570);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "IPVPN-M2";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dgEthM2
            // 
            this.dgEthM2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgEthM2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEthM2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgEthM2.Location = new System.Drawing.Point(3, 3);
            this.dgEthM2.Name = "dgEthM2";
            this.dgEthM2.RowTemplate.Height = 24;
            this.dgEthM2.Size = new System.Drawing.Size(1226, 564);
            this.dgEthM2.TabIndex = 1;
            this.dgEthM2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgEthM2_CellFormatting);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.dgEthM2);
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1232, 570);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Ethernet-M2";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // dgTLSM2
            // 
            this.dgTLSM2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgTLSM2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTLSM2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTLSM2.Location = new System.Drawing.Point(3, 3);
            this.dgTLSM2.Name = "dgTLSM2";
            this.dgTLSM2.RowTemplate.Height = 24;
            this.dgTLSM2.Size = new System.Drawing.Size(1226, 564);
            this.dgTLSM2.TabIndex = 1;
            this.dgTLSM2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgTLSM2_CellFormatting);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.dgTLSM2);
            this.tabPage7.Location = new System.Drawing.Point(4, 25);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1232, 570);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "TLS-M2";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // dgHSM2
            // 
            this.dgHSM2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgHSM2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHSM2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgHSM2.Location = new System.Drawing.Point(3, 3);
            this.dgHSM2.Name = "dgHSM2";
            this.dgHSM2.RowTemplate.Height = 24;
            this.dgHSM2.Size = new System.Drawing.Size(1226, 564);
            this.dgHSM2.TabIndex = 1;
            this.dgHSM2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgHSM2_CellFormatting);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.dgHSM2);
            this.tabPage8.Location = new System.Drawing.Point(4, 25);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1232, 570);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "HS-M2";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // dgVpnCostGap
            // 
            this.dgVpnCostGap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgVpnCostGap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVpnCostGap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgVpnCostGap.Location = new System.Drawing.Point(3, 3);
            this.dgVpnCostGap.Name = "dgVpnCostGap";
            this.dgVpnCostGap.RowTemplate.Height = 24;
            this.dgVpnCostGap.Size = new System.Drawing.Size(1226, 564);
            this.dgVpnCostGap.TabIndex = 2;
            this.dgVpnCostGap.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgVpnCostGap_CellFormatting);
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.dgVpnCostGap);
            this.tabPage9.Location = new System.Drawing.Point(4, 25);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(1232, 570);
            this.tabPage9.TabIndex = 8;
            this.tabPage9.Text = "Vpn Cost Gap";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(956, 605);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(109, 37);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(1089, 605);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(128, 36);
            this.btnExportExcel.TabIndex = 4;
            this.btnExportExcel.Text = "Export To Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage10);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabPage11);
            this.tabControl1.Controls.Add(this.tabPage12);
            this.tabControl1.Controls.Add(this.tabPage13);
            this.tabControl1.Controls.Add(this.tabPage14);
            this.tabControl1.Location = new System.Drawing.Point(9, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1240, 599);
            this.tabControl1.TabIndex = 3;
            // 
            // ServicesCostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 656);
            this.Controls.Add(this.btnGenExcelData);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.tabControl1);
            this.Name = "ServicesCostForm";
            this.Text = "ServiceCostForm";
            ((System.ComponentModel.ISupportInitialize)(this.KMeansDGV)).EndInit();
            this.tabPage14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgHsCostGap)).EndInit();
            this.tabPage13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTlsCostGap)).EndInit();
            this.tabPage12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgEthCostGap)).EndInit();
            this.tabPage11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVPN)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEthernet)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTLS)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHS)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgVpnM2)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgEthM2)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTLSM2)).EndInit();
            this.tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgHSM2)).EndInit();
            this.tabPage8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgVpnCostGap)).EndInit();
            this.tabPage9.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenExcelData;
        private System.Windows.Forms.DataGridView KMeansDGV;
        private System.Windows.Forms.TabPage tabPage14;
        private System.Windows.Forms.DataGridView dgHsCostGap;
        private System.Windows.Forms.TabPage tabPage13;
        private System.Windows.Forms.DataGridView dgTlsCostGap;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.DataGridView dgEthCostGap;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.DataGridView dgvVPN;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvEthernet;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvTLS;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvHS;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgVpnM2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dgEthM2;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView dgTLSM2;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.DataGridView dgHSM2;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.DataGridView dgVpnCostGap;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.TabControl tabControl1;
    }
}