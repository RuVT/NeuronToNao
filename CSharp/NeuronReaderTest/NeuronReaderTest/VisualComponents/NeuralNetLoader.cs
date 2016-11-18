using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NeuronReaderConsole;
using NeuronReaderConsole.BodyParts;

namespace NeuronReaderTest.VisualComponents
{
    public partial class NeuralNetLoader : UserControl
    {
        BodyPart actualPart;
        public NeuralNetLoader()
        {
            InitializeComponent();
            Body.ActualBodyChange += BodyChange;
        }

        private void BodyChange(object sender, EventArgs e)
        {
            foreach (BodyPart part in Body.ActualBody.Parts)
            {
                ListViewItem item = new ListViewItem(part.Name);
                //listView_parts.Items.Add(item);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    Body.ActualBody.Save(saveFileDialog1.FileName);
                }
                catch (Exception _e)
                {
                    MessageBox.Show(_e.Message);
                }
            }
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            Body.ActualBody = new Body();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    Body.ActualBody = Body.Load(openFileDialog1.FileName);
                    dgv_parts.DataSource = Body.ActualBody.Parts;
                }
                catch (Exception _e)
                {
                    MessageBox.Show(_e.Message);
                }
            }
            
        }

        private void btn_add_part_Click(object sender, EventArgs e)
        {
            BodyPartCreator wind = new BodyPartCreator();
            wind.ShowDialog();
            dgv_parts.DataSource = Body.ActualBody.Parts;
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            BodyPartCreator wind = new BodyPartCreator();
            wind.SetPart(actualPart);
            wind.ShowDialog();
            dgv_parts.Refresh();
        }

        private void dgv_parts_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            actualPart = Body.ActualBody.Parts[e.RowIndex];
        }

        private void btn_remove_part_Click(object sender, EventArgs e)
        {
            if(Body.ActualBody.Parts.Contains(actualPart))
                Body.ActualBody.Parts.Remove(actualPart);
            dgv_parts.Refresh();
        }
    }
}
