using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_IS
{
    public partial class startup_import : Form
    {
        Main startupAux;
        public startup_import(Main formAux)
        {
            InitializeComponent();
            startupAux = formAux;
        }

        private void abrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "xml files (*.xml)|*.xml";
            if (abrir.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    startupAux.HandlerXML(Path.GetFullPath(abrir.FileName));
                    this.Close();
                } catch
                {
                    MessageBox.Show("Erro a processar o ficheiro!");
                }
            } else
            {
                MessageBox.Show("Erro a abrir o ficheiro!");
            }
        }

        private void novo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
