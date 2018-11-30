using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using static EslUdpTest.Tools;

namespace EslUdpTest
{

    public partial class Form1 : Form
    {
        private string ip = "192.168.1.7";
        private int port = 1200;

        static int errorMax = 5;




       


        private string tag1_1 = "EBUF7E8.1";
        private string tag1_2 = "EBUF7E8.1";
        private string tag1_3 = "C1TMJV85156A-M004";
        private string tag2_1 = "Info:";
        private string tag2_2 = "3";
        private string tag3_1 = "PSM";
        private string tag3_2 = "SECURITY";
        private string tag3_3 = "SSSHR";
        private string tag4_1 = "0.028,L,";
        private string tag4_2 = "193,";
        private string tag4_3 = "AJBX3-1,";
        private string tag4_4 = "BK#331";
        private string tag4_5 = "Tone=";
        private string tag4_6 = "C,";
        private string tag4_7 = "CCD=";
        private string tag4_8 = "0.72, ";
        private string tag4_9 = "PD=";
        private string tag4_10 = "23.08%";
        private string tag4_11 = "Pel=";
        private string tag4_12 = "36,";
        private string tag4_13 = "DD-BO, ";
        private string tag4_14 = "CLIP=";
        private string tag4_15 = "10/13 23:00";
        private string tag5_1 = "AAEEMD";
        private string tag5_2 = "(UL_MOSI_40_C)";
        private string tag6_1 = "QA1/ASI/IPRO/MPM";

        bool scan = false;
        static System.Windows.Forms.Timer ScanTimer = new System.Windows.Forms.Timer();
        static System.Windows.Forms.Timer ConnectTimer = new System.Windows.Forms.Timer();
        static System.Windows.Forms.Timer BeaconTimer = new System.Windows.Forms.Timer();
        static System.Windows.Forms.Timer DisConnectTimer = new System.Windows.Forms.Timer();
        //
        static System.Windows.Forms.Timer BleWriteTimer = new System.Windows.Forms.Timer();//寫入電子紙，怕沒回馬需要多送
        private static System.Windows.Forms.Timer ConnectBleTimeOut = new System.Windows.Forms.Timer();

        private static System.Windows.Forms.Timer ApUpdateTiner = new System.Windows.Forms.Timer();

       // Dictionary<string, int> EslError = new Dictionary<string, int>();
        List<ErrorEslObject> EslErrorList = new List<ErrorEslObject>();
        Dictionary<string, EslObject> mDictSocket = new Dictionary<string, EslObject>();

        //List<ScanEslObject> EslTag = new List<ScanEslObject>();

        delegate void UIInvoker(string data, string deviceIP);
        delegate void ReceiveDataInvoker(EventArgs e);
        delegate void APScanDataInvoker(EventArgs e);

        string t = SELData.b;
        string r = SELData.r;

        bool continuewrite = false;
        bool isRun = false;

        int listcount = 0;
        int totalwritecount = 0;

        Stopwatch stopwatch = new Stopwatch();//引用stopwatch物件
        TimeSpan totleTimeSpan;

        List<string> old = new List<string> { };
      //  int connectTime = 10 * 1000;

        int disConnectCount = 0;

        int ColorSelect = 1;
        ElectronicPriceData mElectronicPriceData = new ElectronicPriceData();
        int BeaconIndex = 0;
        // ManualResetEvent instances signal completion.
        private static ManualResetEvent connectDone = new ManualResetEvent(false);

        Socket client;
        int retry = 5;
        int size = 0; //電子紙尺寸
        int EpaperSize = 0; //電子紙尺寸

        bool import_file_check = false;


        Panel panel1Demo = new Panel();
        public Form1()
        {




            
            Panel panel3Demo = new Panel();
            Panel panel4Demo = new Panel();
            Panel panel5Demo = new Panel();
            Panel panel6Demo = new Panel();
            Label panel6labelDemo = new Label();
            TextBox textBox7Demo = new TextBox();
            TextBox textBox6Demo = new TextBox();
            TextBox textBox5Demo = new TextBox();
            TextBox textBox4Demo = new TextBox();
            TextBox textBox3Demo = new TextBox();
            TextBox textBox18Demo = new TextBox();
            TextBox textBox19Demo = new TextBox();

            TextBox textBox2Demo = new TextBox();
            TextBox textBox1Demo = new TextBox();
            Label label5Demo = new Label();
            Label label3Demo = new Label();
            PictureBox pictureBox2 = new PictureBox();
            Button button2 = new Button();
            Button txtImport = new Button();
           // SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            TextBox textBox8Demo = new TextBox();
            TextBox textBox16Demo = new TextBox();
            TextBox textBox17Demo = new TextBox();




            //  panel1.BackColor = SystemColors.ControlLightLight;

            panel1Demo.Name = "panel1Demo";
            panel1Demo.Size = new Size(296, 128);
            panel1Demo.TabIndex = 3;
            panel1Demo.Paint += new PaintEventHandler(panel1_Paint);


            panel3Demo.BorderStyle = BorderStyle.FixedSingle;
            panel3Demo.Location = new Point(191, 1);
            panel3Demo.Size = new Size(103, 56);
            panel3Demo.TabIndex = 120;
            panel4Demo.BorderStyle = BorderStyle.FixedSingle;
            panel4Demo.Location = new Point(146, 57);
            panel4Demo.Size = new Size(148, 47);
            panel4Demo.TabIndex = 120;
            panel5Demo.BorderStyle = BorderStyle.FixedSingle;
            panel5Demo.Location = new Point(2, 104);
            panel5Demo.Size = new Size(78, 23);
            panel5Demo.TabIndex = 120;

            panel6Demo.BorderStyle = BorderStyle.FixedSingle;
            panel6Demo.Location = new Point(222, 104);
            panel6Demo.Size = new Size(72, 23);
            panel6Demo.TabIndex = 120;


            panel1Demo.Controls.Add(panel3Demo);
            panel1Demo.Controls.Add(panel4Demo);
            panel1Demo.Controls.Add(panel5Demo);
            panel1Demo.Controls.Add(panel6Demo);


            // panel1.Controls.Add(textBox7Demo);
            panel1Demo.Controls.Add(textBox6Demo);
            panel1Demo.Controls.Add(textBox5Demo);
            panel1Demo.Controls.Add(textBox4Demo);

            // panel1.Controls.Add(textBox3Demo);
            // panel1.Controls.Add(textBox2);
            //  panel1.Controls.Add(textBox8Demo);
            // panel1.Controls.Add(textBox16Demo);
            // panel1.Controls.Add(textBox17Demo);
            //panel1.Controls.Add(textBox1);
            // panel1.Controls.Add(label5Demo);
            //panel1.Controls.Add(label3Demo);
            panel1Demo.Controls.Add(pictureBox2);

            panel3Demo.Controls.Add(textBox2Demo);
            panel3Demo.Controls.Add(textBox16Demo);
            panel3Demo.Controls.Add(textBox17Demo);
            panel4Demo.Controls.Add(textBox1Demo);
            panel4Demo.Controls.Add(textBox3Demo);
            panel4Demo.Controls.Add(textBox19Demo);
            panel4Demo.Controls.Add(textBox18Demo);
            panel4Demo.Controls.Add(textBox8Demo);
            panel5Demo.Controls.Add(label5Demo);
            panel5Demo.Controls.Add(textBox7Demo);
            panel6Demo.Controls.Add(label3Demo);
            panel6Demo.Controls.Add(panel6labelDemo);




            textBox7Demo.BorderStyle = BorderStyle.None;
            textBox7Demo.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox7Demo.Location = new Point(3, 7);
            textBox7Demo.ForeColor = Color.Red;
            textBox7Demo.Name = "textBox7Demo";
            textBox7Demo.Size = new Size(60, 15);
            textBox7Demo.TabIndex = 30;
            textBox7Demo.Font = new Font("Calibri", 6);
            textBox7Demo.Text = tag5_2;
            textBox6Demo.BorderStyle = BorderStyle.FixedSingle;
            textBox6Demo.Font = new Font("Cambria", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox6Demo.Location = new Point(80, 104);
            textBox6Demo.Name = "textBox6Demo";
            textBox6Demo.Size = new Size(142, 50);
            textBox6Demo.TabIndex = 29;
            textBox6Demo.Font = new Font("Calibri", 9.6F);
            textBox6Demo.TextAlign = HorizontalAlignment.Center;
            textBox6Demo.Text = tag6_1;

            textBox5Demo.BorderStyle = BorderStyle.FixedSingle;
            textBox5Demo.Font = new Font("Calibri", 11.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox5Demo.Location = new Point(2, 77);
            textBox5Demo.Name = "textBox5Demo";
            textBox5Demo.Size = new Size(144, 10);
            textBox5Demo.TabIndex = 28;
            textBox5Demo.TextAlign = HorizontalAlignment.Center;
            textBox5Demo.Text = tag1_3;
            textBox4Demo.BorderStyle = BorderStyle.FixedSingle;
            textBox4Demo.Font = new Font("Calibri", 11.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox4Demo.Location = new Point(2, 50);
            textBox4Demo.Name = "textBox4Demo";
            textBox4Demo.Size = new Size(144, 10);
            textBox4Demo.TabIndex = 27;
            textBox4Demo.Text = tag1_2;
            textBox4Demo.TextAlign = HorizontalAlignment.Center;
            /*  textBox3Demo.BorderStyle = BorderStyle.None;
              textBox3Demo.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
              textBox3Demo.ForeColor = Color.Red;
              textBox3Demo.Location = new Point(4, 24);
              textBox3Demo.Name = "textBox3Demo";
              textBox3Demo.Size = new Size(139, 15);
              textBox3Demo.TabIndex = 26;
              textBox3Demo.Text = "瑞新電子股份有限公司";*/
            textBox2Demo.BorderStyle = BorderStyle.None;
            textBox2Demo.Font = new Font("Calibri", 13, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2Demo.Location = new Point(20, -3);
            textBox2Demo.Name = "textBox2Demo";
            textBox2Demo.Size = new Size(68, 20);
            textBox2Demo.TabIndex = 25;
            textBox2Demo.Text = tag3_1;
            textBox2Demo.TextAlign = HorizontalAlignment.Center;

            label5Demo.AutoSize = true;
            label5Demo.Font = new Font("Calibri", 5, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5Demo.Location = new Point(27, 0);
            label5Demo.Name = "label5Demo";
            label5Demo.Size = new Size(25, 18);
            label5Demo.TabIndex = 21;
            label5Demo.Font = new Font("Calibri", 6);
            label5Demo.Text = tag5_1;
            label3Demo.AutoSize = true;
            label3Demo.Font = new Font("Calibri", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3Demo.Location = new Point(1, 5);
            label3Demo.Name = "Info";
            label3Demo.Size = new Size(10, 14);
            label3Demo.TabIndex = 19;
            label3Demo.Text = tag2_1;
            panel6labelDemo.AutoSize = false;
            string str = System.AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine("str" + str);
            string filename = str + "circle.jpg";
            panel6labelDemo.Image = Image.FromFile(@filename);
            panel6labelDemo.BackColor = Color.Red;
            panel6labelDemo.Font = new Font("Calibri", 7, FontStyle.Bold, GraphicsUnit.Point, 0);
            panel6labelDemo.Location = new Point(35, 6);
            panel6labelDemo.Name = "Info";
            panel6labelDemo.Size = new Size(19, 19);
            panel6labelDemo.TabIndex = 100;
            panel6labelDemo.Text = tag2_2;
            panel6labelDemo.ForeColor = Color.White;
            panel6labelDemo.TextAlign = ContentAlignment.MiddleCenter;
          //  panel6labelDemo.Paint += new PaintEventHandler(panel6labelDemo_Paint);





            textBox3Demo.BorderStyle = BorderStyle.None;
            textBox3Demo.Font = new Font("Calibri", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3Demo.Location = new Point(4, 3);
            textBox3Demo.Name = "textBox3Demo";
            textBox3Demo.Size = new Size(74, 15);
            textBox3Demo.TabIndex = 26;
            textBox3Demo.Text += (tag4_1 + tag4_2 + tag4_3);
            textBox18Demo.BorderStyle = BorderStyle.None;
            textBox18Demo.Font = new Font("Calibri", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox18Demo.ForeColor = Color.Red;
            textBox18Demo.Location = new Point(103, 3);
            textBox18Demo.Name = "textBox18Demo";
            textBox18Demo.Size = new Size(15, 15);
            textBox18Demo.TabIndex = 229;
            textBox18Demo.Text += (tag4_4);
            textBox18Demo.TextAlign = HorizontalAlignment.Center;

            textBox1Demo.BorderStyle = BorderStyle.None;
            textBox1Demo.Font = new Font("Calibri", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1Demo.Location = new Point(0, 15);
            textBox1Demo.Name = "textBox1Demo";
            textBox1Demo.Size = new Size(139, 15);
            textBox1Demo.TabIndex = 24;
            textBox1Demo.Text += (tag4_5 + tag4_6 + tag4_7 + tag4_8 + tag4_9 + tag4_10);
            textBox1Demo.TextAlign = HorizontalAlignment.Center;
            textBox8Demo.BorderStyle = BorderStyle.None;
            textBox8Demo.Location = new Point(11, 28);
            textBox8Demo.Font = new Font("Calibri", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox8Demo.Name = "textBox8Demo";
            textBox8Demo.Size = new Size(75, 15);
            textBox8Demo.TabIndex = 8;
            textBox8Demo.Text += (tag4_11 + tag4_12 + tag4_13 + tag4_14);
            textBox8Demo.TextAlign = HorizontalAlignment.Center;

            textBox19Demo.BorderStyle = BorderStyle.None;
            textBox19Demo.Font = new Font("Calibri", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox19Demo.ForeColor = Color.Red;
            textBox19Demo.Location = new Point(89, 28);
            textBox19Demo.Name = "textBox19Demo";
            textBox19Demo.Size = new Size(58, 15);
            textBox19Demo.TabIndex = 229;
            textBox19Demo.Text += (tag4_15);
            textBox19Demo.TextAlign = HorizontalAlignment.Center;

            textBox16Demo.BorderStyle = BorderStyle.None;
            textBox16Demo.Location = new Point(20, 12);
            textBox16Demo.Font = new Font("Calibri", 13, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox16Demo.ForeColor = Color.Red;
            textBox16Demo.Name = "textBox16Demo";
            textBox16Demo.BackColor=Color.Red;
            textBox16Demo.Size = new Size(68, 15);
            textBox16Demo.TabIndex = 55;
            textBox16Demo.Text += (tag3_2);
            textBox16Demo.TextAlign = HorizontalAlignment.Center;

            textBox17Demo.BorderStyle = BorderStyle.None;
            textBox17Demo.Location = new Point(0, 28);
            textBox17Demo.Font = new Font("Calibri", 13, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox17Demo.ForeColor = Color.Red;
            textBox17Demo.Name = "textBox16Demo";
            textBox17Demo.Size = new Size(112, 15);
            textBox17Demo.TabIndex = 56;
            textBox17Demo.Text += (tag3_3);
            textBox17Demo.TextAlign = HorizontalAlignment.Center;
            pictureBox2.Location = new Point(3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(146, 46);


            InitializeComponent();
            this.progressBar1.Visible = false;

            ScanTimer.Tick += new EventHandler(TimerEventProcessor);
            ConnectTimer.Tick += new EventHandler(ConnectBle);
            ConnectTimer.Interval = 1000;
            DisConnectTimer.Tick += new EventHandler(DisConnectBle);
            DisConnectTimer.Interval = 500;

            ApUpdateTiner.Tick += new EventHandler(ApUpdateTinerFun);
            ApUpdateTiner.Interval = 500;


            String dateString = String.Format("{0}", DateTime.Now.ToString("yyMMddHHmm"));
            tbBeaconStartTime.Text = dateString;
            tbBeaconEndTime.Text = dateString;

            BleWriteTimer.Interval = (12 * 1000);
            BleWriteTimer.Tick += new EventHandler(WriteESL_TimeOut);

            ConnectBleTimeOut.Interval = (30 * 1000);
            ConnectBleTimeOut.Tick += new EventHandler(ConnectBle_TimeOut);



            listView1.View = View.Details;
            listView1.LabelEdit = true;
            listView1.AllowColumnReorder = true;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Columns.Add("NO", 30, HorizontalAlignment.Left);
            listView1.Columns.Add("MAC", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("電壓", 40, HorizontalAlignment.Left);
            listView1.Columns.Add("尺寸", 40, HorizontalAlignment.Left);


            /*  ListViewItem item1 = new ListViewItem("1", 0);
              item1.SubItems.Add("9991DD50A0BB");
              item1.SubItems.Add("null");
              ListViewItem item2 = new ListViewItem("2", 0);
              item2.SubItems.Add("C3C59450A0BB");
              item2.SubItems.Add("null");
              listView1.Items.AddRange(new ListViewItem[] { item1, item2 });

              import_file_check = true;*/

        }


        public void ProgressBarVisible()
        {
            this.progressBar1.Visible = true; //顯示進度條

            progressBar1.Maximum = 440;//設置最大長度值
            progressBar1.Value = 0;//設置當前值
            progressBar1.Step = 10;//設置沒次增長多少

            /*if (size == 0)
            {
                progressBar1.Maximum = 440;//設置最大長度值
                progressBar1.Value = 0;//設置當前值
                progressBar1.Step = 10;//設置沒次增長多少
            }else
            {
                progressBar1.Maximum = 770;//設置最大長度值
                progressBar1.Value = 0;//設置當前值
                progressBar1.Step = 10;//設置沒次增長多少
            }*/

           
        }


        #region Button
        //掃描 ESL 
        private void ScanBleButton_Click(object sender, EventArgs e)
        {
            continuewrite = false;
            if (scan == false)
            {
                scan = true;
                ScanBleButton.Text = "Stop";
                ScanBleButton.ForeColor = Color.Red;
                ConnectBleTimeOut.Stop();

                foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
                {
                    if (kvp.Key.Contains(AP_IP_Label.Text))
                    {
                       // kvp.Value.mSmcEsl.startScanBleDevice(65535);
                        kvp.Value.mSmcEsl.startScanBleDevice(); // 18小時
                    }
                }

                tbMessageBox.Text = "";

                stopwatch.Reset();
                stopwatch.Start();
                
                ScanTimer.Interval = 255 * 1000;
                ScanTimer.Start();
            }
            else
            {
                //取消掃描
                ScanTimer.Stop();
                ScanBleButton.Text = "Start Scan Ble";
                ScanBleButton.ForeColor = Color.Black;
                scan = false;
                foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
                {
                    if (kvp.Key.Contains(AP_IP_Label.Text))
                    {
                        kvp.Value.mSmcEsl.stopScanBleDevice();
                    }
                }
            }
        }

        // This is the method to run when the timer is raised.
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            ScanTimer.Stop();
            ScanBleButton.Text = "Start Scan Ble";
            ScanBleButton.ForeColor = Color.Black;
            scan = false;
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                kvp.Value.mSmcEsl.stopScanBleDevice();
            }
        }
        //選擇MAC
        private void SelectBleMac(object sender, EventArgs e)
        {
           /* try
            {
                leBleMac.Text = BleMacList.SelectedItem.ToString();
                listcount = BleMacList.SelectedIndex;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }*/
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    listView1.Items[i].ForeColor = Color.Black;
                }

                ListView.SelectedListViewItemCollection breakfast = this.listView1.SelectedItems;
                int index = 0;
                foreach (ListViewItem item in breakfast)
                {
                    item.ForeColor = System.Drawing.Color.Blue;
                    leBleMac.Text = item.SubItems[1].Text;
                }
                if (listView1.SelectedItems.Count > 0)
                {
                    listcount = listView1.Items.IndexOf(listView1.SelectedItems[0]);
                   // Console.WriteLine(listcount);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        // ESL 連線
        private void BleConnect_Click(object sender, EventArgs e)
        {
            ConnectBleTimeOut.Stop();
            ScanTimer.Stop();
            ScanBleButton.Text = "Start Scan Ble";
            ScanBleButton.ForeColor = Color.Black;
            scan = false;
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.stopScanBleDevice();
                }
            }

            Thread.Sleep(100);

            stopwatch.Reset();
            stopwatch.Start();
            isRun = true;

            /* EslError.Clear();
             ListView.ListViewItemCollection breakfast = listView1.Items;
             foreach (ListViewItem item in breakfast)
             {
                 EslError.Add(item.SubItems[1].Text, 0);
             }
             */
            EslErrorList.Clear();
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                ErrorEslObject mErrorEslObject = new ErrorEslObject();
                mErrorEslObject.mac = listView1.Items[i].SubItems[1].ToString();
                mErrorEslObject.error = 0;
                EslErrorList.Add(mErrorEslObject);
            }

            continuewrite = false;
           // mSmcEsl.ConnectBleDevice(leBleMac.Text);
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.ConnectBleDevice(leBleMac.Text);
                }
            }
            ConnectBleTimeOut.Start();

            leconnect.Text = "嘗試連線中請稍候...";
            leconnect.ForeColor = Color.Blue;
            tbMessageBox.Text = leBleMac.Text + "  嘗試連線中請稍候... \r\n";
        }
        // 與 ESL 斷線
        private void BleDisconnect_Click(object sender, EventArgs e)
        {
            ConnectBleTimeOut.Stop();
            continuewrite = false;
           // mSmcEsl.DisConnectBleDevice();
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.DisConnectBleDevice();
                }
            }
        }

        // 取得 ESL Ble 名稱
        private void ReadDeviceNameButton_Click(object sender, EventArgs e)
        {
           // mSmcEsl.ReadBleDeviceName();
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.ReadBleDeviceName();
                }
            }
        }

        // 寫入 ESL Ble 名稱 12 bytes
        private void WriteDeviceNameButton_Click(object sender, EventArgs e)
        {
            //mSmcEsl.WriteBleDeviceName(tbDeviceName.Text);
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.WriteBleDeviceName(tbDeviceName.Text);
                }
            }
        }

        //寫入 ESL 資料
        private void WriteEslDataButton_Click(object sender, EventArgs e) //把資料寫進電子紙內
        {
            stopwatch.Reset();
            stopwatch.Start();//碼表開始計時

            BleWriteTimer.Start();

            ProgressBarVisible();
            continuewrite = false;
            //listcount = 0;
           // mSmcEsl.setHexData(t, r);
           // mSmcEsl.WriteESLDataWithBle();
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.setHexData(t, r);
                    kvp.Value.mSmcEsl.WriteESLDataWithBle();
                }
            }
        }



        //連續寫入 ESL 按鈕
        private void ContinueWrite_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            stopwatch.Start();//碼表開始計時

            BleWriteTimer.Start();

            ProgressBarVisible();
            continuewrite = true;
           // listcount = 0;
            ColorSelect = 1;
            Bitmap bmp = mElectronicPriceData.setPage1(leBleMac.Text);
           // mSmcEsl.TransformImageToData(bmp);
           // mSmcEsl.WriteESLDataWithBle();
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.TransformImageToData(bmp);
                    kvp.Value.mSmcEsl.WriteESLDataWithBle();
                }
            }
        }

        //設定 Beacon Data
        private void BeaconButton_Click(object sender, EventArgs e)
        {
            BeaconIndex = 0; //Count
           // mSmcEsl.WriteBeaconData("ESL143AP01", "000000000000", false);
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.WriteBeaconData("ESL143AP01", "000000000000", false);
                }
            }
        }

       //設定連線 timeout
        private void button2_Click(object sender, EventArgs e)
        {
           // connectTime = Convert.ToInt32(tbTime.Text) * 1000;
        }

        //------------------------------- New --------------------------------------------------
        // 讀取 ESL 的電壓
        private void EslBattery_Click(object sender, EventArgs e)
        {
            //mSmcEsl.ReadEslBattery();
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.ReadEslBattery();
                }
            }
        }
        // 讀取 ESL 版本
        private void EslVersin_Click(object sender, EventArgs e)
        {
           // mSmcEsl.ReadEslVersion();
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.ReadEslVersion();
                }
            }
        }
        // 讀取 ESL 的製造資料
        private void ReadEslManufacture_Click(object sender, EventArgs e)
        {
           // mSmcEsl.ReadManufactureData();
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.ReadManufactureData();
                }
            }
        }

        // 寫入 ESL 的製造資料 12 Byte
        private void WriteEslManufacture_Click(object sender, EventArgs e)
        {
            //mSmcEsl.WriteManufactureData(tblManufacture.Text);
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.WriteManufactureData(tblManufacture.Text);
                }
            }
        }
        // 將資料寫進 AP Buffer
        private void WriteEslBuffer_Click(object sender, EventArgs e)
        {
            if (leBleMac.Text.Equals("000000000000"))
            {
                MessageBox.Show("請先選擇MAC Adress");
                return;
            }

            buffercontineu = false;

            // Bitmap bmp = mElectronicPriceData.setPage1(leBleMac.Text);
            Bitmap bmp = null;

            // mSmcEsl.TransformImageToData(bmp);
            // mSmcEsl.writeESLDataBuffer(BleMacList.SelectedItem.ToString());

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].ForeColor = Color.Black;
                if (listView1.Items[i].SubItems[1].Text.Equals(leBleMac.Text))
                {
                    if (listView1.Items[i].SubItems[3].Text.Equals("02") || size == 2)
                    {
                        bmp = mElectronicPriceData.setESLimage_42(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                    }
                    else if (listView1.Items[i].SubItems[3].Text.Equals("01") || size == 1)
                    {
                        Console.WriteLine("---------------");
                        bmp = mElectronicPriceData.setESLimage_29(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                        //bmp = mElectronicPriceData.setESLimageDemo_29(panel1Demo, tag1_1);
                        
                    }
                    else
                    {
                        bmp = mElectronicPriceData.setESLimage(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                    }

                    listView1.Items[i].ForeColor = Color.Blue;
                }
            }


            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text)) {
                    kvp.Value.mSmcEsl.TransformImageToData(bmp);
                    kvp.Value.mSmcEsl.writeESLDataBuffer(leBleMac.Text, 0);
                }
            }

            tbMessageBox.AppendText(Environment.NewLine + "資料寫入中...");

            tbMessageBox.SelectionStart = tbMessageBox.Text.Length;
            tbMessageBox.ScrollToCaret();

        }
        // 開始從 AP Buffer 的資料更新ESL
        private void UpdateEsl_Click(object sender, EventArgs e)
        {
            // mSmcEsl.UpdataESLDataFromBuffer(BleMacList.SelectedItem.ToString(), 0, 6);
            if (leBleMac.Text.Equals("000000000000"))
            {
                MessageBox.Show("請先選擇MAC Adress");
                return;
            }
            int selectSize = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].ForeColor = Color.Black;
                if (listView1.Items[i].SubItems[1].Text.Equals(leBleMac.Text))
                {
                    if (listView1.Items[i].SubItems[3].Text.Equals("02") || size == 2)
                    {
                        selectSize = 2;
                    }
                    else if(listView1.Items[i].SubItems[3].Text.Equals("01") || size == 1)
                    {
                        selectSize = 1;
                    }
                    else
                    {
                        selectSize = 0;
                    }
                }
            }


            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    SmcEsl mSmcEsl = kvp.Value.mSmcEsl;
                    mSmcEsl.UpdataESLDataFromBuffer(leBleMac.Text, selectSize, retry, 0); // mac  type  count  buffer
                }
            }
            tbMessageBox.AppendText(Environment.NewLine + "更新電子紙...");

            tbMessageBox.SelectionStart = tbMessageBox.Text.Length;
            tbMessageBox.ScrollToCaret();
        }
        //設定 AP 的時間
        private void SetRTCTime_Click(object sender, EventArgs e)
        {
            int yy = int.Parse(String.Format("{0}", DateTime.Now.ToString("yy")));
            int MM = int.Parse(String.Format("{0}", DateTime.Now.ToString("MM")));
            int dd = int.Parse(String.Format("{0}", DateTime.Now.ToString("dd")));
            int HH = int.Parse(String.Format("{0}", DateTime.Now.ToString("HH")));
            int mm = int.Parse(String.Format("{0}", DateTime.Now.ToString("mm")));
            int ss = int.Parse(String.Format("{0}", DateTime.Now.ToString("ss")));
            String dateString = String.Format("{0}", DateTime.Now.ToString("MM/dd/yyyy"));
            DateTime Week = DateTime.Parse(dateString, CultureInfo.InvariantCulture);
            //mSmcEsl.setRTCTime(yy, MM, dd, (int)Week.DayOfWeek, HH, mm, ss);
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.setRTCTime(yy, MM, dd, (int)Week.DayOfWeek, HH, mm, ss);
                }
            }
        }

        //取得 AP 的時間
        private void GetRTCTime_Click(object sender, EventArgs e)
        {
            //mSmcEsl.getRTCTime();
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.getRTCTime();
                }
            }
        }

        //設定 AP Beacon 的開始時間與結束時間
        private void SetBeaconTime_Click(object sender, EventArgs e)
        {
            string startTimes = tbBeaconStartTime.Text.ToString();
            if (startTimes.Length < 10) return;

            string endTimes = tbBeaconEndTime.Text.ToString();
            if (endTimes.Length < 10) return;

            int yy = int.Parse(startTimes.Substring(0, 2));
            int MM = int.Parse(startTimes.Substring(2, 2));
            int dd = int.Parse(startTimes.Substring(4, 2));
            int HH = int.Parse(startTimes.Substring(6, 2));
            int mm = int.Parse(startTimes.Substring(8, 2));

            int eyy = int.Parse(endTimes.Substring(0, 2));
            int eMM = int.Parse(endTimes.Substring(2, 2));
            int edd = int.Parse(endTimes.Substring(4, 2));
            int eHH = int.Parse(endTimes.Substring(6, 2));
            int emm = int.Parse(endTimes.Substring(8, 2));

          //  mSmcEsl.setBeaconTime(yy, MM, dd, HH, mm, eyy, eMM, edd, eHH, emm);
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.setBeaconTime(yy, MM, dd, HH, mm, eyy, eMM, edd, eHH, emm);
                }
            }
        }



        #endregion

        #region Even


        //其他回傳處理

      
        //---------- 超時回傳處理 ----------------
        private void ConnectBle(object sender, EventArgs e)
        {
            ConnectTimer.Stop();
            if (listView1.Items.Count == 0) return;


            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].ForeColor = Color.Black;
            }

            leBleMac.Text = listView1.Items[listcount].SubItems[1].Text;
            listView1.Items[listcount].ForeColor = Color.Blue;



            //BleMacList.SetSelected(listcount, true);

            //tbMessageBox.SelectionColor = Color.FromArgb(0, 0, 0);
            tbMessageBox.AppendText(Environment.NewLine + DateTime.Now.ToString("HH:mm:ss") + " =>" + "正連接: " + leBleMac.Text);

            tbMessageBox.SelectionStart = tbMessageBox.Text.Length;
            tbMessageBox.ScrollToCaret();
            // mSmcEsl.ConnectBleDevice(leBleMac.Text);
            ConnectBleTimeOut.Start();
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {

                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.ConnectBleDevice(leBleMac.Text);
                }
            }

        }

        private void DisConnectBle(object sender, EventArgs e)
        {
            ConnectTimer.Start();
            disConnectCount++;
            string mac = listView1.Items[listcount].SubItems[1].Text;

            for(int i = 0; i < EslErrorList.Count; i++)
            {
                if (EslErrorList[i].mac.Equals(mac))
                {
                    int error = EslErrorList[i].error;
                    error++;
                    EslErrorList[i].error = error;
                    break;
                }
            }

          /*  int error = EslError[mac];
            error++;
            EslError[mac] = error;*/

            if (disConnectCount > errorMax)
            {
                disConnectCount = 0;
                ErrorEslList.Items.Add(mac);
                listView1.Items[listcount].Remove();

                BleMacCountLabel.Text = listView1.Items.Count + "";
                ErrorCountLabel.Text = ErrorEslList.Items.Count + "";

                if (listView1.Items.Count < listcount + 1)
                {
                    listcount = 0;
                }
                if (listView1.Items.Count > 0)
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        listView1.Items[i].ForeColor = Color.Black;
                    }

                    leBleMac.Text = listView1.Items[listcount].SubItems[1].Text;

                    listView1.Items[listcount].ForeColor = Color.Blue;
                }
            }
            DisConnectTimer.Stop();
        }



        private void ApUpdateTinerFun(object sender, EventArgs e)
        {
            ApUpdateTiner.Stop();
            disConnectCount++;
            string mac = listView1.Items[listcount].SubItems[1].Text;
          /*  int error = EslError[mac];
            error++;
            EslError[mac] = error;*/

            for (int i = 0; i < EslErrorList.Count; i++)
            {
                if (EslErrorList[i].mac.Equals(mac))
                {
                    int error = EslErrorList[i].error;
                    error++;
                    EslErrorList[i].error = error;
                    break;
                }
            }


            /*foreach (KeyValuePair<string, int> kvp in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }*/
            if (disConnectCount > 2)
            {
                disConnectCount = 0;
                ErrorEslList.Items.Add(mac);
                listView1.Items[listcount].Remove();

                BleMacCountLabel.Text = listView1.Items.Count + "";
                ErrorCountLabel.Text = ErrorEslList.Items.Count + "";

               /* if (listView1.Items.Count < listcount + 1)
                {
                    listcount = 0;
                }*/
                if (listView1.Items.Count > 0)
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        listView1.Items[i].ForeColor = Color.Black;
                    }
                    leBleMac.Text = listView1.Items[listcount].SubItems[1].Text;
                    listView1.Items[listcount].ForeColor = Color.Blue;

                    Bitmap bmp = mElectronicPriceData.setESLimage(leBleMac.Text, listView1.Items[listcount].SubItems[2].Text);

                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        listView1.Items[i].ForeColor = Color.Black;
                        if (listView1.Items[i].SubItems[1].Text.Equals(leBleMac.Text))
                        {
                            if (listView1.Items[i].SubItems[3].Text.Equals("02") || size == 2)
                            {
                                bmp = mElectronicPriceData.setESLimage_42(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                            }
                            else if (listView1.Items[i].SubItems[3].Text.Equals("01") || size == 1)
                            {
                                bmp = mElectronicPriceData.setESLimage_29(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                            }
                            else
                            {
                                bmp = mElectronicPriceData.setESLimage(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                            }

                           // listView1.Items[i].ForeColor = Color.Blue;
                        }
                    }


                    foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
                    {
                        if (kvp.Key.Contains(AP_IP_Label.Text))
                        {
                            kvp.Value.mSmcEsl.TransformImageToData(bmp);
                            kvp.Value.mSmcEsl.writeESLDataBuffer(leBleMac.Text, 0);
                            stopwatch.Reset();
                            stopwatch.Start();//碼表開始計時
                            break;
                        }
                    }
                }

            }
            else
            {

                int selectSize = 0;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    listView1.Items[i].ForeColor = Color.Black;
                    if (listView1.Items[i].SubItems[1].Text.Equals(leBleMac.Text))
                    {
                        if (listView1.Items[i].SubItems[3].Text.Equals("02") || size == 2)
                        {
                            selectSize = 2;
                        }
                        else if (listView1.Items[i].SubItems[3].Text.Equals("01") || size == 1)
                        {
                            selectSize = 1;
                        }
                        else
                        {
                            selectSize = 0;
                        }
                    }
                }


                // mac = listView1.Items[listcount].SubItems[1].Text;
                foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
                {
                    if (kvp.Key.Contains(AP_IP_Label.Text))
                    {
                        kvp.Value.mSmcEsl.UpdataESLDataFromBuffer(mac, selectSize, retry, 0); //mac  type  count  buffer
                        break;
                    }
              }
            }

  
        }


        #endregion

        //---------------


        //==================================================================================
        //--------------------------  其他設定  -----------------------------------------------
        #region Even


        //資料傳輸超時，斷線
        private void WriteESL_TimeOut(object sender, EventArgs e)
        {

            BleWriteTimer.Stop();
            this.progressBar1.Visible = false;
             foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
             {
                 if (kvp.Key.Contains(AP_IP_Label.Text))
                 {
                     kvp.Value.mSmcEsl.DisConnectBleDevice();
                 }
             }
        }
        //藍牙連線超過時間
        private void ConnectBle_TimeOut(object sender, EventArgs e)
        {
            ConnectBleTimeOut.Stop();
            this.progressBar1.Visible = false; //隱藏進度條
            leconnect.Text = "連線超時...";
            leconnect.ForeColor = Color.Red;
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.DisConnectBleDevice();
                }
            }

        }


        private void SMCEslReceiveEvent(object sender, EventArgs e)
        {
            ReceiveDataInvoker stc = new ReceiveDataInvoker(ReceiveData);
            this.BeginInvoke(stc, e);
        }

        private void ScanUI(string data, string deviceIP, double battery)
        {
            string RssiS = "";
            string sizes = "0";

            if (data.Length == 14)
            {
                Console.WriteLine("ddddddddd");
                RssiS = data.Substring(data.Length - 2, 2);
                data = data.Substring(0, data.Length - 2);
            }
            else if (data.Length == 16)
            {
                Console.WriteLine("dddddfafaf");
                RssiS = data.Substring(12, 2);
                sizes = data.Substring(14, 2);
                data = data.Substring(0, 12);
            }


            if (!sizes.Equals("0") || !sizes.Equals("01") || !sizes.Equals("02"))
            {
                sizes = "0";
            }

            if (sizes.Equals("FF"))
            {
                return;
            }
            
            bool check = false;
            //EslTag.Add(data, battery);
           // string mac = listView1.Items[listcount].SubItems[0].Text;
            for (int i = (listView1.Items.Count - 1); i > -1; i--)
            {
                if (listView1.Items[i].SubItems[1].Text.ToString() == data)
                {
                    //EslTag.Add(data, battery);

                    //  ScanEslObject esl = new ScanEslObject();
                    //    esl.mac = input;
                    //    esl.battery = "null";
                    if (import_file_check == true)
                    {
                        listView1.Items[i].SubItems[2].Text = "" + battery;
                    }
                    listView1.Items[i].SubItems[3].Text = "" + sizes;

                    check = true;
                    break;
                }
            }
            if (import_file_check == true)
            {
                Console.WriteLine("T1");

                bool scancheck = false;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[2].Text.Equals("null"))
                    {
                        listView1.Items[i].SubItems[3].Text = "" + sizes;
                        scancheck = true;
                        break;
                    }
                }
                if (scancheck == false)
                {
                    Console.WriteLine("T2");
                    ScanTimer.Stop();
                    ScanBleButton.Text = "Start Scan Ble";
                    ScanBleButton.ForeColor = Color.Black;
                    scan = false;
                    foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
                    {
                        if (kvp.Key.Contains(deviceIP))
                        {
                            kvp.Value.mSmcEsl.stopScanBleDevice();
                        }
                    }
                  
                    string str_data = listView1.Items.Count + ":  " + data + " , RSS = " + (0 - (int)Convert.ToByte(RssiS, 16)) + "  Battery = " + battery + "V\n";
                        tbMessageBox.Text = tbMessageBox.Text + str_data;
                    tbMessageBox.SelectionStart = tbMessageBox.Text.Length;
                    tbMessageBox.ScrollToCaret();

                    /*  BleMacList.SelectedIndex = 0;
                      leBleMac.Text = BleMacList.SelectedItem.ToString();
                      listcount = BleMacList.SelectedIndex;*/

                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        listView1.Items[i].ForeColor = Color.Black;
                    }


                    leBleMac.Text = listView1.Items[0].SubItems[1].Text;
                    //listView1.Items[0].Selected = true;
                    listcount = 0;
                    listView1.Items[0].ForeColor = Color.Blue;
                    MessageBox.Show("電壓全部取得");

                }
            }


           if (check == false && import_file_check == false)
            {
                   if ((int)Convert.ToByte(RssiS, 16) < 65)
                {
                Console.WriteLine("T3");
                Console.WriteLine("data:"+data + " battery:" + battery+ " sizes" + sizes);
                    ListViewItem item1 = new ListViewItem(listView1.Items.Count + 1 + "", data);
                    item1.SubItems.Add("" + data);
                    item1.SubItems.Add("" + battery);
                    item1.SubItems.Add("" + sizes);
                    listView1.Items.AddRange(new ListViewItem[] { item1 });
                    BleMacCountLabel.Text = listView1.Items.Count + "";


                    stopwatch.Stop();//碼錶停止
                    TimeSpan ts = stopwatch.Elapsed;
                    string elapsedTime = String.Format("{0:00} 分 {1:00} 秒 {2:000} ms", ts.Minutes, ts.Seconds, ts.Milliseconds);
                    string str_data = listView1.Items.Count + ":  " + data + " , RSS = " + (int)Convert.ToByte(RssiS, 16) + "  Battery = " + battery + "V ,  Scan Time = " + elapsedTime + "  IP = "
                        + deviceIP + "\n";




                    /*tbMessageBox.Text = tbMessageBox.Text + str_data;
                    tbMessageBox.SelectionStart = tbMessageBox.Text.Length;
                    tbMessageBox.ScrollToCaret();*/

                    tbMessageBox.BeginInvoke(
                        new RichTextBoxUpdateEventHandler(UpdateRichTextBox), // the method to call back on
                        new object[] { str_data });


                    stopwatch.Reset();
                    stopwatch.Start();
                }
            }else
            {
                Console.WriteLine("T4");
                string str_data = listView1.Items.Count + ":  " + data + " , RSS = " + (0 - (int)Convert.ToByte(RssiS, 16)) + "  Battery = " + battery + "V \n";

                tbMessageBox.BeginInvoke(
                   new RichTextBoxUpdateEventHandler(UpdateRichTextBox), // the method to call back on
                   new object[] { str_data });

               /* tbMessageBox.Text = tbMessageBox.Text + str_data;
                tbMessageBox.SelectionStart = tbMessageBox.Text.Length;
                tbMessageBox.ScrollToCaret();*/

            }
        }
        //-----------------------------   接收回傳資料 UI處理 ---------------------------
        private void ReceiveData(EventArgs e)
        {
            int msgId = (e as SmcEsl.SMCEslReceiveEventArgs).msgId;
            bool status = (e as SmcEsl.SMCEslReceiveEventArgs).status;
            string deviceIP = (e as SmcEsl.SMCEslReceiveEventArgs).apIP;
            string data = (e as SmcEsl.SMCEslReceiveEventArgs).data;

            double battery = (e as SmcEsl.SMCEslReceiveEventArgs).battery;

            string str_data = "";

            //掃描
            if (msgId == SmcEsl.msg_ScanDevice)
            {
                ScanUI(data, deviceIP, battery);
            }

            // 藍牙連線
            else if (msgId == SmcEsl.msg_ConnectEslDevice)
            {
                if (status)
                {
                    str_data = "連線成功";
                    //    tbMessageBox.SelectionColor = Color.FromArgb(60, 119, 119);

                    ConnectTimer.Stop();
                    ConnectBleTimeOut.Stop();
                    leconnect.Text = "連線成功";
                    leconnect.ForeColor = Color.Blue;
                    disConnectCount = 0;


                    if (continuewrite == true)
                    {
                        DisConnectTimer.Stop();
                        ProgressBarVisible();

                        if (ColorSelect == 5)//尺寸分開寫入
                        {
                            Bitmap bmp = null;
                            for (int i = 0; i < listView1.Items.Count; i++)
                            {
                                listView1.Items[i].ForeColor = Color.Black;
                                if (listView1.Items[i].SubItems[1].Text.Equals(leBleMac.Text))
                                {
                                    if (listView1.Items[i].SubItems[3].Text.Equals("02") || size == 2)
                                    {
                                        bmp = mElectronicPriceData.setESLimage_42(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                                        progressBar1.Maximum = 2400;//設置最大長度值
                                        progressBar1.Value = 0;//設置當前值
                                        progressBar1.Step = 10;//設置沒次增長多少
                                    }
                                    else if (listView1.Items[i].SubItems[3].Text.Equals("01") || size == 1)
                                    {
                                        bmp = mElectronicPriceData.setESLimage_29(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                                        progressBar1.Maximum = 770;//設置最大長度值
                                        progressBar1.Value = 0;//設置當前值
                                        progressBar1.Step = 10;//設置沒次增長多少
                                    }
                                    else
                                    {
                                        bmp = mElectronicPriceData.setESLimage(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                                        progressBar1.Maximum = 440;//設置最大長度值
                                        progressBar1.Value = 0;//設置當前值
                                        progressBar1.Step = 10;//設置沒次增長多少
                                    }

                                    listView1.Items[i].ForeColor = Color.Blue;
                                }
                            }

                            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
                            {
                                if (kvp.Key.Contains(AP_IP_Label.Text))
                                {
                                    kvp.Value.mSmcEsl.TransformImageToData(bmp);
                                    kvp.Value.mSmcEsl.WriteESLDataWithBle2(tBCustomerID.Text);
                                }
                            }


                            return;
                        }


                        if (ColorSelect == 1)//一班寫入
                        {
                            string mac = listView1.Items[listcount].SubItems[1].Text;
                            Bitmap bmp = mElectronicPriceData.setPage1(mac);
                            // mSmcEsl.TransformImageToData(bmp);
                            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
                            {
                                if (kvp.Key.Contains(AP_IP_Label.Text))
                                {
                                    kvp.Value.mSmcEsl.TransformImageToData(bmp);
                                }
                            }
                        }
                        else if (ColorSelect == 2)
                        { //黑
                           // mSmcEsl.setBlackData();
                            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
                            {
                                if (kvp.Key.Contains(AP_IP_Label.Text))
                                {
                                    kvp.Value.mSmcEsl.setBlackData();
                                }
                            }
                        }
                        else if (ColorSelect == 3)
                        { //白
                            //mSmcEsl.setWhileData();
                            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
                            {
                                if (kvp.Key.Contains(AP_IP_Label.Text))
                                {
                                    kvp.Value.mSmcEsl.setWhileData();
                                }
                            }
                        }
                        else if (ColorSelect == 4)
                        { //紅
                           // mSmcEsl.setRedData();
                            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
                            {
                                if (kvp.Key.Contains(AP_IP_Label.Text))
                                {
                                    kvp.Value.mSmcEsl.setRedData();
                                }
                            }
                        }

                       // mSmcEsl.WriteESLDataWithBle();
                        foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
                        {
                            if (kvp.Key.Contains(AP_IP_Label.Text))
                            {
                                BleWriteTimer.Start();
                                kvp.Value.mSmcEsl.WriteESLDataWithBle();
                            }
                        }



                    }
                   
                }
                else
                {
                    str_data = "連線失敗";
                    leconnect.Text = "連線失敗";
                    leconnect.ForeColor = Color.Red;
                    DisConnectTimer.Stop();
                    ConnectBleTimeOut.Stop();
                    if (continuewrite)
                    {
                        DisConnectTimer.Start();
                        // ConnectTimer.Interval = 4000;
                        // ConnectTimer.Start();
                    }
                }
            }
            // 藍牙斷線
            else if (msgId == SmcEsl.msg_DisconnectEslDevice)
            {
                ConnectBleTimeOut.Stop();
                if (status)
                {
                    str_data = "斷線成功";
                    this.progressBar1.Visible = false; //隱藏進度條


                    DisConnectTimer.Stop();

                    leconnect.Text = "斷線成功";
                    leconnect.ForeColor = Color.Red;
                    if (continuewrite)
                    {
                        data = "斷線成功";
                        DisConnectTimer.Start();
                    /*    ConnectTimer.Interval = 1000;
                        ConnectTimer.Start();*/
                    }
                }
                else
                {
                    leconnect.Text = "斷線失敗";
                    str_data = "斷線失敗";
                    if (isRun && continuewrite)
                    {
                        DisConnectTimer.Start();
                    }
                }
            }
            // 取得藍牙名稱
            else if (msgId == SmcEsl.msg_ReadEslName)
            {
                str_data = "Device Name : " + data;
            }
            // 寫入設備名稱
            else if (msgId == SmcEsl.msg_WriteEslName)
            {
                if (status)
                {
                    str_data = "Esl 名稱更新成功";
                }
                else
                {
                    str_data = "Esl 名稱更新失敗";
                }
            }
            // 寫入ESL資料
            else if (msgId == SmcEsl.msg_WriteEslData)
            {
                if (status)
                {
                //    Console.WriteLine("資料寫入成功");
                    progressBar1.Value += progressBar1.Step;
                    str_data = "資料寫入成功";
                }
                else
                {
                    str_data = "資料寫入失敗";
                }
            }
            // 寫入ESL資料，全部寫完
            else if (msgId == SmcEsl.msg_WriteEslDataFinish)
            {

                BleWriteTimer.Stop();
                str_data = "全部資料寫入成功";
                this.progressBar1.Visible = false; //顯示進度條

                stopwatch.Stop();//碼錶停止
                TimeSpan ts = stopwatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00} 分 {1:00} 秒 {2:000} 毫秒", ts.Minutes, ts.Seconds, ts.Milliseconds);

                totleTimeSpan = totleTimeSpan + ts;
                double totletime = totleTimeSpan.TotalMilliseconds;
                totletime = totletime / totalwritecount / 1000;
                totletime = Math.Round(totletime, 3);
                string average = totletime.ToString();
                //Console.WriteLine("msg_WriteEslDataFinish");
                if (continuewrite)
                {
                    if (listcount + 1 < listView1.Items.Count)
                    {
                        listcount++;
                    }
                    else
                    {
                        listcount = 0;
                    }
                    foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
                    {
                        if (kvp.Key.Contains(AP_IP_Label.Text))
                        {
                            kvp.Value.mSmcEsl.DisConnectBleDevice();
                        }
                    }
                    totalwritecount++;
                    stopwatch.Reset();
                    stopwatch.Start();//碼表開始計時
                }
                str_data = "  -> MAC:" + leBleMac.Text + "  成功" + ", 執行時間 = " + elapsedTime + ", 總時間 = " + totleTimeSpan + ", 平均 = " + average + ", 總次數 = " + totalwritecount;
               
            }
            // 寫入AP Beacon Data
            else if (msgId == SmcEsl.msg_WriteBeacon)
            {
                if (status)
                {
                    str_data = "Beacon更新成功";
                    // tbBeaconCount
                    BeaconIndex++;
                    string EID = "000000000000";

                    if (BeaconIndex < 10)
                    {
                        EID = "00000000000" + BeaconIndex;
                    }
                    else if (BeaconIndex > 10 && BeaconIndex < 100)
                    {
                        EID = "0000000000" + BeaconIndex;
                    }
                    else
                    {
                        EID = "000000000" + BeaconIndex;
                    }

                    if (BeaconIndex < int.Parse(tbBeaconCount.Text.ToString()) - 1)
                    {
                        //mSmcEsl.WriteBeaconData("ESL143AP01", EID, false);
                        foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
                        {
                            if (kvp.Key.Contains(AP_IP_Label.Text))
                            {
                                kvp.Value.mSmcEsl.WriteBeaconData("ESL143AP01", EID, false);
                            }
                        }
                    }
                    else if (BeaconIndex == int.Parse(tbBeaconCount.Text.ToString()) - 1)
                    {
                       // mSmcEsl.WriteBeaconData("ESL143AP01", EID, true);
                        foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
                        {
                            if (kvp.Key.Contains(AP_IP_Label.Text))
                            {
                                kvp.Value.mSmcEsl.WriteBeaconData("ESL143AP01", EID, true);
                            }
                        }
                    }
                }
                else
                {
                    str_data = "Beacon更新失敗";
                }
            }

            // ---------  ESL  版本 -------
            else if (msgId == SmcEsl.msg_ReadEslVersion)
            {
                if (status)
                {
                    str_data = "ESL 版本 = " + data;
                }
                else
                {
                    str_data = "ESL 版本讀取錯誤";
                }
            }
            // ---------  ESL  電壓 -------
            else if (msgId == SmcEsl.msg_ReadEslBattery)
            {
                if (status)
                {
                    str_data = "Esl電池電壓 = " + data + " V";
                }
                else
                {
                    str_data = "Esl電池電壓讀取失敗";
                }
            }
            // ---------  ESL  製造資料 -------
            else if (msgId == SmcEsl.msg_ReadManufactureData)
            {
                if (status)
                {
                    str_data = "製造資料 = " + data;
                }
                else
                {
                    str_data = "製造資料讀取錯誤";
                }
            }
            // ---------  ESL  版本 -------
            else if (msgId == SmcEsl.msg_WriteManufactureData)
            {
                if (status)
                {
                    str_data = "ESL 版本寫入成功";
                }
                else
                {
                    str_data = "ESL 版本寫入失敗";
                }
            }

            // ---------  AP  寫入Buffer -------
            else if (msgId == SmcEsl.msg_WriteESLDataBuffer)
            {
                if (status)
                {
                    if (buffercontineu)
                    {

                        int selectSize = 0;
                        for (int i = 0; i < listView1.Items.Count; i++)
                        {
                            listView1.Items[i].ForeColor = Color.Black;
                            if (listView1.Items[i].SubItems[1].Text.Equals(leBleMac.Text))
                            {
                                if (listView1.Items[i].SubItems[3].Text.Equals("02") || size == 2)
                                {
                                    selectSize = 2;
                                }
                                else if (listView1.Items[i].SubItems[3].Text.Equals("01") || size == 1)
                                {
                                    selectSize = 1;
                                }
                                else
                                {
                                    selectSize = 0;
                                }
                            }
                        }

                        foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
                        {
                            if (kvp.Key.Contains(deviceIP))
                            {
                                SmcEsl mSmcEsl = kvp.Value.mSmcEsl;
                                Thread.Sleep(200);
                                mSmcEsl.UpdataESLDataFromBuffer(leBleMac.Text, selectSize, retry, 0); // mac  type  count  buffer
                            }
                        }


                        str_data = " 開始更新ESL  MAC = " + leBleMac.Text;
                    }
                    else
                    {
                        str_data = "寫入 AP Buffer 完成";
                    }

                }
                else
                {



                    if (buffercontineu)
                    {




                        Bitmap bmp = mElectronicPriceData.setPage1(leBleMac.Text);


                        for (int i = 0; i < listView1.Items.Count; i++)
                        {
                            listView1.Items[i].ForeColor = Color.Black;
                            if (listView1.Items[i].SubItems[1].Text.Equals(leBleMac.Text))
                            {
                                if (listView1.Items[i].SubItems[3].Text.Equals("02") || size == 2)
                                {
                                    bmp = mElectronicPriceData.setESLimage_42(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                                }
                                else if (listView1.Items[i].SubItems[3].Text.Equals("01") || size == 1)
                                {
                                    bmp = mElectronicPriceData.setESLimage_29(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                                }
                                else
                                {
                                    bmp = mElectronicPriceData.setESLimage(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                                }

                            }
                        }


                        foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
                        {
                            if (kvp.Key.Contains(deviceIP))
                            {
                                kvp.Value.mSmcEsl.TransformImageToData(bmp);
                                kvp.Value.mSmcEsl.writeESLDataBuffer(leBleMac.Text, 0);
                            }
                        }
                    }

                        str_data = "寫入 AP Buffer 失敗";
                }
            }

            // ---------  AP  更新ESL -------
            else if (msgId == SmcEsl.msg_UpdataESLDataFromBuffer)
            {
                //

                if (status)
                {
                    ApUpdateTiner.Stop();
                    disConnectCount = 0;
                    //  str_data = "AP 更新 ESL 完成";
                    stopwatch.Stop();//碼錶停止
                    TimeSpan ts = stopwatch.Elapsed;

                    // Format and display the TimeSpan value.
                    string elapsedTime = String.Format("{0:00} 分 {1:00} 秒 {2:000} 毫秒", ts.Minutes, ts.Seconds, ts.Milliseconds);

                    totleTimeSpan = totleTimeSpan + ts;
                    double totletime = totleTimeSpan.TotalMilliseconds;
                    totletime = totletime / totalwritecount / 1000;
                    totletime = Math.Round(totletime, 3);
                    string average = totletime.ToString();


                    str_data = "  MAC:" + leBleMac.Text + "  成功" + ", 執行時間 = " + elapsedTime + ", 總時間 = " + totleTimeSpan + ", 平均 = " + average + ", 總次數 = " + totalwritecount + "\n";

                    //Console.WriteLine("msg_WriteEslDataFinish");
                    if (buffercontineu)
                    {
                        if (listcount + 1 < listView1.Items.Count)
                        {
                            listcount++;
                        }
                        else
                        {
                            listcount = 0;
                        }
                        totalwritecount++;
                        for (int i = 0; i < listView1.Items.Count; i++)
                        {
                            listView1.Items[i].ForeColor = Color.Black;
                        }
                        leBleMac.Text = listView1.Items[listcount].SubItems[1].Text;
                        listView1.Items[listcount].ForeColor = Color.Blue;
                        // Bitmap bmp = mElectronicPriceData.setPage1(BleMacList.Items[listcount].ToString());


                        Bitmap bmp = null;
                        bmp = mElectronicPriceData.setESLimage(leBleMac.Text, listView1.Items[listcount].SubItems[2].Text);
                        /*
                                                for (int i = 0; i < listView1.Items.Count; i++)
                                                {
                                                    listView1.Items[i].ForeColor = Color.Black;
                                                    if (listView1.Items[i].SubItems[1].Text.Equals(leBleMac.Text))
                                                    {
                                                        bmp = mElectronicPriceData.setESLimage(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                                                        listView1.Items[i].ForeColor = Color.Blue;
                                                    }
                                                }*/

                        for (int i = 0; i < listView1.Items.Count; i++)
                        {
                            listView1.Items[i].ForeColor = Color.Black;
                            if (listView1.Items[i].SubItems[1].Text.Equals(leBleMac.Text))
                            {
                                if (listView1.Items[i].SubItems[3].Text.Equals("02") || size == 2)
                                {
                                    bmp = mElectronicPriceData.setESLimage_42(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                                }
                                else if (listView1.Items[i].SubItems[3].Text.Equals("01") || size == 1)
                                {
                                    bmp = mElectronicPriceData.setESLimage_29(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                                }
                                else
                                {
                                    bmp = mElectronicPriceData.setESLimage(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                                }

                            }
                        }


                        foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
                        {
                            if (kvp.Key.Contains(deviceIP))
                            {
                                kvp.Value.mSmcEsl.TransformImageToData(bmp);
                                kvp.Value.mSmcEsl.writeESLDataBuffer(leBleMac.Text, 0);
                                stopwatch.Reset();
                                stopwatch.Start();//碼表開始計時
                                break;
                            }
                        }


                    }
                   
                }
                else
                {
                    if (buffercontineu)
                    {
                        str_data = "AP 更新 ESL ( " + leBleMac.Text + " ) 失敗，重新更新中";
                        ApUpdateTiner.Stop();
                        ApUpdateTiner.Start();
                    }
                    else
                    {
                        str_data = "AP 更新 ESL 失敗";
                    }
                    
                }



            }
            // ---------  AP  設定時間 -------
            else if (msgId == SmcEsl.msg_SetRTCTime)
            {
                if (status)
                {
                    str_data = "AP 設定時間 完成";
                }
                else
                {
                    str_data = "AP 設定時間 失敗";
                }
            }
            // ---------  AP  取得時間 -------
            else if (msgId == SmcEsl.msg_GetRTCTime)
            {

                string yy = data.Substring(0, 2);
                string MM = data.Substring(2, 2);
                string dd = data.Substring(4, 2);
                string ww = data.Substring(6, 2);
                string HH = data.Substring(8, 2);
                string mm = data.Substring(10, 2);
                string ss = data.Substring(12, 2);
                str_data = yy + "/" + MM + "/" + dd + "  星期:" + ww + "  " + HH + ":" + mm + ":" + ss;

            }
            // ---------  AP  Beacon Time  -------
            else if (msgId == SmcEsl.msg_SetBeaconTime)
            {
                if (status)
                {
                    str_data = "Beacon 設定時間 完成";
                }
                else
                {
                    str_data = "Beacon 設定時間 失敗";
                }
            }

            //----------- 2018/03/23
            // ---------  AP  設定時間 -------
            else if (msgId == SmcEsl.msg_SetCustomerID_AP)
            {
                if (status)
                {
                    str_data = "AP 客戶ID設定 成功";
                }
                else
                {
                    str_data = "AP 客戶ID設定 失敗";
                }
            }
            else if (msgId == SmcEsl.msg_SetCustomerID_ESL)
            {
                if (status)
                {
                    str_data = "ESL 客戶ID設定 成功";
                }
                else
                {
                    str_data = "ESL 客戶ID設定 失敗";
                }
            }
            else if (msgId == SmcEsl.msg_ReadEslType)
            {
                Console.WriteLine(" SmcEsl.msg_ReadEslType"+ data);
                if(data.Substring(6, 2).Equals("00"))
                {
                    str_data = "2.13吋";
                }
                else if (data.Substring(6, 2).Equals("01"))
                {
                    str_data = "2.9吋";
                }
                else if (data.Substring(6, 2).Equals("02"))
                {
                    str_data = "4.2吋";
                }
            }
            // 寫入ESL資料
            else if (msgId == SmcEsl.msg_WriteEslData2)
            {
                if (status)
                {
                    //    Console.WriteLine("資料寫入成功");
                    progressBar1.Value += progressBar1.Step;
                    str_data = "資料寫入成功";
                }
                else
                {
                    str_data = "資料寫入失敗";
                }
            }
            // 寫入ESL資料，全部寫完
            else if (msgId == SmcEsl.msg_WriteEslDataFinish2)
            {
                BleWriteTimer.Stop();
                str_data = "全部資料寫入成功";
                this.progressBar1.Visible = false; //顯示進度條

                stopwatch.Stop();//碼錶停止
                TimeSpan ts = stopwatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00} 分 {1:00} 秒 {2:000} 毫秒", ts.Minutes, ts.Seconds, ts.Milliseconds);

                totleTimeSpan = totleTimeSpan + ts;
                double totletime = totleTimeSpan.TotalMilliseconds;
                totletime = totletime / totalwritecount / 1000;
                totletime = Math.Round(totletime, 3);
                string average = totletime.ToString();
                //Console.WriteLine("msg_WriteEslDataFinish");
                if (continuewrite)
                {
                    if (listcount + 1 < listView1.Items.Count)
                    {
                        listcount++;
                    }
                    else
                    {
                        listcount = 0;
                    }
                    foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
                    {
                        if (kvp.Key.Contains(AP_IP_Label.Text))
                        {
                            kvp.Value.mSmcEsl.DisConnectBleDevice();
                        }
                    }
                    totalwritecount++;
                    stopwatch.Reset();
                    stopwatch.Start();//碼表開始計時
                }
                str_data = "  -> MAC:" + leBleMac.Text + "  成功" + ", 執行時間 = " + elapsedTime + ", 總時間 = " + totleTimeSpan + ", 平均 = " + average + ", 總次數 = " + totalwritecount;

            }



            if (str_data.Equals("斷線成功") || str_data.Equals("斷線失敗") || str_data.Equals("連線失敗") || str_data.Contains("AP 更新 ESL 失敗"))
            {
                tbMessageBox.SelectionColor = Color.FromArgb(255, 89, 0);

            }
            else if (str_data.Equals("連線成功"))
            {
                tbMessageBox.SelectionColor = Color.FromArgb(60, 119, 119);
            }
            else
            {
                tbMessageBox.SelectionColor = Color.FromArgb(0, 34, 255);
            }


            if (totalwritecount == 100)
            {
                tbMessageBox.Text = "";
            }


            if (str_data.Equals("資料寫入成功") || msgId == SmcEsl.msg_ScanDevice)
            {

            }
            else
            {
                tbMessageBox.AppendText(Environment.NewLine + deviceIP + "  Time = "+ DateTime.Now.ToString("HH:mm:ss") + " =>" + str_data);
                tbMessageBox.SelectionStart = tbMessageBox.Text.Length;
                tbMessageBox.ScrollToCaret();
            }
           


        }


        #endregion
        
        private void writeEslTimeout_Click(object sender, EventArgs e)
        {
            //寫入時間 Timeout
            BleWriteTimer.Stop();
            BleWriteTimer.Interval = (int.Parse(tbEslTime.Text) * 1000);
        }

        private void BleTimeout_Click(object sender, EventArgs e)
        {
            //連線時間 Timeout
            // mSmcEsl.setBleConnectTimeOut(int.Parse(tbBleTimeout.Text) * 1000);
            ConnectBleTimeOut.Stop();
            ConnectBleTimeOut.Interval = (int.Parse(tbBleTimeout.Text) * 1000);
        }

        //-------------------------  黑白紅 ------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            stopwatch.Start();//碼表開始計時
            //寫入全  黑
            ProgressBarVisible();
            continuewrite = true;
            //listcount = 0;
            ColorSelect = 2;
           // mSmcEsl.setBlackData();
           // mSmcEsl.WriteESLDataWithBle();
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.setBlackData();
                    kvp.Value.mSmcEsl.WriteESLDataWithBle();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            stopwatch.Start();//碼表開始計時
            //寫入全   白
            ProgressBarVisible();
            continuewrite = true;
            //listcount = 0;
            ColorSelect = 3;
           // mSmcEsl.setWhileData();
           // mSmcEsl.WriteESLDataWithBle();
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.setWhileData();
                    kvp.Value.mSmcEsl.WriteESLDataWithBle();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            stopwatch.Start();//碼表開始計時
            //寫入全  紅
            ProgressBarVisible();
            continuewrite = true;
            //listcount = 0;
            ColorSelect = 4;
           // mSmcEsl.setRedData();
           // mSmcEsl.WriteESLDataWithBle();
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.setRedData();
                    kvp.Value.mSmcEsl.WriteESLDataWithBle();
                }
            }
        }
        //--------------------------  Mac List Control 位置 ------------------------------------
        private void btnUP_Click(object sender, EventArgs e)
        {
           /* int lbxLength = this.BleMacList.Items.Count;
            int iselect = this.BleMacList.SelectedIndex;
            if (lbxLength > iselect && iselect > 0)
            {
                object oTempItem = this.BleMacList.SelectedItem;
                this.BleMacList.Items.RemoveAt(iselect);
                this.BleMacList.Items.Insert(iselect - 1, oTempItem);
                this.BleMacList.SelectedIndex = iselect - 1;
            }*/
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            /*int lbxLength = this.BleMacList.Items.Count;
            int iselect = this.BleMacList.SelectedIndex;
            if (lbxLength > iselect && iselect < lbxLength - 1)
            {
                object oTempItem = this.BleMacList.SelectedItem;
                this.BleMacList.Items.RemoveAt(iselect);
                this.BleMacList.Items.Insert(iselect + 1, oTempItem);
                this.BleMacList.SelectedIndex = iselect + 1;
            }*/
        }

        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            String StrName = String.Format("{0}", DateTime.Now.ToString("yyyy_MM_dd HH_mm_ss"));
            saveFileDialog1.FileName = "Er"+StrName; // Default file name
            saveFileDialog1.DefaultExt = ".txt"; // Default file extension
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                FileStream myStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);

                StreamWriter sw = new StreamWriter(myStream);

               /* foreach (KeyValuePair<string, int> kvp in EslError)
                { 
                    sw.Write("MAC = " + kvp.Key + ", Error = " + kvp.Value + "\r\n");
                }*/

                for (int i = 0; i < EslErrorList.Count; i++)
                {
                    sw.Write("MAC = " + EslErrorList[i].mac + ", Error = " + EslErrorList[i].error + "\r\n");
                }



                sw.Flush();
                sw.Close();
                myStream.Close();
            }
        }


        private void SaveMacToText_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            String StrName = String.Format("{0}", DateTime.Now.ToString("yyyy_MM_dd HH_mm_ss"));
            saveFileDialog1.FileName = StrName; // Default file name
            saveFileDialog1.DefaultExt = ".txt"; // Default file extension
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                FileStream myStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);

                StreamWriter sw = new StreamWriter(myStream);

                for (int i = 0;i< listView1.Items.Count;i++)
                {
                    sw.Write(listView1.Items[listcount].SubItems[1].Text + "\r\n");
                }


                sw.Flush();
                sw.Close();
                myStream.Close();
                MessageBox.Show("Write Finish");
            }
        }

        private void ReadTextFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = File.OpenText(openFileDialog1.FileName))
                {

                    import_file_check = true;

                    listView1.Items.Clear();
                    //listBox_Battery.Items.Clear();
                   

                    String input;
                    int j = 0;
                    while ((input = sr.ReadLine()) != null)
                    {
                        ListViewItem item1 = new ListViewItem(""+(j+1), j);
                        item1.SubItems.Add(input);
                        item1.SubItems.Add("3.04");
                        item1.SubItems.Add("01");
                        listView1.Items.AddRange(new ListViewItem[] { item1 });
                        j++;

                     
                    }
                    BleMacCountLabel.Text = listView1.Items.Count + "";
                    MessageBox.Show("Read Finish");
                    sr.Close();
                }
            }
        }



        //----------------------------------   紅外線掃描   --------------------------------
        static int VALIDATION_DELAY = 80;
        System.Threading.Timer timer = null;
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            // barcode += tbDeviceName.Text;
            TextBox origin = sender as TextBox;
            if (!origin.ContainsFocus)
                return;

            DisposeTimer();
            timer = new System.Threading.Timer(TimerElapsed, null, VALIDATION_DELAY, VALIDATION_DELAY);
            //  Console.WriteLine(barcode);

        }
        private void TimerElapsed(Object obj)
        {
            CheckSyntaxAndReport();
            DisposeTimer();
        }

        private void DisposeTimer()
        {
            if (timer != null)
            {
                timer.Dispose();
                timer = null;
            }
        }

        private void CheckSyntaxAndReport()
        {
            this.Invoke(new Action(() =>
            {
                string s = tbDeviceName.Text.ToUpper(); 
                tbDeviceName.Text = "";
            }
                ));
        }

        //------------------------------------------  IP 搜尋與連線  ----------------------------------------------------------------
        #region AP Scan connect
        private void getAPinfo_Click(object sender, EventArgs e)
        {
            tbMessageBox.Text = "";
            AP_ListBox.Items.Clear();
            Tools tool = new Tools();
            tool.onApScanEvent += new EventHandler(AP_Scan);
            tool.SNC_GetAP_Info();
        }

        private void AP_Scan(object sender, EventArgs e)
        {
            APScanDataInvoker stc = new APScanDataInvoker(ApScanReceiveData);
            this.BeginInvoke(stc, e);
        }
        private void ApScanReceiveData(EventArgs e)
        {
            List<AP_Information> AP = (e as Tools.ApScanEventArgs).data;
            foreach (AP_Information mAP_Information in AP)
            {
                tbMessageBox.AppendText("IP = " + mAP_Information.AP_IP + " Mac = " + mAP_Information.AP_MAC_Address + " Name = " + mAP_Information.AP_Name );
                tbMessageBox.AppendText("\n");
                AP_ListBox.Items.Add(mAP_Information.AP_IP);
                AP_ListBox.SelectedIndex = 0;
                AP_IP_Label.Text = AP_ListBox.SelectedItem.ToString();
            }
        }
        //連線
        private void AP_Connect_Click(object sender, EventArgs e)
        {
            if (AP_ListBox.Items.Count < 1)
            {
                return;
            }
            ClearSocket();
            Socket client = null;
           /* for (int i = 0; i < AP_ListBox.Items.Count; i++)
            {
                string ipp = AP_ListBox.Items[i].ToString();
               // client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);  // TCP
                client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp); // UDP
                IPAddress ipAddress = IPAddress.Parse(ipp);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
                client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();
                client = null;
                Thread.Sleep(100);
            }*/
            AP_ListBox.SelectedIndex = 0;
            AP_IP_Label.Text = AP_ListBox.SelectedItem.ToString();

            string ipp = AP_IP_Label.Text.ToString();
             client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);  // TCP
            //client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp); // UDP
            IPAddress ipAddress = IPAddress.Parse(ipp);
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
            client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), client);
          //  connectDone.WaitOne();

        }


        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;
                // Complete the connection.
                client.EndConnect(ar);
                SmcEsl aSmcEsl = new SmcEsl(client);
                aSmcEsl.onSMCEslReceiveEvent += new EventHandler(SMCEslReceiveEvent); //全資料回傳

                EslObject mEslObject = new EslObject();
                mEslObject.workSocket = client;
                mEslObject.mSmcEsl = aSmcEsl;
                mDictSocket.Add(client.RemoteEndPoint.ToString(), mEslObject);

               // aSmcEsl.stopScanBleDevice();
                aSmcEsl.DisConnectBleDevice();

                tbMessageBox.BeginInvoke(
                    new RichTextBoxUpdateEventHandler(UpdateRichTextBox), // the method to call back on
                    new object[] { client.RemoteEndPoint.ToString() + "  連線成功 \n" });
               // connectDone.Set();
            }
            catch (Exception e)
            {
                tbMessageBox.BeginInvoke(
                    new RichTextBoxUpdateEventHandler(UpdateRichTextBox), // the method to call back on
                    new object[] { "AP 連線失敗，請檢查網路設定是否正確 \n" });
            }
        }
        // IP列表選擇
        private void SelectAPIP(object sender, EventArgs e)
        {
            AP_IP_Label.Text = AP_ListBox.SelectedItem.ToString();
        }

        private void ClearSocket()
        {
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                kvp.Value.mSmcEsl = null;
                kvp.Value.workSocket.Close();
                kvp.Value.workSocket = null;
            }
            mDictSocket.Clear();
        }
        #endregion
        //-----RichTextBox anys ------------------
        private delegate void RichTextBoxUpdateEventHandler(string message);
        private void UpdateRichTextBox(string message)
        {
            if (tbMessageBox.InvokeRequired)
            {
                tbMessageBox.Invoke(
                    new RichTextBoxUpdateEventHandler(UpdateRichTextBox),
                    new object[] { message });
            }
            else
            {
                tbMessageBox.AppendText(message);
                tbMessageBox.SelectionStart = tbMessageBox.Text.Length;
                tbMessageBox.ScrollToCaret();
            }
        }

        //===============

        bool buffercontineu = false;
        private void button1_Click(object sender, EventArgs e)
        {
            buffercontineu = true;
            totalwritecount = 0;

            stopwatch.Reset();
            stopwatch.Start();//碼表開始計時

            disConnectCount = 0;

            // listcount = this.BleMacList.SelectedIndex;
            // leBleMac.Text = BleMacList.SelectedItem.ToString();
            /*EslError.Clear();
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                EslError.Add(BleMacList.Items[i].ToString(), 0);
            }*/
            EslErrorList.Clear();
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                ErrorEslObject mErrorEslObject = new ErrorEslObject();
                mErrorEslObject.mac = listView1.Items[i].SubItems[1].ToString();
                mErrorEslObject.error = 0;
                EslErrorList.Add(mErrorEslObject);
            }


            // Bitmap bmp = mElectronicPriceData.setPage1(leBleMac.Text);


            // leBleMac.Text = listView1.Items[listcount].SubItems[0].Text;
            // listView1.Items[listcount].Selected = true;
            // Bitmap bmp = mElectronicPriceData.setPage1(BleMacList.Items[listcount].ToString());


            Bitmap bmp = null;

          /*  for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].ForeColor = Color.Black;
                if (listView1.Items[i].SubItems[1].Text.Equals(leBleMac.Text))
                {
                    bmp = mElectronicPriceData.setESLimage(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                    listView1.Items[i].ForeColor = Color.Blue;
                }
            }*/

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].ForeColor = Color.Black;
                if (listView1.Items[i].SubItems[1].Text.Equals(leBleMac.Text))
                {
                    if (listView1.Items[i].SubItems[3].Text.Equals("02") || size == 2)
                    {
                        bmp = mElectronicPriceData.setESLimage_42(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                    }
                    else if(listView1.Items[i].SubItems[3].Text.Equals("01") || size == 1)
                    {
                        bmp = mElectronicPriceData.setESLimage_29(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                    }
                    else
                    {
                        bmp = mElectronicPriceData.setESLimage(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                    }

                    listView1.Items[i].ForeColor = Color.Blue;
                }
            }



            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                   // kvp.Value.mSmcEsl.setHexData(t, r);
                    kvp.Value.mSmcEsl.TransformImageToData(bmp);
                    kvp.Value.mSmcEsl.writeESLDataBuffer(leBleMac.Text, 0);
                   // kvp.Value.stopwatch.Reset();
                 //   kvp.Value.stopwatch.Start();
                }
            }

           /* tbMessageBox.AppendText(Environment.NewLine + "資料寫入中...");

            tbMessageBox.SelectionStart = tbMessageBox.Text.Length;
            tbMessageBox.ScrollToCaret();*/
        }

        private void ApBufferRetrySet_Click(object sender, EventArgs e)
        {
            retry = int.Parse(UpdataReTryCount.Text);
        }


        //------------- 2018/03/23
        private void CustomerIDApBtn_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.setCustomerID_AP(tBCustomerID.Text);
                }
            }
        }

        private void CustomerIDEslBtn_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.setCustomerID_ESL(tBCustomerID.Text);
                }
            }
        }

        private void ReadSizeBtn_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.ReadEslType();
                }
            }
        }

        private void WriteEslDataBtn_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            stopwatch.Start();//碼表開始計時

            BleWriteTimer.Start();

            ProgressBarVisible();
            continuewrite = false;

            ColorSelect = 5; //

            Bitmap bmp = null;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].ForeColor = Color.Black;
                if (listView1.Items[i].SubItems[1].Text.Equals(leBleMac.Text))
                {
                    if (listView1.Items[i].SubItems[3].Text.Equals("02") || size == 2)
                    {
                        bmp = mElectronicPriceData.setESLimage_42(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                        progressBar1.Maximum = 2400;//設置最大長度值
                        progressBar1.Value = 0;//設置當前值
                        progressBar1.Step = 10;//設置沒次增長多少
                    }
                    else if (listView1.Items[i].SubItems[3].Text.Equals("01") || size == 1)
                    {
                         bmp = mElectronicPriceData.setESLimage_29(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                       // bmp = mElectronicPriceData.setESLimageDemo_29(panel1Demo, tag1_1);
                        progressBar1.Maximum = 770;//設置最大長度值
                        progressBar1.Value = 0;//設置當前值
                        progressBar1.Step = 10;//設置沒次增長多少
                    }
                    else
                    {
                        bmp = mElectronicPriceData.setESLimage(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                        progressBar1.Maximum = 440;//設置最大長度值
                        progressBar1.Value = 0;//設置當前值
                        progressBar1.Step = 10;//設置沒次增長多少
                    }

                    listView1.Items[i].ForeColor = Color.Blue;
                }
            }

            // mSmcEsl.TransformImageToData(bmp);
            // mSmcEsl.WriteESLDataWithBle();
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.TransformImageToData(bmp);
                    kvp.Value.mSmcEsl.WriteESLDataWithBle2(tBCustomerID.Text);
                }
            }
        }

        private void WriteEslDataContinueBtn_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            stopwatch.Start();//碼表開始計時

            BleWriteTimer.Start();

            ProgressBarVisible();
            continuewrite = true;
            // listcount = 0;
            ColorSelect = 5;

            EslErrorList.Clear();
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                ErrorEslObject mErrorEslObject = new ErrorEslObject();
                mErrorEslObject.mac = listView1.Items[i].SubItems[1].ToString();
                mErrorEslObject.error = 0;
                EslErrorList.Add(mErrorEslObject);
            }
            Bitmap bmp = null;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].ForeColor = Color.Black;
                if (listView1.Items[i].SubItems[1].Text.Equals(leBleMac.Text))
                {
                    if (listView1.Items[i].SubItems[3].Text.Equals("02") || size == 2)
                    {
                        bmp = mElectronicPriceData.setESLimage_42(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                        progressBar1.Maximum = 2400;//設置最大長度值
                        progressBar1.Value = 0;//設置當前值
                        progressBar1.Step = 10;//設置沒次增長多少
                    }
                    else if (listView1.Items[i].SubItems[3].Text.Equals("01") || size == 1)
                    {
                        bmp = mElectronicPriceData.setESLimage_29(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                        progressBar1.Maximum = 770;//設置最大長度值
                        progressBar1.Value = 0;//設置當前值
                        progressBar1.Step = 10;//設置沒次增長多少
                    }
                    else
                    {
                        bmp = mElectronicPriceData.setESLimage(leBleMac.Text, listView1.Items[i].SubItems[2].Text);
                        progressBar1.Maximum = 440;//設置最大長度值
                        progressBar1.Value = 0;//設置當前值
                        progressBar1.Step = 10;//設置沒次增長多少
                    }

                    listView1.Items[i].ForeColor = Color.Blue;
                }
            }




            // mSmcEsl.TransformImageToData(bmp);
            // mSmcEsl.WriteESLDataWithBle();
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.TransformImageToData(bmp);
                    kvp.Value.mSmcEsl.WriteESLDataWithBle2(tBCustomerID.Text);
                }
            }
        }

        private void SelectSizeChange(object sender, EventArgs e)
        {
            size = cBSize.SelectedIndex;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel1Demo.ClientRectangle, Color.DimGray, 1, ButtonBorderStyle.Solid, Color.DimGray, 1, ButtonBorderStyle.Solid, Color.DimGray, 1, ButtonBorderStyle.Solid, Color.DimGray, 1, ButtonBorderStyle.Solid);
        }

        private void WriteEslData2Button_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            stopwatch.Start();//碼表開始計時

            BleWriteTimer.Start();

            ProgressBarVisible();
            continuewrite = false;
            //listcount = 0;
            // mSmcEsl.setHexData(t, r);
            // mSmcEsl.WriteESLDataWithBle();
            foreach (KeyValuePair<string, EslObject> kvp in mDictSocket)
            {
                if (kvp.Key.Contains(AP_IP_Label.Text))
                {
                    kvp.Value.mSmcEsl.setHexData(t, r);
                    kvp.Value.mSmcEsl.WriteESLDataWithBle2(tBCustomerID.Text);
                }
            }
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel1Demo.ClientRectangle, Color.DimGray, 1, ButtonBorderStyle.Solid, Color.DimGray, 1, ButtonBorderStyle.Solid, Color.DimGray, 1, ButtonBorderStyle.Solid, Color.DimGray, 1, ButtonBorderStyle.Solid);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap aa =   mElectronicPriceData.setESLimageDemo_29(panel1Demo, tag1_1);
           // Bitmap aa = mElectronicPriceData.setESLimage_29(leBleMac.Text,"25");
            pictureBox1.Image = aa;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}
