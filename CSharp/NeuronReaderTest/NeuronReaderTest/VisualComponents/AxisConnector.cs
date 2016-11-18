using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuronDataReaderWraper;

namespace NeuronReaderTest.VisualComponents
{
    public partial class AxisConnector : UserControl
    {
        public AxisConnector()
        {
            InitializeComponent();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            IntPtr mySocket = IntPtr.Zero;
            try
            {
                mySocket = NeuronDataReader.BRConnectTo(textBox_ip.Text, int.Parse(textBox_port.Text));
                switch (NeuronDataReader.BRGetSocketStatus(mySocket))
                {
                    case SocketStatus.CS_Starting:
                        label_connection.Text = string.Format("Status: {0}", "Starting");
                        break;
                    case SocketStatus.CS_Running:
                        label_connection.Text = string.Format("Status: {0}", "Running");
                        break;
                    case SocketStatus.CS_OffWork:
                        label_connection.Text = string.Format("Status: {0}", "Off");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("Exception when trying to connect to Axis Neuron.\r\n\r\n{0}", ex.Message));
            }
        }
    }
}
