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
    public partial class inREST : Form
    {
        Main formAux;

        public inREST(Main mainAux)
        {
            InitializeComponent();
            //recebe a main form de modo a alterar as variaveis da main de inMethod e inPath
            formAux = mainAux;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            //validaçao se string vazia
            if (String.IsNullOrEmpty(url.Text))
            {
                MessageBox.Show("Erro! Por favor introduza um URL");
            } else
            {
                //validacao se URI inserida é válida com recurso à biblioteca URI
                Uri outUri;

                if (Uri.TryCreate(url.Text, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps))
                {
                    MessageBox.Show("Sucesso!");
                    //guardar na main form a uri validada
                    formAux.inPath = url.Text;
                    formAux.inMethod = "GET";
                    formAux.permitirOutput();
                    this.Close();
                } else
                {
                    MessageBox.Show("Erro! URI Inválida!");
                }
                
            }

        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
