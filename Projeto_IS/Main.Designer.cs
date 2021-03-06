﻿
namespace Projeto_IS
{
    partial class Main
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.output.SuspendLayout();
            this.INPUT.SuspendLayout();
            this.SuspendLayout();
            // 
            // listaFluxos
            // 
            this.listaFluxos.FormattingEnabled = true;
            this.listaFluxos.HorizontalScrollbar = true;
            this.listaFluxos.Location = new System.Drawing.Point(224, 126);
            this.listaFluxos.Margin = new System.Windows.Forms.Padding(2);
            this.listaFluxos.Name = "listaFluxos";
            this.listaFluxos.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listaFluxos.Size = new System.Drawing.Size(414, 225);
            this.listaFluxos.TabIndex = 0;
            // 
            // import
            // 
            this.import.Location = new System.Drawing.Point(376, 365);
            this.import.Margin = new System.Windows.Forms.Padding(2);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(104, 30);
            this.import.TabIndex = 1;
            this.import.Text = "Abrir Fluxos";
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(532, 365);
            this.export.Margin = new System.Windows.Forms.Padding(2);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(104, 30);
            this.export.TabIndex = 2;
            this.export.Text = "Guardar fluxos";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // output
            // 
            this.output.Controls.Add(this.outHTML);
            this.output.Controls.Add(this.outREST);
            this.output.Location = new System.Drawing.Point(690, 126);
            this.output.Margin = new System.Windows.Forms.Padding(2);
            this.output.Name = "output";
            this.output.Padding = new System.Windows.Forms.Padding(2);
            this.output.Size = new System.Drawing.Size(150, 224);
            this.output.TabIndex = 3;
            this.output.TabStop = false;
            this.output.Text = "OUTPUT";
            // 
            // outHTML
            // 
            this.outHTML.Location = new System.Drawing.Point(45, 121);
            this.outHTML.Margin = new System.Windows.Forms.Padding(2);
            this.outHTML.Name = "outHTML";
            this.outHTML.Size = new System.Drawing.Size(56, 51);
            this.outHTML.TabIndex = 1;
            this.outHTML.Text = "HTML";
            this.outHTML.UseVisualStyleBackColor = true;
            this.outHTML.Click += new System.EventHandler(this.outHTML_Click);
            // 
            // outREST
            // 
            this.outREST.Location = new System.Drawing.Point(45, 55);
            this.outREST.Margin = new System.Windows.Forms.Padding(2);
            this.outREST.Name = "outREST";
            this.outREST.Size = new System.Drawing.Size(56, 51);
            this.outREST.TabIndex = 0;
            this.outREST.Text = "REST";
            this.outREST.UseVisualStyleBackColor = true;
            this.outREST.Click += new System.EventHandler(this.outREST_Click);
            // 
            // INPUT
            // 
            this.INPUT.Controls.Add(this.inEXCEL);
            this.INPUT.Controls.Add(this.inXML);
            this.INPUT.Controls.Add(this.inREST);
            this.INPUT.Location = new System.Drawing.Point(29, 126);
            this.INPUT.Margin = new System.Windows.Forms.Padding(2);
            this.INPUT.Name = "INPUT";
            this.INPUT.Padding = new System.Windows.Forms.Padding(2);
            this.INPUT.Size = new System.Drawing.Size(150, 224);
            this.INPUT.TabIndex = 4;
            this.INPUT.TabStop = false;
            this.INPUT.Text = "INPUT";
            // 
            // inEXCEL
            // 
            this.inEXCEL.Location = new System.Drawing.Point(37, 144);
            this.inEXCEL.Margin = new System.Windows.Forms.Padding(2);
            this.inEXCEL.Name = "inEXCEL";
            this.inEXCEL.Size = new System.Drawing.Size(56, 51);
            this.inEXCEL.TabIndex = 2;
            this.inEXCEL.Text = "Excel";
            this.inEXCEL.UseVisualStyleBackColor = true;
            this.inEXCEL.Click += new System.EventHandler(this.inEXCEL_Click);
            // 
            // inXML
            // 
            this.inXML.Location = new System.Drawing.Point(37, 88);
            this.inXML.Margin = new System.Windows.Forms.Padding(2);
            this.inXML.Name = "inXML";
            this.inXML.Size = new System.Drawing.Size(56, 51);
            this.inXML.TabIndex = 1;
            this.inXML.Text = "XML";
            this.inXML.UseVisualStyleBackColor = true;
            this.inXML.Click += new System.EventHandler(this.inXML_Click);
            // 
            // inREST
            // 
            this.inREST.Location = new System.Drawing.Point(37, 32);
            this.inREST.Margin = new System.Windows.Forms.Padding(2);
            this.inREST.Name = "inREST";
            this.inREST.Size = new System.Drawing.Size(56, 51);
            this.inREST.TabIndex = 0;
            this.inREST.Text = "REST";
            this.inREST.UseVisualStyleBackColor = true;
            this.inREST.Click += new System.EventHandler(this.inREST_Click);
            // 
            // projetoIS
            // 
            this.projetoIS.AutoSize = true;
            this.projetoIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projetoIS.Location = new System.Drawing.Point(196, 38);
            this.projetoIS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.projetoIS.Name = "projetoIS";
            this.projetoIS.Size = new System.Drawing.Size(501, 36);
            this.projetoIS.TabIndex = 5;
            this.projetoIS.Text = "Projeto de Integração de Sistemas";
            // 
            // executar
            // 
            this.executar.Location = new System.Drawing.Point(644, 460);
            this.executar.Margin = new System.Windows.Forms.Padding(2);
            this.executar.Name = "executar";
            this.executar.Size = new System.Drawing.Size(196, 45);
            this.executar.TabIndex = 6;
            this.executar.Text = "Correr fluxos";
            this.executar.UseVisualStyleBackColor = true;
            this.executar.Click += new System.EventHandler(this.executar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(224, 365);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 30);
            this.button1.TabIndex = 7;
            this.button1.Text = "Eliminar Fluxos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(29, 460);
            this.cancelar.Margin = new System.Windows.Forms.Padding(2);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(196, 45);
            this.cancelar.TabIndex = 8;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 526);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.executar);
            this.Controls.Add(this.projetoIS);
            this.Controls.Add(this.INPUT);
            this.Controls.Add(this.output);
            this.Controls.Add(this.export);
            this.Controls.Add(this.import);
            this.Controls.Add(this.listaFluxos);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
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
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cancelar;
    }
}

