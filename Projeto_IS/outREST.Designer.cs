
namespace Projeto_IS
{
    partial class outREST
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
            this.okOut = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.method = new System.Windows.Forms.ComboBox();
            this.url = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.metodo = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // okOut
            // 
            this.okOut.Location = new System.Drawing.Point(598, 358);
            this.okOut.Name = "okOut";
            this.okOut.Size = new System.Drawing.Size(131, 50);
            this.okOut.TabIndex = 0;
            this.okOut.Text = "OK";
            this.okOut.UseVisualStyleBackColor = true;
            this.okOut.Click += new System.EventHandler(this.okOut_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(88, 358);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(131, 50);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Cancelar";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // method
            // 
            this.method.FormattingEnabled = true;
            this.method.Items.AddRange(new object[] {
            "PUT",
            "POST"});
            this.method.Location = new System.Drawing.Point(88, 276);
            this.method.Name = "method";
            this.method.Size = new System.Drawing.Size(186, 24);
            this.method.TabIndex = 2;
            // 
            // url
            // 
            this.url.Location = new System.Drawing.Point(88, 183);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(641, 22);
            this.url.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Método";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Insira a URI alvo";
            // 
            // metodo
            // 
            this.metodo.FormattingEnabled = true;
            this.metodo.ItemHeight = 16;
            this.metodo.Items.AddRange(new object[] {
            "PUT",
            "POST"});
            this.metodo.Location = new System.Drawing.Point(234, 287);
            this.metodo.Name = "metodo";
            this.metodo.Size = new System.Drawing.Size(8, 4);
            this.metodo.TabIndex = 6;
            // 
            // outREST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metodo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.url);
            this.Controls.Add(this.method);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.okOut);
            this.Name = "outREST";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okOut;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ComboBox method;
        private System.Windows.Forms.TextBox url;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox metodo;
    }
}