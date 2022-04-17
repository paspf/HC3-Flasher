using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HC3_Flasher
{
    public partial class Form1 : Form
    {
        XmlConfigHandler xmlConfig = new XmlConfigHandler();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxParity.Items.AddRange(Enum.GetNames(typeof(Parity)));
            comboBoxStopBits.Items.Add("0");
            comboBoxStopBits.Items.Add("1");
            comboBoxStopBits.Items.Add("1.5");
            comboBoxStopBits.Items.Add("2");

            refreshComboBoxProfileSelect();
            ShowAvailableComPorts();

            if (xmlConfig.DefaultProfileName != "" && xmlConfig.Profiles.Exists(xmlConfig.DefaultProfileName))
            {
                comboBoxProfileSelect.Text = xmlConfig.Profiles.Get[xmlConfig.Profiles.GetIndex(xmlConfig.DefaultProfileName)].Name;
                ChangeLoadedProfile(xmlConfig.Profiles.GetIndex(xmlConfig.DefaultProfileName));
            }
            else 
            {
                // default values
                textBoxFile.Text = "C:\\program.hc";
                comboBoxParity.SelectedIndex = 0;
                textBoxBaudRate.Text = "9600";
                textBoxDataBits.Text = "8";
                comboBoxStopBits.SelectedIndex = 1;
            }
        }

        /// <summary>
        /// refresh the profiles shown in the profile selector comboBox
        /// </summary>
        private void refreshComboBoxProfileSelect()
        {
            comboBoxProfileSelect.Items.Clear();
            foreach (Profile p in xmlConfig.Profiles.Get)
            {
                comboBoxProfileSelect.Items.Add(p.Name);
            }
            comboBoxProfileSelect.SelectedIndex = comboBoxProfileSelect.Items.Count - 1;
        }

        /// <summary>
        /// Add available com ports to ui
        /// </summary>
        private void ShowAvailableComPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            comboBoxComPort.Items.AddRange(ports);
        }

        private void FlashButton_Click(object sender, EventArgs e)
        {
            Profile profile = checkProfileValidity();
            if(profile == null)
            {
                return;
            }

            string[] ports = SerialPort.GetPortNames();
            bool portFound = false;
            for(int i = 0; i < ports.Length; i++)
            {
                if(ports[i] == comboBoxComPort.Text)
                {
                    portFound = true;
                    break;
                }
            }
            if (!portFound)
            {
                MessageBox.Show("Port not found!", "Error");
                return;
            }
            if (!File.Exists(textBoxFile.Text))
            {
                MessageBox.Show("File not Found!", "Error");
                return;
            }

            byte[] rawFile = File.ReadAllBytes(textBoxFile.Text);

            SerialPort sp = new SerialPort();
            sp.PortName = comboBoxComPort.Text;
            sp.BaudRate = profile.BaudRate;
            sp.Parity = profile.Parity;
            sp.DataBits = profile.DataBits;
            sp.StopBits = profile.StopBits;
            try
            {
                sp.Open();
            }
            catch (UnauthorizedAccessException) {
                MessageBox.Show("Unable to acces COM Port: " + comboBoxComPort.Text, "HC3 Info");
                return;
            }
            
            sp.Write(rawFile, 0, rawFile.Length);
            sp.Close();
            sp.Dispose();
            sp = null;
            MessageBox.Show("Data has been sent", "HC3 Info");
        }

        private void comboBoxProfileSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeLoadedProfile(comboBoxProfileSelect.SelectedIndex);
        }

        /// <summary>
        /// Change the profile
        /// </summary>
        /// <param name="index">index of the new profile</param>
        private void ChangeLoadedProfile(int index)
        {
            Profile currentProfile = xmlConfig.Profiles.Get[index];

            textBoxBaudRate.Text = currentProfile.BaudRate.ToString();
            comboBoxParity.SelectedIndex = (int)currentProfile.Parity;
            textBoxDataBits.Text = currentProfile.DataBits.ToString();
            comboBoxStopBits.Text = xmlConfig.Profiles.StopBitsEnumToString(currentProfile.StopBits);
            comboBoxComPort.Text = currentProfile.DefaultPort;
            textBoxFile.Text = currentProfile.DefaultPath;
        }

        private void storeProfileButton_Click(object sender, EventArgs e)
        {
            // no profile name in text box
            if (comboBoxProfileSelect.Text == "")
            {
                MessageBox.Show("Please enter a profile name", "HC3 Info");
            }
            // profile already exists
            else if (xmlConfig.Profiles.Exists(comboBoxProfileSelect.Text))
            {
                DialogResult dialogResult = MessageBox.Show("Profile already exists!\nDo you want to update the stored profile?", "HC3 Info", MessageBoxButtons.YesNo);
                // overwrite profile
                if (dialogResult == DialogResult.Yes)
                {
                    Profile newProfile = checkProfileValidity();
                    if (newProfile != null)
                    {
                        xmlConfig.Profiles.Remove(comboBoxProfileSelect.SelectedIndex);
                        xmlConfig.Profiles.Add(newProfile);
                        refreshComboBoxProfileSelect();
                    }
                }
                // do nothing
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            // create new profile
            else
            {
                Profile newProfile = checkProfileValidity();
                if(newProfile != null)
                {
                    xmlConfig.Profiles.Add(newProfile);
                    refreshComboBoxProfileSelect();
                }
            }
        }
        private void dropProfileButton_Click(object sender, EventArgs e)
        {
            xmlConfig.Profiles.Remove(comboBoxProfileSelect.SelectedIndex);
            refreshComboBoxProfileSelect();
        }

        /// <summary>
        /// Check if the entered values have the correct format and return a profile object with the values
        /// </summary>
        /// <returns>profile with current values</returns>
        private Profile checkProfileValidity()
        {
            int baudRate;
            int dataBits;
            if (!Int32.TryParse(textBoxBaudRate.Text, out baudRate))
            {
                MessageBox.Show("Error with BaudRate", "Error");
                return null;
            }
            else if (!Int32.TryParse(textBoxDataBits.Text, out dataBits))
            {
                MessageBox.Show("Error with DataBits", "Error");
                return null;
            }

            return new Profile(comboBoxProfileSelect.Text, 
                baudRate, 
                xmlConfig.Profiles.ParityStringToEnum(comboBoxParity.Text), 
                dataBits, 
                xmlConfig.Profiles.StopBitsStringToEnum(comboBoxStopBits.Text), 
                textBoxFile.Text, 
                comboBoxComPort.Text);
        }

        private void buttonSetAsDefault_Click(object sender, EventArgs e)
        {
            xmlConfig.DefaultProfileName = comboBoxProfileSelect.Text;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            xmlConfig.Store();
        }

        private void buttonRefreshCom_Click(object sender, EventArgs e)
        {
            comboBoxComPort.Items.Clear();
            ShowAvailableComPorts();
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Open file browser at location "My Computer"
                openFileDialog.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of specified file
                    textBoxFile.Text = openFileDialog.FileName;
                }
            }
        }
    }
}
