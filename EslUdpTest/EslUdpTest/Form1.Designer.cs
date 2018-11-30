namespace EslUdpTest
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.leBleMac = new System.Windows.Forms.Label();
            this.ScanBleButton = new System.Windows.Forms.Button();
            this.BleConnect = new System.Windows.Forms.Button();
            this.ReadDeviceNameButton = new System.Windows.Forms.Button();
            this.WriteDeviceNameButton = new System.Windows.Forms.Button();
            this.tbDeviceName = new System.Windows.Forms.TextBox();
            this.WriteEslDataButton = new System.Windows.Forms.Button();
            this.BleDisconnect = new System.Windows.Forms.Button();
            this.leconnect = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ContinueWrite = new System.Windows.Forms.Button();
            this.BeaconButton = new System.Windows.Forms.Button();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.writeEslTimeout = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tbEslTime = new System.Windows.Forms.TextBox();
            this.BleTimeout = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tbBleTimeout = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.ErrorEslList = new System.Windows.Forms.ListBox();
            this.btnUP = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.BleMacCountLabel = new System.Windows.Forms.Label();
            this.ErrorCountLabel = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.EslBattery = new System.Windows.Forms.Button();
            this.EslVersin = new System.Windows.Forms.Button();
            this.ReadEslManufacture = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.WriteEslDataContinueBtn = new System.Windows.Forms.Button();
            this.WriteEslDataBtn = new System.Windows.Forms.Button();
            this.CustomerIDEslBtn = new System.Windows.Forms.Button();
            this.ReadSizeBtn = new System.Windows.Forms.Button();
            this.tblManufacture = new System.Windows.Forms.TextBox();
            this.WriteEslManufacture = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CustomerIDApBtn = new System.Windows.Forms.Button();
            this.ApBufferRetrySet = new System.Windows.Forms.Button();
            this.UpdataReTryCount = new System.Windows.Forms.TextBox();
            this.tbBeaconCount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbBeaconEndTime = new System.Windows.Forms.TextBox();
            this.tbBeaconStartTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SetBeaconTime = new System.Windows.Forms.Button();
            this.GetRTCTime = new System.Windows.Forms.Button();
            this.SetRTCTime = new System.Windows.Forms.Button();
            this.UpdateEsl = new System.Windows.Forms.Button();
            this.WriteEslBuffer = new System.Windows.Forms.Button();
            this.tbMessageBox = new System.Windows.Forms.RichTextBox();
            this.getAPinfo = new System.Windows.Forms.Button();
            this.AP_Connect = new System.Windows.Forms.Button();
            this.AP_ListBox = new System.Windows.Forms.ListBox();
            this.AP_IP_Label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ReadTextFile = new System.Windows.Forms.Button();
            this.SaveMacToText = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tBCustomerID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cBSize = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.WriteEslData2Button = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "選擇BLE位置 : ";
            // 
            // leBleMac
            // 
            this.leBleMac.AutoSize = true;
            this.leBleMac.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.leBleMac.ForeColor = System.Drawing.Color.Navy;
            this.leBleMac.Location = new System.Drawing.Point(97, 66);
            this.leBleMac.Name = "leBleMac";
            this.leBleMac.Size = new System.Drawing.Size(131, 16);
            this.leBleMac.TabIndex = 6;
            this.leBleMac.Text = "ADC59450A0BB";
            // 
            // ScanBleButton
            // 
            this.ScanBleButton.Location = new System.Drawing.Point(6, 35);
            this.ScanBleButton.Name = "ScanBleButton";
            this.ScanBleButton.Size = new System.Drawing.Size(93, 23);
            this.ScanBleButton.TabIndex = 7;
            this.ScanBleButton.Text = "Start Scan Ble";
            this.ScanBleButton.UseVisualStyleBackColor = true;
            this.ScanBleButton.Click += new System.EventHandler(this.ScanBleButton_Click);
            // 
            // BleConnect
            // 
            this.BleConnect.Location = new System.Drawing.Point(106, 35);
            this.BleConnect.Name = "BleConnect";
            this.BleConnect.Size = new System.Drawing.Size(79, 23);
            this.BleConnect.TabIndex = 8;
            this.BleConnect.Text = "Ble Connect";
            this.BleConnect.UseVisualStyleBackColor = true;
            this.BleConnect.Click += new System.EventHandler(this.BleConnect_Click);
            // 
            // ReadDeviceNameButton
            // 
            this.ReadDeviceNameButton.Location = new System.Drawing.Point(76, 12);
            this.ReadDeviceNameButton.Name = "ReadDeviceNameButton";
            this.ReadDeviceNameButton.Size = new System.Drawing.Size(92, 23);
            this.ReadDeviceNameButton.TabIndex = 13;
            this.ReadDeviceNameButton.Text = "讀取ESL名稱";
            this.ReadDeviceNameButton.UseVisualStyleBackColor = true;
            this.ReadDeviceNameButton.Click += new System.EventHandler(this.ReadDeviceNameButton_Click);
            // 
            // WriteDeviceNameButton
            // 
            this.WriteDeviceNameButton.Location = new System.Drawing.Point(3, 95);
            this.WriteDeviceNameButton.Name = "WriteDeviceNameButton";
            this.WriteDeviceNameButton.Size = new System.Drawing.Size(92, 23);
            this.WriteDeviceNameButton.TabIndex = 14;
            this.WriteDeviceNameButton.Text = "寫入ESL名稱";
            this.WriteDeviceNameButton.UseVisualStyleBackColor = true;
            this.WriteDeviceNameButton.Click += new System.EventHandler(this.WriteDeviceNameButton_Click);
            // 
            // tbDeviceName
            // 
            this.tbDeviceName.Location = new System.Drawing.Point(101, 96);
            this.tbDeviceName.MaxLength = 12;
            this.tbDeviceName.Name = "tbDeviceName";
            this.tbDeviceName.Size = new System.Drawing.Size(67, 22);
            this.tbDeviceName.TabIndex = 15;
            this.tbDeviceName.Text = "ESL-0001";
            // 
            // WriteEslDataButton
            // 
            this.WriteEslDataButton.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.WriteEslDataButton.Location = new System.Drawing.Point(106, 6);
            this.WriteEslDataButton.Name = "WriteEslDataButton";
            this.WriteEslDataButton.Size = new System.Drawing.Size(79, 25);
            this.WriteEslDataButton.TabIndex = 18;
            this.WriteEslDataButton.Text = "寫入電子紙";
            this.WriteEslDataButton.UseVisualStyleBackColor = true;
            this.WriteEslDataButton.Click += new System.EventHandler(this.WriteEslDataButton_Click);
            // 
            // BleDisconnect
            // 
            this.BleDisconnect.Location = new System.Drawing.Point(191, 35);
            this.BleDisconnect.Name = "BleDisconnect";
            this.BleDisconnect.Size = new System.Drawing.Size(72, 23);
            this.BleDisconnect.TabIndex = 20;
            this.BleDisconnect.Text = "Disconnect";
            this.BleDisconnect.UseVisualStyleBackColor = true;
            this.BleDisconnect.Click += new System.EventHandler(this.BleDisconnect_Click);
            // 
            // leconnect
            // 
            this.leconnect.AutoSize = true;
            this.leconnect.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.leconnect.ForeColor = System.Drawing.Color.Red;
            this.leconnect.Location = new System.Drawing.Point(220, 66);
            this.leconnect.Name = "leconnect";
            this.leconnect.Size = new System.Drawing.Size(55, 15);
            this.leconnect.TabIndex = 21;
            this.leconnect.Text = "未連線";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 87);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(325, 17);
            this.progressBar1.TabIndex = 22;
            // 
            // ContinueWrite
            // 
            this.ContinueWrite.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ContinueWrite.ForeColor = System.Drawing.Color.Blue;
            this.ContinueWrite.Location = new System.Drawing.Point(6, 4);
            this.ContinueWrite.Name = "ContinueWrite";
            this.ContinueWrite.Size = new System.Drawing.Size(89, 25);
            this.ContinueWrite.TabIndex = 24;
            this.ContinueWrite.Text = "連續寫入";
            this.ContinueWrite.UseVisualStyleBackColor = true;
            this.ContinueWrite.Click += new System.EventHandler(this.ContinueWrite_Click);
            // 
            // BeaconButton
            // 
            this.BeaconButton.Location = new System.Drawing.Point(83, 13);
            this.BeaconButton.Name = "BeaconButton";
            this.BeaconButton.Size = new System.Drawing.Size(79, 23);
            this.BeaconButton.TabIndex = 26;
            this.BeaconButton.Text = "設定Beacon";
            this.BeaconButton.UseVisualStyleBackColor = true;
            this.BeaconButton.Click += new System.EventHandler(this.BeaconButton_Click);
            // 
            // tbTime
            // 
            this.tbTime.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbTime.Location = new System.Drawing.Point(75, 69);
            this.tbTime.MaxLength = 3;
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(38, 27);
            this.tbTime.TabIndex = 32;
            this.tbTime.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 12);
            this.label6.TabIndex = 33;
            this.label6.Text = "連線間隔(S):";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(119, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 23);
            this.button2.TabIndex = 34;
            this.button2.Text = "設定";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // writeEslTimeout
            // 
            this.writeEslTimeout.Location = new System.Drawing.Point(119, 10);
            this.writeEslTimeout.Name = "writeEslTimeout";
            this.writeEslTimeout.Size = new System.Drawing.Size(42, 23);
            this.writeEslTimeout.TabIndex = 44;
            this.writeEslTimeout.Text = "設定";
            this.writeEslTimeout.UseVisualStyleBackColor = true;
            this.writeEslTimeout.Click += new System.EventHandler(this.writeEslTimeout_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 12);
            this.label9.TabIndex = 43;
            this.label9.Text = "Esl Timeout";
            // 
            // tbEslTime
            // 
            this.tbEslTime.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbEslTime.Location = new System.Drawing.Point(75, 10);
            this.tbEslTime.MaxLength = 3;
            this.tbEslTime.Name = "tbEslTime";
            this.tbEslTime.Size = new System.Drawing.Size(38, 27);
            this.tbEslTime.TabIndex = 42;
            this.tbEslTime.Text = "12";
            // 
            // BleTimeout
            // 
            this.BleTimeout.Location = new System.Drawing.Point(119, 40);
            this.BleTimeout.Name = "BleTimeout";
            this.BleTimeout.Size = new System.Drawing.Size(42, 23);
            this.BleTimeout.TabIndex = 47;
            this.BleTimeout.Text = "設定";
            this.BleTimeout.UseVisualStyleBackColor = true;
            this.BleTimeout.Click += new System.EventHandler(this.BleTimeout_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 12);
            this.label10.TabIndex = 46;
            this.label10.Text = "Ble Timeout";
            // 
            // tbBleTimeout
            // 
            this.tbBleTimeout.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbBleTimeout.Location = new System.Drawing.Point(75, 39);
            this.tbBleTimeout.MaxLength = 3;
            this.tbBleTimeout.Name = "tbBleTimeout";
            this.tbBleTimeout.Size = new System.Drawing.Size(38, 27);
            this.tbBleTimeout.TabIndex = 45;
            this.tbBleTimeout.Text = "30";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(191, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 23);
            this.button3.TabIndex = 48;
            this.button3.Text = "全黑連續";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button4.Location = new System.Drawing.Point(267, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 49;
            this.button4.Text = "全白連續";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(267, 35);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 50;
            this.button5.Text = "全紅連續";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // ErrorEslList
            // 
            this.ErrorEslList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ErrorEslList.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ErrorEslList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ErrorEslList.FormattingEnabled = true;
            this.ErrorEslList.ItemHeight = 16;
            this.ErrorEslList.Location = new System.Drawing.Point(228, 311);
            this.ErrorEslList.Name = "ErrorEslList";
            this.ErrorEslList.Size = new System.Drawing.Size(134, 308);
            this.ErrorEslList.TabIndex = 52;
            // 
            // btnUP
            // 
            this.btnUP.Location = new System.Drawing.Point(51, 110);
            this.btnUP.Name = "btnUP";
            this.btnUP.Size = new System.Drawing.Size(32, 23);
            this.btnUP.TabIndex = 57;
            this.btnUP.Text = "上";
            this.btnUP.UseVisualStyleBackColor = true;
            this.btnUP.Click += new System.EventHandler(this.btnUP_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(89, 110);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(33, 23);
            this.btnDown.TabIndex = 58;
            this.btnDown.Text = "下";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // BleMacCountLabel
            // 
            this.BleMacCountLabel.AutoSize = true;
            this.BleMacCountLabel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BleMacCountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BleMacCountLabel.Location = new System.Drawing.Point(6, 141);
            this.BleMacCountLabel.Name = "BleMacCountLabel";
            this.BleMacCountLabel.Size = new System.Drawing.Size(51, 16);
            this.BleMacCountLabel.TabIndex = 59;
            this.BleMacCountLabel.Text = "Count";
            // 
            // ErrorCountLabel
            // 
            this.ErrorCountLabel.AutoSize = true;
            this.ErrorCountLabel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ErrorCountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ErrorCountLabel.Location = new System.Drawing.Point(279, 293);
            this.ErrorCountLabel.Name = "ErrorCountLabel";
            this.ErrorCountLabel.Size = new System.Drawing.Size(51, 16);
            this.ErrorCountLabel.TabIndex = 60;
            this.ErrorCountLabel.Text = "Count";
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.Location = new System.Drawing.Point(73, 138);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(93, 23);
            this.SaveFileButton.TabIndex = 61;
            this.SaveFileButton.Text = "存檔(失敗次數)";
            this.SaveFileButton.UseVisualStyleBackColor = true;
            this.SaveFileButton.Click += new System.EventHandler(this.SaveFileButton_Click);
            // 
            // EslBattery
            // 
            this.EslBattery.Location = new System.Drawing.Point(6, 11);
            this.EslBattery.Name = "EslBattery";
            this.EslBattery.Size = new System.Drawing.Size(65, 23);
            this.EslBattery.TabIndex = 62;
            this.EslBattery.Text = "電量";
            this.EslBattery.UseVisualStyleBackColor = true;
            this.EslBattery.Click += new System.EventHandler(this.EslBattery_Click);
            // 
            // EslVersin
            // 
            this.EslVersin.Location = new System.Drawing.Point(5, 38);
            this.EslVersin.Name = "EslVersin";
            this.EslVersin.Size = new System.Drawing.Size(66, 23);
            this.EslVersin.TabIndex = 63;
            this.EslVersin.Text = "版本";
            this.EslVersin.UseVisualStyleBackColor = true;
            this.EslVersin.Click += new System.EventHandler(this.EslVersin_Click);
            // 
            // ReadEslManufacture
            // 
            this.ReadEslManufacture.Location = new System.Drawing.Point(76, 39);
            this.ReadEslManufacture.Name = "ReadEslManufacture";
            this.ReadEslManufacture.Size = new System.Drawing.Size(92, 23);
            this.ReadEslManufacture.TabIndex = 64;
            this.ReadEslManufacture.Text = "讀取製造資料";
            this.ReadEslManufacture.UseVisualStyleBackColor = true;
            this.ReadEslManufacture.Click += new System.EventHandler(this.ReadEslManufacture_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.WriteEslDataContinueBtn);
            this.groupBox1.Controls.Add(this.WriteEslDataBtn);
            this.groupBox1.Controls.Add(this.CustomerIDEslBtn);
            this.groupBox1.Controls.Add(this.ReadSizeBtn);
            this.groupBox1.Controls.Add(this.tblManufacture);
            this.groupBox1.Controls.Add(this.WriteEslManufacture);
            this.groupBox1.Controls.Add(this.EslBattery);
            this.groupBox1.Controls.Add(this.EslVersin);
            this.groupBox1.Controls.Add(this.ReadEslManufacture);
            this.groupBox1.Controls.Add(this.ReadDeviceNameButton);
            this.groupBox1.Controls.Add(this.WriteDeviceNameButton);
            this.groupBox1.Controls.Add(this.tbDeviceName);
            this.groupBox1.Location = new System.Drawing.Point(517, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 123);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ESL";
            // 
            // WriteEslDataContinueBtn
            // 
            this.WriteEslDataContinueBtn.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.WriteEslDataContinueBtn.ForeColor = System.Drawing.Color.Green;
            this.WriteEslDataContinueBtn.Location = new System.Drawing.Point(171, 95);
            this.WriteEslDataContinueBtn.Name = "WriteEslDataContinueBtn";
            this.WriteEslDataContinueBtn.Size = new System.Drawing.Size(75, 23);
            this.WriteEslDataContinueBtn.TabIndex = 71;
            this.WriteEslDataContinueBtn.Text = "連續寫入";
            this.WriteEslDataContinueBtn.UseVisualStyleBackColor = true;
            this.WriteEslDataContinueBtn.Click += new System.EventHandler(this.WriteEslDataContinueBtn_Click);
            // 
            // WriteEslDataBtn
            // 
            this.WriteEslDataBtn.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.WriteEslDataBtn.ForeColor = System.Drawing.Color.Green;
            this.WriteEslDataBtn.Location = new System.Drawing.Point(171, 66);
            this.WriteEslDataBtn.Name = "WriteEslDataBtn";
            this.WriteEslDataBtn.Size = new System.Drawing.Size(75, 23);
            this.WriteEslDataBtn.TabIndex = 70;
            this.WriteEslDataBtn.Text = "單一寫入";
            this.WriteEslDataBtn.UseVisualStyleBackColor = true;
            this.WriteEslDataBtn.Click += new System.EventHandler(this.WriteEslDataBtn_Click);
            // 
            // CustomerIDEslBtn
            // 
            this.CustomerIDEslBtn.Location = new System.Drawing.Point(171, 12);
            this.CustomerIDEslBtn.Name = "CustomerIDEslBtn";
            this.CustomerIDEslBtn.Size = new System.Drawing.Size(76, 23);
            this.CustomerIDEslBtn.TabIndex = 69;
            this.CustomerIDEslBtn.Text = "Customer ID";
            this.CustomerIDEslBtn.UseVisualStyleBackColor = true;
            this.CustomerIDEslBtn.Click += new System.EventHandler(this.CustomerIDEslBtn_Click);
            // 
            // ReadSizeBtn
            // 
            this.ReadSizeBtn.Location = new System.Drawing.Point(171, 39);
            this.ReadSizeBtn.Name = "ReadSizeBtn";
            this.ReadSizeBtn.Size = new System.Drawing.Size(76, 23);
            this.ReadSizeBtn.TabIndex = 67;
            this.ReadSizeBtn.Text = "讀取尺寸";
            this.ReadSizeBtn.UseVisualStyleBackColor = true;
            this.ReadSizeBtn.Click += new System.EventHandler(this.ReadSizeBtn_Click);
            // 
            // tblManufacture
            // 
            this.tblManufacture.Location = new System.Drawing.Point(101, 67);
            this.tblManufacture.MaxLength = 16;
            this.tblManufacture.Name = "tblManufacture";
            this.tblManufacture.Size = new System.Drawing.Size(67, 22);
            this.tblManufacture.TabIndex = 66;
            this.tblManufacture.Text = "20171226";
            // 
            // WriteEslManufacture
            // 
            this.WriteEslManufacture.Location = new System.Drawing.Point(3, 66);
            this.WriteEslManufacture.Name = "WriteEslManufacture";
            this.WriteEslManufacture.Size = new System.Drawing.Size(92, 23);
            this.WriteEslManufacture.TabIndex = 65;
            this.WriteEslManufacture.Text = "寫入製造資料";
            this.WriteEslManufacture.UseVisualStyleBackColor = true;
            this.WriteEslManufacture.Click += new System.EventHandler(this.WriteEslManufacture_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbTime);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.tbEslTime);
            this.groupBox2.Controls.Add(this.writeEslTimeout);
            this.groupBox2.Controls.Add(this.tbBleTimeout);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.BleTimeout);
            this.groupBox2.Location = new System.Drawing.Point(346, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(165, 100);
            this.groupBox2.TabIndex = 66;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "控制時間";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CustomerIDApBtn);
            this.groupBox3.Controls.Add(this.ApBufferRetrySet);
            this.groupBox3.Controls.Add(this.UpdataReTryCount);
            this.groupBox3.Controls.Add(this.tbBeaconCount);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.tbBeaconEndTime);
            this.groupBox3.Controls.Add(this.tbBeaconStartTime);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.SetBeaconTime);
            this.groupBox3.Controls.Add(this.GetRTCTime);
            this.groupBox3.Controls.Add(this.SetRTCTime);
            this.groupBox3.Controls.Add(this.UpdateEsl);
            this.groupBox3.Controls.Add(this.WriteEslBuffer);
            this.groupBox3.Controls.Add(this.BeaconButton);
            this.groupBox3.Location = new System.Drawing.Point(776, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(254, 149);
            this.groupBox3.TabIndex = 67;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "AP";
            // 
            // CustomerIDApBtn
            // 
            this.CustomerIDApBtn.Location = new System.Drawing.Point(4, 120);
            this.CustomerIDApBtn.Name = "CustomerIDApBtn";
            this.CustomerIDApBtn.Size = new System.Drawing.Size(82, 23);
            this.CustomerIDApBtn.TabIndex = 31;
            this.CustomerIDApBtn.Text = "Customer ID";
            this.CustomerIDApBtn.UseVisualStyleBackColor = true;
            this.CustomerIDApBtn.Click += new System.EventHandler(this.CustomerIDApBtn_Click);
            // 
            // ApBufferRetrySet
            // 
            this.ApBufferRetrySet.Location = new System.Drawing.Point(210, 42);
            this.ApBufferRetrySet.Name = "ApBufferRetrySet";
            this.ApBufferRetrySet.Size = new System.Drawing.Size(41, 23);
            this.ApBufferRetrySet.TabIndex = 29;
            this.ApBufferRetrySet.Text = "設定";
            this.ApBufferRetrySet.UseVisualStyleBackColor = true;
            this.ApBufferRetrySet.Click += new System.EventHandler(this.ApBufferRetrySet_Click);
            // 
            // UpdataReTryCount
            // 
            this.UpdataReTryCount.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.UpdataReTryCount.Location = new System.Drawing.Point(165, 41);
            this.UpdataReTryCount.MaxLength = 3;
            this.UpdataReTryCount.Name = "UpdataReTryCount";
            this.UpdataReTryCount.Size = new System.Drawing.Size(40, 27);
            this.UpdataReTryCount.TabIndex = 28;
            this.UpdataReTryCount.Text = "5";
            // 
            // tbBeaconCount
            // 
            this.tbBeaconCount.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbBeaconCount.Location = new System.Drawing.Point(165, 12);
            this.tbBeaconCount.MaxLength = 3;
            this.tbBeaconCount.Name = "tbBeaconCount";
            this.tbBeaconCount.Size = new System.Drawing.Size(57, 27);
            this.tbBeaconCount.TabIndex = 27;
            this.tbBeaconCount.Text = "128";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(104, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "停止";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(103, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "開始";
            // 
            // tbBeaconEndTime
            // 
            this.tbBeaconEndTime.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbBeaconEndTime.Location = new System.Drawing.Point(137, 98);
            this.tbBeaconEndTime.Name = "tbBeaconEndTime";
            this.tbBeaconEndTime.Size = new System.Drawing.Size(105, 23);
            this.tbBeaconEndTime.TabIndex = 7;
            this.tbBeaconEndTime.Text = "1712261222";
            // 
            // tbBeaconStartTime
            // 
            this.tbBeaconStartTime.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbBeaconStartTime.Location = new System.Drawing.Point(138, 72);
            this.tbBeaconStartTime.Name = "tbBeaconStartTime";
            this.tbBeaconStartTime.Size = new System.Drawing.Size(104, 23);
            this.tbBeaconStartTime.TabIndex = 6;
            this.tbBeaconStartTime.Text = "1712261221";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 5;
            // 
            // SetBeaconTime
            // 
            this.SetBeaconTime.Location = new System.Drawing.Point(4, 94);
            this.SetBeaconTime.Name = "SetBeaconTime";
            this.SetBeaconTime.Size = new System.Drawing.Size(97, 23);
            this.SetBeaconTime.TabIndex = 4;
            this.SetBeaconTime.Text = "設定Beacon時間";
            this.SetBeaconTime.UseVisualStyleBackColor = true;
            this.SetBeaconTime.Click += new System.EventHandler(this.SetBeaconTime_Click);
            // 
            // GetRTCTime
            // 
            this.GetRTCTime.Location = new System.Drawing.Point(4, 66);
            this.GetRTCTime.Name = "GetRTCTime";
            this.GetRTCTime.Size = new System.Drawing.Size(75, 23);
            this.GetRTCTime.TabIndex = 3;
            this.GetRTCTime.Text = "取得時間";
            this.GetRTCTime.UseVisualStyleBackColor = true;
            this.GetRTCTime.Click += new System.EventHandler(this.GetRTCTime_Click);
            // 
            // SetRTCTime
            // 
            this.SetRTCTime.Location = new System.Drawing.Point(4, 40);
            this.SetRTCTime.Name = "SetRTCTime";
            this.SetRTCTime.Size = new System.Drawing.Size(75, 23);
            this.SetRTCTime.TabIndex = 2;
            this.SetRTCTime.Text = "設定時間";
            this.SetRTCTime.UseVisualStyleBackColor = true;
            this.SetRTCTime.Click += new System.EventHandler(this.SetRTCTime_Click);
            // 
            // UpdateEsl
            // 
            this.UpdateEsl.Location = new System.Drawing.Point(83, 40);
            this.UpdateEsl.Name = "UpdateEsl";
            this.UpdateEsl.Size = new System.Drawing.Size(79, 23);
            this.UpdateEsl.TabIndex = 1;
            this.UpdateEsl.Text = "更新ESL";
            this.UpdateEsl.UseVisualStyleBackColor = true;
            this.UpdateEsl.Click += new System.EventHandler(this.UpdateEsl_Click);
            // 
            // WriteEslBuffer
            // 
            this.WriteEslBuffer.Location = new System.Drawing.Point(4, 13);
            this.WriteEslBuffer.Name = "WriteEslBuffer";
            this.WriteEslBuffer.Size = new System.Drawing.Size(75, 23);
            this.WriteEslBuffer.TabIndex = 0;
            this.WriteEslBuffer.Text = "寫入Buffer";
            this.WriteEslBuffer.UseVisualStyleBackColor = true;
            this.WriteEslBuffer.Click += new System.EventHandler(this.WriteEslBuffer_Click);
            // 
            // tbMessageBox
            // 
            this.tbMessageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMessageBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbMessageBox.Location = new System.Drawing.Point(365, 384);
            this.tbMessageBox.Name = "tbMessageBox";
            this.tbMessageBox.Size = new System.Drawing.Size(668, 234);
            this.tbMessageBox.TabIndex = 68;
            this.tbMessageBox.Text = "";
            // 
            // getAPinfo
            // 
            this.getAPinfo.Location = new System.Drawing.Point(180, 110);
            this.getAPinfo.Name = "getAPinfo";
            this.getAPinfo.Size = new System.Drawing.Size(83, 23);
            this.getAPinfo.TabIndex = 69;
            this.getAPinfo.Text = "取得AP列表";
            this.getAPinfo.UseVisualStyleBackColor = true;
            this.getAPinfo.Click += new System.EventHandler(this.getAPinfo_Click);
            // 
            // AP_Connect
            // 
            this.AP_Connect.Location = new System.Drawing.Point(269, 110);
            this.AP_Connect.Name = "AP_Connect";
            this.AP_Connect.Size = new System.Drawing.Size(62, 23);
            this.AP_Connect.TabIndex = 70;
            this.AP_Connect.Text = "AP連線";
            this.AP_Connect.UseVisualStyleBackColor = true;
            this.AP_Connect.Click += new System.EventHandler(this.AP_Connect_Click);
            // 
            // AP_ListBox
            // 
            this.AP_ListBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AP_ListBox.FormattingEnabled = true;
            this.AP_ListBox.ItemHeight = 16;
            this.AP_ListBox.Location = new System.Drawing.Point(228, 167);
            this.AP_ListBox.Name = "AP_ListBox";
            this.AP_ListBox.Size = new System.Drawing.Size(134, 116);
            this.AP_ListBox.TabIndex = 71;
            this.AP_ListBox.SelectedIndexChanged += new System.EventHandler(this.SelectAPIP);
            // 
            // AP_IP_Label
            // 
            this.AP_IP_Label.AutoSize = true;
            this.AP_IP_Label.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AP_IP_Label.ForeColor = System.Drawing.Color.Blue;
            this.AP_IP_Label.Location = new System.Drawing.Point(336, 111);
            this.AP_IP_Label.Name = "AP_IP_Label";
            this.AP_IP_Label.Size = new System.Drawing.Size(84, 16);
            this.AP_IP_Label.TabIndex = 72;
            this.AP_IP_Label.Text = "192.168.1.7";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(232, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 73;
            this.label4.Text = "失敗區";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(230, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 12);
            this.label8.TabIndex = 74;
            this.label8.Text = "搜到的IP";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(427, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 75;
            this.button1.Text = "AP連續";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReadTextFile
            // 
            this.ReadTextFile.Location = new System.Drawing.Point(6, 110);
            this.ReadTextFile.Name = "ReadTextFile";
            this.ReadTextFile.Size = new System.Drawing.Size(38, 23);
            this.ReadTextFile.TabIndex = 76;
            this.ReadTextFile.Text = "讀檔";
            this.ReadTextFile.UseVisualStyleBackColor = true;
            this.ReadTextFile.Click += new System.EventHandler(this.ReadTextFile_Click);
            // 
            // SaveMacToText
            // 
            this.SaveMacToText.Location = new System.Drawing.Point(128, 110);
            this.SaveMacToText.Name = "SaveMacToText";
            this.SaveMacToText.Size = new System.Drawing.Size(38, 23);
            this.SaveMacToText.TabIndex = 77;
            this.SaveMacToText.Text = "存檔";
            this.SaveMacToText.UseVisualStyleBackColor = true;
            this.SaveMacToText.Click += new System.EventHandler(this.SaveMacToText_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listView1.Location = new System.Drawing.Point(6, 167);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(220, 452);
            this.listView1.TabIndex = 78;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // tBCustomerID
            // 
            this.tBCustomerID.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tBCustomerID.Location = new System.Drawing.Point(396, 137);
            this.tBCustomerID.MaxLength = 8;
            this.tBCustomerID.Name = "tBCustomerID";
            this.tBCustomerID.Size = new System.Drawing.Size(115, 25);
            this.tBCustomerID.TabIndex = 30;
            this.tBCustomerID.Text = "FFFFFFFF";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(337, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 79;
            this.label1.Text = "客戶ID :";
            // 
            // cBSize
            // 
            this.cBSize.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cBSize.FormattingEnabled = true;
            this.cBSize.Items.AddRange(new object[] {
            "2.13 吋 (212 x 104)",
            "2.9 吋 (296 x 128)",
            "4.2 吋 (400 x 300)"});
            this.cBSize.Location = new System.Drawing.Point(603, 136);
            this.cBSize.Name = "cBSize";
            this.cBSize.Size = new System.Drawing.Size(167, 24);
            this.cBSize.TabIndex = 70;
            this.cBSize.Text = "2.13 吋 (212 x 104)";
            this.cBSize.SelectedIndexChanged += new System.EventHandler(this.SelectSizeChange);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(518, 141);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 80;
            this.label11.Text = "電子紙尺寸 :";
            // 
            // WriteEslData2Button
            // 
            this.WriteEslData2Button.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.WriteEslData2Button.Location = new System.Drawing.Point(269, 60);
            this.WriteEslData2Button.Name = "WriteEslData2Button";
            this.WriteEslData2Button.Size = new System.Drawing.Size(73, 22);
            this.WriteEslData2Button.TabIndex = 81;
            this.WriteEslData2Button.Text = "Cus寫入";
            this.WriteEslData2Button.UseVisualStyleBackColor = true;
            this.WriteEslData2Button.Click += new System.EventHandler(this.WriteEslData2Button_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(688, 193);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 83;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(384, 173);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(296, 128);
            this.pictureBox1.TabIndex = 84;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 619);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.WriteEslData2Button);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cBSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.tBCustomerID);
            this.Controls.Add(this.SaveMacToText);
            this.Controls.Add(this.ReadTextFile);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AP_IP_Label);
            this.Controls.Add(this.AP_ListBox);
            this.Controls.Add(this.AP_Connect);
            this.Controls.Add(this.getAPinfo);
            this.Controls.Add(this.tbMessageBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SaveFileButton);
            this.Controls.Add(this.ErrorCountLabel);
            this.Controls.Add(this.BleMacCountLabel);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUP);
            this.Controls.Add(this.ErrorEslList);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ContinueWrite);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.leconnect);
            this.Controls.Add(this.BleDisconnect);
            this.Controls.Add(this.WriteEslDataButton);
            this.Controls.Add(this.BleConnect);
            this.Controls.Add(this.ScanBleButton);
            this.Controls.Add(this.leBleMac);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label leBleMac;
        private System.Windows.Forms.Button ScanBleButton;
        private System.Windows.Forms.Button BleConnect;
        private System.Windows.Forms.Button ReadDeviceNameButton;
        private System.Windows.Forms.Button WriteDeviceNameButton;
        private System.Windows.Forms.TextBox tbDeviceName;
        private System.Windows.Forms.Button WriteEslDataButton;
        private System.Windows.Forms.Button BleDisconnect;
        private System.Windows.Forms.Label leconnect;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button ContinueWrite;
        private System.Windows.Forms.Button BeaconButton;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button writeEslTimeout;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbEslTime;
        private System.Windows.Forms.Button BleTimeout;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbBleTimeout;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ListBox ErrorEslList;
        private System.Windows.Forms.Button btnUP;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Label BleMacCountLabel;
        private System.Windows.Forms.Label ErrorCountLabel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button SaveFileButton;
        private System.Windows.Forms.Button EslBattery;
        private System.Windows.Forms.Button EslVersin;
        private System.Windows.Forms.Button ReadEslManufacture;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tblManufacture;
        private System.Windows.Forms.Button WriteEslManufacture;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button UpdateEsl;
        private System.Windows.Forms.Button WriteEslBuffer;
        private System.Windows.Forms.Button SetBeaconTime;
        private System.Windows.Forms.Button GetRTCTime;
        private System.Windows.Forms.Button SetRTCTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbBeaconEndTime;
        private System.Windows.Forms.TextBox tbBeaconStartTime;
        private System.Windows.Forms.TextBox tbBeaconCount;
        private System.Windows.Forms.RichTextBox tbMessageBox;
        private System.Windows.Forms.Button getAPinfo;
        private System.Windows.Forms.Button AP_Connect;
        private System.Windows.Forms.ListBox AP_ListBox;
        private System.Windows.Forms.Label AP_IP_Label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox UpdataReTryCount;
        private System.Windows.Forms.Button ApBufferRetrySet;
        private System.Windows.Forms.Button ReadTextFile;
        private System.Windows.Forms.Button SaveMacToText;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button CustomerIDEslBtn;
        private System.Windows.Forms.Button ReadSizeBtn;
        private System.Windows.Forms.Button CustomerIDApBtn;
        private System.Windows.Forms.TextBox tBCustomerID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBSize;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button WriteEslDataContinueBtn;
        private System.Windows.Forms.Button WriteEslDataBtn;
        private System.Windows.Forms.Button WriteEslData2Button;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

