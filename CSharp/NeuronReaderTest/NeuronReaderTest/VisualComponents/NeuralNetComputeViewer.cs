using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuronReaderConsole;
using NeuronReaderConsole.BodyParts;

namespace NeuronReaderTest.VisualComponents
{
    public partial class NeuralNetComputeViewer : UserControl
    {
        public NeuralNetComputeViewer()
        {
            InitializeComponent();
            bool designMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
            if (!designMode)
            {
                Body.ActualBodyChange += BodyChange;
            }
        }

        delegate void ChangeListBodyPart(object s, EventArgs e);

        private void BodyChange(object sender, EventArgs e)
        {
            Body body = (Body)sender;
            checkedListBox_parts.Items.Clear();
            foreach(BodyPart part in body.Parts)
            {
                checkedListBox_parts.Items.Add(part.Name, part.Subcription != null);
            } 
        }

        Dictionary<BodyPart, NeuralNetOutputGraph> graphDic = new Dictionary<BodyPart, NeuralNetOutputGraph>();

        private void checkedListBox_parts_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(e.NewValue == CheckState.Checked)
            {
                BodyPart part = Body.ActualBody.Parts[e.Index];
                NeuralNetOutputGraph graph = new NeuralNetOutputGraph();
                graph.LinkToOutputData(part);
                graphDic.Add(part, graph);
                flowLayoutPanel1.Controls.Add(graph);
                part.State = NetworkSate.COMPUTING;
                part.Subcription = NeuronReceiver.Instance.Subscribe(part);
            }
            else if(e.NewValue == CheckState.Unchecked)
            {
                BodyPart part = Body.ActualBody.Parts[e.Index];
                part.Subcription?.Dispose();
                if(graphDic.ContainsKey(part))
                {
                    flowLayoutPanel1.Controls.Remove(graphDic[part]);
                    graphDic.Remove(part);
                    part.State = NetworkSate.NO_ACTION; 
                }
            }
        }
    }
}
