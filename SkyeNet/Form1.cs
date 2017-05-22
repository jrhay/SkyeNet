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
        SkyeNet.SkyeNet _SkyeTek = new SkyeNet.SkyeNet();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnFindDevices_Click(object sender, EventArgs e)
        {
            ClearReaders();
            _SkyeTek.RefreshDevices();
            lblNumDevices.Text = _SkyeTek.NumDevices.ToString();
            grpReaders.Enabled = (_SkyeTek.NumDevices > 0);
        }

        private void btnFindReaders_Click(object sender, EventArgs e)
        {
            _SkyeTek.RefreshReaders();
            lblNumReaders.Text = _SkyeTek.NumReaders.ToString();
        }

        private void ClearReaders()
        {
            lblNumReaders.Text = "0";
            grpReaders.Enabled = false;
        }

        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            _SkyeTek = new SkyeNet.SkyeNet();
        }

        private void btnGetDevice_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _SkyeTek.NumDevices; i++)
            {
                Device device = _SkyeTek.GetDevice(i);
                txtLog.AppendText("SkyeTek Device #" + i + ":\r\n");
                txtLog.AppendText("\tDevice Name: " + device.friendly + "\r\n");
                txtLog.AppendText("\tType: " + device.type + "\r\n");
                txtLog.AppendText("\tAddress: " + device.address + "\r\n");
                txtLog.AppendText("\r\n");
            }
        }

        private void btnGetReader_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _SkyeTek.NumReaders; i++)
            {
                Reader reader = _SkyeTek.GetReader(i);
                txtLog.AppendText("RFID Reader #" + i + ":\r\n");
                txtLog.AppendText("\tReader Name: " + reader.readerName + "\r\n");
                txtLog.AppendText("\tManufacturer: " + reader.manufacturer + "\r\n");
                txtLog.AppendText("\tModel: " + reader.model + "\r\n");
                txtLog.AppendText("\tSerial Number: " + reader.serialNumber + "\r\n");
                txtLog.AppendText("\tFirmware: " + reader.firmware + "\r\n");
                txtLog.AppendText("\tFriendly: " + reader.friendly + "\r\n");
                txtLog.AppendText("\r\n");
            }
        }
    }
}
