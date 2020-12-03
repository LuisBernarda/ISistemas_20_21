using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_IS
{
    public partial class inXML : Form
    {
        Main formXML;

        public inXML(Main mainXML)
        {
            InitializeComponent();
            formXML = mainXML;
        }
        //Função do FORM_LOAD
        private void inXML_Load(object sender, EventArgs e)
        {

        }

        //FUÇÂO DO BUTÂO PARA ADICIONAR XML
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog2.InitialDirectory = Application.StartupPath;
            openFileDialog2.Filter = "xml files (*.xml)|*.xml";

            if (openFileDialog2.ShowDialog() == DialogResult.OK) {

                textBox1.Text = openFileDialog2.FileName;
                MessageBox.Show(textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
