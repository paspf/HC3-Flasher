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


/*
 * HC3 Flasher
 * 2019 01 18
 * - First version to transmit compiled an linked binary file to HC3
 * 2019 01 23
 * - fixed: the broken com port selection
 * 2019 03 03
 * - added: manual adustment of serial parameters
 * - added: profile selector
 * - added: store profiles
 * 2019 10 03
 * - fixed: exceptions handeled
 * - added: option to edit profiles
 */
namespace HC3_Flasher
{
    public partial class Form1 : Form
    {
        ProfileHandler loadProfiles;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxCom.Text = "COM1";
            textBoxFile.Text = "C:\\program.hc";
            comboBoxParity.Items.Add("None");
            comboBoxParity.Items.Add("Odd");
            comboBoxParity.Items.Add("Even");
            comboBoxParity.SelectedIndex = 0;
            textBoxBaudRate.Text = "9600";
            textBoxDataBits.Text = "8";
            comboBoxStopBits.Items.Add("0");
            comboBoxStopBits.Items.Add("1");
            comboBoxStopBits.Items.Add("1.5");
            comboBoxStopBits.Items.Add("2");
            comboBoxStopBits.SelectedIndex = 1;

            loadProfiles = new ProfileHandler();
            if (loadProfiles.loadProfiles() == 1)
            {
                MessageBox.Show("Error in handeling HC3 Flasher Profiles.cfg!", "Error");
            }
            refreshComboBoxProfileSelect();
        }

        /*
         * refreshComboBoxProfileSelect
         * refresh the profiles shown in the
         * profile selector comboBox
         */
        private void refreshComboBoxProfileSelect()
        {
            comboBoxProfileSelect.Items.Clear();
            for (int i = 0; i < loadProfiles.Profiles.Count; i++)
            {
                comboBoxProfileSelect.Items.Add(loadProfiles.Profiles.ElementAt(i).Name);
            }
        }

        private void FlashButton_Click(object sender, EventArgs e)
        {
            Profile profile = checkConsistance();
            if(profile == null)
            {
                return;
            }

            string[] ports = SerialPort.GetPortNames();
            bool portFound = false;
            for(int i = 0; i < ports.Length; i++)
            {
                if(ports[i] == textBoxCom.Text)
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

            byte[] rawFile = File.ReadAllBytes(textBoxFile.Text);

            Parity parity;
            switch(profile.Parity)
            {
                case 1:
                    parity = Parity.Odd;
                    break;
                case 2:
                    parity = Parity.Even;
                    break;
                default:
                    parity = Parity.None;
                    break;
            }

            StopBits stopBit;
            switch(profile.StopBits)
            {
                case 1:
                    stopBit = StopBits.One;
                    break;
                case 2:
                    stopBit = StopBits.Two;
                    break;
                case 3:
                    stopBit = StopBits.OnePointFive;
                    break;
                default:
                    stopBit = StopBits.None;
                    break;
            }

            SerialPort sp = new SerialPort();
            sp.PortName = textBoxCom.Text;
            sp.BaudRate = profile.BaudRate;
            sp.Parity = parity;
            sp.DataBits = profile.DataBits;
            sp.StopBits = stopBit;
            try
            {
                sp.Open();
            }
            catch (UnauthorizedAccessException) {
                MessageBox.Show("Unable to acces COM Port: " + textBoxCom.Text, "HC3 Info");
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
            textBoxBaudRate.Text = loadProfiles.Profiles.ElementAt(comboBoxProfileSelect.SelectedIndex).BaudRate.ToString();
            comboBoxParity.SelectedIndex = loadProfiles.Profiles.ElementAt(comboBoxProfileSelect.SelectedIndex).Parity;
            textBoxDataBits.Text = loadProfiles.Profiles.ElementAt(comboBoxProfileSelect.SelectedIndex).DataBits.ToString();
            comboBoxStopBits.SelectedIndex = loadProfiles.Profiles.ElementAt(comboBoxProfileSelect.SelectedIndex).StopBits;
            textBoxCom.Text = loadProfiles.Profiles.ElementAt(comboBoxProfileSelect.SelectedIndex).DefaultPort;
            textBoxFile.Text = loadProfiles.Profiles.ElementAt(comboBoxProfileSelect.SelectedIndex).DefaultPath;
        }

        private void storeProfileButton_Click(object sender, EventArgs e)
        {
            // no profile name in text box
            if (comboBoxProfileSelect.Text == "")
            {
                MessageBox.Show("Please enter a profile name", "HC3 Info");
            }
            // profile already exists
            else if (loadProfiles.profileExists(comboBoxProfileSelect.Text))
            {
                DialogResult dialogResult = MessageBox.Show("Profile already exists!\nDo you want the replace the stored profile?", "HC3 Info", MessageBoxButtons.YesNo);
                // overwrite profile
                if (dialogResult == DialogResult.Yes)
                {
                    Profile newProfile = checkConsistance();
                    if (newProfile != null)
                    {
                        loadProfiles.dropProfile(loadProfiles.getProfileIndex(comboBoxProfileSelect.Text));
                        loadProfiles.storeProfile(newProfile);
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
                Profile newProfile = checkConsistance();
                if(newProfile != null)
                {
                    loadProfiles.storeProfile(newProfile);
                    refreshComboBoxProfileSelect();
                }
            }
        }
        private void dropProfileButton_Click(object sender, EventArgs e)
        {
            loadProfiles.dropProfile(comboBoxProfileSelect.SelectedIndex);
            refreshComboBoxProfileSelect();
        }

        /*
         * checkConsistance
         * This function checks if the
         * values entered in the fields
         * are in the accepted ranges
         */
        private Profile checkConsistance()
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
            return new Profile(comboBoxProfileSelect.Text, baudRate, comboBoxParity.SelectedIndex, dataBits, comboBoxStopBits.SelectedIndex, textBoxFile.Text, textBoxCom.Text);
        }
    }
}
