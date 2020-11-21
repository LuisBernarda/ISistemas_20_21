
namespace Projeto_IS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listaFluxos = new System.Windows.Forms.ListBox();
            this.import = new System.Windows.Forms.Button();
            this.export = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.GroupBox();
            this.outHTML = new System.Windows.Forms.Button();
            this.outREST = new System.Windows.Forms.Button();
            this.INPUT = new System.Windows.Forms.GroupBox();
            this.inEXCEL = new System.Windows.Forms.Button();
            this.inXML = new System.Windows.Forms.Button();
            this.inREST = new System.Windows.Forms.Button();
            this.projetoIS = new System.Windows.Forms.Label();
            this.executar = new System.Windows.Forms.Button();
            this.output.SuspendLayout();
            this.INPUT.SuspendLayout();
            this.SuspendLayout();
            // 
            // listaFluxos
            // 
            this.listaFluxos.FormattingEnabled = true;
            this.listaFluxos.ItemHeight = 16;
            this.listaFluxos.Location = new System.Drawing.Point(299, 155);
            this.listaFluxos.Name = "listaFluxos";
            this.listaFluxos.Size = new System.Drawing.Size(550, 276);
            this.listaFluxos.TabIndex = 0;
            // 
            // import
            // 
            this.import.Location = new System.Drawing.Point(299, 449);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(174, 37);
            this.import.TabIndex = 1;
            this.import.Text = "Importar fluxo";
            this.import.UseVisualStyleBackColor = true;
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(675, 449);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(174, 37);
            this.export.TabIndex = 2;
            this.export.Text = "Exportar fluxo";
            this.export.UseVisualStyleBackColor = true;
            // 
            // output
            // 
            this.output.Controls.Add(this.outHTML);
            this.output.Controls.Add(this.outREST);
            this.output.Location = new System.Drawing.Point(920, 155);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(200, 276);
            this.output.TabIndex = 3;
            this.output.TabStop = false;
            this.output.Text = "OUTPUT";
            // 
            // outHTML
            // 
            this.outHTML.Location = new System.Drawing.Point(60, 149);
            this.outHTML.Name = "outHTML";
            this.outHTML.Size = new System.Drawing.Size(75, 63);
            this.outHTML.TabIndex = 1;
            this.outHTML.Text = "HTML";
            this.outHTML.UseVisualStyleBackColor = true;
            this.outHTML.Click += new System.EventHandler(this.outHTML_Click);
            // 
            // outREST
            // 
            this.outREST.Location = new System.Drawing.Point(60, 68);
            this.outREST.Name = "outREST";
            this.outREST.Size = new System.Drawing.Size(75, 63);
            this.outREST.TabIndex = 0;
            this.outREST.Text = "REST";
            this.outREST.UseVisualStyleBackColor = true;
            // 
            // INPUT
            // 
            this.INPUT.Controls.Add(this.inEXCEL);
            this.INPUT.Controls.Add(this.inXML);
            this.INPUT.Controls.Add(this.inREST);
            this.INPUT.Location = new System.Drawing.Point(39, 155);
            this.INPUT.Name = "INPUT";
            this.INPUT.Size = new System.Drawing.Size(200, 276);
            this.INPUT.TabIndex = 4;
            this.INPUT.TabStop = false;
            this.INPUT.Text = "INPUT";
            // 
            // inEXCEL
            // 
            this.inEXCEL.Location = new System.Drawing.Point(49, 177);
            this.inEXCEL.Name = "inEXCEL";
            this.inEXCEL.Size = new System.Drawing.Size(75, 63);
            this.inEXCEL.TabIndex = 2;
            this.inEXCEL.Text = "Excel";
            this.inEXCEL.UseVisualStyleBackColor = true;
            // 
            // inXML
            // 
            this.inXML.Location = new System.Drawing.Point(49, 108);
            this.inXML.Name = "inXML";
            this.inXML.Size = new System.Drawing.Size(75, 63);
            this.inXML.TabIndex = 1;
            this.inXML.Text = "XML";
            this.inXML.UseVisualStyleBackColor = true;
            // 
            // inREST
            // 
            this.inREST.Location = new System.Drawing.Point(49, 39);
            this.inREST.Name = "inREST";
            this.inREST.Size = new System.Drawing.Size(75, 63);
            this.inREST.TabIndex = 0;
            this.inREST.Text = "REST";
            this.inREST.UseVisualStyleBackColor = true;
            // 
            // projetoIS
            // 
            this.projetoIS.AutoSize = true;
            this.projetoIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projetoIS.Location = new System.Drawing.Point(261, 47);
            this.projetoIS.Name = "projetoIS";
            this.projetoIS.Size = new System.Drawing.Size(635, 44);
            this.projetoIS.TabIndex = 5;
            this.projetoIS.Text = "Projeto de Integração de Sistemas";
            // 
            // executar
            // 
            this.executar.Location = new System.Drawing.Point(848, 566);
            this.executar.Name = "executar";
            this.executar.Size = new System.Drawing.Size(272, 55);
            this.executar.TabIndex = 6;
            this.executar.Text = "Correr fluxos";
            this.executar.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 647);
            this.Controls.Add(this.executar);
            this.Controls.Add(this.projetoIS);
            this.Controls.Add(this.INPUT);
            this.Controls.Add(this.output);
            this.Controls.Add(this.export);
            this.Controls.Add(this.import);
            this.Controls.Add(this.listaFluxos);
            this.Name = "Form1";
            this.Text = "Form1";
            this.output.ResumeLayout(false);
            this.INPUT.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listaFluxos;
        private System.Windows.Forms.Button import;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.GroupBox output;
        private System.Windows.Forms.Button outHTML;
        private System.Windows.Forms.Button outREST;
        private System.Windows.Forms.GroupBox INPUT;
        private System.Windows.Forms.Button inEXCEL;
        private System.Windows.Forms.Button inXML;
        private System.Windows.Forms.Button inREST;
        private System.Windows.Forms.Label projetoIS;
        private System.Windows.Forms.Button executar;
    }
}

