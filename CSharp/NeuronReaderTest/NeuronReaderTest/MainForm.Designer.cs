namespace NeuronReaderTest
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.neuralNetLoader1 = new NeuronReaderTest.VisualComponents.NeuralNetLoader();
            this.axisConnector1 = new NeuronReaderTest.VisualComponents.AxisConnector();
            this.neuralNetTrainer1 = new NeuronReaderTest.VisualComponents.NeuralNetTrainer();
            this.neuralNetComputeViewer1 = new NeuronReaderTest.VisualComponents.NeuralNetComputeViewer();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(663, 431);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.neuralNetLoader1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(655, 405);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Load Neural Network";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.axisConnector1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(655, 405);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Connect Axis Neuron";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.neuralNetTrainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(655, 405);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Training";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.neuralNetComputeViewer1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(655, 405);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Real time";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // neuralNetLoader1
            // 
            this.neuralNetLoader1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuralNetLoader1.Location = new System.Drawing.Point(3, 3);
            this.neuralNetLoader1.Name = "neuralNetLoader1";
            this.neuralNetLoader1.Size = new System.Drawing.Size(649, 399);
            this.neuralNetLoader1.TabIndex = 0;
            // 
            // axisConnector1
            // 
            this.axisConnector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisConnector1.Location = new System.Drawing.Point(3, 3);
            this.axisConnector1.Name = "axisConnector1";
            this.axisConnector1.Size = new System.Drawing.Size(649, 399);
            this.axisConnector1.TabIndex = 0;
            // 
            // neuralNetTrainer1
            // 
            this.neuralNetTrainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuralNetTrainer1.Location = new System.Drawing.Point(3, 3);
            this.neuralNetTrainer1.Name = "neuralNetTrainer1";
            this.neuralNetTrainer1.Size = new System.Drawing.Size(649, 399);
            this.neuralNetTrainer1.TabIndex = 0;
            // 
            // neuralNetComputeViewer1
            // 
            this.neuralNetComputeViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuralNetComputeViewer1.Location = new System.Drawing.Point(3, 3);
            this.neuralNetComputeViewer1.Name = "neuralNetComputeViewer1";
            this.neuralNetComputeViewer1.Size = new System.Drawing.Size(649, 399);
            this.neuralNetComputeViewer1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 431);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Training Neron-Nao Interface";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage4;
        private VisualComponents.NeuralNetLoader neuralNetLoader1;
        private VisualComponents.NeuralNetTrainer neuralNetTrainer1;
        private System.Windows.Forms.TabPage tabPage5;
        private VisualComponents.AxisConnector axisConnector1;
        private VisualComponents.NeuralNetComputeViewer neuralNetComputeViewer1;
    }
}

