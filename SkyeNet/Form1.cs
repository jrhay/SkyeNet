using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SkyeNet;

namespace SkyeNetDemo
{
    public partial class Form1 : Form
    {
        SkyeNet.SkyeNet _SkyeTek;

        public Form1()
        {
            InitializeComponent();
            InitializeSkyeNet();
        }

        private void InitializeSkyeNet()
        {
            _SkyeTek = new SkyeNet.SkyeNet();
            ResetDevices();
        }

        #region GUI Event Handling

        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            InitializeSkyeNet();
        }

        private void chkAllDevices_CheckedChanged(object sender, EventArgs e)
        {
            cmbDevices.Enabled = !chkAllDevices.Checked;
            if (chkAllDevices.Checked)
                SetAllowReaders(true);
            else
                SetAllowReaders(cmbDevices.SelectedIndex >= 0);
        }

        private void btnFindDevices_Click(object sender, EventArgs e)
        {
            PopulateDevices();
        }

        private void btnFindReaders_Click(object sender, EventArgs e)
        {
            if (chkAllDevices.Checked)
                PopulateReaders();
            else
                PopulateReaders(cmbDevices.SelectedItem as Device);
        }

        private void btnGetTags_Click(object sender, EventArgs e)
        {
            PopulateTags();
        }

        private void cmbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDevices.SelectedIndex >= 0)
                AddDeviceToLog("Selected SkyeTek Device:", cmbDevices.SelectedItem as Device);
            SetAllowReaders(cmbDevices.SelectedIndex >= 0);
        }

        private void cmbReaders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbReaders.SelectedIndex >= 0)
            {
                _SkyeTek.ActiveReader = cmbReaders.SelectedItem as Reader;
                AddReaderToLog("Selected RFID Reader: ", _SkyeTek.ActiveReader);
            }
            SetAllowTags(cmbReaders.SelectedIndex >= 0);
        }
        private void cmbTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTags.SelectedIndex >= 0)
                AddTagToLog("Selected RFID Tag: ", cmbTags.SelectedItem as Tag);
        }

        #endregion

        #region Devices

        private void SetHaveDevices(bool doHaveDevices)
        {
            grpReaders.Enabled = doHaveDevices;
            cmbDevices.Enabled = doHaveDevices;
            chkAllDevices.Enabled = doHaveDevices;
        }

        private void ResetDevices()
        {
            ResetReaders();
            lblNumDevices.Text = "0";
            chkAllDevices.Checked = false;
            cmbDevices.Items.Clear();
            cmbDevices.SelectedIndex = -1;
            SetHaveDevices(false);
        }

        private void PopulateDevices()
        {
            using (new WaitCursor())
            {
                ResetDevices();
                foreach (Device device in _SkyeTek.GetDevices())
                    cmbDevices.Items.Add(device);

                lblNumDevices.Text = _SkyeTek.NumDevices.ToString();
                SetHaveDevices(_SkyeTek.NumDevices > 0);
            }
        }

        #endregion

        #region Readers

        private void SetAllowReaders(bool doAllowReaders)
        {
            btnFindReaders.Enabled = doAllowReaders;
        }

        private void SetHaveReaders(bool doHaveReaders)
        {
            cmbReaders.Enabled = doHaveReaders;
        }

        private void ResetReaders()
        {
            lblNumReaders.Text = "0";
            cmbReaders.Items.Clear();
            cmbReaders.SelectedIndex = -1;
            SetHaveReaders(false);
            SetAllowReaders(false);
            ResetTags();
        }

        private void PopulateReaders(Device device = null)
        {
            using (new WaitCursor())
            {
                ResetReaders();
                foreach (Reader reader in _SkyeTek.GetReaders(device))
                    cmbReaders.Items.Add(reader);
            }

            lblNumReaders.Text = _SkyeTek.NumReaders.ToString();
            SetHaveReaders(_SkyeTek.NumReaders > 0);
        }

        #endregion

        #region Tags

        private void SetAllowTags(Boolean doAllowTags)
        {
            btnGetTags.Enabled = doAllowTags;
        }

        private void SetHaveTags(bool doHaveTags)
        {
            cmbTags.Enabled = doHaveTags;
        }

        private void ResetTags()
        {
            lblNumTags.Text = "0";
            cmbTags.Items.Clear();
            cmbTags.SelectedIndex = -1;
            SetHaveTags(false);
            SetAllowTags(false);
        }

        private void PopulateTags()
        {
            using (new WaitCursor())
            {
                ResetTags();
                foreach (Tag tag in _SkyeTek.GetTags())
                    cmbTags.Items.Add(tag);
            }

            lblNumTags.Text = _SkyeTek.NumTags.ToString();
            SetHaveTags(_SkyeTek.NumTags > 0);
            SetAllowTags(true);
        }

        #endregion

        #region Log Handling

        private void AddLog(String Message)
        {
            txtLog.AppendText(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ": " + Message + "\r\n");
        }

        private void AddSubLog(String Message, int indents = 1)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < indents; i++)
                sb.Append("\t");
            sb.Append(Message);
            sb.Append("\r\n");
            txtLog.AppendText(sb.ToString());
        }

        private void AddDeviceToLog(String Message, Device device)
        {
            AddLog(Message);
            AddSubLog("Device Name: " + device.friendly);
            AddSubLog("Type: " + device.type);
            AddSubLog("Address: " + device.address);
            AddSubLog("");
        }

        private void AddReaderToLog(String Message, Reader reader)
        {
            AddLog(Message);
            AddSubLog("Reader Name: " + reader.readerName);
            AddSubLog("Manufacturer: " + reader.manufacturer);
            AddSubLog("Model: " + reader.model);
            AddSubLog("Serial Number: " + reader.serialNumber);
            AddSubLog("Firmware: " + reader.firmware);
            AddSubLog("Friendly: " + reader.friendly);
            AddSubLog("");
        }

        private void AddTagToLog(String Message, Tag tag)
        {
            AddLog(Message);
            AddSubLog("Tag Type: " + tag.type.ToString());
            AddSubLog("AFI: " + tag.afi);
            AddSubLog("Session: " + tag.session);
            AddSubLog("Friendly: " + tag.friendly);
        }

        #endregion

    }
}
