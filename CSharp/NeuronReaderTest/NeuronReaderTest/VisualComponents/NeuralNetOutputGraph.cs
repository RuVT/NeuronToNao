using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NeuronReaderConsole.BodyParts;

namespace NeuronReaderTest.VisualComponents
{
    public partial class NeuralNetOutputGraph : UserControl
    {
        public NeuralNetOutputGraph()
        {
            InitializeComponent();
        }

        public void LinkToOutputData(BodyPart part)
        {
            part.OutputChanged += OutputChanged;
        }

        private delegate void UpdateChart(object sender, EventArgs e);

        private void OutputChanged(object sender, EventArgs e)
        {
            if (chart_output.InvokeRequired)
            {
                UpdateChart d = new UpdateChart(OutputChanged);
                chart_output.Invoke(d, new object[] { sender, e });
            }
            else
            {
                BodyPart part = (BodyPart)sender;
                chart_output.Series.Clear();
                Series outputSerie = new Series();
                outputSerie.ChartType = SeriesChartType.Bar;
                for (int n = 0; n < part.OutputActions.Length; n++)
                {
                    try
                    {
                        outputSerie.Points.AddXY(part.OutputActions[n], part.RealOutput[n]);
                    }
                    catch (Exception) { }
                }
                chart_output.Series.Add(outputSerie);
            }
        }
    }
}
