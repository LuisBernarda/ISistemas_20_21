
namespace Projeto_IS
{
    partial class inREST
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
            this.url = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.label_url = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // url
            // 
            this.url.Location = new System.Drawing.Point(105, 87);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(340, 22);
            this.url.TabIndex = 0;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(355, 147);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(93, 49);
            this.OK.TabIndex = 1;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(105, 147);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(93, 49);
            this.cancelar.TabIndex = 2;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // label_url
            // 
            this.label_url.AutoSize = true;
            this.label_url.Location = new System.Drawing.Point(105, 64);
            this.label_url.Name = "label_url";
            this.label_url.Size = new System.Drawing.Size(86, 17);
            this.label_url.TabIndex = 3;
            this.label_url.Text = "Insira a URL";
            // 
            // inREST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 277);
            this.Controls.Add(this.label_url);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.url);
            this.Name = "inREST";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox url;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Label label_url;
    }
}