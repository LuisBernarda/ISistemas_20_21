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
using System.Xml;
using Newtonsoft.Json;

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

                string path = openFileDialog2.FileName;
                textBox1.Text = path;
                MessageBox.Show(textBox1.Text);
                XmlDocument doc = new XmlDocument();

                doc.Load(path);

                //A variavel "jsonText" contem  o JSON já convertido 
                string jsonText = JsonConvert.SerializeXmlNode(doc);
                
                /*
                MessageBox.Show(jsonText);
                
                String output = "C:\\Users\\Celso Reis\\Desktop\\file.json"; 
                using (FileStream fs = new FileStream(output, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write)){
                    StreamWriter write = new StreamWriter(fs);
                    write.Write(JsonConvert.SerializeObject(jsonText));
                    write.Flush();
                    write.Close();
                    fs.Close();
                }*/
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
