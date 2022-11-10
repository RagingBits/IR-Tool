using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Raging_Bits_IR_Tool
{
    public partial class Form1 : Form
    {

        string BUTTON_CONNECT_PORT_TEXT_CONNECT = "Connect";
        string BUTTON_CONNECT_PORT_TEXT_CONNECTING = "Connecting...";
        string BUTTON_CONNECT_PORT_TEXT_DISCONNECT = "Disconnect";

        int MAX_CARRIER_FREQUENCY = 60000;
        int MIN_CARRIER_FREQUENCY = 20000;

        int MAX_TIMEOUT = 65000;
        int MIN_TIMEOUT = 250;

        string CMD_AT_INFO = "AT+INFO\r\n";
        string CMD_AT_DECODE = "AT+IR_RAW_GET:";
        string CMD_AT_ENCODE = "AT+IR_RAW_SEND:";

        private struct ir_command_field_t
        {
            public string name { get; set; }
            public int type { get; set; }
            public int min { get; set; }
            public int max { get; set; }
        };

        struct ir_command_io_t
        {
            public string name { get; set; }
            public string at_invoke { get; set; }
            public string field_json { get; set; }
        };

        struct ir_command_t
        {
            public string name { get; set; }
            public string at_invoke { get; set; }
            public List<ir_command_field_t> fields { get; set; }
        };



        private struct ir_encoder_decoder_field_t
        {
            public string name { get; set; }
            public int group { get; set; }
            public int min { get; set; }
            public int max { get; set; }
        };

        struct ir_encoder_decoder_io_t
        {
            public string name { get; set; }
            public string path { get; set; }
            public string field_json { get; set; }
        };

        struct ir_encoder_decoder_t
        {
            public string name { get; set; }
            public string path { get; set; }
            public List<ir_encoder_decoder_field_t> fields { get; set; }
        };


        static List<int> serial_port_speeds = new List<int>
        {
            115200,
            57600,
            38400,
            19200,
            14400,
            9600,
            7200,
            4800,
            1200,
            600,
            300
        };

        static List<int> serial_port_autobaud_timeout = new List<int>
        {
            300,
            300,
            300,
            300,
            500,
            500,
            500,
            500,
            500,
            1000,
            2000
        };

        static List<string> serial_port_names = new List<string>();


        string serial_port_name = "";
        string serial_port_name_current = "";
        int serial_port_speeds_index = 0;
        int serial_port_speed = serial_port_speeds[0];
        SerialPort serial_port = new SerialPort();

        int current_connection_state = 0;

        private List<ir_command_t> available_commands;
        private List<ir_encoder_decoder_t> available_encoders_decoders;
        private string decoders_received_raw_data = "";
        private int decoders_decode_stage = 0;


        private int file_send_items_counter = 0;
        private List<string> file_send_items = new List<string>();


        private void load_commands_list()
        {

            //StreamReader command_list = File.OpenText("command_list.cfg");
            string jsonString = File.ReadAllText("command_list.cfg");

            List<ir_command_io_t> list_of__commands = JsonConvert.DeserializeObject<List<ir_command_io_t>>(jsonString);

            foreach (ir_command_io_t cmd in list_of__commands)
            {
                ir_command_t temp = new ir_command_t();
                temp.at_invoke = cmd.at_invoke;
                temp.name = cmd.name;
                temp.fields = new List<ir_command_field_t>();

                if (cmd.field_json != null)
                {
                    List<ir_command_field_t> temp2 = JsonConvert.DeserializeObject<List<ir_command_field_t>>(cmd.field_json);

                    foreach (ir_command_field_t field in temp2)
                    {
                        temp.fields.Add(field);
                    }

                }
                available_commands.Add(temp);
            }

        }

        private void load_encoders_decoders_list()
        {

            //StreamReader command_list = File.OpenText("command_list.cfg");
            string jsonString = File.ReadAllText("encoder_decoder_list.cfg");

            List<ir_encoder_decoder_io_t> list_of__commands = JsonConvert.DeserializeObject<List<ir_encoder_decoder_io_t>>(jsonString);

            foreach (ir_encoder_decoder_io_t cmd in list_of__commands)
            {
                ir_encoder_decoder_t temp = new ir_encoder_decoder_t();
                temp.path = cmd.path;
                temp.name = cmd.name;
                temp.fields = new List<ir_encoder_decoder_field_t>();

                if (cmd.field_json != null)
                {
                    List<ir_encoder_decoder_field_t> temp2 = JsonConvert.DeserializeObject<List<ir_encoder_decoder_field_t>>(cmd.field_json);

                    foreach (ir_encoder_decoder_field_t field in temp2)
                    {
                        temp.fields.Add(field);
                    }

                }
                available_encoders_decoders.Add(temp);
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();

            if (!File.Exists("command_list.cfg"))
            {
                MessageBox.Show("command_list.cfg not found!", "Loading error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            else
            {
                available_commands = new List<ir_command_t>();

                try
                {

                    load_commands_list();

                    foreach (ir_command_t command in available_commands)
                    {
                        comboBox_command.Items.Add(command.name);
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("File command_list.cfg is invalid!", "Loading error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                }
            }



            if (!File.Exists("encoder_decoder_list.cfg"))
            {
                MessageBox.Show("encoder_decoder_list.cfg not found!", "Loading error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            else
            {
                available_encoders_decoders = new List<ir_encoder_decoder_t>();

                try
                {

                    load_encoders_decoders_list();

                    foreach (ir_encoder_decoder_t protocol in available_encoders_decoders)
                    {
                        comboBox_protocols.Items.Add(protocol.name);
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("File encoder_decoder_list.cfg is invalid!", "Loading error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                }
            }
        }

        private void serial_send(string data)
        {
            if (serial_port.IsOpen)
            {
                serial_port.Write(data);
                richTextBox_printout.AppendText(data);
                richTextBox_printout.ScrollToCaret();
            }
        }

        private string serial_get()
        {
            string data = "";
            if (serial_port.IsOpen)
            {
                try
                {
                    data = serial_port.ReadExisting();

                    if (data != "")
                    {
                        richTextBox_printout.AppendText(data);
                        richTextBox_printout.ScrollToCaret();

                        if (current_connection_state == 3)
                        {
                            decoders_received_raw_data += data;
                        }

                    }
                } catch (Exception)
                {
                }

            }

            return data;
        }

        private void serial_port_combobox_work()
        {
            /* Search for serial ports and list them in the drop box. */
            string[] ports = SerialPort.GetPortNames();
            /*var searcher = new ManagementObjectSearcher("SELECT * FROM WIN32_SerialPort");

            var ports_info = searcher.Get().Cast<ManagementBaseObject>().ToList();
            */
            int current_index = comboBox_SerialPortList.SelectedIndex;
            /*
            var tList = (from n in ports
                         join p in ports_info on n equals p["DeviceID"].ToString()
                         select p["Caption"]).ToList();
            */

            if (current_index == -1)
            {
                current_index = ports.Length - 1;
            }


            if (current_index != -1 && ports.Length > current_index)
            {
                serial_port_name_current = ports[current_index];
            }
            else
            {
                current_index = ports.Length - 1;
                serial_port_name_current = "";
            }


            comboBox_SerialPortList.DataSource = ports;
            comboBox_SerialPortList.SelectedIndex = current_index;
        }


        private void serial_port_autobaud()
        {
            string serial_input = "";
            bool success = true;
            try
            {
                serial_input = serial_get();
            }
            catch (Exception)
            {
                success = false;
            }


            if (success && serial_input.Contains("INFO:"))
            {
                /* Found Boud. */
                current_connection_state = 2;
                work_timer.Interval = 10;
            }
            else
            {
                /* Try next Boudrate. */
                serial_port_speeds_index++;
                if (serial_port_speeds_index >= serial_port_speeds.Count)
                {
                    serial_port_speeds_index = 0;
                    // current_connection_state = 0;

                }

                timer_serial_port_auto_speed.Interval = serial_port_autobaud_timeout[serial_port_speeds_index];
                serial_port_speed = serial_port_speeds[serial_port_speeds_index];


                serial_port.Close();

                serial_port.BaudRate = serial_port_speed;

                success = true;

                try
                {
                    serial_port.Open();
                    serial_port.DiscardInBuffer();
                }
                catch (Exception)
                {
                    success = false;
                }

                if (success)
                {
                    textBox_serial_speed.Text = serial_port_speed.ToString();
                    serial_send(CMD_AT_INFO);
                }
                else
                {
                    current_connection_state = 0;
                }
            }

            if (current_connection_state != 1)
            {
                timer_serial_port_auto_speed.Enabled = false;

                if (current_connection_state == 2)
                {
                    button_PortConnect.Text = BUTTON_CONNECT_PORT_TEXT_DISCONNECT;

                    textBox_device_serial_number.Text = serial_input.Substring(5, 10);
                    textBox_device_sw_rev.Text = serial_input.Substring(16, 10);
                    textBox_device_hw_rev.Text = serial_input.Substring(27, 10);
                    tabControl_work.Visible = true;
                }
                else
                {
                    comboBox_SerialPortList.Enabled = true;
                    button_PortConnect.Text = BUTTON_CONNECT_PORT_TEXT_CONNECT;
                    serial_port_name = "";
                    textBox_serial_speed.Text = "";
                    textBox_device_serial_number.Text = "";
                    textBox_device_sw_rev.Text = "";
                    textBox_device_hw_rev.Text = "";
                    tabControl_work.Visible = false;
                }
            }
        }

        private void button_PortConnect_Click(object sender, EventArgs e)
        {
            if (current_connection_state == 0)
            {
                if (-1 != comboBox_SerialPortList.SelectedIndex)
                {

                    bool success = true;

                    if (serial_port.IsOpen)
                    {
                        serial_port.Close();
                    }



                    serial_port.PortName = serial_port_name_current;
                    serial_port.BaudRate = serial_port_speed;
                    serial_port.Parity = Parity.None;
                    serial_port.DataBits = 8;
                    serial_port.Handshake = Handshake.None;
                    serial_port.ReadTimeout = 0;
                    try
                    {
                        serial_port.Open();
                        serial_port.DiscardInBuffer();
                    } catch (Exception)
                    {
                        success = false;
                    }

                    if (success)
                    {

                        comboBox_SerialPortList.Enabled = false;
                        button_PortConnect.Text = BUTTON_CONNECT_PORT_TEXT_CONNECTING;

                        /* Start auto baud detection. */

                        serial_send(CMD_AT_INFO);
                        textBox_serial_speed.Text = serial_port_speed.ToString();

                        timer_serial_port_auto_speed.Interval = serial_port_autobaud_timeout[serial_port_speeds_index];
                        timer_serial_port_auto_speed.Enabled = true;
                        current_connection_state = 1;

                        serial_port_name = serial_port_name_current;

                    }
                }
            }
            else
            {
                if (current_connection_state == 3)
                {
                    timer_decoder.Enabled = false;
                    button_protocol_encode.Enabled = true;
                    button_protocol_decode.Enabled = true;
                    label_protocol_10.Visible = false;
                    richTextBox_protocol_10.Visible = false;
                }

                work_timer.Interval = 1000;
                timer_serial_port_auto_speed.Enabled = false;
                comboBox_SerialPortList.Enabled = true;
                button_PortConnect.Text = BUTTON_CONNECT_PORT_TEXT_CONNECT;
                current_connection_state = 0;
                serial_port_name = "";
                textBox_serial_speed.Text = "";
                textBox_device_serial_number.Text = "";
                textBox_device_sw_rev.Text = "";
                textBox_device_hw_rev.Text = "";
                tabControl_work.Visible = false;
            }
        }

        private void timer_serial_port_auto_speed_Tick(object sender, EventArgs e)
        {
            serial_port_autobaud();
        }

        private void work_timer_Tick(object sender, EventArgs e)
        {
            /* Update serial port combobox. */

            if (current_connection_state == 0)
            {
                serial_port_combobox_work();
            }
            else
            if (current_connection_state >= 2)
            {
                serial_get();
            }
            else
            {

            }
        }

        private void comboBox_command_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (-1 != comboBox_command.SelectedIndex)
            {
                if (!button_cmd_send.Visible)
                {
                    button_cmd_send.Visible = true;
                }


                label_cmd_field0.Visible = false;
                label_cmd_field1.Visible = false;
                label_cmd_field2.Visible = false;
                label_cmd_field3.Visible = false;
                label_cmd_field4.Visible = false;
                label_cmd_field5.Visible = false;
                label_cmd_field6.Visible = false;
                label_cmd_field7.Visible = false;
                label_cmd_field8.Visible = false;
                label_cmd_field9.Visible = false;
                label_cmd_field10.Visible = false;

                textBox_cmd_field0.Visible = false;
                textBox_cmd_field1.Visible = false;
                textBox_cmd_field2.Visible = false;
                textBox_cmd_field3.Visible = false;
                textBox_cmd_field4.Visible = false;
                textBox_cmd_field5.Visible = false;
                textBox_cmd_field6.Visible = false;
                textBox_cmd_field7.Visible = false;
                textBox_cmd_field8.Visible = false;
                textBox_cmd_field9.Visible = false;
                richTextBox_cmd_field10.Visible = false;


                int counter = available_commands[comboBox_command.SelectedIndex].fields.Count;

                while (counter != 0)
                {
                    counter--;

                    if (available_commands[comboBox_command.SelectedIndex].fields[counter].type > 1)
                    {
                        label_cmd_field10.Text = available_commands[comboBox_command.SelectedIndex].fields[counter].name;
                        label_cmd_field10.Visible = true;
                        richTextBox_cmd_field10.Visible = true;
                    }
                    else
                    {

                        switch (counter)
                        {
                            case 0:
                                {
                                    label_cmd_field0.Text = available_commands[comboBox_command.SelectedIndex].fields[counter].name;
                                    label_cmd_field0.Visible = true;
                                    textBox_cmd_field0.Visible = true;
                                }
                                break;

                            case 1:
                                {
                                    label_cmd_field1.Text = available_commands[comboBox_command.SelectedIndex].fields[counter].name;
                                    label_cmd_field1.Visible = true;
                                    textBox_cmd_field1.Visible = true;
                                }
                                break;

                            case 2:
                                {
                                    label_cmd_field2.Text = available_commands[comboBox_command.SelectedIndex].fields[counter].name;
                                    label_cmd_field2.Visible = true;
                                    textBox_cmd_field2.Visible = true;
                                }
                                break;

                            case 3:
                                {
                                    label_cmd_field3.Text = available_commands[comboBox_command.SelectedIndex].fields[counter].name;
                                    label_cmd_field3.Visible = true;
                                    textBox_cmd_field3.Visible = true;
                                }
                                break;

                            case 4:
                                {
                                    label_cmd_field4.Text = available_commands[comboBox_command.SelectedIndex].fields[counter].name;
                                    label_cmd_field4.Visible = true;
                                    textBox_cmd_field4.Visible = true;
                                }
                                break;

                            case 5:
                                {
                                    label_cmd_field5.Text = available_commands[comboBox_command.SelectedIndex].fields[counter].name;
                                    label_cmd_field5.Visible = true;
                                    textBox_cmd_field5.Visible = true;
                                }
                                break;

                            case 6:
                                {
                                    label_cmd_field6.Text = available_commands[comboBox_command.SelectedIndex].fields[counter].name;
                                    label_cmd_field6.Visible = true;
                                    textBox_cmd_field6.Visible = true;
                                }
                                break;

                            case 7:
                                {
                                    label_cmd_field7.Text = available_commands[comboBox_command.SelectedIndex].fields[counter].name;
                                    label_cmd_field7.Visible = true;
                                    textBox_cmd_field7.Visible = true;
                                }
                                break;

                            case 8:
                                {
                                    label_cmd_field8.Text = available_commands[comboBox_command.SelectedIndex].fields[counter].name;
                                    label_cmd_field8.Visible = true;
                                    textBox_cmd_field8.Visible = true;
                                }
                                break;

                            case 9:
                                {
                                    label_cmd_field9.Text = available_commands[comboBox_command.SelectedIndex].fields[counter].name;
                                    label_cmd_field9.Visible = true;
                                    textBox_cmd_field9.Visible = true;
                                }
                                break;
                        }
                    }


                }
            }


        }

        private void button_cmd_send_Click(object sender, EventArgs e)
        {
            int counter = 0;
            string command_to_send = available_commands[comboBox_command.SelectedIndex].at_invoke;

            while (counter < available_commands[comboBox_command.SelectedIndex].fields.Count)
            {


                if (available_commands[comboBox_command.SelectedIndex].fields[counter].type > 1)
                {
                    List<string> List_of_values_strings = richTextBox_cmd_field10.Text.Split(',').ToList();

                    if (available_commands[comboBox_command.SelectedIndex].fields[counter].type == 2)
                    {
                        try
                        {

                            int counter_values = 1;
                            foreach (string value in List_of_values_strings)
                            {
                                if (int.TryParse(value, out int data))
                                {
                                    if ((data > available_commands[comboBox_command.SelectedIndex].fields[counter].max) ||
                                    (data < available_commands[comboBox_command.SelectedIndex].fields[counter].min))
                                    {
                                        MessageBox.Show("In field " + available_commands[comboBox_command.SelectedIndex].fields[counter].name +
                                                        " item " + counter_values.ToString() + " with value " + data.ToString() +
                                                        " is outside range.", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Field " + available_commands[comboBox_command.SelectedIndex].fields[counter].name +
                                                    " has invalid values.", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                counter_values++;
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Field " + available_commands[comboBox_command.SelectedIndex].fields[counter].name +
                                                    " has invalid values.", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return;
                        }

                        command_to_send += List_of_values_strings.Count.ToString();
                    }
                    else
                    {

                        string data = richTextBox_cmd_field10.Text;

                        if ((data.Length > available_commands[comboBox_command.SelectedIndex].fields[counter].max) ||
                            (data.Length < available_commands[comboBox_command.SelectedIndex].fields[counter].min))
                        {
                            MessageBox.Show("Field " + available_commands[comboBox_command.SelectedIndex].fields[counter].name +
                                                    " has invalid data length.", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        command_to_send += data.Length.ToString();

                    }


                    command_to_send += ',';
                    command_to_send += richTextBox_cmd_field10.Text;
                }
                else
                {
                    string value = "";
                    switch (counter)
                    {
                        case 0:
                            {
                                value = textBox_cmd_field0.Text;
                            }
                            break;

                        case 1:
                            {
                                value = textBox_cmd_field1.Text;
                            }
                            break;

                        case 2:
                            {
                                value = textBox_cmd_field2.Text;
                            }
                            break;

                        case 3:
                            {
                                value = textBox_cmd_field3.Text;
                            }
                            break;

                        case 4:
                            {
                                value = textBox_cmd_field4.Text;
                            }
                            break;

                        case 5:
                            {
                                value = textBox_cmd_field5.Text;
                            }
                            break;

                        case 6:
                            {
                                value = textBox_cmd_field6.Text;
                            }
                            break;

                        case 7:
                            {
                                value = textBox_cmd_field7.Text;
                            }
                            break;

                        case 8:
                            {
                                value = textBox_cmd_field8.Text;
                            }
                            break;

                        case 9:
                            {
                                value = textBox_cmd_field9.Text;
                            }
                            break;
                    }



                    if (int.TryParse(value, out int data))
                    {


                        if ((data > available_commands[comboBox_command.SelectedIndex].fields[counter].max) ||
                        (data < available_commands[comboBox_command.SelectedIndex].fields[counter].min))
                        {
                            MessageBox.Show("Field " + available_commands[comboBox_command.SelectedIndex].fields[counter].name +
                                            " value " + data.ToString() +
                                            " is outside range.", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Field " + available_commands[comboBox_command.SelectedIndex].fields[counter].name +
                                        " has invalid values.", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    command_to_send += value;


                }

                counter++;

                if (counter < available_commands[comboBox_command.SelectedIndex].fields.Count)
                {
                    command_to_send += ',';
                }
            }

            command_to_send += "\n";

            serial_send(command_to_send);
        }

        private void comboBox_protocols_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_connection_state = 2;
            button_protocol_encode.Enabled = true;
            button_protocol_decode.Enabled = true;
            timer_decoder.Enabled = false;

            label_protocol_0.Visible = false;
            label_protocol_1.Visible = false;
            label_protocol_2.Visible = false;
            label_protocol_3.Visible = false;
            label_protocol_4.Visible = false;
            label_protocol_5.Visible = false;
            label_protocol_6.Visible = false;
            label_protocol_7.Visible = false;
            label_protocol_8.Visible = false;
            label_protocol_9.Visible = false;
            label_protocol_10.Visible = false;

            textBox_protocol_0.Visible = false;
            textBox_protocol_1.Visible = false;
            textBox_protocol_2.Visible = false;
            textBox_protocol_3.Visible = false;
            textBox_protocol_4.Visible = false;
            textBox_protocol_5.Visible = false;
            textBox_protocol_6.Visible = false;
            textBox_protocol_7.Visible = false;
            textBox_protocol_8.Visible = false;
            textBox_protocol_9.Visible = false;
            richTextBox_protocol_10.Visible = false;

            textBox_protocol_0.Text = "";
            textBox_protocol_1.Text = "";
            textBox_protocol_2.Text = "";
            textBox_protocol_3.Text = "";
            textBox_protocol_4.Text = "";
            textBox_protocol_5.Text = "";
            textBox_protocol_6.Text = "";
            textBox_protocol_7.Text = "";
            textBox_protocol_8.Text = "";
            textBox_protocol_9.Text = "";

            textBox_protocol_11.Enabled = true;
            textBox_protocol_12.Enabled = true;

            if (comboBox_protocols.SelectedIndex >= 0)
            {
                int field_iterator = 0;

                while (field_iterator < available_encoders_decoders[comboBox_protocols.SelectedIndex].fields.Count)
                {
                    switch (field_iterator)
                    {
                        case 0:
                            {
                                label_protocol_0.Text = available_encoders_decoders[comboBox_protocols.SelectedIndex].fields[field_iterator].name;
                                label_protocol_0.Visible = true;
                                textBox_protocol_0.Visible = true;
                            }
                            break;

                        case 1:
                            {
                                label_protocol_1.Text = available_encoders_decoders[comboBox_protocols.SelectedIndex].fields[field_iterator].name;
                                label_protocol_1.Visible = true;
                                textBox_protocol_1.Visible = true;
                            }
                            break;

                        case 2:
                            {
                                label_protocol_2.Text = available_encoders_decoders[comboBox_protocols.SelectedIndex].fields[field_iterator].name;
                                label_protocol_2.Visible = true;
                                textBox_protocol_2.Visible = true;
                            }
                            break;

                        case 3:
                            {
                                label_protocol_3.Text = available_encoders_decoders[comboBox_protocols.SelectedIndex].fields[field_iterator].name;
                                label_protocol_3.Visible = true;
                                textBox_protocol_3.Visible = true;
                            }
                            break;

                        case 4:
                            {
                                label_protocol_4.Text = available_encoders_decoders[comboBox_protocols.SelectedIndex].fields[field_iterator].name;
                                label_protocol_4.Visible = true;
                                textBox_protocol_4.Visible = true;
                            }
                            break;

                        case 5:
                            {
                                label_protocol_5.Text = available_encoders_decoders[comboBox_protocols.SelectedIndex].fields[field_iterator].name;
                                label_protocol_5.Visible = true;
                                textBox_protocol_5.Visible = true;
                            }
                            break;

                        case 6:
                            {
                                label_protocol_6.Text = available_encoders_decoders[comboBox_protocols.SelectedIndex].fields[field_iterator].name;
                                label_protocol_6.Visible = true;
                                textBox_protocol_6.Visible = true;
                            }
                            break;

                        case 7:
                            {
                                label_protocol_7.Text = available_commands[comboBox_protocols.SelectedIndex].fields[field_iterator].name;
                                label_protocol_7.Visible = true;
                                textBox_protocol_7.Visible = true;
                            }
                            break;

                        case 8:
                            {
                                label_protocol_8.Text = available_commands[comboBox_protocols.SelectedIndex].fields[field_iterator].name;
                                label_protocol_8.Visible = true;
                                textBox_protocol_8.Visible = true;
                            }
                            break;

                        case 9:
                            {
                                label_protocol_9.Text = available_commands[comboBox_protocols.SelectedIndex].fields[field_iterator].name;
                                label_protocol_9.Visible = true;
                                textBox_protocol_9.Visible = true;
                            }
                            break;
                    }

                    field_iterator++;
                }

            }
        }

        private void button_protocol_encode_Click(object sender, EventArgs e)
        {
            /* Encode command to times. */

            string command = " encode ";

            int current_work_group = -1;
            int field_counter = 0;


            while (field_counter < available_encoders_decoders[comboBox_protocols.SelectedIndex].fields.Count)
            {
                string value = "";
                switch (field_counter)
                {
                    case 0: { value = textBox_protocol_0.Text; } break;
                    case 1: { value = textBox_protocol_1.Text; } break;
                    case 2: { value = textBox_protocol_2.Text; } break;
                    case 3: { value = textBox_protocol_3.Text; } break;
                    case 4: { value = textBox_protocol_4.Text; } break;
                    case 5: { value = textBox_protocol_5.Text; } break;
                    case 6: { value = textBox_protocol_6.Text; } break;
                    case 7: { value = textBox_protocol_7.Text; } break;
                    case 8: { value = textBox_protocol_8.Text; } break;
                    case 9: { value = textBox_protocol_9.Text; } break;
                }

                if (value != "" &&  value != null)
                {
                    if (current_work_group == -1)
                    {
                        current_work_group = available_encoders_decoders[comboBox_protocols.SelectedIndex].fields[field_counter].group;
                    }

                    if (current_work_group == available_encoders_decoders[comboBox_protocols.SelectedIndex].fields[field_counter].group)
                    {
                        if (value != "" && value != null && int.TryParse(value, out int data))
                        {
                            if ((data > available_encoders_decoders[comboBox_protocols.SelectedIndex].fields[field_counter].max) ||
                            (data < available_encoders_decoders[comboBox_protocols.SelectedIndex].fields[field_counter].min))
                            {
                                MessageBox.Show("Field " + available_encoders_decoders[comboBox_protocols.SelectedIndex].fields[field_counter].name +
                                                " with value " + value +
                                                " is outside range.", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Field " + available_commands[comboBox_command.SelectedIndex].fields[field_counter].name +
                                            " has invalid values.", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        command += available_encoders_decoders[comboBox_protocols.SelectedIndex].fields[field_counter].name + value + " ";
                    }
                }
                field_counter++;
            }

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = available_encoders_decoders[comboBox_protocols.SelectedIndex].path,
                    Arguments = command,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();

            proc.WaitForExit();

            string line = proc.StandardOutput.ReadLine();

            if (line != "" && line != null)
            {
                while (line[0] == ' ')
                {
                    line = line.Substring(1);
                }

                line = line.Replace(' ', ',');
                List<string> elements = line.Split(',').ToList();


                if (int.TryParse(textBox_protocol_11.Text, out int data))
                {
                    if ((data > MAX_TIMEOUT) ||
                    (data < MIN_TIMEOUT))
                    {
                        MessageBox.Show("Field " + label_protocol_11.Text +
                                        " with value " + textBox_protocol_11.Text +
                                        " is outside range.", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Field " + label_protocol_12.Text +
                                    " has invalid values.", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (int.TryParse(textBox_protocol_12.Text, out data))
                {
                    if ((data > MAX_CARRIER_FREQUENCY) ||
                    (data < MIN_CARRIER_FREQUENCY))
                    {
                        MessageBox.Show("Field " + label_protocol_12.Text +
                                        " with value " + textBox_protocol_12.Text +
                                        " is outside range.", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Field " + label_protocol_12.Text +
                                    " has invalid values.", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                serial_send(CMD_AT_ENCODE + textBox_protocol_12.Text + "," + textBox_protocol_11.Text + "," + elements.Count.ToString() + "," + line + "\r\n");
            }



        }

        private void button_protocol_decode_Click(object sender, EventArgs e)
        {
            comboBox_protocols.SelectedIndex = -1;
            button_protocol_encode.Enabled = false;
            button_protocol_decode.Enabled = false;

            label_protocol_10.Visible = true;
            richTextBox_protocol_10.Visible = true;

            textBox_protocol_11.Enabled = false;
            textBox_protocol_12.Enabled = false;

            current_connection_state = 3;
            timer_decoder.Enabled = true;
            decoders_decode_stage = 0;
            /* Send command to setup a raw receive. */

            if (int.TryParse(textBox_protocol_11.Text, out int data))
            {
                if ((data > MAX_TIMEOUT) ||
                (data < MIN_TIMEOUT))
                {
                    MessageBox.Show("Field " + label_protocol_11.Text +
                                    " with value " + textBox_protocol_11.Text +
                                    " is outside range.", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
            else
            {
                MessageBox.Show("Field " + label_protocol_12.Text +
                                " has invalid values.", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.TryParse(textBox_protocol_12.Text, out data))
            {
                if ((data > MAX_CARRIER_FREQUENCY) ||
                (data < MIN_CARRIER_FREQUENCY))
                {
                    MessageBox.Show("Field " + label_protocol_12.Text +
                                    " with value " + textBox_protocol_12.Text +
                                    " is outside range.", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
            else
            {
                MessageBox.Show("Field " + label_protocol_12.Text +
                                " has invalid values.", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            serial_send(CMD_AT_DECODE + textBox_protocol_12.Text + "," + textBox_protocol_11.Text + "\r\n");
        }


        private void decode_raw_data(string data)
        {
            /* data shall arrive ready for injection. */
            int protocol_index = 0;

            while (protocol_index < available_encoders_decoders.Count)
            {
                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = available_encoders_decoders[protocol_index].path,
                        Arguments = "decode " + data,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };

                proc.Start();

                proc.WaitForExit();

                string line = proc.StandardOutput.ReadLine();

                if (line != "")
                {
                    string temp = available_encoders_decoders[protocol_index].name + ": " + line + "\r\n";
                    richTextBox_protocol_10.AppendText(temp);
                    richTextBox_protocol_10.ScrollToCaret();

                    protocol_index = available_encoders_decoders.Count;
                }
                else
                {
                    protocol_index++;
                }

            }



        }


        private void timer_decoder_Tick(object sender, EventArgs e)
        {
            /* get from richTextBox_printout and inject to the decoders. */

            try
            {
                if (tabControl_work.SelectedTab != tabControl_work.TabPages[1])
                {
                    current_connection_state = 2;
                    timer_decoder.Enabled = false;
                    button_protocol_encode.Enabled = true;
                    button_protocol_decode.Enabled = true;

                    label_protocol_10.Visible = false;
                    richTextBox_protocol_10.Visible = false;

                    textBox_protocol_11.Enabled = true;
                    textBox_protocol_12.Enabled = true;
                }
                else
                {
                    switch (decoders_decode_stage)
                    {
                        case 0:
                            {
                                string search_text = "\r\nT:";
                                if (decoders_received_raw_data.Length >= search_text.Length)
                                {
                                    int counter = 0;
                                    while (counter <= (decoders_received_raw_data.Length - search_text.Length))
                                    {
                                        if (search_text == decoders_received_raw_data.Substring(counter, search_text.Length))
                                        {
                                            /* Remove rest of the data. */
                                            decoders_received_raw_data = decoders_received_raw_data.Substring(counter + search_text.Length);
                                            decoders_decode_stage = 1;
                                            break;
                                        }
                                        counter++;
                                    }
                                }
                            }
                            break;

                        case 1:
                            {
                                string search_text = "\r\n";
                                if (decoders_received_raw_data.Length >= (search_text.Length))
                                {
                                    int counter = 0;
                                    while (counter <= (decoders_received_raw_data.Length - search_text.Length))
                                    {
                                        if (search_text == decoders_received_raw_data.Substring(counter, search_text.Length))
                                        {
                                            /* Remove rest of the data. */
                                            //decoders_received_raw_data = decoders_received_raw_data.Substring(counter);
                                            string data_to_decode = decoders_received_raw_data.Substring(0, counter);

                                            /* Treat data to fin the decoders. */
                                            data_to_decode = data_to_decode.Replace(',', ' ');



                                            decode_raw_data(data_to_decode);

                                            decoders_received_raw_data = decoders_received_raw_data.Substring(counter);
                                            decoders_decode_stage = 0;

                                            break;
                                        }
                                        counter++;
                                    }
                                }
                            }
                            break;
                    }
                }
            }
            catch (Exception except)
            {

            }

        }

        private void label5_MouseHover(object sender, EventArgs e)
        {

        }

        private void licenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gNULicenseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "notepad",
                    Arguments = "\"GNU License.txt\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            try
            {
                proc.Start();
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void readmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "notepad",
                    Arguments = "\"README.txt\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            try
            {
                proc.Start();
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }


        }

        private void githubProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string target = "https://github.com/RagingBits/IR-Tool";


            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void iRToolDatasheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string target = "https://github.com/RagingBits/IR-Tool/blob/main/Datasheet_IR_Tool_V1.pdf";


            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void button_filesend_open_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();


        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string file = openFileDialog1.FileName;

            if (File.Exists(file))
            {
                textBox_filesend_file_to_send.Text = file;

                button_sendfile_send.Enabled = true;
            }
        }

        private void textBox_filesend_file_to_send_TextChanged(object sender, EventArgs e)
        {

        }


        private void button_sendfile_send_Click(object sender, EventArgs e)
        {

            if (current_connection_state == 2)
            {
                string file = textBox_filesend_file_to_send.Text;
                if (File.Exists(file))
                {
                    button_sendfile_send.Text = "Stop";
                    current_connection_state = 3;
                    timer_filesend.Enabled = true;

                    file_send_items = File.ReadAllLines(file).ToList();

                    file_send_items_counter = 0;

                    serial_send(file_send_items[file_send_items_counter++] + "\r\n");
                }
            }
            else 
            {
                button_sendfile_send.Text = "Send";
                //textBox_filesend_file_to_send.Text = "";
                //button_sendfile_send.Enabled = false;
                current_connection_state = 2;
                timer_filesend.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (tabControl_work.SelectedTab != tabControl_work.TabPages[2])
                {
                    button_sendfile_send.Text = "Send";
                    //textBox_filesend_file_to_send.Text = "";
                    //button_sendfile_send.Enabled = false;
                    current_connection_state = 1;
                    timer_filesend.Enabled = false;
                }
                else
                {
                    switch (decoders_decode_stage)
                    {
                        case 0:
                            {
                                string search_text = "\r\nOK\r\n";
                                if (decoders_received_raw_data.Length >= search_text.Length)
                                {
                                    int counter = 0;
                                    while (counter <= (decoders_received_raw_data.Length - search_text.Length))
                                    {
                                        if (search_text == decoders_received_raw_data.Substring(counter, search_text.Length))
                                        {
                                            /* Remove rest of the data. */
                                            decoders_received_raw_data = "";

                                            if (file_send_items_counter < file_send_items.Count)
                                            {
                                                serial_send(file_send_items[file_send_items_counter++] + "\r\n");
                                            }
                                            else
                                            {
                                                button_sendfile_send.Text = "Send";
                                                //textBox_filesend_file_to_send.Text = "";
                                                //button_sendfile_send.Enabled = false;
                                                current_connection_state = 2;
                                                timer_filesend.Enabled = false;
                                            }


                                            break;
                                        }
                                        counter++;
                                    }
                                }
                            }
                            break;

                    }
                }
            }
            catch (Exception except)
            {

            }
        }
    }
}
