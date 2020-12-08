
namespace Projeto_IS
{
    partial class startup_import
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
            this.label1 = new System.Windows.Forms.Label();
            this.abrir = new System.Windows.Forms.Button();
            this.novo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(422, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Deseja importar um ficheiro de fluxos?";
            // 
            // abrir
            // 
            this.abrir.Location = new System.Drawing.Point(382, 145);
            this.abrir.Name = "abrir";
            this.abrir.Size = new System.Drawing.Size(93, 35);
            this.abrir.TabIndex = 1;
            this.abrir.Text = "Abrir";
            this.abrir.UseVisualStyleBackColor = true;
            this.abrir.Click += new System.EventHandler(this.abrir_Click);
            // 
            // novo
            // 
            this.novo.Location = new System.Drawing.Point(58, 145);
            this.novo.Name = "novo";
            this.novo.Size = new System.Drawing.Size(93, 35);
            this.novo.TabIndex = 2;
            this.novo.Text = "Cancelar";
            this.novo.UseVisualStyleBackColor = true;
            this.novo.Click += new System.EventHandler(this.novo_Click);
            // 
            // startup_import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 224);
            this.Controls.Add(this.novo);
            this.Controls.Add(this.abrir);
            this.Controls.Add(this.label1);
            this.Name = "startup_import";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button abrir;
        private System.Windows.Forms.Button novo;
    }
}