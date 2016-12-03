using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using NeuronReaderConsole;
using NeuronReaderConsole.BodyParts;

namespace NeuronReaderTest.VisualComponents
{
    public partial class BodyPartCreator : Form
    {
        DataTable numbers, actions;
        BodyPart actual = null;
        public BodyPartCreator()
        {
            InitializeComponent();
            numbers = new DataTable();
            numbers.Columns.Add("Bone Number", typeof(int));
            dgv_numbers.DataSource = numbers;

            actions = new DataTable();
            actions.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Action Name", typeof(string)),
                new DataColumn("Script response", typeof(string))
            });
            dgv_actions.DataSource = actions;
        }

        public void SetPart(BodyPart p)
        {
            if (p != null)
            {
                actual = p;
                textBox_name.Text = p.Name;
                foreach (var num in p.BoneNumbers)
                    numbers.Rows.Add(num);
                for(int n=0; n < p.OutputActions.Length; n++)
                {
                    actions.Rows.Add(p.OutputActions[n], p.ScriptActions[n]);
                }
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (actual == null)
                Body.ActualBody.Parts.Add(
                    new BodyPart
                    {
                        Name = textBox_name.Text,
                        BoneNumbers = numbers.AsEnumerable().Select(row => row.Field<int>("Bone Number")).ToArray(),
                        OutputActions = actions.AsEnumerable().Select(row => row.Field<string>("Action Name")).ToArray(),
                        ScriptActions = actions.AsEnumerable().Select(row => row.Field<string>("Script response")).ToArray(),
                    });
            else
            {
                actual.Name = textBox_name.Text;
                actual.BoneNumbers = numbers.AsEnumerable().Select(row => row.Field<int>("Bone Number")).ToArray();
                actual.OutputActions = actions.AsEnumerable().Select(row => row.Field<string>("Action Name")).ToArray();
                actual.ScriptActions = actions.AsEnumerable().Select(row => row.Field<string>("Script response")).ToArray();
            }
            Close();           
        }
    }
}
