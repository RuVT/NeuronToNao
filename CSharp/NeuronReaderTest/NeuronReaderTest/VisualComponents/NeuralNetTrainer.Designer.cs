namespace NeuronReaderTest.VisualComponents
{
    partial class NeuralNetTrainer
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_bodyParts = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.checkedListBox_states = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numericUpDown_sampleLength = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_record = new System.Windows.Forms.Button();
            this.btn_start_training = new System.Windows.Forms.Button();
            this.label_dataSetLength = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_sampleLength)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.36416F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.63584F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 174F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_dataSetLength, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.08127F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.91873F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(499, 389);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBox_bodyParts);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 63);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select a Body Part";
            // 
            // comboBox_bodyParts
            // 
            this.comboBox_bodyParts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.comboBox_bodyParts.FormattingEnabled = true;
            this.comboBox_bodyParts.Location = new System.Drawing.Point(0, 42);
            this.comboBox_bodyParts.Name = "comboBox_bodyParts";
            this.comboBox_bodyParts.Size = new System.Drawing.Size(219, 21);
            this.comboBox_bodyParts.TabIndex = 4;
            this.comboBox_bodyParts.SelectedIndexChanged += new System.EventHandler(this.comboBox_bodyParts_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.checkedListBox_states, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 72);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.3139F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.6861F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(219, 289);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // checkedListBox_states
            // 
            this.checkedListBox_states.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox_states.FormattingEnabled = true;
            this.checkedListBox_states.Location = new System.Drawing.Point(3, 32);
            this.checkedListBox_states.Name = "checkedListBox_states";
            this.checkedListBox_states.Size = new System.Drawing.Size(213, 254);
            this.checkedListBox_states.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a State to train";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.numericUpDown_sampleLength);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(228, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(93, 63);
            this.panel2.TabIndex = 8;
            // 
            // numericUpDown_sampleLength
            // 
            this.numericUpDown_sampleLength.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.numericUpDown_sampleLength.Location = new System.Drawing.Point(0, 43);
            this.numericUpDown_sampleLength.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown_sampleLength.Name = "numericUpDown_sampleLength";
            this.numericUpDown_sampleLength.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_sampleLength.TabIndex = 1;
            this.numericUpDown_sampleLength.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_sampleLength.ValueChanged += new System.EventHandler(this.numericUpDown_sampleLength_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sample length";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnClear);
            this.panel3.Controls.Add(this.btn_record);
            this.panel3.Controls.Add(this.btn_start_training);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(228, 72);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(93, 289);
            this.panel3.TabIndex = 9;
            // 
            // btn_record
            // 
            this.btn_record.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_record.Location = new System.Drawing.Point(3, 3);
            this.btn_record.Name = "btn_record";
            this.btn_record.Size = new System.Drawing.Size(87, 28);
            this.btn_record.TabIndex = 7;
            this.btn_record.Text = "Record";
            this.btn_record.UseVisualStyleBackColor = true;
            this.btn_record.Click += new System.EventHandler(this.btn_record_Click);
            // 
            // btn_start_training
            // 
            this.btn_start_training.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_start_training.Location = new System.Drawing.Point(0, 257);
            this.btn_start_training.Name = "btn_start_training";
            this.btn_start_training.Size = new System.Drawing.Size(93, 29);
            this.btn_start_training.TabIndex = 2;
            this.btn_start_training.Text = "Start Training";
            this.btn_start_training.UseVisualStyleBackColor = true;
            this.btn_start_training.Click += new System.EventHandler(this.btn_start_training_Click);
            // 
            // label_dataSetLength
            // 
            this.label_dataSetLength.AutoSize = true;
            this.label_dataSetLength.Location = new System.Drawing.Point(327, 69);
            this.label_dataSetLength.Name = "label_dataSetLength";
            this.label_dataSetLength.Size = new System.Drawing.Size(94, 13);
            this.label_dataSetLength.TabIndex = 10;
            this.label_dataSetLength.Text = "DataSet Length: 0";
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(327, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(169, 63);
            this.panel4.TabIndex = 11;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(-3, 129);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // NeuralNetTrainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NeuralNetTrainer";
            this.Size = new System.Drawing.Size(499, 389);
            this.Load += new System.EventHandler(this.NeuralNetTrainer_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_sampleLength)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_start_training;
        private System.Windows.Forms.CheckedListBox checkedListBox_states;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_bodyParts;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_record;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numericUpDown_sampleLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label_dataSetLength;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnClear;
    }
}
