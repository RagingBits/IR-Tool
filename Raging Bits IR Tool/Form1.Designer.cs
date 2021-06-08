
namespace Raging_Bits_IR_Tool
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBox_SerialPortList = new System.Windows.Forms.ComboBox();
            this.work_timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.button_PortConnect = new System.Windows.Forms.Button();
            this.timer_serial_port_auto_speed = new System.Windows.Forms.Timer(this.components);
            this.richTextBox_printout = new System.Windows.Forms.RichTextBox();
            this.textBox_serial_speed = new System.Windows.Forms.TextBox();
            this.bps = new System.Windows.Forms.Label();
            this.groupBox_device_info = new System.Windows.Forms.GroupBox();
            this.label_device_hw_rev = new System.Windows.Forms.Label();
            this.textBox_device_hw_rev = new System.Windows.Forms.TextBox();
            this.label_device_sw_rev = new System.Windows.Forms.Label();
            this.textBox_device_sw_rev = new System.Windows.Forms.TextBox();
            this.label_device_serial = new System.Windows.Forms.Label();
            this.textBox_device_serial_number = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider_error = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl_work = new System.Windows.Forms.TabControl();
            this.tool_commands = new System.Windows.Forms.TabPage();
            this.button_cmd_send = new System.Windows.Forms.Button();
            this.richTextBox_cmd_field10 = new System.Windows.Forms.RichTextBox();
            this.label_cmd_field10 = new System.Windows.Forms.Label();
            this.label_cmd_field9 = new System.Windows.Forms.Label();
            this.textBox_cmd_field9 = new System.Windows.Forms.TextBox();
            this.label_cmd_field8 = new System.Windows.Forms.Label();
            this.textBox_cmd_field8 = new System.Windows.Forms.TextBox();
            this.label_cmd_field7 = new System.Windows.Forms.Label();
            this.textBox_cmd_field7 = new System.Windows.Forms.TextBox();
            this.label_cmd_field6 = new System.Windows.Forms.Label();
            this.textBox_cmd_field6 = new System.Windows.Forms.TextBox();
            this.label_cmd_field5 = new System.Windows.Forms.Label();
            this.textBox_cmd_field5 = new System.Windows.Forms.TextBox();
            this.label_cmd_field4 = new System.Windows.Forms.Label();
            this.textBox_cmd_field4 = new System.Windows.Forms.TextBox();
            this.label_cmd_field3 = new System.Windows.Forms.Label();
            this.textBox_cmd_field3 = new System.Windows.Forms.TextBox();
            this.label_cmd_field2 = new System.Windows.Forms.Label();
            this.textBox_cmd_field2 = new System.Windows.Forms.TextBox();
            this.label_cmd_field1 = new System.Windows.Forms.Label();
            this.textBox_cmd_field1 = new System.Windows.Forms.TextBox();
            this.label_cmd_field0 = new System.Windows.Forms.Label();
            this.textBox_cmd_field0 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_command = new System.Windows.Forms.ComboBox();
            this.encode_decode = new System.Windows.Forms.TabPage();
            this.label_protocol_12 = new System.Windows.Forms.Label();
            this.textBox_protocol_12 = new System.Windows.Forms.TextBox();
            this.label_protocol_11 = new System.Windows.Forms.Label();
            this.textBox_protocol_11 = new System.Windows.Forms.TextBox();
            this.label_protocol_10 = new System.Windows.Forms.Label();
            this.richTextBox_protocol_10 = new System.Windows.Forms.RichTextBox();
            this.button_protocol_decode = new System.Windows.Forms.Button();
            this.button_protocol_encode = new System.Windows.Forms.Button();
            this.label_protocol_0 = new System.Windows.Forms.Label();
            this.label_protocol_9 = new System.Windows.Forms.Label();
            this.textBox_protocol_9 = new System.Windows.Forms.TextBox();
            this.textBox_protocol_0 = new System.Windows.Forms.TextBox();
            this.label_protocol_8 = new System.Windows.Forms.Label();
            this.textBox_protocol_8 = new System.Windows.Forms.TextBox();
            this.label_protocol_7 = new System.Windows.Forms.Label();
            this.textBox_protocol_7 = new System.Windows.Forms.TextBox();
            this.label_protocol_6 = new System.Windows.Forms.Label();
            this.textBox_protocol_6 = new System.Windows.Forms.TextBox();
            this.label_protocol_5 = new System.Windows.Forms.Label();
            this.textBox_protocol_5 = new System.Windows.Forms.TextBox();
            this.label_protocol_4 = new System.Windows.Forms.Label();
            this.textBox_protocol_4 = new System.Windows.Forms.TextBox();
            this.label_protocol_3 = new System.Windows.Forms.Label();
            this.textBox_protocol_3 = new System.Windows.Forms.TextBox();
            this.label_protocol_2 = new System.Windows.Forms.Label();
            this.textBox_protocol_2 = new System.Windows.Forms.TextBox();
            this.label_protocol_1 = new System.Windows.Forms.Label();
            this.textBox_protocol_1 = new System.Windows.Forms.TextBox();
            this.comboBox_protocols = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timer_decoder = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gNULicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readmeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.githubProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iRToolDatasheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button_filesend_open = new System.Windows.Forms.Button();
            this.textBox_filesend_file_to_send = new System.Windows.Forms.TextBox();
            this.button_sendfile_send = new System.Windows.Forms.Button();
            this.timer_filesend = new System.Windows.Forms.Timer(this.components);
            this.groupBox_device_info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_error)).BeginInit();
            this.tabControl_work.SuspendLayout();
            this.tool_commands.SuspendLayout();
            this.encode_decode.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_SerialPortList
            // 
            this.comboBox_SerialPortList.FormattingEnabled = true;
            this.comboBox_SerialPortList.Location = new System.Drawing.Point(12, 58);
            this.comboBox_SerialPortList.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_SerialPortList.Name = "comboBox_SerialPortList";
            this.comboBox_SerialPortList.Size = new System.Drawing.Size(310, 21);
            this.comboBox_SerialPortList.TabIndex = 0;
            // 
            // work_timer
            // 
            this.work_timer.Enabled = true;
            this.work_timer.Interval = 500;
            this.work_timer.Tick += new System.EventHandler(this.work_timer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serial port Connected to IR Tool";
            // 
            // button_PortConnect
            // 
            this.button_PortConnect.Location = new System.Drawing.Point(330, 58);
            this.button_PortConnect.Margin = new System.Windows.Forms.Padding(4);
            this.button_PortConnect.Name = "button_PortConnect";
            this.button_PortConnect.Size = new System.Drawing.Size(98, 46);
            this.button_PortConnect.TabIndex = 2;
            this.button_PortConnect.Text = "Connect";
            this.button_PortConnect.UseVisualStyleBackColor = true;
            this.button_PortConnect.Click += new System.EventHandler(this.button_PortConnect_Click);
            // 
            // timer_serial_port_auto_speed
            // 
            this.timer_serial_port_auto_speed.Interval = 1000;
            this.timer_serial_port_auto_speed.Tick += new System.EventHandler(this.timer_serial_port_auto_speed_Tick);
            // 
            // richTextBox_printout
            // 
            this.richTextBox_printout.Location = new System.Drawing.Point(12, 485);
            this.richTextBox_printout.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox_printout.MaxLength = 1000000;
            this.richTextBox_printout.Name = "richTextBox_printout";
            this.richTextBox_printout.ReadOnly = true;
            this.richTextBox_printout.Size = new System.Drawing.Size(1152, 228);
            this.richTextBox_printout.TabIndex = 0;
            this.richTextBox_printout.Text = "";
            // 
            // textBox_serial_speed
            // 
            this.textBox_serial_speed.Enabled = false;
            this.textBox_serial_speed.Location = new System.Drawing.Point(12, 80);
            this.textBox_serial_speed.Name = "textBox_serial_speed";
            this.textBox_serial_speed.ReadOnly = true;
            this.textBox_serial_speed.Size = new System.Drawing.Size(114, 20);
            this.textBox_serial_speed.TabIndex = 4;
            // 
            // bps
            // 
            this.bps.AutoSize = true;
            this.bps.Location = new System.Drawing.Point(132, 83);
            this.bps.Name = "bps";
            this.bps.Size = new System.Drawing.Size(24, 13);
            this.bps.TabIndex = 5;
            this.bps.Text = "bps";
            // 
            // groupBox_device_info
            // 
            this.groupBox_device_info.Controls.Add(this.label_device_hw_rev);
            this.groupBox_device_info.Controls.Add(this.textBox_device_hw_rev);
            this.groupBox_device_info.Controls.Add(this.label_device_sw_rev);
            this.groupBox_device_info.Controls.Add(this.textBox_device_sw_rev);
            this.groupBox_device_info.Controls.Add(this.label_device_serial);
            this.groupBox_device_info.Controls.Add(this.textBox_device_serial_number);
            this.groupBox_device_info.Location = new System.Drawing.Point(466, 41);
            this.groupBox_device_info.Name = "groupBox_device_info";
            this.groupBox_device_info.Size = new System.Drawing.Size(386, 69);
            this.groupBox_device_info.TabIndex = 0;
            this.groupBox_device_info.TabStop = false;
            this.groupBox_device_info.Text = "Device Information";
            // 
            // label_device_hw_rev
            // 
            this.label_device_hw_rev.AutoSize = true;
            this.label_device_hw_rev.Location = new System.Drawing.Point(277, 25);
            this.label_device_hw_rev.Name = "label_device_hw_rev";
            this.label_device_hw_rev.Size = new System.Drawing.Size(65, 13);
            this.label_device_hw_rev.TabIndex = 5;
            this.label_device_hw_rev.Text = "HW revision";
            // 
            // textBox_device_hw_rev
            // 
            this.textBox_device_hw_rev.Location = new System.Drawing.Point(280, 43);
            this.textBox_device_hw_rev.Name = "textBox_device_hw_rev";
            this.textBox_device_hw_rev.ReadOnly = true;
            this.textBox_device_hw_rev.Size = new System.Drawing.Size(100, 20);
            this.textBox_device_hw_rev.TabIndex = 4;
            // 
            // label_device_sw_rev
            // 
            this.label_device_sw_rev.AutoSize = true;
            this.label_device_sw_rev.Location = new System.Drawing.Point(171, 22);
            this.label_device_sw_rev.Name = "label_device_sw_rev";
            this.label_device_sw_rev.Size = new System.Drawing.Size(63, 13);
            this.label_device_sw_rev.TabIndex = 3;
            this.label_device_sw_rev.Text = "FW revision";
            // 
            // textBox_device_sw_rev
            // 
            this.textBox_device_sw_rev.Location = new System.Drawing.Point(174, 42);
            this.textBox_device_sw_rev.Name = "textBox_device_sw_rev";
            this.textBox_device_sw_rev.ReadOnly = true;
            this.textBox_device_sw_rev.Size = new System.Drawing.Size(100, 20);
            this.textBox_device_sw_rev.TabIndex = 2;
            // 
            // label_device_serial
            // 
            this.label_device_serial.AutoSize = true;
            this.label_device_serial.Location = new System.Drawing.Point(3, 22);
            this.label_device_serial.Name = "label_device_serial";
            this.label_device_serial.Size = new System.Drawing.Size(71, 13);
            this.label_device_serial.TabIndex = 1;
            this.label_device_serial.Text = "Serial number";
            // 
            // textBox_device_serial_number
            // 
            this.textBox_device_serial_number.Location = new System.Drawing.Point(6, 42);
            this.textBox_device_serial_number.Name = "textBox_device_serial_number";
            this.textBox_device_serial_number.ReadOnly = true;
            this.textBox_device_serial_number.Size = new System.Drawing.Size(162, 20);
            this.textBox_device_serial_number.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 466);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Log";
            // 
            // errorProvider_error
            // 
            this.errorProvider_error.ContainerControl = this;
            // 
            // tabControl_work
            // 
            this.tabControl_work.Controls.Add(this.tool_commands);
            this.tabControl_work.Controls.Add(this.encode_decode);
            this.tabControl_work.Controls.Add(this.tabPage1);
            this.tabControl_work.Location = new System.Drawing.Point(12, 116);
            this.tabControl_work.Name = "tabControl_work";
            this.tabControl_work.SelectedIndex = 0;
            this.tabControl_work.Size = new System.Drawing.Size(1156, 347);
            this.tabControl_work.TabIndex = 6;
            this.tabControl_work.Visible = false;
            // 
            // tool_commands
            // 
            this.tool_commands.Controls.Add(this.button_cmd_send);
            this.tool_commands.Controls.Add(this.richTextBox_cmd_field10);
            this.tool_commands.Controls.Add(this.label_cmd_field10);
            this.tool_commands.Controls.Add(this.label_cmd_field9);
            this.tool_commands.Controls.Add(this.textBox_cmd_field9);
            this.tool_commands.Controls.Add(this.label_cmd_field8);
            this.tool_commands.Controls.Add(this.textBox_cmd_field8);
            this.tool_commands.Controls.Add(this.label_cmd_field7);
            this.tool_commands.Controls.Add(this.textBox_cmd_field7);
            this.tool_commands.Controls.Add(this.label_cmd_field6);
            this.tool_commands.Controls.Add(this.textBox_cmd_field6);
            this.tool_commands.Controls.Add(this.label_cmd_field5);
            this.tool_commands.Controls.Add(this.textBox_cmd_field5);
            this.tool_commands.Controls.Add(this.label_cmd_field4);
            this.tool_commands.Controls.Add(this.textBox_cmd_field4);
            this.tool_commands.Controls.Add(this.label_cmd_field3);
            this.tool_commands.Controls.Add(this.textBox_cmd_field3);
            this.tool_commands.Controls.Add(this.label_cmd_field2);
            this.tool_commands.Controls.Add(this.textBox_cmd_field2);
            this.tool_commands.Controls.Add(this.label_cmd_field1);
            this.tool_commands.Controls.Add(this.textBox_cmd_field1);
            this.tool_commands.Controls.Add(this.label_cmd_field0);
            this.tool_commands.Controls.Add(this.textBox_cmd_field0);
            this.tool_commands.Controls.Add(this.label2);
            this.tool_commands.Controls.Add(this.comboBox_command);
            this.tool_commands.Location = new System.Drawing.Point(4, 22);
            this.tool_commands.Name = "tool_commands";
            this.tool_commands.Padding = new System.Windows.Forms.Padding(3);
            this.tool_commands.Size = new System.Drawing.Size(1148, 321);
            this.tool_commands.TabIndex = 0;
            this.tool_commands.Text = "Tool Commands";
            this.tool_commands.UseVisualStyleBackColor = true;
            // 
            // button_cmd_send
            // 
            this.button_cmd_send.Location = new System.Drawing.Point(314, 9);
            this.button_cmd_send.Name = "button_cmd_send";
            this.button_cmd_send.Size = new System.Drawing.Size(121, 38);
            this.button_cmd_send.TabIndex = 29;
            this.button_cmd_send.Text = "Send";
            this.button_cmd_send.UseVisualStyleBackColor = true;
            this.button_cmd_send.Visible = false;
            this.button_cmd_send.Click += new System.EventHandler(this.button_cmd_send_Click);
            // 
            // richTextBox_cmd_field10
            // 
            this.richTextBox_cmd_field10.Location = new System.Drawing.Point(5, 161);
            this.richTextBox_cmd_field10.Name = "richTextBox_cmd_field10";
            this.richTextBox_cmd_field10.Size = new System.Drawing.Size(1137, 151);
            this.richTextBox_cmd_field10.TabIndex = 27;
            this.richTextBox_cmd_field10.Text = "";
            this.richTextBox_cmd_field10.Visible = false;
            // 
            // label_cmd_field10
            // 
            this.label_cmd_field10.AutoSize = true;
            this.label_cmd_field10.Location = new System.Drawing.Point(6, 145);
            this.label_cmd_field10.Name = "label_cmd_field10";
            this.label_cmd_field10.Size = new System.Drawing.Size(35, 13);
            this.label_cmd_field10.TabIndex = 26;
            this.label_cmd_field10.Text = "label4";
            this.label_cmd_field10.Visible = false;
            // 
            // label_cmd_field9
            // 
            this.label_cmd_field9.AutoSize = true;
            this.label_cmd_field9.Location = new System.Drawing.Point(947, 100);
            this.label_cmd_field9.Name = "label_cmd_field9";
            this.label_cmd_field9.Size = new System.Drawing.Size(35, 13);
            this.label_cmd_field9.TabIndex = 24;
            this.label_cmd_field9.Text = "label4";
            this.label_cmd_field9.Visible = false;
            // 
            // textBox_cmd_field9
            // 
            this.textBox_cmd_field9.Location = new System.Drawing.Point(950, 116);
            this.textBox_cmd_field9.Name = "textBox_cmd_field9";
            this.textBox_cmd_field9.Size = new System.Drawing.Size(180, 20);
            this.textBox_cmd_field9.TabIndex = 23;
            this.textBox_cmd_field9.Visible = false;
            // 
            // label_cmd_field8
            // 
            this.label_cmd_field8.AutoSize = true;
            this.label_cmd_field8.Location = new System.Drawing.Point(708, 100);
            this.label_cmd_field8.Name = "label_cmd_field8";
            this.label_cmd_field8.Size = new System.Drawing.Size(35, 13);
            this.label_cmd_field8.TabIndex = 22;
            this.label_cmd_field8.Text = "label4";
            this.label_cmd_field8.Visible = false;
            // 
            // textBox_cmd_field8
            // 
            this.textBox_cmd_field8.Location = new System.Drawing.Point(711, 116);
            this.textBox_cmd_field8.Name = "textBox_cmd_field8";
            this.textBox_cmd_field8.Size = new System.Drawing.Size(184, 20);
            this.textBox_cmd_field8.TabIndex = 21;
            this.textBox_cmd_field8.Visible = false;
            // 
            // label_cmd_field7
            // 
            this.label_cmd_field7.AutoSize = true;
            this.label_cmd_field7.Location = new System.Drawing.Point(473, 100);
            this.label_cmd_field7.Name = "label_cmd_field7";
            this.label_cmd_field7.Size = new System.Drawing.Size(35, 13);
            this.label_cmd_field7.TabIndex = 20;
            this.label_cmd_field7.Text = "label4";
            this.label_cmd_field7.Visible = false;
            // 
            // textBox_cmd_field7
            // 
            this.textBox_cmd_field7.Location = new System.Drawing.Point(476, 116);
            this.textBox_cmd_field7.Name = "textBox_cmd_field7";
            this.textBox_cmd_field7.Size = new System.Drawing.Size(180, 20);
            this.textBox_cmd_field7.TabIndex = 19;
            this.textBox_cmd_field7.Visible = false;
            // 
            // label_cmd_field6
            // 
            this.label_cmd_field6.AutoSize = true;
            this.label_cmd_field6.Location = new System.Drawing.Point(238, 100);
            this.label_cmd_field6.Name = "label_cmd_field6";
            this.label_cmd_field6.Size = new System.Drawing.Size(41, 13);
            this.label_cmd_field6.TabIndex = 18;
            this.label_cmd_field6.Text = "label11";
            this.label_cmd_field6.Visible = false;
            // 
            // textBox_cmd_field6
            // 
            this.textBox_cmd_field6.Location = new System.Drawing.Point(241, 116);
            this.textBox_cmd_field6.Name = "textBox_cmd_field6";
            this.textBox_cmd_field6.Size = new System.Drawing.Size(180, 20);
            this.textBox_cmd_field6.TabIndex = 17;
            this.textBox_cmd_field6.Visible = false;
            // 
            // label_cmd_field5
            // 
            this.label_cmd_field5.AutoSize = true;
            this.label_cmd_field5.Location = new System.Drawing.Point(6, 100);
            this.label_cmd_field5.Name = "label_cmd_field5";
            this.label_cmd_field5.Size = new System.Drawing.Size(35, 13);
            this.label_cmd_field5.TabIndex = 16;
            this.label_cmd_field5.Text = "label4";
            this.label_cmd_field5.Visible = false;
            // 
            // textBox_cmd_field5
            // 
            this.textBox_cmd_field5.Location = new System.Drawing.Point(6, 116);
            this.textBox_cmd_field5.Name = "textBox_cmd_field5";
            this.textBox_cmd_field5.Size = new System.Drawing.Size(180, 20);
            this.textBox_cmd_field5.TabIndex = 15;
            this.textBox_cmd_field5.Visible = false;
            // 
            // label_cmd_field4
            // 
            this.label_cmd_field4.AutoSize = true;
            this.label_cmd_field4.Location = new System.Drawing.Point(947, 53);
            this.label_cmd_field4.Name = "label_cmd_field4";
            this.label_cmd_field4.Size = new System.Drawing.Size(35, 13);
            this.label_cmd_field4.TabIndex = 14;
            this.label_cmd_field4.Text = "label4";
            this.label_cmd_field4.Visible = false;
            // 
            // textBox_cmd_field4
            // 
            this.textBox_cmd_field4.Location = new System.Drawing.Point(950, 69);
            this.textBox_cmd_field4.Name = "textBox_cmd_field4";
            this.textBox_cmd_field4.Size = new System.Drawing.Size(180, 20);
            this.textBox_cmd_field4.TabIndex = 13;
            this.textBox_cmd_field4.Visible = false;
            // 
            // label_cmd_field3
            // 
            this.label_cmd_field3.AutoSize = true;
            this.label_cmd_field3.Location = new System.Drawing.Point(708, 53);
            this.label_cmd_field3.Name = "label_cmd_field3";
            this.label_cmd_field3.Size = new System.Drawing.Size(35, 13);
            this.label_cmd_field3.TabIndex = 12;
            this.label_cmd_field3.Text = "label4";
            this.label_cmd_field3.Visible = false;
            // 
            // textBox_cmd_field3
            // 
            this.textBox_cmd_field3.Location = new System.Drawing.Point(711, 69);
            this.textBox_cmd_field3.Name = "textBox_cmd_field3";
            this.textBox_cmd_field3.Size = new System.Drawing.Size(184, 20);
            this.textBox_cmd_field3.TabIndex = 11;
            this.textBox_cmd_field3.Visible = false;
            // 
            // label_cmd_field2
            // 
            this.label_cmd_field2.AutoSize = true;
            this.label_cmd_field2.Location = new System.Drawing.Point(473, 53);
            this.label_cmd_field2.Name = "label_cmd_field2";
            this.label_cmd_field2.Size = new System.Drawing.Size(35, 13);
            this.label_cmd_field2.TabIndex = 10;
            this.label_cmd_field2.Text = "label4";
            this.label_cmd_field2.Visible = false;
            // 
            // textBox_cmd_field2
            // 
            this.textBox_cmd_field2.Location = new System.Drawing.Point(476, 69);
            this.textBox_cmd_field2.Name = "textBox_cmd_field2";
            this.textBox_cmd_field2.Size = new System.Drawing.Size(180, 20);
            this.textBox_cmd_field2.TabIndex = 9;
            this.textBox_cmd_field2.Visible = false;
            // 
            // label_cmd_field1
            // 
            this.label_cmd_field1.AutoSize = true;
            this.label_cmd_field1.Location = new System.Drawing.Point(238, 53);
            this.label_cmd_field1.Name = "label_cmd_field1";
            this.label_cmd_field1.Size = new System.Drawing.Size(35, 13);
            this.label_cmd_field1.TabIndex = 8;
            this.label_cmd_field1.Text = "label4";
            this.label_cmd_field1.Visible = false;
            // 
            // textBox_cmd_field1
            // 
            this.textBox_cmd_field1.Location = new System.Drawing.Point(241, 69);
            this.textBox_cmd_field1.Name = "textBox_cmd_field1";
            this.textBox_cmd_field1.Size = new System.Drawing.Size(180, 20);
            this.textBox_cmd_field1.TabIndex = 7;
            this.textBox_cmd_field1.Visible = false;
            // 
            // label_cmd_field0
            // 
            this.label_cmd_field0.AutoSize = true;
            this.label_cmd_field0.Location = new System.Drawing.Point(6, 53);
            this.label_cmd_field0.Name = "label_cmd_field0";
            this.label_cmd_field0.Size = new System.Drawing.Size(35, 13);
            this.label_cmd_field0.TabIndex = 6;
            this.label_cmd_field0.Text = "label4";
            this.label_cmd_field0.Visible = false;
            // 
            // textBox_cmd_field0
            // 
            this.textBox_cmd_field0.Location = new System.Drawing.Point(6, 69);
            this.textBox_cmd_field0.Name = "textBox_cmd_field0";
            this.textBox_cmd_field0.Size = new System.Drawing.Size(180, 20);
            this.textBox_cmd_field0.TabIndex = 5;
            this.textBox_cmd_field0.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Commands";
            // 
            // comboBox_command
            // 
            this.comboBox_command.FormattingEnabled = true;
            this.comboBox_command.Location = new System.Drawing.Point(6, 25);
            this.comboBox_command.Name = "comboBox_command";
            this.comboBox_command.Size = new System.Drawing.Size(298, 21);
            this.comboBox_command.TabIndex = 0;
            this.comboBox_command.SelectedIndexChanged += new System.EventHandler(this.comboBox_command_SelectedIndexChanged);
            // 
            // encode_decode
            // 
            this.encode_decode.Controls.Add(this.label_protocol_12);
            this.encode_decode.Controls.Add(this.textBox_protocol_12);
            this.encode_decode.Controls.Add(this.label_protocol_11);
            this.encode_decode.Controls.Add(this.textBox_protocol_11);
            this.encode_decode.Controls.Add(this.label_protocol_10);
            this.encode_decode.Controls.Add(this.richTextBox_protocol_10);
            this.encode_decode.Controls.Add(this.button_protocol_decode);
            this.encode_decode.Controls.Add(this.button_protocol_encode);
            this.encode_decode.Controls.Add(this.label_protocol_0);
            this.encode_decode.Controls.Add(this.label_protocol_9);
            this.encode_decode.Controls.Add(this.textBox_protocol_9);
            this.encode_decode.Controls.Add(this.textBox_protocol_0);
            this.encode_decode.Controls.Add(this.label_protocol_8);
            this.encode_decode.Controls.Add(this.textBox_protocol_8);
            this.encode_decode.Controls.Add(this.label_protocol_7);
            this.encode_decode.Controls.Add(this.textBox_protocol_7);
            this.encode_decode.Controls.Add(this.label_protocol_6);
            this.encode_decode.Controls.Add(this.textBox_protocol_6);
            this.encode_decode.Controls.Add(this.label_protocol_5);
            this.encode_decode.Controls.Add(this.textBox_protocol_5);
            this.encode_decode.Controls.Add(this.label_protocol_4);
            this.encode_decode.Controls.Add(this.textBox_protocol_4);
            this.encode_decode.Controls.Add(this.label_protocol_3);
            this.encode_decode.Controls.Add(this.textBox_protocol_3);
            this.encode_decode.Controls.Add(this.label_protocol_2);
            this.encode_decode.Controls.Add(this.textBox_protocol_2);
            this.encode_decode.Controls.Add(this.label_protocol_1);
            this.encode_decode.Controls.Add(this.textBox_protocol_1);
            this.encode_decode.Controls.Add(this.comboBox_protocols);
            this.encode_decode.Controls.Add(this.label4);
            this.encode_decode.Location = new System.Drawing.Point(4, 22);
            this.encode_decode.Name = "encode_decode";
            this.encode_decode.Padding = new System.Windows.Forms.Padding(3);
            this.encode_decode.Size = new System.Drawing.Size(1148, 321);
            this.encode_decode.TabIndex = 1;
            this.encode_decode.Text = "RC encode/decode";
            this.encode_decode.UseVisualStyleBackColor = true;
            // 
            // label_protocol_12
            // 
            this.label_protocol_12.AutoSize = true;
            this.label_protocol_12.Location = new System.Drawing.Point(657, 8);
            this.label_protocol_12.Name = "label_protocol_12";
            this.label_protocol_12.Size = new System.Drawing.Size(112, 13);
            this.label_protocol_12.TabIndex = 29;
            this.label_protocol_12.Text = "Carrier Frequency (Hz)";
            // 
            // textBox_protocol_12
            // 
            this.textBox_protocol_12.Location = new System.Drawing.Point(657, 25);
            this.textBox_protocol_12.MaxLength = 5;
            this.textBox_protocol_12.Name = "textBox_protocol_12";
            this.textBox_protocol_12.Size = new System.Drawing.Size(148, 20);
            this.textBox_protocol_12.TabIndex = 28;
            this.textBox_protocol_12.Text = "38000";
            // 
            // label_protocol_11
            // 
            this.label_protocol_11.AutoSize = true;
            this.label_protocol_11.Location = new System.Drawing.Point(492, 9);
            this.label_protocol_11.Name = "label_protocol_11";
            this.label_protocol_11.Size = new System.Drawing.Size(126, 13);
            this.label_protocol_11.TabIndex = 27;
            this.label_protocol_11.Text = "Frame maximum time (uS)";
            // 
            // textBox_protocol_11
            // 
            this.textBox_protocol_11.Location = new System.Drawing.Point(492, 26);
            this.textBox_protocol_11.MaxLength = 5;
            this.textBox_protocol_11.Name = "textBox_protocol_11";
            this.textBox_protocol_11.Size = new System.Drawing.Size(148, 20);
            this.textBox_protocol_11.TabIndex = 26;
            this.textBox_protocol_11.Text = "41000";
            // 
            // label_protocol_10
            // 
            this.label_protocol_10.AutoSize = true;
            this.label_protocol_10.Location = new System.Drawing.Point(3, 58);
            this.label_protocol_10.Name = "label_protocol_10";
            this.label_protocol_10.Size = new System.Drawing.Size(75, 13);
            this.label_protocol_10.TabIndex = 25;
            this.label_protocol_10.Text = "Decoded data";
            this.label_protocol_10.Visible = false;
            // 
            // richTextBox_protocol_10
            // 
            this.richTextBox_protocol_10.Location = new System.Drawing.Point(3, 74);
            this.richTextBox_protocol_10.Name = "richTextBox_protocol_10";
            this.richTextBox_protocol_10.ReadOnly = true;
            this.richTextBox_protocol_10.Size = new System.Drawing.Size(1136, 241);
            this.richTextBox_protocol_10.TabIndex = 24;
            this.richTextBox_protocol_10.Text = "";
            this.richTextBox_protocol_10.Visible = false;
            // 
            // button_protocol_decode
            // 
            this.button_protocol_decode.Location = new System.Drawing.Point(328, 9);
            this.button_protocol_decode.Name = "button_protocol_decode";
            this.button_protocol_decode.Size = new System.Drawing.Size(146, 37);
            this.button_protocol_decode.TabIndex = 23;
            this.button_protocol_decode.Text = "Decode";
            this.button_protocol_decode.UseVisualStyleBackColor = true;
            this.button_protocol_decode.Click += new System.EventHandler(this.button_protocol_decode_Click);
            // 
            // button_protocol_encode
            // 
            this.button_protocol_encode.Location = new System.Drawing.Point(170, 9);
            this.button_protocol_encode.Name = "button_protocol_encode";
            this.button_protocol_encode.Size = new System.Drawing.Size(146, 37);
            this.button_protocol_encode.TabIndex = 22;
            this.button_protocol_encode.Text = "Send";
            this.button_protocol_encode.UseVisualStyleBackColor = true;
            this.button_protocol_encode.Click += new System.EventHandler(this.button_protocol_encode_Click);
            // 
            // label_protocol_0
            // 
            this.label_protocol_0.AutoSize = true;
            this.label_protocol_0.Location = new System.Drawing.Point(6, 62);
            this.label_protocol_0.Name = "label_protocol_0";
            this.label_protocol_0.Size = new System.Drawing.Size(35, 13);
            this.label_protocol_0.TabIndex = 21;
            this.label_protocol_0.Text = "label5";
            this.label_protocol_0.Visible = false;
            // 
            // label_protocol_9
            // 
            this.label_protocol_9.AutoSize = true;
            this.label_protocol_9.Location = new System.Drawing.Point(911, 108);
            this.label_protocol_9.Name = "label_protocol_9";
            this.label_protocol_9.Size = new System.Drawing.Size(35, 13);
            this.label_protocol_9.TabIndex = 19;
            this.label_protocol_9.Text = "label5";
            this.label_protocol_9.Visible = false;
            // 
            // textBox_protocol_9
            // 
            this.textBox_protocol_9.Location = new System.Drawing.Point(914, 124);
            this.textBox_protocol_9.Name = "textBox_protocol_9";
            this.textBox_protocol_9.Size = new System.Drawing.Size(205, 20);
            this.textBox_protocol_9.TabIndex = 18;
            this.textBox_protocol_9.Visible = false;
            // 
            // textBox_protocol_0
            // 
            this.textBox_protocol_0.Location = new System.Drawing.Point(6, 78);
            this.textBox_protocol_0.Name = "textBox_protocol_0";
            this.textBox_protocol_0.Size = new System.Drawing.Size(205, 20);
            this.textBox_protocol_0.TabIndex = 20;
            this.textBox_protocol_0.Visible = false;
            // 
            // label_protocol_8
            // 
            this.label_protocol_8.AutoSize = true;
            this.label_protocol_8.Location = new System.Drawing.Point(684, 108);
            this.label_protocol_8.Name = "label_protocol_8";
            this.label_protocol_8.Size = new System.Drawing.Size(35, 13);
            this.label_protocol_8.TabIndex = 17;
            this.label_protocol_8.Text = "label5";
            this.label_protocol_8.Visible = false;
            // 
            // textBox_protocol_8
            // 
            this.textBox_protocol_8.Location = new System.Drawing.Point(687, 124);
            this.textBox_protocol_8.Name = "textBox_protocol_8";
            this.textBox_protocol_8.Size = new System.Drawing.Size(205, 20);
            this.textBox_protocol_8.TabIndex = 16;
            this.textBox_protocol_8.Visible = false;
            // 
            // label_protocol_7
            // 
            this.label_protocol_7.AutoSize = true;
            this.label_protocol_7.Location = new System.Drawing.Point(457, 108);
            this.label_protocol_7.Name = "label_protocol_7";
            this.label_protocol_7.Size = new System.Drawing.Size(35, 13);
            this.label_protocol_7.TabIndex = 15;
            this.label_protocol_7.Text = "label5";
            this.label_protocol_7.Visible = false;
            // 
            // textBox_protocol_7
            // 
            this.textBox_protocol_7.Location = new System.Drawing.Point(460, 124);
            this.textBox_protocol_7.Name = "textBox_protocol_7";
            this.textBox_protocol_7.Size = new System.Drawing.Size(205, 20);
            this.textBox_protocol_7.TabIndex = 14;
            this.textBox_protocol_7.Visible = false;
            // 
            // label_protocol_6
            // 
            this.label_protocol_6.AutoSize = true;
            this.label_protocol_6.Location = new System.Drawing.Point(230, 108);
            this.label_protocol_6.Name = "label_protocol_6";
            this.label_protocol_6.Size = new System.Drawing.Size(35, 13);
            this.label_protocol_6.TabIndex = 13;
            this.label_protocol_6.Text = "label5";
            this.label_protocol_6.Visible = false;
            // 
            // textBox_protocol_6
            // 
            this.textBox_protocol_6.Location = new System.Drawing.Point(233, 124);
            this.textBox_protocol_6.Name = "textBox_protocol_6";
            this.textBox_protocol_6.Size = new System.Drawing.Size(205, 20);
            this.textBox_protocol_6.TabIndex = 12;
            this.textBox_protocol_6.Visible = false;
            // 
            // label_protocol_5
            // 
            this.label_protocol_5.AutoSize = true;
            this.label_protocol_5.Location = new System.Drawing.Point(6, 108);
            this.label_protocol_5.Name = "label_protocol_5";
            this.label_protocol_5.Size = new System.Drawing.Size(35, 13);
            this.label_protocol_5.TabIndex = 11;
            this.label_protocol_5.Text = "label5";
            this.label_protocol_5.Visible = false;
            // 
            // textBox_protocol_5
            // 
            this.textBox_protocol_5.Location = new System.Drawing.Point(6, 124);
            this.textBox_protocol_5.Name = "textBox_protocol_5";
            this.textBox_protocol_5.Size = new System.Drawing.Size(205, 20);
            this.textBox_protocol_5.TabIndex = 10;
            this.textBox_protocol_5.Visible = false;
            // 
            // label_protocol_4
            // 
            this.label_protocol_4.AutoSize = true;
            this.label_protocol_4.Location = new System.Drawing.Point(911, 62);
            this.label_protocol_4.Name = "label_protocol_4";
            this.label_protocol_4.Size = new System.Drawing.Size(35, 13);
            this.label_protocol_4.TabIndex = 9;
            this.label_protocol_4.Text = "label5";
            this.label_protocol_4.Visible = false;
            // 
            // textBox_protocol_4
            // 
            this.textBox_protocol_4.Location = new System.Drawing.Point(914, 78);
            this.textBox_protocol_4.Name = "textBox_protocol_4";
            this.textBox_protocol_4.Size = new System.Drawing.Size(205, 20);
            this.textBox_protocol_4.TabIndex = 8;
            this.textBox_protocol_4.Visible = false;
            // 
            // label_protocol_3
            // 
            this.label_protocol_3.AutoSize = true;
            this.label_protocol_3.Location = new System.Drawing.Point(684, 62);
            this.label_protocol_3.Name = "label_protocol_3";
            this.label_protocol_3.Size = new System.Drawing.Size(35, 13);
            this.label_protocol_3.TabIndex = 7;
            this.label_protocol_3.Text = "label5";
            this.label_protocol_3.Visible = false;
            // 
            // textBox_protocol_3
            // 
            this.textBox_protocol_3.Location = new System.Drawing.Point(687, 78);
            this.textBox_protocol_3.Name = "textBox_protocol_3";
            this.textBox_protocol_3.Size = new System.Drawing.Size(205, 20);
            this.textBox_protocol_3.TabIndex = 6;
            this.textBox_protocol_3.Visible = false;
            // 
            // label_protocol_2
            // 
            this.label_protocol_2.AutoSize = true;
            this.label_protocol_2.Location = new System.Drawing.Point(457, 62);
            this.label_protocol_2.Name = "label_protocol_2";
            this.label_protocol_2.Size = new System.Drawing.Size(35, 13);
            this.label_protocol_2.TabIndex = 5;
            this.label_protocol_2.Text = "label5";
            this.label_protocol_2.Visible = false;
            // 
            // textBox_protocol_2
            // 
            this.textBox_protocol_2.Location = new System.Drawing.Point(460, 78);
            this.textBox_protocol_2.Name = "textBox_protocol_2";
            this.textBox_protocol_2.Size = new System.Drawing.Size(205, 20);
            this.textBox_protocol_2.TabIndex = 4;
            this.textBox_protocol_2.Visible = false;
            // 
            // label_protocol_1
            // 
            this.label_protocol_1.AutoSize = true;
            this.label_protocol_1.Location = new System.Drawing.Point(230, 62);
            this.label_protocol_1.Name = "label_protocol_1";
            this.label_protocol_1.Size = new System.Drawing.Size(35, 13);
            this.label_protocol_1.TabIndex = 3;
            this.label_protocol_1.Text = "label5";
            this.label_protocol_1.Visible = false;
            // 
            // textBox_protocol_1
            // 
            this.textBox_protocol_1.Location = new System.Drawing.Point(233, 78);
            this.textBox_protocol_1.Name = "textBox_protocol_1";
            this.textBox_protocol_1.Size = new System.Drawing.Size(205, 20);
            this.textBox_protocol_1.TabIndex = 2;
            this.textBox_protocol_1.Visible = false;
            // 
            // comboBox_protocols
            // 
            this.comboBox_protocols.FormattingEnabled = true;
            this.comboBox_protocols.Location = new System.Drawing.Point(6, 25);
            this.comboBox_protocols.Name = "comboBox_protocols";
            this.comboBox_protocols.Size = new System.Drawing.Size(152, 21);
            this.comboBox_protocols.TabIndex = 1;
            this.comboBox_protocols.SelectedIndexChanged += new System.EventHandler(this.comboBox_protocols_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Protocols";
            // 
            // timer_decoder
            // 
            this.timer_decoder.Interval = 10;
            this.timer_decoder.Tick += new System.EventHandler(this.timer_decoder_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(1174, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.licenseToolStripMenuItem,
            this.infoToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // licenseToolStripMenuItem
            // 
            this.licenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gNULicenseToolStripMenuItem});
            this.licenseToolStripMenuItem.Name = "licenseToolStripMenuItem";
            this.licenseToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.licenseToolStripMenuItem.Text = "License";
            // 
            // gNULicenseToolStripMenuItem
            // 
            this.gNULicenseToolStripMenuItem.Name = "gNULicenseToolStripMenuItem";
            this.gNULicenseToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.gNULicenseToolStripMenuItem.Text = "GNU license";
            this.gNULicenseToolStripMenuItem.Click += new System.EventHandler(this.gNULicenseToolStripMenuItem_Click_1);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readmeToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // readmeToolStripMenuItem
            // 
            this.readmeToolStripMenuItem.Name = "readmeToolStripMenuItem";
            this.readmeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.readmeToolStripMenuItem.Text = "Readme";
            this.readmeToolStripMenuItem.Click += new System.EventHandler(this.readmeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.githubProjectToolStripMenuItem,
            this.iRToolDatasheetToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // githubProjectToolStripMenuItem
            // 
            this.githubProjectToolStripMenuItem.Name = "githubProjectToolStripMenuItem";
            this.githubProjectToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.githubProjectToolStripMenuItem.Text = "Github Project";
            this.githubProjectToolStripMenuItem.Click += new System.EventHandler(this.githubProjectToolStripMenuItem_Click);
            // 
            // iRToolDatasheetToolStripMenuItem
            // 
            this.iRToolDatasheetToolStripMenuItem.Name = "iRToolDatasheetToolStripMenuItem";
            this.iRToolDatasheetToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.iRToolDatasheetToolStripMenuItem.Text = "IR Tool datasheet ";
            this.iRToolDatasheetToolStripMenuItem.Click += new System.EventHandler(this.iRToolDatasheetToolStripMenuItem_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button_sendfile_send);
            this.tabPage1.Controls.Add(this.textBox_filesend_file_to_send);
            this.tabPage1.Controls.Add(this.button_filesend_open);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1148, 321);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "FileSend";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button_filesend_open
            // 
            this.button_filesend_open.Location = new System.Drawing.Point(979, 60);
            this.button_filesend_open.Name = "button_filesend_open";
            this.button_filesend_open.Size = new System.Drawing.Size(75, 23);
            this.button_filesend_open.TabIndex = 0;
            this.button_filesend_open.Text = "...";
            this.button_filesend_open.UseVisualStyleBackColor = true;
            this.button_filesend_open.Click += new System.EventHandler(this.button_filesend_open_Click);
            // 
            // textBox_filesend_file_to_send
            // 
            this.textBox_filesend_file_to_send.Location = new System.Drawing.Point(10, 62);
            this.textBox_filesend_file_to_send.Name = "textBox_filesend_file_to_send";
            this.textBox_filesend_file_to_send.Size = new System.Drawing.Size(963, 20);
            this.textBox_filesend_file_to_send.TabIndex = 1;
            this.textBox_filesend_file_to_send.TextChanged += new System.EventHandler(this.textBox_filesend_file_to_send_TextChanged);
            // 
            // button_sendfile_send
            // 
            this.button_sendfile_send.Enabled = false;
            this.button_sendfile_send.Location = new System.Drawing.Point(10, 88);
            this.button_sendfile_send.Name = "button_sendfile_send";
            this.button_sendfile_send.Size = new System.Drawing.Size(149, 23);
            this.button_sendfile_send.TabIndex = 2;
            this.button_sendfile_send.Text = "Send";
            this.button_sendfile_send.UseVisualStyleBackColor = true;
            this.button_sendfile_send.Click += new System.EventHandler(this.button_sendfile_send_Click);
            // 
            // timer_filesend
            // 
            this.timer_filesend.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 725);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tabControl_work);
            this.Controls.Add(this.groupBox_device_info);
            this.Controls.Add(this.bps);
            this.Controls.Add(this.textBox_serial_speed);
            this.Controls.Add(this.richTextBox_printout);
            this.Controls.Add(this.button_PortConnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_SerialPortList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Raging Bits IR Tool SW V1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_device_info.ResumeLayout(false);
            this.groupBox_device_info.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_error)).EndInit();
            this.tabControl_work.ResumeLayout(false);
            this.tool_commands.ResumeLayout(false);
            this.tool_commands.PerformLayout();
            this.encode_decode.ResumeLayout(false);
            this.encode_decode.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_SerialPortList;
        private System.Windows.Forms.Timer work_timer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_PortConnect;
        private System.Windows.Forms.Timer timer_serial_port_auto_speed;
        private System.Windows.Forms.RichTextBox richTextBox_printout;
        private System.Windows.Forms.TextBox textBox_serial_speed;
        private System.Windows.Forms.Label bps;
        private System.Windows.Forms.GroupBox groupBox_device_info;
        private System.Windows.Forms.Label label_device_hw_rev;
        private System.Windows.Forms.TextBox textBox_device_hw_rev;
        private System.Windows.Forms.Label label_device_sw_rev;
        private System.Windows.Forms.TextBox textBox_device_sw_rev;
        private System.Windows.Forms.Label label_device_serial;
        private System.Windows.Forms.TextBox textBox_device_serial_number;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider_error;
        private System.Windows.Forms.TabControl tabControl_work;
        private System.Windows.Forms.TabPage tool_commands;
        private System.Windows.Forms.Button button_cmd_send;
        private System.Windows.Forms.RichTextBox richTextBox_cmd_field10;
        private System.Windows.Forms.Label label_cmd_field10;
        private System.Windows.Forms.Label label_cmd_field9;
        private System.Windows.Forms.TextBox textBox_cmd_field9;
        private System.Windows.Forms.Label label_cmd_field8;
        private System.Windows.Forms.TextBox textBox_cmd_field8;
        private System.Windows.Forms.Label label_cmd_field7;
        private System.Windows.Forms.TextBox textBox_cmd_field7;
        private System.Windows.Forms.Label label_cmd_field6;
        private System.Windows.Forms.TextBox textBox_cmd_field6;
        private System.Windows.Forms.Label label_cmd_field5;
        private System.Windows.Forms.TextBox textBox_cmd_field5;
        private System.Windows.Forms.Label label_cmd_field4;
        private System.Windows.Forms.TextBox textBox_cmd_field4;
        private System.Windows.Forms.Label label_cmd_field3;
        private System.Windows.Forms.TextBox textBox_cmd_field3;
        private System.Windows.Forms.Label label_cmd_field2;
        private System.Windows.Forms.TextBox textBox_cmd_field2;
        private System.Windows.Forms.Label label_cmd_field1;
        private System.Windows.Forms.TextBox textBox_cmd_field1;
        private System.Windows.Forms.Label label_cmd_field0;
        private System.Windows.Forms.TextBox textBox_cmd_field0;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_command;
        private System.Windows.Forms.TabPage encode_decode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_protocols;
        private System.Windows.Forms.Button button_protocol_decode;
        private System.Windows.Forms.Button button_protocol_encode;
        private System.Windows.Forms.Label label_protocol_0;
        private System.Windows.Forms.TextBox textBox_protocol_0;
        private System.Windows.Forms.Label label_protocol_9;
        private System.Windows.Forms.TextBox textBox_protocol_9;
        private System.Windows.Forms.Label label_protocol_8;
        private System.Windows.Forms.TextBox textBox_protocol_8;
        private System.Windows.Forms.Label label_protocol_7;
        private System.Windows.Forms.TextBox textBox_protocol_7;
        private System.Windows.Forms.Label label_protocol_6;
        private System.Windows.Forms.TextBox textBox_protocol_6;
        private System.Windows.Forms.Label label_protocol_5;
        private System.Windows.Forms.TextBox textBox_protocol_5;
        private System.Windows.Forms.Label label_protocol_4;
        private System.Windows.Forms.TextBox textBox_protocol_4;
        private System.Windows.Forms.Label label_protocol_3;
        private System.Windows.Forms.TextBox textBox_protocol_3;
        private System.Windows.Forms.Label label_protocol_2;
        private System.Windows.Forms.TextBox textBox_protocol_2;
        private System.Windows.Forms.Label label_protocol_1;
        private System.Windows.Forms.TextBox textBox_protocol_1;
        private System.Windows.Forms.Label label_protocol_10;
        private System.Windows.Forms.RichTextBox richTextBox_protocol_10;
        private System.Windows.Forms.Timer timer_decoder;
        private System.Windows.Forms.Label label_protocol_11;
        private System.Windows.Forms.TextBox textBox_protocol_11;
        private System.Windows.Forms.Label label_protocol_12;
        private System.Windows.Forms.TextBox textBox_protocol_12;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gNULicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readmeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem githubProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iRToolDatasheetToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button_filesend_open;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox_filesend_file_to_send;
        private System.Windows.Forms.Button button_sendfile_send;
        private System.Windows.Forms.Timer timer_filesend;
    }
}

