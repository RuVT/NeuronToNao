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
    public partial class NeuralNetTrainer : UserControl
    {
        private IDisposable dis;

        public NeuralNetTrainer()
        {
            InitializeComponent();
            bool designMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
            if (!designMode)
            {
                Body.ActualBodyChange += BodyChange; 
            }
        }

        private void Training_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Trining complete");
        }

        private void NeuralNetTrainer_Load(object sender, EventArgs e)
        {
            
        }

        private void Training_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        delegate void ChangeCounter(int n);

        void SetCounter(int n)
        {
            if (label_dataSetLength.InvokeRequired)
            {
                ChangeCounter d = new ChangeCounter(SetCounter);
                label_dataSetLength.Invoke(d, new object[] { n });
            }
            else
            {
                label_dataSetLength.Text = string.Format("DataSet Length: {0}", n);
            }
        }

        private void btn_start_training_Click(object sender, EventArgs e)
        {
            BodyPart part = Body.ActualBody.Parts[comboBox_bodyParts.SelectedIndex];
            part.State = NetworkSate.TRAINING;
            this.Enabled = false;
        }

        private void BodyChange(object sender, EventArgs e)
        {
            Body actual = (Body)sender;
            comboBox_bodyParts.Items.Clear();
            checkedListBox_states.Items.Clear();
            foreach(BodyPart part in actual.Parts)
            {
                comboBox_bodyParts.Items.Add(part.Name);
            }
        }

        private void comboBox_bodyParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (BodyPart p in Body.ActualBody.Parts)
            {
                p.StateChanged -= StateChanged;
                p.TrainingEnded -= TrainingEnded;
                p.Subcription?.Dispose();
            }
            BodyPart part = Body.ActualBody.Parts[comboBox_bodyParts.SelectedIndex];
            part.Subcription = NeuronReceiver.Instance.Subscribe(part);
            numericUpDown_sampleLength.Value = Convert.ToDecimal(part.SampleLength);
            part.StateChanged += StateChanged;
            part.TrainingEnded += TrainingEnded;
            checkedListBox_states.Items.Clear();
            string[] actions = part.OutputActions;
            checkedListBox_states.Items.AddRange(actions);
        }

        private void TrainingEnded(object sender, EventArgs e)
        {
            BodyPart part = (BodyPart)sender;
            SetEnable(true);
            MessageBox.Show("Training end");
        }

        delegate void ChangeEnable(bool enable);

        private void SetEnable(bool enable)
        {
            if(this.InvokeRequired)
            {
                ChangeEnable d = new ChangeEnable(SetEnable);
                this.Invoke(d, new object[] { enable });
            }
            else
            {
                this.Enabled = true;
            }
        }

        private void StateChanged(object sender, EventArgs e)
        {
            BodyPart part = (BodyPart)sender;
            SetCounter(part.DataSets.Count);
        }

        private void btn_record_Click(object sender, EventArgs e)
        {
            BodyPart part = Body.ActualBody.Parts[comboBox_bodyParts.SelectedIndex];
            double[] outputArray = new double[part.OutputActions.Length];
            for(int n=0; n < part.OutputActions.Length; n++)
            {
                outputArray[n] = checkedListBox_states.GetSelected(n) ? 1 : 0;
            }
            part.outputArray = outputArray;
            part.State = NetworkSate.RECORDING;
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numericUpDown_sampleLength_ValueChanged(object sender, EventArgs e)
        {
            BodyPart part = Body.ActualBody.Parts[comboBox_bodyParts.SelectedIndex];
            part.SampleLength = Convert.ToInt32(numericUpDown_sampleLength.Value);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            BodyPart part = Body.ActualBody.Parts[comboBox_bodyParts.SelectedIndex];
            part.DataSets.Clear();
        }
    }
}
