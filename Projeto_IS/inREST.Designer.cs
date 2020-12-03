
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
            this.url.Location = new System.Drawing.Point(210, 169);
            this.url.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(676, 38);
            this.url.TabIndex = 0;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(710, 285);
            this.OK.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(186, 95);
            this.OK.TabIndex = 1;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(210, 285);
            this.cancelar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(186, 95);
            this.cancelar.TabIndex = 2;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // label_url
            // 
            this.label_url.AutoSize = true;
            this.label_url.Location = new System.Drawing.Point(210, 124);
            this.label_url.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_url.Name = "label_url";
            this.label_url.Size = new System.Drawing.Size(170, 32);
            this.label_url.TabIndex = 3;
            this.label_url.Text = "Insira a URL";
            // 
            // inREST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 537);
            this.Controls.Add(this.label_url);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.url);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "inREST";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.inREST_Load);
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